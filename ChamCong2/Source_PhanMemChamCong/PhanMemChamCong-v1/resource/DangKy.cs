using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace PhanMemChamCong.resource
{
    public class DangKy
    {
        private Dangnhap database;
        public bool error;
        private string m_hoten;
        private string m_MaNVFT;
        private string m_username;
        private string m_password;
        private string m_XNpass;
        public string EmpError;

        public string DK_hotenNV
        {
            get { return m_hoten; }
            set { m_hoten = value; }
        }
        public string DK_maNVFT
        {
            get { return m_MaNVFT; }
            set { m_MaNVFT = value; }
        }
        public string DK_user 
        {
            get { return m_username; }
            set { m_username = value; }
        }
        public string DK_pass
        {
            get { return m_password; }
            set { m_password = value; }
        }
        public string DK_xnpass
        {
            get { return m_XNpass; }
            set { m_XNpass = value; }
        }
         public DangKy() { }
         public bool saveDangky()
         {
             bool kayitDurumu;
             bool ktManv;
             bool ktten_user;
             database = Dangnhap.getUser();
             try
             {
                 SqlCommand cmd = new SqlCommand();
                 cmd.CommandText = "Select Username From Dangky Where Username = @User";
                 cmd.Connection = database.DatabaseConnectionOpen();
                 cmd.Parameters.AddWithValue("@User", m_username);
                 using (SqlDataReader reader = cmd.ExecuteReader())
                 {
                     if (reader.Read())
                     {
                         kayitDurumu = false;
                     }
                     else
                     {
                         reader.Close();
                         kayitDurumu = true; cmd.CommandText = "Insert Into tbChamCong_DangNhap ( MaNVFT, User, Password) values (@MaNVFT, @User, @Password)";
                        if ("@MaNVFT" != m_MaNVFT)
                        {
                            ktManv = false;
                        }
                         else
                         {
                             if ("@User" != "")
                             {
                                 ktten_user = false;
                             }
                             else
                             {
                                 cmd.Parameters.AddWithValue("@User", m_username);
                                 cmd.Parameters.AddWithValue("@Password", m_password);
                                 
                             }
                         }
                          cmd.ExecuteNonQuery();                        
                     }
                 }
             }
             catch (Exception f)
             {
                 kayitDurumu = false;
                 EmpError = f.ToString();
             }
             return kayitDurumu;
         }
    }
}
