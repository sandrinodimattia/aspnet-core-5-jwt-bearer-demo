# JWT Bearer Authentication and Authorization for ASP.NET Core 5

Sample API which shows how to configure JWT Bearer Authentication and Authorization using an Open ID Connect / OAuth 2 Authorization Server (like Auth0, Okta, Identity Server, ...).

This sample API comes with 2 endpoints:

- `http://localhost:5001/api/claims` which requires the call to be authenticated
- `http://localhost:5001/api/billing/settings` which requires the call to be authenticated and the presence of a `read:billing_settings` scope

More info is available in this blog post: https://sandrino.dev/blog/aspnet-core-5-jwt-authorization

## Running on MacOSX

You'll need to install the SDK for VS Code first:

https://dotnet.microsoft.com/download/dotnet-core/sdk-for-vs-code

The following command will help you solve any issues related to VS Code not being able to find the .NET SDK:

```bash
sudo ln -s /usr/local/share/dotnet/dotnet /usr/local/bin/dotnet
```

### VS Code Extensions

Consider installing the following extensions for VS Code for a better editing experience:

- C#
- NuGet Gallery
- NuGet Package Manager
