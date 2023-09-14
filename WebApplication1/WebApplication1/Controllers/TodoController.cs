using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private static List<TodoItem> _todos = new List<TodoItem>();
        private static int _nextId = 1; // Keep track of the next available ID

        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> Get()
        {
            return _todos;
        }

        [HttpPost]
        public ActionResult<TodoItem> Post(TodoItem todo)
        {
            todo.Id = _nextId; // Assign the next available ID
            _todos.Add(todo);
            _nextId++; // Increment the next available ID
            return CreatedAtAction(nameof(Get), new { id = todo.Id }, todo);
        }
    }
}
