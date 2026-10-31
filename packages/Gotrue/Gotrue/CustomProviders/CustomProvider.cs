using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Supabase.Gotrue.CustomProviders;

/// <summary>
///     Represents a custom provider for authentication.
/// </summary>
public class CustomProvider
{
    /// <summary>
    /// Unique identifier (UUID)
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Provider Type
    /// </summary>
    [JsonPropertyName("provider_type")]
    public string? ProviderType { get; set; }

    /// <summary>
    /// Provider identifier, e.g. custom:myprovider
    /// </summary>
    [JsonPropertyName("identifier")]
    public string? Identifier { get; set; }

    /// <summary>
    /// Human readable name
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// OAuth client ID
    /// </summary>
    [JsonPropertyName("client_id")]
    public string? ClientId { get; set; }

    /// <summary>
    /// Additional client IDs accepted during token validation
    /// </summary>
    [JsonPropertyName("acceptable_client_ids")]
    public List<string>? AcceptableClientId { get; set; }

    /// <summary>
    /// OAuth scope authorization.
    /// </summary>
    [JsonPropertyName("scopes")]
    public List<string>? Scopes { get; set; }

    /// <summary>
    /// Allowlist of raw identity provider claim keys to copy verbatim
    /// </summary>
    [JsonPropertyName("custom_claims_allowlist")]
    public List<string> CustomClaimsAllowlist { get; set; }

    /// <summary>
    /// Whether PKCE is enabled
    /// </summary>
    [JsonPropertyName("pkce_enabled")]
    public bool? PkceEnabled { get; set; }

    /// <summary>
    /// Mapping of provider attibutes to Supabase user attribute.
    /// </summary>
    [JsonPropertyName("attribute_mapping")]
    public Dictionary<string, object>? AttributeMapping { get; set; }

    /// <summary>
    /// Additional paramaters sent with the authorization request.
    /// </summary>
    [JsonPropertyName("authorization_params")]
    public Dictionary<string, string>? AuthorizationParameter { get; set; }

    /// <summary>
    /// Whether the provider is enabled.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Whether email is optional for this provider
    /// </summary>
    [JsonPropertyName("email_optional")]
    public bool? EmailOptional { get; set; }

    /// <summary>
    /// OIDC issuer URL
    /// </summary>
    [JsonPropertyName("issuer")]
    public string? Issuer { get; set; }

    /// <summary>
    /// OIDC discovery URL
    /// </summary>
    [JsonPropertyName("discovery_url")]
    public string? DiscoveryUrl { get; set; }

    /// <summary>
    /// Whether to skip nonce check
    /// </summary>
    [JsonPropertyName("skip_nonce_check")]
    public bool? SkipNonceCheck { get; set; }

    /// <summary>
    /// OAuth2 authorization url
    /// </summary>
    [JsonPropertyName("authorization_url")]
    public string? AuthorizationUrl { get; set; }

    /// <summary>OAuth2 token URL.</summary>
    [JsonPropertyName("token_url")]
    public string? TokenUrl { get; set; }

    /// <summary>OAuth2 userinfo URL.</summary>
    [JsonPropertyName("userinfo_url")]
    public string? UserinfoUrl { get; set; }

    /// <summary>JWKS URI for token verification.</summary>
    [JsonPropertyName("jwks_uri")]
    public string? JwksUri { get; set; }

    /// <summary>
    /// OIDC discovery document (OIDC providers only)
    /// </summary>
    public OIDCDiscoveryDocument? DiscoveryDocument { get; set; }

    /// <summary>Timestamp when the provider was created.</summary>
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>Timestamp when the provider was last updated.</summary>
    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}
