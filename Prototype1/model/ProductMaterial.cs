//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prototype1.model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductMaterial
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductMaterial()
        {
            this.ProductProduction = new HashSet<ProductProduction>();
        }
    
        public int Id { get; set; }
        public Nullable<int> ProductName { get; set; }
        public Nullable<int> MaterialName { get; set; }
    
        public virtual Material Material { get; set; }
        public virtual Product Product { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductProduction> ProductProduction { get; set; }
    }
}
