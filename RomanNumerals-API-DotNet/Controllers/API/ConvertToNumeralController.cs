using MediatR;
using Microsoft.AspNetCore.Mvc;
using RomanNumerals_API_DotNet.Models;
using RomanNumerals_API_DotNet.Requests.ConvertToRomanNumeral;
using System.Threading;
using System.Threading.Tasks;

namespace RomanNumerals_API_DotNet.Controllers.API;

[Route("api/[controller]")]
[ApiController]
public sealed class ConvertToNumeralController(IMediator mediator) : ControllerBase
{
    public async Task<string> Get(
        [FromQuery] ConvertToRomanNumeralRequest request,
        CancellationToken cancellationToken)
    {
        ConversionResult conversion = await mediator
            .Send(request, cancellationToken);
        return conversion.ToString();
    }
}