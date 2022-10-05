using System.Xml;
using Bee.ZatcaHelper.Model;

namespace Bee.ZatcaHelper.Util;

public static class XmlHelper
{
    public static void SetNodeValue(this XmlDocument xmlDocument, string xPath, string? value)
    {
        var xmlNode = xmlDocument.SelectSingleNode(xPath);
        if (xmlNode == null)
            return;
        if (value != null) xmlNode.InnerText = value;
    }

    public static void RemoveNode(this XmlDocument xmlDocument, string xPath)
    {
        var xmlNode = xmlDocument.SelectSingleNode(xPath);
        xmlNode?.ParentNode?.RemoveChild(xmlNode);
    }

    public static void SetAttributeValue(this XmlDocument xmlDocument, string xPath, string attributeName,
        string? value)
    {
        var xmlNode = xmlDocument.SelectSingleNode(xPath);
        if (xmlNode?.Attributes == null) return;
        foreach (XmlAttribute attribute in xmlNode.Attributes)
        {
            if (attribute.Name == attributeName)
                attribute.Value = value;
        }
    }

    public static void SetCurrencyNodeValue(this XmlDocument xmlDocument, string xPath, string? value, string? attributeValue)
    {
     const string currencyIdAttributeName = "currencyID";
        
        var xmlNode = xmlDocument.SelectSingleNode(xPath);
        if (xmlNode?.Attributes == null) return;
        foreach (XmlAttribute attribute in xmlNode.Attributes)
        {
            if (attribute.Name == currencyIdAttributeName)
                attribute.Value = attributeValue;
        }

        if (value != null) xmlNode.InnerText = value;
    }
    
    public static void SetCurrencyNodeValue(this XmlDocument xmlDocument, string xPath, Money money)
    {
        const string currencyIdAttributeName = "currencyID";
        
        var xmlNode = xmlDocument.SelectSingleNode(xPath);
        if (xmlNode?.Attributes == null) return;
        foreach (XmlAttribute attribute in xmlNode.Attributes)
        {
            if (attribute.Name == currencyIdAttributeName)
                attribute.Value = money.CurrencyCode;
        }

        xmlNode.InnerText = money.GetAmountString();
    }
    
    public static string? GetNodeValue(this XmlDocument xmlDocument, string xPath)
    {
        var xmlNode = xmlDocument.SelectSingleNode(xPath);
        return xmlNode?.InnerText;
    }
}