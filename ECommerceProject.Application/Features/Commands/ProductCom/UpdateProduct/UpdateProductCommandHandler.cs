using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ECommerceProject.Application.Helpers;
using ECommerceProject.Application.Repository.Interface.ProductRepo;
using ECommerceProject.Application.Validators.FluentValidators.ProductValidators;
using ECommerceProject.Domain.Concrete;
using ECommerceProject.Domain.Ultilities.Results;
using MediatR;

namespace ECommerceProject.Application.Features.Commands.ProductCom.UpdateProduct
{
    public class UpdateProductCommandHandler:IRequestHandler<UpdateProductCommandRequest, Result>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository; 
        private readonly IMapper _mapper;
        private readonly IValidatorHelper _validatorHelper;

        public UpdateProductCommandHandler(IProductWriteRepository productWriteRepository, IMapper mapper, IValidatorHelper validatorHelper, IProductReadRepository productReadRepository)
        {
            _mapper = mapper;
            _productWriteRepository = productWriteRepository;
            _validatorHelper = validatorHelper;
            _productReadRepository = productReadRepository;
        }

        public async Task<Result> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            return await _validatorHelper.ValidateAndHandle(request, new UpdateProductCommandRequestValidator(), async (validatedRequest) =>
            {
                var updateProduct=await _productReadRepository.GetByIdAsync(validatedRequest.Id);
                if (updateProduct==null)
                    return new ErrorResult("Ürün Bulunamadı"); 
                await _productWriteRepository.UpdateAsync(_mapper.Map(validatedRequest,updateProduct));
                await _productWriteRepository.SaveChangesAsync();
                return new SuccessResult("Güncelleme Başarılı");
            });

        }
    }
}
