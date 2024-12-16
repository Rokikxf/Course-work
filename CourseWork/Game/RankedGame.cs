namespace CourseWork;

public class RankedGame: Game
{
    public RankedGame(IGameService gameService) : base(gameService)
    {
    }

    public override int CalculateRating()
    {
        Random random = new Random();
        return random.Next(24, 27);
    }
}