using apiaulasindb.Entidades;
using Microsoft.EntityFrameworkCore;

namespace apiaulasindb.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Aulas> Aulas { get; set; }

        // El tipo es <Usuario> (singular) y la propiedad es Usuarios (plural)
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Disponibilidad> Disponibilidades { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        // CORREGIDO: Con su tipo correcto, espacio y punto y coma al final
        public DbSet<Notificación> Notificaciones { get; set; }
    }
}