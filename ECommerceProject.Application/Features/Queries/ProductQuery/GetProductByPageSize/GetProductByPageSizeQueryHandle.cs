using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ECommerceProject.Application.DTOs;
using ECommerceProject.Application.Helpers;
using ECommerceProject.Application.Repository.Interface.ProductRepo;
using ECommerceProject.Application.Validators.FluentValidators.ProductValidators;
using ECommerceProject.Domain.Ultilities.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceProject.Application.Features.Queries.ProductQuery.GetProductByPageSize
{
    public class GetProductByPageSizeQueryHandle : IRequestHandler<GetProductByPageSizeQueryRequest, Result>
    {
       private readonly IProductReadRepository _productReadRepository;
       private readonly IMapper _mapper;
       private readonly IValidatorHelper _validatorHelper;

        public GetProductByPageSizeQueryHandle(IProductReadRepository productReadRepository, IMapper mapper, IValidatorHelper validatorHelper)
        {
            _productReadRepository = productReadRepository;
            _mapper = mapper;
            _validatorHelper = validatorHelper;
        }


        public async Task<Result> Handle(GetProductByPageSizeQueryRequest request,
            CancellationToken cancellationToken)
        {
            return await _validatorHelper.ValidateAndHandle(request, new GetProductByPageSizeQueryRequestValidator(),
                async (validatedRequest) =>
                {
                    var totalProduct = _productReadRepository.GetProductByPageSize(false);

                    var products = totalProduct.Skip(request.Page * request.Size).Take(request.Size)
                        .Include(p => p.ProductImageFiles);
                    var productDtos = _mapper.Map<IEnumerable<GetProductByPageSizeDto>>(products).ToList();

                    return new SuccessDataResult<GetProductByPageSizeQueryResponse>(new GetProductByPageSizeQueryResponse(totalProduct.Count(), productDtos), "Listeleme Başarılı");

                });


        }


    }

   
}
