namespace CourseWork;

public class User
{
    private static int _id = 1;
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    private int _rating;
    public int Rating
    {
        get
        {
            return _rating;
        }
        set
        {
            _rating = value > 0 ? value : 1;
        }
    }
    public List<GameData> GameHistory { get; private set; }

    public User(string username, string password)
    {
        Id = _id++;
        Username = username;
        Password = password;
        Rating = 300;
        GameHistory = new List<GameData>();
    }
}