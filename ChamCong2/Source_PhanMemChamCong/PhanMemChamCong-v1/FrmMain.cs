using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemChamCong
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            FrmMain log = new FrmMain();
            this.Close();
            log.Show();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            FrmDangKy dangky = new FrmDangKy();
            this.Hide();
            dangky.ShowDialog();
            this.Close();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            FrmDangNhap dangnhap = new FrmDangNhap();
            this.Hide();
            dangnhap.ShowDialog();
            this.Close();
        }
    }
}
