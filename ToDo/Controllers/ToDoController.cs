using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.Data;
using ToDo.Models;
using Microsoft.AspNetCore.Http;

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
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
    public async Task<IActionResult> PostTarefa(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
            return Ok(tarefa);

        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateTarefa(int id, [FromBody]Tarefa tarefaAtualizada)
        {

            var tarefaExistente = await _context.Tarefas.FindAsync(id);

            if (tarefaExistente == null)
            {
                return NotFound("Tarefa não encontrada.");
            }
            _context.Entry(tarefaExistente).CurrentValues.SetValues(tarefaAtualizada);
            await _context.SaveChangesAsync();
            return StatusCode(201, tarefaExistente);
        }
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteTarefa(int id)
        {

            var tarefa = await _context.Tarefas.FindAsync(id);

            if (tarefa == null)
            {
                return NotFound("Tarefa não encontrada.");
            }
            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
            return Ok("Tarefa deletada com sucesso!");
        }
    }
} 