using Microsoft.AspNetCore.Mvc;

namespace Play.Catalog.Service.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemController : ControllerBase
    {
        private static readonly List<ItemDto> items = new()
        {
            new ItemDto(Guid.NewGuid(), "Potion", "Restores a small amount of HP", 5, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Antidote", "Cures poison", 7, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Bronze sword", "Deals a small amount of damage", 20, DateTimeOffset.UtcNow)
        };

        [HttpGet]
        public ActionResult<IEnumerable<ItemDto>> Get()
        {
            return Ok(items);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<ItemDto>> GetById(Guid id)
        {
            var item = items.Where(item => item.id == id).SingleOrDefault();
            return Ok(item);
        }
    }
}