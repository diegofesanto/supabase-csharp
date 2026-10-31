using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supabase.Gotrue.CustomProviders;

namespace Gotrue.Tests.CustomProviders;

[TestClass]
[TestCategory("E2E")]
public class CustomProviderTest : CustomProviderFixture
{
    [TestMethod]
    public async Task CustomProvider_CreateProviderTypeOAuth_GivenMandatoryFields()
    {
        var provider = new CreateCustomProvider
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

        var result = await this.Api.CreateCustomProvider(provider);
        await this.Api.DeleteCustomProvider(provider.Identifier);

        using (new AssertionScope())
        {
            result.Should().NotBeNull();
            result.ClientId.Should().Be(provider.ClientId);
            result.Identifier.Should().Be(provider.Identifier);
            result.Name.Should().Be(provider.Name);
            result.ClientId.Should().Be(provider.ClientId);
            result.AuthorizationUrl.Should().Be(provider.AuthorizationUrl);
            result.TokenUrl.Should().Be(provider.TokenUrl);
            result.UserinfoUrl.Should().Be(provider.UserinfoUrl);
        }
    }

    [TestMethod]
    public async Task CustomProvider_CreateProviderTypeOAuth_GivenOptionalsFields()
    {
        var provider = new CreateCustomProvider
        {
            CustomProviderType = CustomProviderType.OAuth2,
            Identifier = "custom:mysupabase",
            Name = "CustomOAuthSupabase",
            ClientId = "ClientId",
            ClientSecret = "Secret",
            AcceptableClientIDs = ["Secret", "Secret1"],
            Scopes = ["groups", "org_id"],
            CustomClaimsAllowList = ["claims"],
            PkceEnabled = false,
            AttributeMapping = new Dictionary<string, object>() { { "key", "value" } },
            AuthorizationParameters = new Dictionary<string, string>() { { "key", "value" } },
            Enabled = true,
            EmailOptional = true,
            Issuer = "https://batrpyimgiqfewsdkfll.supabase.co",
            DiscoveryUrl = "https://batrpyimgiqfewsdkfll.supabase.co",
            SkipNonceCheck = false,
            AuthorizationUrl = "https://batrpyimgiqfewsdkfll.supabase.co",
            TokenUrl = "https://batrpyimgiqfewsdkfll.supabase.co",
            UserinfoUrl = "https://batrpyimgiqfewsdkfll.supabase.co",
            JwksUri = "https://batrpyimgiqfewsdkfll.supabase.co",
        };

        var result = await this.Api.CreateCustomProvider(provider);
        await this.Api.DeleteCustomProvider(provider.Identifier);

        using (new AssertionScope())
        {
            result.Should().NotBeNull();
            result.ClientId.Should().Be(provider.ClientId);
            result.Identifier.Should().Be(provider.Identifier);
            result.Name.Should().Be(provider.Name);
            result.ClientId.Should().Be(provider.ClientId);
            result.AcceptableClientId.Should().Equal(provider.AcceptableClientIDs);
            result.Scopes.Should().Equal(provider.Scopes);
            result.CustomClaimsAllowlist.Should().Equal(provider.CustomClaimsAllowList);
            result.PkceEnabled.Should().Be(provider.PkceEnabled);
            result.AttributeMapping.Should().Equal(provider.AttributeMapping);
            result.AuthorizationParameter.Should().Equal(provider.AuthorizationParameters);
            result.Enabled.Should().Be(provider.Enabled);
            result.EmailOptional.Should().Be(provider.EmailOptional);
            result.Issuer.Should().BeNull();
            result.DiscoveryUrl.Should().BeNull();
            result.SkipNonceCheck.Should().Be(provider.SkipNonceCheck);
            result.AuthorizationUrl.Should().Be(provider.AuthorizationUrl);
            result.TokenUrl.Should().Be(provider.TokenUrl);
            result.UserinfoUrl.Should().Be(provider.UserinfoUrl);
            result.JwksUri.Should().Be(provider.JwksUri);
        }
    }

