using Microsoft.AspNetCore.Mvc;

namespace REPR_Pattern.ActionResults
{
    public class InternalServerErrorObjectResult : ObjectResult
    {
        public InternalServerErrorObjectResult(object error) :
            base(error)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
