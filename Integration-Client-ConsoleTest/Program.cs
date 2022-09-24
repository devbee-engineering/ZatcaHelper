// See https://aka.ms/new-console-template for more information

using Zatca_Standard_Invoice_Integration_Client;
using Zatca_Standard_Invoice_Integration_Client.Model;
using Zatca_Standard_Invoice_Integration_Client.Util;
using Zatca_Standard_Invoice_Integration_Client;

// var csrResponse = ComplianceCsrApiClient.GetToken(new ComplianceCsrRequest("123456", "LS0tLS1CRUdJTiBDRVJUSUZJQ0FURSBSRVFVRVNULS0tLS0NIE1JSUI3akNDQVpNQ0FRQXdZREVMTUFrR0ExVUVCaE1DVTBFeEZUQVRCZ05WQkFzTURGSnBlV0ZrSUVKeVlXNWoNIGFERXRNQ3NHQTFVRUNnd2tWVzVwZEdWa0lFZDFiR1lnUVdseVkzSmhablFnUm5WbGJHbHVaeUJEYjIxd1lXNTUNIE1Rc3dDUVlEVlFRRERBSlRRVEJXTUJBR0J5cUdTTTQ5QWdFR0JTdUJCQUFLQTBJQUJQWHFkK1Q1ZkZhK1ZlYmcNIHlzL1d4bkJPNHBwOHNVeWtlM1BMSmVKYjZLbkk1Z0ZEcHVsWWY1K1NvUFJZVGFmK1o3Y0g1RzdJSmExdVNYSXENIHkwWVdoVytnZ2RNd2dkQUdDU3FHU0liM0RRRUpEakdCd2pDQnZ6QWhCZ2tyQmdFRUFZSTNGQUlFRkJNU1drRlUNIFEwRXRRMjlrWlMxVGFXZHVhVzVuTUlHWkJnTlZIUkVFZ1pFd2dZNmtnWXN3Z1lneEp6QWxCZ05WQkFRTUhqRXQNIFZXZGhabU52ZkRJdFJWTkhWVTVKVkh3ekxURXlNelExTmpjNE9URWZNQjBHQ2dtU0pvbVQ4aXhrQVFFTUR6TXgNIE1ERTNOVE01TnpRd01EQXdNekVOTUFzR0ExVUVEQXdFTVRFd01ERVNNQkFHQTFVRUdnd0pUWGxCWkdSeVpYTnoNIE1Sa3dGd1lEVlFRUERCQkdkV1ZzYVc1bklFbHVaSFZ6ZEhKNU1Bb0dDQ3FHU000OUJBTUNBMGtBTUVZQ0lRQ1ANIFlFVGJuazFSblFYTDdvSUxJek1qMFJGQWg3QmErUEFPenJIQnMyYzdLZ0loQUxDaUVKNnRjVzdGcHdyVEZ0RGMNIFA1QjVoRE5nYjFGUTJXSVZjMzc1VS9PdA0gLS0tLS1FTkQgQ0VSVElGSUNBVEUgUkVRVUVTVC0tLS0t"));
 //
 // Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(csrResponse));
 //
 // var prodOnboard = ProdCsidApiClient.GetToken(new ProdCsidOnboardingRequest(csrResponse.RequestID,csrResponse.BinarySecurityToken,csrResponse.Secret));
 //
 // Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(prodOnboard));

var invoice = new StandardInvoice()
{
Id = "100012",
UUID = Guid.NewGuid().ToString(),
ActualDeliveryDate = "2022-09-13",
DocumentCurrencyCode = "SAR",
TaxCurrencyCode = "SAR",
InvoiceTypeCode = "388",
IssuedDate = "2022-09-13",
IssuedTime = "14:40:40",
LatestDeliveryDate = "2022-09-13",
PreviousInvoiceHash = "NWZlY2ViNjZmZmM4NmYzOGQ5NTI3ODZjNmQ2OTZjNzljMmRiYzIzOWRkNGU5MWI0NjcyOWQ3M2EyN2ZiNTdlOQ==",
SupplierInfo = new SupplierInfo()
{
 CRN = "310175397400003",
 PartyPostalAddress = new PartyPostalAddress()
 {
  StreetName = "testA",
  BuildingNumber = "3454",
  CityName = "RiyadhA",
  CitySubdivisionName = "fgffA",
  Country = "SA",
  CountrySubentity = "test",
  PlotIdentification = "1234",
  PostalZone = "12345",
 },
 RegistrationName = "United Gulf Aircraft Fueling Company",
 VAT = "310175397400003"
},
CustomerInfo = new CustomerInfo()
{
 NAT = "2345",
 PartyPostalAddress = new PartyPostalAddress()
 {
  BuildingNumber = "3353A",
  CityName = "DhurmaA",
  CitySubdivisionName = "fgffA",
  Country = "SA",
  CountrySubentity = "ulhkA",
  PlotIdentification = "3434",
  PostalZone = "34341",
  StreetName = "baaounA",
 },
 RegistrationName = "testA",
 VAT = "300075588700003",
},
InvoiceLineItem = new InvoiceLineItem()
{
 ID = "1",
 InvoicedQuantity = "100",
 ItemName = "item",
 LineExtensionAmount =  new Money("SAR", 1000.00),
 PriceAmount = new Money("SAR", 10.00),
 RoundingAmount = new Money("SAR", 1150.00),
 TaxAmount = new Money("SAR", 150.00),
 TaxPercent = "15.00",
 TaxScheme = "VAT",
 TaxSchemeId = "S"
},
LegalMonetaryTotal = new LegalMonetaryTotal()
{
 AllowanceTotalAmount = new Money("SAR", 0.00),
 LineExtensionAmount = new Money("SAR", 1000.00),
 PayableAmount = new Money("SAR", 1150.00),
 PrepaidAmount = new Money("SAR", 0.00),
 TaxExclusiveAmount = new Money("SAR", 1000.00),
 TaxInclusiveAmount = new Money("SAR", 1150.00),
},
TaxTotal = new TaxTotal()
{
 Percent = "15.00",
 TaxableAmount = new Money("SAR", 1000.00),
 TaxAmount = new Money("SAR", 150.00),
 TaxCategory = "SA"
}
};
 
