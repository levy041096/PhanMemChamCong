using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhanMemChamCong.resource;

namespace PhanMemChamCong
{
    public partial class FrmDangNhap : Form
    {
        public FrmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            FrmDangNhap log = new FrmDangNhap();
            this.Close();
            log.Show();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            Dangnhap user = Dangnhap.getUser();
            FrmDangNhap log = new FrmDangNhap();
            if (txtUser.Text == "" & txtPassword.Text == "")
            {
                lblGhiChu.Text = "Bạn chưa nhập user";
                lblGhiChu.Show();
                lbGhiChu2.Text = "Bạn chưa nhập mật khẩu";
                lbGhiChu2.Show();
               
            }
            else if (txtUser.Text == "" || txtPassword.Text != "")
            {
                lblGhiChu.Text = "Bạn chưa nhập user";
                lblGhiChu.Show();
                lbGhiChu2.Text = "";
                lbGhiChu2.Show();
            }
            else if (txtUser.Text != "" || txtPassword.Text == "")
            {
                lbGhiChu2.Text = "Bạn chưa nhập mật khẩu";
                lbGhiChu2.Show();
                lblGhiChu.Text = "";
                lblGhiChu.Show();
                
            }
            else
            {
                if (user.Dangnhap1(txtUser.Text, txtPassword.Text) == true)
                {
                    FrmDashboard bang = new FrmDashboard();
                    this.Hide();
                    bang.ShowDialog();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!");
                }
            }
        }
    }
}
