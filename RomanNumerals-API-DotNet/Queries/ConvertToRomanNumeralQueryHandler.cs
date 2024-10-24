using MediatR;
using Microsoft.EntityFrameworkCore;
using RomanNumerals_API_DotNet.DAL;
using RomanNumerals_API_DotNet.DAL.Entities;
using RomanNumerals_API_DotNet.Services;
using System.Threading;
using System.Threading.Tasks;

namespace RomanNumerals_API_DotNet.Queries;

public sealed class ConvertToRomanNumeralQueryHandler(
    IIntegerConversionService integerConversionService,
    RomanNumeralsDbContext dbContext) 
    : IRequestHandler<ConvertToRomanNumeralQuery, string>
{
    public async Task<string> Handle(
        ConvertToRomanNumeralQuery request,
        CancellationToken cancellationToken)
    {

        dbContext.ConversionRequests.Add(new ConversionRequestEntity
        {
            ArebicValue = request.Number,
            TimesRequested = 1
        });

        await dbContext.SaveChangesAsync(cancellationToken);

        var requests = await dbContext.ConversionRequests.ToListAsync(cancellationToken);

        return integerConversionService.ToRomanNumerals(request.Number);
    }
}
