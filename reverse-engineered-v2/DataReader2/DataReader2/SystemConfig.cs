using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace DataReader2;

public class SystemConfig
{
	private static string CONFIG_FILE = "SystemConfig.xml";

	private static string GetWorkDirectory()
	{
		try
		{
			return Path.GetDirectoryName(typeof(SystemConfig).Assembly.Location);
		}
		catch
		{
			return Application.StartupPath;
		}
	}

	private static bool IsEmptyString(string szString)
	{
		if (szString == null)
		{
			return true;
		}
		if (szString.Trim() == string.Empty)
		{
			return true;
		}
		return false;
	}

	private static bool CreateXmlFile(string szFileName, string szRootName)
	{
		if (szFileName == null || szFileName.Trim() == "")
		{
			return false;
		}
		if (szRootName == null || szRootName.Trim() == "")
		{
			return false;
		}
		XmlDocument clsXmlDoc = new XmlDocument();
		clsXmlDoc.AppendChild(clsXmlDoc.CreateXmlDeclaration("1.0", "GBK", null));
		clsXmlDoc.AppendChild(clsXmlDoc.CreateNode(XmlNodeType.Element, szRootName, ""));
		try
		{
			clsXmlDoc.Save(szFileName);
			return true;
		}
		catch
		{
			return false;
		}
	}

	private static XmlDocument GetXmlDocument(string szXmlFile)
	{
		if (IsEmptyString(szXmlFile))
		{
			return null;
		}
		if (!File.Exists(szXmlFile))
		{
			return null;
		}
		XmlDocument clsXmlDoc = new XmlDocument();
		try
		{
			clsXmlDoc.Load(szXmlFile);
		}
		catch
		{
			return null;
		}
		return clsXmlDoc;
	}

	private static bool SaveXmlDocument(XmlDocument clsXmlDoc, string szXmlFile)
	{
		if (clsXmlDoc == null)
		{
			return false;
		}
		if (IsEmptyString(szXmlFile))
		{
			return false;
		}
		try
		{
			if (File.Exists(szXmlFile))
			{
				File.Delete(szXmlFile);
			}
		}
		catch
		{
			return false;
		}
		try
		{
			clsXmlDoc.Save(szXmlFile);
		}
		catch
		{
			return false;
		}
		return true;
	}

	private static XmlNode SelectXmlNode(XmlNode clsRootNode, string szXPath)
	{
		if (clsRootNode == null || IsEmptyString(szXPath))
		{
			return null;
		}
		try
		{
			return clsRootNode.SelectSingleNode(szXPath);
		}
		catch
		{
			return null;
		}
	}

	private static XmlNodeList SelectXmlNodes(XmlNode clsRootNode, string szXPath)
	{
		if (clsRootNode == null || IsEmptyString(szXPath))
		{
			return null;
		}
		try
		{
			return clsRootNode.SelectNodes(szXPath);
		}
		catch
		{
			return null;
		}
	}

	private static XmlNode CreateXmlNode(XmlNode clsParentNode, string szNodeName)
	{
		try
		{
			XmlDocument clsXmlDoc = null;
			clsXmlDoc = ((!(clsParentNode.GetType() != typeof(XmlDocument))) ? (clsParentNode as XmlDocument) : clsParentNode.OwnerDocument);
			XmlNode clsXmlNode = clsXmlDoc.CreateNode(XmlNodeType.Element, szNodeName, string.Empty);
			if (clsParentNode.GetType() == typeof(XmlDocument))
			{
				clsXmlDoc.LastChild.AppendChild(clsXmlNode);
			}
			else
			{
				clsParentNode.AppendChild(clsXmlNode);
			}
			return clsXmlNode;
		}
		catch
		{
			return null;
		}
	}

	private static bool SetXmlAttr(XmlNode clsXmlNode, string szAttrName, string szAttrValue)
	{
		if (clsXmlNode == null)
		{
			return false;
		}
		if (IsEmptyString(szAttrName))
		{
			return false;
		}
		if (IsEmptyString(szAttrValue))
		{
			szAttrValue = string.Empty;
		}
		XmlAttribute clsAttrNode = clsXmlNode.Attributes.GetNamedItem(szAttrName) as XmlAttribute;
		if (clsAttrNode == null)
		{
			XmlDocument clsXmlDoc = clsXmlNode.OwnerDocument;
			if (clsXmlDoc == null)
			{
				return false;
			}
			clsAttrNode = clsXmlDoc.CreateAttribute(szAttrName);
			clsXmlNode.Attributes.Append(clsAttrNode);
		}
		clsAttrNode.Value = szAttrValue;
		return true;
	}

	public static int GetConfigData(string szKeyName, int nDefaultValue)
	{
		string szValue = GetConfigData(szKeyName, nDefaultValue.ToString());
		try
		{
			return int.Parse(szValue);
		}
		catch
		{
			return nDefaultValue;
		}
	}

	public static float GetConfigData(string szKeyName, float fDefaultValue)
	{
		string szValue = GetConfigData(szKeyName, fDefaultValue.ToString());
		try
		{
			return float.Parse(szValue);
		}
		catch
		{
			return fDefaultValue;
		}
	}

	public static bool GetConfigData(string szKeyName, bool bDefaultValue)
	{
		string szValue = GetConfigData(szKeyName, bDefaultValue.ToString());
		try
		{
			return bool.Parse(szValue);
		}
		catch
		{
			return bDefaultValue;
		}
	}

	public static string GetConfigData(string szKeyName, string szDefaultValue)
	{
		string szConfigFile = $"{GetWorkDirectory()}\\{CONFIG_FILE}";
		if (!File.Exists(szConfigFile))
		{
			return szDefaultValue;
		}
		XmlDocument clsXmlDoc = GetXmlDocument(szConfigFile);
		if (clsXmlDoc == null)
		{
			return szDefaultValue;
		}
		string szXPath = $".//key[@name='{szKeyName}']";
		XmlNode clsXmlNode = SelectXmlNode(clsXmlDoc, szXPath);
		if (clsXmlNode == null)
		{
			return szDefaultValue;
		}
		XmlNode clsValueAttr = clsXmlNode.Attributes.GetNamedItem("value");
		if (clsValueAttr == null)
		{
			return szDefaultValue;
		}
		return clsValueAttr.Value;
	}

	public static bool WriteConfigData(string szKeyName, string szValue)
	{
		string szConfigFile = $"{GetWorkDirectory()}\\{CONFIG_FILE}";
		if (!File.Exists(szConfigFile) && !CreateXmlFile(szConfigFile, "SystemConfig"))
		{
			return false;
		}
		XmlDocument clsXmlDoc = GetXmlDocument(szConfigFile);
		string szXPath = $".//key[@name='{szKeyName}']";
		XmlNode clsXmlNode = SelectXmlNode(clsXmlDoc, szXPath);
		if (clsXmlNode == null)
		{
			clsXmlNode = CreateXmlNode(clsXmlDoc, "key");
		}
		if (!SetXmlAttr(clsXmlNode, "name", szKeyName))
		{
			return false;
		}
		if (!SetXmlAttr(clsXmlNode, "value", szValue))
		{
			return false;
		}
		return SaveXmlDocument(clsXmlDoc, szConfigFile);
	}
}
