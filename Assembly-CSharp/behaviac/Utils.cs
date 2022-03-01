using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using UnityEngine;

namespace behaviac
{
	// Token: 0x02004837 RID: 18487
	public static class Utils
	{
		// Token: 0x0601A908 RID: 108808 RVA: 0x00836002 File Offset: 0x00834402
		public static bool IsNull(object aObj)
		{
			return aObj == null;
		}

		// Token: 0x0601A909 RID: 108809 RVA: 0x00836008 File Offset: 0x00834408
		public static bool IsStaticType(Type type)
		{
			return type != null && type.IsAbstract && type.IsSealed;
		}

		// Token: 0x1700228E RID: 8846
		// (get) Token: 0x0601A90A RID: 108810 RVA: 0x00836024 File Offset: 0x00834424
		private static Dictionary<string, bool> StaticClasses
		{
			get
			{
				if (Utils.ms_staticClasses == null)
				{
					Utils.ms_staticClasses = new Dictionary<string, bool>();
				}
				return Utils.ms_staticClasses;
			}
		}

		// Token: 0x0601A90B RID: 108811 RVA: 0x0083603F File Offset: 0x0083443F
		public static void AddStaticClass(Type type)
		{
			if (Utils.IsStaticType(type))
			{
				Utils.StaticClasses[type.FullName] = true;
			}
		}

		// Token: 0x0601A90C RID: 108812 RVA: 0x0083605D File Offset: 0x0083445D
		public static bool IsStaticClass(string className)
		{
			return Utils.StaticClasses.ContainsKey(className);
		}

		// Token: 0x0601A90D RID: 108813 RVA: 0x0083606C File Offset: 0x0083446C
		public static Agent GetParentAgent(Agent pAgent, string instanceName)
		{
			Agent agent = pAgent;
			if (!string.IsNullOrEmpty(instanceName) && instanceName != "Self")
			{
				agent = Agent.GetInstance(instanceName, (agent == null) ? 0 : agent.GetContextId());
				if (pAgent != null && agent == null && !Utils.IsStaticClass(instanceName))
				{
					agent = pAgent.GetVariable<Agent>(instanceName);
					if (agent == null)
					{
						string text = string.Format("[instance] The instance \"{0}\" can not be found, so please check the Agent.BindInstance(...) method has been called for this instance.\n", instanceName);
						LogManager.Instance.Log(text, new object[0]);
						Debug.LogError(text);
					}
				}
			}
			return agent;
		}

		// Token: 0x0601A90E RID: 108814 RVA: 0x008360F8 File Offset: 0x008344F8
		public static bool IsDefault<T>(T obj)
		{
			return EqualityComparer<T>.Default.Equals(obj, default(T));
		}

		// Token: 0x0601A90F RID: 108815 RVA: 0x00836119 File Offset: 0x00834519
		public static uint MakeVariableId(string idstring)
		{
			return CRC32.CalcCRC(idstring);
		}

		// Token: 0x0601A910 RID: 108816 RVA: 0x00836121 File Offset: 0x00834521
		public static int GetClassTypeNumberId<T>()
		{
			return 0;
		}

		// Token: 0x0601A911 RID: 108817 RVA: 0x00836124 File Offset: 0x00834524
		public static void ConvertFromInteger<T>(int v, ref T ret)
		{
		}

		// Token: 0x0601A912 RID: 108818 RVA: 0x00836126 File Offset: 0x00834526
		public static uint ConvertToInteger<T>(T v)
		{
			return 0U;
		}

