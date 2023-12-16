using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ECommerceProject.Application.Features.Commands.ProductCom.UpdateProduct;
using ECommerceProject.Application.FluentValidators.ProductValidators;
using ECommerceProject.Application.Helpers;
using ECommerceProject.Application.Repository.Interface.ProductRepo;
using ECommerceProject.Domain.Ultilities.Results;
using MediatR;

namespace ECommerceProject.Application.Features.Commands.ProductCom.DeleteProduct
{
    public class DeleteProductCommandHandler:IRequestHandler<DeleteProductCommandRequest, Result>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository; 
        private readonly IValidatorHelper _validatorHelper;

        public DeleteProductCommandHandler(IProductWriteRepository productWriteRepository, IMapper mapper, IValidatorHelper validatorHelper, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _validatorHelper = validatorHelper;
            _productReadRepository = productReadRepository;
        }

        public async Task<Result> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            return await _validatorHelper.ValidateAndHandle(request, new DeleteProductCommandRequestValidator(), async (validatedRequest) =>
            {
                var deleteProduct=await _productReadRepository.GetByIdAsync(validatedRequest.Id);
                if (deleteProduct==null)
                    return new ErrorResult("Ürün Bulunamadı"); 
                await _productWriteRepository.DeleteAsync(deleteProduct);
                await _productWriteRepository.SaveChangesAsync();
                return new SuccessResult("Silme Başarılı");
            });

        }
    }
}
