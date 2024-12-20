namespace CourseWork;

public class LoginCommand(IAuthService authService, IGameService gameService) : ICommand
{
    
    public void Execute()
    {
        Console.WriteLine("Enter your username:");
        string username = Console.ReadLine();
        Console.WriteLine("Enter your password:");
        string password = Console.ReadLine();
        var user = authService.Login(username, password);
        var command = new GameSessionCommand(authService, gameService, user);
        command.Execute();
    }
    
}