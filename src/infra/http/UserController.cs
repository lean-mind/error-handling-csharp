using LeanMind.ErrorHandling.application;
using LeanMind.ErrorHandling.domain;
using LeanMind.ErrorHandling.exercise_2;
using Microsoft.AspNetCore.Mvc;

namespace LeanMind.ErrorHandling.infra.http;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    private readonly CreateUserUseCase createUserUseCase;

    public UserController(CreateUserUseCase createUserUseCase)
    {
        this.createUserUseCase = createUserUseCase;
    }

    [HttpPost(Name = "CreateNewUser")]
    public IActionResult CreateUser(UserDto userDto)
    {
        var userResult = userDto.ToDomain();
        if (userResult.IsError())
        {
            return userResult.error switch
            {
                Error.PasswordTooShort => BadRequest("Password is too short."),
                Error.UsernameCannotBeEmpty => BadRequest("Username and password cannot be empty."),
                _ => Problem("Unknown problem.")
            };
        }

        var createUserResult = createUserUseCase.Execute(userResult.value!);

        return createUserResult.error switch
        {
            Error.UserAlreadyExists => BadRequest("User already exists."),
            Error.TooManyAdmins => BadRequest("Too many admins."),
            Error.CannotSaveUser => Problem("Cannot create user."),
            null => Created("", null),
            _ => Problem("Unknown problem.")
        };
    }
}

static class UserDtoExtensions
{
    public static Result<User> ToDomain(this UserDto userDto)
    {
        UserRole role = ParseUserRole.From(userDto.role);
        return User.From(userDto.username, userDto.password, role);
    }
}