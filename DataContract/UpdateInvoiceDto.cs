﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContract
{
    public class UpdateInvoiceDto: NewInvoiceDto
    {
        public string InvoiceNo { get; set; }
    }
}
