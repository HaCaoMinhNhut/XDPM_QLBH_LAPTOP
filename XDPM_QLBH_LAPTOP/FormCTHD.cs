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
    public partial class FormCTHD : Form
    {
        
        DTO_CTHD dto;
        BUS_CTHD bus= new BUS_CTHD();// chi tiết hóa đơn + xem hóa đơn + in hóa đơn
        DataTable dt = new DataTable();
        string mahd = "";
     //public FormCTHD()
     //   {
     //       InitializeComponent();
     //   }
        public FormCTHD(string mahd,string tennv,string tenkh,string ngay)
        {
            InitializeComponent();
            lbKH.Text = "Khách hàng: " + tenkh;
            lbHoaDon.Text = "Hóa đơn: " + mahd;
            lbNgay.Text = "Ngày bán: " + ngay;
            lbNV.Text = "Nhân viên: " + tennv;
            this.mahd = mahd;
        }
        private void FormCTHD_Load(object sender, EventArgs e)
        {
            LoadSql();
            btnXoa.Enabled=false;
            btnSua.Enabled = false;

        }
        private void LoadSql()
        {
            GridSanPham.DataSource = bus.ListSP();
           dt = bus.ListCTHD(mahd);
            gridviewSP();
            if (dt.Rows.Count>0)
            {
                GridCTHD.DataSource = dt;
                gridviewCTHD();
            }    
        }
        private void gridviewCTHD()
        {
            int tongtien = 0;
            GridCTHD.Columns[0].HeaderText = "Mã hóa đơn";
            GridCTHD.Columns[1].HeaderText = "Mã sản phẩm";
            GridCTHD.Columns[2].HeaderText = "Số lượng";
            GridCTHD.Columns[3].HeaderText = "Thành tiền";
            GridCTHD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            for(int i=0; i<dt.Rows.Count; i++)
            {
                tongtien += int.Parse(dt.Rows[i]["THANHTIEN"].ToString());
            }
            lbtongtien.Text = tongtien.ToString();
        }
        private void gridviewSP()
        {
            //MAHD,CONVERT(varchar, NGAY, 103) AS NGAY,MAKH,MANV,TONGTIEN
            GridSanPham.Columns[0].HeaderText = "Mã";
            GridSanPham.Columns[1].HeaderText = "Tên";
            GridSanPham.Columns[2].HeaderText = "Tồn kho";
            GridSanPham.Columns[3].HeaderText = "Giá bán";
          GridSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void GridSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string tensp = GridSanPham.Rows[e.RowIndex].Cells["TENSP"].Value.ToString();
            string dongia = GridSanPham .Rows[e.RowIndex].Cells["DONGIA"].Value.ToString();
          string  masp= GridSanPham.Rows[e.RowIndex].Cells["MASP"].Value.ToString();
            txtGia.Text = dongia;
            txtTenSP.Text = tensp;
            txtMasp.Text=masp;
        }

        private void FormCTHD_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có chắc thoát", "Thông báo", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                dt = bus.ListCTHD(mahd);
            if (dt.Rows.Count <= 0)
            {
                dt = bus.DeleteHDfromCTHD(mahd);
                
            }
                else
                {
                    float tongtien = float.Parse(lbtongtien.Text);
                    bus.UpdateHDfromCTHD(mahd, tongtien);
                     
                }

                FormHoaDon frm = new FormHoaDon();
                //Guna2GradientButton btnHoaDon = new Guna2GradientButton();
                //btnHoaDon.Text = "Hóa đơn";
                //FormMain frm = new FormMain();
                //frm.LoadHoadon(sender, e, btnHoaDon);
                //frm.Show();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int sl = Int32.Parse(txtSL.Text);
            float dongia = float.Parse(txtGia.Text);
            float thanhtien = sl * dongia;
            string masp = txtMasp.Text;
            dto = new DTO_CTHD(mahd, masp, sl, thanhtien);
            if (bus.InsertCTHD(dto))
            {
                MessageBox.Show("Thêm thành công", "Thông báo");
                LoadSql();
            }
            else
                MessageBox.Show("Thêm thất bại", "Thông báo");


        }

        private void txtSL_TextChanged(object sender, EventArgs e)
        {

        }

      

        private void GridCTHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = false;
            string masp = GridCTHD.Rows[e.RowIndex].Cells["MASP"].Value.ToString();
            int soluong = Int32.Parse(GridCTHD.Rows[e.RowIndex].Cells["SOLUONG"].Value.ToString());
            float thanhtien = float.Parse(GridCTHD.Rows[e.RowIndex].Cells["THANHTIEN"].Value.ToString());
            int dongia = (int)thanhtien / soluong;
            dt = bus.SP(masp); 
            txtTenSP.Text = dt.Rows[0]["TENSP"].ToString();
            txtMasp.Text = masp;
            txtSL.Text = soluong.ToString();
            txtGia.Text = dongia.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int sl = Int32.Parse(txtSL.Text);
            float dongia = float.Parse(txtGia.Text);
            float thanhtien = sl * dongia;
            string masp = txtMasp.Text;
            dto = new DTO_CTHD(mahd, masp, sl, thanhtien);
            if (bus.UpdateCTHD(dto))
            {
                MessageBox.Show("Sửa thành công", "Thông báo");
                LoadSql();
            }
            else
                MessageBox.Show("Sửa thất bại", "Thông báo");

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            txtMasp.Text = "";
            txtTenSP.Text = "";
            txtSL.Text = "";
            txtGia.Text = "";
            FormCTHD_Load(sender, e);
        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar)&&!char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }    
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string masp = txtMasp.Text;
            dto = new DTO_CTHD("",masp,0,0);
            if(bus.DeleteCTHD(dto))
            {
                MessageBox.Show("Xóa thành công", "Thông báo");
                btnReset_Click(sender, e);
                LoadSql();
            }    
            else
            {
                MessageBox.Show("Xóa thất bại", "Thông báo");
            }    
        }
    }
}