		// Token: 0x0601A913 RID: 108819 RVA: 0x0083612C File Offset: 0x0083452C
		public static Type GetType(string typeName)
		{
			Type type = Type.GetType(typeName);
			if (type != null)
			{
				return type;
			}
			for (int i = 0; i < AppDomain.CurrentDomain.GetAssemblies().Length; i++)
			{
				Assembly assembly = AppDomain.CurrentDomain.GetAssemblies()[i];
				type = assembly.GetType(typeName);
				if (type != null)
				{
					return type;
				}
			}
			if (typeName.StartsWith("System.Collections.Generic.List"))
			{
				int num = typeName.IndexOf("[[");
				if (num > -1)
				{
					int num2 = typeName.IndexOf(",");
					if (num2 < 0)
					{
						num2 = typeName.IndexOf("]]");
					}
					if (num2 > num)
					{
						string typeName2 = typeName.Substring(num + 2, num2 - num - 2);
						type = Utils.GetType(typeName2);
						if (type != null)
						{
							return typeof(List<>).MakeGenericType(new Type[]
							{
								type
							});
						}
					}
				}
			}
			return null;
		}

		// Token: 0x0601A914 RID: 108820 RVA: 0x0083620B File Offset: 0x0083460B
		private static object GetDefaultValue(Type t)
		{
			if (t.IsValueType)
			{
				return Activator.CreateInstance(t);
			}
			return null;
		}

		// Token: 0x0601A915 RID: 108821 RVA: 0x00836220 File Offset: 0x00834620
		public static object FromStringPrimitive(Type type, string valueStr)
		{
			if (valueStr != null)
			{
				if (type == typeof(string) && !string.IsNullOrEmpty(valueStr) && valueStr.Length > 1 && valueStr[0] == '"' && valueStr[valueStr.Length - 1] == '"')
				{
					valueStr = valueStr.Substring(1, valueStr.Length - 2);
				}
				try
				{
					TypeConverter converter = TypeDescriptor.GetConverter(type);
					return converter.ConvertFromString(valueStr);
				}
				catch
				{
					if (type == typeof(bool))
					{
						bool flag;
						if (bool.TryParse(valueStr, out flag))
						{
							return flag;
						}
					}
					else if (type == typeof(int))
					{
						int num;
						if (int.TryParse(valueStr, out num))
						{
							return num;
						}
					}
					else if (type == typeof(uint))
					{
						uint num2;
						if (uint.TryParse(valueStr, out num2))
						{
							return num2;
						}
					}
					else if (type == typeof(short))
					{
						short num3;
						if (short.TryParse(valueStr, out num3))
						{
							return num3;
						}
					}
					else if (type == typeof(ushort))
					{
						ushort num4;
						if (ushort.TryParse(valueStr, out num4))
						{
							return num4;
						}
					}
					else if (type == typeof(char))
					{
						char c;
						if (char.TryParse(valueStr, out c))
						{
							return c;
						}
					}
					else if (type == typeof(sbyte))
					{
						sbyte b;
						if (sbyte.TryParse(valueStr, out b))
						{
							return b;
						}
					}
					else if (type == typeof(byte))
					{
						byte b2;
						if (byte.TryParse(valueStr, out b2))
						{
							return b2;
						}
					}
					else if (type == typeof(long))
					{
						long num5;
						if (long.TryParse(valueStr, out num5))
						{
							return num5;
						}
					}
					else if (type == typeof(ulong))
					{
						ulong num6;
						if (ulong.TryParse(valueStr, out num6))
						{
							return num6;
						}
					}
					else if (type == typeof(float))
					{
						float num7;
						if (float.TryParse(valueStr, out num7))
						{
							return num7;
						}
					}
					else if (type == typeof(double))
					{
						double num8;
						if (double.TryParse(valueStr, out num8))
						{
							return num8;
						}
					}
					else
					{
						if (type == typeof(string))
						{
							return valueStr;
						}
						if (type.IsEnum)
						{
							return Enum.Parse(type, valueStr, true);
						}
					}
				}
			}
			return Utils.GetDefaultValue(type);
		}

