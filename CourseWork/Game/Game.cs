namespace CourseWork;

public abstract class Game
{
    private readonly IGameService _gameService;

    protected Game(IGameService gameService)
    {
        _gameService = gameService;
    }

    public abstract int CalculateRating();

    public virtual void Play(User user)
    {
        var gameLogic = new GameLogic();
        ConsoleKeyInfo key;
        gameLogic.GenerateSolvedGrid();
        gameLogic.PrepareGameGrid();
        do {
            Console.Clear();
            gameLogic.PrintGrid();
            if (gameLogic.IsGameComplete())
            {
                Console.WriteLine("Congratulations!");
                _gameService.WinGame(user, CalculateRating());
                break;
            }
            if (gameLogic.HasLost())
            {
                Console.WriteLine("You have lost the game due to too many incorrect attempts.");
                _gameService.LoseGame(user, CalculateRating());
                break;
            }
            key = Console.ReadKey(true);
            gameLogic.HandleInput(key);
        } while (key.Key != ConsoleKey.Spacebar);
    }
}