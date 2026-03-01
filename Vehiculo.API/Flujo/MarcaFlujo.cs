using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;

namespace Flujo
{

    public class MarcaFlujo : IMarcaFlujo
    {
        private readonly IMarcaDA _marcaDA;
        private readonly IRegistroReglas _registroReglas;
        private readonly IRevisionReglas _revisionReglas;

        public MarcaFlujo(IMarcaDA marcaDA, IRegistroReglas registroReglas, 
            IRevisionReglas revisionReglas)
        {
            _marcaDA = marcaDA;
            _registroReglas = registroReglas;
            _revisionReglas = revisionReglas;
        }

        public async Task<IEnumerable<MarcaResponse>> Obtener()
        {
            return await _marcaDA.Obtener();
        }

        public Task<MarcaResponse> Obtener(Guid Id)
        {
            return _marcaDA.Obtener(Id);
        }
    }
}
