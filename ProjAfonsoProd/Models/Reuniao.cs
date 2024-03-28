namespace ProjAfonsoProd.Models
{
    public class Reuniao
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int duracao { get; set; }
        public string? Resumo { get; set; }
        // Foreign keys
        public int FuncionarioId { get; set; }
        public int ClienteId { get; set; }
        // Navigation properties
        public virtual Funcionario? Funcionario { get; set; }
        public virtual Cliente? Cliente { get; set; }
        
    }
}
