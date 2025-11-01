using AutoMapper;
using GenericDemo.Dtos.CustomerDtos;
using GenericDemo.Interfaces;
using GenericDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace GenericDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : GenericController<Customer, CustomerResponseDto, CustomerRequestDto>
    {
        public CustomerController(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }
    }
}
