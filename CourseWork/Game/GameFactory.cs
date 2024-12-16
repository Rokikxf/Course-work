namespace CourseWork;

public class GameFactory
{
    private readonly IGameService _gameService;

    public GameFactory(IGameService gameService)
    {
        _gameService = gameService;
    }

    public Game CreateGame(GameType gameType)
    {
        return gameType switch
        {
            GameType.Training => new TrainingGame(_gameService),
            GameType.Ranked => new RankedGame(_gameService),
            _ => throw new ArgumentException("Invalid game type", nameof(gameType))
        };
    }
}

public enum GameType
{
    Training,
    Ranked
}