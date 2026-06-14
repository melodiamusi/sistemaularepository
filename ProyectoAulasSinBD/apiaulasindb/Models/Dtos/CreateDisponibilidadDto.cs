namespace apiaulasindb.Models.Dtos
{
    public class CreateDisponibilidadDto
    {
        public int AulaId { get; set; }
        public string Estado { get; set; } = string.Empty;
    }
}