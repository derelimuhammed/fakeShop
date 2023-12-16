using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceProject.Application.Features.Queries.ProductQuery.GetProductByPageSize;
using FluentValidation;

namespace ECommerceProject.Application.Validators.FluentValidators.ProductValidators
{
    public class GetProductByPageSizeQueryRequestValidator : AbstractValidator<GetProductByPageSizeQueryRequest>
    {
        public GetProductByPageSizeQueryRequestValidator()
        {
            RuleFor(x => x.Page + 1).GreaterThan(0).WithMessage("Sayfa numarası 0 dan büyük olmalıdır").NotEmpty().WithMessage("Sayfa sayısı boş olamaz.").Must(BeValidPageCount).WithMessage("Sayfa sayısı bir tam sayı olmalıdır.");
            RuleFor(x => x.Size).GreaterThan(0).WithMessage("Sayfa boyutu 0 dan büyük olmalıdır").NotEmpty().WithMessage("Sayfa sayısı boş olamaz.").Must(BeValidPageCount).WithMessage("Sayfa sayısı bir tam sayı olmalıdır.");
        }
        private bool BeValidPageCount(int pageCount)
        {
            return pageCount % 1 == 0;
        }
    }
}
