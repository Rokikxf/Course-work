namespace CourseWork;

public interface IUserRepository
{
    IEnumerable<User> GetAllUsers();
    User GetByUsername(string username);
    User GetById(int id);
    void AddUser(User user);
    
}