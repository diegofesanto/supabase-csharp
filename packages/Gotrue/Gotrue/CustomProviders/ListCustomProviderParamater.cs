using System.Text.Json.Serialization;

namespace Supabase.Gotrue.CustomProviders;

/// <summary>
/// Parameters for listing custom providers
/// </summary>
public record class ListCustomProviderParameter
{
    /// <summary>
    /// Filter by provider type
    /// </summary>
    [JsonPropertyName("type")]
    public CustomProviderType Type { get; set; }
}
