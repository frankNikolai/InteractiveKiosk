//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InteractiveKiosk
{
    using System;
    using System.Collections.Generic;
    
    public partial class Attraction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Attraction()
        {
            this.Basket_Attraction = new HashSet<Basket_Attraction>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public int Description_ID { get; set; }
        public decimal Cost { get; set; }
        public string Clossed_Open { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Basket_Attraction> Basket_Attraction { get; set; }
        public virtual Descriptions Descriptions { get; set; }
    }
}