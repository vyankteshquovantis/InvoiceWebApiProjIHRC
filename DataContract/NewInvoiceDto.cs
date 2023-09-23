using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContract
{
    public class NewInvoiceDto
    {
        public string CustomerName { get; set; }
        public string CustomerMobNo { get; set; }
        public int PaymentMode { get; set; }
        public List<InvoiceItemDetailsDto> Items { get; set; }
    }
}
