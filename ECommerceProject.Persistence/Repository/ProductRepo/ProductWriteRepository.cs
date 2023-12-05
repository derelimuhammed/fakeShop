using ECommerceProject.Application.Repository.Interface.ProductRepo;
using ECommerceProject.Domain.Concrete;
using ECommerceProject.Persistence.AppContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.Persistence.Repository.ProductRepo
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(ECommerceAPPIDbContext context) : base(context)
        {
        }
    }
}
