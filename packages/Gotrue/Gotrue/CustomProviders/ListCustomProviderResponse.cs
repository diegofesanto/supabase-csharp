using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Supabase.Gotrue.CustomProviders;

/// <summary>
/// Response type for Custom Providers
/// </summary>
public class ListCustomProviderResponse
{
    /// <summary>
    /// Response
    /// </summary>
    [JsonPropertyName("providers")]
    public List<CustomProvider>? Providers { get; set; }
}
