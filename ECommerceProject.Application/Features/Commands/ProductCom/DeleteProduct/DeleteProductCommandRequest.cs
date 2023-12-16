using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceProject.Domain.Ultilities.Results;
using MediatR;

namespace ECommerceProject.Application.Features.Commands.ProductCom.DeleteProduct
{
    public class DeleteProductCommandRequest:IRequest<Result>
    {
        public Guid Id { get; set; }
    }
}
