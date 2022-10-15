using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Xml;
using Bee.ZatcaHelper.Contracts;
using Bee.ZatcaHelper.Util;
using WebClient = Bee.ZatcaHelper.Util.WebClient;

namespace Bee.ZatcaHelper;

public class StandardInvoiceClearanceApiClient
{
    private readonly string _baseUrl;
    private readonly string _invoiceClearanceEndPoint;

    public StandardInvoiceClearanceApiClient(GlobalVariables globalVariables)
    {
        _baseUrl = globalVariables.BaseUrl;
        _invoiceClearanceEndPoint = globalVariables.InvoiceClearanceEndPoint;
    }

    public InvoiceClearanceResponse ClearInvoice(InvoiceClearanceRequest invoiceClearanceRequest)
    {
        var customHeaders = new Dictionary<string, string> {{"Clearance-Status", "1"},{"accept-language","en"}};
        var result = new WebClient(_baseUrl, customHeaders,
            invoiceClearanceRequest.BinaryToken, invoiceClearanceRequest.Secret).PostAsJsonAsync(
            _invoiceClearanceEndPoint, invoiceClearanceRequest.Body);
        var response = result.Result.Content.ReadFromJsonAsync<InvoiceClearanceResponse>().Result;

        if (result.Result.StatusCode == HttpStatusCode.InternalServerError)
        {
            throw new Exception("Something went wrong  " + result.Result.Content);
        }

        if (response?.ClearanceStatus != "CLEARED") return response;
        response.Hash = ((dynamic) invoiceClearanceRequest.Body).invoiceHash;
        response.GeneratedQR = GetGeneratedQrCode(response);
        return response;
    }

    private static string? GetGeneratedQrCode(InvoiceClearanceResponse response)
    {
        var data = Convert.FromBase64String(response.ClearedInvoice);
        var decodedString = Encoding.UTF8.GetString(data);

        var xmlDoc = new XmlDocument
        {
            PreserveWhitespace = true
        };

        xmlDoc.LoadXml(decodedString);

        var value = xmlDoc.GetNodeValue(Bee.ZatcaHelper.StandardInvoiceXmlGenerator.QrCodeXpath);

        return value;
    }
}