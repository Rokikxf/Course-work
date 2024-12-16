namespace CourseWork;

class Program
{
    static void Main(string[] args)
    {
        var context = new DbContext();
        var userRepository = new UserRepository(context);
        var authService = new AuthService(userRepository);
        var gameRepository = new GameRepository(context);
        var gameService = new GameService(gameRepository);
        var cli = new CommandLineInterface(authService, gameService);

        int selectedIndex = 0;
        string[] options = { "Register", "Login", "Exit" };

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

            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.W:
                    selectedIndex = (selectedIndex == 0) ? options.Length - 1 : selectedIndex - 1;
                    break;
                case ConsoleKey.S:
                    selectedIndex = (selectedIndex == options.Length - 1) ? 0 : selectedIndex + 1;
                    break;
                case ConsoleKey.Enter:
                    HandleSelection(selectedIndex, authService, cli);
                    break;
            }
        }
    }

    static void HandleSelection(int selectedIndex, IAuthService authService, CommandLineInterface cli)
    {
        string? username;
        string? password;
        User? user = null;
        switch (selectedIndex)
        {
            case 0:
                Console.Write("Enter username: ");
                username = Console.ReadLine();
                Console.Write("Enter password: ");
                password = Console.ReadLine();
                try
                {
                    user = authService.Register(username, password);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
                break;
            case 1:
                Console.Write("Enter username: ");
                username = Console.ReadLine();
                Console.Write("Enter password: ");
                password = Console.ReadLine();

                try
                {
                    user = authService.Login(username, password);
                    ShowUserMenu(user, cli);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
                break;
            case 2:
                Environment.Exit(0);
                break;
        }
        Console.ReadKey();
    }

    static void ShowUserMenu(User user, CommandLineInterface cli)
    {
        int selectedIndex = 0;
        string[] options = { "Play Game", "View Statistics", "Logout" };

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Welcome {user.Username}! Please select an option:");

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

            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.W:
                    selectedIndex = (selectedIndex == 0) ? options.Length - 1 : selectedIndex - 1;
                    break;
                case ConsoleKey.S:
                    selectedIndex = (selectedIndex == options.Length - 1) ? 0 : selectedIndex + 1;
                    break;
                case ConsoleKey.Enter:
                    if (HandleUserSelection(selectedIndex, user, cli))
                    {
                        return; // Exit the loop and return to the main menu
                    }
                    break;
            }
        }
    }

    static bool HandleUserSelection(int selectedIndex, User user, CommandLineInterface cli)
    {
        switch (selectedIndex)
        {
            case 0:
                ShowGameTypeMenu(user, cli);
                break;
            case 1:
                cli.ViewStatistics(user);
                break;
            case 2:
                return true; 
        }

        Console.ReadKey();
        return false; 
    }

    static void ShowGameTypeMenu(User user, CommandLineInterface cli)
    {
        int selectedIndex = 0;
        string[] options = { "Training", "Ranked", "Back" };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Select Game Type:");

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

            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.W:
                    selectedIndex = (selectedIndex == 0) ? options.Length - 1 : selectedIndex - 1;
                    break;
                case ConsoleKey.S:
                    selectedIndex = (selectedIndex == options.Length - 1) ? 0 : selectedIndex + 1;
                    break;
                case ConsoleKey.Enter:
                    if (selectedIndex == 2) return;
                    var gameType = selectedIndex == 0 ? GameType.Training : GameType.Ranked;
                    cli.PlayGame(user, gameType);
                    return;
            }
        }
    }
}