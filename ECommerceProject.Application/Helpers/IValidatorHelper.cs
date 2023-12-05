using ECommerceProject.Domain.Ultilities.Results;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.Application.Helpers
{
    public interface IValidatorHelper
    {
        public Task<Result> ValidateAndHandle<TRequest>(TRequest request, AbstractValidator<TRequest> validator, Func<TRequest, Task<Result>> handleFunction);
    }
}
