using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace behaviac
{
	// Token: 0x02004839 RID: 18489
	public static class StringUtils
	{
		// Token: 0x0601A930 RID: 108848 RVA: 0x00837184 File Offset: 0x00835584
		private static bool IsArrayString(string str, int posStart, ref int posEnd)
		{
			bool flag = false;
			int length = str.Length;
			while (posStart < length)
			{
				char c = str[posStart++];
				if (char.IsDigit(c))
				{
					flag = true;
				}
				else
				{
					if (c == ':' && flag)
					{
						int num = 0;
						for (int i = posStart; i < length; i++)
						{
							char c2 = str[i];
							if (c2 == ';' && num == 0)
							{
								posEnd = i;
								break;
							}
							if (c2 == '{')
							{
								num++;
							}
							else if (c2 == '}')
							{
								num--;
							}
						}
						return true;
					}
					break;
				}
			}
			return false;
		}

		// Token: 0x0601A931 RID: 108849 RVA: 0x00837234 File Offset: 0x00835634
		private static int SkipPairedBrackets(string src, int indexBracketBegin)
		{
			if (!string.IsNullOrEmpty(src) && src[indexBracketBegin] == '{')
			{
				int num = 0;
				for (int i = indexBracketBegin; i < src.Length; i++)
				{
					if (src[i] == '{')
					{
						num++;
					}
					else if (src[i] == '}' && --num == 0)
					{
						return i;
					}
				}
			}
			return -1;
		}

		// Token: 0x0601A932 RID: 108850 RVA: 0x008372A8 File Offset: 0x008356A8
		public static List<string> SplitTokensForStruct(string src)
		{
			List<string> list = new List<string>();
			if (string.IsNullOrEmpty(src))
			{
				return list;
			}
			int num = StringUtils.SkipPairedBrackets(src, 0);
			int num2 = 1;
			int num3 = src.IndexOf(';', num2);
			while (num3 != -1)
			{
				if (num3 > num2)
				{
					int num4 = src.IndexOf('=', num2);
					int num5 = num4 - num2;
					string text = src.Substring(num2, num5);
					char c = src[num4 + 1];
					string item;
					if (c != '{')
					{
						num5 = num3 - num4 - 1;
						StringUtils.IsArrayString(src, num4 + 1, ref num3);
						num5 = num3 - num4 - 1;
						item = src.Substring(num4 + 1, num5);
					}
					else
					{
						int num6 = 0;
						num6 += num4 + 1;
						int num7 = StringUtils.SkipPairedBrackets(src, num6);
						num5 = num7 - num6 + 1;
						item = src.Substring(num4 + 1, num5);
						num3 = num4 + 1 + num5;
					}
					list.Add(item);
				}
				num2 = num3 + 1;
				num3 = src.IndexOf(';', num2);
				if (num3 > num)
				{
					break;
				}
			}
			return list;
		}

		// Token: 0x0601A933 RID: 108851 RVA: 0x008373A8 File Offset: 0x008357A8
		private static object FromStringStruct(Type type, string src)
		{
			object obj = Activator.CreateInstance(type);
			Dictionary<string, FieldInfo> dictionary = new Dictionary<string, FieldInfo>();
			foreach (FieldInfo fieldInfo in type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
			{
				if (!fieldInfo.IsLiteral)
				{
					dictionary.Add(fieldInfo.Name, fieldInfo);
				}
			}
			if (string.IsNullOrEmpty(src))
			{
				return obj;
			}
			int num = StringUtils.SkipPairedBrackets(src, 0);
			int num2 = 1;
			int num3 = src.IndexOf(';', num2);
			while (num3 != -1)
			{
				if (num3 > num2)
				{
					int num4 = src.IndexOf('=', num2);
					int num5 = num4 - num2;
					string key = src.Substring(num2, num5);
					char c = src[num4 + 1];
					string valStr;
					if (c != '{')
					{
						num5 = num3 - num4 - 1;
						StringUtils.IsArrayString(src, num4 + 1, ref num3);
						num5 = num3 - num4 - 1;
						valStr = src.Substring(num4 + 1, num5);
					}
					else
					{
						int num6 = 0;
						num6 += num4 + 1;
						int num7 = StringUtils.SkipPairedBrackets(src, num6);
						num5 = num7 - num6 + 1;
						valStr = src.Substring(num4 + 1, num5);
						num3 = num4 + 1 + num5;
					}
					if (dictionary.ContainsKey(key))
					{
						FieldInfo fieldInfo2 = dictionary[key];
						if (fieldInfo2 != null)
						{
							object value = StringUtils.FromString(fieldInfo2.FieldType, valStr, false);
							fieldInfo2.SetValue(obj, value);
						}
					}
				}
				num2 = num3 + 1;
				num3 = src.IndexOf(';', num2);
				if (num3 > num)
				{
					break;
				}
			}
			return obj;
		}

		// Token: 0x0601A934 RID: 108852 RVA: 0x00837530 File Offset: 0x00835930
		private static object FromStringVector(Type type, string src)
		{
			Type type2 = typeof(List<>).MakeGenericType(new Type[]
			{
				type
			});
			IList list = (IList)Activator.CreateInstance(type2);
			if (string.IsNullOrEmpty(src))
			{
				return list;
			}
			int num = src.IndexOf(':');
			string s = src.Substring(0, num);
			int num2 = int.Parse(s);
			int num3 = num + 1;
			int num4 = num3;
			if (num3 < src.Length && src[num3] == '{')
			{
				num4 = StringUtils.SkipPairedBrackets(src, num3);
			}
			for (num4 = src.IndexOf('|', num4); num4 != -1; num4 = src.IndexOf('|', num4))
			{
				int length = num4 - num3;
				string valStr = src.Substring(num3, length);
				object value = StringUtils.FromString(type, valStr, false);
				list.Add(value);
				num3 = num4 + 1;
				if (num3 < src.Length && src[num3] == '{')
				{
					num4 = StringUtils.SkipPairedBrackets(src, num3);
				}
				else
				{
					num4 = num3;
				}
			}
			if (num3 < src.Length)
			{
				int length2 = src.Length - num3;
				string valStr2 = src.Substring(num3, length2);
				object value2 = StringUtils.FromString(type, valStr2, false);
				list.Add(value2);
			}
			return list;
		}

		// Token: 0x0601A935 RID: 108853 RVA: 0x00837673 File Offset: 0x00835A73
		public static bool IsValidString(string str)
		{
			return !string.IsNullOrEmpty(str) && (str[0] != '"' || str[1] != '"');
		}

		// Token: 0x0601A936 RID: 108854 RVA: 0x008376A0 File Offset: 0x00835AA0
		public static object FromString(Type type, string valStr, bool bStrIsArrayType)
		{
			if (!string.IsNullOrEmpty(valStr) && valStr == "null")
			{
				return null;
			}
			if (type.IsByRef)
			{
				type = type.GetElementType();
			}
			bool flag = Utils.IsArrayType(type);
			object result;
			if (bStrIsArrayType || flag)
			{
				if (flag)
				{
					Type type2 = type.GetGenericArguments()[0];
					result = StringUtils.FromStringVector(type2, valStr);
				}
				else
				{
					result = StringUtils.FromStringVector(type, valStr);
				}
			}
			else if (type == typeof(IProperty))
			{
				result = AgentMeta.ParseProperty(valStr, null);
			}
			else if (Utils.IsCustomClassType(type))
			{
				result = StringUtils.FromStringStruct(type, valStr);
			}
			else
			{
				result = Utils.FromStringPrimitive(type, valStr);
			}
			return result;
		}

		// Token: 0x0601A937 RID: 108855 RVA: 0x0083775C File Offset: 0x00835B5C
		public static string ToString(object value)
		{
			string text = string.Empty;
			if (value != null)
			{
				Type type = value.GetType();
				bool flag = Utils.IsArrayType(type);
				if (flag)
				{
					IList list = value as IList;
					text = string.Format("{0}:", list.Count);
					if (list.Count > 0)
					{
						for (int i = 0; i < list.Count - 1; i++)
						{
							object value2 = list[i];
							string arg = StringUtils.ToString(value2);
							text += string.Format("{0}|", arg);
						}
						object value3 = list[list.Count - 1];
						string arg2 = StringUtils.ToString(value3);
						text += string.Format("{0}", arg2);
					}
				}
				else if (Utils.IsCustomClassType(type))
				{
					bool flag2 = Utils.IsRefNullType(type);
					if (flag2)
					{
						text = string.Format("{0:x08}", value.GetHashCode());
					}
					else
					{
						text = "{";
						foreach (FieldInfo fieldInfo in type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
						{
							if (!fieldInfo.IsLiteral && !fieldInfo.IsInitOnly)
							{
								object value4 = fieldInfo.GetValue(value);
								string arg3 = StringUtils.ToString(value4);
								text += string.Format("{0}={1};", fieldInfo.Name, arg3);
							}
						}
						text += "}";
					}
				}
				else
				{
					text = value.ToString();
				}
			}
			else
			{
				text = "null";
			}
			return text;
		}

		// Token: 0x0601A938 RID: 108856 RVA: 0x008378F4 File Offset: 0x00835CF4
		public static string FindExtension(string path)
		{
			return Path.GetExtension(path);
		}

		// Token: 0x0601A939 RID: 108857 RVA: 0x008378FC File Offset: 0x00835CFC
		public static int FirstToken(string params_, char sep, ref string token)
		{
			int num = params_.IndexOf(sep);
			if (num != -1)
			{
				token = params_.Substring(0, num);
				return num;
			}
			return -1;
		}

		// Token: 0x0601A93A RID: 108858 RVA: 0x00837928 File Offset: 0x00835D28
		public static string RemoveQuot(string str)
		{
			string text = str;
			if (text.StartsWith("&quot;"))
			{
				text = text.Replace("&quot;", "\"");
			}
			return text;
		}

		// Token: 0x0601A93B RID: 108859 RVA: 0x0083795C File Offset: 0x00835D5C
		public static List<string> SplitTokens(ref string str)
		{
			List<string> list = new List<string>();
			str = StringUtils.RemoveQuot(str);
			if (str.StartsWith("\"") && str.EndsWith("\""))
			{
				list.Add(str);
				return list;
			}
			if (str.StartsWith("const string "))
			{
				list.Add("const");
				list.Add("string");
				string text = str.Substring(13);
				text = StringUtils.RemoveQuot(text);
				list.Add(text);
				str = "const string " + text;
				return list;
			}
			int pB = 0;
			int i = 0;
			bool flag = false;
			while (i < str.Length)
			{
				bool flag2 = false;
				char c = str[i];
				if (c == ' ' && !flag)
				{
					flag2 = true;
				}
				else if (c == '[')
				{
					flag = true;
					flag2 = true;
				}
				else if (c == ']')
				{
					flag = false;
					flag2 = true;
				}
				if (flag2)
				{
					string item = StringUtils.ReadToken(str, pB, i);
					list.Add(item);
					pB = i + 1;
				}
				i++;
			}
			string text2 = StringUtils.ReadToken(str, pB, i);
			if (text2.Length > 0)
			{
				list.Add(text2);
			}
			return list;
		}

		// Token: 0x0601A93C RID: 108860 RVA: 0x00837A98 File Offset: 0x00835E98
		private static string ReadToken(string str, int pB, int end)
		{
			string text = string.Empty;
			int i = pB;
			while (i < end)
			{
				text += str[i++];
			}
			return text;
		}

		// Token: 0x0601A93D RID: 108861 RVA: 0x00837AD4 File Offset: 0x00835ED4
		public static bool ParseForStruct(Type type, string str, ref string strT, Dictionary<string, IInstanceMember> props)
		{
			int num = 0;
			for (int i = 0; i < str.Length; i++)
			{
				char c = str[i];
				if (c == ';' || c == '{' || c == '}')
				{
					int j = num;
					while (j <= i)
					{
						strT += str[j++];
					}
					num = i + 1;
				}
				else if (c == ' ')
				{
					string text = string.Empty;
					int num2 = num;
					while (str[num2] != '=')
					{
						text += str[num2++];
					}
					num2++;
					string value = str.Substring(num2);
					string text2 = string.Empty;
					while (str[num2] != ' ')
					{
						text2 += str[num2++];
					}
					if (text2 == "static")
					{
						num2++;
						while (str[num2] != ' ')
						{
							text2 += str[num2++];
						}
					}
					string arg = string.Empty;
					i++;
					while (str[i] != ';')
					{
						arg += str[i++];
					}
					props[text] = AgentMeta.ParseProperty(value, null);
					num = i + 1;
				}
			}
			return true;
		}
	}
}
