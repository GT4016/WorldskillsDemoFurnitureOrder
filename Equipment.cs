//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Worldskills
{
    using System;
    using System.Collections.Generic;
    
    public partial class Equipment
    {
        public string Marking { get; set; }
        public string Type { get; set; }
        public string Characteristic { get; set; }
    
        public virtual Equipment_type Equipment_type { get; set; }
    }
}