using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using mainform_noSmoking.Models.SQLModel;

namespace mainform_noSmoking.Models.Grading
{
    public class GradingContext
    {
        public string ConnectionString { get; set; }
        public GradingContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        private FileInfo MappingFileToClass(SqlDataReader reader)
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
        private StudentInfo MappingStudentToClass(SqlDataReader reader)
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
        public bool SetPassStatus(int student_id, int pass_status)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE wo.dbo.Student_info SET Pass_or_Not = " + pass_status + " WHERE Student_id = " + student_id + ";", conn);
                    conn.Open();

                    cmd.ExecuteNonQuery();

                    conn.Close();
                }

                return true;
            }
            catch(Exception e) { string _ = e.ToString(); }

            return false;
        }
        public bool GetWorksByGrade(int grade, int Pass_or_not, out List<StudentInfo> studentInfos)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    List<StudentInfo> tmp = new List<StudentInfo>();
                    string cmdstring = "";
                    if (grade == 0)
                    {
                        cmdstring =
                            "SELECT * " +
                            "FROM wo.dbo.Student_info " +
                            "ORDER BY Student_id ASC;";
                    }
                    else if (grade < 6)
                    {
                        cmdstring =
                       "SELECT * " +
                       "FROM wo.dbo.Student_info " +
                       "WHERE ( Student_grade = " + grade + " OR Student_grade = " + (grade + 1) + " ) " +
                       "ORDER BY Student_id ASC;";
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
