using MediatR;
using RomanNumerals_API_DotNet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RomanNumerals_API_DotNet.Requests.GetRecentConversions;

public sealed class GetRecentConversionsRequest : 
    IRequest<ICollection<ConversionResult>>
{
    [Required]
    public TimeSpan Within { get; set; }
}
