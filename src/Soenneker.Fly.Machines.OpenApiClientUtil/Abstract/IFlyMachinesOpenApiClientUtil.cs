using Soenneker.Fly.Machines.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Fly.Machines.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IFlyMachinesOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<FlyMachinesOpenApiClient> Get(CancellationToken cancellationToken = default);
}
