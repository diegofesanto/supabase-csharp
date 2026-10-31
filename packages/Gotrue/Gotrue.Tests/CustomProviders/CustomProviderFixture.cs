using System;
using System.Threading.Tasks;
using Gotrue.Tests.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supabase.Gotrue;
using Supabase.Gotrue.CustomProviders;
using Supabase.Gotrue.Interfaces;
using static Gotrue.Tests.TestUtils;

namespace Gotrue.Tests.CustomProviders;

public abstract class CustomProviderFixture
{
    protected IGotrueAdminClient<User> Api { get; private set; } = null!;

    protected static string ServiceRoleKey => GenerateServiceRoleToken(TestClients.CliJwtSecret);

    [TestInitialize]
    public void InitializeClient()
    {
        this.Api = TestClients.AdminAgainstCliStack();
    }

    public Task<CustomProvider?> CreateCustomProviderOAuth()
    {
        var provider = new CreateCustomProvider
        {
            CustomProviderType = CustomProviderType.OAuth2,
            Identifier = $"custom:oauth{Guid.NewGuid()}",
            Name = "CustomOAuthSupabase",
            ClientId = "ClientId",
            ClientSecret = "Secret",
            AuthorizationUrl = "https://batrpyimgiqfewsdkfll.supabase.co",
            TokenUrl = "https://batrpyimgiqfewsdkfll.supabase.co",
            UserinfoUrl = "https://batrpyimgiqfewsdkfll.supabase.co",
        };

        return this.Api.CreateCustomProvider(provider);
    }

    public Task<CustomProvider?> CreateCustomProviderOIDC()
    {
        var provider = new CreateCustomProvider
        {
            CustomProviderType = CustomProviderType.OIDC,
            Identifier = $"custom:oidc{Guid.NewGuid()}",
            Name = "CustomOAuthSupabase",
            ClientId = "ClientId",
            ClientSecret = "Secret",
            Issuer = "https://batrpyimgiqfewsdkfll.supabase.co/auth/v1",
            DiscoveryUrl =
                "https://batrpyimgiqfewsdkfll.supabase.co/auth/v1/.well-known/openid-configuration",
        };

        return this.Api.CreateCustomProvider(provider);
    }
}
