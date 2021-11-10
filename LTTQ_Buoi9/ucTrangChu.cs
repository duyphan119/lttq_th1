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
    public partial class ucTrangChu : UserControl
    {
        private DataTable dt = new DataTable("Statistics");
        private List<invoice> listInvoice = new List<invoice>();
        private List<order> listOrder = new List<order>();
        private DateTime deliveryDateReport;
        private string invoiceno = "";
        private decimal total = 0;
        private bool hasSearchFromTo = false;
        private SqlConnection cnn;
        private SqlCommand scm;
        private SqlDataReader reader;
        public ucTrangChu()
        {
            InitializeComponent();
        }

        private void ucTrangChu_Load(object sender, EventArgs e)
        {
            string connetionString = @"Data Source=DESKTOP-NIULDEP\SQLEXPRESS;Initial Catalog=lttq_buoi9;User ID=sa;Password=password";
            cnn = new SqlConnection(connetionString);
            //Lấy tất cả hoá đơn
            cnn.Open();
            scm = new SqlCommand("select * from invoice",cnn);
            reader = scm.ExecuteReader();
            while (reader.Read())
            {
                invoice inv = new invoice();
                inv.invoiceno = reader.GetValue(0).ToString();
                inv.orderdate = DateTime.Parse(reader.GetValue(1).ToString());
                inv.deliverydate = DateTime.Parse(reader.GetValue(2).ToString());
                inv.note = reader.GetValue(3).ToString();
                listInvoice.Add(inv);
            }
            cnn.Close();
            cnn.Open();
            scm = new SqlCommand("select * from [dbo].[order]", cnn);
            reader = scm.ExecuteReader();
            while (reader.Read())
            {
                order or = new order();
                or.inv.invoiceno = reader.GetValue(0).ToString();
                or.pro.productid = reader.GetValue(1).ToString();
                or.no = Convert.ToInt32(reader.GetValue(2).ToString());
                or.pro.productname = reader.GetValue(3).ToString();
                or.pro.unit = reader.GetValue(4).ToString();
                or.pro.sellprice = Convert.ToInt32(reader.GetValue(5).ToString());
                or.quantity = Convert.ToInt32(reader.GetValue(6).ToString());
                listOrder.Add(or);
            }
            cnn.Close();
            dt.Columns.Add("STT", System.Type.GetType("System.String"));
            dt.Columns.Add("Số HĐ", System.Type.GetType("System.String"));
            dt.Columns.Add("Ngày Đặt Hàng", System.Type.GetType("System.String"));
            dt.Columns.Add("Ngày Giao Hàng", System.Type.GetType("System.String"));
            dt.Columns.Add("Thành Tiền", System.Type.GetType("System.Int32"));
            dgvSearch.DataSource = dt;
            dgvSearch.Columns[0].Width = 49;
            dgvSearch.Columns[1].Width = 66;
            dgvSearch.Columns[2].Width = 146;
            dgvSearch.Columns[3].Width = 146;
            dgvSearch.Columns[4].Width = 120;
            //Mặc định là các hoá đơn ngày hôm nay
            DateTime Now = DateTime.Now;
            searchByDate(new DateTime(Now.Year, Now.Month, Now.Day, 0, 0, 0), new DateTime(Now.Year, Now.Month, Now.Day, 23, 59, 59));
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (invoiceno != "")
            {
                new BaoCao(invoiceno, deliveryDateReport).Visible = true;
            }
            else
            {
                MessageBox.Show("Chưa chọn đơn hàng !");
            }
        }

        private void btnAddInvoice_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Add(new ucQuanLyDonHang());
            this.Parent.Controls.Remove(this);
        }

        private void dtpDeliveryDateFrom_ValueChanged(object sender, EventArgs e)
        {
            if (!hasSearchFromTo) hasSearchFromTo = true;
            searchByDate(dtpDeliveryDateFrom.Value, dtpDeliveryDateTo.Value);
        }

        private void dtpDeliveryDateTo_ValueChanged(object sender, EventArgs e)
        {
            if (!hasSearchFromTo) hasSearchFromTo = true;
            searchByDate(dtpDeliveryDateFrom.Value, dtpDeliveryDateTo.Value);
        }

        public void searchByDate(DateTime from, DateTime to)
        {
            total = 0;
            dt.Rows.Clear();
            //Lấy các hoá đơn trong khoảng thời gian
            List<invoice> newList = listInvoice.FindAll(inv =>
            {
                return DateTime.Compare((DateTime)inv.deliverydate, from) >= 0 && DateTime.Compare((DateTime)inv.deliverydate, to) <= 0;
            });
            //Tính thành tiền từng hoá đơn
            for (int i = 0; i < newList.Count; i++)
            {
                List<order> orders = new List<order>();
                orders = getOrder(newList[i].invoiceno);
               
                
                //Tính thành tiền
                decimal price = 0;
                orders.ForEach(o =>
                {
                    price += Convert.ToDecimal(o.quantity * o.pro.sellprice);
                });
                dt.Rows.Add(new object[]
                {
                    i + 1,
                    newList[i].invoiceno,
                    newList[i].orderdate,
                    newList[i].deliverydate,
                    price
                });
                
                total += price;
            }
            if (dgvSearch.Controls.OfType<VScrollBar>().First().Visible)
            {
                dgvSearch.Columns[4].Width = 103;
            }
            else
            {
                dgvSearch.Columns[4].Width = 120;
            }
            dgvSearch.DataSource = dt;
            txtPrice.Text = "" + total;
            //Mặc định chọn hoá đơn đầu tiên
            if (dgvSearch.Rows.Count > 1)
            {
                invoiceno = dgvSearch.Rows[0].Cells[1].Value.ToString();
                deliveryDateReport = DateTime.Parse(dgvSearch.Rows[0].Cells[3].Value.ToString());
            }
        }

        private void ckbViewAll_CheckedChanged(object sender, EventArgs e)
        {
            DateTime Now = DateTime.Now;
            if(ckbViewAll.Checked == true)
            {
                searchByDate(new DateTime(Now.Year, Now.Month, 1, 0, 0, 0), new DateTime(Now.Year, Now.Month, DateTime.DaysInMonth(Now.Year, Now.Month), 23, 59, 59));
            }
            else
            {
                if (hasSearchFromTo)
                {
                    searchByDate(dtpDeliveryDateFrom.Value, dtpDeliveryDateTo.Value);
                }
                else
                {
                    searchByDate(new DateTime(Now.Year, Now.Month, Now.Day, 0, 0, 0), new DateTime(Now.Year, Now.Month, Now.Day, 23, 59, 59));
                }
            }
        }

        private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != dgvSearch.RowCount - 1 && e.RowIndex!=-1)
            {
                invoiceno = dgvSearch.Rows[e.RowIndex].Cells[1].Value.ToString();
                deliveryDateReport = DateTime.Parse(dgvSearch.Rows[e.RowIndex].Cells[3].Value.ToString());
            }
            else
            {
                invoiceno = "";
            }
        }

        public List<order> getOrder(string invoiceno)
        {
            List<order> result = new List<order>();
            for (int i = 0; i < listOrder.Count; i++)
            {
                if (listOrder[i].inv.invoiceno == invoiceno)
                {
                    result.Add(listOrder[i]);
                }
            }
            return result;
        }
    }
}
