using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security;
using System.Text;
using MiniXml;
using UnityEngine;

namespace behaviac
{
	// Token: 0x020047FB RID: 18427
	public class AgentMeta
	{
		// Token: 0x0601A767 RID: 108391 RVA: 0x00831D8A File Offset: 0x0083018A
		public AgentMeta(uint signature = 0U)
		{
			this._signature = signature;
		}

		// Token: 0x17002272 RID: 8818
		// (get) Token: 0x0601A769 RID: 108393 RVA: 0x00831DCD File Offset: 0x008301CD
		// (set) Token: 0x0601A768 RID: 108392 RVA: 0x00831DC5 File Offset: 0x008301C5
		public static uint TotalSignature
		{
			get
			{
				return AgentMeta._totalSignature;
			}
			set
			{
				AgentMeta._totalSignature = value;
			}
		}

		// Token: 0x17002273 RID: 8819
		// (get) Token: 0x0601A76A RID: 108394 RVA: 0x00831DD4 File Offset: 0x008301D4
		public uint Signature
		{
			get
			{
				return this._signature;
			}
		}

		// Token: 0x17002274 RID: 8820
		// (get) Token: 0x0601A76B RID: 108395 RVA: 0x00831DDC File Offset: 0x008301DC
		public static Dictionary<uint, AgentMeta> _AgentMetas_
		{
			get
			{
				return AgentMeta._agentMetas;
			}
		}

		// Token: 0x17002275 RID: 8821
		// (set) Token: 0x0601A76C RID: 108396 RVA: 0x00831DE3 File Offset: 0x008301E3
		public static BehaviorLoader _BehaviorLoader_
		{
			set
			{
				AgentMeta._behaviorLoader = value;
			}
		}

		// Token: 0x0601A76D RID: 108397 RVA: 0x00831DEC File Offset: 0x008301EC
		public static void Register()
		{
			AgentMeta.RegisterBasicTypes();
			Type type = Type.GetType("behaviac.BehaviorLoaderImplement");
			if (type == null)
			{
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				foreach (Assembly assembly in assemblies)
				{
					type = assembly.GetType("behaviac.BehaviorLoaderImplement");
					if (type != null)
					{
						break;
					}
				}
			}
			if (type != null)
			{
				AgentMeta._behaviorLoader = (BehaviorLoader)Activator.CreateInstance(type);
				AgentMeta._behaviorLoader.Load();
			}
			AgentMeta.LoadAllMetaFiles();
		}

		// Token: 0x0601A76E RID: 108398 RVA: 0x00831E76 File Offset: 0x00830276
		public static void UnRegister()
		{
			AgentMeta.UnRegisterBasicTypes();
			if (AgentMeta._behaviorLoader != null)
			{
				AgentMeta._behaviorLoader.UnLoad();
			}
			AgentMeta._agentMetas.Clear();
			AgentMeta._Creators.Clear();
		}

		// Token: 0x0601A76F RID: 108399 RVA: 0x00831EA6 File Offset: 0x008302A6
		public static Type GetTypeFromName(string typeName)
		{
			if (AgentMeta._typesRegistered.ContainsKey(typeName))
			{
				return AgentMeta._typesRegistered[typeName];
			}
			return null;
		}

		// Token: 0x0601A770 RID: 108400 RVA: 0x00831EC5 File Offset: 0x008302C5
		public static AgentMeta GetMeta(uint classId)
		{
			if (AgentMeta._agentMetas.ContainsKey(classId))
			{
				return AgentMeta._agentMetas[classId];
			}
			return null;
		}

		// Token: 0x0601A771 RID: 108401 RVA: 0x00831EE4 File Offset: 0x008302E4
		public Dictionary<uint, IInstantiatedVariable> InstantiateCustomizedProperties()
		{
			Dictionary<uint, IInstantiatedVariable> dictionary = new Dictionary<uint, IInstantiatedVariable>();
			foreach (uint key in this._customizedProperties.Keys)
			{
				ICustomizedProperty customizedProperty = this._customizedProperties[key];
				dictionary[key] = customizedProperty.Instantiate();
			}
			if (this._customizedStaticVars == null)
			{
				this._customizedStaticVars = new Dictionary<uint, IInstantiatedVariable>();
				foreach (uint key2 in this._customizedStaticProperties.Keys)
				{
					ICustomizedProperty customizedProperty2 = this._customizedStaticProperties[key2];
					this._customizedStaticVars[key2] = customizedProperty2.Instantiate();
				}
			}
			foreach (uint key3 in this._customizedStaticVars.Keys)
			{
				IInstantiatedVariable value = this._customizedStaticVars[key3];
				dictionary[key3] = value;
			}
			return dictionary;
		}

		// Token: 0x0601A772 RID: 108402 RVA: 0x00831FE6 File Offset: 0x008303E6
		public void RegisterMemberProperty(uint propId, IProperty property)
		{
			this._memberProperties[propId] = property;
		}

		// Token: 0x0601A773 RID: 108403 RVA: 0x00831FF5 File Offset: 0x008303F5
		public void RegisterCustomizedProperty(uint propId, ICustomizedProperty property)
		{
			this._customizedProperties[propId] = property;
		}

		// Token: 0x0601A774 RID: 108404 RVA: 0x00832004 File Offset: 0x00830404
		public void RegisterStaticCustomizedProperty(uint propId, ICustomizedProperty property)
		{
			this._customizedStaticProperties[propId] = property;
		}

		// Token: 0x0601A775 RID: 108405 RVA: 0x00832013 File Offset: 0x00830413
		public void RegisterMethod(uint methodId, IMethod method)
		{
			this._methods[methodId] = method;
		}

