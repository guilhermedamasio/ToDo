using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.Data;
using ToDo.Models;

namespace ToDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly ApiDbContext _context;
        public ToDoController(ApiDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IEnumerable<Tarefa>>> GetTarefas() 
        {
            return await _context.Tarefas.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public IActionResult Get2(int id, int id2)
        {

            return Ok(new Tarefa { Id = id, Nome = "" });
        }

        [HttpPost]
        public IActionResult Post(Tarefa tarefa)
        {
            return CreatedAtAction("Get", new { id = tarefa.Id }, tarefa);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Tarefa tarefa) 
        {
            if (id != tarefa.Id)
            {
                return BadRequest();
            }
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
