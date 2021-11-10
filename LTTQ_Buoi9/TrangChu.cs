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
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
            pnlControl.Controls.Add(new ucTrangChu());
        }

        private void nhậpĐơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlControl.Controls.Clear();
            pnlControl.Controls.Add(new ucQuanLyDonHang());
        }

        private void quảnLíSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlControl.Controls.Clear();
            pnlControl.Controls.Add(new ucQuanLySanPham());
        }



        private void pnlControl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void xuấtBáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BaoCao(null, DateTime.Now).Visible = true;
        }

        private void TrangChu_Load_1(object sender, EventArgs e)
        {
            
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void thốngKêToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pnlControl.Controls.Clear();
            pnlControl.Controls.Add(new ucThongKe());
        }
    }
}