		// Token: 0x0601A916 RID: 108822 RVA: 0x00836534 File Offset: 0x00834934
		public static Type GetPrimitiveTypeFromName(string typeName)
		{
			if (string.IsNullOrEmpty(typeName))
			{
				return null;
			}
			switch (typeName)
			{
			case "bool":
			case "Boolean":
				return typeof(bool);
			case "int":
			case "Int32":
				return typeof(int);
			case "uint":
			case "UInt32":
				return typeof(uint);
			case "short":
			case "Int16":
				return typeof(short);
			case "ushort":
			case "UInt16":
				return typeof(ushort);
			case "char":
			case "Char":
				return typeof(char);
			case "sbyte":
			case "SByte":
				return typeof(sbyte);
			case "ubyte":
			case "Ubyte":
			case "byte":
			case "Byte":
				return typeof(byte);
			case "long":
			case "llong":
			case "Int64":
				return typeof(long);
			case "ulong":
			case "ullong":
			case "UInt64":
				return typeof(ulong);
			case "float":
			case "Single":
				return typeof(float);
			case "double":
			case "Double":
				return typeof(double);
			case "string":
			case "String":
				return typeof(string);
			}
			return Utils.GetType(typeName);
		}

		// Token: 0x0601A917 RID: 108823 RVA: 0x008367C4 File Offset: 0x00834BC4
		public static Type GetElementTypeFromName(string typeName)
		{
			bool flag = false;
			if (typeName.StartsWith("vector<"))
			{
				flag = true;
			}
			if (flag)
			{
				int num = typeName.IndexOf('<');
				int num2 = typeName.IndexOf('>');
				int length = num2 - num - 1;
				string typeName2 = typeName.Substring(num + 1, length);
				return Utils.GetTypeFromName(typeName2);
			}
			return null;
		}

		// Token: 0x0601A918 RID: 108824 RVA: 0x0083681C File Offset: 0x00834C1C
		public static Type GetTypeFromName(string typeName)
		{
			if (typeName == "void*")
			{
				return typeof(Agent);
			}
			Type type = AgentMeta.GetTypeFromName(typeName);
			if (type == null)
			{
				type = Utils.GetPrimitiveTypeFromName(typeName);
				if (type == null)
				{
					Type elementTypeFromName = Utils.GetElementTypeFromName(typeName);
					if (elementTypeFromName != null)
					{
						return typeof(List<>).MakeGenericType(new Type[]
						{
							elementTypeFromName
						});
					}
					typeName = typeName.Replace("::", ".");
					type = Utils.GetType(typeName);
				}
			}
			return type;
		}

		// Token: 0x0601A919 RID: 108825 RVA: 0x008368A4 File Offset: 0x00834CA4
		public static Type GetTypeFromName(string typeName, ref bool bIsArrayType)
		{
			Type elementTypeFromName = Utils.GetElementTypeFromName(typeName);
			if (elementTypeFromName != null)
			{
				bIsArrayType = true;
				return elementTypeFromName;
			}
			return Utils.GetTypeFromName(typeName);
		}

		// Token: 0x0601A91A RID: 108826 RVA: 0x008368CC File Offset: 0x00834CCC
		public static string GetNativeTypeName(string typeName)
		{
			if (string.IsNullOrEmpty(typeName))
			{
				return string.Empty;
			}
			if (typeName.StartsWith("vector<"))
			{
				return typeName;
			}
			bool flag = false;
			string key;
			if (typeName.EndsWith("&"))
			{
				key = typeName.Substring(0, typeName.Length - 1);
				flag = true;
			}
			else
			{
				key = typeName;
			}
			if (!Utils.ms_type_mapping.ContainsKey(key))
			{
				return typeName;
			}
			if (flag)
			{
				return Utils.ms_type_mapping[key] + "&";
			}
			return Utils.ms_type_mapping[key];
		}

		// Token: 0x0601A91B RID: 108827 RVA: 0x00836960 File Offset: 0x00834D60
		public static string GetNativeTypeName(Type type)
		{
			if (Utils.IsArrayType(type))
			{
				Type type2 = type.GetGenericArguments()[0];
				return string.Format("vector<{0}>", Utils.GetNativeTypeName(type2));
			}
			return Utils.GetNativeTypeName(type.FullName);
		}

