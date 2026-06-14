using System.ComponentModel.DataAnnotations;

namespace apiaulasindb.Entidades
{
    public class Administrador
    {
        [Key] // Esto le dice obligatoriamente a SQL que este es el ID primario
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string UsuarioAdmin { get; set; } = string.Empty;
    }
}