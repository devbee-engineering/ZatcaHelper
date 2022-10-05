using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using Serilog;

namespace Bee.ZatcaHelper.Util;

public static class InvoiceHashHelper
{
    private const string StandardInvoiceHashingXslTemplate = "StandardInvoiceHashingTemplate.xsl";

    public static string? GenerateEInvoiceHashing(string xmlString)
    {
        try
        {
            var xslStream = typeof(InvoiceHashHelper).GetFileContentAsStream(StandardInvoiceHashingXslTemplate);
            string transformedXml;
            try
            {
                transformedXml = ApplyXslt(xmlString, xslStream);
            }
            catch
            {
                Log.Error("Can not apply XSL file");
                return null;
            }

            if (string.IsNullOrEmpty(transformedXml))
            {
                Log.Error("Error In applying XSL file");
                return null;
            }

            var canonicalizedXml = CanonicalizeXml(transformedXml);
            var hashValue = GetSha256Hash(Encoding.UTF8.GetString(canonicalizedXml?.ToArray() ?? Array.Empty<byte>()));
            if (hashValue.Any()) return Convert.ToBase64String(hashValue);
            Log.Error("Hashing Error");
            return null;
        }
        catch (Exception ex)
        {
            Log.Error(ex,ex.Message);
            return null;
        }
    }

    private static MemoryStream? CanonicalizeXml(string transformedXml)
    {
        using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(transformedXml));
        //converting xml to standard format
        //https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.xml.xmldsigc14ntransform?view=dotnet-plat-ext-6.0
        var canonicalizer = new XmlDsigC14NTransform(false);
        canonicalizer.LoadInput(memoryStream);
        var canonicalizedXml = canonicalizer.GetOutput() as MemoryStream;
        return canonicalizedXml;
    }


    private static byte[] GetSha256Hash(string value)
    {
        using var shA256 = SHA256.Create();
        var utF8 = Encoding.UTF8;
        return shA256.ComputeHash(utF8.GetBytes(value));
    }

    private static string ApplyXslt(string xmlContent, StreamReader? xslFile)
    {
        var xmlReader = XmlReader.Create(new StringReader(xmlContent));
        var output = new StringBuilder();
        using (var results = XmlWriter.Create(output, new XmlWriterSettings()
               {
                   OmitXmlDeclaration = true,
                   Encoding = Encoding.UTF8,
                   Indent = false
               }))
        {
            if (xslFile != null)
            {
                var stylesheet = XmlReader.Create(xslFile);

                var compiledTransform = new XslCompiledTransform();
                compiledTransform.Load(stylesheet);
                compiledTransform.Transform(xmlReader, results);
            }
        }

        xslFile?.Close();
        return output.ToString();
    }
}