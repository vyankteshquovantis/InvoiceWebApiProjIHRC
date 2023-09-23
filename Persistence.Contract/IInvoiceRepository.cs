using EntityContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contract
{
    public interface IInvoiceRepository
    {
        Task<Invoice?> GetInvoice(string invoiceNo);
        Task CreateInvoice(Invoice invoice);
        Task UpdateInvoice(Invoice invoice);
        Task DeleteInvoice(Invoice invoice);
        Task<List<Invoice>> GetInvoices();
        Task<Invoice?> GetInvoiceWithoutItems(string invoiceNo);
    }
}
