//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YumKaax.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class images_solicitud
    {
        public int idImages_Solicitud { get; set; }
        public int idSol_Img_Sol { get; set; }
        public byte[] ImagenImg_Sol { get; set; }
    
        public virtual solicitudes solicitudes { get; set; }
    }
}