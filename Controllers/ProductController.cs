using AutoMapper;
using GenericDemo.Dtos.ProductDtos;
using GenericDemo.Interfaces;
using GenericDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace GenericDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : GenericController<Product, ProductResponseDto, ProductRequestDto>

    {
        public ProductsController(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }
    }
}
