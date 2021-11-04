using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YumKaax.Models
{
    public class Images_SolicitudCLS
    {
        public int idImages_Solicitud { get; set; }
        public int idSol_Img_Sol { get; set; }
        public byte[] ImagenImg_Sol { get; set; }
        
    }
}