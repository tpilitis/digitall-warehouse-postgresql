using Digitall.Warehouse.Api.Contracts.Requests;
using Digitall.Warehouse.Application.Categories;
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

    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.FailedDependency)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest category, CancellationToken token)
    {
        var createCategoryCommand = new CreateCategoryCommand(category.Name);
        var result = await _sender.Send(createCategoryCommand, token);

        if (result.IsFailure)
        {
            // expect and return
            return result.Error.Code switch
            {
                Error.DuplicatedValueCode => BadRequest(result.Error),
                _ => StatusCode((int) HttpStatusCode.FailedDependency, result.Error)
            };
        }

        return NoContent();
    }
}
