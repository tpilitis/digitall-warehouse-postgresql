using AutoMapper;
using Digitall.Warehouse.Api.Contracts.Requests.Products;
using Digitall.Warehouse.Api.Infrastructure.ExceptionHandling.Models;
using Digitall.Warehouse.Application.Contracts.Responses;
using Digitall.Warehouse.Application.Features.Products.Commands;
using Digitall.Warehouse.Application.Features.Products.Queries;
using Digitall.Warehouse.Domain.Shared;
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
        private readonly IMapper _mapper;

        public ProductsController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PaginatedResponseT<GetProductResponse>))]
        public async Task<IActionResult> GetProductsAsync(
            [FromQuery] string keyword,
            CancellationToken cancellationToken,
            [FromQuery] int? skip = 0,
            [FromQuery] int? take = 50)
        {
            var getProductsQuery = new SearchProductsQuery(keyword, skip!.Value, take!.Value);
            var result = await _sender.Send(getProductsQuery, cancellationToken);

            return Ok(result.Value);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(ValidationErrorResponse))]
        [ProducesResponseType((int)HttpStatusCode.FailedDependency, Type = typeof(ValidationErrorResponse))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(GetProductResponse))]
        public async Task<IActionResult> GetProductByIdAsync([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var getProductQuery = new GetProductQuery(id);
            var result = await _sender.Send(getProductQuery, cancellationToken);

            if (result.IsFailure)
            {

                ErrorType.TryFromValue(result.Error.Code, out var errorType);
                if (errorType != null && errorType == ErrorType.ResourceNotFound)
                {
                    return NotFound(new ValidationErrorResponse(result.Error));
                }

                return StatusCode((int)HttpStatusCode.FailedDependency, new ValidationErrorResponse(result.Error));
            }

            return Ok(result.Value);
        }

        [ProducesResponseType((int)HttpStatusCode.FailedDependency, Type = typeof(ValidationErrorResponse))]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductRequest createProductRequest, CancellationToken cancellationToken)
        {
            var createProductCommand = _mapper.Map<CreateProductCommand>(createProductRequest);
            var result = await _sender.Send(createProductCommand, cancellationToken);

            if (result.IsFailure)
            {
                return StatusCode((int)HttpStatusCode.FailedDependency, new ValidationErrorResponse(result.Error));
            }

            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}
