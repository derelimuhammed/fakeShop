using ECommerceProject.Application.Features.Commands.ProductCom.CreateProduct;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.Application.FluentValidators.ProductValidators
{
    public class CreateProductCommandRequestValidator : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductCommandRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        }
    }
}
