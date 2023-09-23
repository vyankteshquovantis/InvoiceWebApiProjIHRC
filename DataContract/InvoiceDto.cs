namespace DataContract
{
    public class InvoiceDto
    {
        public InvoiceGridDto InvoiceDetails { get; set; }
        public List<ItemDto> Items { get; set; }

    }
}