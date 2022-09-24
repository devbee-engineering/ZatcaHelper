using System.Net.Http.Json;
using System.Text;
using System.Xml;
using Zatca_Standard_Invoice_Integration_Client.Util;

namespace Zatca_Standard_Invoice_Integration_Client;

public static class StandardInvoiceClearanceApiClient
{
    public static InvoiceClearanceResponse? ClearInvoice(InvoiceClearanceRequest invoiceClearanceRequest)
    {
        var customHeaders = new Dictionary<string, string> {{"Clearance-Status", "1"}};
        var result = new WebClient("https://gw-apic-gov.gazt.gov.sa", customHeaders,
            invoiceClearanceRequest.BinaryToken, invoiceClearanceRequest.Secret).PostAsJsonAsync(
            "/e-invoicing/developer-portal/invoices/clearance/single", invoiceClearanceRequest.Body);
        var response =  result.Result.Content.ReadFromJsonAsync<InvoiceClearanceResponse>().Result;
        response.Hash = ((dynamic) invoiceClearanceRequest.Body).invoiceHash;
        response.GeneratedQR = GetGeneratedQrCode(response);

        return response;
    }

    private static string? GetGeneratedQrCode(InvoiceClearanceResponse response)
    {
        byte[] data = Convert.FromBase64String(response.ClearedInvoice);
        string decodedString = Encoding.UTF8.GetString(data);
        
        var xmlDoc = new XmlDocument
        {
            PreserveWhitespace = true
        };

        xmlDoc.LoadXml(decodedString);

        var value = xmlDoc.GetNodeValue(StandardInvoiceXmlGenerator.QrCodeXpath);

        return value;

    }
}

public class InvoiceClearanceRequest
{
    public InvoiceClearanceRequest(object body, string binaryToken, string secret)
    {
        Body = body;
        BinaryToken = binaryToken;
        Secret = secret;
    }

    public object Body { get; }
    public string BinaryToken { get; }
    public string Secret { get; }
}

public class InvoiceClearanceResponse
{
    public string ClearanceStatus { get; set; }
    public string ClearedInvoice { get; set; }
    public object validationResults { get; set; }
    public string? Hash { get; set; }
    public string? GeneratedQR { get; set; }
}