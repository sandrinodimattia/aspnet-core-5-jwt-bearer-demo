using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace JwtDemo
{
  public class Startup
  {
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();

      // Configure JWT authentication.
      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearerConfiguration(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"]);

      // Create an authorization policy for each scope supported by my API.
      services.AddAuthorization(options =>
      {
        var scopes = new[] { "read:billing_settings", "update:billing_settings", "read:customers", "read:files" };
        Array.ForEach(scopes, scope =>
          options.AddPolicy(scope, policy => policy.Requirements.Add(new ScopeRequirement(_configuration["Jwt:Issuer"], scope)))
        );
      });

      // Register our authorization handler.
      services.AddSingleton<IAuthorizationHandler, RequireScopeHandler>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();
      app.UseAuthentication();
      app.UseAuthorization();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
