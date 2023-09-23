using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EntityContract
{
    [Index(nameof(InvoiceNo),IsUnique = true)]
    public class Invoice
    {
        [Key]
        public string InvoiceNo { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string CustomerMobNo { get; set; }

        public PaymentMode PaymentMode { get; set; }

        //navigation properties
        public ICollection<InvoiceItemMapping> InvoiceItemMappings { get; set; }
    }
}