
using TaxiCompany.Application.Models.Users;
using TaxiCompany.Core.Entities;

namespace TaxiCompany.Application.Services;

public interface IUserFactory
{
    UserDto MapToUserDto(User user);
    User MapToUser(UserForCreationDto userForCreationDto);
    void MapToUser(User storageUser, UserForModificationDto userForCreationDto);
}