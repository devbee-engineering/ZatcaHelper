namespace Bee.ZatcaHelper.IntegrationTests;

public static class E2ETest
{
    private static readonly GlobalVariables GlobalVariables = new GlobalVariables()
    {
        BaseUrl = "https://gw-apic-gov.gazt.gov.sa",
        ComplianceCsidEndpoint = "/e-invoicing/developer-portal/compliance",
        ProdCsidEndpoint = "/e-invoicing/developer-portal/production/csids",
        InvoiceClearanceEndPoint = "/e-invoicing/developer-portal/invoices/clearance/single"
    };

    private const string Otp = "123456";

    private const string Csr =
        "LS0tLS1CRUdJTiBDRVJUSUZJQ0FURSBSRVFVRVNULS0tLS0NIE1JSUI3akNDQVpNQ0FRQXdZREVMTUFrR0ExVUVCaE1DVTBFeEZUQVRCZ05WQkFzTURGSnBlV0ZrSUVKeVlXNWoNIGFERXRNQ3NHQTFVRUNnd2tWVzVwZEdWa0lFZDFiR1lnUVdseVkzSmhablFnUm5WbGJHbHVaeUJEYjIxd1lXNTUNIE1Rc3dDUVlEVlFRRERBSlRRVEJXTUJBR0J5cUdTTTQ5QWdFR0JTdUJCQUFLQTBJQUJQWHFkK1Q1ZkZhK1ZlYmcNIHlzL1d4bkJPNHBwOHNVeWtlM1BMSmVKYjZLbkk1Z0ZEcHVsWWY1K1NvUFJZVGFmK1o3Y0g1RzdJSmExdVNYSXENIHkwWVdoVytnZ2RNd2dkQUdDU3FHU0liM0RRRUpEakdCd2pDQnZ6QWhCZ2tyQmdFRUFZSTNGQUlFRkJNU1drRlUNIFEwRXRRMjlrWlMxVGFXZHVhVzVuTUlHWkJnTlZIUkVFZ1pFd2dZNmtnWXN3Z1lneEp6QWxCZ05WQkFRTUhqRXQNIFZXZGhabU52ZkRJdFJWTkhWVTVKVkh3ekxURXlNelExTmpjNE9URWZNQjBHQ2dtU0pvbVQ4aXhrQVFFTUR6TXgNIE1ERTNOVE01TnpRd01EQXdNekVOTUFzR0ExVUVEQXdFTVRFd01ERVNNQkFHQTFVRUdnd0pUWGxCWkdSeVpYTnoNIE1Sa3dGd1lEVlFRUERCQkdkV1ZzYVc1bklFbHVaSFZ6ZEhKNU1Bb0dDQ3FHU000OUJBTUNBMGtBTUVZQ0lRQ1ANIFlFVGJuazFSblFYTDdvSUxJek1qMFJGQWg3QmErUEFPenJIQnMyYzdLZ0loQUxDaUVKNnRjVzdGcHdyVEZ0RGMNIFA1QjVoRE5nYjFGUTJXSVZjMzc1VS9PdA0gLS0tLS1FTkQgQ0VSVElGSUNBVEUgUkVRVUVTVC0tLS0t";

    public static void Run()
    {
        var csrResponse = GetComplianceCsr(GlobalVariables, Otp, Csr);

        var prodOnboard = GetProdCsid(GlobalVariables, csrResponse);

        ClearInvoice(GlobalVariables, prodOnboard);
        
        Console.WriteLine("-----------------------------------------------------------------------------------------");
        Console.WriteLine("----------------------------------Test Run Completed-------------------------------------");
        Console.WriteLine("-----------------------------------------------------------------------------------------");
    }

    private static void ClearInvoice(GlobalVariables globalVariables, ProdCsidOnboardingResponse prodOnboard)
    {
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
            PreviousInvoiceHash =
                "NWZlY2ViNjZmZmM4NmYzOGQ5NTI3ODZjNmQ2OTZjNzljMmRiYzIzOWRkNGU5MWI0NjcyOWQ3M2EyN2ZiNTdlOQ==",
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
                    BuildingNumber = "3353",
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
                LineExtensionAmount = new Money("SAR", 1000.00),
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


        var generatedClearanceRequest = StandardInvoiceXmlGenerator.Generate(invoice);
        Console.WriteLine("----------------------Standard Invoice Generation Request---------------------------------");
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(generatedClearanceRequest));
        var clearanceResponse = new StandardInvoiceClearanceApiClient(globalVariables).ClearInvoice(
            new InvoiceClearanceRequest(generatedClearanceRequest, prodOnboard.BinarySecurityToken,
                prodOnboard.Secret));
        Console.WriteLine("----------------------Standard Invoice Clearance Request---------------------------------");
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(clearanceResponse));
        Assert.IsNotNull(clearanceResponse);
        Assert.IsNotEmpty(clearanceResponse.GeneratedQR);
    }

    private static ProdCsidOnboardingResponse GetProdCsid(GlobalVariables globalVariables,
        ComplianceCsrResponse csrResponse)
    {
        var prodOnboard = new ProdCsidApiClient(globalVariables).GetToken(
            new ProdCsidOnboardingRequest(csrResponse.RequestId, csrResponse.BinarySecurityToken, csrResponse.Secret));
        Console.WriteLine("--------------------------------Prod Csid Request-----------------------------------");
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(prodOnboard));
        Assert.IsNotNull(prodOnboard);
        Assert.IsTrue(prodOnboard.Errors is null);
        return prodOnboard;
    }

    private static ComplianceCsrResponse GetComplianceCsr(GlobalVariables globalVariables, string otp, string csr)
    {
        var csrResponse = new ComplianceCsrApiClient(globalVariables).GetToken(new ComplianceCsrRequest(otp, csr));
        Console.WriteLine("--------------------------------Compliance Csr Request-----------------------------------");
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(csrResponse));
        Assert.IsNotNull(csrResponse);
        Assert.IsTrue(csrResponse.Errors is null);
        return csrResponse;
    }
}