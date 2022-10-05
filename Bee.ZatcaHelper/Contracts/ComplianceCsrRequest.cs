namespace Bee.ZatcaHelper.Contracts;

public class ComplianceCsrRequest
{
    public ComplianceCsrRequest(string otp, string csr)
    {
        Otp = otp;
        Csr = csr;
    }

    public string Otp { get; init; }
    public string Csr { get; init; }
}