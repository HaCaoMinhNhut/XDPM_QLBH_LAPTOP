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

namespace XDPM_QLBH_LAPTOP
{
    public partial class FormHoaDon : Form
    {
        DTO_HOADON dto;
        BUS_HOADON bus=new BUS_HOADON();
        DataTable dt= new DataTable();
        string makh;
        private DateTime dateTime;

        public FormHoaDon()
        {
            InitializeComponent();
        }
        public FormHoaDon(string makh)
        {
            this.makh = makh;
            InitializeComponent();
        }

        private void FormHoaDon_Load(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            dateTime = DateTime.Now;
            txtMahd.Text= "HD" + dateTime.ToString("ddMM") + dateTime.ToString("HHmm");
            btnSua.Enabled = false;
            txtTongTien.Text = "0";
          txtTongTien.Enabled = false;
            LoadSql();
            if(makh !=null)// dữ liệu từ bên khách hàng
            {
                for (int i = 0; i < cbKH.Items.Count; i++)
                {
                    cbKH.SelectedIndex = i;
                    if (makh == cbKH.SelectedValue.ToString())
                    {
                        break;
                    }
                }
            }    
        }
        private void LoadSql()
        {
            GridHoaDon.DataSource = bus.ListOfHOADON();
            dt = bus.ListOfNVtoHOADON();
            if(dt.Rows.Count > 0 )
            {
                DataRow row;
                row= dt.NewRow();
                row["MANV"] = "";
                row["TENNV"] = "--Lựa chọn--";
                dt.Rows.InsertAt(row,0);
                cbNV.DataSource = dt;
                cbNV.ValueMember = "MANV";
                cbNV.DisplayMember = "TENNV";
            }

            dt = bus.ListOfKHtoHOADON();
            if (dt.Rows.Count > 0)
            {
                DataRow row;
                row = dt.NewRow();
                row["MAKH"] = "";
                row["TENKH"] = "--Lựa chọn--";
                dt.Rows.InsertAt(row, 0);
                cbKH.DataSource = dt;
                cbKH.ValueMember = "MAKH";
                cbKH.DisplayMember = "TENKH";
            }
            gridview();
        }
        private void gridview()
        {
            //MAHD,CONVERT(varchar, NGAY, 103) AS NGAY,MAKH,MANV,TONGTIEN
            GridHoaDon.Columns[0].HeaderText = "Mã hóa đơn";
            GridHoaDon.Columns[1].HeaderText = "Ngày";
            GridHoaDon.Columns[2].HeaderText = "Mã khách hàng";
            GridHoaDon.Columns[3].HeaderText = "Mã nhân viên";
            GridHoaDon.Columns[4].HeaderText = "Tổng tiền";
            GridHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {

            string ngay = DateTime.Now.ToString();
            string makh = cbKH.SelectedValue.ToString();
            string manv = cbNV.SelectedValue.ToString();
            if (makh != "" && manv != "")
            {
                string mahd = txtMahd.Text;
                float tongtien = 0;
                dto = new DTO_HOADON(mahd, ngay, manv, makh, tongtien);
                if (bus.InsertHOADON(dto))
                {
                    GridHoaDon.DataSource = bus.ListOfHOADON();
                    string tenkh = cbKH.Text;
                    string tennv = cbNV.Text;
                    this.Close();
                    FormCTHD frm = new FormCTHD(mahd, tennv, tenkh, ngay);
                    frm.ShowDialog();
                }
            }
            else
                MessageBox.Show("Vui lòng điền đầy đủ", "Thông báo");
        }
     

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có chắc không ???","Thông báo",MessageBoxButtons.YesNo);
            if(dialog==DialogResult.Yes)
            {
                string mahd = txtMahd.Text; dto = new DTO_HOADON(mahd, "", "", "", 0); 
                if (bus.DeleteHOADON(dto))//xóa hóa đơn + chi tiêt hóa đơn
                {
                    LoadSql();
                }
            }    
            
        }

        private void GridHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = false;
            string mahd = GridHoaDon.Rows[e.RowIndex].Cells["MAHD"].Value.ToString();
            txtMahd.Text = mahd;
            string tongtien = GridHoaDon.Rows[e.RowIndex].Cells["TONGTIEN"].Value.ToString();
            txtTongTien.Text = tongtien;
            btnSua.Enabled = true;
            string makh = GridHoaDon.Rows[e.RowIndex].Cells["MAKH"].Value.ToString();
            string manv = GridHoaDon.Rows[e.RowIndex].Cells["MANV"].Value.ToString();
            loadcb(manv,makh);
        }
        private void loadcb(string nv,string kh)
        {
            for(int i = 0;i<cbKH.Items.Count;i++)
            {
                cbKH.SelectedIndex = i;
                if(kh==cbKH.SelectedValue.ToString())
                {
                    break;
                }    
            }
            for (int i = 0; i < cbNV.Items.Count; i++)
            {
                cbNV.SelectedIndex = i;
                if (nv == cbNV.SelectedValue.ToString())
                {
                    break;
                }
            }
        }    

        private void btnSua_Click(object sender, EventArgs e)
        {

            string ngay = DateTime.Now.ToString();
            string makh = cbKH.SelectedValue.ToString();
            string manv = cbNV.SelectedValue.ToString();
            string mahd = txtMahd.Text;
            float tongtien = float.Parse(txtTongTien.Text);
            if (makh != "" && manv != "") 
            { 
                dto = new DTO_HOADON(mahd, ngay, manv, makh, tongtien);
                if (bus.UpdateHOADON(dto)) 
                 {
                string tenkh = cbKH.Text;
                string tennv = cbNV.Text;
                this.Close();
                FormCTHD frm = new FormCTHD(mahd, tennv, tenkh, ngay);
                frm.ShowDialog();
             
                 }
            }
            else
           MessageBox.Show("Vui lòng điền đầy đủ", "Thông báo");
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            string tgbegin= txtSearchBegin.Text;
         tgbegin=loaddate(txtSearchBegin.Text,0);
          string tgend=txtSearchEnd.Text;
        tgend = loaddate(tgend,1);
            if (tgbegin=="" && tgend=="")
            {
                return;
            }
            //dt = bus.SearchHOADON(tgbegin,tgend);
            if (dt.Rows.Count > 0)
            {
                GridHoaDon.DataSource=dt;
            }
            else
                MessageBox.Show("Không tìm thấy", "Thông báo");
        }
        private string  loaddate(string tg,int vt)
        // tại vì thời gian kết thúc giảm 1 phút, vd: chọn 10/09/2023 => 09/09/2023 23:59:59
        {// dd/MM/YYYY
            int ngay=0;
            string[] date = tg.Split('/');
            if (date.Length!=3)
            {
                MessageBox.Show("Vui lòng điền lại", "Thông báo");
                tg = null;
            }
            else
            {     
                ngay = Int32.Parse(date[0]) + vt;
               
            tg = date[1] + "/" + ngay+ "/" + date[2];
            }
            return tg;
        }

        private void txtSearchBegin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar!='/')
            {
                e.Handled = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            FormHoaDon_Load(sender, e);
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            ResportHoaDonForm frm = new ResportHoaDonForm(txtMahd.Text);
            frm.ShowDialog();
        }
    }
}
