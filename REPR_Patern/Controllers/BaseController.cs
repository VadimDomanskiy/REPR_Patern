using Microsoft.AspNetCore.Mvc;
using REPR_Pattern.ActionResults;
using REPR_Pattern.Enums;
using REPR_Pattern.Interfaces;

namespace REPR_Pattern.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class BaseController : ControllerBase
    {
        protected IActionResult MapResponse<T>(IResponse<T> response)
        {
            if (response.IsSuccess)
                return Ok(response);

            return MapError(response);
        }

        private IActionResult MapError(IResponse response)
        {
            switch (response.Error.Type)
            {
                case string s when s == ErrorType.InternalServerError.ToString():
                    return new InternalServerErrorObjectResult(response);
                case string s when s == ErrorType.NotFound.ToString():
                    return new NotFoundObjectResult(response);
                case string s when s == ErrorType.InvalidData.ToString():
                    return new BadRequestObjectResult(response);
                default:
                    throw new ArgumentOutOfRangeException($"Invalid error type: {response.Error.Type}");
            }
        }
    }
}
