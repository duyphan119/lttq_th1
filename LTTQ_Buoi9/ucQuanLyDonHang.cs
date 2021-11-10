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
    public partial class ucQuanLyDonHang : UserControl
    {
        private List<product> listProducts = new List<product>();
        private int rowIndex = -1;
        private string name;
        private decimal total = 0;
        private string invoiceNo;
        private DateTime deliveryDate;
        private List<invoice> listInvoice = new List<invoice>();
        private List<order> listOrder = new List<order>();
        private SqlConnection cnn;
        private SqlCommand scm;
        private SqlDataReader reader;

        public ucQuanLyDonHang()
        {
            InitializeComponent();
        }

        public string formatInvoiceID(int id)
        {
            string result = "";
            if (id < 10)
            {
                result = "00" + id;
            }else if (id < 100)
            {
                result = "0" + id;
            }
            else
            {
                result = "" + id;
            }
            return result;
        }

        private void ucQuanLyDonHang_Load(object sender, EventArgs e)
        {
            string connetionString = @"Data Source=DESKTOP-NIULDEP\SQLEXPRESS;Initial Catalog=lttq_buoi9;User ID=sa;Password=password";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            scm = new SqlCommand("select * from invoice", cnn);
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
            scm = new SqlCommand("select * from product", cnn);
            reader = scm.ExecuteReader();
            while (reader.Read())
            {
                product pro = new product();
                pro.productid = reader.GetValue(0).ToString();
                pro.productname = reader.GetValue(1).ToString();
                pro.unit = reader.GetValue(2).ToString();
                pro.buyprice = Convert.ToDecimal(reader.GetValue(3).ToString());
                pro.sellprice = Convert.ToDecimal(reader.GetValue(4).ToString());
                pro.deleted = Convert.ToBoolean(reader.GetValue(5).ToString());
                listProducts.Add(pro);
            }
            cnn.Close();
            listProducts.ForEach(product =>
            {
                if (product.deleted == false)
                {
                    productName.Items.Add(product.productname);
                }
            });
            txtInvoiceNo.Text ="HDX" + formatInvoiceID(listInvoice.Count + 1);
        }  

        private void dgvOrder_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvOrder.CurrentCell.ColumnIndex == 2 && e.Control is ComboBox)
            {
                ComboBox comboBox = e.Control as ComboBox;
                comboBox.SelectedIndexChanged -= nameChanged;
                comboBox.SelectedIndexChanged += nameChanged;
            }
            if (dgvOrder.CurrentCell.ColumnIndex == 4 && e.Control is TextBox)
            {
                TextBox txb = e.Control as TextBox;
                txb.TextChanged += quantityChanged;
            }
        }

        private void nameChanged(object sender, EventArgs e)
        {
            name = (sender as ComboBox).SelectedItem.ToString();
            int index = listProducts.FindIndex(product => product.productname == name);
            DataGridViewRow row = dgvOrder.Rows[rowIndex];
            row.Cells[0].Value = rowIndex + 1;
            row.Cells[1].Value = listProducts[index].productid;
            row.Cells[3].Value = listProducts[index].unit;
            row.Cells[4].Value = 1;
            row.Cells[5].Value = listProducts[index].sellprice;
            row.Cells[6].Value = Convert.ToDecimal(row.Cells[5].Value) * Convert.ToDecimal(row.Cells[4].Value);
            total += Convert.ToDecimal(row.Cells[6].Value);
            setPriceResult();
        }

        private void quantityChanged(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvOrder.Rows[rowIndex];
            try
            {
                row.Cells[4].Value = (sender as TextBox).Text;
                row.Cells[6].Value = Convert.ToDecimal(row.Cells[5].Value) * Convert.ToDecimal(row.Cells[4].Value);
                setPriceResult();
            }
            catch (FormatException er)
            {
                MessageBox.Show("Nhập số lượng không hợp lệ");
                Console.WriteLine(er);
            }
        }

        private void dgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            listOrder.Clear();
            invoiceNo = txtInvoiceNo.Text;
            DateTime orderDate = dtpOrderDate.Value;
            deliveryDate = dtpDeliveryDate.Value;
            string note = txtNote.Text;
            invoice inv = new invoice();
            inv.invoiceno = invoiceNo;
            inv.orderdate = orderDate;
            inv.deliverydate = deliveryDate;
            inv.note = note;
            listInvoice.Add(inv);
            int count = dgvOrder.Rows.Count;
            cnn.Open();
            scm = new SqlCommand("insert into invoice(invoiceno, orderdate, deliverydate, note) values" +
                "(N'" + inv.invoiceno + "','" + inv.orderdate + "','" + inv.deliverydate + "',N'" + inv.note + "')",cnn);
            scm.ExecuteNonQuery();
            cnn.Close();
            for (int i = 0; i < count - 1; i++)//Trừ 1 vì dư 1 hàng trống cuối datagridview
            {
                DataGridViewRow row = dgvOrder.Rows[i];
                int no = Convert.ToInt32(row.Cells[0].Value);
                string productId = row.Cells[1].Value.ToString();
                string productName = row.Cells[2].Value.ToString();
                string unit = row.Cells[3].Value.ToString();
                int quantity = Convert.ToInt32(row.Cells[4].Value);
                decimal sellPrice = Convert.ToDecimal(row.Cells[5].Value);
                order or = new order();
                or.inv.invoiceno = invoiceNo;
                or.no = no;
                or.pro.productid = productId;
                or.pro.productname = productName;
                or.pro.unit = unit;
                or.pro.sellprice = sellPrice;
                or.quantity = quantity;
                listOrder.Add(or);
                cnn.Open();
                scm = new SqlCommand("insert into [dbo].[order](invoiceno, no, productid, productname, unit, quantity, price) values" +
               "(N'" + or.inv.invoiceno + "',"+or.no + ",N'" + or.pro.productid + "',N'" + or.pro.productname + "',N'" + or.pro.unit + "',"+or.quantity+","+or.pro.sellprice+")", cnn);
                scm.ExecuteNonQuery();
                cnn.Close();
            }
            reset();

            MessageBox.Show("Đặt hàng thành công");
        }

        public void setPriceResult()
        {
            int count = dgvOrder.Rows.Count;
            total = 0;
            for(int i = 0; i < count; i++)
            {
                DataGridViewRow row = dgvOrder.Rows[i];
                total += Convert.ToDecimal(row.Cells[6].Value);
                txtPrice.Text = "" + total;
            }
        }

        public void reset()
        {
            txtInvoiceNo.Text = "";
            dtpOrderDate.Value = DateTime.Now;
            dtpDeliveryDate.Value = DateTime.Now;
            txtNote.Text = "";
            dgvOrder.Rows.Clear();
            txtInvoiceNo.Text = "HDX" + formatInvoiceID(listInvoice.Count + 1);
            total = 0;
            txtPrice.Text = "" + total;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(listOrder.Count > 0)
            {
                new BaoCao(listInvoice[listInvoice.Count-1].invoiceno, deliveryDate).Visible = true;
            }
            else
            {
                MessageBox.Show("Chưa nhập đơn hàng!");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Add(new ucTrangChu());
            this.Parent.Controls.Remove(this);
        }
    }
}
