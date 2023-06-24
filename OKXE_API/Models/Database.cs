using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OKXE_API.Models
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

        public static DataTable LayDSXeTheoUser(string username)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("username", username);
            return Read_Table("LayDSXeTheoUser", param);
        }
        public static DataTable LayDSShopTheoUser(string username)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("username", username);
            return Read_Table("LayDSShopTheoUser", param);
        }
        public static DataTable LayDSXe()
        {
            return Read_Table("LayDSXe");
        }
        public static DataTable LayDSUser()
        {
            return Read_Table("LayDSUser");
        }
        public static DataTable LayDSShop()
        {
            return Read_Table("LayDSShop");
        }
        public static int CapNhatXe(Xe xe)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("maXe", xe.maXe);
            param.Add("trangThaiXe", xe.trangThaiXe);
            param.Add("loveImg", xe.loveImg);
            int kq = int.Parse(Exec_Command("Cap_Nhat_Xe", param).ToString());
            return kq;
        }

        public static int CapNhatShop(Shop shop)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("idShopXe", shop.idShopXe);
            param.Add("loveImg", shop.loveImg);
            int kq = int.Parse(Exec_Command("Cap_Nhat_Shop", param).ToString());
            return kq;
        }
        public static int ThemUser(User user)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("username", user.username);
            param.Add("mkUser", user.mkUser);
            param.Add("hoTenUser", user.hoTenUser);
            param.Add("phoneUser", user.phoneUser);
            param.Add("diaChiUser", user.diaChiUser);
            param.Add("emailUser", user.emailUser);
            param.Add("hinhUser", user.hinhUser);
            int kq = int.Parse(Exec_Command("Them_User", param).ToString());
            return kq;
        }

    }
}