		// Token: 0x0601A91C RID: 108828 RVA: 0x0083699D File Offset: 0x00834D9D
		public static bool IsStringType(Type type)
		{
			return type == typeof(string);
		}

		// Token: 0x0601A91D RID: 108829 RVA: 0x008369AC File Offset: 0x00834DAC
		public static bool IsEnumType(Type type)
		{
			return type != null && type.IsEnum;
		}

		// Token: 0x0601A91E RID: 108830 RVA: 0x008369BD File Offset: 0x00834DBD
		public static bool IsArrayType(Type type)
		{
			return type != null && type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);
		}

		// Token: 0x0601A91F RID: 108831 RVA: 0x008369E8 File Offset: 0x00834DE8
		public static bool IsCustomClassType(Type type)
		{
			return type != null && !type.IsByRef && (type.IsClass || type.IsValueType) && type != typeof(void) && !type.IsEnum && !type.IsPrimitive && !Utils.IsStringType(type) && !Utils.IsArrayType(type);
		}

		// Token: 0x0601A920 RID: 108832 RVA: 0x00836A5C File Offset: 0x00834E5C
		public static bool IsCustomStructType(Type type)
		{
			return type != null && !type.IsByRef && type.IsValueType && type != typeof(void) && !type.IsEnum && !type.IsPrimitive && !Utils.IsStringType(type) && !Utils.IsArrayType(type);
		}

		// Token: 0x0601A921 RID: 108833 RVA: 0x00836AC2 File Offset: 0x00834EC2
		public static bool IsAgentType(Type type)
		{
			return type == typeof(Agent) || type.IsSubclassOf(typeof(Agent));
		}

		// Token: 0x0601A922 RID: 108834 RVA: 0x00836AE7 File Offset: 0x00834EE7
		public static bool IsGameObjectType(Type type)
		{
			return type == typeof(GameObject) || type.IsSubclassOf(typeof(GameObject));
		}

		// Token: 0x0601A923 RID: 108835 RVA: 0x00836B0C File Offset: 0x00834F0C
		public static bool IsRefNullType(Type type)
		{
			return type != null && type.IsClass && type != typeof(string);
		}

