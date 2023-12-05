using ECommerceProject.Application.Helpers;
using ECommerceProject.Domain.Ultilities.Results;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.Persistence.Helpers
{
    public class ValidatorHelper : IValidatorHelper
    {
        public async Task<Result> ValidateAndHandle<TRequest>(TRequest request, AbstractValidator<TRequest> validator, Func<TRequest, Task<Result>> handleFunction)
        {
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return new ErrorResult("Ekleme Başarısız. Hatalar: " + string.Join(", ", errorMessages));
            }

            return await handleFunction(request);
        }
    }
}
