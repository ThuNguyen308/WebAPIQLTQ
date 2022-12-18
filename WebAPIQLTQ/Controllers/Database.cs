using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAPIQLTQ.Models;

namespace WebAPIQLTQ.Controllers
{
    public class Database
    {
        public static DataTable Read_Table(string StoredProcedureName, Dictionary<string, object> dic_param = null)
        {
            string SQLconnectionString = ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString;
            DataTable result = new DataTable("table1");
            using (SqlConnection conn = new SqlConnection(SQLconnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.Connection = conn;
                cmd.CommandText = StoredProcedureName;
                cmd.CommandType = CommandType.StoredProcedure;
                if (dic_param != null)
                {
                    foreach (KeyValuePair<string, object> data in dic_param)
                    {
                        if (data.Value == null)
                        {
                            cmd.Parameters.AddWithValue("@" + data.Key, DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@" + data.Key, data.Value);
                        }
                    }
                }
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(result);

                }
                catch (Exception ex)
                {

                }
            }
            return result;
        }

        public static object Exec_Command(string StoredProcedureName, Dictionary<string, object> dic_param = null)
        {
            string SQLconnectionString = ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString;
            object result = null;
            using (SqlConnection conn = new SqlConnection(SQLconnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();

                // Start a local transaction.

                cmd.Connection = conn;
                cmd.CommandText = StoredProcedureName;
                cmd.CommandType = CommandType.StoredProcedure;

                if (dic_param != null)
                {
                    foreach (KeyValuePair<string, object> data in dic_param)
                    {
                        if (data.Value == null)
                        {
                            cmd.Parameters.AddWithValue("@" + data.Key, DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@" + data.Key, data.Value);
                        }
                    }
                }
                cmd.Parameters.Add("@CurrentID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    cmd.ExecuteNonQuery();
                    result = cmd.Parameters["@CurrentID"].Value;
                    // Attempt to commit the transaction.

                }
                catch (Exception ex)
                {
                    result = null;
                }

            }
            return result;
        }

        public static User Signup(User u)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("userName", u.userName);
            param.Add("email", u.email);
            param.Add("password", u.password);
            int kq = int.Parse(Exec_Command("Signup", param).ToString());
            if (kq > -1)
                u.userId = kq;
            return u;
        }
        public static int UpdateUserInfo(User u)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("userId", u.userId);
            param.Add("userName", u.userName);
            param.Add("email", u.email);
            param.Add("password", u.password);
            param.Add("userImage", u.userImage);
            int kq = int.Parse(Exec_Command("Update_UserInfo", param).ToString());
            return kq;
        }
        public static User Login(string userName, string password)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("userName", userName);
            param.Add("password", password);
            DataTable tb = Read_Table("Login", param);
            User kq = new User();
            if (tb.Rows.Count > 0)
            {
                kq.userId = int.Parse(tb.Rows[0]["userId"].ToString());
                kq.userName = tb.Rows[0]["userName"].ToString();
                kq.email = tb.Rows[0]["email"].ToString();
                kq.password = tb.Rows[0]["password"].ToString();
                kq.userImage = tb.Rows[0]["userImage"].ToString();
            }
            else
                kq.userId = 0;
            return kq;
        }
        public static DataTable GetColorList()
        {
            return Read_Table("GetColorList");
        }
        public static DataTable GetIconList()
        {
            return Read_Table("GetIconList");
        }
        public static DataTable GetCategoryList(int userId)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("userId", userId);
            return Read_Table("GetCategoryList", param);
        }
        public static int CreateCategory(Category ct)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("categoryName", ct.categoryName);
            param.Add("colorId", ct.colorId);
            param.Add("iconId", ct.iconId);
            param.Add("userId", ct.userId);
            int kq = int.Parse(Exec_Command("Create_Category", param).ToString());
            return kq;
        }
        public static int UpdateCategory(Category ct)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("categoryId", ct.categoryId);
            param.Add("categoryName", ct.categoryName);
            param.Add("colorId", ct.colorId);
            param.Add("iconId", ct.iconId);
            int kq = int.Parse(Exec_Command("Update_Category", param).ToString());
            return kq;
        }
        public static int DeleteCategory(Category ct)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("categoryId", ct.categoryId);

            int kq = int.Parse(Exec_Command("Delete_Category", param).ToString());
            return kq;
        }
        public static DataTable GetHabitList(int userId)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("userId", userId);
            return Read_Table("GetCategoryList", param);
        }
        public static int CreateHabit(Habit h)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("habitName", h.habitName);
            param.Add("habitStartDate", h.habitStartDate.ToString("yyyy-MM-dd"));
            param.Add("habitEndDate", h.habitEndDate.ToString("yyyy-MM-dd"));
            param.Add("habitDescription", h.habitDescription);
            param.Add("categoryId", h.categoryId);
            param.Add("userId", h.userId);
            int kq = int.Parse(Exec_Command("Create_Habit", param).ToString());
            return kq;
        }
        public static int UpdateHabit(Habit h)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("habitId", h.habitId);
            param.Add("habitName", h.habitName);
            param.Add("habitStartDate", h.habitStartDate.ToString("yyyy-MM-dd"));
            param.Add("habitEndDate", h.habitEndDate.ToString("yyyy-MM-dd"));
            param.Add("habitDescription", h.habitDescription);
            param.Add("categoryId", h.categoryId);
            int kq = int.Parse(Exec_Command("Update_Habit", param).ToString());
            return kq;
        }
        public static int DeleteHabit(Habit h)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("habitId", h.habitId);

            int kq = int.Parse(Exec_Command("Delete_Habit", param).ToString());
            return kq;
        }
        public static DataTable GetCheckinList(Habit h)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("habitId", h.habitId);
            return Read_Table("GetCheckinList", param);
        }

        public static int Checkin(HabitHistory hh)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("habitId", hh.habitId);
            int kq = int.Parse(Exec_Command("Checkin", param).ToString());
            return kq;
        }
        public static int DeleteCheckin(HabitHistory hh)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("habitId", hh.habitId);
            int kq = int.Parse(Exec_Command("Delete_Checkin", param).ToString());
            return kq;
        }

    }
}