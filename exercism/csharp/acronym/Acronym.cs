#pragma warning disable CA1050 // Declare types in namespaces
using System.Text;
using System.Text.RegularExpressions;

public static partial class Acronym
#pragma warning restore CA1050 // Declare types in namespaces
{
    public static string Abbreviate(string phrase)
    {
        // Replace hyphens with spaces (since they are also word separators)
        phrase = phrase.Replace('-', ' ');

        // Remove all punctuation except letters and spaces
        phrase = NonLetterRegex().Replace(phrase, "");

        // Split into words and take the first letter of each
        var letters = phrase
            .Split([' '], StringSplitOptions.RemoveEmptyEntries)
            .Select(word => char.ToUpper(word[0]));

        // Join the letters to form the acronym
        return string.Concat(letters);
    }

    [GeneratedRegex(@"[^a-zA-Z\s]")]
    private static partial Regex NonLetterRegex();
}