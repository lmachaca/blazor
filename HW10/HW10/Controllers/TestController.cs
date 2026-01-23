using Microsoft.AspNetCore.Mvc;

namespace HW10.Controllers
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private static readonly List<Item> Items = [];
        private static int _nextId = 1;


        //get : /Test/items
        [HttpGet("items")]
        public ActionResult<IEnumerable<Item>> GetItems()
        {
            return Ok(Items);
        }
        //post : /Test/items 
        [HttpPost("items")]
        public ActionResult<Item> CreateItem([FromBody] Item newItem)
        {
            newItem.Id = _nextId++;
            Items.Add(newItem);
            return CreatedAtAction(nameof(GetItems), new { id = newItem.Id }, newItem);
        }

        //put : /Test/items/{id}
        [HttpPut("items/{id}")]  
        public IActionResult UpdateItem(int id, [FromBody] Item updatedItem)
        {
            if (updatedItem == null || string.IsNullOrWhiteSpace(updatedItem.Name))
            {
                return BadRequest("Item name is required.");
            }

            var existingItem = Items.FirstOrDefault(i => i.Id == id);
            if (existingItem == null)
            {
                return NotFound($"Item with ID {id} not found.");
            }

            existingItem.Name = updatedItem.Name;

            return NoContent();
        }
        //delete : /Test/items/{id}
        [HttpDelete("items/{id}")]
        public IActionResult DeleteItem(int id) {
            var item = Items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound($"Item with ID {id} not found.");
            }
            Items.Remove(item);
            return NoContent();
        }
    }
}