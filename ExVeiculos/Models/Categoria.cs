namespace ExVeiculos.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string? Designacao { get; set; }

        // Navigation property
        public virtual ICollection<Veiculo>? Veiculos { get; set; }
    }
}
