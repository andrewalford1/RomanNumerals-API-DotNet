using System;

namespace RomanNumerals_API_DotNet.DAL.Entities;

public sealed class ConversionRequestEntity
{
    public Guid Id { get; set; }

    public int ArebicValue { get; set; }

    public int TimesRequested { get; set; }
}