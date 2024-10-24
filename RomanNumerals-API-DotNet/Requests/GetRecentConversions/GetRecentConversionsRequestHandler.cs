using MediatR;
using RomanNumerals_API_DotNet.Interfaces;
using RomanNumerals_API_DotNet.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RomanNumerals_API_DotNet.Requests.GetRecentConversions;

public sealed class GetRecentConversionsRequestHandler(
    IConversionRequestReadService readService)
    : IRequestHandler<GetRecentConversionsRequest, ICollection<ConversionResult>>
{
    public async Task<ICollection<ConversionResult>> Handle(
        GetRecentConversionsRequest request, CancellationToken cancellationToken)
    {
        return await readService.GetRecentConversions(
            request.Within,
            cancellationToken);
    }
}