		// Token: 0x0601A776 RID: 108406 RVA: 0x00832024 File Offset: 0x00830424
		public IProperty GetProperty(uint propId)
		{
			if (this._customizedStaticProperties.ContainsKey(propId))
			{
				return this._customizedStaticProperties[propId];
			}
			if (this._customizedProperties.ContainsKey(propId))
			{
				return this._customizedProperties[propId];
			}
			if (this._memberProperties.ContainsKey(propId))
			{
				return this._memberProperties[propId];
			}
			return null;
		}

		// Token: 0x0601A777 RID: 108407 RVA: 0x0083208C File Offset: 0x0083048C
		public IProperty GetMemberProperty(uint propId)
		{
			if (this._memberProperties.ContainsKey(propId))
			{
				return this._memberProperties[propId];
			}
			return null;
		}

		// Token: 0x0601A778 RID: 108408 RVA: 0x008320AD File Offset: 0x008304AD
		public Dictionary<uint, IProperty> GetMemberProperties()
		{
			return this._memberProperties;
		}

		// Token: 0x0601A779 RID: 108409 RVA: 0x008320B5 File Offset: 0x008304B5
		public IMethod GetMethod(uint methodId)
		{
			if (this._methods.ContainsKey(methodId))
			{
				return this._methods[methodId];
			}
			return null;
		}

		// Token: 0x0601A77A RID: 108410 RVA: 0x008320D6 File Offset: 0x008304D6
		public static string GetTypeName(string typeName)
		{
			typeName = typeName.Replace("*", string.Empty);
			return typeName;
		}

		// Token: 0x0601A77B RID: 108411 RVA: 0x008320EC File Offset: 0x008304EC
		public static ICustomizedProperty CreateProperty(string typeName, uint propId, string propName, string valueStr)
		{
			typeName = AgentMeta.GetTypeName(typeName);
			if (AgentMeta._Creators.ContainsKey(typeName))
			{
				AgentMeta.TypeCreator typeCreator = AgentMeta._Creators[typeName];
				return typeCreator.CreateProperty(propId, propName, valueStr);
			}
			return null;
		}

		// Token: 0x0601A77C RID: 108412 RVA: 0x00832128 File Offset: 0x00830528
		public static ICustomizedProperty CreateArrayItemProperty(string typeName, uint parentId, string parentName)
		{
			typeName = AgentMeta.GetTypeName(typeName);
			if (AgentMeta._Creators.ContainsKey(typeName))
			{
				AgentMeta.TypeCreator typeCreator = AgentMeta._Creators[typeName];
				return typeCreator.CreateArrayItemProperty(parentId, parentName);
			}
			return null;
		}

		// Token: 0x0601A77D RID: 108413 RVA: 0x00832164 File Offset: 0x00830564
		public static IInstanceMember CreateInstanceProperty(string typeName, string instance, IInstanceMember indexMember, uint varId)
		{
			typeName = AgentMeta.GetTypeName(typeName);
			if (AgentMeta._Creators.ContainsKey(typeName))
			{
				AgentMeta.TypeCreator typeCreator = AgentMeta._Creators[typeName];
				return typeCreator.CreateInstanceProperty(instance, indexMember, varId);
			}
			return null;
		}

		// Token: 0x0601A77E RID: 108414 RVA: 0x008321A0 File Offset: 0x008305A0
		public static IInstanceMember CreateInstanceConst(string typeName, string valueStr)
		{
			typeName = AgentMeta.GetTypeName(typeName);
			if (AgentMeta._Creators.ContainsKey(typeName))
			{
				AgentMeta.TypeCreator typeCreator = AgentMeta._Creators[typeName];
				return typeCreator.CreateInstanceConst(typeName, valueStr);
			}
			return null;
		}

		// Token: 0x0601A77F RID: 108415 RVA: 0x008321DC File Offset: 0x008305DC
		public static ICustomizedProperty CreateCustomizedProperty(string typeName, uint id, string name, string valueStr)
		{
			typeName = AgentMeta.GetTypeName(typeName);
			if (AgentMeta._Creators.ContainsKey(typeName))
			{
				AgentMeta.TypeCreator typeCreator = AgentMeta._Creators[typeName];
				return typeCreator.CreateCustomizedProperty(id, name, valueStr);
			}
			return null;
		}

		// Token: 0x0601A780 RID: 108416 RVA: 0x00832218 File Offset: 0x00830618
		public static ICustomizedProperty CreateCustomizedArrayItemProperty(string typeName, uint id, string name)
		{
			typeName = AgentMeta.GetTypeName(typeName);
			if (AgentMeta._Creators.ContainsKey(typeName))
			{
				AgentMeta.TypeCreator typeCreator = AgentMeta._Creators[typeName];
				return typeCreator.CreateCustomizedArrayItemProperty(id, name);
			}
			return null;
		}

		// Token: 0x0601A781 RID: 108417 RVA: 0x00832254 File Offset: 0x00830654
		public static object ParseTypeValue(string typeName, string valueStr)
		{
			bool flag = false;
			Type typeFromName = Utils.GetTypeFromName(typeName, ref flag);
			if (flag || !Utils.IsRefNullType(typeFromName))
			{
				if (!string.IsNullOrEmpty(valueStr))
				{
					return StringUtils.FromString(typeFromName, valueStr, flag);
				}
				if (typeFromName == typeof(string))
				{
					return string.Empty;
				}
			}
			return null;
		}

