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
    
    public partial class Ekzamen
    {
        public int ID { get; set; }
        public int nomer_ekzamena { get; set; }
        public System.DateTime data_ekzamena { get; set; }
        public int N_zach_knigi { get; set; }
        public string Naimenovanie { get; set; }
        public Nullable<int> ID_Disciplini { get; set; }
        public Nullable<int> ID_studenta { get; set; }
        public int Ocenka { get; set; }
    
        public virtual Disciplini Disciplini { get; set; }
        public virtual Studenti Studenti { get; set; }
    }
}
