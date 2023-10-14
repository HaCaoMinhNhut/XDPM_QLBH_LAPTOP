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
    public partial class FormNhanVien : Form
    {
        DataTable dt = new DataTable();
        DTO_NHANVIEN dto;
        BUS_NHANVIEN nv = new BUS_NHANVIEN();
        public FormNhanVien()
        {
            InitializeComponent();
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            LoadSql();
        }
        private void LoadSql()
        {
            GridNhanVien.DataSource = nv.ListOfNHANVIEN();

            dt = nv.ListOfcvTonv();
            if (dt.Rows.Count > 0)
                cbCV.DataSource = dt;
            cbCV.DisplayMember = "TENCV";
            cbCV.ValueMember = "MACV";
            cbCV.SelectedIndex = 0;
            gridview();
        }
        private void gridview()
        {
            GridNhanVien.Columns[0].HeaderText = "Mã nhân viên";
            GridNhanVien.Columns[1].HeaderText = "Họ tên";
            GridNhanVien.Columns[2].HeaderText = "Ngày sinh";
            GridNhanVien.Columns[3].HeaderText = "Địa chỉ";
            GridNhanVien.Columns[4].HeaderText = "Giới tính";
            GridNhanVien.Columns[5].HeaderText = "Chức vụ";
            GridNhanVien.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
        }    

        private void txtNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if (!(Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar) || e.KeyChar=='/'))
                    //!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '/'
                    e.Handled = true;
            }
        }
        private void txtNgay_TextChanged(object sender, EventArgs e)
        {
            if(txtNgay.Text.Length > 10) {
                MessageBox.Show("chỉ cho phép nhập ngày");
                txtNgay.Text = "";
            }
        }

        private void txtTennv_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if ((!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar)))
                    //!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '/'
                    e.Handled = true;     }
        }

        private void GridNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = false;
            txtManv.Enabled = false;
            string manv = GridNhanVien.Rows[e.RowIndex].Cells["MANV"].Value.ToString();
            string ten = GridNhanVien.Rows[e.RowIndex].Cells["TENNV"].Value.ToString();
            string date = GridNhanVien.Rows[e.RowIndex].Cells["NGAYSINH"].Value.ToString();
            string gt = GridNhanVien.Rows[e.RowIndex].Cells["GIOITINH"].Value.ToString();
          
            string dc = GridNhanVien.Rows[e.RowIndex].Cells["DIACHI"].Value.ToString();
            string macv = GridNhanVien.Rows[e.RowIndex].Cells["MACV"].Value.ToString();
            txtManv.Text = manv;
            txtTennv.Text = ten;
            txtDC.Text = dc;
            txtNgay.Text = date;

            string[] ngay = date.Split('/');// tách chuỗi
            txtNgay.Text = ngay[0];
            txtthang.Text = ngay[1];
            txtNam.Text = ngay[2];

            for(int i=0;i<cbCV.Items.Count;i++)
            {
                cbCV.SelectedIndex = i;
                if(cbCV.SelectedValue.ToString()==macv)
                {
                    break;
                }    
            }    

            if (gt.Equals("Nam"))
            {
                rdoNam.Checked = true;
            }    
            else
                rdoNu.Checked=true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string manv = txtManv.Text.ToUpper();
            if (nv.CheckNHANVIEN(manv))//Kiểm tra có dữ liệu không
            {
                dto = NhanVien();// Hàm ở dòng 148
                if (dto != null)// để viết lại các chỗ bị lỗi
                {
                    if (nv.InsertNHANVIEN(dto))
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo");
                        LoadSql();
                    }
                    else

                        MessageBox.Show("Thêm thất bại", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Mã đã tồn tại", "Thông báo");
            }    
           
        }
       
       private bool TryParseDT(string date)
        {  
            return DateTime.TryParse(date,out DateTime dt);
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            dto =new DTO_NHANVIEN("",txtSearch.Text,"", "", true, "");// Hàm ở dòng 148
            dt = nv.SearchNHANVIEN(dto);
            if(dt.Rows.Count>0)
            {
                GridNhanVien.DataSource = dt;
            }    
            else
            {
                MessageBox.Show("Không tìm thấy");
            }    
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            dto = NhanVien();// Hàm ở dòng 148
            if (dto != null)// để viết lại các chỗ bị lỗi
            {
                if (nv.DeleteNHANVIEN(dto))
                {
                    MessageBox.Show("Xóa thành công", "Thông báo");
                    LoadSql();
                }
                else

                    MessageBox.Show("Xóa thất bại", "Thông báo");
            }
        }
        private DTO_NHANVIEN NhanVien()
        {
            DTO_NHANVIEN nhanvien;
            string manv = txtManv.Text.ToUpper();
            string tennv = txtTennv.Text;
            string diachi = txtDC.Text;
            string date = txtthang.Text + "/" + txtNgay.Text + "/" + txtNam.Text;// lấy MM/DD/YYYY
            string macv = cbCV.SelectedValue.ToString();
            bool gioitinh = false;
           
                Guna2TextBox[] chuoi = { txtManv, txtTennv, txtDC, txtNgay, txtthang, txtNam };
                for (int i = 0; i < 6; i++)
                {
                    if (chuoi[i].Text == "")
                    {
                        chuoi[i].Focus();
                        MessageBox.Show("vui lòng điền đầy đủ thông tin", "Thông báo");
                        nhanvien = null;
                        break;

                    }
                }
                if (rdoNam.Checked)
                {
                    gioitinh = true;
                }
                if (rdoNu.Checked)
                {
                    gioitinh = false;
                }

            nhanvien = new DTO_NHANVIEN(manv, tennv, date, diachi, gioitinh, macv);
            if (!TryParseDT(date))
                {
                    MessageBox.Show("Vui lòng điền lại", "Thông báo");
                    txtNgay.Focus();
                    nhanvien = null;
                } 
            return nhanvien;

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            txtManv.Enabled = true;
            txtManv.Text = "";
            txtTennv.Text = "";
            txtNgay.Text = "";
            txtthang.Text = "";
            txtNam.Text = "";
            txtDC.Text = "";
            cbCV.SelectedIndex = 0;
            rdoNam.Checked = false;
            rdoNu.Checked = false;
            FormNhanVien_Load(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            dto = NhanVien();// Hàm ở dòng 148
            if (dto != null)// để viết lại các chỗ bị lỗi
            {
                if (nv.UpdateNHANVIEN(dto))
                {
                    MessageBox.Show("Sửa thành công", "Thông báo");
                    LoadSql();
                }
                else

                    MessageBox.Show("Sửa thất bại", "Thông báo");
            }
        }

        private void txtTennv_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtSearch.Text=="")
            {
                btnTK.Enabled = false;
            }    
            else
                btnTK.Enabled = true;
        }
    }
}
