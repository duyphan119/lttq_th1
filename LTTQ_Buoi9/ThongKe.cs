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
    public partial class ThongKe : Form
    {
        private SqlConnection cnn;
        private int s, year;
        public ThongKe(int m, int y)
        {
            InitializeComponent();
            s = m;
            year = y;
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {
            //Theo Tháng
            if (s == 1)
            {
                DoanhThuTheoThang();
            }
            else if(s == 0)//Theo Quý
            {
                DoanhThuTheoQuy();
            }
            else if(s == -1)//Theo Năm
            {
                DoanhThuTheoNam();
            }
            else if (s == -2)//Từng sản phẩm theo tháng
            {
                SanPhamTheoThang();
            }
            else if (s == -3)//Tửng sản phẩm theo quý
            {
                SanPhamTheoQuy();
            }
            else if (s == -4)//Từng sản phẩm theo năm
            {
                SanPhamTheoNam();
            }
        }
        public void DoanhThuTheoThang()
        {
            string connetionString = @"Data Source=DESKTOP-NIULDEP\SQLEXPRESS;Initial Catalog=lttq_buoi9;User ID=sa;Password=password";
            cnn = new SqlConnection(connetionString);
            DataSet ds = new DataSet();
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("execute sp_ThongKeTheoThangTrongNam "+year+"", cnn);
            adp.Fill(ds);
            cnn.Close();
            reportViewer1.LocalReport.ReportPath = "../../DoanhThuThang.rdlc";
            ReportParameter rptYear = new ReportParameter("year", year.ToString());
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rptYear });
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "ThangTrongNam";
            rds.Value = ds.Tables[0];
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }
        public void DoanhThuTheoQuy()
        {
            string connetionString = @"Data Source=DESKTOP-NIULDEP\SQLEXPRESS;Initial Catalog=lttq_buoi9;User ID=sa;Password=password";
            cnn = new SqlConnection(connetionString);
            DataSet ds = new DataSet();
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("execute sp_ThongKeTheoQuy " + year + "", cnn);
            adp.Fill(ds);
            cnn.Close();
            reportViewer1.LocalReport.ReportPath = "../../DoanhThuQuy.rdlc";
            ReportParameter rptYear = new ReportParameter("year", year.ToString());
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] {  rptYear });
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "QuyTrongNam";
            rds.Value = ds.Tables[0];
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }
        public void DoanhThuTheoNam()
        {
            string connetionString = @"Data Source=DESKTOP-NIULDEP\SQLEXPRESS;Initial Catalog=lttq_buoi9;User ID=sa;Password=password";
            cnn = new SqlConnection(connetionString);
            DataSet ds = new DataSet();
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("execute sp_ThongKeTheoNam", cnn);
            adp.Fill(ds);
            cnn.Close();
            reportViewer1.LocalReport.ReportPath = "../../DoanhThuNam.rdlc";
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "CacNam";
            rds.Value = ds.Tables[0];
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }

        public void SanPhamTheoThang()
        {
            string connetionString = @"Data Source=DESKTOP-NIULDEP\SQLEXPRESS;Initial Catalog=lttq_buoi9;User ID=sa;Password=password";
            cnn = new SqlConnection(connetionString);
            DataSet ds = new DataSet();
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("execute sp_DoanhThuTungLoaiSanPhamTheoThang "+year, cnn);
            adp.Fill(ds);
            cnn.Close();
            reportViewer1.LocalReport.ReportPath = "../../SanPhamTheoThang.rdlc";
            ReportParameter rptYear = new ReportParameter("year", year.ToString());
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rptYear });
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "SP_TheoThang";
            rds.Value = ds.Tables[0];
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }

        public void SanPhamTheoQuy()
        {
            string connetionString = @"Data Source=DESKTOP-NIULDEP\SQLEXPRESS;Initial Catalog=lttq_buoi9;User ID=sa;Password=password";
            cnn = new SqlConnection(connetionString);
            DataSet ds = new DataSet();
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("execute sp_DoanhThuTungLoaiSanPhamTheoQuy " + year, cnn);
            adp.Fill(ds);
            cnn.Close();
            reportViewer1.LocalReport.ReportPath = "../../SanPhamTheoQuy.rdlc";
            ReportParameter rptYear = new ReportParameter("year", year.ToString());
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rptYear });
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "SP_TheoQuy";
            rds.Value = ds.Tables[0];
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }

        public void SanPhamTheoNam()
        {
            string connetionString = @"Data Source=DESKTOP-NIULDEP\SQLEXPRESS;Initial Catalog=lttq_buoi9;User ID=sa;Password=password";
            cnn = new SqlConnection(connetionString);
            DataSet ds = new DataSet();
            cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("execute sp_DoanhThuTungLoaiSanPhamTheoNam ", cnn);
            adp.Fill(ds);
            cnn.Close();
            reportViewer1.LocalReport.ReportPath = "../../SanPhamTheoNam.rdlc";
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "SP_TheoNam";
            rds.Value = ds.Tables[0];
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }
    }
}
