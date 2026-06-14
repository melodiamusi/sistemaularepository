namespace apiaulasindb.Models.Dtos
{
    public class CreateReservaDto
    {
        public int AulaId { get; set; }
        public int UsuarioId { get; set; }
        public string Fecha { get; set; } = string.Empty;
    }
}