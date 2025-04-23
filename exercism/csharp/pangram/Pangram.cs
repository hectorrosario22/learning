#pragma warning disable CA1050 // Declare types in namespaces
public static class Pangram
#pragma warning restore CA1050 // Declare types in namespaces
{
    public static bool IsPangram(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return false;

        input = input.ToLower();
        HashSet<char> letters =
        [
            'a', 'b', 'c', 'd', 'e',
            'f', 'g', 'h', 'i', 'j',
            'k', 'l', 'm', 'n', 'o',
            'p', 'q', 'r', 's', 't',
            'u', 'v', 'w', 'x', 'y',
            'z'
        ];

        for (var i = 0; i < input.Length; i++)
        {
            if (letters.Contains(input[i]))
            {
                letters.Remove(input[i]);
            }

            if (letters.Count == 0) break;
        }

        return letters.Count == 0;
    }
}
