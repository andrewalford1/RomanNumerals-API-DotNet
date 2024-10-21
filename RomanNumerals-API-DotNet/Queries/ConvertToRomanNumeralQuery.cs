using System.ComponentModel.DataAnnotations;

namespace RomanNumerals_API_DotNet.Queries
{
    public sealed class ConvertToRomanNumeralQuery
    {
        [Required]
        [Range(1, 3999, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Number { get; set; }
    }
}
