using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtDemo.Controllers
{
  [ApiController]
  [Route("/api/claims")]
  public class UserController : ControllerBase
  {
    [HttpGet]
    [Authorize]
    public UserInfo Get()
    {
      return new UserInfo()
      {
        Id = this.User.GetId(),
        Claims = this.User.Claims.Select(claim =>
        {
          return new ClaimInfo
          {
            Name = claim.Type,
            Value = claim.Value
          };
        })
      };
    }
  }
}
