using System;
using System.Collections.Generic;
using System.Linq;
using mainform_noSmoking.Models.SQLModel;
using mainform_noSmoking.Models.Grading;
using ReflectionIT.Mvc.Paging;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace mainform_noSmoking.Models.AwardList
{
    public class AwardListModel
    {
        public ShareModel ShareModel { get; set; }
        public List<WorkViewModel> ViewModels { get; set; }
        public PagingList<WorkViewModel> ViewModelsInPaging { get; set; }
        public AwardListModel()
        {
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
        public void GetSchules(string district) { 
            ShareModel.GetSchules(district);
            return;
        }
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
