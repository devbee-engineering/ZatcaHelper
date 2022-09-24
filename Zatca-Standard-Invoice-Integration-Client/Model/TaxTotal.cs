namespace Zatca_Standard_Invoice_Integration_Client.Model;

public class TaxTotal
{
    public Money TaxAmount { get; set; }
    public Money TaxableAmount { get; set; }
    public string TaxCategory { get; set; }
    public string Percent { get; set; }
}