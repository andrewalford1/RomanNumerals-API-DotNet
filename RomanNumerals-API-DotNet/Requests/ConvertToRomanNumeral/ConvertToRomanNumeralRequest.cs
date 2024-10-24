using MediatR;
using RomanNumerals_API_DotNet.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace RomanNumerals_API_DotNet.Requests.ConvertToRomanNumeral
{
    public sealed class ConvertToRomanNumeralRequest : IRequest<ConversionResult>
    {
        [Required]
        [Range(1, 3999, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public required int Number { get; set; }

        public DateTime Timestamp { get; } = DateTime.UtcNow;
    }
}
