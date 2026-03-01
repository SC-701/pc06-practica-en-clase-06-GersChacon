using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IModeloFlujo
    {
        Task<IEnumerable<ModeloResponse>> Obtener();
        Task<ModeloResponse> Obtener(Guid Id);
        Task<IEnumerable<ModeloResponse>> ObtenerPorMarca(Guid IdMarca);
    }
}