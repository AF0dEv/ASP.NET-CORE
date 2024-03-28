namespace ProjAfonsoProd.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        // Navigation properties
        public virtual ICollection<Reuniao>? Reunioes { get; set; }
    }
}