    [TestMethod]
    public async Task CustomProvider_CreateProviderTypeOIDC_GivenMandatoryFields()
    {
        var provider = new CreateCustomProvider
        {
            CustomProviderType = CustomProviderType.OIDC,
            Identifier = "custom:mysupabase",
            Name = "CustomOAuthSupabase",
            ClientId = "ClientId",
            ClientSecret = "Secret",
            Issuer = "https://batrpyimgiqfewsdkfll.supabase.co/auth/v1",
            DiscoveryUrl =
                "https://batrpyimgiqfewsdkfll.supabase.co/auth/v1/.well-known/openid-configuration",
        };

        var result = await this.Api.CreateCustomProvider(provider);
        await this.Api.DeleteCustomProvider(provider.Identifier);

        using (new AssertionScope())
        {
            result.Should().NotBeNull();
            result.ClientId.Should().Be(provider.ClientId);
            result.Identifier.Should().Be(provider.Identifier);
            result.Name.Should().Be(provider.Name);
            result.ClientId.Should().Be(provider.ClientId);
        }
    }

    [TestMethod]
    public async Task CustomProvider_CreateProviderTypeOIDC_GivenOptionalsFields()
    {
        var provider = new CreateCustomProvider
        {
            CustomProviderType = CustomProviderType.OIDC,
            Identifier = "custom:mysupabase",
            Name = "CustomOAuthSupabase",
            ClientId = "ClientId",
            ClientSecret = "Secret",
            AcceptableClientIDs = ["Secret", "Secret1"],
            Scopes = ["openid", "groups", "org_id"],
            CustomClaimsAllowList = ["claims"],
            PkceEnabled = false,
            AttributeMapping = new Dictionary<string, object>() { { "key", "value" } },
            AuthorizationParameters = new Dictionary<string, string>() { { "key", "value" } },
            Enabled = true,
            EmailOptional = true,
            Issuer = "https://batrpyimgiqfewsdkfll.supabase.co/auth/v1",
            DiscoveryUrl =
                "https://batrpyimgiqfewsdkfll.supabase.co/auth/v1/.well-known/openid-configuration",
            SkipNonceCheck = false,
            AuthorizationUrl = "https://batrpyimgiqfewsdkfll.supabase.co",
            TokenUrl = "https://batrpyimgiqfewsdkfll.supabase.co",
            UserinfoUrl = "https://batrpyimgiqfewsdkfll.supabase.co",
            JwksUri = "https://batrpyimgiqfewsdkfll.supabase.co",
        };

        var result = await this.Api.CreateCustomProvider(provider);
        await this.Api.DeleteCustomProvider(provider.Identifier);

        using (new AssertionScope())
        {
            result.Should().NotBeNull();
            result.ClientId.Should().Be(provider.ClientId);
            result.Identifier.Should().Be(provider.Identifier);
            result.Name.Should().Be(provider.Name);
            result.ClientId.Should().Be(provider.ClientId);
            result.AcceptableClientId.Should().Equal(provider.AcceptableClientIDs);
            result.Scopes.Should().Equal(provider.Scopes);
            result.CustomClaimsAllowlist.Should().Equal(provider.CustomClaimsAllowList);
            result.PkceEnabled.Should().Be(provider.PkceEnabled);
            result.AttributeMapping.Should().Equal(provider.AttributeMapping);
            result.AuthorizationParameter.Should().Equal(provider.AuthorizationParameters);
            result.Enabled.Should().Be(provider.Enabled);
            result.EmailOptional.Should().Be(provider.EmailOptional);
            result.Issuer.Should().Be(provider.Issuer);
            result.DiscoveryUrl.Should().Be(provider.DiscoveryUrl);
            result.SkipNonceCheck.Should().Be(provider.SkipNonceCheck);
            result.AuthorizationUrl.Should().BeNull();
            result.TokenUrl.Should().BeNull();
            result.UserinfoUrl.Should().BeNull();
            result.JwksUri.Should().BeNull();
        }
    }

