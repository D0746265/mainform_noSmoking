using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using mainform_noSmoking.Models.SQLModel;

namespace mainform_noSmoking.Models
{
    public class ShareContext
    {
        public string ConnectionString { get; set; }
        public ShareContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        private static FileInfo MappingFileToClass(SqlDataReader reader)
        {
            FileInfo result = new FileInfo
            {
                File_Image_id = (reader["File_Image_id"] == DBNull.Value) ? 0 : Convert.ToInt16(reader["File_Image_id"]),
                File_location = (reader["File_location"] == DBNull.Value) ? string.Empty : reader["File_location"].ToString(),
                File_base64 = (reader["File_base64"] == DBNull.Value) ? string.Empty : reader["File_base64"].ToString(),
                Upload_time = (reader["Upload_time"] == DBNull.Value) ? null : reader["Upload_time"].ToString(),
                Original_name = (reader["Original_name"] == DBNull.Value) ? string.Empty : reader["Original_name"].ToString(),
                Work_concept = (reader["Work_concept"] == DBNull.Value) ? string.Empty : reader["Work_concept"].ToString()
            };
            return result;
        }
        private static StudentInfo MappingStudentToClass(SqlDataReader reader)
        {
            StudentInfo result = new StudentInfo
            {
                Student_id = (reader["Student_id"] == DBNull.Value) ? 0 : Convert.ToInt16(reader["Student_id"]),
                Schule_id = (reader["Schule_id"] == DBNull.Value) ? 0 : Convert.ToInt16(reader["Schule_id"]),
                File_Image_id = (reader["File_Image_id"] == DBNull.Value) ? 0 : Convert.ToInt16(reader["File_Image_id"]),
                Pass_or_Not = (reader["Pass_or_Not"] == DBNull.Value) ? 0 : Convert.ToInt16(reader["Pass_or_Not"]),
                Student_name = (reader["Student_name"] == DBNull.Value) ? string.Empty : reader["Student_name"].ToString(),
                Student_grade = (reader["Student_grade"] == DBNull.Value) ? 0 : Convert.ToInt16(reader["Student_grade"]),
                Student_class = (reader["Student_class"] == DBNull.Value) ? string.Empty : reader["Student_class"].ToString(),
                Teacher_name = (reader["Teacher_name"] == DBNull.Value) ? string.Empty : reader["Teacher_name"].ToString(),
                Teacher_phone = (reader["Teacher_phone"] == DBNull.Value) ? string.Empty : reader["Teacher_phone"].ToString(),
                Email_address = (reader["Email_address"] == DBNull.Value) ? string.Empty : reader["Email_address"].ToString()
            };
            return result;
        }
        private SchuleInfo MappingSchuleToClass(SqlDataReader reader)
        {
            SchuleInfo result = new SchuleInfo
            {
                Schule_id = (reader["Schule_id"] == DBNull.Value) ? 0 : Convert.ToUInt16(reader["Schule_id"]),
                Location_name = (reader["Location_name"] == DBNull.Value) ? string.Empty : reader["Location_name"].ToString(),
                Schule_name = (reader["Schule_name"] == DBNull.Value) ? string.Empty : reader["Schule_name"].ToString()
            };
            return result;
        }
        public bool GetDistrict(out List<string> districts)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    List<string> tmp = new List<string>();
                    SqlCommand cmd = new SqlCommand("SELECT DISTINCT Location_name FROM wo.dbo.Schule_info;", conn);
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string tmpstr = (reader["Location_name"] == DBNull.Value) ? string.Empty : reader["Location_name"].ToString();
                            tmp.Add(tmpstr);
                        }
                    }
                    conn.Close();
                    districts = tmp;

                    return true;
                }
            }
            catch (Exception e) { string _ = e.ToString(); }

            districts = new List<string>();
            return false;
        }
        public bool GetSchuleInDistrict(string location_name, out List<SchuleInfo> schules)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    List<SchuleInfo> tmp = new List<SchuleInfo>();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM wo.dbo.Schule_info WHERE Location_name = N'" + location_name + "';", conn);
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tmp.Add(MappingSchuleToClass(reader));
                        }
                    }
                    conn.Close();
                    schules = tmp;

                    return true;
                }
            }
            catch (Exception e) { string _ = e.ToString(); }

            schules = new List<SchuleInfo>();
            return false;
        }
        public bool GetImage(int File_Image_id, out FileInfo fileInfo)
        {
            //Get image by image id which is from student_info
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    FileInfo tmp = new FileInfo();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM wo.dbo.File_info WHERE File_Image_id = " + File_Image_id + ";", conn);
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tmp = MappingFileToClass(reader);
                        }
                    }
                    conn.Close();
                    fileInfo = tmp;
                }
                return true;
            }
            catch (Exception e) { string _ = e.ToString(); }

            fileInfo = new FileInfo();
            return false;
        }
        public bool GetSchule(int Schule_id, out SchuleInfo schuleInfo)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    SchuleInfo tmp = new SchuleInfo();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM wo.dbo.Schule_info WHERE Schule_id = " + Schule_id + ";", conn);
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tmp = MappingSchuleToClass(reader);
                        }
                    }
                    conn.Close();
                    schuleInfo = tmp;
                }
                return true;
            }
            catch (Exception e) { string _ = e.ToString(); }

            schuleInfo = new SchuleInfo();
            return false;
        }
        public bool GetAllImage(out List<FileInfo> fileInfos)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    List<FileInfo> tmp = new List<FileInfo>();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM wo.dbo.File_info;", conn);

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tmp.Add(MappingFileToClass(reader));
                        }
                    }
                    conn.Close();
                    fileInfos = tmp;

                    return true;
                }
            }
            catch (Exception e) { string _ = e.ToString(); }

            fileInfos = new List<FileInfo>();
            return false;
        }
        public bool GetStudent(int student_id, out StudentInfo studentInfo)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(ConnectionString)){
                    StudentInfo tmp = new StudentInfo();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM wo.dbo.Student_info WHERE Student_id = " + student_id + ";", conn);

                    conn.Open();
                    using(var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tmp = MappingStudentToClass(reader);
                        }
                    }
                    conn.Close();

                    studentInfo = tmp;
                    return true;
                }
            }
            catch (Exception e) { string _ = e.ToString(); }

            studentInfo = new StudentInfo();
            return false;
        }
        public bool GetAllStudentByPass_or_Not(int Pass_or_not, out List<StudentInfo> studentInfos)
        {
            //Get only not grade student which is Pass_or_Not = 0
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    List<StudentInfo> tmp = new List<StudentInfo>();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM wo.dbo.Student_info WHERE Pass_or_Not = " + Pass_or_not + ";", conn);

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tmp.Add(MappingStudentToClass(reader));
                        }
                    }
                    conn.Close();

                    studentInfos = tmp;
                    return true;
                }
            }
            catch (Exception e) { string _ = e.ToString(); }
            studentInfos = new List<StudentInfo>();

            return false;
        }
        public bool GetWorks(int schule_id, int grade, int Pass_or_not, out List<StudentInfo> studentInfos)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    List<StudentInfo> tmp = new List<StudentInfo>();
                    string cmdstring = "";
                    if (schule_id == 0)
                    {
                        if (grade == 0)
                        {
                            cmdstring =
                                "SELECT * " +
                                "FROM wo.dbo.Student_info " +
                                "WHERE Pass_or_Not = " + Pass_or_not +
                                "ORDER BY Student_id DESC;";
                        }else if (grade < 6)
                        {
                            cmdstring =
                           "SELECT * " +
                           "FROM wo.dbo.Student_info " +
                           "WHERE ( Student_grade = " + grade + " OR Student_grade = " + (grade + 1) + " ) AND Pass_or_Not = " + Pass_or_not +
                           "ORDER BY Student_id DESC;";
                        }
                    }
                    else
                    {
                        if (grade == 0)
                        {
                            cmdstring =
                                "SELECT * " +
                                "FROM wo.dbo.Student_info " +
                                "WHERE Pass_or_Not = " + Pass_or_not + " AND Schule_id = " + schule_id +
                                "ORDER BY Student_id DESC;";
                        }
                        else if (grade < 6)
                        {
                            cmdstring =
                           "SELECT * " +
                           "FROM wo.dbo.Student_info " +
                           "WHERE ( Student_grade = " + grade + " OR Student_grade = " + (grade + 1) + " ) AND Pass_or_Not = " + Pass_or_not+ " AND Schule_id = " + schule_id +
                          "ORDER BY Student_id DESC;";
                        }
                    }
                    SqlCommand cmd = new SqlCommand(cmdstring, conn);
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tmp.Add(MappingStudentToClass(reader));
                        }
                        conn.Close();
                        studentInfos = tmp;

                        return true;
                    }
                }
            }
            catch (Exception e) { string _ = e.ToString(); }
            studentInfos = new List<StudentInfo>();

            return false;
        }
    }
}