		// Token: 0x0601A782 RID: 108418 RVA: 0x008322A8 File Offset: 0x008306A8
		public static string ParseInstanceNameProperty(string fullName, ref string instanceName, ref string agentType)
		{
			int num = fullName.IndexOf('.');
			if (num != -1)
			{
				instanceName = fullName.Substring(0, num).Replace("::", ".");
				string text = fullName.Substring(num + 1);
				int num2 = text.LastIndexOf(':');
				agentType = text.Substring(0, num2 - 1).Replace("::", ".");
				return text.Substring(num2 + 1);
			}
			return fullName;
		}

		// Token: 0x0601A783 RID: 108419 RVA: 0x00832319 File Offset: 0x00830719
		public static ICustomizedProperty CreatorProperty<T>(uint propId, string propName, string valueStr)
		{
			return new CCustomizedProperty<T>(propId, propName, valueStr);
		}

		// Token: 0x0601A784 RID: 108420 RVA: 0x00832323 File Offset: 0x00830723
		public static ICustomizedProperty CreatorArrayItemProperty<T>(uint parentId, string parentName)
		{
			return new CCustomizedArrayItemProperty<T>(parentId, parentName);
		}

		// Token: 0x0601A785 RID: 108421 RVA: 0x0083232C File Offset: 0x0083072C
		public static IInstanceMember CreatorInstanceProperty<T>(string instance, IInstanceMember indexMember, uint varId)
		{
			return new CInstanceCustomizedProperty<T>(instance, indexMember, varId);
		}

		// Token: 0x0601A786 RID: 108422 RVA: 0x00832336 File Offset: 0x00830736
		public static IInstanceMember CreatorInstanceConst<T>(string typeName, string valueStr)
		{
			return new CInstanceConst<T>(typeName, valueStr);
		}

		// Token: 0x0601A787 RID: 108423 RVA: 0x0083233F File Offset: 0x0083073F
		public static ICustomizedProperty CreateCustomizedProperty<T>(uint id, string name, string valueStr)
		{
			return new CCustomizedProperty<T>(id, name, valueStr);
		}

		// Token: 0x0601A788 RID: 108424 RVA: 0x00832349 File Offset: 0x00830749
		public static ICustomizedProperty CreateCustomizedArrayItemProperty<T>(uint id, string name)
		{
			return new CCustomizedArrayItemProperty<T>(id, name);
		}

		// Token: 0x0601A789 RID: 108425 RVA: 0x00832354 File Offset: 0x00830754
		public static bool Register<T>(string typeName)
		{
			typeName = typeName.Replace("::", ".");
			AgentMeta.TypeCreator value = new AgentMeta.TypeCreator(new AgentMeta.TypeCreator.PropertyCreator(AgentMeta.CreatorProperty<T>), new AgentMeta.TypeCreator.ArrayItemPropertyCreator(AgentMeta.CreatorArrayItemProperty<T>), new AgentMeta.TypeCreator.InstancePropertyCreator(AgentMeta.CreatorInstanceProperty<T>), new AgentMeta.TypeCreator.InstanceConstCreator(AgentMeta.CreatorInstanceConst<T>), new AgentMeta.TypeCreator.CustomizedPropertyCreator(AgentMeta.CreateCustomizedProperty<T>), new AgentMeta.TypeCreator.CustomizedArrayItemPropertyCreator(AgentMeta.CreateCustomizedArrayItemProperty<T>));
			AgentMeta._Creators[typeName] = value;
			string key = string.Format("vector<{0}>", typeName);
			AgentMeta.TypeCreator value2 = new AgentMeta.TypeCreator(new AgentMeta.TypeCreator.PropertyCreator(AgentMeta.CreatorProperty<List<T>>), new AgentMeta.TypeCreator.ArrayItemPropertyCreator(AgentMeta.CreatorArrayItemProperty<List<T>>), new AgentMeta.TypeCreator.InstancePropertyCreator(AgentMeta.CreatorInstanceProperty<List<T>>), new AgentMeta.TypeCreator.InstanceConstCreator(AgentMeta.CreatorInstanceConst<List<T>>), new AgentMeta.TypeCreator.CustomizedPropertyCreator(AgentMeta.CreateCustomizedProperty<List<T>>), new AgentMeta.TypeCreator.CustomizedArrayItemPropertyCreator(AgentMeta.CreateCustomizedArrayItemProperty<List<T>>));
			AgentMeta._Creators[key] = value2;
			AgentMeta._typesRegistered[typeName] = typeof(T);
			AgentMeta._typesRegistered[key] = typeof(List<T>);
			return true;
		}

		// Token: 0x0601A78A RID: 108426 RVA: 0x00832460 File Offset: 0x00830860
		public static void UnRegister<T>(string typeName)
		{
			typeName = typeName.Replace("::", ".");
			string key = string.Format("vector<{0}>", typeName);
			AgentMeta._typesRegistered.Remove(typeName);
			AgentMeta._typesRegistered.Remove(key);
			AgentMeta._Creators.Remove(typeName);
			AgentMeta._Creators.Remove(key);
		}

