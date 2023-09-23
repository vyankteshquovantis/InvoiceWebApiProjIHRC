using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityContract
{
    public class InvoiceItemMapping
    {
        [Column(Order = 1)]
        public string InvoiceNo { get; set; }

        [Column(Order = 2)]
        public string ItemCode { get; set; }

        public int ItemQty { get; set; }

        // Navigation properties
        public Invoice Invoice { get; set; }
        public Item Item { get; set; }
    }
}
