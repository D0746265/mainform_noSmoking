using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mainform_noSmoking.Models.SQLModel;

namespace mainform_noSmoking.Models.Grading
{
    public class WorkViewModel
    {
        public int Student_id { get; set; }
        public int Schule_id { get; set; }
        public int File_Image_id { get; set; }
        public int Pass_or_Not { get; set; }
        public string Student_name { get; set; }
        public int Student_grade { get; set; }
        public string Student_class { get; set; }
        public string File_location { get; set; }
        public string File_base64 { get; set; }
        public string Work_concept { get; set; }
        public StudentInfo StudentInfo { get; set; }
        public FileInfo FileInfo { get; set; }
        public SchuleInfo SchuleInfo { get; set; }
    }
}
