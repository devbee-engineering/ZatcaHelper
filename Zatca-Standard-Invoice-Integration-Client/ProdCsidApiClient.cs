using System.Net.Http.Json;
using Zatca_Standard_Invoice_Integration_Client.Util;

namespace Zatca_Standard_Invoice_Integration_Client;

public class ProdCsidApiClient
{
    public static ProdCsidOnboardingResponse? GetToken(ProdCsidOnboardingRequest prodCsidOnboardingRequest)
    {
        ;
        var result = new WebClient("https://gw-apic-gov.gazt.gov.sa", new Dictionary<string, string>(),
            prodCsidOnboardingRequest.CsrBinaryToken, prodCsidOnboardingRequest.CsrSecret).PostAsJsonAsync(
            "/e-invoicing/developer-portal/production/csids", new
            {
                compliance_request_id = prodCsidOnboardingRequest.ComplianceRequestId
            });
        return result.Result.Content.ReadFromJsonAsync<ProdCsidOnboardingResponse>().Result;
    }
}

public class ProdCsidOnboardingRequest
{
    public ProdCsidOnboardingRequest(long complianceRequestId, string csrBinaryToken, string csrSecret)
    {
        ComplianceRequestId = complianceRequestId;
        CsrBinaryToken = csrBinaryToken;
        CsrSecret = csrSecret;
    }

    public long ComplianceRequestId { get; }
    public string CsrBinaryToken { get; }
    public string CsrSecret { get; }
}

public class ProdCsidOnboardingResponse
{
    public long RequestID { get; set; }
    public string DispositionMessage { get; set; }
    public string BinarySecurityToken { get; set; }
    public string Secret { get; set; }
    public string[] Errors { get; set; }
}