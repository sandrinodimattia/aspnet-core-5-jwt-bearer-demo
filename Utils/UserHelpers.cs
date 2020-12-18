using System.Security.Claims;

public static class UserHelpers
{
  public static string GetId(this ClaimsPrincipal principal)
  {
    var userIdClaim = principal.FindFirst(c => c.Type == ClaimTypes.NameIdentifier) ?? principal.FindFirst(c => c.Type == "sub");
    if (userIdClaim != null && !string.IsNullOrEmpty(userIdClaim.Value))
    {
      return userIdClaim.Value;
    }

    return null;
  }
}