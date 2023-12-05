using ECommerceProject.Domain.Ultilities.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.Application.Features.Commands.ProductCom.CreateProduct
{
    public class CreateProductCommandRequest : IRequest<Result>
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
    }
}
