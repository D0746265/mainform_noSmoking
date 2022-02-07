using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mainform_noSmoking.Models.SQLModel;
using mainform_noSmoking.Models.Grading;
using ReflectionIT.Mvc.Paging;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public PagingList<WorkViewModel> ViewModelsInPaging { get; set; }
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
            ShareModel.GetDistrict();

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

            string[] gradeClass = { "低年級", "中年級", "高年級" };
            int index = 0;

            List<SelectListItem> temp = new List<SelectListItem>();
            temp.Add(new SelectListItem()
            {
                Text = "全部年級",
                Value = index.ToString()
            });
            index = 1;
            foreach (string t in gradeClass)
            {
                temp.Add(new SelectListItem()
                {
                    Text = t,
                    Value = index.ToString()
                });
                index += 2;
            }
            ShareModel.GradeSelectList = temp;
        }
        public void GetHomePageWorks(int NumOfStudent = 5)
        {            
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
        public void GetSchules(string district) { 
            ShareModel.GetSchules(district);
            return;
        }
        //public void ShowWorks(int grade, int status)
        //{          

        //    Initial();

        //    List<StudentInfo> tmp = ShareModel.GetWorks(0, grade, status);

        //    ViewModels = new List<WorkViewModel>();
        //    foreach (StudentInfo studentInfo in tmp)
        //    {
        //        ShareModel.GetWork(studentInfo.Student_id);
        //        Anonymously(ShareModel);
        //        ViewModels.Add(ShareModel.ViewModel);
        //    }
        //    return;
        //}
        //public void GetSchuleWorks(int schule_id)
        //{
        //    List<StudentInfo> tmp = ShareModel.GetWorks(schule_id, 0, 1);

        //    ViewModels = new List<WorkViewModel>();
        //    foreach(StudentInfo studentInfo in tmp)
        //    {
        //        ShareModel.GetWork(studentInfo.Student_id);
        //        Anonymously(ShareModel);
        //        ViewModels.Add(ShareModel.ViewModel);
        //    }
        //}
        public void GetImage(int student_id)
        {
            ShareModel.GetWork(student_id);
            Anonymously(ShareModel);
        }
        public void GetWorks(int schule_id, int grade, int status)
        {
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
                string anonymousName = "";
                int nameLength = shareModel.ViewModel.StudentInfo.Student_name.Count();
                int startIndex = 1;
                int removeCount = nameLength - 2;
                if (removeCount != 0)
                {
                    anonymousName = shareModel.ViewModel.StudentInfo.Student_name.Remove(startIndex, removeCount);
                    for (int i = startIndex; i <= removeCount; i++)
                    {
                        anonymousName = anonymousName.Insert(i, "〇");
                    }
                }
                else
                {
                    anonymousName = shareModel.ViewModel.StudentInfo.Student_name.Remove(startIndex, 1);
                    anonymousName = anonymousName.Insert(1, "〇");
                }
                shareModel.ViewModel.StudentInfo.Student_name = anonymousName;
                //shareModel.ViewModel.StudentInfo.Student_name = shareModel.ViewModel.StudentInfo.Student_name.Remove(1, 1).Insert(1, "〇");
            }
            catch(ArgumentOutOfRangeException)
            {
                return shareModel;
            }
            return shareModel;
        }
    }
}
