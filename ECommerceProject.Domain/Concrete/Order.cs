using ECommerceProject.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.Domain.Concrete
{
    public class Order : BaseEntity
    {
        //public Guid CustomerId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        public string OrderCode { get; set; }

        public Basket Basket { get; set; }
        //public ICollection<Product> Products { get; set; }
        //public Customer Customer { get; set; }
        public CompletedOrder CompletedOrder { get; set; }
    }
}
