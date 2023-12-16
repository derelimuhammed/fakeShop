using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceProject.Application.Features.Commands.ProductCom.DeleteProduct;
using FluentValidation;

namespace ECommerceProject.Application.Validators.FluentValidators.ProductValidators
{
    public class DeleteProductCommandRequestValidator : AbstractValidator<DeleteProductCommandRequest>
    {
        public DeleteProductCommandRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        }
    }
}
