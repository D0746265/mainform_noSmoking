using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mainform_noSmoking.Models.SQLModel
{
    public class FileInfo
    {
        public int File_Image_id { get; set; }
        public string File_location { get; set; }
        public string File_base64 { get; set; }
        public string Upload_time { get; set; }
        public string Original_name { get; set; }
        public string Work_concept { get; set; }
    }
}
