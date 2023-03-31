namespace QuickBiteBE.Services;

public static class InputValidator
{
    public static void ValidateIfNumericInputIsGreaterThan0(int input, string message)
    {
        if (input <= 0)
            throw new ArgumentException(message);
    }

    public static void ValidateIfNumericInputIsAtLeast0(int input, string message)
    {
        if (input < 0)
            throw new ArgumentException(message);
    }
    
    public static void ValidateStringInputHasValue(string input, string message)
    {
        if (string.IsNullOrEmpty(input))
            throw new ArgumentException(message);
    }
}