namespace CourseWork;

public class GameService(GameRepository gameRepository): IGameService
{
    public void RecordGame(GameData record)
    {
        gameRepository.AddGameRecord(record);
    }

    public IEnumerable<GameData> GetUserGames(string username)
    {
        return gameRepository.GetUserGames(username);
    }

    public void WinGame(User user, int rating)
    {
        user.Rating += rating;
        var gameData = new GameData(rating, DateTime.Now, "Win", user , user.Rating);
        user.GameHistory.Add(gameData);
        RecordGame(gameData);
    }

    public void LoseGame(User user, int rating)
    {
        user.Rating -= rating;
        var gameData = new GameData(rating, DateTime.Now, "Lose", user , user.Rating);
        user.GameHistory.Add(gameData);
        RecordGame(gameData);
    }
    
    
}