using System;

namespace RomanNumerals_API_DotNet.DAL.Entities;

public sealed class ConversionRequestEntity
{
    public Guid Id { get; set; }

    public int ArebicNumeral { get; set; }

    public DateTime TimeRequested { get; set; }
}