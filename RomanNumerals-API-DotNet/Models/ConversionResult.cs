namespace RomanNumerals_API_DotNet.Models;

public sealed record ConversionResult(int ArebicNumeral, string RomanNumeral)
{
    public override string ToString()
    {
        return $"{ArebicNumeral} => {RomanNumeral}";
    }
}