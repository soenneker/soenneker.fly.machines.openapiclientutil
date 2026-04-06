using Soenneker.Fly.Machines.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Fly.Machines.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class FlyMachinesOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly IFlyMachinesOpenApiClientUtil _openapiclientutil;

    public FlyMachinesOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<IFlyMachinesOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
