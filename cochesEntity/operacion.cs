//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace cochesEntity
{
    using System;
    using System.Collections.Generic;
    
    public partial class operacion
    {
        public int id { get; set; }
        public bool tipo { get; set; }
        public Nullable<int> idEmpleado { get; set; }
        public Nullable<int> idCliente { get; set; }
        public Nullable<double> precio { get; set; }
    
        public virtual clientes clientes { get; set; }
        public virtual empleados empleados { get; set; }
    }
}
