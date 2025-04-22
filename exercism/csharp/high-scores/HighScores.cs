#pragma warning disable CA1050 // Declare types in namespaces
public class HighScores(List<int> list)
#pragma warning restore CA1050 // Declare types in namespaces
{
    public List<int> Scores() => list;

    public int Latest() => list.Last();

    public int PersonalBest() => list.Max();

    public List<int> PersonalTopThree() => [.. list.OrderDescending().Take(3)];
}