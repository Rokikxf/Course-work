namespace CourseWork;

public class GameData
{
    public int Id { get; set; }
    public int Rating { get; set; }
    public DateTime Date { get; set; }
    public string State { get; set; }
    public User User { get; set; }
    
    public int CurrentRating { get; set; }
    
    public GameData(int rating, DateTime date, string state, User user, int currentRating)
    {
        Rating = rating;
        Date = date;
        State = state;
        User = user;
        CurrentRating = currentRating;
    }

}