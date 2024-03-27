namespace ExVeiculos.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Matricula { get; set; }
        public string Marca { get; set; }
        public int Ano { get; set; }
        // Foreign Key
        public int CategoriaId { get; set; }
        // Navigation property
        public virtual Categoria? Categoria { get; set; }
    }
}
