using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TaskManagerSystem.Context;
using TaskManagerSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskManagerSystem.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class TarefaController : ControllerBase
	{
		private readonly AgendaContext _context;

		public TarefaController(AgendaContext context)
		{
			_context = context;
		}

		[HttpGet("ObterTodos")]
		public async Task<IActionResult> ObterTodos()
		{
			var tarefas = await _context.Tarefas.ToListAsync();
			if (tarefas.Count == 0)
			{
				return NoContent();
			}
			return Ok(tarefas);
		}

		[HttpGet("ObterPorTitulo")]
		public async Task<IActionResult> ObterTarefaPorTitulo(string titulo)
		{
			List<Tarefa> tarefas = await _context.Tarefas.Where(t => t.Titulo.Contains(titulo)).ToListAsync();

			if (tarefas.Count == 0)
			{
				return NoContent();
			}
			return Ok(tarefas);
		}

		[HttpGet("ObterPorData")]
		public async Task<IActionResult> ObterPorData(DateTime data)
		{
			List<Tarefa> Tarefas = await _context.Tarefas.Where(t => t.Data == data).ToListAsync();
			if (Tarefas.Count == 0)
			{
				return NoContent();
			}
			return Ok(Tarefas);
		}

		[HttpGet("ObterPorStatus")]
		public async Task<IActionResult> ObterPorStatus(StatusTarefa status)
		{
			List<Tarefa> Tarefas = await _context.Tarefas.Where(t => t.Status == status).ToListAsync();
			if (Tarefas.Count == 0)
			{
				return NoContent();
			}
			return Ok(Tarefas);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> ObterTarefaPorId(int id)
		{
			Tarefa tarefa = await _context.Tarefas.FindAsync(id) ?? null!;
			if (tarefa == null)
			{
				return NotFound("Tarefa não encontrada");
			}
			return Ok(tarefa);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> AtualizarTarefa(int id, Tarefa tarefa)
		{
			Tarefa tarefaDB = await _context.Tarefas.FindAsync(id) ?? null!;
			if (tarefaDB == null)
			{
				return NotFound("Tarefa não encontrada");
			}
			tarefaDB.Titulo = tarefa.Titulo;
			tarefaDB.Descricao = tarefa.Descricao;
			tarefaDB.Status = tarefa.Status;
			_context.Update(tarefaDB);
			await _context.SaveChangesAsync();
			return Ok(tarefaDB);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletarTarefa(int id)
		{
			Tarefa tarefa = await _context.Tarefas.FindAsync(id) ?? null!;
			if (tarefa == null)
			{
				return NotFound("Tarefa não encontrada");
			}
			_context.Remove(tarefa);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		[HttpPost]
		public async Task<IActionResult> CriarTarefa(Tarefa tarefa)
		{
			await _context.AddAsync(tarefa);
			await _context.SaveChangesAsync();
			return CreatedAtAction(nameof(ObterTarefaPorId), new { id = tarefa.Id }, tarefa);
		}
	}
}