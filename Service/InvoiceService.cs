using AutoMapper;
using DataContract;
using EntityContract;
using Persistence.Contract;
using Service.Contract;

namespace Service
{
    public class InvoiceService : IInvoiceService
    {
        private const string InvoiceNoDateFormat = "yyMMddHHmmss";
        private const int InvoiceNoRandomLetterLength = 8;
        private const string AlphaNumericCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;
        public InvoiceService(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public async Task<Invoice?> GetInvoice(string invoiceNo)
        {
            return await _invoiceRepository.GetInvoice(invoiceNo);
        }

        public async Task<List<Invoice>> GetInvoices()
        {
            return await _invoiceRepository.GetInvoices();
        }

        public async Task<string> AddInvoice(NewInvoiceDto invoiceDto)
        {
            var invoice = _mapper.Map<Invoice>(invoiceDto);
            invoice.InvoiceNo = GenerateInvoiceNo();
            invoice.CreatedOn = DateTime.Now;
            invoice.InvoiceItemMappings = new List<InvoiceItemMapping>();
            invoiceDto.Items.ForEach(x =>
            {
                invoice.InvoiceItemMappings.Add(new InvoiceItemMapping { InvoiceNo = invoice.InvoiceNo, ItemCode = x.ItemCode, ItemQty = x.Quantity });
            });
            await _invoiceRepository.CreateInvoice(invoice);
            return invoice.InvoiceNo;
        }

        public async Task<bool> UpdateInvoice(UpdateInvoiceDto invoiceDto)
        {
            var invoice = await _invoiceRepository.GetInvoice(invoiceDto.InvoiceNo);
            if (invoice == null)
            {
                return false;
            }
            invoice.CustomerMobNo = invoiceDto.CustomerMobNo;
            invoice.CustomerName = invoiceDto.CustomerName;
            invoice.InvoiceItemMappings.Clear();
            invoiceDto.Items.ForEach(x =>
            {
                invoice.InvoiceItemMappings.Add(new InvoiceItemMapping { InvoiceNo = invoice.InvoiceNo, ItemCode = x.ItemCode, ItemQty = x.Quantity });
            });
            await _invoiceRepository.UpdateInvoice(invoice);
            return true;
        }

        public async Task<bool> DeleteInvoice(string invoiceNo)
        {
            var invoice = await _invoiceRepository.GetInvoiceWithoutItems(invoiceNo);
            if (invoice == null)
            {
                return false;
            }

            await _invoiceRepository.DeleteInvoice(invoice);
            return true;

        }

        private static string GenerateInvoiceNo()
        {
            string timestamp = DateTime.Now.ToString(InvoiceNoDateFormat);
            string randomText = GenerateRandomText(InvoiceNoRandomLetterLength);
            return $"{timestamp}-{randomText}";
        }

        private static string GenerateRandomText(int length)
        {
            const string chars = AlphaNumericCharacters;
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}