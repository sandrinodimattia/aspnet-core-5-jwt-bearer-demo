using System.Text.Json.Serialization;

namespace JwtDemo
{
  public class BillingSettings
  {
    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("state")]
    public string State { get; set; }

    [JsonPropertyName("street")]
    public string Street { get; set; }

    [JsonPropertyName("vat_number")]
    public string VATNumber { get; set; }
  }
}
