using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Flujo;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase, IMarcaController
    {
        private IMarcaFlujo _marcaFLujo;
        private ILogger<MarcaController> _logger;

        #region Operaciones
        public MarcaController(IMarcaFlujo marcaFLujo, ILogger<MarcaController> logger)
        {
            _marcaFLujo = marcaFLujo;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var result = await _marcaFLujo.Obtener();
            if (!result.Any())
            {
                return NoContent();
            }
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> Obtener([FromRoute] Guid Id)
        {
            var result = await _marcaFLujo.Obtener(Id);
            return Ok(result);
        }
        #endregion Operaciones

        #region Helpers
        private async Task<bool> VerificarMarcaExiste(Guid Id)
        {
            var resultadoValidacion = false;
            var resultadoMarcaExiste = await _marcaFLujo.Obtener(Id);
            if (resultadoMarcaExiste != null)
                resultadoValidacion = true;
            return resultadoValidacion;
        }
        #endregion Helpers

    }
}
