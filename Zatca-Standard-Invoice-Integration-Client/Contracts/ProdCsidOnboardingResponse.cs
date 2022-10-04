namespace Zatca_Standard_Invoice_Integration_Client.Contracts;

public class ProdCsidOnboardingResponse
{
    public long RequestId { get; set; }
    public string? DispositionMessage { get; set; }
    public string? BinarySecurityToken { get; set; }
    public string? Secret { get; set; }
    public string[]? Errors { get; set; }
}