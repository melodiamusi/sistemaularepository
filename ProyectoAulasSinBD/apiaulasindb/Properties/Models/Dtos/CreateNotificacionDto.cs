namespace apiaulasindb.Models.Dtos
{
    public class CreateNotificacionDto
    {
        public int UsuarioId { get; set; }
        public string Mensaje { get; set; } = string.Empty;
    }
}
