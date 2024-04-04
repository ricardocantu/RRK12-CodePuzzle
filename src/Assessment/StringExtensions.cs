namespace Assessment;

public static class StringExtensions
{
    public static string GetStringBetweenIndexes(this string input, int startIndex, int endIndex)
    {
        if (endIndex < startIndex || startIndex < 0 || endIndex > input.Length)
        {
            return string.Empty;
        }

        int length = endIndex - startIndex;
        return input.Substring(startIndex, length);
    }
}
