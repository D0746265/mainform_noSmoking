using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using mainform_noSmoking.Models.SQLModel;

namespace mainform_noSmoking.Models.Home
{
    public class HomeContext
    {
        public string ConnectionString { get; set; }
        public HomeContext(string connectionString)
        {
            this.ConnectionString = connectionString;
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
        public bool GetLatestStudent(int num, int grade, out List<StudentInfo> studentInfos)
        {//to add filter which is passed
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    List<StudentInfo> tmp = new List<StudentInfo>();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT TOP " + num + " * " +
                        "FROM wo.dbo.Student_info " +
                        "WHERE ( Student_grade = " + grade + " OR Student_grade = " + (grade + 1) + " ) AND  Pass_or_Not = 1" +
                        "ORDER BY Student_id DESC;", conn);
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
            catch(Exception e) { string _ = e.ToString(); }

            studentInfos = new List<StudentInfo>();

            return false;
        }
        public bool GetSelectWorks(int schule_id, out List<StudentInfo> studentInfos)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    List<StudentInfo> tmp = new List<StudentInfo>();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT * " +
                        "FROM wo.dbo.Student_info " +
                        "WHERE Schule_id = " + schule_id + ";", conn);
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
        public bool GetAllWorks(out List<StudentInfo> studentInfos)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    List<StudentInfo> tmp = new List<StudentInfo>();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT * " +
                        "FROM wo.dbo.Student_info " +
                        "WHERE Pass_or_Not = 1;", conn);
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
