using System.ComponentModel.DataAnnotations;

namespace ExCliX.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Display(Name = "Nome Cliente (Obrigatório, máx: 100 carateres)")]
        [Required(ErrorMessage = "O nome do cliente é obrigatório")]
        [StringLength(100, ErrorMessage = "O Nome do Cliente não pode ter mais de 100 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Referência Cliente (Máx: 100 carateres)")]
        [StringLength(100, ErrorMessage = "A Referência do Cliente não pode ter mais de 100 caracteres")]
        public string? Referencia { get; set; }
    }
}
