using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.DA
{
    public interface IModeloDA
    {
        Task<IEnumerable<ModeloResponse>> Obtener();
        Task<ModeloResponse> Obtener(Guid Id);
        Task<IEnumerable<ModeloResponse>> ObtenerPorMarca(Guid IdMarca);
    }
}