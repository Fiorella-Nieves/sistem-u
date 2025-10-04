using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sis.U_firme.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Curso> Cursos { get; set; }
}

public static class DataInitializer

{
    public static async Task InitializeAsync(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        // Crear roles
        await roleManager.CreateAsync(new IdentityRole("Coordinador"));

        // Crear usuario coordinador
        var coordinador = new IdentityUser
        {

            UserName = "coordinador@universidad.edu",
            Email = "coordinador@universidad.edu"
        };

        var result = await userManager.CreateAsync(coordinador, "Coordinador123!");
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(coordinador, "Coordinador");
        }

        if (!context.Cursos.Any())
        {
            var cursos = new[]
            {
                new Curso
                {
                    Codigo = "MAT101",
                    Nombre = "Matemáticas Básicas",
                    Creditos = 4,
                    CupoMaximo = 30,
                    HorarioInicio = new TimeSpan(8, 0, 0),
                    HorarioFin = new TimeSpan(10, 0, 0),
                    Activo = true,
                    Matriculas = new List<Matricula>()
                },
                new Curso
                {
                    Codigo = "PROG201",
                    Nombre = "Programación I",
                    Creditos = 5,
                    CupoMaximo = 25,
                    HorarioInicio = new TimeSpan(10, 30, 0),
                    HorarioFin = new TimeSpan(12, 30, 0),
                    Activo = true,
                    Matriculas = new List<Matricula>()
                },
                new Curso
                {
                    Codigo = "FIS301",
                    Nombre = "Física General",
                    Creditos = 4,
                    CupoMaximo = 35,
                    HorarioInicio = new TimeSpan(14, 0, 0),
                    HorarioFin = new TimeSpan(16, 0, 0),
                    Activo = true,
                    Matriculas = new List<Matricula>()
                }
            };

            await context.Cursos.AddRangeAsync(cursos);
            await context.SaveChangesAsync();
        }
    }
}