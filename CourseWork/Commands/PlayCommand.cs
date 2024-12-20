﻿namespace CourseWork;

public class PlayCommand : ICommand
{
    private readonly GameFactory _gameFactory;
    private readonly User _user;
    private readonly IAuthService _authService;
    private readonly IGameService _gameService;

    public PlayCommand(User user, IGameService gameService, IAuthService authService)
    {
        _user = user;
        _gameFactory = new GameFactory(gameService);
        _authService = authService;
        _gameService = gameService;
    }

    public void Execute()
    {
        string[] options = { "Training", "Ranked" };
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
                    GameType gameType = (selectedIndex == 0) ? GameType.Training : GameType.Ranked;
                    var game = _gameFactory.CreateGame(gameType);
                    game.Play(_user);
                    var gameSessionCommand = new GameSessionCommand(_authService, _gameService, _user);
                    gameSessionCommand.Execute();
                    return;
            }
        }
    }
}