#pragma warning disable CA1050 // Declare types in namespaces
using System.Text;

public static class ReverseString
#pragma warning restore CA1050 // Declare types in namespaces
{
    public static string Reverse(string input)
    {
        StringBuilder sb = new();
        for (int i = input.Length - 1; i >= 0; i--)
        {
            sb.Append(input[i]);
        }

        return sb.ToString();
    }
}