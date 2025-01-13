using Microsoft.EntityFrameworkCore;

class UsuarioDb : DbContext
{
    public UsuarioDb(DbContextOptions<UsuarioDb> options)
        : base(options) { }

    public DbSet<Usuario> Usuarios {get; set;}
}