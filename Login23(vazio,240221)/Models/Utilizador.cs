namespace Login23.Models
{
    public class Utilizador
    {
        public int  Id { get; set; }
        public string? NomeUtilizador { get; set; }
        public string? Senha  { get; set; }
        
        //administrador? sim ou não:
        public bool Administrador { get; set; }

        //ativo ou inativo?
        public bool Estado { get; set; }

    }
}
