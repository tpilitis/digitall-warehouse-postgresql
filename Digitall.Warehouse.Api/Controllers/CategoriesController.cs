using Digitall.Warehouse.Api.Contracts.Requests;
using Digitall.Warehouse.Api.Infrastructure.ExceptionHandling.Models;
using Digitall.Warehouse.Application.Contracts.Responses;
using Digitall.Warehouse.Application.Features.Categories.Commands;
using Digitall.Warehouse.Application.Features.Categories.Queries.GetCategoryByName;
using Digitall.Warehouse.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Digitall.Warehouse.Api.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ISender _sender;

    public CategoriesController(ISender sender)
    {
        _sender = sender;
    }

    [ProducesResponseType(typeof(ValidationErrorResponse), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ValidationErrorResponse), (int)HttpStatusCode.FailedDependency)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [HttpPost]
    public async Task<IActionResult> CreateCategoryAsync([FromBody] CreateCategoryRequest category, CancellationToken token)
    {
        var createCategoryCommand = new CreateCategoryCommand(category.Name);

        var result = await _sender.Send(createCategoryCommand, token);

        if (result.IsFailure)
        {
            // expect and return
            return StatusCode(
                (int)HttpStatusCode.FailedDependency,
                new ValidationErrorResponse(result.Error));
        }

        return NoContent();
    }

    [ProducesResponseType(typeof(ValidationErrorResponse), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ValidationErrorResponse), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ValidationErrorResponse), (int)HttpStatusCode.FailedDependency)]
    [ProducesResponseType(typeof(GetCategoryByNameResponse), (int)HttpStatusCode.OK)]
    [HttpGet("name")]
    public async Task<IActionResult> GetCategoryAsync([FromQuery] string name, CancellationToken token)
    {
        var createCategoryQuery = new GetCategoryByNameQuery(name);
        var result = await _sender.Send(createCategoryQuery, token);

        if (result.IsFailure)
        {
            // expect and return
            ErrorType.TryFromValue(result.Error.Code, out var errorType);
            if (errorType != null && errorType == ErrorType.ResourceNotFound)
            {
                return NotFound(new ValidationErrorResponse(result.Error));
            }

            return StatusCode((int)HttpStatusCode.FailedDependency, new ValidationErrorResponse(result.Error));
        }

        return Ok(result.Value);
    }
}
