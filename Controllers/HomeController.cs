using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers
{
    [ApiController] //informa que só retornar JSON
    public class HomeController : ControllerBase
    {
        protected Context _context;
        public HomeController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/")]
        public IActionResult Get()
        => Ok(_context.Todos.ToList());

        [HttpGet("/{id}")]
        public IActionResult GetById(int id)
        {
            var todos = _context.Todos.FirstOrDefault(x => x.Id == id);
            if (todos == null)
                return NotFound();
            return Ok(todos);
        }

        [HttpPost("/")]
        public IActionResult Post(TodoModel model)
        {
            _context.Todos.Add(model);
            _context.SaveChanges();
            return Created($"/{model.Id}", model);
        }

        [HttpPut("/{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] TodoModel model)
        {
            var models = _context.Todos.FirstOrDefault(x => x.Id == id);
            if (models == null) return NotFound();

            models.Title = model.Title;
            models.Done = model.Done;
            _context.Todos.Update(models);
            _context.SaveChanges();
            return Ok(models);
        }

        [HttpDelete("/{id}")]
        public IActionResult Delete(int id)
        {
            var models = _context.Todos.FirstOrDefault(x => x.Id == id);
            _context.Todos.Remove(models);
            if (models == null) return NotFound();
            _context.SaveChanges();
            return Ok(models);
        }
    }
}