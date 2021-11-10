using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTTQ_Buoi9
{
    public partial class BaoCao : Form
    {
        private DateTime deliveryDate;
        private string invoiceno;
        private List<product> listProduct = new List<product>();
        private SqlConnection cnn;

        public BaoCao(string id, DateTime dD)
        {
            InitializeComponent();
            if (id != "")
            {
                deliveryDate = dD;
                invoiceno = id;
                phieuGiaoHang();
            }
            else
            {
                baoGiaSanPham();
            }
        }

        private void BaoCao_Load(object sender, EventArgs e)
        {

        }

        public void phieuGiaoHang()
        {
            DataSet ds = new DataSet();
            string connetionString = @"Data Source=DESKTOP-NIULDEP\SQLEXPRESS;Initial Catalog=lttq_buoi9;User ID=sa;Password=password";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("select * from [dbo].[order] where invoiceno = N'"+ invoiceno + "'", cnn);
            adp.Fill(ds);
            cnn.Close();
            this.reportViewer1.LocalReport.ReportPath = "../../ChiTietDonHang.rdlc";
            ReportParameter rptId = new ReportParameter("InvoiceNo", invoiceno);
            ReportParameter rptDeliverDate = new ReportParameter("DeliveryDateStr", deliveryDate.ToString());
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rptId, rptDeliverDate });
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSetOrder";
            rds.Value = ds.Tables[0];
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }

        public void baoGiaSanPham()
        {
            DataSet ds = new DataSet();
            string connetionString = @"Data Source=DESKTOP-NIULDEP\SQLEXPRESS;Initial Catalog=lttq_buoi9;User ID=sa;Password=password";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("select * from product where deleted = 0", cnn);
            adp.Fill(ds);
            cnn.Close();
            reportViewer1.LocalReport.ReportPath = "../../BangBaoGia.rdlc";
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSetProduct";
            rds.Value = ds.Tables[0];
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }
    }
}
