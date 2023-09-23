namespace DataContract
{
    public class InvoiceGridDto
    {
        public string? InvoiceNo { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CustomerName { get; set; }
        public string CustomerMobNo { get; set; }
        public string PaymentMode { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal PayableAmount { get; set; }

    }
}
