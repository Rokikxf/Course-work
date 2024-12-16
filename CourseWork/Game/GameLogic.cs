namespace CourseWork;

public class GameLogic
{
    const int SIZE = 9;
    int[,] solutionGrid = new int[SIZE, SIZE];
    int[,] gameGrid = new int[SIZE, SIZE];
    bool[,] fixedCells = new bool[SIZE, SIZE];
    int cursorX = 0, cursorY = 0;
    private int incorrectAttempts = 0;
    private const int maxIncorrectAttempts = 3;

    public void GenerateSolvedGrid()
    {
        Random rand = new Random();
        FillGrid(0, 0, rand);
        Array.Copy(solutionGrid, gameGrid, solutionGrid.Length);
    }

    private bool FillGrid(int row, int col, Random rand)
    {
        if (row == SIZE)
        {
            return true;
        }

        int nextRow = (col == SIZE - 1) ? row + 1 : row;
        int nextCol = (col + 1) % SIZE;

        int[] numbers = GetShuffledNumbers(rand);
        foreach (int num in numbers)
        {
            if (IsValidMove(row, col, num, solutionGrid))
            {
                solutionGrid[row, col] = num;
                if (FillGrid(nextRow, nextCol, rand))
                {
                    return true;
                }
                solutionGrid[row, col] = 0;
            }
        }

        return false;
    }

    public void PrepareGameGrid()
    {
        Random rand = new Random();
        int cellsToRemove = 50;

        while (cellsToRemove > 0)
        {
            int x = rand.Next(0, SIZE);
            int y = rand.Next(0, SIZE);
            if (gameGrid[y, x] != 0)
            {
                gameGrid[y, x] = 0;
                fixedCells[y, x] = false;
                cellsToRemove--;
            }
        }

        for (int i = 0; i < SIZE; i++)
        for (int j = 0; j < SIZE; j++)
            if (gameGrid[i, j] != 0)
                fixedCells[i, j] = true;
    }

    private int[] GetShuffledNumbers(Random rand)
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        for (int i = numbers.Length - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);
            (numbers[i], numbers[j]) = (numbers[j], numbers[i]);
        }

        return numbers;
    }

    public void PrintGrid()
    {
        for (int i = 0; i < SIZE; i++)
        {
            if (i % 3 == 0) Console.WriteLine("+-------+-------+-------+");
            for (int j = 0; j < SIZE; j++)
            {
                if (j % 3 == 0) Console.Write("| ");

                if (i == cursorY && j == cursorX) Console.BackgroundColor = ConsoleColor.DarkGray;

                if (!fixedCells[i, j] && gameGrid[i, j] != 0 && gameGrid[i, j] != solutionGrid[i, j])
                    Console.ForegroundColor = ConsoleColor.Red;

                if (fixedCells[i, j]) Console.ForegroundColor = ConsoleColor.Cyan;

                Console.Write(gameGrid[i, j] == 0 ? "\u00b7 " : gameGrid[i, j] + " ");

                Console.ResetColor();
            }

            Console.WriteLine("|");
        }

        Console.WriteLine("+-------+-------+-------+");
    }

    private bool IsValidMove(int row, int col, int num, int[,] grid)
    {
        for (int i = 0; i < SIZE; i++)
            if (grid[row, i] == num || grid[i, col] == num)
                return false;

        int startRow = row / 3 * 3, startCol = col / 3 * 3;
        for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
            if (grid[startRow + i, startCol + j] == num)
                return false;

        return true;
    }

    public void HandleInput(ConsoleKeyInfo key)
    {
        switch (key.Key)
        {
            case ConsoleKey.W: cursorY = (cursorY > 0) ? cursorY - 1 : SIZE - 1; break;
            case ConsoleKey.S: cursorY = (cursorY < SIZE - 1) ? cursorY + 1 : 0; break;
            case ConsoleKey.A: cursorX = (cursorX > 0) ? cursorX - 1 : SIZE - 1; break;
            case ConsoleKey.D: cursorX = (cursorX < SIZE - 1) ? cursorX + 1 : 0; break;
            case ConsoleKey.Backspace:
            case ConsoleKey.Delete:
                if (!fixedCells[cursorY, cursorX]) gameGrid[cursorY, cursorX] = 0;
                break;

            default:
                if (char.IsDigit(key.KeyChar))
                {
                    int value = key.KeyChar - '0';
                    if (value >= 1 && value <= 9 && !fixedCells[cursorY, cursorX])
                    {
                        if (gameGrid[cursorY, cursorX] != solutionGrid[cursorY, cursorX])
                        {
                            if (value != solutionGrid[cursorY, cursorX])
                            {
                                incorrectAttempts++;
                            }
                        }
                        gameGrid[cursorY, cursorX] = value;
                    }
                }
                break;
        }
    }

    public bool IsGameComplete()
    {
        for (int i = 0; i < SIZE; i++)
        for (int j = 0; j < SIZE; j++)
            if (gameGrid[i, j] != solutionGrid[i, j])
                return false;
        return true;
    }

    public bool HasLost()
    {
        return incorrectAttempts >= maxIncorrectAttempts;
    }
}
