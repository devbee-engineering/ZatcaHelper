namespace Zatca_Standard_Invoice_Integration_Client.Contracts;

public class InvoiceClearanceRequest
{
    public InvoiceClearanceRequest(object body, string binaryToken, string secret)
    {
        Body = body;
        BinaryToken = binaryToken;
        Secret = secret;
    }

    public object Body { get; }
    public string BinaryToken { get; }
    public string Secret { get; }
}