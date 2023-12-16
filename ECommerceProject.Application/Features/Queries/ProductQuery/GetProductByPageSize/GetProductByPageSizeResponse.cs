using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceProject.Application.DTOs;
using ECommerceProject.Domain.Concrete;

namespace ECommerceProject.Application.Features.Queries.ProductQuery.GetProductByPageSize
{
    public class GetProductByPageSizeResponse
    {
       
        public int TotalProductCount { get; set; }
        public List<GetProductByPageSizeDto>? Products { get; set; }
        public GetProductByPageSizeResponse(int totalProductCount, List<GetProductByPageSizeDto>? product )
        {
            TotalProductCount = totalProductCount;
            Products = product;
        }
    }
}
