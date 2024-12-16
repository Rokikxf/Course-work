namespace CourseWork;

public class UserRepository(DbContext context): IUserRepository
{
    public IEnumerable<User> GetAllUsers()
    {
        return context.Users;
    }

    public User GetByUsername(string username)
    {
        return context.Users.Find(u=>u.Username == username);
    }

    public User GetById(int id)
    {
        return context.Users.Find(u=>u.Id == id);
    }

    public void AddUser(User user)
    {
        context.Users.Add(user);
    }
}