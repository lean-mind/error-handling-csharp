using LeanMind.ErrorHandling.domain;
using LeanMind.ErrorHandling.infra.database;

namespace LeanMind.ErrorHandling.application;


public class CreateUserUseCase
{
    private const int MAX_NUMBER_OF_ADMINS = 2;
    private readonly UserRepository userRepository;

    public CreateUserUseCase(UserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public CreateUserResult Execute(User user)
    {
        if (userRepository.Exists(user))
        {
            return CreateUserResult.UserAlreadyExistsError();
        }

        if (user.IsAdmin() && CannotExistsMoreAdmins())
        {
            return CreateUserResult.TooManyAdminsError();
        }

        return userRepository.Save(user);
    }

    private bool CannotExistsMoreAdmins()
    {
        return userRepository.CountOfAdmins() >= MAX_NUMBER_OF_ADMINS;
    }
}