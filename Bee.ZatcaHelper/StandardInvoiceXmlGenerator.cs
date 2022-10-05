using System.Xml;
using Bee.ZatcaHelper.Model;
using Bee.ZatcaHelper.Util;

namespace Bee.ZatcaHelper;

public static partial class StandardInvoiceXmlGenerator
{
    private const string StandardInvoiceXmlFormat = "StandardInvoiceTemplate.xml";
    private static string? _currentHash;
    public  static object  Generate(StandardInvoice standardInvoice)
    {
        
        var xmlDoc = new XmlDocument
        {
            PreserveWhitespace = true
        };
        var xmlString = typeof(Bee.ZatcaHelper.StandardInvoiceXmlGenerator).GetFileContent(StandardInvoiceXmlFormat);


        xmlDoc.LoadXml(xmlString);
        PopulateInvoiceBasicInfo(xmlDoc, standardInvoice);
        PopulateSupplierInfo(xmlDoc, standardInvoice);
        PopulateCustomerInfo(xmlDoc, standardInvoice);
        PopulateDiscountInfo(xmlDoc, standardInvoice);
        PopulateTaxTotals(xmlDoc, standardInvoice);
        PopulateInvoiceLineItems(xmlDoc, standardInvoice);
        PopulateTotals(xmlDoc, standardInvoice);
        PopulateInvoiceHash(xmlDoc);

        

        var xmlBytes = System.Text.Encoding.UTF8.GetBytes(xmlDoc.OuterXml);
        var sample = xmlDoc.OuterXml;

        var resultAPiCall = new
        {
            invoiceHash = _currentHash,
            uuid = standardInvoice.UUID,
            invoice = Convert.ToBase64String(xmlBytes)
        };

        // Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(resultAPiCall));
        // Console.WriteLine(xmlDoc.OuterXml);
        
        return resultAPiCall;
    }

    private static void PopulateInvoiceHash(XmlDocument xmlDoc)
    {
        _currentHash = InvoiceHashHelper.GenerateEInvoiceHashing(xmlDoc.OuterXml);
        xmlDoc.SetNodeValue(HashXpath, _currentHash);
    }

    private static void PopulateTotals(XmlDocument xmlDoc, StandardInvoice standardInvoice)
    {
        xmlDoc.SetCurrencyNodeValue(LegalMonetaryTotalLineExtensionAmountXpath, standardInvoice.LegalMonetaryTotal.LineExtensionAmount);
        xmlDoc.SetCurrencyNodeValue(LegalMonetaryTotalTaxExclusiveAmountXpath, standardInvoice.LegalMonetaryTotal.TaxExclusiveAmount);
        xmlDoc.SetCurrencyNodeValue(LegalMonetaryTotalTaxInclusiveAmountXpath, standardInvoice.LegalMonetaryTotal.TaxInclusiveAmount);
        xmlDoc.SetCurrencyNodeValue(LegalMonetaryTotalAllowanceTotalAmountXpath, standardInvoice.LegalMonetaryTotal.AllowanceTotalAmount);
        xmlDoc.SetCurrencyNodeValue(LegalMonetaryTotalAllowanceTotalAmountXpath, standardInvoice.LegalMonetaryTotal.AllowanceTotalAmount);
        xmlDoc.SetCurrencyNodeValue(LegalMonetaryTotalPrepaidAmountXpath, standardInvoice.LegalMonetaryTotal.PrepaidAmount);
        xmlDoc.SetCurrencyNodeValue(LegalMonetaryTotalPayableAmountXpath, standardInvoice.LegalMonetaryTotal.PayableAmount);
    }

    private static void PopulateInvoiceLineItems(XmlDocument xmlDoc, StandardInvoice standardInvoice)
    {
        xmlDoc.SetNodeValue(LineItemIdXpath, standardInvoice.InvoiceLineItem.ID);
        xmlDoc.SetNodeValue(LineItemInvoicedQuantityXpath, standardInvoice.InvoiceLineItem.InvoicedQuantity);
        xmlDoc.SetCurrencyNodeValue(LineItemLineExtensionAmountXpath, standardInvoice.InvoiceLineItem.LineExtensionAmount);
        xmlDoc.SetCurrencyNodeValue(LineItemTaxAmountXpath, standardInvoice.InvoiceLineItem.TaxAmount);
        xmlDoc.SetCurrencyNodeValue(LineItemRoundingAmountXpath, standardInvoice.InvoiceLineItem.RoundingAmount);
        xmlDoc.SetNodeValue(LineItemNameXpath, standardInvoice.InvoiceLineItem.ItemName);
        xmlDoc.SetNodeValue(LineItemTaxPercentXpath, standardInvoice.InvoiceLineItem.TaxPercent);
        xmlDoc.SetNodeValue(LineItemTaxClassificationIdXpath, standardInvoice.InvoiceLineItem.TaxSchemeId);
        xmlDoc.SetNodeValue(LineItemTaxSchemeXpath, standardInvoice.InvoiceLineItem.TaxScheme);
        xmlDoc.SetCurrencyNodeValue(LineItemPriceAmountXpath, standardInvoice.InvoiceLineItem.PriceAmount);

        // TODO : implement Allowance charge 
        
        xmlDoc.RemoveNode(LineItemAllowanceXpath);
    }

