using System.Net.Http.Json;
using Zatca_Standard_Invoice_Integration_Client.Util;

namespace Zatca_Standard_Invoice_Integration_Client;

public static class ComplianceCsrApiClient
{
    public static ComplianceCsrResponse? GetToken(ComplianceCsrRequest complianceCsrRequest)
    {
        var customHeaders = new Dictionary<string, string> {{"OTP", complianceCsrRequest.Otp}};
        var result = new WebClient("https://gw-apic-gov.gazt.gov.sa", customHeaders).PostAsJsonAsync(
            "/e-invoicing/developer-portal/compliance", new
            {
                csr = complianceCsrRequest.Csr
            });
        return result.Result.Content.ReadFromJsonAsync<ComplianceCsrResponse>().Result;
    }
}

public class ComplianceCsrRequest
{
    public ComplianceCsrRequest(string otp, string csr)
    {
        Otp = otp;
        Csr = csr;
    }

    public string Otp { get; init; }
    public string Csr { get; init; }
}

public class ComplianceCsrResponse
{
    public long RequestId { get; set; }
    public string DispositionMessage { get; set; }
    public string BinarySecurityToken { get; set; }
    public string Secret { get; set; }
    public string[] Errors { get; set; }
}