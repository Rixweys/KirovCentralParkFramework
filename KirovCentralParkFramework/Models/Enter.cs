//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KirovCentralParkFramework.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Enter
    {
        public int ID { get; set; }
        public System.DateTime LastEnter { get; set; }
        public bool TypeOfEnter { get; set; }
        public string CodeEmployee { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