		// Token: 0x0601A924 RID: 108836 RVA: 0x00836B34 File Offset: 0x00834F34
		public static bool IfEquals(object l, object r)
		{
			if (l == r)
			{
				return true;
			}
			if (l == null || r == null)
			{
				return false;
			}
			Type type = l.GetType();
			if (type != r.GetType())
			{
				return false;
			}
			bool flag = Utils.IsArrayType(type);
			if (flag)
			{
				IList list = (IList)l;
				IList list2 = (IList)r;
				if (list.Count != list2.Count)
				{
					return false;
				}
				for (int i = 0; i < list.Count; i++)
				{
					object l2 = list[i];
					object r2 = list2[i];
					if (!Utils.IfEquals(l2, r2))
					{
						return false;
					}
				}
				return true;
			}
			else
			{
				bool flag2 = Utils.IsCustomClassType(type);
				if (flag2)
				{
					foreach (FieldInfo fieldInfo in type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
					{
						object value = fieldInfo.GetValue(l);
						object value2 = fieldInfo.GetValue(r);
						if (!Utils.IfEquals(value, value2))
						{
							return false;
						}
					}
					return true;
				}
				return object.Equals(l, r);
			}
		}

		// Token: 0x0601A925 RID: 108837 RVA: 0x00836C50 File Offset: 0x00835050
		public static void Clone<T>(ref T o, T c)
		{
			if (c == null)
			{
				o = default(T);
				return;
			}
			Type typeFromHandle = typeof(T);
			if (typeFromHandle.IsPrimitive || typeFromHandle.IsEnum || typeFromHandle.IsValueType)
			{
				o = c;
			}
			else if (typeFromHandle == typeof(string))
			{
				o = c;
			}
			else if (typeFromHandle.IsArray)
			{
				Type type = typeFromHandle.GetElementType();
				if (type == null)
				{
					type = Type.GetType(typeFromHandle.FullName.Replace("[]", string.Empty));
				}
				Array array = c as Array;
				Array array2 = Array.CreateInstance(type, array.Length);
				for (int i = 0; i < array.Length; i++)
				{
					object value = null;
					Utils.Clone<object>(ref value, array.GetValue(i));
					array2.SetValue(value, i);
				}
				if (o == null)
				{
					o = (T)((object)Convert.ChangeType(array2, typeFromHandle));
				}
			}
			else if (Utils.IsArrayType(typeFromHandle))
			{
				if (typeFromHandle.GetElementType() == null)
				{
					Type type2 = Type.GetType(typeFromHandle.FullName.Replace("[]", string.Empty));
				}
				IList list = c as IList;
				o = (T)((object)Activator.CreateInstance(typeFromHandle));
				for (int j = 0; j < list.Count; j++)
				{
					object value2 = null;
					Utils.Clone<object>(ref value2, list[j]);
					((IList)((object)o)).Add(value2);
				}
			}
			else
			{
				bool isClass = typeFromHandle.IsClass;
				if (isClass && Utils.IsRefNullType(typeFromHandle))
				{
					o = c;
				}
				else
				{
					bool isValueType = typeFromHandle.IsValueType;
					if (o == null)
					{
						o = (T)((object)Activator.CreateInstance(typeFromHandle));
					}
					if (isValueType || isClass)
					{
						foreach (FieldInfo fieldInfo in typeFromHandle.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
						{
							if (!fieldInfo.IsLiteral)
							{
								object value3 = fieldInfo.GetValue(c);
								object value4 = null;
								Utils.Clone<object>(ref value4, value3);
								fieldInfo.SetValue(o, value4);
							}
						}
					}
					else
					{
						o = c;
					}
				}
			}
		}

		// Token: 0x04012955 RID: 76117
		private static Dictionary<string, bool> ms_staticClasses;

		// Token: 0x04012956 RID: 76118
		private static Dictionary<string, string> ms_type_mapping = new Dictionary<string, string>
		{
			{
				"Boolean",
				"bool"
			},
			{
				"System.Boolean",
				"bool"
			},
			{
				"Int32",
				"int"
			},
			{
				"System.Int32",
				"int"
			},
			{
				"UInt32",
				"uint"
			},
			{
				"System.UInt32",
				"uint"
			},
			{
				"Int16",
				"short"
			},
			{
				"System.Int16",
				"short"
			},
			{
				"UInt16",
				"ushort"
			},
			{
				"System.UInt16",
				"ushort"
			},
			{
				"Int8",
				"sbyte"
			},
			{
				"System.Int8",
				"sbyte"
			},
			{
				"SByte",
				"sbyte"
			},
			{
				"System.SByte",
				"sbyte"
			},
			{
				"UInt8",
				"ubyte"
			},
			{
				"System.UInt8",
				"ubyte"
			},
			{
				"Byte",
				"ubyte"
			},
			{
				"System.Byte",
				"ubyte"
			},
			{
				"Char",
				"char"
			},
			{
				"System.Char",
				"char"
			},
			{
				"Int64",
				"long"
			},
			{
				"System.Int64",
				"long"
			},
			{
				"UInt64",
				"ulong"
			},
			{
				"System.UInt64",
				"ulong"
			},
			{
				"Single",
				"float"
			},
			{
				"System.Single",
				"float"
			},
			{
				"Double",
				"double"
			},
			{
				"System.Double",
				"double"
			},
			{
				"String",
				"string"
			},
			{
				"System.String",
				"string"
			},
			{
				"Void",
				"void"
			},
			{
				"System.Void",
				"void"
			}
		};
	}
}
