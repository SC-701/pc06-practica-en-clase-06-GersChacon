using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;

namespace Flujo
{
    public class ModeloFlujo : IModeloFlujo
    {
        private readonly IModeloDA _modeloDA;
        private readonly IRegistroReglas _registroReglas;
        private readonly IRevisionReglas _revisionReglas;

        public ModeloFlujo(IModeloDA modeloDA, IRegistroReglas registroReglas,
            IRevisionReglas revisionReglas)
        {
            _modeloDA = modeloDA;
            _registroReglas = registroReglas;
            _revisionReglas = revisionReglas;
        }

        public async Task<IEnumerable<ModeloResponse>> Obtener()
        {
            return await _modeloDA.Obtener();
        }

        public Task<ModeloResponse> Obtener(Guid Id)
        {
            return _modeloDA.Obtener(Id);
        }

        public async Task<IEnumerable<ModeloResponse>> ObtenerPorMarca(Guid IdMarca)
        {

            return await _modeloDA.ObtenerPorMarca(IdMarca);
        }
    }
}