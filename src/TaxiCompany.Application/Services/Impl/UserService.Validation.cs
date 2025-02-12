using FluentValidation.Results;
using System.Text.Json;
using TaxiCompany.Application.Exceptions;
using TaxiCompany.Application.Models.Users;
using TaxiCompany.Application.Validators.Users;
using TaxiCompany.Core.Entities;
using TaxiCompany.Core.Exceptions;

namespace TaxiCompany.Application.Services.Impl;

public partial class UserService
{
    public void ValidateUserId(Guid userId)
    {
        if (userId == default)
        {
            throw new ValidationException($"The given userId is invalid: {userId}");
        }
    }

    public void ValidateStorageUser(User storageUser, Guid userId)
    {
        if (storageUser is null)
        {
            throw new NotFoundException($"Couldn't find user with given id: {userId}");
        }
    }

    public void ValidateUserForCreationDto(
        UserForCreationDto userForCreationDto)
    {
        var validationResult = new UserForCreationDtoValidator()
            .Validate(userForCreationDto);

        ThrowValidationExceptionIfValidationIsInvalid(validationResult);
    }

    public void ValidateUserForModificationDto(
        UserForModificationDto userForModificationDto)
    {
        var validationResult = new UserForModificationDtoValidator()
            .Validate(userForModificationDto);

        ThrowValidationExceptionIfValidationIsInvalid(validationResult);
    }

    private static void ThrowValidationExceptionIfValidationIsInvalid(ValidationResult validationResult)
    {
        if (validationResult.IsValid)
        {
            return;
        }

        var errors = JsonSerializer
                .Serialize(validationResult.Errors.Select(error => new
                {
                    PropertyName = error.PropertyName,
                    ErrorMessage = error.ErrorMessage,
                    AttemptedValue = error.AttemptedValue
                }));

        throw new ValidationException(errors);
    }
}