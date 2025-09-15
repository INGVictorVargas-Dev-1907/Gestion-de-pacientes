using Gestion_de_pacientes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gestion_de_pacientes.Controllers

{
    // Controlador para la gestion de pacientes de un hospital
    // permite operaciones CRUD 
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : Controller
    {
        private readonly HospitalDbContext _context;

        public HospitalController(HospitalDbContext context)
        {
            _context = context;
        }

        /// <summary>
        ///Obtener todos los pacientes
        /// </summary>
        /// <returns> Returna una lista de pacientes registrados </returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Paciente>>> GetPaciente()
        {
            var pacientes = await _context.Pacientes.ToListAsync();
            var response = new ApiResponse<IEnumerable<Paciente>>
            {
                Success = true,
                Message = "Pacientes obtenidos correctamente",
                Data = pacientes
            };

            return Ok(pacientes);
        }

        ///<summary>
        /// Obtener un paciente por ID
        /// </summary> Obtener un paciente por ID
        /// <param name="id">ID del paciente </param>
        /// <returns> Returna una lista de pacientes registrados </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Paciente>> BuscarPorId(int id)
        {
            try
            {
                var paciente = await _context.Pacientes.FindAsync(id);

                if (paciente == null)
                {
                    var responseError = new ApiResponse<Paciente>
                    {
                        Success = true,
                        Message = "Paciente no encontrado",
                        Data = null
                    };
                    return NotFound(responseError);
                }

                var response = new ApiResponse<Paciente>
                {
                    Success = true,
                    Message = "Paciente obtenido correctamente",
                    Data = paciente
                };

                return Ok(response);
            } catch (Exception ex)
            {
                var errorResponse = new ApiResponse<Paciente>
                {
                    Success = true,
                    Message = $"Error al buscar el usuario: {ex.Message}",
                    Data = null
                };

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        ///<summary>
        /// Crear un paciente.
        /// </summary>
        /// <param name="paciente">Datos del paciente</param>
        /// <returns>Paciente creado</returns>
        [HttpPost("guardar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Paciente>> CrearPaciente(Paciente paciente)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Validar el documento sea unico
            if (_context.Pacientes.Any(p => p.NumeroDocumento == paciente.NumeroDocumento))
                return BadRequest(new { message = "El numero de documento ya existe" });

            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();

            var response = new ApiResponse<Paciente>
            {
                Success = true,
                Message = "Paciente creado correctamente",
                Data = paciente
            };

            return CreatedAtAction(nameof(GetPaciente), new { id = paciente.PacientesId }, paciente);
        }

        ///<sumary>
        ///Actualizar un paciente existente
        /// </sumary>
        /// <param name="id">ID del paciente a actualizar</param>
        /// <param name="paciente">Datos del paciente</param>
        /// <returns>Resultado de la actualizacion</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ActualizarPaciente(int id, Paciente paciente)
        {
            try
            {
                var pacienteActualizado = await _context.Pacientes.FindAsync(id);
                if (pacienteActualizado == null)
                {
                    var responseError = new ApiResponse<Paciente>
                    {
                        Success = false,
                        Message = "Paciente no encontrado",
                        Data = null
                    };
                    return NotFound(responseError);
                }

                pacienteActualizado.TipoDocumento = paciente.TipoDocumento;
                pacienteActualizado.NumeroDocumento = paciente.NumeroDocumento;
                pacienteActualizado.NombreCompleto = paciente.NombreCompleto;
                pacienteActualizado.FechaNacimiento = paciente.FechaNacimiento;
                pacienteActualizado.CorreoElectronico = paciente.CorreoElectronico;
                pacienteActualizado.Direccion = paciente.Direccion;
                pacienteActualizado.Genero = paciente.Genero;
                pacienteActualizado.Telefono = paciente.Telefono;
                pacienteActualizado.Activo = paciente.Activo;

                await _context.SaveChangesAsync();

                var response = new ApiResponse<Paciente>
                {
                    Success = true,
                    Message = "Paciente actualizado exitosamente",
                    Data = pacienteActualizado
                };

                return Ok(response);
                
            } catch (Exception ex)
            {
                var responseError = new ApiResponse<Paciente>
                {
                    Success = false,
                    Message = $"Error al actualizar el paciente {ex.Message}",
                    Data = null
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }

        }

        ///<sumary>
        ///Eliminar ususario
        /// </sumary>
        /// <param name="id">ID del usuario a eliminar</param>
        /// <returns>Resultado de la eliminacion del paciente</returns>
        /// 
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<Paciente>>> EliminarUsuario(int id)
        {
            try
            {
                var paciente = await _context.Pacientes.FindAsync(id);

                if (paciente == null)
                {
                    var responseError = new ApiResponse<Paciente>
                    {
                        Success = false,
                        Message = "Paciente no encontrado",
                        Data = null
                    };
                    return NotFound(responseError);
                }

                _context.Pacientes.Remove(paciente);
                await _context.SaveChangesAsync();

                var response = new ApiResponse<Paciente>
                {
                    Success = true,
                    Message = "Paciente eliminado exitosamente",
                    Data = paciente
                };

                return Ok(response);
            } catch (Exception ex)
            {
                var responseError = new ApiResponse<Paciente>
                {
                    Success = false,
                    Message = $"Error al eliminar el paciente {ex.Message}",
                    Data = null
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

    }
}
