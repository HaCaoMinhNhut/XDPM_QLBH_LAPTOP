using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using Guna.UI2.WinForms;
using TheArtOfDevHtmlRenderer.Adapters;

namespace XDPM_QLBH_LAPTOP
{
    public partial class FormSanPham : Form
    {
        DTO_SANPHAM dto;
        BUS_SANPHAM bus = new BUS_SANPHAM(); 
        DataTable dt= new DataTable();
        private string fileAddress;
        private byte[] img=null;
        public FormSanPham()
        {
            InitializeComponent();
        }

        private void FormSanPham_Load(object sender, EventArgs e)
        {
            txtTonkho.Enabled= false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtGiaban.Text = "0";
            txtGianhap.Text = "0";
            txtsl.Text="0";
            txtTonkho.Text="0";
            LoadSql();
        }
        private void LoadSql()
        {
            GridSanPham.DataSource = bus.ListOfSANPHAM();

            gridview();
        }

        private void gridview()
        {
            GridSanPham.Columns[0].HeaderText = "Mã sản phẩm";
            GridSanPham.Columns[1].HeaderText = "Tên sản phẩm";
            GridSanPham.Columns[2].HeaderText = "Số lượng";
            GridSanPham.Columns[3].HeaderText = "Giá nhập";
            GridSanPham.Columns[4].HeaderText = "Giá bán";
            GridSanPham.Columns[5].HeaderText = "Hình ảnh";
            GridSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";
            open.Title = "Chọn ảnh";
            if (open.ShowDialog() == DialogResult.OK)
            {
                fileAddress = open.FileName;
                ImageView.Image = CloneImage(fileAddress);
                ImageView.ImageLocation = fileAddress;
                ImageView.SizeMode = PictureBoxSizeMode.Zoom;
                
            }
        }
       

        private Image CloneImage(string path)
        {
            Image result;
            using (Bitmap original = new Bitmap(path))
            {
                result = (Bitmap)original.Clone();

            };
            return result;
        }

        private byte[] ImageToByteArray(PictureBox pictureBox)
        {
            MemoryStream memoryStream = new MemoryStream();
            pictureBox.Image.Save(memoryStream, pictureBox.Image.RawFormat);
            return memoryStream.ToArray();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string masp = txtMasp.Text.ToUpper();
            if (bus.CheckSANPHAM(masp))
            {
                dto = SanPham();
                if (dto != null)// để viết lại các chỗ bị lỗi
                {
                    if (bus.InsertSANPHAM(dto))
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

        private void txtGianhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar) || e.KeyChar == '.'))
                //!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '/'
                e.Handled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            dto = SanPham();
            if (dto != null)// để viết lại các chỗ bị lỗi
            {
                if (bus.DeleteSANPHAM(dto))
                {
                    MessageBox.Show("Xóa thành công", "Thông báo");
                    LoadSql();
                }
                else

                    MessageBox.Show("Xóa thất bại", "Thông báo");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            dto = SanPham();
            if (dto != null)// để viết lại các chỗ bị lỗi
            {
                if (bus.UpdateSANPHAM(dto))
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
            txtMasp.Enabled = true;
            txtMasp.Text = "";
            txtTensp.Text = "";
            FormSanPham_Load(sender, e);
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            dto = new DTO_SANPHAM("", txtSearch.Text, 0,0,0,null);// Hàm ở dòng 148
            dt = bus.SearchSANPHAM(dto);
            if (dt.Rows.Count > 0)
            {
                GridSanPham.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Không tìm thấy");
            }
        }
        private DTO_SANPHAM SanPham()
        {
            DTO_SANPHAM sanpham;
            string masp = txtMasp.Text.ToUpper();
            string tensp = txtTensp.Text;
            int sl = Int32.Parse(txtsl.Text);
            float gianhap=float.Parse(txtGianhap.Text);
            float dongia = float.Parse(txtGiaban.Text);
           

                if (fileAddress == null)
                {
                    MessageBox.Show("Vui lòng chọn hình ảnh", "Thông báo");
                    btnImage.Focus();
                }
                else
                    img = ImageToByteArray(ImageView);

                Guna2TextBox[] chuoi = { txtMasp, txtTensp, txtsl, txtGianhap, txtGiaban };

                sanpham = new DTO_SANPHAM(masp, tensp, sl, gianhap, dongia, img);
                for (int i = 0; i < 5; i++)
                {
                    if (chuoi[i].Text == "" || chuoi[i].Text == "0")
                    {
                        chuoi[i].Focus();
                        MessageBox.Show("vui lòng điền đầy đủ thông tin", "Thông báo");
                        sanpham = null;
                        break;

                    }
                }
         
           
            return sanpham;

        }

        private void GridSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ma = GridSanPham.Rows[e.RowIndex].Cells["MASP"].Value.ToString();
            string ten = GridSanPham.Rows[e.RowIndex].Cells["TENSP"].Value.ToString();
            string gianhap = GridSanPham.Rows[e.RowIndex].Cells["GIANHAP"].Value.ToString();
            string dongia = GridSanPham.Rows[e.RowIndex].Cells["DONGIA"].Value.ToString();
            string sl = GridSanPham.Rows[e.RowIndex].Cells["SL"].Value.ToString();
             img = (byte[])GridSanPham.Rows[e.RowIndex].Cells["HINHANH"].Value;
            MemoryStream memoryStream = new MemoryStream(img);
            ImageView.Image = Image.FromStream(memoryStream);
            ImageView.SizeMode = PictureBoxSizeMode.Zoom;
            txtMasp.Text = ma;
            txtTensp.Text = ten;
            txtGiaban.Text = dongia;
            txtGianhap.Text = gianhap;
            txtTonkho.Text = sl;

            txtMasp.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            

        }
    }
}
