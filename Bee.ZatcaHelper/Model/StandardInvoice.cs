namespace Bee.ZatcaHelper.Model;

public class StandardInvoice
{
    public string Id { get; set; }
    public string UUID { get; set; }
    public string IssuedDate { get; set; }
    public string IssuedTime { get; set; }
    public string InvoiceTypeCode { get; set; }
    public string DocumentCurrencyCode { get; set; }
    public string TaxCurrencyCode { get; set; }
    public string PreviousInvoiceHash { get; set; }
    public string ActualDeliveryDate { get; set; }
    public string LatestDeliveryDate { get; set; }
    
    
    
    public SupplierInfo SupplierInfo { get; set; }
    public CustomerInfo CustomerInfo { get; set; }
    public InvoiceLineItem InvoiceLineItem { get; set; }
    public LegalMonetaryTotal LegalMonetaryTotal { get; set; }
    public TaxTotal TaxTotal { get; set; }
   
}