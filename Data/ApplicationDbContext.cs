using Microsoft.EntityFrameworkCore;

public partial class ApplicationDbContext : DbContext
{
    // Constructor requerido para la configuración del DbContext
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // Definir las entidades que se mapearán a tablas de la base de datos
    public virtual DbSet<User> Users { get; set; } = null!;

    // Configuración personalizada de las entidades
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.id); // Clave primaria
            entity.Property(e => e.nombre)
                .IsRequired()
                .HasMaxLength(100); // Columna nombre con longitud máxima
            entity.Property(e => e.contrasenia)
                .IsRequired()
                .HasMaxLength(100); // Columna contraseña con longitud máxima
        });

        base.OnModelCreating(modelBuilder); // Llamada al método base (opcional)
    }
}
