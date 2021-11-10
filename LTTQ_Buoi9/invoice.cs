using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTTQ_Buoi9
{
    public class invoice
    {
        public string invoiceno, note;
        public DateTime orderdate, deliverydate;

        public invoice()
        {
        }

        public invoice(string invoiceno, string note, DateTime orderdate, DateTime deliverydate)
        {
            this.invoiceno = invoiceno;
            this.note = note;
            this.orderdate = orderdate;
            this.deliverydate = deliverydate;
        }
    }
}
