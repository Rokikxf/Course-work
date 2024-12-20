namespace CourseWork;

public class CommandManager
{
    private readonly Dictionary<string, ICommand> _commands = new();

    public void RegisterCommand(string name, ICommand command)
    {
        _commands[name] = command;
    }

    public void ExecuteCommand(string name)
    {
        if (_commands.TryGetValue(name, out var command))
        {
            command.Execute();
            return;
        }

        Console.WriteLine($"Command '{name}' not found.");
    }
}