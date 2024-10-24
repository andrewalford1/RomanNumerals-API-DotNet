using MediatR;
using RomanNumerals_API_DotNet.Services;
using System.Threading;
using System.Threading.Tasks;

namespace RomanNumerals_API_DotNet.Queries;

public sealed class ConvertToRomanNumeralQueryHandler(
    IIntegerConversionService integerConversionService) 
    : IRequestHandler<ConvertToRomanNumeralQuery, string>
{
    public Task<string> Handle(
        ConvertToRomanNumeralQuery request,
        CancellationToken cancellationToken)
    {
        return Task.FromResult(integerConversionService.ToRomanNumerals(request.Number));
    }
}
