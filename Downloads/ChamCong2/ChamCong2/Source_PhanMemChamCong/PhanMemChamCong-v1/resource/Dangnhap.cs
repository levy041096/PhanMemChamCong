using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;

namespace PhanMemChamCong.resource
{
    public class Dangnhap
    {
        SqlConnection myDBconnection = new SqlConnection(@"Data Source = .\SQLExpress; Initial Catalog = dbChamCong;  Integrated Security = True;");
        private static Dangnhap _Dangnhap;
        public string username, password;//bien tam thay cho txtusername,txtpassword
        //public string User_ten;
        public string Error;
        public int User_ID;
        public Stopwatch watch;
        private Dangnhap()
        {
            watch = new Stopwatch();
            watch.Start();
        }
        public static Dangnhap getUser()
        {
            if (_Dangnhap == null)
            {
                _Dangnhap = new Dangnhap();
            }

            return _Dangnhap;
        }
        public SqlConnection DatabaseConnectionOpen()
        {
            if (myDBconnection.State == System.Data.ConnectionState.Closed)
            {
                myDBconnection.Open();
            }

            return myDBconnection;
        }
        public void DatabaseConnectionClosed()
        {
            myDBconnection.Close();
        }
        public bool Dangnhap1(string _username, string _password)
        {
            username = _username;
            password = _password;
            string query = "Select * From tbChamCong_DangKy Where Username=@User and Password=@Password";

            try
            { 
                myDBconnection.Open();
                SqlCommand cmd = new SqlCommand(query, myDBconnection);
                //khai báo tham so cho txt
                cmd.Parameters.AddWithValue("@User", _username);
                cmd.Parameters.AddWithValue("@Password", _password);
                using (SqlDataReader reader = cmd.ExecuteReader())             
                {
                    if (reader.Read())
                    {
                         User_ID = int.Parse(reader["MaDN"].ToString());
                         return true;
                    }
                    else { return false; }
                }
            }
            catch (Exception f)
            {
                Error = "Veritabani Hatasi:\n\n" + f.ToString();
                return false;
            }
            finally
            {
                myDBconnection.Close();
            }
        }

    }
}
