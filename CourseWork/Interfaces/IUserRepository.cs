namespace CourseWork;

public interface IUserRepository
{
    IEnumerable<User> GetAllUsers();
    User GetByUsername(string username);

    void AddUser(User user);
    
}