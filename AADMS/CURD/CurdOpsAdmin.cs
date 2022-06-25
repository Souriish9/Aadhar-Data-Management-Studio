using AADMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AADMS.CURD
{
    public class CurdOpsAdmin
    {
        public static bool Login(Admin admin)
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-KHL9E1P\\SQLEXPRESS;Initial Catalog=ADMS;Integrated Security=true"))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SP_ADMIN_LOGIN", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Emailid", admin.EMAIL);
                com.Parameters.AddWithValue("@Password", admin.PASSWORD);

                SqlDataReader dr = com.ExecuteReader();

                if(dr.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool AddAdmin(Admin admin)
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-KHL9E1P\\SQLEXPRESS;Initial Catalog=ADMS;Integrated Security=true"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_ADD_ADMIN", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NAME", admin.NAME);
                cmd.Parameters.AddWithValue("@EMAIL", admin.EMAIL);
                cmd.Parameters.AddWithValue("@PASSWORD", admin.PASSWORD);
                cmd.Parameters.AddWithValue("@DEPARTMENT", admin.DEPARTMENT);

                int x = cmd.ExecuteNonQuery();

                if (x > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
