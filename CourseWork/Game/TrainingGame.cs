namespace CourseWork;

public class TrainingGame:Game
{
    public TrainingGame(IGameService gameService) : base(gameService)
    {
    }

    public override int CalculateRating()
    {
        return 0;
    }
}