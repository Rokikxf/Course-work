namespace CourseWork;

public class DbContext
{
    public List<User> Users { get; set; } = new();
    public List<GameData> GameDatas { get; set; } = new();
}