using System.ComponentModel.DataAnnotations;

namespace apiaulasindb.Entidades
{
    public class Horario
    {
        [Key] // Llave primaria obligatoria
        public int Id { get; set; }
        public string DiaSemana { get; set; } = string.Empty;
        public string HoraInicio { get; set; } = string.Empty;
        public string HoraFin { get; set; } = string.Empty;
    }
}