using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ECommerceProject.Application.DTOs;
using ECommerceProject.Application.FluentValidators.ProductValidators;
using ECommerceProject.Application.Helpers;
using ECommerceProject.Application.Repository.Interface.ProductRepo;
using ECommerceProject.Domain.Ultilities.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceProject.Application.Features.Queries.ProductQuery.GetProductByPageSize
{
    public class GetProductByPageSizeHandle : IRequestHandler<GetProductByPageSizeRequest, Result>
    {
       private readonly IProductReadRepository _productReadRepository;
       private readonly IMapper _mapper;
       private readonly IValidatorHelper _validatorHelper;

        public GetProductByPageSizeHandle(IProductReadRepository productReadRepository, IMapper mapper, IValidatorHelper validatorHelper)
        {
            _productReadRepository = productReadRepository;
            _mapper = mapper;
            _validatorHelper = validatorHelper;
        }


        public async Task<Result> Handle(GetProductByPageSizeRequest request,
            CancellationToken cancellationToken)
        {
            return await _validatorHelper.ValidateAndHandle(request, new GetProductByPageSizeQueryRequestValidator(),
                async (validatedRequest) =>
                {
                    var totalProduct = _productReadRepository.GetProductByPageSize(false);

                    var products = totalProduct.Skip(request.Page * request.Size).Take(request.Size)
                        .Include(p => p.ProductImageFiles);
                    var productDtos =_mapper.Map< IEnumerable<GetProductByPageSizeDto>>(products).ToList();
           
                    return  new SuccessDataResult<GetProductByPageSizeResponse>(new GetProductByPageSizeResponse(totalProduct.Count(),productDtos),"Listeleme Başarılı");

                });
           
        }
    }

   
}
