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
    
    public partial class Uchebnii_plan
    {
        public int N_plana { get; set; }
        public int N_group { get; set; }
        public string Naimenovanie { get; set; }
        public int Tab_nomer { get; set; }
        public string Familia { get; set; }
        public int Semestr { get; set; }
        public Nullable<int> ID_Disciplini { get; set; }
        public Nullable<int> ID_prepoda { get; set; }
        public int ID { get; set; }
    
        public virtual Disciplini Disciplini { get; set; }
        public virtual Prepodavateli Prepodavateli { get; set; }
    }
}
