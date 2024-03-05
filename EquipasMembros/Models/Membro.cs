namespace EquipasMembros.Models
{
    public class Membro
    {
        public int Id { get; set; }
        public string? NomeMembro { get; set; }

        //chave estrangeira:
        public int EquipaId { get; set; }


        public virtual Equipa? Equipa { get; set; }
    }
}
