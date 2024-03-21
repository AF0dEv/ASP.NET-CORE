namespace ExCliX.Models
{
    public class ClientesTiposItems
    {
        public IEnumerable<Cliente>? Clientes { get; set; }
        public IEnumerable<Tipo>?  Tipos { get; set; }
        public IEnumerable<Item>?  Items { get; set; }
    }
}
