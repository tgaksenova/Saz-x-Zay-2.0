//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sazay
{
    using System;
    using System.Collections.Generic;
    
    public partial class Disciplini
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Disciplini()
        {
            this.Ekzamen = new HashSet<Ekzamen>();
            this.Uchebnii_plan = new HashSet<Uchebnii_plan>();
        }
    
        public string Naimenovanie { get; set; }
        public int chasi_obucheni9 { get; set; }
        public int ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ekzamen> Ekzamen { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Uchebnii_plan> Uchebnii_plan { get; set; }
    }
}
