using REPR_Pattern.Dtos;
using REPR_Pattern.Entities;
using REPR_Pattern.Factories;
using REPR_Pattern.Interfaces;
using REPR_Pattern.Models;

namespace REPR_Pattern.Services
{
    public class UserService : IUserService
    {
        private List<UserEntity> users = new List<UserEntity>();

        public async Task<ApiResponse<UserDto>> CreateAsync(CreateUserRequest request)
        {
            if (users.Any(x => x.Email == request.Email))
            {
                return ApiResponse<UserDto>.ErrorResponse("User with this email already exist");
            }

            await Task.Delay(5);

            var user = new UserEntity()
            {
                Email = request.Email,
                Password = request.Password,
                Username = request.Username
            };
            users.Add(user);
            await Task.Delay(5);

            var response =  new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.Username
            };

            return ApiResponse<UserDto>.SuccessResponse(response);
        }

        public async Task<IResponse<UserDto>> CreateAsyncV2(CreateUserRequest request)
        {
            if (users.Any(x => x.Email == request.Email))
            {
                return ResponseFactory.NotFound<UserDto>("User with this email already exist");
            }

            var user = new UserEntity()
            {
                Email = request.Email,
                Password = request.Password,
                Username = request.Username
            };

            users.Add(user);
            await Task.Delay(5);
            var response = new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.Username
            };

            return ResponseFactory.Success(response);
        }
    }
}
