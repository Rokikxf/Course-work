namespace CourseWork;

public class AuthService(UserRepository userRepository) : IAuthService
{
    public User Register(string username, string password)
    {
        username = username.Trim();
        password = password.Trim();
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            throw new Exception("Username or password are invalid");
        }
        
        var existingUser = userRepository.GetByUsername(username);
        if (existingUser != null)
        {
            throw new Exception("Username already exists");
        }
        var user = new User(username, password);
        userRepository.AddUser(user);
        return user;
    }

    public User Login(string username, string password)
    {
        username = username.Trim();
        password = password.Trim();
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            throw new Exception("Username or password are invalid");
        }

        var user = userRepository.GetByUsername(username);
        if (user == null || user.Password != password)
        {
            throw new Exception("Invalid username or password");
        }
        return user;
    }

    public IEnumerable<User> GetAllUsers()
    {
        return userRepository.GetAllUsers();
    }

}