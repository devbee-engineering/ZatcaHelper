namespace Bee.ZatcaHelper.Model;

public class LegalMonetaryTotal
{
    public Money LineExtensionAmount { get; set; }
    public Money TaxExclusiveAmount { get; set; }
    public Money TaxInclusiveAmount { get; set; }
    public Money AllowanceTotalAmount { get; set; }
    public Money PrepaidAmount { get; set; }
    public Money PayableAmount { get; set; }
}