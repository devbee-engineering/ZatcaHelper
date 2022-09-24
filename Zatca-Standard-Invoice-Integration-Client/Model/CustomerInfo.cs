namespace Zatca_Standard_Invoice_Integration_Client.Model;

public class CustomerInfo
{
    public string NAT { get; set; }
    public string VAT { get; set; }
    public string RegistrationName { get; set; }
    public PartyPostalAddress PartyPostalAddress { get; set; }
}