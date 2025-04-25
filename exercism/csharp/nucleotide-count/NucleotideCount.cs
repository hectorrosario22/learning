#pragma warning disable CA1050 // Declare types in namespaces
public static class NucleotideCount
#pragma warning restore CA1050 // Declare types in namespaces
{
    public static IDictionary<char, int> Count(string sequence)
    {
        var sequenceCount = new Dictionary<char, int>
        {
            ['A'] = 0,
            ['C'] = 0,
            ['G'] = 0,
            ['T'] = 0,
        };

        foreach (var letter in sequence)
        {
            if (!sequenceCount.TryGetValue(letter, out var value))
            {
                throw new ArgumentException("Invalid DNA");
            }

            sequenceCount[letter] = ++value;
        }

        return sequenceCount;
    }
}