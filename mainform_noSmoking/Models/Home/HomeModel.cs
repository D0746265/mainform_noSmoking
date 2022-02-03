using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mainform_noSmoking.Models.SQLModel;
using mainform_noSmoking.Models.Grading;

namespace mainform_noSmoking.Models.Home
{
    public class HomeModel
    {
        public HomeContext HomeContext { get; set; }
        public ShareModel ShareModel { get; set; }
        public List<WorkViewModel> ViewModels { get; set; }
        public List<WorkViewModel> ViewModels_L { get; set; }
        public List<WorkViewModel> ViewModels_M { get; set; }
        public List<WorkViewModel> ViewModels_H { get; set; }
        public HomeModel()
        {
            HomeContext ??= new HomeContext(DBTest.ConnectionString);
            ShareModel ??= new ShareModel();
            ViewModels ??= new List<WorkViewModel>();
        }
        public FileInfo FileInfo { get; set; }
        public StudentInfo StudentInfo { get; set; }

        public void Initial()
        {
            ShareModel.ViewModel.StudentInfo = new StudentInfo()
            {
                Student_id = 0,
                Schule_id = 0,
                File_Image_id = 0,
                Student_grade = 0,
                Student_class = "",
                Student_name = ""
            };
            ShareModel.ViewModel.FileInfo = new FileInfo()
            {
                File_base64 = "",
                Work_concept = ""
            };
            ShareModel.ViewModel.SchuleInfo = new SchuleInfo()
            {
                Schule_name = "",
                Location_name = ""
            };
        }
        public void GetWorks()
        {
            ShareModel.GetDistrict();

            int NumOfStudent = 5;
            List<StudentInfo> LowGrade;
            List<StudentInfo> MedGrade;
            List<StudentInfo> HighGrade;

            HomeContext.GetLatestStudent(NumOfStudent, 1, out LowGrade);
            HomeContext.GetLatestStudent(NumOfStudent, 3, out MedGrade);
            HomeContext.GetLatestStudent(NumOfStudent, 5, out HighGrade);

            ViewModels_L = new();
            ViewModels_M = new();
            ViewModels_H = new();

            foreach (StudentInfo studentInfo in LowGrade)
            {
                ShareModel.GetWork(studentInfo.Student_id);
                Anonymously(ShareModel);
                ViewModels_L.Add(ShareModel.ViewModel);
            }
            foreach (StudentInfo studentInfo in MedGrade)
            {
                ShareModel.GetWork(studentInfo.Student_id);
                Anonymously(ShareModel);
                ViewModels_M.Add(ShareModel.ViewModel);
            }
            foreach (StudentInfo studentInfo in HighGrade)
            {
                ShareModel.GetWork(studentInfo.Student_id);
                Anonymously(ShareModel);
                ViewModels_H.Add(ShareModel.ViewModel);
            }
        }
        public void ShowWorks(int grade, int status)
        {
            ShareModel.GetDistrict();

            Initial();

            List<StudentInfo> tmp = ShareModel.GetWorks(0, grade, status);

            //HomeContext.GetAllWorks(out List<StudentInfo> tmp);

            ViewModels = new List<WorkViewModel>();
            foreach (StudentInfo studentInfo in tmp)
            {
                ShareModel.GetWork(studentInfo.Student_id);
                Anonymously(ShareModel);
                ViewModels.Add(ShareModel.ViewModel);
            }
            return;
        }
        public void GetSchules(string district) { 
            ShareModel.GetSchules(district);
            return;
        }
        public void GetSchuleWorks(int schule_id)
        {
            //HomeContext.GetSelectWorks(schule_id, out List<StudentInfo> tmp);
            List<StudentInfo> tmp = ShareModel.GetWorks(schule_id, 0, 1);

            ViewModels = new List<WorkViewModel>();
            foreach(StudentInfo studentInfo in tmp)
            {
                ShareModel.GetWork(studentInfo.Student_id);
                Anonymously(ShareModel);
                ViewModels.Add(ShareModel.ViewModel);
            }
        }
        public void GetImage(int student_id)
        {
            ShareModel.GetWork(student_id);
            Anonymously(ShareModel);
        }
        public void GetWorks(int schule_id, int grade, int status)
        {
            //Useless

            Initial();

            List<StudentInfo> tmp;
            
            tmp = ShareModel.GetWorks(schule_id, grade, status);

            ShareModel.ViewModels = new List<WorkViewModel>();
            foreach (StudentInfo studentInfo in tmp)
            {
                ShareModel.GetWork(studentInfo.Student_id);
                Anonymously(ShareModel);
                ShareModel.ViewModels.Add(ShareModel.ViewModel);
            }
            ViewModels = ShareModel.ViewModels;
        }
        public ShareModel Anonymously(ShareModel shareModel)
        {
            try
            {
                shareModel.ViewModel.StudentInfo.Student_name = shareModel.ViewModel.StudentInfo.Student_name.Remove(1, 1).Insert(1, "〇");
            }
            catch(ArgumentOutOfRangeException)
            {
                return shareModel;
            }
            return shareModel;
        }
    }
}
