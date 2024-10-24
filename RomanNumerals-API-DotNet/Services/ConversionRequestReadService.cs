using Microsoft.EntityFrameworkCore;
using RomanNumerals_API_DotNet.DAL;
using RomanNumerals_API_DotNet.Interfaces;
using RomanNumerals_API_DotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RomanNumerals_API_DotNet.Services;

public sealed class ConversionRequestReadService(
    IConversionService conversionService,
    RomanNumeralsDbContext dbContext) : IConversionRequestReadService
{
    public async Task<ICollection<ConversionResult>> GetRecentConversions(
        TimeSpan within, CancellationToken cancellationToken = default)
    {
        DateTime cutOffDate = DateTime.UtcNow.Subtract(within);

        return await dbContext.ConversionRequests
            .Where(x => x.TimeRequested >= cutOffDate)
            .OrderByDescending(x => x.TimeRequested)
            .Select(x => conversionService.ToRomanNumerals(x.ArebicNumeral))
            .ToListAsync(cancellationToken);
    }

    public async Task<ICollection<ConversionResult>> GetTopConversions(
        int take, CancellationToken cancellationToken = default)
    {
        return await dbContext.ConversionRequests
            .GroupBy(x => x.ArebicNumeral)
            .OrderByDescending(x => x.Count())
            .ThenBy(x => x.Key)
            .Take(take)
            .Select(x => conversionService.ToRomanNumerals(x.Key))
            .ToListAsync(cancellationToken);
    }
}
