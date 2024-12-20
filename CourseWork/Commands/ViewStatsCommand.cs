namespace CourseWork;

public class ViewStatsCommand : ICommand
{
    private readonly IGameService _gameService;
    private readonly User _user;

    public ViewStatsCommand(IGameService gameService, User user)
    {
        _gameService = gameService;
        _user = user;
    }

    public void Execute()
    {
        var games = _gameService.GetUserGames(_user.Username);
        Console.Clear();
        foreach (var game in games)
        {
            Console.WriteLine($"Date: {game.Date}, State: {game.State}, Rating Change: {game.Rating}, Current Rating: {game.CurrentRating}");
        }
        Console.ReadKey(true);
    }
}