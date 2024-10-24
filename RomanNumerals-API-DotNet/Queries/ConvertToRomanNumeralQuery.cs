using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace RomanNumerals_API_DotNet.Queries
{
    public sealed class ConvertToRomanNumeralQuery : IRequest<string>
    {
        [Required]
        [Range(1, 3999, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public required int Number { get; set; }

        public DateTime Timestamp { get; } = DateTime.UtcNow;
    }
}
