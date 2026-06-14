namespace apiaulasindb.Models.Dtos
{
    public class HorarioDto
    {
        public int Id { get; set; }
        public string DiaSemana { get; set; } = string.Empty;
        public string HoraInicio { get; set; } = string.Empty;
        public string HoraFin { get; set; } = string.Empty;
    }
}