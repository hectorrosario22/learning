using System;

#pragma warning disable CA1050 // Declare types in namespaces
public class Player
#pragma warning restore CA1050 // Declare types in namespaces
{
    private readonly Random _rnd = new();
    
    public int RollDie() => _rnd.Next(1, 19);

    public double GenerateSpellStrength() => _rnd.NextDouble() * 100;
}
