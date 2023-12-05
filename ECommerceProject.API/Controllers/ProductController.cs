using ECommerceProject.Application.Features.Commands.ProductCom.CreateProduct;
using ECommerceProject.Domain.Ultilities.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using ECommerceProject.Application.Features.Queries.ProductQuery.GetAllProduct;

namespace ECommerceProject.API.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
        {
            var response = await _mediator.Send(getAllProductQueryRequest);
            return Ok(response);
        }
    }
}
