using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace XDPM_QLBH_LAPTOP
{
    public partial class FormDangNhap : Form
    {
        BUS_TAIKHOAN bus = new BUS_TAIKHOAN();
        DataTable dt = new DataTable();
        BUS_NHANVIEN busNV = new BUS_NHANVIEN();
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormTaiKhoan frm = new FormTaiKhoan(lbQuenMK.Text);
            frm.Show();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string taikhoan = txtTK.Text;
            string matkhau=txtMK.Text;
            dt = bus.LoginTAIKHOAN(taikhoan, matkhau);//gọi bảng Tài khoản để lấy mã nhân viên
            if (dt.Rows.Count>0&&dt.Rows.Count<2)
            {
                Properties.Settings.Default.isSave=true;
                if (SwitchRemember.Checked)
                {
                    Properties.Settings.Default.TaiKhoan = txtTK.Text;
                    Properties.Settings.Default.MatKhau = txtMK.Text;
                }
                Properties.Settings.Default.Save();
                string manv = dt.Rows[0]["MANV"].ToString();
                dt = busNV.LoginNHANVIEN(manv);// Lấy bảng nhân viên 
                string tennv = dt.Rows[0]["TENNV"].ToString();
                string macv = dt.Rows[0]["MACV"].ToString();
                MessageBox.Show("Đăng nhập thành công","Thông báo");
                FormMain frm = new FormMain(tennv, macv);
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu bị sai", "Thông báo");
            }
        }

        private void btnDK_Click(object sender, EventArgs e)
        {
            FormTaiKhoan frm = new FormTaiKhoan(btnDK.Text);
            this.Hide();
            frm.ShowDialog();
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.isSave)
            {
                txtTK.Text = Properties.Settings.Default.TaiKhoan;
                txtMK.Text = Properties.Settings.Default.MatKhau;
                SwitchRemember.Checked = true;
            }
        }

        private void FormDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
          Application.Exit();
        }
    }
}
