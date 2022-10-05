using System.Net.Http.Json;
using Bee.ZatcaHelper.Contracts;
using Bee.ZatcaHelper.Util;
using Serilog;

namespace Bee.ZatcaHelper;

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