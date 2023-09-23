using AutoMapper;
using DataContract;
using EntityContract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contract;

namespace HKRPInvoiceProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IMapper _mapper;
        public InvoiceController(IInvoiceService invoiceService, IMapper mapper)
        {
            _invoiceService = invoiceService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetInvoices()
        {
            return Ok(_mapper.Map<List<InvoiceDto>>(await _invoiceService.GetInvoices()));
        }

        [HttpGet("{invoiceNo}")]
        public async Task<ActionResult> GetInvoice(string invoiceNo)
        {
            var invoice = await _invoiceService.GetInvoice(invoiceNo);
            return invoice != null ? Ok(_mapper.Map<InvoiceDto>(invoice)) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> AddInvoice([FromBody]NewInvoiceDto invoiceDto)
        {
            var invoiceNo = await _invoiceService.AddInvoice(invoiceDto);
            return CreatedAtAction(nameof(AddInvoice), invoiceNo);
        }

        [HttpPut("{invoiceNo}")]
        public async Task<ActionResult> UpdateInvoice(UpdateInvoiceDto invoiceDto)
        {
            var isInvoiceUpdated = await _invoiceService.UpdateInvoice(invoiceDto);
            return isInvoiceUpdated ? Ok() : NotFound();
        }

        [HttpDelete("{invoiceNo}")]
        public async Task<ActionResult> DeleteInvoice(string invoiceNo)
        {
            var isDeleted =await _invoiceService.DeleteInvoice(invoiceNo);
            return isDeleted ? Ok() : NotFound();
        }
    }
}
