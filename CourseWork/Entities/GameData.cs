namespace CourseWork;

public class GameData
{
    private static int _id = 1;
    public int Id { get; set; }
    public int Rating { get; set; }
    public DateTime Date { get; set; }
    public string State { get; set; }
    public User User { get; set; }
    
    public GameData(int rating, DateTime date, string state, User user)
    {
        Id = _id++;
        Rating = rating;
        Date = date;
        State = state;
        User = user;
    }

}