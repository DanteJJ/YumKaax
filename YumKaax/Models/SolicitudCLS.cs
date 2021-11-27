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
        public int[] IdTipoPlanta { get; set; }
        public float PrecioCotiza { get; set; }
        public string Comentarios { get; set; }
        public List<TipoPlanta_SolicitudCLS> DescTipoPlanta { get; set; }
        public List<TipoPlantaCLS> TipoPlanta { get; set; }
        public Cat_EstadoSolCLS Cat_estadosol { get; set; }
        public UsuariosCLS Usuarios { get; set; }
        public List<Images_SolicitudCLS> Images_Solicitud_cl { get; set; }
        public Cotizacion_SolicitudCLS Cotizacion_Solicitud { get; set; }
    }
    public class TipoPlantaCLS
    {
        public int IdTipoPlanta { get; set; }
        public string Descripcion { get; set; }
    }

    public class TipoPlanta_SolicitudCLS
    {
        public Nullable<int> IdtipoPlanta { get; set; }
        public Nullable<int> IdSolicitud { get; set; }
        public string DescTipoPlanta { get; set; }
    }

    public class Cotizacion_SolicitudCLS
    {
        public int idSolicitud_Cotizacion { get; set; }
        public string Comentarios_cotizacion { get; set; }
        public float Costo_Cotizacion { get; set; }
        public int IdSolicitud { get; set; }
        public int IdUsuarioCotiza { get; set; }

    }
}