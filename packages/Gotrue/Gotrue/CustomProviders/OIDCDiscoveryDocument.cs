using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Supabase.Gotrue.CustomProviders;

/// <summary>
/// Represents the discovery document obtained from an OpenId Connect (OIDC)
/// </summary>
public record class OIDCDiscoveryDocument
{
    /// <summary>
    /// Issuer identifier
    /// </summary>
    [JsonPropertyName("issuer")]
    public string? Issuer { get; set; }

    /// <summary>
    /// URL of authorization endpoint
    /// </summary>
    [JsonPropertyName("authorization_endpoint")]
    public string? AuthorizationEndpoint { get; set; }

    /// <summary>
    /// URL of the token endpoint
    /// </summary>
    [JsonPropertyName("token_endpoint")]
    public string? TokenEndpoint { get; set; }

    /// <summary>
    /// URL of the JSON Web Key Set
    /// </summary>
    [JsonPropertyName("jwks_uri")]
    public string? JwksUri { get; set; }

    /// <summary>
    /// URL of the userinfo endpoint
    /// </summary>
    [JsonPropertyName("userinfo_endpoint")]
    public string? UserinfoEndpoint { get; set; }

    /// <summary>
    /// URL of the revocation endpoint
    /// </summary>
    [JsonPropertyName("revocation_endpoint")]
    public string? RevocationEndpoint { get; set; }

    /// <summary>
    /// List of supported scopes
    /// </summary>
    [JsonPropertyName("supported_scopes")]
    public List<string>? ScopesSupported { get; set; }

    /// <summary>
    /// List of supported response types
    /// </summary>
    [JsonPropertyName("supported_response_types")]
    public List<string>? ResponseTypesSupported { get; set; }

    /// <summary>
    /// List of supported subject type
    /// </summary>
    [JsonPropertyName("supported_subject_types")]
    public List<string>? SubjectTypesSupported { get; set; }

    /// <summary>
    /// List of supported ID token signing algorithms
    /// </summary>
    [JsonPropertyName("supported_id_token_signing_algs")]
    public List<string>? IdTokenSigningAlgsSupported { get; set; }
}
