using TaxiCompany.Application.Models.Users;
using TaxiCompany.Core.Entities;
using TaxiCompany.Core.Enums;
using TaxiCompany.DataAccess.Authentication;

namespace TaxiCompany.Application.Services.Impl;

public class UserFactory : IUserFactory
{
    private readonly IPasswordHasher passwordHasher;

    public UserFactory(IPasswordHasher passwordHasher)
    {
        this.passwordHasher = passwordHasher;
    }

    public User MapToUser(
        UserForCreationDto userForCreationDto)
    {
        string randomSalt = Guid.NewGuid().ToString();

        return new User
        {
            FirstName = userForCreationDto.firstName,
            LastName = userForCreationDto.lastName,
            Email = userForCreationDto.email,

            Salt = randomSalt,

            PasswordHash = this.passwordHasher.Encrypt(
                password: userForCreationDto.password,
                salt: randomSalt),
               
                Role= UserRole.Client,
            
        };
    }

    public void MapToUser(
        User storageUser,
        UserForModificationDto userForModificationDto)
    {
        storageUser.FirstName = userForModificationDto.firstName ?? storageUser.FirstName;
        storageUser.LastName = userForModificationDto.lastName;
        storageUser.UpdatedAt = DateTime.UtcNow;
    }

    public UserDto MapToUserDto(User user)
    {
        return new UserDto(
            user.Id,
            user.FirstName,
            user.LastName!,
            user.Email,
            user.Role);
    }
}