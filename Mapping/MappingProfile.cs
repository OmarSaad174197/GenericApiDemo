using AutoMapper;
using GenericDemo.Dtos.CustomerDtos;
using GenericDemo.Dtos.ProductDtos;
using GenericDemo.Models;

namespace GenericDemo.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductResponseDto>().ReverseMap();
            CreateMap<ProductRequestDto, Product>().ReverseMap();

            CreateMap<Customer, CustomerResponseDto>().ReverseMap();
            CreateMap<CustomerRequestDto, Customer>().ReverseMap();
        }
    }
}