		// Token: 0x0601A78B RID: 108427 RVA: 0x008324BC File Offset: 0x008308BC
		private static void RegisterBasicTypes()
		{
			AgentMeta.Register<bool>("bool");
			AgentMeta.Register<bool>("Boolean");
			AgentMeta.Register<byte>("byte");
			AgentMeta.Register<byte>("ubyte");
			AgentMeta.Register<byte>("Byte");
			AgentMeta.Register<char>("char");
			AgentMeta.Register<char>("Char");
			AgentMeta.Register<decimal>("decimal");
			AgentMeta.Register<decimal>("Decimal");
			AgentMeta.Register<double>("double");
			AgentMeta.Register<double>("Double");
			AgentMeta.Register<float>("float");
			AgentMeta.Register<int>("int");
			AgentMeta.Register<short>("Int16");
			AgentMeta.Register<int>("Int32");
			AgentMeta.Register<long>("Int64");
			AgentMeta.Register<long>("long");
			AgentMeta.Register<long>("llong");
			AgentMeta.Register<sbyte>("sbyte");
			AgentMeta.Register<sbyte>("SByte");
			AgentMeta.Register<short>("short");
			AgentMeta.Register<ushort>("ushort");
			AgentMeta.Register<uint>("uint");
			AgentMeta.Register<ushort>("UInt16");
			AgentMeta.Register<uint>("UInt32");
			AgentMeta.Register<ulong>("UInt64");
			AgentMeta.Register<ulong>("ulong");
			AgentMeta.Register<ulong>("ullong");
			AgentMeta.Register<float>("Single");
			AgentMeta.Register<string>("string");
			AgentMeta.Register<string>("String");
			AgentMeta.Register<object>("object");
			AgentMeta.Register<GameObject>("UnityEngine.GameObject");
			AgentMeta.Register<Vector2>("UnityEngine.Vector2");
			AgentMeta.Register<Vector3>("UnityEngine.Vector3");
			AgentMeta.Register<Vector4>("UnityEngine.Vector4");
			AgentMeta.Register<Agent>("behaviac.Agent");
			AgentMeta.Register<EBTStatus>("behaviac.EBTStatus");
		}

		// Token: 0x0601A78C RID: 108428 RVA: 0x0083266C File Offset: 0x00830A6C
		private static void UnRegisterBasicTypes()
		{
			AgentMeta.UnRegister<bool>("bool");
			AgentMeta.UnRegister<bool>("Boolean");
			AgentMeta.UnRegister<byte>("byte");
			AgentMeta.UnRegister<byte>("ubyte");
			AgentMeta.UnRegister<byte>("Byte");
			AgentMeta.UnRegister<char>("char");
			AgentMeta.UnRegister<char>("Char");
			AgentMeta.UnRegister<decimal>("decimal");
			AgentMeta.UnRegister<decimal>("Decimal");
			AgentMeta.UnRegister<double>("double");
			AgentMeta.UnRegister<double>("Double");
			AgentMeta.UnRegister<float>("float");
			AgentMeta.UnRegister<float>("Single");
			AgentMeta.UnRegister<int>("int");
			AgentMeta.UnRegister<short>("Int16");
			AgentMeta.UnRegister<int>("Int32");
			AgentMeta.UnRegister<long>("Int64");
			AgentMeta.UnRegister<long>("long");
			AgentMeta.UnRegister<long>("llong");
			AgentMeta.UnRegister<sbyte>("sbyte");
			AgentMeta.UnRegister<sbyte>("SByte");
			AgentMeta.UnRegister<short>("short");
			AgentMeta.UnRegister<ushort>("ushort");
			AgentMeta.UnRegister<uint>("uint");
			AgentMeta.UnRegister<ushort>("UInt16");
			AgentMeta.UnRegister<uint>("UInt32");
			AgentMeta.UnRegister<ulong>("UInt64");
			AgentMeta.UnRegister<ulong>("ulong");
			AgentMeta.UnRegister<ulong>("ullong");
			AgentMeta.UnRegister<string>("string");
			AgentMeta.UnRegister<string>("String");
			AgentMeta.UnRegister<object>("object");
			AgentMeta.UnRegister<GameObject>("UnityEngine.GameObject");
			AgentMeta.UnRegister<Vector2>("UnityEngine.Vector2");
			AgentMeta.UnRegister<Vector3>("UnityEngine.Vector3");
			AgentMeta.UnRegister<Vector4>("UnityEngine.Vector4");
			AgentMeta.UnRegister<Agent>("behaviac.Agent");
			AgentMeta.UnRegister<EBTStatus>("behaviac.EBTStatus");
		}

		// Token: 0x0601A78D RID: 108429 RVA: 0x008327F8 File Offset: 0x00830BF8
		public static IInstanceMember ParseProperty<T>(string value)
		{
			try
			{
				if (string.IsNullOrEmpty(value))
				{
					return null;
				}
				List<string> list = StringUtils.SplitTokens(ref value);
				if (list.Count == 1)
				{
					string nativeTypeName = Utils.GetNativeTypeName(typeof(T));
					return AgentMeta.CreateInstanceConst(nativeTypeName, list[0]);
				}
				return AgentMeta.ParseProperty(value, null);
			}
			catch (Exception ex)
			{
			}
			return null;
		}

