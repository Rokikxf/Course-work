using CourseWork;

public class RegisterCommand(IAuthService authService) : ICommand
{


    public void Execute()
    {
        Console.WriteLine("Enter your username:");
        string username = Console.ReadLine();
        Console.WriteLine("Enter your password:");
        string password = Console.ReadLine();
        authService.Register(username, password);
    }
    
}