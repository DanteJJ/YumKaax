using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YumKaax.Models
{
    public class OfertasCLS
    {
        public int idOfertas { get; set; }
        public string TituloOfertas { get; set; }
        public sbyte EstadoOfertas { get; set; }
        public string DescripcionOfertas { get; set; }
        public byte[] ImagenOfertas { get; set; }
        public int PrecioOfertas { get; set; }
        public int ExistenciaOfertas { get; set; }
        public int IdUsuarioOferta { get; set; }

        public UsuariosCLS usuarios { get; set; }
    }
}