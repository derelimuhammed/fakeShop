using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceProject.Domain.Ultilities.Results;
using MediatR;

namespace ECommerceProject.Application.Features.Commands.ProductCom.UpdateProduct
{
    public class UpdateProductCommandRequest : IRequest<Result>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
    }
}
