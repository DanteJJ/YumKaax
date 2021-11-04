using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YumKaax.Models
{
    public class SolicitudCLS
    {
        public int idSolicitud { get; set; }
        public string TituloSolicitud { get; set; }
        public int EstadoSolicitud { get; set; }
        public string DescripcionSolicitud { get; set; }
        public byte[] ImagenSolicitud { get; set; }
        public int IdUsuario { get; set; }
        public List<int> TipoPlanta { get; set; }
        public List<HttpPostedFileBase> Imagen { get; set; }
        public Cat_EstadoSolCLS Cat_estadosol { get; set; }
        public UsuariosCLS Usuarios { get; set; }
        public List<Images_SolicitudCLS> Images_Solicitud_cl { get; set; }
        
    }
    public class TipoPlantaCLS
    {
        public int IdTipoPlanta { get; set; }
        public string Descripcion { get; set; }
    }

}