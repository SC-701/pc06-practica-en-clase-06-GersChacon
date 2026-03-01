using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.DA
{
    public interface IMarcaDA
    {
        Task<IEnumerable<MarcaResponse>> Obtener();
        Task<MarcaResponse> Obtener(Guid Id);

    }
}
