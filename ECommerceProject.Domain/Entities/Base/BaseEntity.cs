using ECommerceProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.Domain.Entities.Base
{
    public class BaseEntity
    {
        public string? UpdatedBy { get; set; }
        public virtual DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid Id { get; set; }
        public Status Status { get; set; }
    }
}
