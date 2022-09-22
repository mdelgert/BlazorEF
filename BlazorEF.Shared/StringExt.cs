namespace BlazorEF.Shared;

public static class StringExt
{
    public static string? Truncate(this string? value, int maxLength, string truncationSuffix = "…")
    {
        return value?.Length > maxLength
            ? value.Substring(0, maxLength) + truncationSuffix
            : value;
    }
}

//https://stackoverflow.com/questions/2776673/how-do-i-truncate-a-net-string
