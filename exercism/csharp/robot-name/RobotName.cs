#pragma warning disable CA1050 // Declare types in namespaces
using System.Text;

public class Robot
#pragma warning restore CA1050 // Declare types in namespaces
{
    private static readonly HashSet<string> _usedRobotNames = [];

    private string? _name;
    public string Name
    {
        get
        {
            _name ??= GenerateUniqueName();
            return _name;
        }
    }

    public void Reset() => _name = null;

    private static string GenerateUniqueName()
    {
        var allowedLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        StringBuilder robotNameBuilder = new();
        robotNameBuilder.Append(allowedLetters[Random.Shared.Next(allowedLetters.Length)]);
        robotNameBuilder.Append(allowedLetters[Random.Shared.Next(allowedLetters.Length)]);
        robotNameBuilder.Append(Random.Shared.Next(100, 1000));

        var robotName = robotNameBuilder.ToString();
        if (_usedRobotNames.Contains(robotName))
        {
            return GenerateUniqueName();
        }

        _usedRobotNames.Add(robotName);
        return robotName;
    }
}