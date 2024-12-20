namespace CourseWork;

public class CommandLineInterface
{
    private readonly List<ICommand> _commands;

    public CommandLineInterface(IAuthService authService, IGameService gameService)
    {
        _commands = new List<ICommand>
        {
            new LoginCommand(),
            new RegisterCommand(),
            new PlayCommand(),
            new ViewStatsCommand(),
            new ExitCommand()
        };
    }


}