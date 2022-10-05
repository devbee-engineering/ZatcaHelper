using Bee.ZatcaHelper.Util;

namespace Bee.ZatcaHelper.UnitTests.UtilTests;

public class InvoiceHashHelperTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ShouldGenerateValidHashForProvidedInvoice()
    {
        const string expectedHash = "UVySRXxjE3r+aWN93hfnhc2w15aoaZO0v9pQtOKpupA=";
        var xmlString = typeof(StandardInvoiceXmlGenerator).GetFileContent("StandardInvoiceTemplate.xml");
        var actualHash = InvoiceHashHelper.GenerateEInvoiceHashing(xmlString);
        Assert.That(actualHash, Is.EqualTo(expectedHash));
        Assert.Pass();
    }
}