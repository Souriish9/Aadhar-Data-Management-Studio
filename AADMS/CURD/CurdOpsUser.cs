using AADMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AADMS.CURD
{
    public class CurdOpsUser
    {
        public bool AddUser(User user)
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-KHL9E1P\\SQLEXPRESS;Initial Catalog=ADMS;Integrated Security=true"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_ADD_USERDATA", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FIRSTNAME", user.FIRSTNAME);
                cmd.Parameters.AddWithValue("@LASTNAME", user.LASTNAME);
                cmd.Parameters.AddWithValue("@DOB", user.DOB);
                cmd.Parameters.AddWithValue("@PHONE", user.PHONE);
                cmd.Parameters.AddWithValue("@EMAIL", user.EMAIL);
                cmd.Parameters.AddWithValue("@OCCUPATION", user.OCCUPATION);
                cmd.Parameters.AddWithValue("@GENDER", user.GENDER);
                cmd.Parameters.AddWithValue("@MARTIALSTAT", user.MARTIALSTAT);
                cmd.Parameters.AddWithValue("@ADD_LINE1", user.ADD_LINE1);
                cmd.Parameters.AddWithValue("@ADD_LINE2", user.ADD_LINE2);
                cmd.Parameters.AddWithValue("@POSTALCODE", user.POSTALCODE);
                cmd.Parameters.AddWithValue("@CITY", user.CITY);
                cmd.Parameters.AddWithValue("@STATE", user.STATE);
                cmd.Parameters.AddWithValue("@COUNTRY", user.COUNTRY);
                cmd.Parameters.AddWithValue("@CO_FNAME", user.CO_FNAME);
                cmd.Parameters.AddWithValue("@CO_LNAME", user.CO_LNAME);

                if (CheckDuplicate(user) == true)
                {
                    return false;
                }

                int x = cmd.ExecuteNonQuery();

                if ((x > 0))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool CheckDuplicate(User user)
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-KHL9E1P\\SQLEXPRESS;Initial Catalog=ADMS;Integrated Security=true"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_DUPLICATE_USER", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FIRSTAME", user.FIRSTNAME);
                cmd.Parameters.AddWithValue("@LASTNAME", user.LASTNAME);
                cmd.Parameters.AddWithValue("@EMAIL", user.EMAIL);
                cmd.Parameters.AddWithValue("@ADD_LINE1", user.ADD_LINE1);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public static IEnumerable<User> getAllData()
        {
            List<User> lr = new List<User>();
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-KHL9E1P\\SQLEXPRESS;Initial Catalog=ADMS;Integrated Security=true"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_GETALL_USERDATA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    User user = new User();

                    user.UID = dr[0].ToString();
                    user.FIRSTNAME = dr[1].ToString();
                    user.LASTNAME = dr[2].ToString();
                    user.DOB = dr[3].ToString();
                    user.PHONE = dr[4].ToString();
                    user.EMAIL = dr[5].ToString();
                    user.OCCUPATION = dr[6].ToString();
                    user.GENDER = dr[7].ToString();
                    user.MARTIALSTAT = dr[8].ToString();
                    user.ADD_LINE1 = dr[9].ToString();
                    user.ADD_LINE2 = dr[10].ToString();
                    user.POSTALCODE = dr[11].ToString();
                    user.CITY = dr[12].ToString();
                    user.STATE = dr[13].ToString();
                    user.COUNTRY = dr[14].ToString();
                    user.CO_FNAME = dr[15].ToString();
                    user.CO_LNAME = dr[16].ToString();

                    lr.Add(user);
                }
                return lr;
            }

        }

        public static bool UserLogin(User user)
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-KHL9E1P\\SQLEXPRESS;Initial Catalog=ADMS;Integrated Security=true"))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SP_GET_USER_LOGIN", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@UID", user.UID);
                com.Parameters.AddWithValue("@EMAIL", user.EMAIL);

                SqlDataReader dr = com.ExecuteReader();

                if (dr.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static User getDataByAID(string AID)
        {
            User ur = new User();

            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-KHL9E1P\\SQLEXPRESS;Initial Catalog=ADMS;Integrated Security=true"))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SP_GET_USERDATA_BYAID", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@UID", AID);

                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {

                    ur.UID = dr[0].ToString();
                    ur.FIRSTNAME = dr[1].ToString();
                    ur.LASTNAME = dr[2].ToString();
                    ur.DOB = dr[3].ToString();
                    ur.PHONE = dr[4].ToString();
                    ur.EMAIL = dr[5].ToString();
                    ur.OCCUPATION = dr[6].ToString();
                    ur.GENDER = dr[7].ToString();
                    ur.MARTIALSTAT = dr[8].ToString();
                    ur.ADD_LINE1 = dr[9].ToString();
                    ur.ADD_LINE2 = dr[10].ToString();
                    ur.POSTALCODE = dr[11].ToString();
                    ur.CITY = dr[12].ToString();
                    ur.STATE = dr[13].ToString();
                    ur.COUNTRY = dr[14].ToString();
                    ur.CO_FNAME = dr[15].ToString();
                    ur.CO_LNAME = dr[16].ToString();

                }

                return ur;
            }
        }

        public static bool EditUser(User user)
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-KHL9E1P\\SQLEXPRESS;Initial Catalog=ADMS;Integrated Security=true"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_EDIT_DATABY_UID", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UID", user.UID);
                cmd.Parameters.AddWithValue("@FIRSTNAME", user.FIRSTNAME);
                cmd.Parameters.AddWithValue("@LASTNAME", user.LASTNAME);
                cmd.Parameters.AddWithValue("@DOB", user.DOB);
                cmd.Parameters.AddWithValue("@PHONE", user.PHONE);
                cmd.Parameters.AddWithValue("@EMAIL", user.EMAIL);
                cmd.Parameters.AddWithValue("@OCCUPATION", user.OCCUPATION);
                cmd.Parameters.AddWithValue("@GENDER", user.GENDER);
                cmd.Parameters.AddWithValue("@MARTIALSTAT", user.MARTIALSTAT);
                cmd.Parameters.AddWithValue("@ADD_LINE1", user.ADD_LINE1);
                cmd.Parameters.AddWithValue("@ADD_LINE2", user.ADD_LINE2);
                cmd.Parameters.AddWithValue("@POSTALCODE", user.POSTALCODE);
                cmd.Parameters.AddWithValue("@CITY", user.CITY);
                cmd.Parameters.AddWithValue("@STATE", user.STATE);
                cmd.Parameters.AddWithValue("@COUNTRY", user.COUNTRY);
                cmd.Parameters.AddWithValue("@CO_FNAME", user.CO_FNAME);
                cmd.Parameters.AddWithValue("@CO_LNAME", user.CO_LNAME);

                if (CheckDuplicate(user) == true)
                {
                    return false;
                }

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
