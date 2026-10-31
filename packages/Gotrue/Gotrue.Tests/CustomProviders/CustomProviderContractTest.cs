using System.Collections.Generic;
using System.Threading.Tasks;
using Gotrue.Tests.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supabase.Gotrue.CustomProviders;

namespace Gotrue.Tests.CustomProviders;

[TestClass]
[TestCategory("Contract")]
public class CustomProviderContractTest : RequestApprovalFixture
{
    private const string Jwt = "custom-provider-contract-token";

    [TestMethod]
    public async Task CustomProvider_ShouldSerializeCreateToMandatoryOAuthPayload_GivenOAuthType()
    {
        var oauthProvider = CreateMandatoryOAuthProvider();

        await this.Api.CreateCustomProvider(Jwt, oauthProvider);

        await this.Verify(this.EmittedRequestBody).UseDirectory("Data");
    }

    [TestMethod]
    public async Task CustomProvider_ShouldSerializeCreateToOptionalOAuthPayload_GivenOAuthType()
    {
        var oauthProvider = CreateOptionalParameters(CreateMandatoryOAuthProvider(), ["groups", "org_id"]);

        await this.Api.CreateCustomProvider(Jwt, oauthProvider);

        await this.Verify(this.EmittedRequestBody).UseDirectory("Data");
    }

    [TestMethod]
    public async Task CustomProvider_ShouldSerializeCreateToMandatoryOIDCPayload_GivenOIDCType()
    {
        var provider = CreateMandatoryOIDCProvider();

        await this.Api.CreateCustomProvider(Jwt, provider);

        await this.Verify(this.EmittedRequestBody).UseDirectory("Data");
    }

    [TestMethod]
    public async Task CustomProvider_ShouldSerializeCreateToOptionalOIDCPayload_GivenOIDCType()
    {
        var provider = CreateOptionalParameters(CreateMandatoryOIDCProvider(), ["openid", "groups", "org_id"]);

        await this.Api.CreateCustomProvider(Jwt, provider);

        await this.Verify(this.EmittedRequestBody).UseDirectory("Data");
    }

    [TestMethod]
    public async Task CustomProvider_ShouldSerializeUpdateFromOAuthProvider_GivenExistingOAuth()
    {
        var provider = UpdateCustomProvider.From(CreateExistingOAuthProvider());
        provider.Name = "newnameforcustomprovider";

        await this.Api.UpdateCustomProvider(Jwt, "custom:oauth", provider);

        await this.Verify(this.EmittedRequestBody).UseDirectory("Data");
    }

    [TestMethod]
    public async Task CustomProvider_ShouldSerializeUpdateFromOIDCProvider_GivenExistingOIDC()
    {
        var provider = UpdateCustomProvider.From(CreateExistingOIDCProvider());
        provider.Name = "newnameforcustomprovider";

        await this.Api.UpdateCustomProvider(Jwt, "custom:oidc", provider);

        await this.Verify(this.EmittedRequestBody).UseDirectory("Data");
    }

    [TestMethod]
    public async Task CustomProvider_ShouldNotAddTypeFilter_GivenListRequest()
    {
        await this.Api.ListCustomProvider(Jwt, null);

        this.ValidateNoQueryParameter("type");
    }

    [TestMethod]
    public async Task CustomProvider_ShouldMapOAuthTypeFilter_GivenListRequest()
    {
        await this.Api.ListCustomProvider(Jwt, new ListCustomProviderParameter { Type = CustomProviderType.OAuth2 });

        this.ValidateQueryParameters("type", "oauth2");
    }

    [TestMethod]
    public async Task CustomProvider_ShouldMapOIDCTypeFilter_GivenListRequest()
    {
        await this.Api.ListCustomProvider(Jwt, new ListCustomProviderParameter { Type = CustomProviderType.OIDC });

        this.ValidateQueryParameters("type", "oidc");
    }

    private static CreateCustomProvider CreateMandatoryOAuthProvider() => new()
    {
        CustomProviderType = CustomProviderType.OAuth2,
        Identifier = "custom:mysupabase",
        Name = "CustomOAuthSupabase",
        ClientId = "ClientId",
        ClientSecret = "Secret",
        AuthorizationUrl = "https://batrpyimgiqfewsdkfll.supabase.co",
        TokenUrl = "https://batrpyimgiqfewsdkfll.supabase.co",
        UserinfoUrl = "https://batrpyimgiqfewsdkfll.supabase.co",
    };

    private static CreateCustomProvider CreateMandatoryOIDCProvider() => new()
    {
        CustomProviderType = CustomProviderType.OIDC,
        Identifier = "custom:mysupabase",
        Name = "CustomOAuthSupabase",
        ClientId = "ClientId",
        ClientSecret = "Secret",
        Issuer = "https://batrpyimgiqfewsdkfll.supabase.co/auth/v1",
        DiscoveryUrl = "https://batrpyimgiqfewsdkfll.supabase.co/auth/v1/.well-known/openid-configuration",
    };

    private static CreateCustomProvider CreateOptionalParameters(CreateCustomProvider provider, List<string> scopes)
    {
        return provider with
        {
            AcceptableClientIDs = ["Secret", "Secret1"],
            Scopes = scopes,
            CustomClaimsAllowList = ["claims"],
            PkceEnabled = false,
            AttributeMapping = new Dictionary<string, object> { { "key", "value" } },
            AuthorizationParameters = new Dictionary<string, string> { { "key", "value" } },
            Enabled = true,
            EmailOptional = true,
            Issuer = provider.Issuer ?? "https://batrpyimgiqfewsdkfll.supabase.co",
            DiscoveryUrl = provider.DiscoveryUrl ?? "https://batrpyimgiqfewsdkfll.supabase.co",
            SkipNonceCheck = false,
            AuthorizationUrl = provider.AuthorizationUrl ?? "https://batrpyimgiqfewsdkfll.supabase.co",
            TokenUrl = provider.TokenUrl ?? "https://batrpyimgiqfewsdkfll.supabase.co",
            UserinfoUrl = provider.UserinfoUrl ?? "https://batrpyimgiqfewsdkfll.supabase.co",
            JwksUri = "https://batrpyimgiqfewsdkfll.supabase.co",
        };
    }

    private static CustomProvider CreateExistingOAuthProvider() => new()
    {
        Identifier = "custom:oauth",
        Name = "CustomOAuthSupabase",
        ClientId = "ClientId",
        Scopes = ["groups", "org_id"],
        PkceEnabled = false,
        Enabled = true,
        AuthorizationUrl = "https://batrpyimgiqfewsdkfll.supabase.co",
        TokenUrl = "https://batrpyimgiqfewsdkfll.supabase.co",
        UserinfoUrl = "https://batrpyimgiqfewsdkfll.supabase.co",
    };

    private static CustomProvider CreateExistingOIDCProvider() => new()
    {
        Identifier = "custom:oidc",
        Name = "CustomOAuthSupabase",
        ClientId = "ClientId",
        Scopes = ["openid", "groups", "org_id"],
        PkceEnabled = false,
        Enabled = true,
        Issuer = "https://batrpyimgiqfewsdkfll.supabase.co/auth/v1",
        DiscoveryUrl = "https://batrpyimgiqfewsdkfll.supabase.co/auth/v1/.well-known/openid-configuration",
    };
}
