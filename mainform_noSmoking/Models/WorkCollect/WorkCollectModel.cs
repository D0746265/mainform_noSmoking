using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using mainform_noSmoking.Models.SQLModel;


namespace mainform_noSmoking.Models.WorkCollect
{
    public class WorkCollectModel
    {
        public WorkCollectContext WorkCollectContext { get; set; }
        public ShareModel ShareModel { get; set; }

        public List<SchuleInfo> SchuleInfoList;

        public List<string> Districts;
        public List<SelectListItem> DistrictList;

        public List<string> Schules;//dele
        //public List<SelectListItem> SchuleList;

        public StudentInfo StudentInfo { get; set; }
        public SchuleInfo SchuleInfo { get; set; }

        public FileInfo FileInfo { get; set; }

        public string File_base64;

        public WorkCollectModel()
        {
            WorkCollectContext ??= new WorkCollectContext(DBTest.ConnectionString);
            ShareModel ??= new ShareModel();
        }
        public List<SelectListItem> GetDistrict()//dele
        {
            //List<SelectListItem> temp = new List<SelectListItem>();
            //WorkCollectContext.GetDistrict(out Districts);

            //foreach(string t in Districts)
            //{
            //    temp.Add(new SelectListItem()
            //    {
            //        Text = t
            //    });
            //}
            //DistrictList = temp;

            DistrictList = ShareModel.GetDistrict();
            //Remove 'all district' option
            DistrictList.RemoveAt(0);

            return DistrictList;
        }
        public List<string> GetSchules(string district)//dele
        {
            //List<string> temp = new List<string>();
            //WorkCollectContext.GetSchuleInDistrict(district, out Schules);

            Schules = ShareModel.GetSchules(district);

            return Schules;
        }
        public void PostSaveFileInfo(string file_name, string base64, string file_location)
        {
            FileInfo.Original_name = file_name;
            FileInfo.File_base64 = base64;
            FileInfo.File_location = file_location;

            StudentInfo.File_Image_id = WorkCollectContext.SaveFile(FileInfo);
            StudentInfo.Pass_or_Not = 0;

            WorkCollectContext.SaveWork(StudentInfo);

        }

        public void PostSaveWork(IFormCollection data)
        {
            string Location_name = DistrictList[Convert.ToInt16(data["Location_name"]) - 1].Text;

            int Schule_id = WorkCollectContext.GetSchule_id(Location_name, data["Schule_name"]);

            SchuleInfo = new()
            {
                Schule_id = Schule_id,
                Schule_name = data["Schule_name"],
                Location_name = data["Location_name"]
            };

            StudentInfo = new()
            {
                Schule_id = Schule_id,
                //File_Image_id = File_Image_id,
                Student_name = data["Student_name"],
                Student_grade = Convert.ToInt16(data["Student_grade"]),
                Student_class = data["Student_class"],
                Teacher_name = data["Teacher_name"],
                Teacher_phone = data["Teacher_phone"],
                Email_address = data["Email_address"]
            };
            
            DateTime timeUtc = DateTime.UtcNow;
            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Taipei Standard Time");
            DateTime tstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);
            FileInfo = new()
            {
                Upload_time = tstTime.ToString("yyyy-MM-dd HH:mm"),
                Work_concept = data["Work_concept"]
            };
            

        }
    }
}
