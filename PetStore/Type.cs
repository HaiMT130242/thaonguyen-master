//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PetStore
{
    using System;
    using System.Collections.Generic;
    
    public partial class Type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Type()
        {
            this.Pets = new HashSet<Pet>();
            this.PetFoods = new HashSet<PetFood>();
        }
    
        public int t_id { get; set; }
        public string t_name { get; set; }
        public string t_status { get; set; }
        public Nullable<int> org_id { get; set; }
    
        public virtual Origin Origin { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pet> Pets { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PetFood> PetFoods { get; set; }
    }
}
