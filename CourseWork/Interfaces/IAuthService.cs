
using CourseWork;

public interface IAuthService
{
    User Register(string username, string password);
    
    User Login(string username, string password);
    
    IEnumerable<User> GetAllUsers();
}
