//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RecursosHumanosF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Permiso
    {
        public int ID { get; set; }
        [Required]
        public string Empleado { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Desde { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Hasta { get; set; }
        [Required]
        public string Comentarios { get; set; }
    }
}
