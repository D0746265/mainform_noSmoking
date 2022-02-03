using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mainform_noSmoking.Models.SQLModel;
using mainform_noSmoking.Models.Grading;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace mainform_noSmoking.Models
{
    public class ShareModel
    {
        public ShareContext ShareContext { get; set; }
        public List<WorkViewModel> ViewModels { get; set; }
        public WorkViewModel ViewModel { get; set; }

        public List<string> Districts;

        public List<SelectListItem> DistrictList;

        public List<string> Schules;
        public List<SchuleInfo> SchuleList;
        public List<string> SchuleSelectList;
        public ShareModel()
        {
            ShareContext ??= new ShareContext(DBTest.ConnectionString);
            ViewModel ??= new WorkViewModel();
        }
        public void GetAllWork(int status)
        {
            ShareContext.GetAllStudentByPass_or_Not(status, out List<StudentInfo> tmpStudentList);

            ViewModels = new List<WorkViewModel>();

            foreach (StudentInfo info in tmpStudentList)
            {
                Console.WriteLine(DateTime.Now.Second + "." +DateTime.Now.Millisecond);
                ShareContext.GetImage(info.File_Image_id, out FileInfo fileInfo);
                Console.WriteLine(DateTime.Now.Second + "." + DateTime.Now.Millisecond);
                ShareContext.GetSchule(info.Schule_id, out SchuleInfo schuleInfo);
                Console.WriteLine(DateTime.Now.Second + "." + DateTime.Now.Millisecond);
                ViewModels.Add(new WorkViewModel { StudentInfo = info, FileInfo = fileInfo, SchuleInfo = schuleInfo });
                Console.WriteLine(DateTime.Now.Second + "." + DateTime.Now.Millisecond);
                Console.WriteLine();
            }
        }
        public void GetWork(int student_id)
        {
            ViewModel = new WorkViewModel();

            ShareContext.GetStudent(student_id, out StudentInfo tmpStudent);
            ShareContext.GetImage(tmpStudent.File_Image_id, out FileInfo tmpFile);
            ShareContext.GetSchule(tmpStudent.Schule_id, out SchuleInfo tmpSchule);

            ViewModel.StudentInfo = tmpStudent;
            ViewModel.FileInfo = tmpFile;
            ViewModel.SchuleInfo = tmpSchule;
        }
        public List<SelectListItem> GetDistrict()
        {
            List<SelectListItem> temp = new List<SelectListItem>();
            ShareContext.GetDistrict(out Districts);

            foreach (string t in Districts)
            {
                temp.Add(new SelectListItem()
                {
                    Text = t
                });
            }
            DistrictList = temp;

            return DistrictList;
        }
        public List<string> GetSchules(string district)
        {
            List<string> temp = new List<string>();
            ShareContext.GetSchuleInDistrict(district, out SchuleList);

            foreach(SchuleInfo schuleInfo in SchuleList)
            {
                temp.Add(schuleInfo.Schule_name);
            }
            Schules = temp;

            List<string> tmp = new List<string>();
            foreach (SchuleInfo t in SchuleList)
            {
                tmp.Add(t.Schule_name + " " + t.Schule_id);
            }
            SchuleSelectList = tmp;

            return Schules;
        }
        public List<StudentInfo> GetWorks(int schule_id, int grade, int status)
        {
            ShareContext.GetWorks(schule_id, grade, status, out List<StudentInfo> tmp);

            return tmp;
        }
    }
}
