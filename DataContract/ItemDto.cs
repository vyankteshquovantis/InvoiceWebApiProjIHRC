using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContract
{
    public class ItemDto
    {
        [Required]
        public string ItemCode { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal NetAmount { get; set; }
        public int Quantity { get; set; }
    }
}
