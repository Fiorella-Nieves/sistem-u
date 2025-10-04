using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sis.U_firme.Models;

namespace Sis.U_firme.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    [Obsolete]
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member
    protected override void OnModelCreating(ModelBuilder builder)
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member
    {
        base.OnModelCreating(builder);

        builder.Entity<Curso>()
            .HasIndex(c => c.Codigo)
            .IsUnique();

        builder.Entity<Matricula>()
            .HasIndex(m => new { m.CursoId, m.UsuarioId })
            .IsUnique();

        builder.Entity<Curso>()
            .HasCheckConstraint("CK_Curso_Horario", "HorarioInicio < HorarioFin");
    }
}
