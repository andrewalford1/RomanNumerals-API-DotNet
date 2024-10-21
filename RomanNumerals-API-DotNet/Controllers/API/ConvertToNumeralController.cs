using Microsoft.AspNetCore.Mvc;
using RomanNumerals_API_DotNet.Queries;

namespace RomanNumerals_API_DotNet.Controllers.API;

[Route("api/[controller]")]
[ApiController]
public sealed class ConvertToNumeralController : ControllerBase
{
    public string Get([FromQuery] ConvertToRomanNumeralQuery query)
    {
        // TODO, convert to Roman numeral.
        return query.Number.ToString();
    }
}