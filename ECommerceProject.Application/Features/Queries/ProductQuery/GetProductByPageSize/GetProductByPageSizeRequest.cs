using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceProject.Domain.Ultilities.Results;
using MediatR;

namespace ECommerceProject.Application.Features.Queries.ProductQuery.GetProductByPageSize
{
    public class GetProductByPageSizeRequest: IRequest<Result>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
