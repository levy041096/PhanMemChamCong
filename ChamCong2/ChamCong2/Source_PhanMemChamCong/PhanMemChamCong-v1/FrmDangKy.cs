using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using PhanMemChamCong.resource;

namespace PhanMemChamCong
{
    public partial class FrmDangKy : Form
    {
        public FrmDangKy()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmDangKy_Load(object sender, EventArgs e)
        {

        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            bool kayit;
            bool ktuser;
            bool ktmanv;
            DangKy DK = new DangKy();
            DK.DK_hotenNV = txtHoTen.Text;
            DK.DK_maNVFT = txtMaNV.Text;
            DK.DK_user = txtUser.Text;
            DK.DK_pass = txtPassword.Text;
            DK.DK_xnpass = txtXNpass.Text;

            kayit = DK.saveDangky();
            ktmanv = DK.saveDangky();
            ktuser = DK.saveDangky();

            //if ( trim (txtMaNV.Text) = "")
            //    MessageBox.Show("Chưa nhập mã nhân viên!");


            if (kayit == false)
            {
                MessageBox.Show("Username đã được sử dụng");
            }
            else if (ktuser == false)
            {
                MessageBox.Show("Nhân Viên đã có tài khoản");
            }
            else if (ktmanv == false)
            {
                MessageBox.Show("Nhân Viên không tồn tại");
            }
            else
            {
                if (txtPassword.Text == txtXNpass.Text)
                    MessageBox.Show("Đăng ký thành công");
                else
                    MessageBox.Show("Password chưa đúng");
            }
            txtHoTen.Text = "";
            txtMaNV.Text = "";
            txtUser.Text = "";
            txtPassword.Text = "";
            txtXNpass.Text = "";

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            FrmDangKy log = new FrmDangKy();
            this.Close();
            log.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
