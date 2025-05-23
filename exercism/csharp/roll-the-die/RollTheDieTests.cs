using Exercism.Tests;

#pragma warning disable CA1050 // Declare types in namespaces
public class RollTheDieTests
#pragma warning restore CA1050 // Declare types in namespaces
{
    [Fact]
    [Task(1)]
    public void RollDie()
    {
        var player = new Player();
        for (var i = 0; i < 100; i++)
        {
            Assert.InRange(player.RollDie(), 1, 18);
        }
    }

    [Fact]
    [Task(2)]
    public void GenerateSpellStrength()
    {
        var player = new Player();
        var strength = player.GenerateSpellStrength();
        Assert.InRange(strength, 0.0, 100.0);
    }
}
