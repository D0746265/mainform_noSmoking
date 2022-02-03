using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using mainform_noSmoking.Models.SQLModel;

namespace mainform_noSmoking.Models.WorkCollect
{
    public class WorkCollectContext
    {
        public string ConnectionString { get; set; }
        public WorkCollectContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        private SchuleInfo MappingToClass(SqlDataReader reader)
        {
            SchuleInfo result = new SchuleInfo
            {
                Schule_id = (reader["Schule_id"] == DBNull.Value) ? 0 : Convert.ToUInt16(reader["Schule_id"]),
                Location_name = (reader["Location_name"] == DBNull.Value) ? string.Empty : reader["Location_name"].ToString(),
                Schule_name = (reader["Schule_name"] == DBNull.Value) ? string.Empty : reader["Schule_name"].ToString()
            };
            return result;
        }
        public bool GetSchuleInfo(out List<SchuleInfo> schuleInfo)
        {
            try
            {
                using(SqlConnection conn =  new SqlConnection(ConnectionString))
                {
                    List<SchuleInfo> tmp = new List<SchuleInfo>();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM wo.dbo.Schule_info;");
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            tmp.Add(MappingToClass(reader));
                        }
                    }
                    schuleInfo = tmp;
                }
                return true;
            }
            catch(Exception e) { string _ = e.ToString(); }

            schuleInfo = new List<SchuleInfo>();
            return false;
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
        public bool GetSchuleInDistrict(string location_name, out List<string> schules)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    List<string> tmp = new List<String>();
                    SqlCommand cmd = new SqlCommand("SELECT Schule_name FROM wo.dbo.Schule_info WHERE Location_name = N'" + location_name + "';", conn);
                    conn.Open();
                    //cmd.Parameters.Add("@location_name", System.Data.SqlDbType.VarChar).Value = location_name;

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string tmpstr = (reader["Schule_name"] == DBNull.Value) ? string.Empty : reader["Schule_name"].ToString();
                            tmp.Add(tmpstr);
                        }
                    }
                    conn.Close();
                    schules = tmp;

                    return true;
                }
            }
            catch(Exception e) { string _ = e.ToString(); }

            schules = new List<string>();
            return false;
        }
        public int GetSchule_id(string district, string schuleName)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    int tmp = 0;
                    //string nested = "SELECT Schule_id FROM wo.dbo.Schule_info WHERE Schule_name IN (SELECT Schule_name FROM wo.dbo.Schule_info WHERE Location_name = N'士林區') AND Schule_name=N'市立士林國小';";
                    SqlCommand cmd = new SqlCommand(
                        "SELECT Schule_id FROM wo.dbo.Schule_info WHERE Schule_name=N'" + schuleName + "' AND Location_name= N'" + district + "';", conn);
                    conn.Open();

                    using(var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tmp = Convert.ToInt16(reader["Schule_id"]);
                        }
                    }
                    conn.Close();
                    return tmp;
                }
            }
            catch(Exception e) { string _ = e.ToString(); }

            return 0;
        }
        public int SaveFile(FileInfo fileInfo)
        {
            //DB Insert File_info and return File_Image_id at the same time
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO wo.dbo.File_info " +
                        "(File_base64, File_location, Upload_time, Original_name, Work_concept) " +
                        "VALUES ('" + fileInfo.File_base64 + "', N'" + fileInfo.File_location + "', '" + fileInfo.Upload_time + "', N'" + fileInfo.Original_name + "', N'" + fileInfo.Work_concept + "');", conn);

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch(Exception e) { string _ = e.ToString(); }

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    int image_id = 0;
                    SqlCommand cmd = new SqlCommand("SELECT File_Image_id FROM wo.dbo.File_info  WHERE File_base64 LIKE '" + fileInfo.File_base64.Substring(0, 128) + "%' AND Original_name = N'" + fileInfo.Original_name + "';", conn);

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            image_id = Convert.ToInt16(reader["File_Image_id"]);
                        }
                    }

                    conn.Close();
                    return image_id;
                }
            }
            catch (Exception e) { string _ = e.ToString(); }

            return 0;
        }
        public bool SaveWork(StudentInfo studentInfo)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    
                    SqlCommand cmd = new SqlCommand("INSERT INTO wo.dbo.Student_info (Schule_id, File_Image_id, Pass_or_Not, Student_name, Student_grade, Student_class, Teacher_name, Teacher_phone, Email_address) VALUES(" + studentInfo.Schule_id + ", " + studentInfo.File_Image_id + ",  " + studentInfo.Pass_or_Not + ", N'" + studentInfo.Student_name + "', " + studentInfo.Student_grade + ",  N'" + studentInfo.Student_class + "', N'" + studentInfo.Teacher_name + "', '" + studentInfo.Teacher_phone + "', '" + studentInfo.Email_address + "');", conn);

                    conn.Open();

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception e){ string _ = e.ToString(); }

            return false;
        }
    }
}
