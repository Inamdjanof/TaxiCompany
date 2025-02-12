using TaxiCompany.Application.Models.Users;
using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Repositories;

namespace TaxiCompany.Application.Services.Impl;

public partial class UserService : IUserService
{
    private readonly IUserRepository userRepository;
    private readonly IUserFactory userFactory;

    public UserService(
        IUserRepository userRepository,
        IUserFactory userFactory)
    {
        this.userRepository = userRepository;
        this.userFactory = userFactory;
    }

    public async ValueTask<UserDto> CreateUserAsync(
        UserForCreationDto userForCreationDto)
    {
        ValidateUserForCreationDto(userForCreationDto);

        var newUser = this.userFactory
            .MapToUser(userForCreationDto);

        var addedUser = await this.userRepository
            .InsertAsync(newUser);

        return this.userFactory.MapToUserDto(addedUser);
    }

    public IQueryable<User> RetrieveUsers()
    {
        var users = this.userRepository.SelectAll();

        return users;
    }

    public async ValueTask<UserDto> RetrieveUserByIdAsync(Guid userId)
    {
        ValidateUserId(userId);

        var storageUser = await this.userRepository
            .SelectByIdWithDetailsAsync(
                expression: user =>
                    user.Id == userId);

        ValidateStorageUser(storageUser, userId);

        return this.MapToUserDto(storageUser);
    }

    public async ValueTask<UserDto> ModifyUserAsync(
        UserForModificationDto userForModificationDto)
    {
        ValidateUserForModificationDto(userForModificationDto);

        var storageUser = await this.userRepository
            .SelectByIdWithDetailsAsync(
                expression: user =>
                    user.Id == userForModificationDto.userId);

        ValidateStorageUser(storageUser, userForModificationDto.userId);

        this.userFactory.MapToUser(storageUser, userForModificationDto);

        var modifiedUser = await this.userRepository
            .UpdateAsync(storageUser);

        return this.userFactory.MapToUserDto(modifiedUser);
    }

    public async ValueTask<UserDto> RemoveUserAsync(Guid userId)
    {
        ValidateUserId(userId);

        var storageUser = await this.userRepository
            .SelectByIdAsync(userId);

        ValidateStorageUser(storageUser, userId);

        var removedUser = await this.userRepository
            .DeleteAsync(storageUser);

        return this.userFactory.MapToUserDto(removedUser);
    }

    private UserDto MapToUserDto(User user)
    {
        return new UserDto(
            user.Id,
            user.FirstName,
            user.LastName!,
            user.Email,
            user.Role);
    }
}