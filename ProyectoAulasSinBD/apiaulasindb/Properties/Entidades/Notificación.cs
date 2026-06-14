namespace apiaulasindb.Entidades
{
    public class Notificación
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Mensaje { get; set; } = string.Empty;
    }
}
