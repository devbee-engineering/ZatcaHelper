using System.Net.Http.Json;
using Serilog;
using Zatca_Standard_Invoice_Integration_Client.Contracts;
using Zatca_Standard_Invoice_Integration_Client.Util;

namespace Zatca_Standard_Invoice_Integration_Client;

public class ComplianceCsrApiClient
{
    private readonly string _baseUrl;
    private readonly string _complianceEndPoint;

    public ComplianceCsrApiClient(GlobalVariables globalVariables)
    {
        _baseUrl = globalVariables.BaseUrl;
        _complianceEndPoint = globalVariables.ComplianceCsidEndpoint;
        if (!string.IsNullOrEmpty(_baseUrl) && !string.IsNullOrEmpty(_complianceEndPoint)) return;
        Log.Error("Base Url or Compliance Csid Endpoint cant be empty");
        throw new Exception("Base Url or Compliance Csid Endpoint cant be empty");
    }

    public ComplianceCsrResponse? GetToken(ComplianceCsrRequest complianceCsrRequest)
    {
        var customHeaders = new Dictionary<string, string> {{"OTP", complianceCsrRequest.Otp}};
        var result = new WebClient(_baseUrl, customHeaders).PostAsJsonAsync(
            _complianceEndPoint, new
            {
                csr = complianceCsrRequest.Csr
            });
        return result.Result.Content.ReadFromJsonAsync<ComplianceCsrResponse>().Result;
    }
}