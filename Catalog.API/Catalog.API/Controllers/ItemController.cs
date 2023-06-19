using Microsoft.AspNetCore.Mvc;
using Catalog.Domain.Contracts;
using Catalog.Domain.Contracts.Models;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ItemController: ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpPost]
        public async Task<ActionResult<ItemModel>> Create(ItemModel item)
        {
            var res = await _itemService.Create(item);

            if (res == null) return BadRequest("Item not created!");

            return Ok(res);
        }

        [HttpGet("id")]
        public ActionResult<ItemModel> Get(int id)
        {
            var res = _itemService.Get(id);

            if (res == null) return BadRequest("Item not found!");

            return Ok(res);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ItemModel>> GetAll()
        {
            var collection = _itemService.GetAll();

            if (collection == null) return BadRequest("No items found!");

            return Ok(collection);

        }

        [HttpPut]
        public async Task<ActionResult> Update(ItemModel item)
        {
            var res = await _itemService.Update(item);

            if (res == Guid.Empty) return BadRequest("Item not updated!");

            return Ok(res);
        }

        [HttpDelete("id")]
        public async Task<ActionResult> Delete(int id)
        {
            await _itemService.Delete(id);

            return Ok();
        }
    }
}