		// Token: 0x0601A78E RID: 108430 RVA: 0x00832874 File Offset: 0x00830C74
		public static IInstanceMember ParseProperty(string value, List<string> tokens = null)
		{
			try
			{
				if (string.IsNullOrEmpty(value))
				{
					return null;
				}
				if (tokens == null)
				{
					tokens = StringUtils.SplitTokens(ref value);
				}
				string text = string.Empty;
				if (tokens[0] == "const")
				{
					string text2 = value.Substring(6);
					int num = StringUtils.FirstToken(text2, ' ', ref text);
					text = text.Replace("::", ".");
					string valueStr = text2.Substring(num + 1);
					return AgentMeta.CreateInstanceConst(text, valueStr);
				}
				string text3 = string.Empty;
				string value2 = string.Empty;
				if (tokens[0] == "static")
				{
					text = tokens[1];
					text3 = tokens[2];
					if (tokens.Count == 4)
					{
						value2 = tokens[3];
					}
				}
				else
				{
					text = tokens[0];
					text3 = tokens[1];
					if (tokens.Count == 3)
					{
						value2 = tokens[2];
					}
				}
				string str = string.Empty;
				IInstanceMember indexMember = null;
				if (!string.IsNullOrEmpty(value2))
				{
					str = "[]";
					indexMember = AgentMeta.ParseProperty<int>(value2);
				}
				text = text.Replace("::", ".");
				text3 = text3.Replace("::", ".");
				string[] array = text3.Split(new char[]
				{
					'.'
				});
				string instance = array[0];
				string str2 = array[array.Length - 1];
				string text4 = array[1];
				for (int i = 2; i < array.Length - 1; i++)
				{
					text4 = text4 + "." + array[i];
				}
				uint classId = Utils.MakeVariableId(text4);
				AgentMeta meta = AgentMeta.GetMeta(classId);
				uint num2 = Utils.MakeVariableId(str2 + str);
				if (meta != null)
				{
					IProperty property = meta.GetProperty(num2);
					if (property != null)
					{
						return property.CreateInstance(instance, indexMember);
					}
				}
				return AgentMeta.CreateInstanceProperty(text, instance, indexMember, num2);
			}
			catch (Exception ex)
			{
			}
			return null;
		}

		// Token: 0x0601A78F RID: 108431 RVA: 0x00832A98 File Offset: 0x00830E98
		public static IMethod ParseMethod(string valueStr, ref string methodName)
		{
			if (string.IsNullOrEmpty(valueStr) || (valueStr[0] == '"' && valueStr[1] == '"'))
			{
				return null;
			}
			string instance = null;
			string idstring = null;
			int startIndex = AgentMeta.ParseMethodNames(valueStr, ref instance, ref idstring, ref methodName);
			uint classId = Utils.MakeVariableId(idstring);
			uint methodId = Utils.MakeVariableId(methodName);
			AgentMeta meta = AgentMeta.GetMeta(classId);
			if (meta != null)
			{
				IMethod method = meta.GetMethod(methodId);
				if (method != null)
				{
					method = method.Clone();
					string text = valueStr.Substring(startIndex);
					List<string> list = new List<string>();
					int length = text.Length;
					string tsrc = text.Substring(1, length - 2);
					list = AgentMeta.ParseForParams(tsrc);
					method.Load(instance, list.ToArray());
				}
				return method;
			}
			return null;
		}

		// Token: 0x0601A790 RID: 108432 RVA: 0x00832B60 File Offset: 0x00830F60
		public static IMethod ParseMethod(string valueStr)
		{
			string empty = string.Empty;
			return AgentMeta.ParseMethod(valueStr, ref empty);
		}

		// Token: 0x0601A791 RID: 108433 RVA: 0x00832B7C File Offset: 0x00830F7C
		private static int ParseMethodNames(string fullName, ref string agentIntanceName, ref string agentClassName, ref string methodName)
		{
			int num = fullName.IndexOf('.');
			agentIntanceName = fullName.Substring(0, num);
			int num2 = num + 1;
			int num3 = fullName.IndexOf('(', num2);
			int num4 = fullName.LastIndexOf(':', num3);
			num4++;
			int length = num3 - num4;
			methodName = fullName.Substring(num4, length);
			int length2 = num4 - 2 - num2;
			agentClassName = fullName.Substring(num2, length2).Replace("::", ".");
			return num3;
		}

		// Token: 0x0601A792 RID: 108434 RVA: 0x00832BEC File Offset: 0x00830FEC
		private static List<string> ParseForParams(string tsrc)
		{
			tsrc = StringUtils.RemoveQuot(tsrc);
			int length = tsrc.Length;
			int num = 0;
			int i = 0;
			int num2 = 0;
			List<string> list = new List<string>();
			while (i < length)
			{
				if (tsrc[i] == '"')
				{
					num2++;
					if ((num2 & 1) == 0)
					{
						num2 -= 2;
					}
				}
				else if (num2 == 0 && tsrc[i] == ',')
				{
					int length2 = i - num;
					string item = tsrc.Substring(num, length2);
					list.Add(item);
					num = i + 1;
				}
				i++;
			}
			int num3 = i - num;
			if (num3 > 0)
			{
				string item2 = tsrc.Substring(num, num3);
				list.Add(item2);
			}
			return list;
		}

		// Token: 0x0601A793 RID: 108435 RVA: 0x00832C9C File Offset: 0x0083109C
		private static void LoadAllMetaFiles()
		{
			string text = string.Empty;
			List<byte[]> list = null;
			try
			{
				string ext = (Workspace.Instance.FileFormat != Workspace.EFileFormat.EFF_bson) ? ".xml" : ".bson";
				text = Path.Combine(Workspace.Instance.FilePath, "meta");
				text = text.Replace('\\', '/');
				if (!string.IsNullOrEmpty(Workspace.Instance.MetaFile))
				{
					string text2 = Path.Combine(text, Workspace.Instance.MetaFile);
					text2 = Path.ChangeExtension(text2, ".meta");
					byte[] pBuffer = FileManager.Instance.FileOpen(text2, ext);
					if (Workspace.Instance.FileFormat == Workspace.EFileFormat.EFF_bson)
					{
						AgentMeta.load_bson(pBuffer);
					}
					else
					{
						AgentMeta.load_xml(pBuffer);
					}
				}
				else
				{
					list = FileManager.Instance.DirOpen(text, ext);
					foreach (byte[] pBuffer2 in list)
					{
						if (Workspace.Instance.FileFormat == Workspace.EFileFormat.EFF_bson)
						{
							AgentMeta.load_bson(pBuffer2);
						}
						else
						{
							AgentMeta.load_xml(pBuffer2);
						}
					}
				}
			}
			catch (Exception ex)
			{
				int num = (list == null) ? 0 : list.Count;
				string text3 = string.Format("Load Meta Error: there are {0} meta fiels in {1}", num, text);
			}
		}

