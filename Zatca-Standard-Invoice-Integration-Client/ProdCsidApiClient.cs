using System.Net.Http.Json;
using Zatca_Standard_Invoice_Integration_Client.Contracts;
using Zatca_Standard_Invoice_Integration_Client.Util;

namespace Zatca_Standard_Invoice_Integration_Client;

public class ProdCsidApiClient
{
    private readonly string _baseUrl;
    private readonly string _prodCsidEndPoint;

    public ProdCsidApiClient(GlobalVariables globalVariables)
    {
        _baseUrl = globalVariables.BaseUrl;
        _prodCsidEndPoint = globalVariables.ProdCsidEndpoint;
    }

    public ProdCsidOnboardingResponse? GetToken(ProdCsidOnboardingRequest prodCsidOnboardingRequest)
    {
        var result = new WebClient(_baseUrl, new Dictionary<string, string>(),
            prodCsidOnboardingRequest.CsrBinaryToken, prodCsidOnboardingRequest.CsrSecret).PostAsJsonAsync(
            _prodCsidEndPoint, new
            {
                compliance_request_id = prodCsidOnboardingRequest.ComplianceRequestId
            });
        return result.Result.Content.ReadFromJsonAsync<ProdCsidOnboardingResponse>().Result;
    }
}