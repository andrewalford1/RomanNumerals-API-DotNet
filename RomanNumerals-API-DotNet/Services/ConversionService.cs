using System.Collections.Generic;
using System.Text;
using RomanNumerals_API_DotNet.Interfaces;
using RomanNumerals_API_DotNet.Models;

namespace RomanNumerals_API_DotNet.Services;

public class ConversionService : IConversionService
{
    private static readonly IReadOnlyDictionary<int, string> _conversionTable 
        = new Dictionary<int, string>()
    {
            { 1000, "M" },
            { 900, "CM" },
            { 500, "D" },
            { 400, "CD" },
            { 100, "C" },
            { 90, "XC" },
            { 50, "L" },
            { 40, "XL" },
            { 10, "X" },
            { 9, "IX" },
            { 5, "V" },
            { 4, "IV" },
            { 1, "I" }
    };

    public ConversionResult ToRomanNumerals(int input)
    {

        var romanNumeralBuilder = new StringBuilder();

        foreach (var conversion in _conversionTable) { 
            while (input >= conversion.Key)
            {
                romanNumeralBuilder.Append(conversion.Value);
                input -= conversion.Key;
            }
        }

        return new ConversionResult(input, romanNumeralBuilder.ToString());
    }


}
