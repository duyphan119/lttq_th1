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
    public partial class ucQuanLySanPham : UserControl
    {
        private List<product> listAllProduct = new List<product>();
        private List<product> listProduct = new List<product>();
        private DataTable dt = new DataTable("Product");
        private int rowClicked;
        private bool prevent = true;//true: ko lấy dữ liệu từ bảng khi click, false: lấy dữ liệu từ bảng khi click
        private SqlConnection cnn;
        private SqlCommand scm;
        private SqlDataReader reader;
        public ucQuanLySanPham()
        {
            InitializeComponent();
        }

        public string formatProductID (int newID)
        {
            if (newID < 10)
            {
                return "0" + newID;
            }
            return "" + newID;
        }

        private void ucQuanLySanPham_Load(object sender, EventArgs e)
        {
            string connetionString = @"Data Source=DESKTOP-NIULDEP\SQLEXPRESS;Initial Catalog=lttq_buoi9;User ID=sa;Password=password";
            cnn = new SqlConnection(connetionString);
           
            dt.Columns.Add("STT", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Mã SP", System.Type.GetType("System.String"));
            dt.Columns.Add("Tên SP", System.Type.GetType("System.String"));
            dt.Columns.Add("ĐVT", System.Type.GetType("System.String"));
            dt.Columns.Add("Giá mua", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Giá bán", System.Type.GetType("System.Int32"));
            cnn.Open();
            scm = new SqlCommand("select * from product", cnn);
            reader = scm.ExecuteReader();
            int i = 1;
            while (reader.Read())
            {
                product pro = new product();
                pro.productid = reader.GetValue(0).ToString();
                pro.productname = reader.GetValue(1).ToString();
                pro.unit = reader.GetValue(2).ToString();
                pro.buyprice = Convert.ToDecimal(reader.GetValue(3).ToString());
                pro.sellprice = Convert.ToDecimal(reader.GetValue(4).ToString());
                pro.deleted = Convert.ToBoolean(reader.GetValue(5).ToString());
                if (pro.deleted == false)
                {
                    dt.Rows.Add(new object[]
                    {
                        i++,
                        pro.productid,
                        pro.productname,
                        pro.unit,
                        pro.buyprice,
                        pro.sellprice
                    });
                    listProduct.Add(pro);
                }
                listAllProduct.Add(pro);
            }
            cnn.Close();
            dgvProduct.DataSource = dt;
            dgvProduct.Columns[0].Width = 39;
            dgvProduct.Columns[1].Width = 40;
            dgvProduct.Columns[2].Width = 110;
            dgvProduct.Columns[3].Width = 40;
            dgvProduct.Columns[4].Width = 55;
            dgvProduct.Columns[5].Width = 55;
            cbUnit.SelectedIndex = 0;
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowClicked = e.RowIndex;
            if(prevent == false && rowClicked >= 0 && rowClicked < dgvProduct.Rows.Count - 1)
            {
                txtProductID.Text = listProduct[rowClicked].productid;
                txtProductName.Text = listProduct[rowClicked].productname;
                cbUnit.SelectedItem = listProduct[rowClicked].unit;
                numBuyPrice.Value = listProduct[rowClicked].buyprice;
                numSellPrice.Value = listProduct[rowClicked].sellprice;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtProductID.Enabled == false)
            {
                setEnabled(true);
                prevent = false;
            }
            else
            {
                reset();
                setEnabled(false);
                prevent = true;
            }
        }

        private void txtProductID_TextChanged(object sender, EventArgs e)
        {
            string productID = txtProductID.Text;
            int index = listProduct.FindIndex(product => product.productid == productID);
            if (index != -1)
            {
                txtProductID.Text = listProduct[index].productid;
                txtProductName.Text = listProduct[index].productname;
                cbUnit.SelectedItem = listProduct[index].unit;
                numBuyPrice.Value = (decimal)listProduct[index].buyprice;
                numSellPrice.Value = (decimal)listProduct[index].sellprice;
            }
        }

        public void reset()
        {
            txtProductID.Text = "";
            txtProductName.Text = "";
            cbUnit.SelectedIndex = 0;
            numBuyPrice.Value = 0;
            numSellPrice.Value = 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            cnn.Open();
            scm = new SqlCommand(
                "update product set deleted = 1" +
                "where productId = N'" + listProduct[rowClicked].productid + "'", cnn
            );
            scm.ExecuteNonQuery();
            cnn.Close();
            dgvProduct.Rows.RemoveAt(rowClicked);
            listProduct.RemoveAt(rowClicked);
            //Cập nhật số thứ tự trong bảng 
            for (int i = rowClicked; i < listProduct.Count; i++)
            {
                dgvProduct.Rows[i].Cells[0].Value = i + 1;
            }
            MessageBox.Show("Sản phẩm đã được xoá");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtProductID.Enabled == false)
            {
                txtProductID.Text = formatID(listAllProduct.Count + 1);
                setEnabled(true);
            }
            else
            {
                reset();
                setEnabled(false);
            }
            prevent = true;

        }
        public string formatID(int n)
        {
            if (n < 10)
            {
                return "P0" + n;
            }
            else
            {
                return "P" + n;
            }
        }
        public void setEnabled(bool status)
        {
            txtProductID.Enabled = status;
            txtProductName.Enabled = status;
            cbUnit.Enabled = status;
            numBuyPrice.Enabled = status;
            numSellPrice.Enabled = status;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string productID = txtProductID.Text;
            string productName = txtProductName.Text;
            string unit = cbUnit.SelectedItem.ToString();
            decimal buyPrice = numBuyPrice.Value;
            decimal sellPrice = numSellPrice.Value;
            int index = listProduct.FindIndex(product => product.productid == productID);
            if (index == -1)
            {
                product p = new product();
                p.productid = productID;
                p.productname = productName;
                p.unit = unit;
                p.buyprice = buyPrice;
                p.sellprice = sellPrice;
                listProduct.Add(p);
                listAllProduct.Add(p);
                dt.Rows.Add(new object[]
                {
                    listProduct.Count,
                    productID,
                    productName,
                    unit,
                    buyPrice,
                    sellPrice,
                });
                cnn.Open();
                scm = new SqlCommand(
                    "insert into product(productId, productName, unit, buyprice, sellprice) " +
                    "values(N'" + p.productid + "',N'" + p.productname + "',N'" + p.unit + "'," + p.buyprice + "," + p.sellprice + ")", cnn
                );
                scm.ExecuteNonQuery();
                cnn.Close();
                dgvProduct.DataSource = dt;
                MessageBox.Show("Sản phẩm đã thêm thành công");
            }
            else
            {
                dgvProduct.Rows[index].Cells[2].Value = productName;
                dgvProduct.Rows[index].Cells[3].Value = unit;
                dgvProduct.Rows[index].Cells[4].Value = buyPrice;
                dgvProduct.Rows[index].Cells[5].Value = sellPrice;
                cnn.Open();
                scm = new SqlCommand(
                    "update product set productName=N'" + productName + "', unit=N'" + unit + "', buyprice=" + buyPrice + ", sellprice=" + sellPrice +
                    "where productId = N'" + productID + "'", cnn
                );
                scm.ExecuteNonQuery();
                cnn.Close();
                dgvProduct.DataSource = dt;
                listProduct[index].productname = productName;
                listProduct[index].unit = unit;
                listProduct[index].buyprice = buyPrice;
                listProduct[index].sellprice = sellPrice;
                MessageBox.Show("Sản phẩm cập nhật thành công");
            }
            reset();
            setEnabled(false);
            prevent = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Add(new ucTrangChu());
            this.Parent.Controls.Remove(this);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            reset();
            setEnabled(false);
        }
    }
}
