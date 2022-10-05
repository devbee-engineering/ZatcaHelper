namespace Bee.ZatcaHelper.Util;

public static class EmbeddedResourceHelper
{
    public static string? GetFileContent(this Type type,string fileName)
    {
        var fullyQualifiedName = type.Namespace + "." + fileName;
        using var stream = typeof(Bee.ZatcaHelper.StandardInvoiceXmlGenerator).Assembly.GetManifestResourceStream(fullyQualifiedName);
        if (stream == null) return null;
        using var reader = new StreamReader(stream);
        var fileContent = reader.ReadToEnd();
        return fileContent;
    }
    
    public static StreamReader? GetFileContentAsStream(this Type type,string fileName)
    {
        var fullyQualifiedName = type.Namespace + "." + fileName;
        var stream = typeof(Bee.ZatcaHelper.StandardInvoiceXmlGenerator).Assembly.GetManifestResourceStream(fullyQualifiedName);
        return stream == null ? null : new StreamReader(stream);
    }
}