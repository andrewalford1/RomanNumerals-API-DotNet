using MediatR;
using Microsoft.AspNetCore.Mvc;
using RomanNumerals_API_DotNet.Requests.GetRecentConversions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RomanNumerals_API_DotNet.Controllers.API;

[Route("api/[controller]")]
[ApiController]
public class RecentConversionsController(IMediator mediator) : ControllerBase
{
    public async Task<ICollection<string>> Get(
        CancellationToken cancellationToken)
    {
        // Note: In a real system I would expect this 
        // to be a defined constant, or be defined in the 
        // front-end.
        TimeSpan within = TimeSpan.FromHours(1);

        var recentConversions = await mediator.Send(
            new GetRecentConversionsRequest 
            { 
                Within = within
            },
            cancellationToken);

        return recentConversions.Select(x => x.ToString()).ToList();
    }
}
