using System.Text;

#pragma warning disable CA1050 // Declare types in namespaces
public static class RotationalCipher
#pragma warning restore CA1050 // Declare types in namespaces
{
    public static string Rotate(string text, int shiftKey)
    {
        StringBuilder sb = new();

        foreach (var character in text)
        {
            if (char.IsLetter(character))
            {
                var baseChar = char.IsUpper(character) ? 'A' : 'a';
                var rotatedPosition = ((character + shiftKey - baseChar) % 26) + baseChar;
                var rotatedLetter = (char)rotatedPosition;
                sb.Append(rotatedLetter);
                continue;
            }

            sb.Append(character);
        }

        return sb.ToString();
    }
}