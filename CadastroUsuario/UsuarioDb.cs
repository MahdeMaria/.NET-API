using Microsoft.EntityFrameworkCore;

class UsuarioDb : DbContext
{
    public UsuarioDb(DbContextOptions<UsuarioDb> options)
        : base(option) { }

    public DbSet<Usuarios> Usuarios {get; set;}
}