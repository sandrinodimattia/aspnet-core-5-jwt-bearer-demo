using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JwtDemo
{
  public class UserInfo
  {
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("claims")]
    public IEnumerable<ClaimInfo> Claims { get; set; }
  }

  public class ClaimInfo
  {
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("value")]
    public string Value { get; set; }
  }
}
