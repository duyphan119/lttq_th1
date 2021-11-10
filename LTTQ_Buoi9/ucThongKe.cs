using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTTQ_Buoi9
{
    public partial class ucThongKe : UserControl
    {
        public ucThongKe()
        {
            InitializeComponent();
        }

        private void btnStatisticsMonth_Click(object sender, EventArgs e)
        {
            new ThongKe(1, Convert.ToInt32(numYear.Value)).Visible = true;
        }

        private void ucThongKe_Load(object sender, EventArgs e)
        {
            numYear.Maximum = DateTime.Now.Year;
            numYear.Value = DateTime.Now.Year;
            numMonth.Value = DateTime.Now.Month;
        }

        private void btnStatistics3Month_Click(object sender, EventArgs e)
        {
            new ThongKe(0, Convert.ToInt32(numYear.Value)).Visible = true;
        }

        private void btnStatisticsYear_Click(object sender, EventArgs e)
        {
            new ThongKe(-1, Convert.ToInt32(numYear.Value)).Visible = true;
        }

        private void btnStatisticsProductMonth_Click(object sender, EventArgs e)
        {
            new ThongKe(-2, Convert.ToInt32(numYear.Value)).Visible = true;
        }

        private void btnStatisticsProduct3Month_Click(object sender, EventArgs e)
        {
            new ThongKe(-3, Convert.ToInt32(numYear.Value)).Visible = true;
        }

        private void btnStatisticsProductYear_Click(object sender, EventArgs e)
        {
            new ThongKe(-4, Convert.ToInt32(numYear.Value)).Visible = true;
        }
    }
}
