using System;
using System.Threading;
using System.Threading.Tasks;

namespace RomanNumerals_API_DotNet.Interfaces;

public interface IConversionRequestWriteService
{
    Task AddConversionRequest(
        int arebicNumeral,
        DateTime timeRequested,
        CancellationToken cancellationToken = default);
}
