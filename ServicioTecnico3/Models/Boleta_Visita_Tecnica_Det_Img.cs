//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServicioTecnico3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Boleta_Visita_Tecnica_Det_Img
    {
        public int id { get; set; }
        public Nullable<int> correlativo { get; set; }
        public Nullable<int> idDet { get; set; }
        public string servidor { get; set; }
        public string nombreArchivo { get; set; }
        public string extensionArchivo { get; set; }
        public string comentario { get; set; }
        public Nullable<int> firma { get; set; }
        public Nullable<System.DateTime> fecCrea { get; set; }
        public Nullable<int> usuCrea { get; set; }
        public Nullable<System.DateTime> fecMod { get; set; }
        public Nullable<int> usuMod { get; set; }
    }
}
