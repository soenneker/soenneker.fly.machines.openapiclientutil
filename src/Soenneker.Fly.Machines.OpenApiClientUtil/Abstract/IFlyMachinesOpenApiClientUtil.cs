using Soenneker.Fly.Machines.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Fly.Machines.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides lazy access to a cached Fly Machines API client.
/// </summary>
public interface IFlyMachinesOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the cached Fly Machines API client, creating it on first use.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The generated Fly Machines API client.</returns>
    ValueTask<FlyMachinesOpenApiClient> Get(CancellationToken cancellationToken = default);
}
