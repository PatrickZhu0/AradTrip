using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

// Token: 0x02000196 RID: 406
internal static class TR
{
	// Token: 0x06000C7B RID: 3195 RVA: 0x0003DE70 File Offset: 0x0003C270
	public static bool Initialize(TR.EType type)
	{
		TR.Clear();
		string text = (Singleton<AssetLoader>.instance.LoadRes(TR.m_internationalRes, true, 0U).obj as TextAsset).text;
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(text);
		string xpath = "International/" + Enum.GetName(typeof(TR.EType), type);
		XmlNode xmlNode = xmlDocument.SelectSingleNode(xpath);
		if (xmlNode != null)
		{
			for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
			{
				XmlNode xmlNode2 = xmlNode.ChildNodes[i];
				if (xmlNode2.LocalName == "T")
				{
					XmlElement xmlElement = xmlNode2 as XmlElement;
					string attribute = xmlElement.GetAttribute("Key");
					if (!TR.ms_table.ContainsKey(attribute))
					{
						TR.ms_table.Add(attribute, xmlElement.GetAttribute("Value"));
					}
					else
					{
						Logger.LogErrorFormat("initialize tr data error!! key:{0} repeated!!", new object[]
						{
							attribute
						});
					}
				}
			}
			return true;
		}
		Logger.LogErrorFormat("initialize tr data error!! file path:{0}", new object[]
		{
			TR.m_internationalRes
		});
		return false;
	}

	// Token: 0x06000C7C RID: 3196 RVA: 0x0003DF98 File Offset: 0x0003C398
	public static void Clear()
	{
		TR.ms_table.Clear();
	}

	// Token: 0x06000C7D RID: 3197 RVA: 0x0003DFA4 File Offset: 0x0003C3A4
	public static string Value(string key)
	{
		string text;
		if (TR.ms_table.TryGetValue(key, out text))
		{
			return text.Replace("\\n", "\n");
		}
		Logger.LogErrorFormat("TR can not find key:{0}", new object[]
		{
			key
		});
		return key;
	}

	// Token: 0x06000C7E RID: 3198 RVA: 0x0003DFEC File Offset: 0x0003C3EC
	public static string Value(string key, object arg0)
	{
		string format;
		if (TR.ms_table.TryGetValue(key, out format))
		{
			return string.Format(format, arg0);
		}
		Logger.LogErrorFormat("TR can not find key:{0}", new object[]
		{
			key
		});
		return key;
	}

	// Token: 0x06000C7F RID: 3199 RVA: 0x0003E028 File Offset: 0x0003C428
	public static string Value(string key, object arg0, object arg1)
	{
		string format;
		if (TR.ms_table.TryGetValue(key, out format))
		{
			return string.Format(format, arg0, arg1);
		}
		Logger.LogErrorFormat("TR can not find key:{0}", new object[]
		{
			key
		});
		return key;
	}

	// Token: 0x06000C80 RID: 3200 RVA: 0x0003E068 File Offset: 0x0003C468
	public static string Value(string key, object arg0, object arg1, object arg2)
	{
		string format;
		if (TR.ms_table.TryGetValue(key, out format))
		{
			return string.Format(format, arg0, arg1, arg2);
		}
		Logger.LogErrorFormat("TR can not find key:{0}", new object[]
		{
			key
		});
		return key;
	}

	// Token: 0x06000C81 RID: 3201 RVA: 0x0003E0A8 File Offset: 0x0003C4A8
	public static string Value(string key, object arg0, object arg1, object arg2, object arg3)
	{
		string format;
		if (TR.ms_table.TryGetValue(key, out format))
		{
			return string.Format(format, new object[]
			{
				arg0,
				arg1,
				arg2,
				arg3
			});
		}
		Logger.LogErrorFormat("TR can not find key:{0}", new object[]
		{
			key
		});
		return key;
	}

	// Token: 0x06000C82 RID: 3202 RVA: 0x0003E0FC File Offset: 0x0003C4FC
	public static string Value(string key, object arg0, object arg1, object arg2, object arg3, object arg4)
	{
		string format;
		if (TR.ms_table.TryGetValue(key, out format))
		{
			return string.Format(format, new object[]
			{
				arg0,
				arg1,
				arg2,
				arg3,
				arg4
			});
		}
		Logger.LogErrorFormat("TR can not find key:{0}", new object[]
		{
			key
		});
		return key;
	}

	// Token: 0x06000C83 RID: 3203 RVA: 0x0003E154 File Offset: 0x0003C554
	public static string Value(string key, object[] args)
	{
		string format;
		if (TR.ms_table.TryGetValue(key, out format))
		{
			return string.Format(format, args);
		}
		Logger.LogErrorFormat("TR can not find key:{0}", new object[]
		{
			key
		});
		return key;
	}

	// Token: 0x04000898 RID: 2200
	private static Dictionary<string, string> ms_table = new Dictionary<string, string>();

	// Token: 0x04000899 RID: 2201
	private static string m_internationalRes = "Data/Language/International.xml";

	// Token: 0x02000197 RID: 407
	public enum EType
	{
		// Token: 0x0400089B RID: 2203
		CN,
		// Token: 0x0400089C RID: 2204
		EN
	}
}
