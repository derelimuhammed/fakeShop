using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.Domain.Concrete
{
    public class ProductImageFile : Files
    {
        public bool Showcase { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
