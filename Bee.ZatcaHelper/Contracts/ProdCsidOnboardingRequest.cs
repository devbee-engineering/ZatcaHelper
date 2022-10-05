namespace Bee.ZatcaHelper.Contracts;

public class ProdCsidOnboardingRequest
{
    public ProdCsidOnboardingRequest(long complianceRequestId, string csrBinaryToken, string csrSecret)
    {
        ComplianceRequestId = complianceRequestId;
        CsrBinaryToken = csrBinaryToken;
        CsrSecret = csrSecret;
    }

    public long ComplianceRequestId { get; }
    public string CsrBinaryToken { get; }
    public string CsrSecret { get; }
}