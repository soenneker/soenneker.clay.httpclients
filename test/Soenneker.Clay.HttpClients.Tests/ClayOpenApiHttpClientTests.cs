using Soenneker.Clay.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Clay.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class ClayOpenApiHttpClientTests : HostedUnitTest
{
    private readonly IClayOpenApiHttpClient _httpclient;

    public ClayOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<IClayOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
