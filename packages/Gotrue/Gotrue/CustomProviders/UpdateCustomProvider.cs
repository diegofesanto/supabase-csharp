using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Supabase.Gotrue.CustomProviders;

/// <summary>
/// Parameters for updating an exisint custom provider
/// All fields are optionals
/// ProviderType and Identifier are immutable and cannot be changed.
/// </summary>
public class UpdateCustomProvider
{
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
    /// OAuth client secret (write-only, not returned in response)
    /// </summary>
    [JsonPropertyName("client_secret")]
    public string? ClientSecret { get; set; }

    /// <summary>
    /// Additional client IDs accepted during token validation
    /// </summary>
    [JsonPropertyName("acceptable_client_ids")]
    public List<string>? AcceptableClientIDs { get; set; }

    /// <summary>
    /// OAuth scopes requested during authorization
    /// </summary>
    [JsonPropertyName("scopes")]
    public List<string>? Scopes { get; set; }

    /// <summary>
    /// Allowlist of raw identity provider claim keys to copy verbatim into user's
    /// </summary>
    [JsonPropertyName("custom_claims_allowlist")]
    public List<string>? CustomClaimsAllowList { get; set; }

    /// <summary>
    /// Whether PKCE is enabled
    /// </summary>
    [JsonPropertyName("pkce_enabled")]
    public bool? PkceEnabled { get; set; }

    /// <summary>
    /// Mapping of provider attributes to Supabase user attribute
    /// </summary>
    [JsonPropertyName("attribute_mapping")]
    public Dictionary<string, object>? AttributeMapping { get; set; }

    /// <summary>
    /// Additional parameters sent with the authrozation request
    /// </summary>
    [JsonPropertyName("authorization_params")]
    public Dictionary<string, string>? AuthorizationParameters { get; set; }

    /// <summary>
    /// Whether the provider is enabled
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
    /// OIDC discovery url
    /// </summary>
    [JsonPropertyName("discovery_url")]
    public string? DiscoveryUrl { get; set; }

    /// <summary>
    /// Whether to skip nonce check (OIDC)
    /// </summary>
    [JsonPropertyName("skip_nonce_check")]
    public bool? SkipNonceCheck { get; set; }

    /// <summary>
    /// OAuth2 authorization url
    /// </summary>
    [JsonPropertyName("authorization_url")]
    public string? AuthorizationUrl { get; set; }

    /// <summary>
    /// OAuth2 token URL
    /// </summary>
    [JsonPropertyName("token_url")]
    public string? TokenUrl { get; set; }

    /// <summary>
    /// OAuth2 userinfo URL
    /// </summary>
    [JsonPropertyName("userinfo_url")]
    public string? UserinfoUrl { get; set; }

    /// <summary>
    /// JWKS Uri for token verification
    /// </summary>
    [JsonPropertyName("jwks_uri")]
    public string? JwksUri { get; set; }

    public static UpdateCustomProvider From(CustomProvider provider) =>
        new()
        {
            Name = provider.Name,
            ClientId = provider.ClientId,
            AcceptableClientIDs = provider.AcceptableClientId,
            Scopes = provider.Scopes,
            CustomClaimsAllowList = provider.CustomClaimsAllowlist,
            PkceEnabled = provider.PkceEnabled,
            AttributeMapping = provider.AttributeMapping,
            AuthorizationParameters = provider.AuthorizationParameter,
            Enabled = provider.Enabled,
            EmailOptional = provider.EmailOptional,
            Issuer = provider.Issuer,
            DiscoveryUrl = provider.DiscoveryUrl,
            SkipNonceCheck = provider.SkipNonceCheck,
            AuthorizationUrl = provider.AuthorizationUrl,
            TokenUrl = provider.TokenUrl,
            UserinfoUrl = provider.UserinfoUrl,
            JwksUri = provider.JwksUri,
        };
}
