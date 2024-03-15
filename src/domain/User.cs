namespace LeanMind.ErrorHandling.domain;

public class User
{
    public readonly string username;
    public readonly string password;
    public readonly UserRole role;

    public User(string username, string password, UserRole role)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            throw new EmptyDataNotAllowedException();
        }

        if (password.Length < 8)
        {
            throw new PasswordTooShortException();
        }
        
        this.username = username;
        this.password = password;
        this.role = role;
    }
    
    public bool IsAdmin() => role == UserRole.Admin;
}

public enum UserRole
{
    Admin,
    Standard
}

public static class ParseUserRole
{
    public static UserRole From(string role)
    {
        if (role == "Admin")
        {
            return UserRole.Admin;
        }
        if (role == "Standard")
        {
            return UserRole.Standard;
        }

        throw new ArgumentException("Invalid user role.");
    }
}