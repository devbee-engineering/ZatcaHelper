namespace Bee.ZatcaHelper.UnitTests;

public class StandardInvoiceXmlGeneratorTests
{
    [Test]
    public void ShouldBeAbleToGenerateXml()
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

        var request = StandardInvoiceXmlGenerator.Generate(invoice);

        var actualUuid = request?.GetType().GetProperty("uuid")?.GetValue(request, null);
        var actualInvoiceHash = request?.GetType().GetProperty("invoiceHash")?.GetValue(request, null);
        var actualInvoice = request?.GetType().GetProperty("invoice")?.GetValue(request, null);
        Assert.Multiple(() =>
        {
            Assert.That(actualInvoiceHash, Is.Not.Null);
            Assert.That(actualInvoice, Is.Not.Null);
        });
        Assert.That(actualUuid, Is.EqualTo(invoice.UUID));
        Assert.Pass();
    }
}