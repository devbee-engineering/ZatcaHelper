namespace Bee.ZatcaHelper.Model;

public class InvoiceLineItem
{
    public string ID { get; set; }
    public string InvoicedQuantity { get; set; }
    public Money LineExtensionAmount { get; set; }
    public Money TaxAmount { get; set; }
    public Money RoundingAmount { get; set; }
    public string TaxSchemeId { get; set; }
    public string TaxScheme { get; set; }
    public string TaxPercent { get; set; }
    public string ItemName { get; set; }
    
    //rate of item
    public Money PriceAmount { get; set; }
    
}