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
    [HttpGet] // GET Completo.
    public async Task<ActionResult<IEnumerable<Tarefa>>> GetTarefas()
    {
        var tarefas = await _context.Tarefas.ToListAsync();
        return Ok(tarefas);
    }

    [HttpGet("{id:int}")] // GET id único.

    public async Task<ActionResult<Tarefa>> GetTarefa(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);

            if (tarefa == null)
            {
                return NotFound("Tarefa não encontrada.");
            }
            return Ok(tarefa);
       }
    [HttpPost] // Adicionar nova tarefa.
    public async Task<IActionResult> Add(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
            return Ok(tarefa);

        }
    }
} 