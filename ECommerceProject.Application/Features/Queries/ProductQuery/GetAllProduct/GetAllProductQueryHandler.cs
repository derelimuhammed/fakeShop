using ECommerceProject.Application.Features.Commands.ProductCom.CreateProduct;
using ECommerceProject.Domain.Ultilities.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ECommerceProject.Application.Repository.Interface.ProductRepo;
using ECommerceProject.Domain.Concrete;

namespace ECommerceProject.Application.Features.Queries.ProductQuery.GetAllProduct
{
    public class GetAllProductQueryHandler:IRequestHandler<GetAllProductQueryRequest, Result>
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IMapper _mapper;


        public GetAllProductQueryHandler(IProductReadRepository productReadRepository, IMapper mapper)
        {
            _productReadRepository = productReadRepository;
            _mapper = mapper;
        }

        public async Task<Result> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
          var product= await _productReadRepository.GetAllAsync();
          return new SuccessDataResult<List<GetAllProductQueryResponse>>(
              _mapper.Map<List<GetAllProductQueryResponse>>(product.ToList()),"Listeleme Başarılı");

        }
    }
}
