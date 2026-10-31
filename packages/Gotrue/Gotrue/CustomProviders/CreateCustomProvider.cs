using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Supabase.Gotrue.CustomProviders;

public class CreateCustomProvider
{
    /// <summary>
    /// Provider type
    /// </summary>
    [JsonPropertyName("provider_type")]
    public CustomProviderType CustomProviderType { get; set; }

    /// <summary>
    /// Provider identifier (e. g. custom:mycompany)
    /// </summary>
    [JsonPropertyName("identifier")]
    public string Identifier { get; set; }

    /// <summary>
    /// Human readable name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// OAuth client ID
    /// </summary>
    [JsonPropertyName("client_id")]
    public string ClientId { get; set; }

    /// <summary>
    /// OAuth client secret (write-only, not returned in response)
    /// </summary>
    [JsonPropertyName("client_secret")]
    public string ClientSecret { get; set; }

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

    internal Dictionary<string, object> ToDictionary()
    {
        var payload = new Dictionary<string, object>
        {
            { "provider_type", Core.Helpers.GetMappedToAttr(this.CustomProviderType).Mapping },
            { "identifier", this.Identifier },
            { "name", this.Name },
            { "client_id", this.ClientId },
            { "client_secret", this.ClientSecret },
            { "acceptable_client_ids", this.AcceptableClientIDs },
            { "scopes", this.Scopes },
            { "custom_claims_allowlist", this.CustomClaimsAllowList },
            { "pkce_enabled", this.PkceEnabled },
            { "attribute_mapping", this.AttributeMapping },
            { "authorization_params", this.AuthorizationParameters },
            { "enabled", this.Enabled },
            { "email_optional", this.EmailOptional },
            { "issuer", this.Issuer },
            { "discovery_url", this.DiscoveryUrl },
            { "skip_nonce_check", this.SkipNonceCheck },
            { "authorization_url", this.AuthorizationUrl },
            { "token_url", this.TokenUrl },
            { "userinfo_url", this.UserinfoUrl },
            { "jwks_uri", this.JwksUri },
        };

        return payload;
    }
}
