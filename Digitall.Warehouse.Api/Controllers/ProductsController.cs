using Digitall.Warehouse.Api.Contracts.Requests.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Digitall.Warehouse.Api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _sender;

        public ProductsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IAsyncResult> GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> GetProductByIdAsync()
        {
            throw new NotImplementedException();
        }

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductRequest createProductRequest)
        {
            throw new NotImplementedException();
        }
    }
}
