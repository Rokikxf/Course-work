using CourseWork;

public class ExitCommand : ICommand
{
    public void Execute()
    {
        Environment.Exit(0);
    }

    public void Description()
    {
        Console.WriteLine("Exit");
    }
}