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
using DTO;
using Guna.UI2.WinForms;

namespace XDPM_QLBH_LAPTOP
{
    public partial class FormMain : Form
    {
        BUS_CHUCVU bus = new BUS_CHUCVU();
        string macv;
        string makh;
        DataTable dt = new DataTable();
        
      
        public FormMain(string tennv,string macv)
        {
            InitializeComponent();
            lbHoTen.Text = tennv;
            this.macv= macv;
        }
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

            lbDatetime.Text = DateTime.Now.ToString();
            phanquyen(macv);
        }
        private void phanquyen(string macv)
        {
            dt=bus.CheckCV(macv);
            lbCV.Text = "Chức vụ: " + dt.Rows[0]["TENCV"].ToString();
            // btnNhanvien, btnHoaDon, btnSanpham, btnKhachhang,    btnTaiKhoan
            if (macv =="NS")
            {
                btnNhanvien.Enabled = true;
                btnHoaDon.Enabled = false;
                btnSanpham.Enabled = true;
                btnKhachhang.Enabled = true;
            }
            if (macv == "NV")
            {
                btnNhanvien.Enabled = true;
                btnHoaDon.Enabled = false;
                btnSanpham.Enabled = true;
                btnKhachhang.Enabled = false; }
            if (macv == "TN")
            {
                btnNhanvien.Enabled = false;
                btnHoaDon.Enabled = true;
                btnSanpham.Enabled = false;
                btnKhachhang.Enabled = true;
            }

        }

        private void btnNhanvien_Click(object sender, EventArgs e)
        {

            color(btnNhanvien);
            FormNhanVien frm = new FormNhanVien();
            panelBody.Controls.Clear();
            frm.TopLevel = false;
            panelBody.Controls.Add(frm);
            panelBody.Dock = DockStyle.Fill;
            frm.Show();
        }
        private void btnKhachhang_Click(object sender, EventArgs e)
        {
            color(btnKhachhang);
            FormKhachHang frm = new FormKhachHang();
            panelBody.Controls.Clear();
            frm.TopLevel = false;
            panelBody.Controls.Add(frm);
            panelBody.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            color(btnTaiKhoan);
            FormTaiKhoan frm = new FormTaiKhoan(lbHoTen.Text,macv);
            panelBody.Controls.Clear();
            frm.TopLevel = false;
            panelBody.Controls.Add(frm);
            panelBody.Dock = DockStyle.Fill;
            frm.Show();
        }


        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            color(btnHoaDon);
            DTO_KHACHHANG dto= new DTO_KHACHHANG();
            makh = dto.MAKH;
            if (makh==null)
            {
                FormHoaDon frm = new FormHoaDon();
                panelBody.Controls.Clear();
                frm.TopLevel = false;
                panelBody.Controls.Add(frm);
                panelBody.Dock = DockStyle.Fill;
                frm.Show();
            }
            else
            {
                FormHoaDon frm = new FormHoaDon(makh);
                panelBody.Controls.Clear();
                frm.TopLevel = false;
                panelBody.Controls.Add(frm);
                panelBody.Dock = DockStyle.Fill;
                frm.Show();
            }    

        }

        private void btnSanpham_Click(object sender, EventArgs e)
        {
            color(btnSanpham);
            FormSanPham frm = new FormSanPham();
            panelBody.Controls.Clear();
            frm.TopLevel = false;
            panelBody.Controls.Add(frm);
            panelBody.Dock = DockStyle.Fill;
            frm.Show();
        }
      
        private void color(Guna2GradientButton btn)//Button btn
        {

            object[] chuoi = { btnNhanvien, btnHoaDon, btnSanpham, btnKhachhang, btnTaiKhoan };
            Guna2GradientButton button;
            for (int i = 0; i < chuoi.Length; i++)
            {
                button = (Guna2GradientButton)chuoi[i];
                if (button.Text == btn.Text)
                {
                    btn.FillColor = Color.Cyan;
                    btn.FillColor2 = Color.OrangeRed;

                }
                else
                {
                    button.FillColor = Color.Transparent;
                    button.FillColor2 = Color.Transparent;
                }
            }
        }

       

        private void btnDangxuat_Click(object sender, EventArgs e)
        {
            FormDangNhap frm = new FormDangNhap();
            frm.Show();
            this.Hide();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
          
              //  Application.Exit();
           
        }

      

    
    }
}
