using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.Fly.Machines.HttpClients.Abstract;
using Soenneker.Fly.Machines.OpenApiClientUtil.Abstract;
using Soenneker.Fly.Machines.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Fly.Machines.OpenApiClientUtil;

/// <inheritdoc cref="IFlyMachinesOpenApiClientUtil" />
public sealed class FlyMachinesOpenApiClientUtil : IFlyMachinesOpenApiClientUtil
{
    private readonly AsyncSingleton<FlyMachinesOpenApiClient> _client;

    public FlyMachinesOpenApiClientUtil(IFlyMachinesOpenApiHttpClient httpClientUtil)
    {
        _client = new AsyncSingleton<FlyMachinesOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);

            return new FlyMachinesOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<FlyMachinesOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
