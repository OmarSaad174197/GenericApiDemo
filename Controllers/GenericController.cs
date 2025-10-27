using AutoMapper;
using GenericDemo.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GenericDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<TEntity, TRequest, TResponse> : ControllerBase
        where TEntity : class
        where TRequest : class
        where TResponse : class
    {
        protected readonly IUnitOfWork Uow;
        protected readonly IMapper Mapper;

        public GenericController(IUnitOfWork uow, IMapper mapper)
        {
            Uow = uow;
            Mapper = mapper;
        }
        protected IGenericRepository<TEntity> Repo => Uow.Repository<TEntity>();
        protected object? GetEntityId(TEntity entity)
        {
            var prop = typeof(TEntity).GetProperty("Id");
            return prop?.GetValue(entity);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var entities = await Repo.GetAllAsync();
            return Ok(Mapper.Map<IEnumerable<TResponse>>(entities));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await Repo.GetByIdAsync(id);
            if (entity == null) return NotFound();
            return Ok(Mapper.Map<TResponse>(entity));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] TRequest request)
        {
            if (request == null) return BadRequest();

            var entity = Mapper.Map<TEntity>(request);
            await Repo.AddAsync(entity);
            await Uow.SaveChangesAsync();

            var result = Mapper.Map<TResponse>(entity);
            return CreatedAtAction(nameof(GetById), new { id = GetEntityId(entity) }, result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] TRequest request)
        {
            if (request == null) return BadRequest();

            var entity = await Repo.GetByIdAsync(id);
            if (entity == null) return NotFound();

            Mapper.Map(request, entity);
            Repo.Update(entity);
            await Uow.SaveChangesAsync();

            var result = Mapper.Map<TResponse>(entity);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await Repo.GetByIdAsync(id);
            if (entity == null) return NotFound();

            Repo.Delete(entity);
            await Uow.SaveChangesAsync();
            return NoContent();
        }
    }
}