		// Token: 0x0601A794 RID: 108436 RVA: 0x00832E2C File Offset: 0x0083122C
		private static void registerCustomizedProperty(AgentMeta meta, string propName, string typeName, string valueStr, bool isStatic)
		{
			typeName = typeName.Replace("::", ".");
			uint num = Utils.MakeVariableId(propName);
			IProperty property = meta.GetProperty(num);
			ICustomizedProperty customizedProperty = AgentMeta.CreateCustomizedProperty(typeName, num, propName, valueStr);
			if (property != null && customizedProperty != null)
			{
				object valueObject = customizedProperty.GetValueObject(null);
				object valueObject2 = property.GetValueObject(null);
				if (valueObject != null && valueObject2 != null && valueObject.GetType() == valueObject2.GetType())
				{
					return;
				}
				string text = string.Format("The type of '{0}' has been modified to {1}, which would bring the unpredictable consequences.", propName, typeName);
			}
			if (isStatic)
			{
				meta.RegisterStaticCustomizedProperty(num, customizedProperty);
			}
			else
			{
				meta.RegisterCustomizedProperty(num, customizedProperty);
			}
			Type typeFromName = AgentMeta.GetTypeFromName(typeName);
			if (Utils.IsArrayType(typeFromName))
			{
				int length = "vector<".Length;
				typeName = typeName.Substring(length, typeName.Length - length - 1);
				ICustomizedProperty property2 = AgentMeta.CreateCustomizedArrayItemProperty(typeName, num, propName);
				num = Utils.MakeVariableId(propName + "[]");
				if (isStatic)
				{
					meta.RegisterStaticCustomizedProperty(num, property2);
				}
				else
				{
					meta.RegisterCustomizedProperty(num, property2);
				}
			}
		}

		// Token: 0x0601A795 RID: 108437 RVA: 0x00832F3C File Offset: 0x0083133C
		private static bool checkSignature(string signatureStr)
		{
			return !(signatureStr != AgentMeta.TotalSignature.ToString());
		}

