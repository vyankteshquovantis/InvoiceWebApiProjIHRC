using DataContract;
using EntityContract;

namespace Service.Contract
{
    public interface IInvoiceService
    {
        public Task<List<Invoice>> GetInvoices();
        public Task<Invoice?> GetInvoice(string invoiceNo);
        public Task<string> AddInvoice(NewInvoiceDto invoiceDto);
        public Task<bool> UpdateInvoice(UpdateInvoiceDto invoiceDto);
        public Task<bool> DeleteInvoice(string invoiceNo);

    }
}
