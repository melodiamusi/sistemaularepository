namespace apiaulasindb.Models.Dtos
{
    public class DisponibilidadDto
    {
        public int Id { get; set; }
        public int AulaId { get; set; }
        public string Estado { get; set; } = string.Empty;
    }
}