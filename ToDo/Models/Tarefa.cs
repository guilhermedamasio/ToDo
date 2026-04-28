using System.ComponentModel.DataAnnotations;

namespace ToDo.Models
{
    public class Tarefa

    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da tarefa é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O nome da tarefa não pode exceder 50 caracteres.")]
        public string? Nome { get; set; }


        [Required(ErrorMessage = "A descrição da tarefa é obrigatória.")]
        [MaxLength(50, ErrorMessage = "A descrição da tarefa não pode exceder 50 caracteres.")]
        public string? Descricao { get; set; }

    }
}
