using System.ComponentModel.DataAnnotations;
using System.Threading.Channels;

namespace Abstracciones.Modelos
{
    public class MarcaBase
    {
        public string Nombre { get; set; }

    }

    public class MarcaRequest : MarcaBase
    {
        public Guid IdModelo { get; set; }
    }


    public class MarcaResponse : MarcaBase
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
    }

}
