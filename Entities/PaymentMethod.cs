using SimpleStore.Entities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleStore.Entities
{
    // Requirement 3, 4.6.2, 5
    // Extended by the other 2 specific payment method tables
    public class PaymentMethod : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public PaymentMethodType Type { get; set; }
    }
}
