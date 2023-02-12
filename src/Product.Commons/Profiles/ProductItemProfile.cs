using System;
using AutoMapper;
using Product.Commons.Dtos;
using Product.Domain.Models;

namespace Product.Commons.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductItem, ProductItemDto>()
                .ForMember(dto => dto.Status, opt => opt.MapFrom(pi => pi.Status.ToString()))
                .ReverseMap()
                .ForMember(pi => pi.Status, opt => opt.MapFrom(dto => (ProductStatus)Enum.Parse(typeof(ProductStatus), dto.Status)));
        }
    }
}