    private static void PopulateTaxTotals(XmlDocument xmlDoc, StandardInvoice standardInvoice)
    {
        //TODO: Need to handle tax exemption
        
        xmlDoc.SetCurrencyNodeValue(TaxTotalTaxAmountXpath, standardInvoice.TaxTotal.TaxAmount);
        xmlDoc.SetCurrencyNodeValue(TaxTotalTaxAmountSecondTagXpath, standardInvoice.TaxTotal.TaxAmount);
        xmlDoc.SetCurrencyNodeValue(TaxTotalSubTotalTaxableAmountXpath,standardInvoice.TaxTotal.TaxableAmount);
        xmlDoc.SetCurrencyNodeValue(TaxTotalSubTotalTaxAmountXpath,standardInvoice.TaxTotal.TaxAmount);
        xmlDoc.SetNodeValue(TaxTotalSubTotalTaxCategoryIdTaxAmountXpath,standardInvoice.TaxTotal.TaxCategory);
    }

    private static void PopulateDiscountInfo(XmlDocument xmlDoc, StandardInvoice standardInvoice)
    {
        // TODO : implement Allowance charge 
        
        xmlDoc.RemoveNode(AllowanceXpath);
    }

    private static void PopulateCustomerInfo(XmlDocument xmlDoc, StandardInvoice standardInvoice)
    {
        xmlDoc.SetNodeValue(CustomerStreetNameXpath, standardInvoice.CustomerInfo.PartyPostalAddress.StreetName);
        xmlDoc.SetNodeValue(CustomerBuildingNumberXpath, standardInvoice.CustomerInfo.PartyPostalAddress.BuildingNumber);
        xmlDoc.SetNodeValue(CustomerPlotIdentificationXpath, standardInvoice.CustomerInfo.PartyPostalAddress.PlotIdentification);
        xmlDoc.SetNodeValue(CustomerCitySubdivisionNameXpath, standardInvoice.CustomerInfo.PartyPostalAddress.CitySubdivisionName);
        xmlDoc.SetNodeValue(CustomerCityNameXpath, standardInvoice.CustomerInfo.PartyPostalAddress.CityName);
        xmlDoc.SetNodeValue(CustomerPostalZoneXpath, standardInvoice.CustomerInfo.PartyPostalAddress.PostalZone);
        xmlDoc.SetNodeValue(CustomerCountrySubEntityXpath, standardInvoice.CustomerInfo.PartyPostalAddress.CountrySubentity);
        xmlDoc.SetNodeValue(CustomerCountryXpath, standardInvoice.CustomerInfo.PartyPostalAddress.Country);
        xmlDoc.SetNodeValue(CustomerRegistrationNameXpath, standardInvoice.CustomerInfo.RegistrationName);
        xmlDoc.SetNodeValue(CustomerNatXpath, standardInvoice.CustomerInfo.NAT);
        xmlDoc.SetNodeValue(CustomerTaxSchemeXpath, "VAT");
    }

    private static void PopulateSupplierInfo(XmlDocument xmlDoc, StandardInvoice standardInvoice)
    {
        xmlDoc.SetNodeValue(SupplierStreetNameXpath, standardInvoice.SupplierInfo.PartyPostalAddress.StreetName);
        xmlDoc.SetNodeValue(SupplierBuildingNumberXpath, standardInvoice.SupplierInfo.PartyPostalAddress.BuildingNumber);
        xmlDoc.SetNodeValue(SupplierPlotIdentificationXpath, standardInvoice.SupplierInfo.PartyPostalAddress.PlotIdentification);
        xmlDoc.SetNodeValue(SupplierCitySubdivisionNameXpath, standardInvoice.SupplierInfo.PartyPostalAddress.CitySubdivisionName);
        xmlDoc.SetNodeValue(SupplierCityNameXpath, standardInvoice.SupplierInfo.PartyPostalAddress.CityName);
        xmlDoc.SetNodeValue(SupplierPostalZoneXpath, standardInvoice.SupplierInfo.PartyPostalAddress.PostalZone);
        xmlDoc.SetNodeValue(SupplierCountrySubEntityXpath, standardInvoice.SupplierInfo.PartyPostalAddress.CountrySubentity);
        xmlDoc.SetNodeValue(SupplierCountryXpath, standardInvoice.SupplierInfo.PartyPostalAddress.Country);
        xmlDoc.SetNodeValue(SupplierRegistrationNameXpath, standardInvoice.SupplierInfo.RegistrationName);
        xmlDoc.SetNodeValue(SupplierTaxSchemeXpath, "VAT");
        xmlDoc.SetNodeValue(SupplierCrnXpath, standardInvoice.SupplierInfo.CRN);
    }

    private static void PopulateInvoiceBasicInfo(XmlDocument xmlDoc, StandardInvoice standardInvoice)
    {
        xmlDoc.SetNodeValue(InvoiceIdXpath, standardInvoice.Id);
        xmlDoc.SetNodeValue(InvoiceUuidXpath, standardInvoice.UUID);
        xmlDoc.SetNodeValue(InvoiceActualDeliveryDateXpath, standardInvoice.ActualDeliveryDate);
        xmlDoc.SetNodeValue(InvoiceDocumentCurrencyCodeXpath, standardInvoice.DocumentCurrencyCode);
        xmlDoc.SetNodeValue(InvoiceTaxCurrencyCodeXpath, standardInvoice.TaxCurrencyCode);
        xmlDoc.SetNodeValue(InvoiceIssueDateXpath, standardInvoice.IssuedDate);
        xmlDoc.SetNodeValue(InvoiceIssueTimeXpath, standardInvoice.IssuedTime);
        xmlDoc.SetNodeValue(InvoiceLatestDeliveryDateXpath, standardInvoice.LatestDeliveryDate);
        xmlDoc.SetNodeValue(InvoicePreviousInvoiceHashXpath, standardInvoice.PreviousInvoiceHash);
    }
}