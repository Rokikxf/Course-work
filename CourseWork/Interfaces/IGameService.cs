namespace CourseWork;

public interface IGameService
{
    void RecordGame(GameData record);
    IEnumerable<GameData> GetUserGames(string username);
    void WinGame(User user, int rating);
    void LoseGame(User user, int rating);
}