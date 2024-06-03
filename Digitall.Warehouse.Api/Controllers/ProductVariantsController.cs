using AutoMapper;
using Digitall.Warehouse.Api.Infrastructure.ExceptionHandling.Models;
using Digitall.Warehouse.Application.Contracts.Requests.Products;
using Digitall.Warehouse.Application.Contracts.Responses;
using Digitall.Warehouse.Application.Features.Products.Commands;
using Digitall.Warehouse.Application.Features.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Digitall.Warehouse.Api.Controllers;

[Route("api/products/{id}/variants")]
[ApiController]
public class ProductVariantsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public ProductVariantsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<GetProductVariantResponse>))]
    public async Task<IActionResult> GetVariantsAsync([FromRoute] Guid id)
    {
        var getProductVariantsQuery = new GetProductVariantsQuery(id);
        var result  = await _sender.Send(getProductVariantsQuery);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.FailedDependency, Type = typeof(ValidationErrorResponse))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ValidationErrorResponse))]
    public async Task<IActionResult> AddProductVariantAsync(ProductVariantRequest productVariantRequest)
    {
        var createProductVariantCommand = _mapper.Map<AddProductVariantCommand>(productVariantRequest);
        var result  = await _sender.Send(createProductVariantCommand);
        if (result.IsFailure)
        {
            return StatusCode((int) HttpStatusCode.FailedDependency, new ValidationErrorResponse(result.Error))
        }

        return NoContent();
    }
}
