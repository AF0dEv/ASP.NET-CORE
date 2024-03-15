namespace ExCliX.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Item1 { get; set; }
        public string? Item2 { get; set; }
        public string? Texto { get; set; }

        // Chaves Estrangeiras
        public int TipoId { get; set; }
        public int ClienteId { get; set; }
    }
}
