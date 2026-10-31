using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Supabase.Gotrue.CustomProviders;

public record class CreateCustomProvider
{
    /// <summary>
    /// Provider type
    /// </summary>
    public CustomProviderType CustomProviderType { get; init; }

    /// <summary>
    /// Provider identifier (e. g. custom:mycompany)
    /// </summary>
    public string Identifier { get; init; }

    /// <summary>
    /// Human readable name
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// OAuth client ID
    /// </summary>
    public string ClientId { get; init; }

    /// <summary>
    /// OAuth client secret (write-only, not returned in response)
    /// </summary>
    public string ClientSecret { get; init; }

    /// <summary>
    /// Additional client IDs accepted during token validation
    /// </summary>
    public List<string>? AcceptableClientIDs { get; init; }

    /// <summary>
    /// OAuth scopes requested during authorization
    /// </summary>
    public List<string>? Scopes { get; init; }

    /// <summary>
    /// Allowlist of raw identity provider claim keys to copy verbatim into user's
    /// </summary>
    public List<string>? CustomClaimsAllowList { get; init; }

    /// <summary>
    /// Whether PKCE is enabled
    /// </summary>
    public bool? PkceEnabled { get; init; }

    /// <summary>
    /// Mapping of provider attributes to Supabase user attribute
    /// </summary>
    public Dictionary<string, object>? AttributeMapping { get; init; }

    /// <summary>
    /// Additional parameters sent with the authrozation request
    /// </summary>
    public Dictionary<string, string>? AuthorizationParameters { get; init; }

    /// <summary>
    /// Whether the provider is enabled
    /// </summary>
    public bool? Enabled { get; init; }

    /// <summary>
    /// Whether email is optional for this provider
    /// </summary>
    public bool? EmailOptional { get; init; }

    /// <summary>
    /// OIDC issuer URL
    /// </summary>
    public string? Issuer { get; init; }

    /// <summary>
    /// OIDC discovery url
    /// </summary>
    public string? DiscoveryUrl { get; init; }

    /// <summary>
    /// Whether to skip nonce check (OIDC)
    /// </summary>
    public bool? SkipNonceCheck { get; init; }

    /// <summary>
    /// OAuth2 authorization url
    /// </summary>
    public string? AuthorizationUrl { get; init; }

    /// <summary>
    /// OAuth2 token URL
    /// </summary>
    public string? TokenUrl { get; init; }

    /// <summary>
    /// OAuth2 userinfo URL
    /// </summary>
    public string? UserinfoUrl { get; init; }

    /// <summary>
    /// JWKS Uri for token verification
    /// </summary>
    public string? JwksUri { get; init; }

    internal Dictionary<string, object?> ToDictionary()
    {
        var payload = new Dictionary<string, object?>
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
