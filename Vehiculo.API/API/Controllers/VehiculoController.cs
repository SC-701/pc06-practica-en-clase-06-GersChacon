using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Flujo;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase, IVehiculoController
    {
        private IVehiculoFlujo _vehiculoFLujo;
        private ILogger<VehiculoController> _logger;

        #region Operaciones
        public VehiculoController(IVehiculoFlujo vehiculoFLujo, ILogger<VehiculoController> logger)
        {
            _vehiculoFLujo = vehiculoFLujo;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] VehiculoRequest vehiculo)
        {
            var result = await _vehiculoFLujo.Agregar(vehiculo);
            return CreatedAtAction(nameof(Obtener), new { Id = result }, null);
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Editar([FromRoute] Guid Id,[FromBody] VehiculoRequest vehiculo)
        {
            if (!await VerificarVehiculoExiste(Id))
                return NotFound("El vehículo no existe");
            var result = await _vehiculoFLujo.Editar(Id, vehiculo);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Eliminar([FromRoute] Guid Id)
        {
            if (!await VerificarVehiculoExiste(Id))
                return NotFound("El vehículo no existe");
            var result = await _vehiculoFLujo.Eliminar(Id);
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var result = await _vehiculoFLujo.Obtener();
            if (!result.Any())
            {
                return NoContent();
            }
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> Obtener([FromRoute] Guid Id)
        {
            var result = await _vehiculoFLujo.Obtener(Id);
            return Ok(result);
        }
        #endregion Operaciones

        #region Helpers
        private async Task<bool> VerificarVehiculoExiste(Guid Id)
        {
            var resultadoValidacion = false;
            var resultadoVehiculoExiste = await _vehiculoFLujo.Obtener(Id);
            if (resultadoVehiculoExiste != null)
                resultadoValidacion = true;
            return resultadoValidacion;
        }
        #endregion Helpers

    }
}
