//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Session2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            this.MaterialSupplier = new HashSet<MaterialSupplier>();
        }
    
        public int idSupplier { get; set; }
        public string supplierName { get; set; }
        public int idSupplierType { get; set; }
        public string INN { get; set; }
        public int rating { get; set; }
        public System.DateTime workStartDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialSupplier> MaterialSupplier { get; set; }
        public virtual SupplierType SupplierType { get; set; }
    }
}