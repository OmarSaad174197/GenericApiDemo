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
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<AddProductDto, Product>();

            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<AddCustomerDto, Customer>();
        }
    }
}
