using System.ComponentModel.DataAnnotations;

namespace apiaulasindb.Entidades
{
    public class Reserva
    {
        [Key] // Llave primaria obligatoria
        public int Id { get; set; }
        public int AulaId { get; set; }
        public int UsuarioId { get; set; }
        public string Fecha { get; set; } = string.Empty;
    }
}
