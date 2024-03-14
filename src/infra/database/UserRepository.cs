using LeanMind.ErrorHandling.domain;

namespace LeanMind.ErrorHandling.infra.database;

public class UserRepository
{
    private User[] users = Array.Empty<User>();
    
    public bool Exists(User user)
    {
        return users.FirstOrDefault(u => u?.username == user.username, null) != null;
    }

    public CreateUserResult Save(User user)
    {
        try
        {
            users = users.Append(user).ToArray();
            return CreateUserResult.Success();
        }
        catch (Exception)
        {
            return CreateUserResult.CannotSaveUser();
        }
    }

    public int CountOfAdmins()
    {
        return users.Count(user => user.IsAdmin());
    }
}