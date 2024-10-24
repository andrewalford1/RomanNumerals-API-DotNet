using RomanNumerals_API_DotNet.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RomanNumerals_API_DotNet.Interfaces;

public interface IConversionRequestReadService
{
    Task<ICollection<ConversionResult>> GetRecentConversions(
        TimeSpan within, CancellationToken cancellationToken = default);

    Task<ICollection<ConversionResult>> GetTopConversions(
        int take, CancellationToken cancellationToken = default);
}
