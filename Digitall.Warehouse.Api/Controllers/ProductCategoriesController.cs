using Microsoft.AspNetCore.Mvc;

namespace Digitall.Warehouse.Api.Controllers
{
    [Route("api/products/{id}/categories")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCategoriesAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
