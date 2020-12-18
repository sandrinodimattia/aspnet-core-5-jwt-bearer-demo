using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtDemo.Controllers
{
  [ApiController]
  [Route("/api/billing")]
  public class BillingController : ControllerBase
  {
    [HttpGet]
    [Route("settings")]
    [Authorize("read:billing_settings")]
    public BillingSettings Get()
    {
      return new BillingSettings()
      {
        Country = "United States",
        State = "Washington",
        Street = "Microsoft Road 1",
        VATNumber = "987654321"
      };
    }
  }
}
