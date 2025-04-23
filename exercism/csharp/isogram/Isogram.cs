#pragma warning disable CA1050 // Declare types in namespaces
public static class Isogram
#pragma warning restore CA1050 // Declare types in namespaces
{
    public static bool IsIsogram(string word)
    {
        var seen = new HashSet<char>();
        foreach (var character in word)
        {
            if (!char.IsLetter(character)) continue;
            
            var standarizeCharacter = char.ToLower(character);
            if (seen.Contains(standarizeCharacter)) return false;

            seen.Add(standarizeCharacter);
        }

        return true;
    }
}
