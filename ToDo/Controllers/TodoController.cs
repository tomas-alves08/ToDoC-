using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using ToDo.Data;
using ToDo.Models;
using ToDo.Models.DTO;

namespace ToDo.Controllers
{
    [Route("api/TodoApi")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public TodoController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TodoDTO>> GetTodos()
        {
            return Ok(_db.Todos.ToList());
        }

        [HttpGet("id", Name = "GetTodo")]
        public ActionResult<TodoDTO> GetTodo(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }

            var Todo = _db.Todos.FirstOrDefault(Todo => Todo.Id == id);

            if(Todo == null)
            {
                return NotFound();
            }

            return Ok(Todo);
        }

        [HttpPost]
        public ActionResult<TodoCreateDTO> CreateTodo([FromBody] TodoCreateDTO todoDTO)
        {
            if (todoDTO == null)
            {
                return BadRequest(todoDTO);
            }

            if (_db.Todos.FirstOrDefault(todo => todo.Item.ToLower() == todoDTO.Item.ToLower()) != null)
            {
                ModelState.AddModelError("CustomerError", "Todo already exists");
                return BadRequest(ModelState);
            }

            Todo model = new()
            {
                Item = todoDTO.Item,
                Description = todoDTO.Description,
                DueDate = todoDTO.DueDate
            };

            _db.Todos.Add(model);
            _db.SaveChanges();

            return CreatedAtRoute("GetTodo", todoDTO);
        }

        [HttpDelete("id")]
        public IActionResult DeleteTodo(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }

            var todo = _db.Todos.FirstOrDefault(todo => todo.Id == id);

            if(todo == null)
            {
                return NotFound();
            }

            _db.Todos.Remove(todo);
            _db.SaveChanges();

            return NoContent();
        }

        [HttpPut("id:int")]
        public IActionResult UpdateTodo(int id, [FromBody]TodoUpdateDTO todoDTO)
        {
            if(todoDTO == null || id != todoDTO.Id || id == 0)
            {
                return BadRequest();
            }

            Todo model = new()
            {
                Id = todoDTO.Id,
                Item = todoDTO.Item,
                Description = todoDTO.Description,
                DueDate = todoDTO.DueDate
            };

            _db.Todos.Update(model);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
