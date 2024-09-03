using REPR_Pattern.Dtos;
using REPR_Pattern.Models;

namespace REPR_Pattern.Interfaces
{
    public interface IUserService
    {
        Task<ApiResponse<UserDto>> CreateAsync(CreateUserRequest request);

        Task<IResponse<UserDto>> CreateAsyncV2(CreateUserRequest request);
    }
}