var rsponse = StandardInvoiceXmlGenerator.Generate(invoice);

var tt = StandardInvoiceClearanceApiClient.ClearInvoice(new InvoiceClearanceRequest(rsponse,"TUlJRDJ6Q0NBNENnQXdJQkFnSVRid0FBZHFEbUlocXNqcG01Q3dBQkFBQjJvREFLQmdncWhrak9QUVFEQWpCak1SVXdFd1lLQ1pJbWlaUHlMR1FCR1JZRmJHOWpZV3d4RXpBUkJnb0praWFKay9Jc1pBRVpGZ05uYjNZeEZ6QVZCZ29Ka2lhSmsvSXNaQUVaRmdkbGVIUm5ZWHAwTVJ3d0dnWURWUVFERXhOVVUxcEZTVTVXVDBsRFJTMVRkV0pEUVMweE1CNFhEVEl5TURNeU9ERTFORFl6TWxvWERUSXlNRE16TURFMU5EWXpNbG93VFRFTE1Ba0dBMVVFQmhNQ1UwRXhEakFNQmdOVkJBb1RCVXBoY21seU1Sb3dHQVlEVlFRTEV4RktaV1JrWVdnZ1FuSmhibU5vTVRJek5ERVNNQkFHQTFVRUF4TUpNVEkzTGpBdU1DNHhNRll3RUFZSEtvWkl6ajBDQVFZRks0RUVBQW9EUWdBRUQvd2IybGhCdkJJQzhDbm5adm91bzZPelJ5bXltVTlOV1JoSXlhTWhHUkVCQ0VaQjRFQVZyQnVWMnhYaXhZNHFCWWY5ZGRlcnprVzlEd2RvM0lsSGdxT0NBaW93Z2dJbU1JR0xCZ05WSFJFRWdZTXdnWUNrZmpCOE1Sd3dHZ1lEVlFRRURCTXlNakl5TWpNeU5EUTBNelF6YW1abU5ETXlNUjh3SFFZS0NaSW1pWlB5TEdRQkFRd1BNekV3TVRjMU16azNOREF3TURBek1RMHdDd1lEVlFRTURBUXhNREV4TVJFd0R3WURWUVFhREFoVFlXMXdiR1VnUlRFWk1CY0dBMVVFRHd3UVUyRnRjR3hsSUVKMWMzTnBibVZ6Y3pBZEJnTlZIUTRFRmdRVWhXY3NiYkpoakQ1WldPa3dCSUxDK3dOVmZLWXdId1lEVlIwakJCZ3dGb0FVZG1DTSt3YWdyR2RYTlozUG1xeW5LNWsxdFM4d1RnWURWUjBmQkVjd1JUQkRvRUdnUDRZOWFIUjBjRG92TDNSemRHTnliQzU2WVhSallTNW5iM1l1YzJFdlEyVnlkRVZ1Y205c2JDOVVVMXBGU1U1V1QwbERSUzFUZFdKRFFTMHhMbU55YkRDQnJRWUlLd1lCQlFVSEFRRUVnYUF3Z1owd2JnWUlLd1lCQlFVSE1BR0dZbWgwZEhBNkx5OTBjM1JqY213dWVtRjBZMkV1WjI5MkxuTmhMME5sY25SRmJuSnZiR3d2VkZOYVJXbHVkbTlwWTJWVFEwRXhMbVY0ZEdkaGVuUXVaMjkyTG14dlkyRnNYMVJUV2tWSlRsWlBTVU5GTFZOMVlrTkJMVEVvTVNrdVkzSjBNQ3NHQ0NzR0FRVUZCekFCaGg5b2RIUndPaTh2ZEhOMFkzSnNMbnBoZEdOaExtZHZkaTV6WVM5dlkzTndNQTRHQTFVZER3RUIvd1FFQXdJSGdEQWRCZ05WSFNVRUZqQVVCZ2dyQmdFRkJRY0RBZ1lJS3dZQkJRVUhBd013SndZSkt3WUJCQUdDTnhVS0JCb3dHREFLQmdnckJnRUZCUWNEQWpBS0JnZ3JCZ0VGQlFjREF6QUtCZ2dxaGtqT1BRUURBZ05KQURCR0FpRUF5Tmh5Y1EzYk5sTEZkT1BscVlUNlJWUVRXZ25LMUdoME5IZGNTWTRQZkMwQ0lRQ1NBdGhYdnY3dGV0VUw2OVdqcDhCeG5MTE13ZXJ4WmhCbmV3by9nRjNFSkE9PQ==","f9YRhopN/G7x0TECOY6nKSCHLNYlb5riAHSFPICo4qw="));

var bb = tt;