namespace CourseWork;

public class CommandLineInterface
{
    private readonly IAuthService _authService;
    private readonly IGameService _gameService;
    private readonly GameFactory _gameFactory;

    public CommandLineInterface(IAuthService authService, IGameService gameService)
    {
        _authService = authService;
        _gameService = gameService;
        _gameFactory = new GameFactory(gameService);
    }

    public void PlayGame(User user, GameType gameType)
    {
        var game = _gameFactory.CreateGame(gameType);
        game.Play(user);
    }

    public void ViewStatistics(User user)
    {
        var games = _gameService.GetUserGames(user.Id);
        Console.WriteLine($"Statistics for {user.Username}:");

        if (!games.Any())
        {
            Console.WriteLine("No games found for this user.");
            return;
        }

        foreach (var game in games)
        {
            Console.WriteLine($"Date: {game.Date}, Rating: {game.Rating}, State: {game.State}");
        }
    }
}