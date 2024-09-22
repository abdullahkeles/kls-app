using System.Net;
using Microsoft.AspNetCore.Mvc;
using Shared.Helpers.Services;

namespace Shared.BLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        [NonAction]
        public IActionResult ApiResponse(ServiceResult serviceResult) => serviceResult.StatusCode switch
        {
            HttpStatusCode.NoContent => NoContent(),
            HttpStatusCode.Created => Created(),
            _ => new ObjectResult(serviceResult) { StatusCode = serviceResult.StatusCode.GetHashCode() },
        };
        [NonAction]
        public IActionResult ApiResponse<T>(ServiceResult<T> serviceResult) => serviceResult.StatusCode switch
        {
            HttpStatusCode.NoContent => NoContent(),
            HttpStatusCode.Created => Created(),
            _ => new ObjectResult(serviceResult) { StatusCode = serviceResult.StatusCode.GetHashCode() }
        };
        [NonAction]
        public IActionResult ApiResponse<T, Tpag>(ServiceResult<T, Tpag> serviceResult, string? id = null) => serviceResult.StatusCode switch
        {
            HttpStatusCode.NoContent => NoContent(),
            HttpStatusCode.Created => id is null ? Created() : Created(id, null),
            _ => new ObjectResult(serviceResult) { StatusCode = serviceResult.StatusCode.GetHashCode() }
        };
    }
}
