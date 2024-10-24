using RomanNumerals_API_DotNet.Models;

namespace RomanNumerals_API_DotNet.Interfaces;

public interface IConversionService
{
    ConversionResult ToRomanNumerals(int input);
}
