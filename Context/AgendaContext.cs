using Microsoft.EntityFrameworkCore;
using TaskManagerSystem.Models;

namespace TaskManagerSystem.Context
{
	public class AgendaContext : DbContext
	{
		public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
		{
		}

		public DbSet<Tarefa> Tarefas { get; set; }
	}
}