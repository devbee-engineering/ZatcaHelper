using Zatca_Standard_Invoice_Integration_Client;
using Zatca_Standard_Invoice_Integration_Client.Contracts;

namespace Zatca_Standard_Invoice_Integration_Client_UnitTests;

public class ProdCsidApiClientTests
{
    [Test]
    public void ShouldGetProdCsidTokenWithComplianceCheckBinaryToken()
    {
        var globalVariables = new GlobalVariables()
        {
            BaseUrl = "sample base",
            ProdCsidEndpoint = "end point"
        };

        var prodCsidApiClient = new ProdCsidApiClient(globalVariables);
        var prodCsidRequest = new ProdCsidOnboardingRequest(1234, "binary token", "secret");
        var response = prodCsidApiClient.GetToken(prodCsidRequest);

        Assert.Pass();
    }
}