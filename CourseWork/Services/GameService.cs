namespace CourseWork;

public class GameService(GameRepository gameRepository): IGameService
{
    public void RecordGame(GameData record)
    {
        gameRepository.AddGameRecord(record);
    }

    public IEnumerable<GameData> GetUserGames(int userId)
    {
        return gameRepository.GetUserGames(userId);
    }

    public void WinGame(User user, int rating)
    {
        user.Rating += rating;
        var gameData = new GameData(rating, DateTime.Now, "Win", user);
        user.GameHistory.Add(gameData);
        RecordGame(gameData);
    }

    public void LoseGame(User user, int rating)
    {
        user.Rating -= rating;
        var gameData = new GameData(rating, DateTime.Now, "Lose", user);
        user.GameHistory.Add(gameData);
        RecordGame(gameData);
    }
}