using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Flujo;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloController : ControllerBase, IModeloController
    {
        private IModeloFlujo _modeloFLujo;
        private ILogger<ModeloController> _logger;

        #region Operaciones
        public ModeloController(IModeloFlujo modeloFLujo, ILogger<ModeloController> logger)
        {
            _modeloFLujo = modeloFLujo;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var result = await _modeloFLujo.Obtener();
            if (!result.Any())
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpGet("porModelo/{Id}")]
        public async Task<IActionResult> Obtener([FromRoute] Guid Id)
        {
            var result = await _modeloFLujo.Obtener(Id);
            return Ok(result);
        }

        [HttpGet("{IdMarca}")]
        public async Task<IActionResult> ObtenerPorMarca([FromRoute] Guid IdMarca)
        {
            var result = await _modeloFLujo.ObtenerPorMarca(IdMarca);
            if (!result.Any())
            {
                return NoContent();
            }
            return Ok(result);
        }
        #endregion Operaciones

        #region Helpers
        private async Task<bool> VerificarModeloExiste(Guid Id)
        {
            var resultadoValidacion = false;
            var resultadoModeloExiste = await _modeloFLujo.Obtener(Id);
            if (resultadoModeloExiste != null)
                resultadoValidacion = true;
            return resultadoValidacion;
        }
        #endregion Helpers
    }
}