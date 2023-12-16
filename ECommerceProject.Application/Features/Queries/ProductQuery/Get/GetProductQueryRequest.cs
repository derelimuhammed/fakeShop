using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceProject.Domain.Ultilities.Results;
using MediatR;

namespace ECommerceProject.Application.Features.Queries.ProductQuery.Get
{
    public class GetProductQueryRequest :IRequest<IRequest>, IRequest<Result>
    {
        public Guid Id { get; set; }
    }
}
