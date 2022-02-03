namespace mainform_noSmoking.Models.SQLModel
{
    public class StudentInfo
    {
        public int Student_id { get; set; }
        public int Schule_id { get; set; }
        public int File_Image_id { get; set; }
        public int Pass_or_Not { get; set; }
        public string Student_name { get; set; }
        public int Student_grade { get; set; }
        public string Student_class { get; set; }
        public string Teacher_name { get; set; }
        public string Teacher_phone { get; set; }
        public string Email_address { get; set; }
    }
}
