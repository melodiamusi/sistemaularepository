namespace apiaulasindb.Entidades
{
    public class Reserva
    {
        public int Id { get; set; }
        public int AulaId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
    }
}