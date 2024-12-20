namespace CourseWork;

public class GameSessionCommand : ICommand
{
    private readonly IAuthService _authService;
    private readonly IGameService _gameService;
    private readonly User _user;

    public GameSessionCommand(IAuthService authService, IGameService gameService, User user)
    {
        _authService = authService;
        _gameService = gameService;
        _user = user;
    }

    public void Execute()
    {
        string[] options = { "Play game", "View game logs" };
        int selectedIndex = 0;

        while (true)
        {
            Console.Clear();
            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(options[i]);
                Console.ResetColor();
            }

            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.W:
                    selectedIndex = (selectedIndex == 0) ? options.Length - 1 : selectedIndex - 1;
                    break;
                case ConsoleKey.S:
                    selectedIndex = (selectedIndex == options.Length - 1) ? 0 : selectedIndex + 1;
                    break;
                case ConsoleKey.Enter:
                    if (selectedIndex == 0)
                    {
                        var playCommand = new PlayCommand(_user, _gameService, _authService);
                        playCommand.Execute();
                    }
                    else if (selectedIndex == 1)
                    {
                        var viewStatsCommand = new ViewStatsCommand(_gameService, _user);
                        viewStatsCommand.Execute();
                    }
                    return;
            }
        }
    }
}