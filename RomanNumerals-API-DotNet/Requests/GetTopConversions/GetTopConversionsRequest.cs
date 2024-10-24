using MediatR;
using RomanNumerals_API_DotNet.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RomanNumerals_API_DotNet.Requests.GetTopConversions;

public sealed class GetTopConversionsRequest :
    IRequest<ICollection<ConversionResult>>
{
    [Required]
    public int Take { get; set; }
}
