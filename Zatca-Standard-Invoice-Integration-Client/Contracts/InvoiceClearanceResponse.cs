namespace Zatca_Standard_Invoice_Integration_Client.Contracts;

public class InvoiceClearanceResponse
{
    public string ClearanceStatus { get; set; }
    public string ClearedInvoice { get; set; }
    public object validationResults { get; set; }
    public string? Hash { get; set; }
    public string? GeneratedQR { get; set; }
}