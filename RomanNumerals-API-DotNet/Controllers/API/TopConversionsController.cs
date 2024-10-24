using MediatR;
using Microsoft.AspNetCore.Mvc;
using RomanNumerals_API_DotNet.Requests.GetTopConversions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RomanNumerals_API_DotNet.Controllers.API;

[Route("api/[controller]")]
[ApiController]
public class TopConversionsController(IMediator mediator) : ControllerBase
{
    public async Task<ICollection<string>> Get(
        CancellationToken cancellationToken)
    {
        // Note: In a real system I would expect this 
        // to be a defined constant, or be defined in the 
        // front-end.
        int take = 10;

        var topConversions = await mediator.Send(
            new GetTopConversionsRequest
            {
                Take = take,
            },
            cancellationToken);

        return topConversions.Select(x => x.ToString()).ToList();
    }
}