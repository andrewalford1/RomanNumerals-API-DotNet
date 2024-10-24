using MediatR;
using Microsoft.AspNetCore.Mvc;
using RomanNumerals_API_DotNet.Models;
using RomanNumerals_API_DotNet.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace RomanNumerals_API_DotNet.Controllers.API;

[Route("api/[controller]")]
[ApiController]
public sealed class ConvertToNumeralController(IMediator mediator) : ControllerBase
{
    public async Task<string> Get(
        [FromQuery] ConvertToRomanNumeralQuery query,
        CancellationToken cancellationToken)
    {
        ConversionResult conversion = await mediator
            .Send(query, cancellationToken);
        return conversion.ToString();
    }
}