    [TestMethod]
    public async Task CustomProvider_UpdateProviderTypeOAuth_GiveExistingOAuth()
    {
        var createProvider = await this.CreateCustomProviderOAuth();
        var updated = UpdateCustomProvider.From(createProvider);
        updated.Name = "newnameforcustomprovider";

        var result = await this.Api.UpdateCustomProvider(createProvider.Identifier, updated);
        await this.Api.DeleteCustomProvider(createProvider.Identifier);

        result.Should().NotBeNull();
        result.Name.Should().Be(updated.Name);
        result.Name.Should().NotBe(createProvider.Name);
    }

    [TestMethod]
    public async Task CustomProvider_UpdateProviderTypeOIDC_GiveExistingOIDC()
    {
        var createProvider = await this.CreateCustomProviderOIDC();
        var updated = UpdateCustomProvider.From(createProvider);
        updated.Name = "newnameforcustomprovider";

        var result = await this.Api.UpdateCustomProvider(createProvider.Identifier, updated);
        await this.Api.DeleteCustomProvider(createProvider.Identifier);

        result.Should().NotBeNull();
        result.Name.Should().Be(updated.Name);
        result.Name.Should().NotBe(createProvider.Name);
    }

    [TestMethod]
    public async Task CustomProvider_ShouldGetProvider_GiveExistingIdentifier()
    {
        var provider = await this.CreateCustomProviderOAuth();

        var result = await this.Api.GetCustomProvider(provider.Identifier);

        await this.Api.DeleteCustomProvider(provider.Identifier);

        using (new AssertionScope())
        {
            result.Should().NotBeNull();
            result.ClientId.Should().Be(provider.ClientId);
            result.Identifier.Should().Be(provider.Identifier);
            result.Name.Should().Be(provider.Name);
            result.ClientId.Should().Be(provider.ClientId);
            result.Scopes.Should().Equal(provider.Scopes);
            result.PkceEnabled.Should().Be(provider.PkceEnabled);
            result.AttributeMapping.Should().Equal(provider.AttributeMapping);
            result.Enabled.Should().Be(provider.Enabled);
            result.EmailOptional.Should().Be(provider.EmailOptional);
            result.Issuer.Should().Be(provider.Issuer);
            result.DiscoveryUrl.Should().Be(provider.DiscoveryUrl);
            result.SkipNonceCheck.Should().Be(provider.SkipNonceCheck);
            result.AuthorizationUrl.Should().Be(provider.AuthorizationUrl);
            result.TokenUrl.Should().Be(provider.TokenUrl);
            result.UserinfoUrl.Should().Be(provider.UserinfoUrl);
            result.JwksUri.Should().Be(provider.JwksUri);
        }
    }

    [TestMethod]
    public async Task CustomProvider_ShouldGetProviders()
    {
        var oauth = await this.CreateCustomProviderOAuth();
        var oidc = await this.CreateCustomProviderOIDC();

        var list = await this.Api.ListCustomProvider(null);

        await this.Api.DeleteCustomProvider(oauth.Identifier);
        await this.Api.DeleteCustomProvider(oidc.Identifier);

        list.Should().NotBeNull();
        list.Providers.Should().NotBeEmpty().And.HaveCount(2);
    }

    [TestMethod]
    public async Task CustomProvider_ShouldGetProviders_GivenFilter()
    {
        var oauth = await this.CreateCustomProviderOAuth();
        var oidc = await this.CreateCustomProviderOIDC();

        var filter = new ListCustomProviderParameter() { Type = CustomProviderType.OAuth2 };

        var providers = await this.Api.ListCustomProvider(filter);

        await this.Api.DeleteCustomProvider(oauth.Identifier);
        await this.Api.DeleteCustomProvider(oidc.Identifier);

        providers.Should().NotBeNull();
        providers.Providers.Should().HaveCount(1);
    }
}
