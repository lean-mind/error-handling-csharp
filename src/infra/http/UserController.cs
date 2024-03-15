using LeanMind.ErrorHandling.application;
using LeanMind.ErrorHandling.domain;
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
        try
        {
            var createUserResult = createUserUseCase.Execute(userDto.ToDomain());

            return createUserResult.error switch
            {
                Error.UserAlreadyExists => BadRequest("User already exists."),
                Error.TooManyAdmins => BadRequest("Too many admins."),
                Error.CannotSaveUser => Problem("Cannot create user."),
                null => Created("", null),
                _ => Problem("Unknown problem.")
            };
        }
        catch (PasswordTooShortException)
        {
            return BadRequest("Password is too short.");
        }
        catch (EmptyDataNotAllowedException)
        {
            return BadRequest("Username and password cannot be empty.");
        }
    }
}

static class UserDtoExtensions
{
    public static User ToDomain(this UserDto userDto)
    {
        UserRole role = ParseUserRole.From(userDto.role);
        return new User(userDto.username, userDto.password, role);
    }
}