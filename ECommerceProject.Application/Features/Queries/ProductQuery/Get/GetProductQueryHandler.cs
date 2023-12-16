using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceProject.Domain.Ultilities.Results;
using MediatR;

namespace ECommerceProject.Application.Features.Queries.ProductQuery.Get
{
    internal class GetProductQueryHandler:IRequestHandler<GetProductQueryRequest,Result>
    {
        public Task<Result> Handle(GetProductQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
