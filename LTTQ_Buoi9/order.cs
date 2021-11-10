using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTTQ_Buoi9
{
    public class order
    {
        public invoice inv = new invoice();
        public product pro = new product();
        public int quantity, no;

        public order()
        {
        }

        public order(invoice inv, product pro, int quantity)
        {
            this.inv = inv;
            this.pro = pro;
            this.quantity = quantity;
        }
    }
}
