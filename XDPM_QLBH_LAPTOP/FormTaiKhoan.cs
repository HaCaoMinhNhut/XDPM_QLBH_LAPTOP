using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace XDPM_QLBH_LAPTOP
{
    public partial class FormTaiKhoan : Form
    {
        BUS_NHANVIEN busNV = new BUS_NHANVIEN();
        DTO_NHANVIEN dtoNV;

        DTO_TAIKHOAN dtoTK;
        BUS_TAIKHOAN bustTK = new BUS_TAIKHOAN();

        BUS_CHUCVU busCV = new BUS_CHUCVU();
        DataTable dt= new DataTable();
        string manv = "";
        string macv = "";
        string phanloai = "";
        string phanquyen = "";//đăng ký,button đăng ký=> formDK,quên pass
        public FormTaiKhoan()
        {
            InitializeComponent();
        }
        public FormTaiKhoan(string phanloai)
        {
            InitializeComponent();
            this.phanloai= phanloai;
        }
        
        public FormTaiKhoan(string tennv,string macv)//Vô từ FormMain
        {
            InitializeComponent();
            txtTennv.Text = tennv;
            this.macv = macv;
        }
        private void FormTaiKhoan_Load(object sender, EventArgs e)
        {
            Loadsql();
            if (phanloai=="")
            {
                btnDK.Visible = false;
                btnThoat.Visible = false;
                btnXN.Visible = false;
                btnReset.Visible = false;
                PhanQuyen(macv);
                dtoNV = new DTO_NHANVIEN(txtTennv.Text,macv);
                dt = busNV.LoadNHANVIEN(dtoNV);
                txtDC.Text = dt.Rows[0]["DIACHI"].ToString();
                txtNgay.Text = dt.Rows[0]["NGAYSINH"].ToString();
                string gt = dt.Rows[0]["GIOITINH"].ToString();
                string manv = dt.Rows[0]["MANV"].ToString();
                if (gt == "Nam")
                    rdoNam.Checked = true;
                else 
                    rdoNu.Checked=true;
                for (int i = 0; i < cbCV.Items.Count; i++)
                {
                    cbCV.SelectedIndex = i;
                    if (cbCV.SelectedValue.ToString() == macv)
                    {
                        break;
                    }
                }
                dt = bustTK.CheckTAIKHOAN(manv);
                txtTK.Text = dt.Rows[0]["TAIKHOAN"].ToString();
                txtMKmoi.Text = dt.Rows[0]["MATKHAU"].ToString();
            }
            else
            {
                btnMK.Visible = false;
                if (phanloai == "Đăng ký")
                    this.Size = new Size(370, 450);
                XacMinh();
                if(phanloai == "Quên mật khẩu")
                {
                    this.Size = new Size(370, 450);
                    //this.Size = new Size(730, 450);
                    XacMinh();
                }    
            }    
        }
        private void PhanQuyen(string phanquyen)
        {
            if(phanquyen!="QTV")
            {
                label7.Visible = true;//label Đăng nhập
                                       // mật khẩu cũ là : lbmatkhaucu
                txtTK.Visible = true;
                txtmatkhau.Visible = true;//Nhập lại mật khẩu
                txtMKmoi.Visible = true;//Mật khẩu
                btnMK.Visible = true;//button đổi mật khẩu
                 GridTK.Visible = false;
            } 
            else
            {   
            }    
        }
        private void   QuenPassword() {
            label7.Visible = false;//label Đăng nhập
            // mật khẩu cũ là : lbmatkhaucu
            txtTK.Visible = true;
            txtmatkhau.Visible = false;
            txtMKmoi.Visible = false;
            panel.Visible = false;
            btnDK.Visible = false;
            btnMK.Visible = false;
            GridTK.Visible = false;
            btnSee.Visible = false;
        }

        private void XacMinh()
        {
            label7.Visible = false;//label Đăng nhập
            // mật khẩu cũ là : lbmatkhaucu
            txtTK.Visible = false;
            txtmatkhau.Visible = false;
            txtMKmoi.Visible = false;
            panel.Visible = false;
            btnDK.Visible = false;
            btnMK.Visible=false;
          GridTK.Visible = false;
            btnSee.Visible=false;

        }
        private void Loadsql()
        {
            dt = bustTK.ListofTAIKHOAN();
            if(dt.Rows.Count>0)
            {
                GridTK.DataSource = dt;
                GridTK.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }    

            dt = busCV.LoadCV();
            DataRow dr= dt.NewRow();
            dr["TENCV"] = "Chọn chức vụ";
            dr["MACV"] = "";
            dt.Rows.InsertAt(dr,0);
            cbCV.DataSource = dt;
            cbCV.DisplayMember = "TENCV";
            cbCV.ValueMember = "MACV";
            cbCV.SelectedIndex = 0;
        }

        private void btnXN_Click(object sender, EventArgs e)
        {
            string tennv=txtTennv.Text;
            string dc = txtDC.Text;
           bool gt=false;
            if (rdoNam.Checked)
            {
                gt = true;
            }
            if (rdoNu.Checked)
            {
                gt = false;
            }
            this.macv=cbCV.SelectedValue.ToString();
            string[] date = txtNgay.Text.Split('/');
            if (txtNgay.Text=="" || macv=="")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo");
                return;
            } 
            string ngay = date[1] + "/" + date[0]+"/" + date[2];
            dtoNV = new DTO_NHANVIEN("",tennv,ngay,dc,gt,macv);
            dt = busNV.CheckNHANVIENfromTK(dtoNV);
            if (dt.Rows.Count>0 && dt.Rows.Count < 2)
            {
                MessageBox.Show("Đã thành công","Thông báo");
                this.manv = dt.Rows[0]["MANV"].ToString();
                label7.Visible = true;
                txtTK.Visible = true;
                txtmatkhau.Visible = true;
                txtMKmoi.Visible = true;
                btnDK.Visible = true;
                btnMK.Visible = true;
                panel.Visible = true;
                btnSee.Visible = true;
                dt = bustTK.CheckTAIKHOAN(manv);
                this.Size = new Size(730, 450);
                if(dt.Rows.Count>0)
                {
                    txtTK.Text = dt.Rows[0]["TAIKHOAN"].ToString();
                    txtMKmoi.Text = dt.Rows[0]["MATKHAU"].ToString();
                    btnDK.Visible = false;
                }  
                else
                {
                    MessageBox.Show("Bạn chưa có tài khoản", "Thông báo");
                    btnMK.Visible = false;
                }    
            }    
            else
                MessageBox.Show("Vui lòng kiểm tra lại thông tin điền vào", "Thông báo");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtTennv.Text = "";
           txtDC.Text="";
            txtNgay.Text = "";
            cbCV.SelectedIndex = -1;
            rdoNam.Checked = false;
            rdoNu.Checked = false;
            FormTaiKhoan_Load(sender, e);
        
        }

        private void txtNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar)&& !char.IsControl(e.KeyChar) && e.KeyChar!='/') {
                e.Handled = true; 
            }
        }

        private void txtTennv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSee_Click(object sender, EventArgs e)
        {
            if (btnSee.FillColor == Color.Red)
            {
                btnSee.FillColor = Color.Cyan;
                txtMKmoi.PasswordChar = (char)0;
            }
            else
            {
                btnSee.FillColor = Color.Red;
                txtMKmoi.PasswordChar = '*';
            }   
        }

        private void GridTK_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           
            if (e.ColumnIndex == 2 && e.Value != null)// password
            {
                e.Value = new String('*', 12);
            }
        }

        private void GridTK_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string tk = GridTK.Rows[e.RowIndex].Cells["TAIKHOAN"].Value.ToString();
            txtTK.Text = tk;
            string pass = GridTK.Rows[e.RowIndex].Cells["MATKHAU"].Value.ToString();
            txtMKmoi.Text = pass;
            string manv = GridTK.Rows[e.RowIndex].Cells["MANV"].Value.ToString();
            string macv = GridTK.Rows[e.RowIndex].Cells["MACV"].Value.ToString();
            for (int i = 0; i < cbCV.Items.Count; i++)
            {
                cbCV.SelectedIndex = i;
                if (cbCV.SelectedValue.ToString() == macv)
                {
                    break;
                }
            }
            dt = busNV.LoginNHANVIEN(manv);
            if (dt.Rows.Count>0)
            {
                txtTennv.Text = dt.Rows[0]["TENNV"].ToString();

                dtoNV = new DTO_NHANVIEN(txtTennv.Text, macv);
                dt = busNV.LoadNHANVIEN(dtoNV);
                txtDC.Text = dt.Rows[0]["DIACHI"].ToString();
                txtNgay.Text = dt.Rows[0]["NGAYSINH"].ToString();
                string gt = dt.Rows[0]["GIOITINH"].ToString();
                if (gt == "Nam")
                    rdoNam.Checked = true;
                else
                    rdoNu.Checked = true;


            }
        }

        private void btnDK_Click(object sender, EventArgs e)
        {
            string taikhoan = txtTK.Text;
            string matkhau = txtmatkhau.Text;
            dtoTK = new DTO_TAIKHOAN(manv, macv, taikhoan, matkhau);
            if(bustTK.InsertTAIKHOAN(dtoTK))
            {
                Loadsql();
                FormDangNhap frm=new FormDangNhap();
                frm.Show();
                this.Close();
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            FormDangNhap frm = new FormDangNhap();
            frm.Show();
            this.Close();
        }

        private void btnMK_Click(object sender, EventArgs e)
        {
          
            string taikhoan = txtTK.Text;
            string matkhau = txtmatkhau.Text;
            if (taikhoan==null || matkhau==null)
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu");
            }
            else
            {
                dtoTK = new DTO_TAIKHOAN(manv, macv, taikhoan, matkhau);
                if (bustTK.UpdateTAIKHOAN(dtoTK))
                {
                    MessageBox.Show("Đổi mật khẩu thành công", "Thông báo");
                    Loadsql();
                }
            }    
            
        }

       
    }
}
