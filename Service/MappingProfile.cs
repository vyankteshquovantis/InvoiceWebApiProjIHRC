using AutoMapper;
using DataContract;
using EntityContract;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Service
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {
            MappingConfiguration();
        }

        public void MappingConfiguration()
        {
            CreateMap<Invoice, InvoiceGridDto>()
                .ForMember(dest => dest.PaymentMode, src => src.MapFrom(x => x.PaymentMode.ToString()))
                .ReverseMap();

            CreateMap<Invoice, InvoiceDto>()
                .ForMember(dest => dest.InvoiceDetails, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.InvoiceItemMappings))
                .AfterMap((src,dest) =>
                {
                    dest.InvoiceDetails.TotalAmount = src.InvoiceItemMappings.Select(x => x.Item.UnitPrice*x.ItemQty).Sum();
                    dest.InvoiceDetails.Discount = src.InvoiceItemMappings.Select(x => x.Item.Discount * x.ItemQty).Sum();
                    dest.InvoiceDetails.PayableAmount = dest.InvoiceDetails.TotalAmount - dest.InvoiceDetails.Discount;
                });

            CreateMap<NewInvoiceDto, Invoice>()
                .ForMember(dest => dest.CustomerMobNo, src => src.MapFrom(x => x.CustomerMobNo))
                .ForMember(dest => dest.CustomerName, src => src.MapFrom(x => x.CustomerName));

            CreateMap<Invoice, InvoiceGridDto>()
            .ForMember(dest => dest.InvoiceNo, opt => opt.MapFrom(src => src.InvoiceNo))
            .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerName))
            .ForMember(dest => dest.CustomerMobNo, opt => opt.MapFrom(src => src.CustomerMobNo))
            .ForMember(dest => dest.PaymentMode, opt => opt.MapFrom(src => src.PaymentMode.ToString()));

            CreateMap<InvoiceItemMapping, ItemDto>()
                .ForMember(dest => dest.Quantity, src => src.MapFrom(src => src.ItemQty))
                .ForMember(dest => dest.ItemCode, src => src.MapFrom(src => src.ItemCode))
                .ForMember(dest => dest.Name, src => src.MapFrom(src => src.Item.Name))
                .ForMember(dest => dest.Category, src => src.MapFrom(src => src.Item.Category))
                .ForMember(dest => dest.UnitPrice, src => src.MapFrom(src => src.Item.UnitPrice))
                .ForMember(dest => dest.Discount, src => src.MapFrom(src => src.Item.Discount))
                .ForMember(dest => dest.NetAmount, src => src.MapFrom(src => (src.Item.UnitPrice - src.Item.Discount)*src.ItemQty));


        }
    }
}
