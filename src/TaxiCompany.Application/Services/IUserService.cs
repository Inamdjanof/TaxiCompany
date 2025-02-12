using TaxiCompany.Application.Models.Users;
using TaxiCompany.Core.Entities;

namespace TaxiCompany.Application.Services;

public interface IUserService
{
    ValueTask<UserDto> CreateUserAsync(UserForCreationDto userForCreationDto);
    ValueTask<UserDto> RetrieveUserByIdAsync(Guid userId);
    IQueryable<User> RetrieveUsers();
    ValueTask<UserDto> ModifyUserAsync(UserForModificationDto userForModificationDto);
    ValueTask<UserDto> RemoveUserAsync(Guid userId);
}