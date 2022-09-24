namespace Zatca_Standard_Invoice_Integration_Client.Util;

public static class Embeddedresourcehelper
{
    public static string? GetFileContent(this Type type,string fileName)
    {
        var fullyQualifiedName = type.Namespace + "." + fileName;
        using var stream = typeof(StandardInvoiceXmlGenerator).Assembly.GetManifestResourceStream(fullyQualifiedName);
        if (stream == null) return null;
        using var reader = new StreamReader(stream);
        var fileContent = reader.ReadToEnd();
        return fileContent;
    }
    
    public static StreamReader? GetFileContentAsStream(this Type type,string fileName)
    {
        var fullyQualifiedName = type.Namespace + "." + fileName;
        var stream = typeof(StandardInvoiceXmlGenerator).Assembly.GetManifestResourceStream(fullyQualifiedName);
        return stream == null ? null : new StreamReader(stream);
    }
}