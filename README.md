[![](https://img.shields.io/nuget/v/soenneker.clay.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.clay.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.clay.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.clay.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.clay.httpclients/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.clay.httpclients/actions/workflows/codeql.yml)
[![](https://img.shields.io/nuget/dt/soenneker.clay.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.clay.httpclients/)

# Soenneker.Clay.HttpClients

A cached, authenticated `HttpClient` for Clay's public API.

## Installation

```bash
dotnet add package Soenneker.Clay.HttpClients
```

## Configuration

```json
{
  "Clay": {
    "ApiKey": "your-api-key"
  }
}
```

The key is sent in Clay's `clay-api-key` header. `Clay:ClientBaseUrl`, `Clay:AuthHeaderName`, and `Clay:AuthHeaderValueTemplate` can override the transport defaults for a compatible gateway.

## Registration and usage

```csharp
using Soenneker.Clay.HttpClients.Abstract;
using Soenneker.Clay.HttpClients.Registrars;

services.AddClayOpenApiHttpClientAsSingleton();

public sealed class ClayService(IClayOpenApiHttpClient clientProvider)
{
    public async Task<string> GetCurrentAccount(CancellationToken cancellationToken)
    {
        HttpClient client = await clientProvider.Get(cancellationToken);
        return await client.GetStringAsync("me", cancellationToken);
    }
}
```

The provider owns its named cache entry. Disposing it removes the entry and disposes the cached client. Prefer singleton registration for normal application-wide use.
