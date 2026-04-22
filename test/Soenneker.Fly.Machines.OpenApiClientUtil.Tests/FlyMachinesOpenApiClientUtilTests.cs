using Soenneker.Fly.Machines.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Fly.Machines.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class FlyMachinesOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IFlyMachinesOpenApiClientUtil _openapiclientutil;

    public FlyMachinesOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IFlyMachinesOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
