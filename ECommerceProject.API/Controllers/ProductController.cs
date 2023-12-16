using ECommerceProject.Application.Features.Commands.ProductCom.CreateProduct;
using ECommerceProject.Domain.Ultilities.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using ECommerceProject.Application.Features.Commands.ProductCom.DeleteProduct;
using ECommerceProject.Application.Features.Commands.ProductCom.UpdateProduct;
using ECommerceProject.Application.Features.Queries.ProductQuery.GetAllProduct;
using ECommerceProject.Application.Features.Queries.ProductQuery.GetProductByPageSize;
using Microsoft.AspNetCore.Authorization;

namespace ECommerceProject.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommandRequest createProductCommandRequest)
        {
            Result response = await _mediator.Send(createProductCommandRequest);
            var jsonResult=JsonConvert.SerializeObject(response);
            return Ok(jsonResult);
        }
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            Result response = await _mediator.Send(new GetAllProductQueryRequest());
            var jsonResult = JsonConvert.SerializeObject(response);
            return Ok(jsonResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetByPageSize([FromQuery]GetProductByPageSizeQueryRequest getProductByPageSizeRequest)
        {
            Result response = await _mediator.Send(getProductByPageSizeRequest);
            var jsonResult = JsonConvert.SerializeObject(response);
            return Ok(jsonResult);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommandRequest updateProductCommandRequest)
        {
            Result response = await _mediator.Send(updateProductCommandRequest);
            var jsonResult = JsonConvert.SerializeObject(response);
            return Ok(jsonResult);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteProductCommandRequest deleteProductCommandRequest)
        {
            Result response = await _mediator.Send(deleteProductCommandRequest);
            var jsonResult = JsonConvert.SerializeObject(response);
            return Ok(jsonResult);
        }
    }
}
