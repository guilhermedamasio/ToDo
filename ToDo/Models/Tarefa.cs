using System.ComponentModel.DataAnnotations;

namespace ToDo.Models
{
    public class Tarefa

    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da tarefa é obrigatório.")]
        public string? Nome { get; set; }


        [Required(ErrorMessage = "A descrição da tarefa é obrigatória.")]
        public string? Descricao { get; set; }

    }
}
