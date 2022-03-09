using Microsoft.AspNetCore.Mvc;
using Play.Catalog.Service.Dtos;
using Play.Catalog.Service.Repositories;

namespace Play.Catalog.Service.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemController : ControllerBase
    {
        private readonly ItemsRepository itemsRepository = new();

        // GET /items
        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetAsync()
        {
            var items = (await itemsRepository.GetAllAsync())
                        .Select(item => item.AsDto());
            return items;
        }

        // GET /items/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetByIdAsync(Guid id)
        {
            var item = await itemsRepository.GetAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return item.AsDto();
        }

        // // POST /items
        // [HttpPost]
        // public ActionResult<ItemDto> Post(CreateItemDto createItemDto)
        // {
        //     var item = new ItemDto(Guid.NewGuid(), createItemDto.Name, createItemDto.Description, createItemDto.Price, DateTimeOffset.UtcNow);
        //     items.Add(item);

        //     return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        // }

        // // PUT /items/{id}
        // [HttpPut("{id}")]
        // public IActionResult Put(Guid id, UpdateItemDto updateItemDto)
        // {
        //     var existingItem = items.Where(item => item.Id == id).SingleOrDefault();

        //     if (existingItem == null)
        //     {
        //         return NotFound();
        //     }

        //     var updateItem = existingItem with
        //     {
        //         Name = updateItemDto.Name,
        //         Description = updateItemDto.Description,
        //         Price = updateItemDto.Price
        //     };

        //     var index = items.FindIndex(existingItem => existingItem.Id == id);
        //     items[index] = updateItem;

        //     return NoContent();
        // }

        // //DELETE /items/{id}
        // [HttpDelete("{id}")]
        // public IActionResult Delete(Guid id)
        // {
        //     var index = items.FindIndex(existingItem => existingItem.Id == id);

        //     if (index < 0)
        //     {
        //         return NotFound();
        //     }

        //     items.RemoveAt(index);

        //     return NoContent();
        // }
    }
}