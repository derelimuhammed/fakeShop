using ECommerceProject.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.Domain.Concrete
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        //public ICollection<Order> Orders { get; set; }
    }
}
