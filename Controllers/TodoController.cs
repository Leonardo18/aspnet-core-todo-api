using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Models.Context;

namespace TodoApi.Controllers
{
    [Route("api/todo")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;

            if (_context.Todo.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.Todo.Add(new Todo 
                                                { 
                                                    Name = "John Doe", 
                                                    Description = "My initial Task", 
                                                    Priority = 3, 
                                                    Author = "John Doe" 
                                                });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<Todo>> GetAll()
        {
            return _context.Todo.ToList();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public ActionResult<Todo> GetById(long id)
        {
            var todo = _context.Todo.Find(id);
            if (todo == null)
            {
                return NotFound();
            }
            return todo;
        }

        [HttpPost]
        public IActionResult Create(Todo todo)
        {
            _context.Todo.Add(todo);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = todo.Id }, todo);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, Todo updatedTodo)
        {
            var todo = _context.Todo.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Name = updatedTodo.Name;
            todo.Description = updatedTodo.Description;
            todo.Priority = updatedTodo.Priority;
            todo.Author = updatedTodo.Author;

            _context.Todo.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.Todo.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Todo.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}