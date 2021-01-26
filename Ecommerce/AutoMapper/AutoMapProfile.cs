using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Entities;
using Ecommerce.Helpers;
using Ecommerce.ModelDTO;

namespace Ecommerce.AutoMapper
{
    public class AutoMapProfile : Profile
    {
        public AutoMapProfile()
        {


            CreateMap<Orders, OrdersDTO>()
                .ForMember(
                      dest => dest.CreatedDate,//s => Mapper.Map<DomainClass, Child>(s))
                      opt => opt.MapFrom(src => $"{src.CreatedDate.FormatDatetime()}"))
            .ForMember(
                  dest => dest.ModifiedDate,
                  opt => opt.MapFrom(src => $"{src.ModifiedDate.FormatDatetime()}"));          
            

            CreateMap<Payments, PaymentDTO>()
                .ForMember(
                  dest => dest.Paymentdate,
                  opt => opt.MapFrom(src => $"{src.Paymentdate.StringFormatDatetime()}"))
                .ForMember(
                      dest => dest.PaymentDetails,
                      opt => opt.MapFrom(src => $"  {src.BillingAdd1} ;  {src.BillingAdd2} ; {src.City} ; {src.State} ;  {src.Zip}"));

            CreateMap<ShippingDetails, ShippingDetailDTO>()
                     .ForMember(
                      dest => dest.ShippingDetails,
                      opt => opt.MapFrom(src => $"{src.ShippingAdd1} ; {src.ShippingAdd2} ; {src.City} ; {src.State} ; {src.Zip}"));



        }

        


    }

    
}
