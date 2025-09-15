using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gestion_de_pacientes.Models;

public partial class Paciente
{
    public int PacientesId { get; set; }

    [Required(ErrorMessage = "El tipo de documento es requerido")]
    [StringLength(20)]
    public string TipoDocumento { get; set; } = null!;

    [Required(ErrorMessage = "El numero de documento es requerido")]
    [StringLength(50)]
    public string NumeroDocumento { get; set; } = null!;

    [Required(ErrorMessage = "El nombre  es requerido")]
    [StringLength(150)]
    public string NombreCompleto { get; set; } = null!;

    [Required(ErrorMessage = "la fecha de nacimiento  es requerida")]
    public DateOnly FechaNacimiento { get; set; }

    [Required(ErrorMessage = "El correo electronico es requerido")]
    [EmailAddress(ErrorMessage ="formato de correo invalido")]
    public string CorreoElectronico { get; set; } = null!;

    [Required(ErrorMessage = "El genero es requerido")]
    public string Genero { get; set; } = null!;

    public string? Direccion { get; set; }

    [Phone(ErrorMessage ="formato de telefono invalido")]
    public string? Telefono { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaRegistro { get; set; }
}
