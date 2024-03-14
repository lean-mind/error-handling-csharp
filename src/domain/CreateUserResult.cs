namespace LeanMind.ErrorHandling.domain;

public enum Error
{
    UserAlreadyExists,
    TooManyAdmins,
    CannotSaveUser,
}

public class CreateUserResult
{
    public readonly Error? error;

    private CreateUserResult(Error? error)
    {
        this.error = error;
    }

    public static CreateUserResult Success()
    {
        return new CreateUserResult(null);
    }

    public static CreateUserResult UserAlreadyExistsError()
    {
        return new CreateUserResult(Error.UserAlreadyExists);
    }

    public static CreateUserResult TooManyAdminsError()
    {
        return new CreateUserResult(Error.TooManyAdmins);
    }

    public static CreateUserResult CannotSaveUser()
    {
        return new CreateUserResult(Error.CannotSaveUser);
    }
}
