using Microsoft.AspNetCore.Mvc;
using Onion.Application.Features.CQRS.Commands;
using Onion.Application.Features.CQRS.Handlers;
using Onion.Application.Features.CQRS.Queries;

namespace Onion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
        private readonly DeleteCategoryCommandHandler _deleteCategoryCommandHandler;

        public CategoriesController(GetCategoryQueryHandler getCategoryQueryHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, CreateCategoryCommandHandler createCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, DeleteCategoryCommandHandler deleteCategoryCommandHandler)
        {
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
            _deleteCategoryCommandHandler = deleteCategoryCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()   
        {
            var result = await _getCategoryQueryHandler.Handle();
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var value = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            if (value == null)
            {
                return NotFound("Kategori Bulunamadı");
            }
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateCategoryCommand command)
        {
            var result = await _createCategoryCommandHandler.Handle(command);
            if (!result)
            {
                return BadRequest("Kategori ekleme işlemi başarısız.");
            }
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryCommand command)
        {
            var result = await _updateCategoryCommandHandler.Handle(command);
            if (!result)
            {
                return BadRequest("Kategori güncelleme işlemi başarısız.");
            }
            return Ok("Güncelleme işlemi başarılı.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _deleteCategoryCommandHandler.Handle(new DeleteCategoryCommand(id));
            if (!result)
            {
                return BadRequest("Kategori silme işlemi başarısız.");
            }
            return Ok("Silme işlemi başarılı.");

        }



    }
}
