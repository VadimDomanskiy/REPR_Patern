using Microsoft.AspNetCore.Mvc;
using REPR_Pattern.Dtos;
using REPR_Pattern.Interfaces;
using REPR_Pattern.Models;

namespace REPR_Pattern.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> CreateUserAsync(CreateUserRequest createUserRequest)
        {
            var result = await _userService.CreateAsync(createUserRequest);
            if (result.Success)
            {
                return Ok(ApiResponse<UserDto>.SuccessResponse(result.Data));
            }
            else
            {
                return BadRequest(ApiResponse<string>.ErrorResponse(result.ErrorMessage));
            }
        }

        [HttpPost("v2/create")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> CreateUserV2Async(CreateUserRequest createUserRequest)
        {
            var result = await _userService.CreateAsyncV2(createUserRequest);

            return MapResponse(result);
        }
    }
}
