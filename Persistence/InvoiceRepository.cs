using EntityContract;
using Microsoft.EntityFrameworkCore;
using Persistence.Contract;

namespace Persistence
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly HKRPInvoiceContext _dbContext;
        public InvoiceRepository(HKRPInvoiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateInvoice(Invoice invoice)
        {
            await _dbContext.Invoices.AddAsync(invoice);
            await _dbContext.SaveChangesAsync();

        }

        public async Task DeleteInvoice(Invoice invoice)
        {
            _dbContext.Invoices.Remove(invoice);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Invoice?> GetInvoice(string invoiceNo)
        {
            return await _dbContext.Invoices.Include(x => x.InvoiceItemMappings).ThenInclude(y => y.Item).FirstOrDefaultAsync(x => x.InvoiceNo == invoiceNo);

        }

        public async Task<Invoice?> GetInvoiceWithoutItems(string invoiceNo)
        {
            return await _dbContext.Invoices.FirstOrDefaultAsync(x => x.InvoiceNo == invoiceNo);

        }

        public async Task<List<Invoice>> GetInvoices()
        {
            return await _dbContext.Invoices.Include(x => x.InvoiceItemMappings).ThenInclude(y => y.Item).ToListAsync();

        }


        public async Task UpdateInvoice(Invoice invoice)
        {
            _dbContext.Set<Invoice>().Update(invoice);
            await _dbContext.SaveChangesAsync();
        }
    }
}
