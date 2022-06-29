//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LiteratureWritten.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class SubscribedEditions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SubscribedEditions()
        {
            this.EditionReceiving = new HashSet<EditionReceiving>();
        }
    
        public int ID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> Edition { get; set; }
        public Nullable<int> SubscriptionTerm { get; set; }
        public Nullable<int> DeliveryMethod { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<bool> Status { get; set; }
    
        public virtual DeliveryMethod DeliveryMethod1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EditionReceiving> EditionReceiving { get; set; }
        public virtual Editions Editions { get; set; }
        public virtual SubscriptionTerm SubscriptionTerm1 { get; set; }
        public virtual Users Users { get; set; }
    }
}