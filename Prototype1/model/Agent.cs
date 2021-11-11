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
    
    public partial class Agent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Agent()
        {
            this.PriorityChangeHistory = new HashSet<PriorityChangeHistory>();
        }
    
        public int Id { get; set; }
        public string AgentCompanyName { get; set; }
        public Nullable<int> AgentType { get; set; }
        public string AgentAddress { get; set; }
        public string AgentInn { get; set; }
        public string AgentKpp { get; set; }
        public string AgentDirectorName { get; set; }
        public string AgentPhoneNumber { get; set; }
        public byte[] AgentLogo { get; set; }
        public Nullable<int> AgentPriorety { get; set; }
        public Nullable<int> AgentSalePoint { get; set; }
    
        public virtual AgentType AgentType1 { get; set; }
        public virtual SalePoint SalePoint { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PriorityChangeHistory> PriorityChangeHistory { get; set; }
    }
}
