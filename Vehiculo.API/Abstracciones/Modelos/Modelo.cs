using System.ComponentModel.DataAnnotations;
using System.Threading.Channels;

namespace Abstracciones.Modelos
{
    public class ModeloBase
    {
        public string Nombre { get; set; }
    }

    public class ModeloRequest : ModeloBase
    {
        public Guid IdMarca { get; set; }
    }

    public class ModeloResponse : ModeloBase
    {
        public Guid Id { get; set; }
        public Guid IdMarca { get; set; }
        public string NombreMarca { get; set; }
    }
}