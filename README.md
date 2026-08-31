[![](https://img.shields.io/nuget/v/soenneker.fly.machines.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.fly.machines.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.fly.machines.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.fly.machines.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.fly.machines.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.fly.machines.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.fly.machines.openapiclientutil/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.fly.machines.openapiclientutil/actions/workflows/codeql.yml)

# Soenneker.Fly.Machines.OpenApiClientUtil

Provides lazy, cached access to the generated Fly Machines API client.

## Installation

```bash
dotnet add package Soenneker.Fly.Machines.OpenApiClientUtil
```

## Configure and register

```json
{
  "Fly": {
    "ApiKey": "your-fly-api-token"
  }
}
```

```csharp
using Soenneker.Fly.Machines.OpenApiClientUtil.Registrars;

services.AddFlyMachinesOpenApiClientUtilAsScoped();
```

## Use the client

```csharp
using Soenneker.Fly.Machines.OpenApiClientUtil.Abstract;

public sealed class FlyAppReader(IFlyMachinesOpenApiClientUtil clients)
{
    public async Task Read(CancellationToken cancellationToken)
    {
        var client = await clients.Get(cancellationToken);
        var apps = await client.V1.Apps.GetAsync(
            cancellationToken: cancellationToken);
    }
}
```

The HTTP provider owns bearer authentication and the root API address. The generated request builders add `/v1`; the client does not add a second authorization header.

Use `AddFlyMachinesOpenApiClientUtilAsSingleton()` when the application should share one generated client. A scoped utility borrows the singleton HTTP provider, so disposing the scope does not destroy the shared transport.
