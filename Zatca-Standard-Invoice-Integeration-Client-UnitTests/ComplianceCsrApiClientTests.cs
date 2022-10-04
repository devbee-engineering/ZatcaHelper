using Zatca_Standard_Invoice_Integration_Client;
using Zatca_Standard_Invoice_Integration_Client.Contracts;

namespace Zatca_Standard_Invoice_Integration_Client_UnitTests;

public class ComplianceCsrApiClientTests
{
    [Test]
    public void ShouldGetTokenFromAfterComplianceCheck()
    {
        var globalVariables = new GlobalVariables()
        {
            BaseUrl = "https://www.google.com/",
            ComplianceCsidEndpoint = "/endpoint"
        };

        var complianceCsrApiClient = new ComplianceCsrApiClient(globalVariables);
        var complianceCsrRequest = new ComplianceCsrRequest("1234", "csr");
        var response = complianceCsrApiClient.GetToken(complianceCsrRequest);

        Assert.Pass();
    }
}