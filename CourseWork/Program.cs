namespace CourseWork;

class Program
{
    static void Main(string[] args)
    {
        IAuthService authService = new AuthService(new UserRepository(new DbContext()));
        IGameService gameService = new GameService(new GameRepository(new DbContext()));

        string[] options = { "Register", "Login" };
        int selectedIndex = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Select an option:");
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
                        var registerCommand = new RegisterCommand(authService);
                        registerCommand.Execute();
                    }
                    else if (selectedIndex == 1)
                    {
                        var loginCommand = new LoginCommand(authService, gameService);
                        loginCommand.Execute();
                    }
                    break;
            }
        }
    }
}