namespace apiaulasindb.Models.Dtos
{
    public class ReservaDto
    {
        public int Id { get; set; }
        public int AulaId { get; set; }
        public int UsuarioId { get; set; }
        public string Fecha { get; set; } = string.Empty;
    }
}