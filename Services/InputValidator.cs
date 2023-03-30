namespace QuickBiteBE.Services;

public class InputValidator
{
    public static void ValidateIfNumericInputIsGreaterThan0(int input)
    {
        if (input <= 0)
        {
            throw new ArgumentException("Input value was not correct.");
        }
    }

    public static void ValidateStringInputHasValue(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentException("Input value was not correct.");
        }
    }
}