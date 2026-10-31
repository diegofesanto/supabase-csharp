using System.Text.Json;
using System.Text.Json.Serialization;
using Supabase.Core.Attributes;

namespace Supabase.Gotrue.CustomProviders;

/// <summary>
/// Represents the type of custom authentication provider
/// </summary>
public enum CustomProviderType
{
    /// <summary>
    /// OAuth 2 type
    /// </summary>
    [MapTo("oauth2")]
    OAuth2,

    /// <summary>
    /// OIDC type
    /// </summary>
    [MapTo("oidc")]
    OIDC,
}