		// Token: 0x0601A796 RID: 108438 RVA: 0x00832F70 File Offset: 0x00831370
		private static bool load_xml(byte[] pBuffer)
		{
			try
			{
				string @string = Encoding.UTF8.GetString(pBuffer);
				SecurityParser securityParser = new SecurityParser();
				securityParser.LoadXml(@string);
				SecurityElement securityElement = securityParser.ToXml();
				if (securityElement.Children == null || (securityElement.Tag != "agents" && securityElement.Children.Count != 1))
				{
					return false;
				}
				string text = securityElement.Attribute("version");
				string signatureStr = securityElement.Attribute("signature");
				AgentMeta.checkSignature(signatureStr);
				IEnumerator enumerator = securityElement.Children.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						SecurityElement securityElement2 = (SecurityElement)obj;
						if (securityElement2.Tag == "agent" && securityElement2.Children != null)
						{
							string idstring = securityElement2.Attribute("type").Replace("::", ".");
							uint num = Utils.MakeVariableId(idstring);
							AgentMeta agentMeta = AgentMeta.GetMeta(num);
							if (agentMeta == null)
							{
								agentMeta = new AgentMeta(0U);
								AgentMeta._agentMetas[num] = agentMeta;
							}
							string a = securityElement2.Attribute("signature");
							if (!(a == agentMeta.Signature.ToString()))
							{
								IEnumerator enumerator2 = securityElement2.Children.GetEnumerator();
								try
								{
									while (enumerator2.MoveNext())
									{
										object obj2 = enumerator2.Current;
										SecurityElement securityElement3 = (SecurityElement)obj2;
										if (securityElement3.Tag == "properties" && securityElement3.Children != null)
										{
											IEnumerator enumerator3 = securityElement3.Children.GetEnumerator();
											try
											{
												while (enumerator3.MoveNext())
												{
													object obj3 = enumerator3.Current;
													SecurityElement securityElement4 = (SecurityElement)obj3;
													if (securityElement4.Tag == "property")
													{
														string text2 = securityElement4.Attribute("member");
														if (string.IsNullOrEmpty(text2) || !(text2 == "true"))
														{
															string propName = securityElement4.Attribute("name");
															string typeName = securityElement4.Attribute("type").Replace("::", ".");
															string valueStr = securityElement4.Attribute("defaultvalue");
															string text3 = securityElement4.Attribute("static");
															bool isStatic = !string.IsNullOrEmpty(text3) && text3 == "true";
															AgentMeta.registerCustomizedProperty(agentMeta, propName, typeName, valueStr, isStatic);
														}
													}
												}
											}
											finally
											{
												IDisposable disposable;
												if ((disposable = (enumerator3 as IDisposable)) != null)
												{
													disposable.Dispose();
												}
											}
										}
									}
								}
								finally
								{
									IDisposable disposable2;
									if ((disposable2 = (enumerator2 as IDisposable)) != null)
									{
										disposable2.Dispose();
									}
								}
							}
						}
					}
				}
				finally
				{
					IDisposable disposable3;
					if ((disposable3 = (enumerator as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
				return true;
			}
			catch (Exception ex)
			{
			}
			return false;
		}

		// Token: 0x0601A797 RID: 108439 RVA: 0x008332C8 File Offset: 0x008316C8
		private static bool load_bson(byte[] pBuffer)
		{
			try
			{
				BsonDeserizer bsonDeserizer = new BsonDeserizer();
				if (bsonDeserizer.Init(pBuffer))
				{
					BsonDeserizer.BsonTypes bsonTypes = bsonDeserizer.ReadType();
					if (bsonTypes == BsonDeserizer.BsonTypes.BT_AgentsElement)
					{
						bool flag = bsonDeserizer.OpenDocument();
						string s = bsonDeserizer.ReadString();
						int version = int.Parse(s);
						string signatureStr = bsonDeserizer.ReadString();
						AgentMeta.checkSignature(signatureStr);
						for (bsonTypes = bsonDeserizer.ReadType(); bsonTypes != BsonDeserizer.BsonTypes.BT_None; bsonTypes = bsonDeserizer.ReadType())
						{
							if (bsonTypes == BsonDeserizer.BsonTypes.BT_AgentElement)
							{
								AgentMeta.load_agent(version, bsonDeserizer);
							}
						}
						bsonDeserizer.CloseDocument(false);
						return true;
					}
				}
			}
			catch (Exception ex)
			{
			}
			return false;
		}

		// Token: 0x0601A798 RID: 108440 RVA: 0x00833378 File Offset: 0x00831778
		private static bool load_agent(int version, BsonDeserizer d)
		{
			try
			{
				d.OpenDocument();
				string text = d.ReadString().Replace("::", ".");
				string text2 = d.ReadString();
				uint num = Utils.MakeVariableId(text);
				AgentMeta agentMeta = AgentMeta.GetMeta(num);
				if (agentMeta == null)
				{
					agentMeta = new AgentMeta(0U);
					AgentMeta._agentMetas[num] = agentMeta;
				}
				bool flag = false;
				string a = d.ReadString();
				if (a != agentMeta.Signature.ToString())
				{
					flag = true;
				}
				for (BsonDeserizer.BsonTypes bsonTypes = d.ReadType(); bsonTypes != BsonDeserizer.BsonTypes.BT_None; bsonTypes = d.ReadType())
				{
					if (bsonTypes == BsonDeserizer.BsonTypes.BT_PropertiesElement)
					{
						d.OpenDocument();
						for (bsonTypes = d.ReadType(); bsonTypes != BsonDeserizer.BsonTypes.BT_None; bsonTypes = d.ReadType())
						{
							if (bsonTypes == BsonDeserizer.BsonTypes.BT_PropertyElement)
							{
								d.OpenDocument();
								string propName = d.ReadString();
								string typeName = d.ReadString();
								string text3 = d.ReadString();
								bool flag2 = !string.IsNullOrEmpty(text3) && text3 == "true";
								string text4 = d.ReadString();
								bool isStatic = !string.IsNullOrEmpty(text4) && text4 == "true";
								if (!flag2)
								{
									string valueStr = d.ReadString();
									if (flag)
									{
										AgentMeta.registerCustomizedProperty(agentMeta, propName, typeName, valueStr, isStatic);
									}
								}
								else
								{
									d.ReadString();
								}
								d.CloseDocument(true);
							}
						}
						d.CloseDocument(false);
					}
					else if (bsonTypes == BsonDeserizer.BsonTypes.BT_MethodsElement)
					{
						AgentMeta.load_methods(d, text, bsonTypes);
					}
				}
				d.CloseDocument(false);
				return true;
			}
			catch (Exception ex)
			{
			}
			return false;
		}

		// Token: 0x0601A799 RID: 108441 RVA: 0x00833548 File Offset: 0x00831948
		private static void load_methods(BsonDeserizer d, string agentType, BsonDeserizer.BsonTypes type)
		{
			d.OpenDocument();
			for (type = d.ReadType(); type == BsonDeserizer.BsonTypes.BT_MethodElement; type = d.ReadType())
			{
				d.OpenDocument();
				d.ReadString();
				string text = d.ReadString();
				for (type = d.ReadType(); type == BsonDeserizer.BsonTypes.BT_ParameterElement; type = d.ReadType())
				{
					d.OpenDocument();
					string text2 = d.ReadString();
					d.ReadString();
					d.CloseDocument(true);
				}
				d.CloseDocument(false);
			}
			d.CloseDocument(false);
		}

		// Token: 0x04012904 RID: 76036
		private Dictionary<uint, IProperty> _memberProperties = new Dictionary<uint, IProperty>();

		// Token: 0x04012905 RID: 76037
		private Dictionary<uint, ICustomizedProperty> _customizedProperties = new Dictionary<uint, ICustomizedProperty>();

		// Token: 0x04012906 RID: 76038
		private Dictionary<uint, ICustomizedProperty> _customizedStaticProperties = new Dictionary<uint, ICustomizedProperty>();

		// Token: 0x04012907 RID: 76039
		private Dictionary<uint, IInstantiatedVariable> _customizedStaticVars;

		// Token: 0x04012908 RID: 76040
		private Dictionary<uint, IMethod> _methods = new Dictionary<uint, IMethod>();

		// Token: 0x04012909 RID: 76041
		private static Dictionary<uint, AgentMeta> _agentMetas = new Dictionary<uint, AgentMeta>();

		// Token: 0x0401290A RID: 76042
		private static Dictionary<string, AgentMeta.TypeCreator> _Creators = new Dictionary<string, AgentMeta.TypeCreator>();

		// Token: 0x0401290B RID: 76043
		private static Dictionary<string, Type> _typesRegistered = new Dictionary<string, Type>();

		// Token: 0x0401290C RID: 76044
		private static uint _totalSignature = 0U;

		// Token: 0x0401290D RID: 76045
		private uint _signature;

		// Token: 0x0401290E RID: 76046
		private static BehaviorLoader _behaviorLoader;

		// Token: 0x020047FC RID: 18428
		private class TypeCreator
		{
			// Token: 0x0601A79B RID: 108443 RVA: 0x008335FB File Offset: 0x008319FB
			public TypeCreator(AgentMeta.TypeCreator.PropertyCreator propCreator, AgentMeta.TypeCreator.ArrayItemPropertyCreator arrayItemPropCreator, AgentMeta.TypeCreator.InstancePropertyCreator instancePropertyCreator, AgentMeta.TypeCreator.InstanceConstCreator instanceConstCreator, AgentMeta.TypeCreator.CustomizedPropertyCreator customizedPropertyCreator, AgentMeta.TypeCreator.CustomizedArrayItemPropertyCreator customizedArrayItemPropertyCreator)
			{
				this._propertyCreator = propCreator;
				this._arrayItemPropertyCreator = arrayItemPropCreator;
				this._instancePropertyCreator = instancePropertyCreator;
				this._instanceConstCreator = instanceConstCreator;
				this._customizedPropertyCreator = customizedPropertyCreator;
				this._customizedArrayItemPropertyCreator = customizedArrayItemPropertyCreator;
			}

			// Token: 0x0601A79C RID: 108444 RVA: 0x00833630 File Offset: 0x00831A30
			public ICustomizedProperty CreateProperty(uint propId, string propName, string valueStr)
			{
				return this._propertyCreator(propId, propName, valueStr);
			}

			// Token: 0x0601A79D RID: 108445 RVA: 0x00833640 File Offset: 0x00831A40
			public ICustomizedProperty CreateArrayItemProperty(uint parentId, string parentName)
			{
				return this._arrayItemPropertyCreator(parentId, parentName);
			}

			// Token: 0x0601A79E RID: 108446 RVA: 0x0083364F File Offset: 0x00831A4F
			public IInstanceMember CreateInstanceProperty(string instance, IInstanceMember indexMember, uint id)
			{
				return this._instancePropertyCreator(instance, indexMember, id);
			}

			// Token: 0x0601A79F RID: 108447 RVA: 0x0083365F File Offset: 0x00831A5F
			public IInstanceMember CreateInstanceConst(string typeName, string valueStr)
			{
				return this._instanceConstCreator(typeName, valueStr);
			}

			// Token: 0x0601A7A0 RID: 108448 RVA: 0x0083366E File Offset: 0x00831A6E
			public ICustomizedProperty CreateCustomizedProperty(uint id, string name, string valueStr)
			{
				return this._customizedPropertyCreator(id, name, valueStr);
			}

			// Token: 0x0601A7A1 RID: 108449 RVA: 0x0083367E File Offset: 0x00831A7E
			public ICustomizedProperty CreateCustomizedArrayItemProperty(uint id, string name)
			{
				return this._customizedArrayItemPropertyCreator(id, name);
			}

			// Token: 0x0401290F RID: 76047
			private AgentMeta.TypeCreator.PropertyCreator _propertyCreator;

			// Token: 0x04012910 RID: 76048
			private AgentMeta.TypeCreator.ArrayItemPropertyCreator _arrayItemPropertyCreator;

			// Token: 0x04012911 RID: 76049
			private AgentMeta.TypeCreator.InstancePropertyCreator _instancePropertyCreator;

			// Token: 0x04012912 RID: 76050
			private AgentMeta.TypeCreator.InstanceConstCreator _instanceConstCreator;

			// Token: 0x04012913 RID: 76051
			private AgentMeta.TypeCreator.CustomizedPropertyCreator _customizedPropertyCreator;

			// Token: 0x04012914 RID: 76052
			private AgentMeta.TypeCreator.CustomizedArrayItemPropertyCreator _customizedArrayItemPropertyCreator;

			// Token: 0x020047FD RID: 18429
			// (Invoke) Token: 0x0601A7A3 RID: 108451
			public delegate ICustomizedProperty PropertyCreator(uint propId, string propName, string valueStr);

			// Token: 0x020047FE RID: 18430
			// (Invoke) Token: 0x0601A7A7 RID: 108455
			public delegate ICustomizedProperty ArrayItemPropertyCreator(uint parentId, string parentName);

			// Token: 0x020047FF RID: 18431
			// (Invoke) Token: 0x0601A7AB RID: 108459
			public delegate IInstanceMember InstancePropertyCreator(string instance, IInstanceMember indexMember, uint id);

			// Token: 0x02004800 RID: 18432
			// (Invoke) Token: 0x0601A7AF RID: 108463
			public delegate IInstanceMember InstanceConstCreator(string typeName, string valueStr);

			// Token: 0x02004801 RID: 18433
			// (Invoke) Token: 0x0601A7B3 RID: 108467
			public delegate ICustomizedProperty CustomizedPropertyCreator(uint id, string name, string valueStr);

			// Token: 0x02004802 RID: 18434
			// (Invoke) Token: 0x0601A7B7 RID: 108471
			public delegate ICustomizedProperty CustomizedArrayItemPropertyCreator(uint id, string name);
		}
	}
}
