using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mainform_noSmoking.Models.SQLModel;

namespace mainform_noSmoking.Models.Grading
{
    public class GradingModel
    {
        public GradingContext GradingContext { get; set; }
        public ShareModel ShareModel { get; set; }
        public GradingModel()
        {
            GradingContext ??= new GradingContext(DBTest.ConnectionString);
            ShareModel ??= new ShareModel();
        }
        public void GetAllWork(int grade, int status)
        {
            //ShareModel.GetAllWork(0);//Means get all Pending works

            ShareModel.ViewModel.StudentInfo = new StudentInfo();
            ShareModel.ViewModel.FileInfo = new FileInfo();
            ShareModel.ViewModel.SchuleInfo = new SchuleInfo();

            ShareModel.ViewModel.StudentInfo.Student_id = 0;
            ShareModel.ViewModel.StudentInfo.Schule_id = 0;
            ShareModel.ViewModel.StudentInfo.File_Image_id = 0;
            ShareModel.ViewModel.StudentInfo.Student_grade = 0;
            ShareModel.ViewModel.StudentInfo.Student_class = "";
            ShareModel.ViewModel.StudentInfo.Student_name = "";
            ShareModel.ViewModel.StudentInfo.Teacher_name = "";
            ShareModel.ViewModel.StudentInfo.Teacher_phone = "";

            ShareModel.ViewModel.FileInfo.File_base64 = "";
            ShareModel.ViewModel.FileInfo.Work_concept = "";
            ShareModel.ViewModel.FileInfo.Upload_time = "";
            ShareModel.ViewModel.FileInfo.File_location = "";

            ShareModel.ViewModel.SchuleInfo.Schule_name = "";
            ShareModel.ViewModel.SchuleInfo.Location_name = "";
            
            GetWorksByGrade(grade, status);
        }
        public void GetImage(int student_id)
        {
            ShareModel.GetWork(student_id);
        }
        public void SetPassStatus(int student_id, int pass_status)
        {
            GradingContext.SetPassStatus(student_id, pass_status);
        }
        public void GetWorksByGrade(int grade, int status)
        {
            List<StudentInfo> tmp;
            if(status == 3)
            {
                GradingContext.GetWorksByGrade(grade, status, out tmp);
            }
            else
            {
                tmp = ShareModel.GetWorks(0, grade, status);

            }
            ShareModel.ViewModels = new List<WorkViewModel>();
            foreach (StudentInfo studentInfo in tmp) 
            {
                ShareModel.GetWork(studentInfo.Student_id);
                ShareModel.ViewModels.Add(ShareModel.ViewModel);
            }

        }
    }
}
