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
using Microsoft.Reporting.WinForms;

namespace XDPM_QLBH_LAPTOP
{
    public partial class ResportHoaDonForm : Form
    {
        BUS_RESPORT bus = new BUS_RESPORT();
        string mahd = "";
        public ResportHoaDonForm(string mahd)
        {
            this.mahd= mahd;
            InitializeComponent();
        }
        public ResportHoaDonForm()
        {
            InitializeComponent();
        }

        private void ResportHoaDonForm_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = bus.reportHOADON(mahd);
            reportViewer1.LocalReport.DataSources.Clear();
            //HD05101359
            ReportDataSource source = new ReportDataSource();
            source.Name = "DS_HD";
            source.Value = dt;
            bindingSource1.DataSource = dt;
            reportViewer1.LocalReport.DataSources.Add(source);
            reportViewer1.RefreshReport();
          //  reportViewer1.LocalReport.ReportPath = "~/Resport/ReportHoaDon.rdlc";
        }

     
    }
}
