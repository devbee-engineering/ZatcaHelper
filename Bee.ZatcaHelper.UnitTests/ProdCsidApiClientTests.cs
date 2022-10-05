namespace Bee.ZatcaHelper.UnitTests;

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