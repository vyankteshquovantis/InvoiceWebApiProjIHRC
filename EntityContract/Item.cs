using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityContract
{
    [Index(nameof(ItemCode), IsUnique = true)]
    public class Item
    {
        [Key]
        public string ItemCode { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public ItemCategory Category { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Discount { get; set; }

        //navigation properties
        public ICollection<InvoiceItemMapping> InvoiceItemMappings { get; set; }
    }

}
