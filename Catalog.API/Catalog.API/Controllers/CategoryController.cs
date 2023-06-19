using Microsoft.AspNetCore.Mvc;
using Catalog.Domain.Contracts;
using Catalog.Domain.Contracts.Models;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class CategoryController: ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
              _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<ActionResult<CategoryModel>> Create(CategoryModel model)
        {
            var res = await _categoryService.Create(model);
            return Ok(res);
        }
        [HttpGet("id")]
        public ActionResult<CategoryModel> Get(Guid id)
        {
            var res = _categoryService.Get(id);

            if (res == null) return BadRequest("Product not found!");

            return Ok(res);
        }
        [HttpGet]
        public ActionResult<IEnumerable<CategoryModel>> GetAll()
        {
            var res = _categoryService.GetAll();

            if (res == null) return BadRequest("No products found!");

            return Ok(res);
        }

        [HttpPut]
        public async Task<ActionResult<CategoryModel>> Update(CategoryModel category)
        {
            var res = await _categoryService.Update(category);
            if (res == Guid.Empty)
            {
                return BadRequest("Product not updated");
            }
            return Ok(res);
        }

        [HttpDelete("id")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _categoryService.Delete(id);
            return Ok();
        }
    }
}
