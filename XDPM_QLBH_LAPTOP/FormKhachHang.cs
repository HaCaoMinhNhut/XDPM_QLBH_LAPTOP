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
    public partial class FormKhachHang : Form
    {
        DataTable dt = new DataTable();
        DTO_KHACHHANG dto;
        BUS_KHACHHANG bus = new BUS_KHACHHANG();
       
        public FormKhachHang()
        {
            InitializeComponent();
        }
        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            LoadSql();
        }
        private void LoadSql()
        {
            GridKhachHang.DataSource = bus.ListOfKHACHHANG();
            gridview();
        }
        private void gridview()
        {
            GridKhachHang.Columns[0].HeaderText = "ID";
            GridKhachHang.Columns[1].HeaderText = "Họ tên";
            GridKhachHang.Columns[2].HeaderText = "Địa chỉ";
            GridKhachHang.Columns[3].HeaderText = "SĐT";
            GridKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if (!(Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar)))
                    //!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '/'
                    e.Handled = true;
            }
        }
        private DTO_KHACHHANG KhachHang()
        {
            DTO_KHACHHANG khachhang;
            string makh = txtMakh.Text.ToUpper();
            string tenkh = txtTenKh.Text;
            string diachi = txtDC.Text; 
            string sdt =txtSDT.Text;
          
                Guna2TextBox[] chuoi = { txtMakh, txtTenKh, txtDC, txtSDT };
                khachhang = new DTO_KHACHHANG(makh, tenkh, diachi, sdt);
                for (int i = 0; i < 4; i++)
                {
                    if (chuoi[i].Text == "")
                    {
                        chuoi[i].Focus();
                        MessageBox.Show("vui lòng điền đầy đủ thông tin", "Thông báo");
                        khachhang = null;
                        break;
                    }
                }
                if(sdt.Length>11)
            {
                khachhang = null;
            }    
           
           
            return khachhang;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string makh = txtMakh.Text.ToUpper();
            if (bus.CheckKHACHHANG(makh))
            {
                dto = KhachHang();// Hàm ở dòng 148
                if (dto != null)// để viết lại các chỗ bị lỗi
                {
                    if (bus.InsertKHACHHANG(dto))
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

        private void GridKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = false;
            string ma = GridKhachHang.Rows[e.RowIndex].Cells["MAKH"].Value.ToString();
            string ten = GridKhachHang.Rows[e.RowIndex].Cells["TENKH"].Value.ToString();
            string diachi= GridKhachHang.Rows[e.RowIndex].Cells["DIACHI"].Value.ToString();
            string sdt= GridKhachHang.Rows[e.RowIndex].Cells["SDT"].Value.ToString();

            txtMakh.Text = ma;
            txtTenKh.Text = ten;
            txtDC.Text= diachi;
            txtSDT.Text= sdt;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            dto = KhachHang();// Hàm ở dòng 148
            if (dto != null)// để viết lại các chỗ bị lỗi
            {
                if (bus.DeleteKHACHHANG(dto))
                {
                    MessageBox.Show("Xóa  thành công", "Thông báo");
                    LoadSql();
                }
                else

                    MessageBox.Show("Xóa thất bại", "Thông báo");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            dto = KhachHang();// Hàm ở dòng 148
            if (dto != null)// để viết lại các chỗ bị lỗi
            {
                if (bus.UpdateKHACHHANG(dto))
                {
                    MessageBox.Show("Sửa thành công", "Thông báo");
                    LoadSql();
                }
                else

                    MessageBox.Show("Sửa thất bại", "Thông báo");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            txtMakh.Enabled = true;
            txtMakh.Text = "";
            txtTenKh.Text = "";
            txtDC.Text = "";
            txtSDT.Text = "";
            FormKhachHang_Load(sender, e);
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            dto = new DTO_KHACHHANG("", txtSearch.Text, "", "");// Hàm ở dòng 148
            dt = bus.SearchKHACHHANG(dto);
            if (dt.Rows.Count > 0)
            {
                GridKhachHang.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Không tìm thấy");
            }
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
        
        }
    }
}
