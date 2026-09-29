using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Supabase.Gotrue.Resend;

/// <summary>
/// Parameters for the Resend API.
/// </summary>
public class ResendParameters
{
    /// <summary>
    /// The email address to resend to.
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// The phone number to resend to.
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    /// <summary>
    /// The type of resend.
    /// </summary>
    [JsonPropertyName("type")]
    public ResendType Type { get; set; }

    /// <summary>
    /// Additional options to customize the behavior of the Resend API.
    /// Provides support for features such as CAPTCHA tokens and email redirection.
    /// </summary>
    [JsonPropertyName("options")]
    public ResendOptions? Options { get; set; }

    /// <summary>
    /// Check if the ResendType belongs to email-related types.
    /// </summary>
    /// <returns></returns>
    public bool IsEmail()
    {
        var types = new List<ResendType>()
        {
            ResendType.EmailChange,
            ResendType.SignUp
        };

        return types.Contains(this.Type);
    }
}
