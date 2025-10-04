using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

public class Matricula
{
    public int Id { get; set; }
    public int CursoId { get; set; }
    public required string UsuarioId { get; set; }
    
    [DataType(DataType.DateTime)]
    public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
    
    public EstadoMatricula Estado { get; set; } = EstadoMatricula.Pendiente;
    
    // Navigation
    public required Curso Curso { get; set; }
    public required ApplicationUser Usuario { get; set; }
}
public class ApplicationUser : IdentityUser
{
    
}

public enum EstadoMatricula
{
    Pendiente,
    Confirmada,
    Cancelada
}