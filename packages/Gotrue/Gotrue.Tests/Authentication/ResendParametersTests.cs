using System.Net;
using System.Threading.Tasks;
using Gotrue.Tests.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supabase.Gotrue.Exceptions;
using Supabase.Gotrue.Resend;
using static Gotrue.Tests.TestUtils;

namespace Gotrue.Tests.Authentication;

[TestClass]
[TestCategory("E2E")]
public class ResendParametersTests : AuthClientFixture
{
    [TestMethod]
    public async Task Resend_ShouldRequestConfirmationCode_GivenSignUpType()
    {
        var email = RandomEmail();
        var resend = new ResendParameters { Type = ResendType.SignUp, Email = email };
        var response = await this.Client.Resend(resend);

        Assert.IsNotNull(response);
        Assert.AreEqual(HttpStatusCode.OK, response.ResponseMessage?.StatusCode);
    }

    [TestMethod]
    public async Task Resend_ShouldRequestConfirmationCode_GivenSmsType()
    {
        var resend = new ResendParameters { Type = ResendType.Sms, Phone = "5544989899898" };
        var response = await this.Client.Resend(resend);

        Assert.IsNotNull(response);
        Assert.AreEqual(HttpStatusCode.OK, response.ResponseMessage?.StatusCode);
    }

    [TestMethod]
    public async Task Resend_ShouldRequestConfirmationCode_GivenPhoneChangeType()
    {
        var resend = new ResendParameters { Type = ResendType.PhoneChange, Phone = "5544989899898" };
        var response = await this.Client.Resend(resend);

        Assert.IsNotNull(response);
        Assert.AreEqual(HttpStatusCode.OK, response.ResponseMessage?.StatusCode);
    }

    [TestMethod]
    public async Task Resend_ShouldRequestConfirmationCode_GivenEmailChangeType()
    {
        var resend = new ResendParameters { Type = ResendType.EmailChange, Email = RandomEmail() };
        var response = await this.Client.Resend(resend);

        Assert.IsNotNull(response);
        Assert.AreEqual(HttpStatusCode.OK, response.ResponseMessage?.StatusCode);
    }

    [TestMethod]
    public async Task Resend_ShouldThrowErrorWhenParameterAreInvalid_GivenPhoneForTypeEmail()
    {
        var resend = new ResendParameters { Type = ResendType.EmailChange, Phone = "5544989899898" };

        var action = async () => await this.Client.Resend(resend);

        var exception = await Assert.ThrowsAsync<GotrueException>(action);
        Assert.Contains("Missing email address or phone number", exception.Message);
        Assert.Contains("400", exception.Message);
    }

    [TestMethod]
    public async Task Resend_ShouldThrowErrorWhenParameterAreInvalid_GivenEmailForTypePhone()
    {
        var resend = new ResendParameters { Type = ResendType.Sms, Email = RandomEmail() };

        var action = async () => await this.Client.Resend(resend);

        var exception = await Assert.ThrowsAsync<GotrueException>(action);
        Assert.Contains("Type provided requires a phone number", exception.Message);
        Assert.Contains("400", exception.Message);
    }

    [TestMethod]
    public async Task Resend_ShouldThrowErrorWhenParameterAreInvalid_GivenNothingForTypeEmail()
    {
        var resend = new ResendParameters { Type = ResendType.EmailChange };

        var action = async () => await this.Client.Resend(resend);

        var exception = await Assert.ThrowsAsync<GotrueException>(action);
        Assert.Contains("Missing email address or phone number", exception.Message);
        Assert.Contains("400", exception.Message);
    }

    [TestMethod]
    public async Task Resend_ShouldThrowErrorWhenParameterAreInvalid_GivenNothingForTypePhone()
    {
        var resend = new ResendParameters { Type = ResendType.Sms };

        var action = async () => await this.Client.Resend(resend);

        var exception = await Assert.ThrowsAsync<GotrueException>(action);
        Assert.Contains("Type provided requires a phone number", exception.Message);
        Assert.Contains("400", exception.Message);
    }
}
