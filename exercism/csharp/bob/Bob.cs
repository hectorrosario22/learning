using System;

#pragma warning disable CA1050 // Declare types in namespaces
public static class Bob
#pragma warning restore CA1050 // Declare types in namespaces
{
    public static string Response(string statement)
    {
        if (string.IsNullOrWhiteSpace(statement))
        {
            return "Fine. Be that way!";
        }
        
        if (statement.IsAQuestion() && !statement.AreAllCapitals())
        {
            return "Sure.";
        }
    
        if (statement.AreAllCapitals() && !statement.IsAQuestion())
        {
            return "Whoa, chill out!";
        }
    
        if (statement.AreAllCapitals() && statement.IsAQuestion())
        {
            return "Calm down, I know what I'm doing!";
        }
    
        return "Whatever.";
    }

    private static bool IsAQuestion(this string statement)
        => statement.TrimEnd().EndsWith('?');

    private static bool AreAllCapitals(this string statement)
    {
        var hasLetters = false;
        for (var i = 0; i < statement.Length; i++)
        {
            var current = statement[i];
            if (char.IsLetter(current))
            {
                hasLetters = true;
                if (!char.IsUpper(current)) return false;
            }
        }
        
        return hasLetters;
    }
}