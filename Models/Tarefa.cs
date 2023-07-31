using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerSystem.Models
{
	public enum StatusTarefa
	{
		Pendente,
		Finalizado
	}

	public class Tarefa
	{
		[Key]
		public int Id { get; set; }

		public string Titulo { get; set; } = null!;
		public string? Descricao { get; set; }

		[BindNever]
		public DateTime Data { get; set; } = DateTime.Now;

		public StatusTarefa Status { get; set; }
	}
}