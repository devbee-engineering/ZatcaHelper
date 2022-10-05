namespace Bee.ZatcaHelper.Model;

public class Money
{
    public Money(string currencyCode, double amount)
    {
        CurrencyCode = currencyCode;
        Amount = amount;
    }

    public string CurrencyCode { get; }
    public double Amount { get; }

    public string GetAmountString() => $"{Amount:0.00}";
}