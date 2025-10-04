using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
public class Curso
{
    public int Id { get; set; }

    [Required, MaxLength(20)]
    public required string Codigo { get; set; }

    [Required, MaxLength(100)]
    public required string Nombre { get; set; }

    [Range(1, 10)]
    public int Creditos { get; set; }

    [Range(1, 100)]
    public int CupoMaximo { get; set; }

    [DataType(DataType.Time)]
    public TimeSpan HorarioInicio { get; set; }

    [DataType(DataType.Time)]
    public TimeSpan HorarioFin { get; set; }

    public bool Activo { get; set; } = true;

    // Navigation
    public required ICollection<Matricula> Matriculas { get; set; }
}
