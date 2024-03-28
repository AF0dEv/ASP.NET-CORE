namespace ProjAfonsoProd.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        // Navigation properties
        public virtual ICollection<Reuniao>? Reunioes { get; set; }
    }
}
