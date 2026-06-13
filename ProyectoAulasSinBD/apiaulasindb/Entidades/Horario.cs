namespace apiaulasindb.Entidades
{
    public class Horario
    {
        public int Id { get; set; }
        public string Dia { get; set; } // Ejemplo: "Lunes"
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
    }
}