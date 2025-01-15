using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UsuarioDb>(opt => opt.UseInMemoryDatabase("UsuarioList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Cadastro de Usuário API",
        Version = "v1",
        Description = "API para gerenciar cadastro de usuários.",
    });
});

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<UsuarioDb>();
    dbContext.Database.EnsureCreated();
}

app.MapGet("/usuarios", async (UsuarioDb db) =>
    await db.Usuarios.ToListAsync())
    .WithTags("Listar usuarios");

app.MapGet("/usuarios/{id}", async (int id, UsuarioDb db) =>
    await db.Usuarios.FindAsync(id)
        is Usuario usuario
            ?   Results.Ok(usuario)
            :   Results.NotFound())
            .WithTags("Listar usuario por Id");

app.MapPost("usuarios", async (Usuario usuario, UsuarioDb db) =>
{
    db.Usuarios.Add(usuario);
    await db.SaveChangesAsync();

    return Results.Created($"/usuarios/{usuario.Id}", usuario);
})
    .WithTags("Adicionar Usuario");

app.MapPut("usuarios/{id}", async (int id, Usuario inputUsuario, UsuarioDb db) =>
{
    var usuario = await db.Usuarios.FindAsync(id);

    if(usuario is null) return Results.NotFound();

    usuario.Nome = inputUsuario.Nome;
    usuario.Idade = inputUsuario.Idade;

    await db.SaveChangesAsync();

    return Results.NoContent();
})
    .WithTags("Update usuario por Id");

app.MapDelete("/usuarios/{id}", async (int id, UsuarioDb db) =>
{
    if (await db.Usuarios.FindAsync(id) is Usuario usuario)
    {
        db.Usuarios.Remove(usuario);
        await db.SaveChangesAsync();
        return Results.Ok(usuario);
    }
        return Results.NotFound();

})
    .WithTags("Deletar usuario por Id");

app.UseSwagger();
app.UseSwaggerUI();

app.Run();