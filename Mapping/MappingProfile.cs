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
        CreateMap<Product, ProductResponseDto>();
        CreateMap<ProductRequestDto, Product>();

        CreateMap<Customer, CustomerResponseDto>();
        CreateMap<CustomerRequestDto, Customer>();
        }
    }
}