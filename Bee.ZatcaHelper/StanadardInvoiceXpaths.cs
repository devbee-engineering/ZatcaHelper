namespace Bee.ZatcaHelper;

public  static partial class StandardInvoiceXmlGenerator
{
    public   const string QrCodeXpath = "/*[local-name() = 'Invoice']/*[local-name() = 'AdditionalDocumentReference' and *[local-name()='ID' and .='QR']]/*[local-name() = 'Attachment']/*[local-name() = 'EmbeddedDocumentBinaryObject']";

    private const  string InvoicePreviousInvoiceHashXpath = "/*[local-name() = 'Invoice']/*[local-name() = 'AdditionalDocumentReference' and *[local-name()='ID' and .='PIH']]/*[local-name() = 'Attachment']/*[local-name() = 'EmbeddedDocumentBinaryObject']";

    private const string HashXpath = "/*[local-name() = 'Invoice']/*[local-name() = 'UBLExtensions']/*[local-name() = 'UBLExtension']/*[local-name() = 'ExtensionContent']/*[local-name() = 'UBLDocumentSignatures']/*[local-name() = 'SignatureInformation']/*[local-name() = 'Signature']/*[local-name() = 'SignedInfo']/*[local-name() = 'Reference' and @Id='invoiceSignedData']/*[local-name() = 'DigestValue']";

    private const  string InvoiceIdXpath = "/*[local-name() = 'Invoice']/*[local-name() = 'ID']";
    private const string InvoiceUuidXpath = "/*[local-name() = 'Invoice']/*[local-name() = 'UUID']";

    private const string InvoiceActualDeliveryDateXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'ActualDeliveryDate']";

    private const string InvoiceDocumentCurrencyCodeXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'DocumentCurrencyCode']";

    private const string InvoiceTaxCurrencyCodeXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'TaxCurrencyCode']";

    private const string InvoiceIssueDateXpath = "/*[local-name() = 'Invoice']/*[local-name() = 'IssueDate']";
    private const string InvoiceIssueTimeXpath = "/*[local-name() = 'Invoice']/*[local-name() = 'IssueTime']";

    private const string InvoiceLatestDeliveryDateXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'Delivery']/*[local-name() = 'LatestDeliveryDate']";

    private const string SupplierStreetNameXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'AccountingSupplierParty']/*[local-name() = 'Party']/*[local-name() = 'PostalAddress']/*[local-name() = 'StreetName']";

    private const string SupplierBuildingNumberXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'AccountingSupplierParty']/*[local-name() = 'Party']/*[local-name() = 'PostalAddress']/*[local-name() = 'BuildingNumber']";

    private const string SupplierPlotIdentificationXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'AccountingSupplierParty']/*[local-name() = 'Party']/*[local-name() = 'PostalAddress']/*[local-name() = 'PlotIdentification']";

    private const string SupplierCitySubdivisionNameXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'AccountingSupplierParty']/*[local-name() = 'Party']/*[local-name() = 'PostalAddress']/*[local-name() = 'CitySubdivisionName']";

    private const string SupplierCityNameXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'AccountingSupplierParty']/*[local-name() = 'Party']/*[local-name() = 'PostalAddress']/*[local-name() = 'CityName']";

    private const string SupplierPostalZoneXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'AccountingSupplierParty']/*[local-name() = 'Party']/*[local-name() = 'PostalAddress']/*[local-name() = 'PostalZone']";

    private const string SupplierCountrySubEntityXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'AccountingSupplierParty']/*[local-name() = 'Party']/*[local-name() = 'PostalAddress']/*[local-name() = 'CountrySubentity']";

    private const string SupplierCountryXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'AccountingSupplierParty']/*[local-name() = 'Party']/*[local-name() = 'PostalAddress']/*[local-name() = 'Country']/*[local-name() = 'Country']";

    private const string SupplierRegistrationNameXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'AccountingSupplierParty']/*[local-name() = 'Party']/*[local-name() = 'PartyLegalEntity']/*[local-name() = 'RegistrationName']";

    private const string SupplierCrnXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'AccountingSupplierParty']/*[local-name() = 'Party']/*[local-name() = 'PartyIdentification']/*[local-name() = 'ID']";

    private const string SupplierTaxSchemeXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'AccountingSupplierParty']/*[local-name() = 'Party']/*[local-name() = 'PartyTaxScheme']/*[local-name() = 'TaxScheme']/*[local-name() = 'ID']";

    private const string CustomerStreetNameXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'AccountingCustomerParty']/*[local-name() = 'Party']/*[local-name() = 'PostalAddress']/*[local-name() = 'StreetName']";

    private const string CustomerBuildingNumberXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'AccountingCustomerParty']/*[local-name() = 'Party']/*[local-name() = 'PostalAddress']/*[local-name() = 'BuildingNumber']";

    private const string CustomerPlotIdentificationXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'AccountingCustomerParty']/*[local-name() = 'Party']/*[local-name() = 'PostalAddress']/*[local-name() = 'PlotIdentification']";

    private const string CustomerCitySubdivisionNameXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'AccountingCustomerParty']/*[local-name() = 'Party']/*[local-name() = 'PostalAddress']/*[local-name() = 'CitySubdivisionName']";

    private const string CustomerCityNameXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'AccountingCustomerParty']/*[local-name() = 'Party']/*[local-name() = 'PostalAddress']/*[local-name() = 'CityName']";

    private const string CustomerPostalZoneXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'AccountingCustomerParty']/*[local-name() = 'Party']/*[local-name() = 'PostalAddress']/*[local-name() = 'PostalZone']";

    private const string CustomerCountrySubEntityXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'AccountingCustomerParty']/*[local-name() = 'Party']/*[local-name() = 'PostalAddress']/*[local-name() = 'CountrySubentity']";

    private const string CustomerCountryXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'AccountingCustomerParty']/*[local-name() = 'Party']/*[local-name() = 'PostalAddress']/*[local-name() = 'Country']/*[local-name() = 'Country']";

    private const string CustomerRegistrationNameXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'AccountingCustomerParty']/*[local-name() = 'Party']/*[local-name() = 'PartyLegalEntity']/*[local-name() = 'RegistrationName']";

    private const string CustomerNatXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'AccountingCustomerParty']/*[local-name() = 'Party']/*[local-name() = 'PartyIdentification']/*[local-name() = 'ID']";

    private const string CustomerTaxSchemeXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'AccountingCustomerParty']/*[local-name() = 'Party']/*[local-name() = 'PartyTaxScheme']/*[local-name() = 'TaxScheme']/*[local-name() = 'ID']";

    private const string AllowanceXpath = "/*[local-name() = 'Invoice']/*[local-name() = 'AllowanceCharge']";

    private const string TaxTotalTaxAmountXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'TaxTotal']/*[local-name() = 'TaxAmount']";

    private const string TaxTotalTaxAmountSecondTagXpath =
        "(/*[local-name() = 'Invoice']/*[local-name() = 'TaxTotal']/*[local-name() = 'TaxAmount'])[2]";

    private const string TaxTotalSubTotalTaxableAmountXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'TaxTotal']/*[local-name() = 'TaxSubtotal']/*[local-name() = 'TaxableAmount']";

    private const string TaxTotalSubTotalTaxAmountXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'TaxTotal']/*[local-name() = 'TaxSubtotal']/*[local-name() = 'TaxAmount']";

    private const string TaxTotalSubTotalTaxCategoryIdTaxAmountXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'TaxTotal']/*[local-name() = 'TaxSubtotal']/*[local-name() = 'TaxCategory']/*[local-name() = 'ID']";

    private const string TaxTotalSubTotalTaxPercentTaxAmountXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'TaxTotal']/*[local-name() = 'TaxSubtotal']/*[local-name() = 'TaxCategory']/*[local-name() = 'Percent']";

    private const string CurrencyIdAttributeName = "currencyID";

    private const string LineItemIdXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'InvoiceLine']/*[local-name() = 'ID']";

    private const string LineItemInvoicedQuantityXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'InvoiceLine']/*[local-name() = 'InvoicedQuantity']";

    private const string LineItemLineExtensionAmountXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'InvoiceLine']/*[local-name() = 'LineExtensionAmount']";

    private const string LineItemTaxAmountXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'InvoiceLine']/*[local-name() = 'TaxTotal']/*[local-name() = 'TaxAmount']";

    private const string LineItemRoundingAmountXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'InvoiceLine']/*[local-name() = 'TaxTotal']/*[local-name() = 'RoundingAmount']";

    private const string LineItemNameXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'InvoiceLine']/*[local-name() = 'Item']/*[local-name() = 'Name']";

    private const string LineItemTaxClassificationIdXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'InvoiceLine']/*[local-name() = 'Item']/*[local-name() = 'ClassifiedTaxCategory']/*[local-name() = 'ID']";

    private const string LineItemTaxPercentXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'InvoiceLine']/*[local-name() = 'Item']/*[local-name() = 'ClassifiedTaxCategory']/*[local-name() = 'Percent']";

    private const string LineItemTaxSchemeXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'InvoiceLine']/*[local-name() = 'Item']/*[local-name() = 'ClassifiedTaxCategory']/*[local-name() = 'TaxScheme']/*[local-name() = 'ID']";

    private const string LineItemPriceAmountXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'InvoiceLine']/*[local-name() = 'Price']/*[local-name() = 'PriceAmount']";

    private const string LineItemAllowanceXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'InvoiceLine']/*[local-name() = 'Price']/*[local-name() = 'AllowanceCharge']";

    private const string LegalMonetaryTotalLineExtensionAmountXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'LegalMonetaryTotal']/*[local-name() = 'LineExtensionAmount']";

    private const string LegalMonetaryTotalTaxExclusiveAmountXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'LegalMonetaryTotal']/*[local-name() = 'TaxExclusiveAmount']";

    private const string LegalMonetaryTotalTaxInclusiveAmountXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'LegalMonetaryTotal']/*[local-name() = 'TaxInclusiveAmount']";

    private const string LegalMonetaryTotalAllowanceTotalAmountXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'LegalMonetaryTotal']/*[local-name() = 'AllowanceTotalAmount']";

    private const string LegalMonetaryTotalPrepaidAmountXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'LegalMonetaryTotal']/*[local-name() = 'PrepaidAmount']";

    private const string LegalMonetaryTotalPayableAmountXpath =
        "/*[local-name() = 'Invoice']/*[local-name() = 'LegalMonetaryTotal']/*[local-name() = 'PayableAmount']";
}