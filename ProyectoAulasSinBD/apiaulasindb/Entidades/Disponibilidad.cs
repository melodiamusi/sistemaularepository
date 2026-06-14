using System.ComponentModel.DataAnnotations;

namespace apiaulasindb.Entidades
{
    public class Disponibilidad
    {
        [Key] // Obliga a Entity Framework a reconocer que este es el ID de la tabla
        public int Id { get; set; }
        public int AulaId { get; set; }
        public string Estado { get; set; } = string.Empty;
    }
}
