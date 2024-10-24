using RomanNumerals_API_DotNet.DAL;
using RomanNumerals_API_DotNet.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RomanNumerals_API_DotNet.Services;

public sealed class ConversionRequestWriteService(
    RomanNumeralsDbContext dbContext)
    : IConversionRequestWriteService
{
    public async Task AddConversionRequest(
        int arebicNumeral,
        DateTime timeRequested,
        CancellationToken cancellationToken = default)
    {
        await dbContext.ConversionRequests.AddAsync(new DAL.Entities.ConversionRequestEntity
        {
            ArebicNumeral = arebicNumeral,
            TimeRequested = timeRequested,
        }, cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
