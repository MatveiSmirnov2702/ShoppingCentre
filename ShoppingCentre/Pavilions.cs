//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShoppingCentre
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pavilions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pavilions()
        {
            this.Arenda = new HashSet<Arenda>();
        }
    
        public int ID_Shop { get; set; }
        public string Number_Pavilion { get; set; }
        public Nullable<int> Floor { get; set; }
        public string Status { get; set; }
        public Nullable<double> Square { get; set; }
        public Nullable<decimal> PriceSquare { get; set; }
        public Nullable<double> Coefficient_Pavilion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Arenda> Arenda { get; set; }
        public virtual Shop Shop { get; set; }
    }
}