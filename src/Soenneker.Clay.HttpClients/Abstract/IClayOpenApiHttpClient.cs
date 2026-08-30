using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.Clay.HttpClients.Abstract;

/// <summary>
/// Provides a cached <see cref="HttpClient"/> configured for Clay's public API.
/// </summary>
public interface IClayOpenApiHttpClient: IDisposable, IAsyncDisposable
{
    /// <summary>Gets the configured client.</summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the configured client.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
