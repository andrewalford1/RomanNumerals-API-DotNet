using MediatR;
using RomanNumerals_API_DotNet.Interfaces;
using RomanNumerals_API_DotNet.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RomanNumerals_API_DotNet.Queries;

public sealed class ConvertToRomanNumeralRequestHandler(
    IConversionService integerConversionService,
    IConversionRequestWriteService writeService,
    IConversionRequestReadService readService) 
    : IRequestHandler<ConvertToRomanNumeralRequest, ConversionResult>
{
    public async Task<ConversionResult> Handle(
        ConvertToRomanNumeralRequest request,
        CancellationToken cancellationToken)
    {
        await writeService.AddConversionRequest(
            request.Number,
            request.Timestamp,
            cancellationToken);

        var conversions = await readService.GetRecentConversions(TimeSpan.FromMinutes(2), cancellationToken);
        var topTen = await readService.GetTopConversions(10, cancellationToken);

        return integerConversionService.ToRomanNumerals(request.Number);
    }
}
