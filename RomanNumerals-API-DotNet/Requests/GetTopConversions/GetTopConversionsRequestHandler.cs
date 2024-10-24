using MediatR;
using RomanNumerals_API_DotNet.Interfaces;
using RomanNumerals_API_DotNet.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RomanNumerals_API_DotNet.Requests.GetTopConversions;

public sealed class GetTopConversionsRequestHandler(
    IConversionRequestReadService readService)
    : IRequestHandler<GetTopConversionsRequest, ICollection<ConversionResult>>
{
    public async Task<ICollection<ConversionResult>> Handle(
        GetTopConversionsRequest request,
        CancellationToken cancellationToken)
    {
        return await readService.GetTopConversions(
            request.Take, cancellationToken); 
    }
}