using BlazorDemo.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorDemo.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private IToDoService _toDoItems;

        public ToDoItemsController(IToDoService toDoItems)
        {
            _toDoItems = toDoItems;
        }

        // GET: api/ToDoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetToDoItem()
        {
            return await _toDoItems.GetAllAsync();
        }

        // PUT: api/ToDoItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDoItem(int id, ToDoItem toDoItem)
        {
            if (id != toDoItem.Id)
            {
                return BadRequest();
            }

            await _toDoItems.UpdateAsync(toDoItem);

            return NoContent();
        }

        // POST: api/ToDoItems
        [HttpPost]
        public async Task<ActionResult<ToDoItem>> PostToDoItem(ToDoItem toDoItem)
        {
            await _toDoItems.AddAsync(toDoItem);

            return CreatedAtAction("GetToDoItem", new { id = toDoItem.Id }, toDoItem);
        }

        #region problematic stuff here 😉
        [HttpGet("problematic")]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetToDoItemProblematic()
        {
            var rnd = new Random(DateTime.Now.Millisecond);

            if (rnd.Next(0, 9) < 7)
                throw new Exception();

            return await _toDoItems.GetAllAsync();
        }
        #endregion
    }
}
