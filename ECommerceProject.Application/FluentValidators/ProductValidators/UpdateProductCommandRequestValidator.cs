using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceProject.Application.Features.Commands.ProductCom.UpdateProduct;
using FluentValidation;

namespace ECommerceProject.Application.FluentValidators.ProductValidators
{
    public class UpdateProductCommandRequestValidator:AbstractValidator<UpdateProductCommandRequest>
    {
        public UpdateProductCommandRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        }
    }
}
