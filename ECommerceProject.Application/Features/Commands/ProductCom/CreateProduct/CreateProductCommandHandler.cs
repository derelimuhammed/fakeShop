using AutoMapper;
using ECommerceProject.Application.Features.Commands.ProductCom.CreateProduct;
using ECommerceProject.Application.FluentValidators;
using ECommerceProject.Application.Helpers;
using ECommerceProject.Application.Repository.Interface.ProductRepo;
using ECommerceProject.Domain.Concrete;
using ECommerceProject.Domain.Ultilities.Results;
using MediatR;

namespace ECommerceProject.Application.Features.Commands.ProductCom.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, Result>
    {


        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IMapper _mapper;
        private readonly IValidatorHelper _validatorHelper;

        public CreateProductCommandHandler(IProductWriteRepository productWriteRepository, IMapper mapper, IValidatorHelper validatorHelper)
        {
            _mapper = mapper;
            _productWriteRepository = productWriteRepository;
            _validatorHelper = validatorHelper;
        }

        public async Task<Result> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            return await _validatorHelper.ValidateAndHandle(request, new CreateProductCommandRequestValidator(), async (validatedRequest) =>
            {

                await _productWriteRepository.AddAsync(_mapper.Map<Product>(validatedRequest));
                await _productWriteRepository.SaveChangesAsync();

                return new SuccessResult("Ekleme Başarılı");
            });

        }

    }
}
