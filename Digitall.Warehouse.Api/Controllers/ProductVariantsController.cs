using Microsoft.AspNetCore.Mvc;

namespace Digitall.Warehouse.Api.Controllers
{
    [Route("api/products/{id}/variants")]
    [ApiController]
    public class ProductVariantsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetVariantsAsync([FromRoute] Guid id) => throw new NotImplementedException();
    }
}
