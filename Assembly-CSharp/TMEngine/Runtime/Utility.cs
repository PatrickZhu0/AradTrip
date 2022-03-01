using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;

namespace TMEngine.Runtime
{
	// Token: 0x020046FD RID: 18173
	public static class Utility
	{
		// Token: 0x020046FE RID: 18174
		public static class Assembly
		{
			// Token: 0x0601A10A RID: 106762 RVA: 0x0081E783 File Offset: 0x0081CB83
			public static System.Reflection.Assembly[] GetAssemblies()
			{
				return Utility.Assembly.s_Assemblies;
			}

			// Token: 0x0601A10B RID: 106763 RVA: 0x0081E78A File Offset: 0x0081CB8A
			public static Type[] GetAllTypes()
			{
				return Utility.Assembly.s_CachedTypes.GetAllTypes();
			}

			// Token: 0x0601A10C RID: 106764 RVA: 0x0081E796 File Offset: 0x0081CB96
			public static Type GetType(string typeName)
			{
				return Utility.Assembly.s_CachedTypes.GetType(typeName);
			}

			// Token: 0x0601A10D RID: 106765 RVA: 0x0081E7A3 File Offset: 0x0081CBA3
			public static object CreateInstance(Type type)
			{
				return Activator.CreateInstance(type);
			}

			// Token: 0x0601A10E RID: 106766 RVA: 0x0081E7AC File Offset: 0x0081CBAC
			public static object CreateInstance(string typeFullName)
			{
				Type type = Utility.Assembly.GetType(typeFullName);
				if (type != null)
				{
					return Activator.CreateInstance(type);
				}
				return null;
			}

			// Token: 0x0601A10F RID: 106767 RVA: 0x0081E7D0 File Offset: 0x0081CBD0
			public static string[] GetTypeNamesOf(Type baseType)
			{
				List<string> list = new List<string>();
				Type[] allTypes = Utility.Assembly.GetAllTypes();
				int i = 0;
				int num = allTypes.Length;
				while (i < num)
				{
					Type type = allTypes[i];
					if (type.IsClass && !type.IsAbstract && baseType.IsAssignableFrom(type))
					{
						list.Add(type.FullName);
					}
					i++;
				}
				list.Sort();
				return list.ToArray();
			}

			// Token: 0x040125AF RID: 75183
			private static readonly System.Reflection.Assembly[] s_Assemblies = AppDomain.CurrentDomain.GetAssemblies();

			// Token: 0x040125B0 RID: 75184
			private static readonly Utility.Assembly.TypeTable s_CachedTypes = new Utility.Assembly.TypeTable(Utility.Assembly.s_Assemblies);

			// Token: 0x020046FF RID: 18175
			internal class TypeTable
			{
				// Token: 0x0601A110 RID: 106768 RVA: 0x0081E842 File Offset: 0x0081CC42
				public TypeTable(System.Reflection.Assembly[] assemblies)
				{
					this.m_Assemblies = (assemblies ?? new System.Reflection.Assembly[0]);
					this.m_TypeTable = new Dictionary<string, Type>();
				}

				// Token: 0x0601A111 RID: 106769 RVA: 0x0081E86C File Offset: 0x0081CC6C
				public Type GetType(string typeName)
				{
					if (string.IsNullOrEmpty(typeName))
					{
						TMDebug.LogWarningFormat("Type name can not be null or empty string!", new object[0]);
						return null;
					}
					Type type = null;
					if (this.m_TypeTable.TryGetValue(typeName, out type))
					{
						return type;
					}
					type = Type.GetType(typeName);
					if (type != null)
					{
						this.m_TypeTable.Add(typeName, type);
						return type;
					}
					int i = 0;
					int num = this.m_Assemblies.Length;
					while (i < num)
					{
						System.Reflection.Assembly assembly = this.m_Assemblies[i];
						type = Type.GetType(string.Format("{0}, {1}", typeName, assembly.FullName));
						if (type != null)
						{
							this.m_TypeTable.Add(typeName, type);
							return type;
						}
						i++;
					}
					return null;
				}

				// Token: 0x0601A112 RID: 106770 RVA: 0x0081E91C File Offset: 0x0081CD1C
				public Type[] GetAllTypes()
				{
					List<Type> list = new List<Type>();
					for (int i = 0; i < this.m_Assemblies.Length; i++)
					{
						list.AddRange(this.m_Assemblies[i].GetTypes());
					}
					return list.ToArray();
				}

				// Token: 0x0601A113 RID: 106771 RVA: 0x0081E961 File Offset: 0x0081CD61
				public void ClearAll()
				{
					this.m_TypeTable.Clear();
				}

				// Token: 0x040125B1 RID: 75185
				private readonly System.Reflection.Assembly[] m_Assemblies;

				// Token: 0x040125B2 RID: 75186
				private readonly Dictionary<string, Type> m_TypeTable;
			}
		}

		// Token: 0x02004700 RID: 18176
		public static class Converter
		{
			// Token: 0x170021D8 RID: 8664
			// (get) Token: 0x0601A114 RID: 106772 RVA: 0x0081E96E File Offset: 0x0081CD6E
			public static bool IsLittleEndian
			{
				get
				{
					return BitConverter.IsLittleEndian;
				}
			}

			// Token: 0x170021D9 RID: 8665
			// (get) Token: 0x0601A115 RID: 106773 RVA: 0x0081E975 File Offset: 0x0081CD75
			// (set) Token: 0x0601A116 RID: 106774 RVA: 0x0081E97C File Offset: 0x0081CD7C
			public static float ScreenDpi { get; set; }

			// Token: 0x0601A117 RID: 106775 RVA: 0x0081E984 File Offset: 0x0081CD84
			public static float GetCentimetersFromPixels(float pixels)
			{
				if (Utility.Converter.ScreenDpi <= 0f)
				{
					throw new TMEngineException("You must set screen DPI first.");
				}
				return 2.54f * pixels / Utility.Converter.ScreenDpi;
			}

			// Token: 0x0601A118 RID: 106776 RVA: 0x0081E9AD File Offset: 0x0081CDAD
			public static float GetPixelsFromCentimeters(float centimeters)
			{
				if (Utility.Converter.ScreenDpi <= 0f)
				{
					throw new TMEngineException("You must set screen DPI first.");
				}
				return 0.39370078f * centimeters * Utility.Converter.ScreenDpi;
			}

			// Token: 0x0601A119 RID: 106777 RVA: 0x0081E9D6 File Offset: 0x0081CDD6
			public static float GetInchesFromPixels(float pixels)
			{
				if (Utility.Converter.ScreenDpi <= 0f)
				{
					throw new TMEngineException("You must set screen DPI first.");
				}
				return pixels / Utility.Converter.ScreenDpi;
			}

			// Token: 0x0601A11A RID: 106778 RVA: 0x0081E9F9 File Offset: 0x0081CDF9
			public static float GetPixelsFromInches(float inches)
			{
				if (Utility.Converter.ScreenDpi <= 0f)
				{
					throw new TMEngineException("You must set screen DPI first.");
				}
				return inches * Utility.Converter.ScreenDpi;
			}

			// Token: 0x0601A11B RID: 106779 RVA: 0x0081EA1C File Offset: 0x0081CE1C
			public static byte[] GetBytes(bool value)
			{
				return BitConverter.GetBytes(value);
			}

			// Token: 0x0601A11C RID: 106780 RVA: 0x0081EA24 File Offset: 0x0081CE24
			public static bool GetBoolean(byte[] value)
			{
				return BitConverter.ToBoolean(value, 0);
			}

			// Token: 0x0601A11D RID: 106781 RVA: 0x0081EA2D File Offset: 0x0081CE2D
			public static bool GetBoolean(byte[] value, int startIndex)
			{
				return BitConverter.ToBoolean(value, startIndex);
			}

			// Token: 0x0601A11E RID: 106782 RVA: 0x0081EA36 File Offset: 0x0081CE36
			public static byte[] GetBytes(char value)
			{
				return BitConverter.GetBytes(value);
			}

			// Token: 0x0601A11F RID: 106783 RVA: 0x0081EA3E File Offset: 0x0081CE3E
			public static char GetChar(byte[] value)
			{
				return BitConverter.ToChar(value, 0);
			}

			// Token: 0x0601A120 RID: 106784 RVA: 0x0081EA47 File Offset: 0x0081CE47
			public static char GetChar(byte[] value, int startIndex)
			{
				return BitConverter.ToChar(value, startIndex);
			}

			// Token: 0x0601A121 RID: 106785 RVA: 0x0081EA50 File Offset: 0x0081CE50
			public static byte[] GetBytes(short value)
			{
				return BitConverter.GetBytes(value);
			}

			// Token: 0x0601A122 RID: 106786 RVA: 0x0081EA58 File Offset: 0x0081CE58
			public static short GetInt16(byte[] value)
			{
				return BitConverter.ToInt16(value, 0);
			}

			// Token: 0x0601A123 RID: 106787 RVA: 0x0081EA61 File Offset: 0x0081CE61
			public static short GetInt16(byte[] value, int startIndex)
			{
				return BitConverter.ToInt16(value, startIndex);
			}

			// Token: 0x0601A124 RID: 106788 RVA: 0x0081EA6A File Offset: 0x0081CE6A
			public static byte[] GetBytes(ushort value)
			{
				return BitConverter.GetBytes(value);
			}

			// Token: 0x0601A125 RID: 106789 RVA: 0x0081EA72 File Offset: 0x0081CE72
			public static ushort GetUInt16(byte[] value)
			{
				return BitConverter.ToUInt16(value, 0);
			}

			// Token: 0x0601A126 RID: 106790 RVA: 0x0081EA7B File Offset: 0x0081CE7B
			public static ushort GetUInt16(byte[] value, int startIndex)
			{
				return BitConverter.ToUInt16(value, startIndex);
			}

			// Token: 0x0601A127 RID: 106791 RVA: 0x0081EA84 File Offset: 0x0081CE84
			public static byte[] GetBytes(int value)
			{
				return BitConverter.GetBytes(value);
			}

			// Token: 0x0601A128 RID: 106792 RVA: 0x0081EA8C File Offset: 0x0081CE8C
			public static int GetInt32(byte[] value)
			{
				return BitConverter.ToInt32(value, 0);
			}

			// Token: 0x0601A129 RID: 106793 RVA: 0x0081EA95 File Offset: 0x0081CE95
			public static int GetInt32(byte[] value, int startIndex)
			{
				return BitConverter.ToInt32(value, startIndex);
			}

			// Token: 0x0601A12A RID: 106794 RVA: 0x0081EA9E File Offset: 0x0081CE9E
			public static byte[] GetBytes(uint value)
			{
				return BitConverter.GetBytes(value);
			}

			// Token: 0x0601A12B RID: 106795 RVA: 0x0081EAA6 File Offset: 0x0081CEA6
			public static uint GetUInt32(byte[] value)
			{
				return BitConverter.ToUInt32(value, 0);
			}

			// Token: 0x0601A12C RID: 106796 RVA: 0x0081EAAF File Offset: 0x0081CEAF
			public static uint GetUInt32(byte[] value, int startIndex)
			{
				return BitConverter.ToUInt32(value, startIndex);
			}

			// Token: 0x0601A12D RID: 106797 RVA: 0x0081EAB8 File Offset: 0x0081CEB8
			public static byte[] GetBytes(long value)
			{
				return BitConverter.GetBytes(value);
			}

			// Token: 0x0601A12E RID: 106798 RVA: 0x0081EAC0 File Offset: 0x0081CEC0
			public static long GetInt64(byte[] value)
			{
				return BitConverter.ToInt64(value, 0);
			}

			// Token: 0x0601A12F RID: 106799 RVA: 0x0081EAC9 File Offset: 0x0081CEC9
			public static long GetInt64(byte[] value, int startIndex)
			{
				return BitConverter.ToInt64(value, startIndex);
			}

			// Token: 0x0601A130 RID: 106800 RVA: 0x0081EAD2 File Offset: 0x0081CED2
			public static byte[] GetBytes(ulong value)
			{
				return BitConverter.GetBytes(value);
			}

			// Token: 0x0601A131 RID: 106801 RVA: 0x0081EADA File Offset: 0x0081CEDA
			public static ulong GetUInt64(byte[] value)
			{
				return BitConverter.ToUInt64(value, 0);
			}

			// Token: 0x0601A132 RID: 106802 RVA: 0x0081EAE3 File Offset: 0x0081CEE3
			public static ulong GetUInt64(byte[] value, int startIndex)
			{
				return BitConverter.ToUInt64(value, startIndex);
			}

			// Token: 0x0601A133 RID: 106803 RVA: 0x0081EAEC File Offset: 0x0081CEEC
			public static byte[] GetBytes(float value)
			{
				return BitConverter.GetBytes(value);
			}

			// Token: 0x0601A134 RID: 106804 RVA: 0x0081EAF4 File Offset: 0x0081CEF4
			public static float GetSingle(byte[] value)
			{
				return BitConverter.ToSingle(value, 0);
			}

			// Token: 0x0601A135 RID: 106805 RVA: 0x0081EAFD File Offset: 0x0081CEFD
			public static float GetSingle(byte[] value, int startIndex)
			{
				return BitConverter.ToSingle(value, startIndex);
			}

			// Token: 0x0601A136 RID: 106806 RVA: 0x0081EB06 File Offset: 0x0081CF06
			public static byte[] GetBytes(double value)
			{
				return BitConverter.GetBytes(value);
			}

			// Token: 0x0601A137 RID: 106807 RVA: 0x0081EB0E File Offset: 0x0081CF0E
			public static double GetDouble(byte[] value)
			{
				return BitConverter.ToDouble(value, 0);
			}

			// Token: 0x0601A138 RID: 106808 RVA: 0x0081EB17 File Offset: 0x0081CF17
			public static double GetDouble(byte[] value, int startIndex)
			{
				return BitConverter.ToDouble(value, startIndex);
			}

			// Token: 0x0601A139 RID: 106809 RVA: 0x0081EB20 File Offset: 0x0081CF20
			public static byte[] GetBytes(string value)
			{
				return Encoding.UTF8.GetBytes(value);
			}

			// Token: 0x0601A13A RID: 106810 RVA: 0x0081EB2D File Offset: 0x0081CF2D
			public static string GetString(byte[] value)
			{
				if (value == null)
				{
					throw new TMEngineException("Value is invalid.");
				}
				return Encoding.UTF8.GetString(value, 0, value.Length);
			}

			// Token: 0x040125B3 RID: 75187
			private const float CONST_INCHES_TO_CENTIMETERS = 2.54f;

			// Token: 0x040125B4 RID: 75188
			private const float CONST_CENTIMETERS_TO_INCHES = 0.39370078f;
		}

		// Token: 0x02004701 RID: 18177
		internal static class Encryption
		{
			// Token: 0x0601A13B RID: 106811 RVA: 0x0081EB4F File Offset: 0x0081CF4F
			public static byte[] GetQuickXorBytes(byte[] bytes, byte[] code)
			{
				return Utility.Encryption.GetXorBytes(bytes, code, 220);
			}

			// Token: 0x0601A13C RID: 106812 RVA: 0x0081EB60 File Offset: 0x0081CF60
			public static byte[] GetXorBytes(byte[] bytes, byte[] code, int length = 0)
			{
				if (bytes == null)
				{
					return null;
				}
				if (code == null)
				{
					throw new TMEngineException("Code is invalid.");
				}
				int num = code.Length;
				if (num <= 0)
				{
					throw new TMEngineException("Code length is invalid.");
				}
				int num2 = 0;
				int num3 = bytes.Length;
				if (length <= 0 || length > num3)
				{
					length = num3;
				}
				byte[] array = new byte[num3];
				Buffer.BlockCopy(bytes, 0, array, 0, num3);
				for (int i = 0; i < length; i++)
				{
					byte[] array2 = array;
					int num4 = i;
					array2[num4] ^= code[num2++];
					num2 %= num;
				}
				return array;
			}

			// Token: 0x040125B6 RID: 75190
			private const int CONST_QUICK_ENCRYPT_LENGTH = 220;
		}

		// Token: 0x02004702 RID: 18178
		public static class File
		{
			// Token: 0x0601A13D RID: 106813 RVA: 0x0081EBF3 File Offset: 0x0081CFF3
			public static bool Exists(string path)
			{
				return System.IO.File.Exists(path);
			}

			// Token: 0x0601A13E RID: 106814 RVA: 0x0081EBFB File Offset: 0x0081CFFB
			public static FileStream OpenRead(string path)
			{
				return System.IO.File.OpenRead(path);
			}
		}

		// Token: 0x02004703 RID: 18179
		public static class Path
		{
			// Token: 0x0601A13F RID: 106815 RVA: 0x0081EC03 File Offset: 0x0081D003
			public static string Normalize(string path)
			{
				if (string.IsNullOrEmpty(path))
				{
					return path;
				}
				return path.Replace('\\', '/');
			}

			// Token: 0x0601A140 RID: 106816 RVA: 0x0081EC1C File Offset: 0x0081D01C
			public static string Combine(string path1, string path2)
			{
				string path3 = System.IO.Path.Combine(path1, path2);
				return Utility.Path.Normalize(path3);
			}

			// Token: 0x0601A141 RID: 106817 RVA: 0x0081EC38 File Offset: 0x0081D038
			public static string Combine(string[] paths)
			{
				if (paths == null || paths.Length < 1)
				{
					return string.Empty;
				}
				string text = paths[0];
				int i = 1;
				int num = paths.Length;
				while (i < num)
				{
					text = System.IO.Path.Combine(text, paths[i]);
					i++;
				}
				return Utility.Path.Normalize(text);
			}

			// Token: 0x0601A142 RID: 106818 RVA: 0x0081EC84 File Offset: 0x0081D084
			public static string ChangeExtension(string path, string dstExt)
			{
				string path2 = System.IO.Path.ChangeExtension(path, dstExt);
				return Utility.Path.Normalize(path2);
			}

			// Token: 0x0601A143 RID: 106819 RVA: 0x0081EC9F File Offset: 0x0081D09F
			public static bool HasExtension(string path)
			{
				return System.IO.Path.HasExtension(path);
			}

			// Token: 0x0601A144 RID: 106820 RVA: 0x0081ECA7 File Offset: 0x0081D0A7
			public static string GetFileName(string path)
			{
				return System.IO.Path.GetFileName(path);
			}
		}

		// Token: 0x02004704 RID: 18180
		public static class Text
		{
			// Token: 0x0601A145 RID: 106821 RVA: 0x0081ECAF File Offset: 0x0081D0AF
			public static string GetNameWithType<T>(string name)
			{
				return Utility.Text.GetNameWithType(typeof(T), name);
			}

			// Token: 0x0601A146 RID: 106822 RVA: 0x0081ECC4 File Offset: 0x0081D0C4
			public static string GetNameWithType(Type type, string name)
			{
				string text;
				if (type != null)
				{
					text = type.FullName;
				}
				else
				{
					TMDebug.LogWarningFormat("Type is null!", new object[0]);
					text = "<UnknownType>";
				}
				return (!string.IsNullOrEmpty(name)) ? string.Format("{0}.{1}", text, name) : text;
			}
		}

		// Token: 0x02004705 RID: 18181
		public static class Thread
		{
			// Token: 0x0601A147 RID: 106823 RVA: 0x0081ED18 File Offset: 0x0081D118
			public static void SetMainThread()
			{
				Utility.Thread.m_MainThreadID = System.Threading.Thread.CurrentThread.ManagedThreadId;
			}

			// Token: 0x0601A148 RID: 106824 RVA: 0x0081ED29 File Offset: 0x0081D129
			public static bool IsMainThread()
			{
				if (Utility.Thread.m_MainThreadID == -1)
				{
					throw new Exception("Main thread ID is not set!");
				}
				return Utility.Thread.m_MainThreadID == System.Threading.Thread.CurrentThread.ManagedThreadId;
			}

			// Token: 0x040125B7 RID: 75191
			private static int m_MainThreadID = -1;
		}

		// Token: 0x02004706 RID: 18182
		public static class Time
		{
			// Token: 0x0601A14A RID: 106826 RVA: 0x0081ED5A File Offset: 0x0081D15A
			public static float TicksToSeconds(long ticks)
			{
				return (float)ticks * 1E-07f;
			}

			// Token: 0x0601A14B RID: 106827 RVA: 0x0081ED64 File Offset: 0x0081D164
			public static long SecondsToTicks(float seconds)
			{
				return (long)(seconds * 10000000f);
			}

			// Token: 0x0601A14C RID: 106828 RVA: 0x0081ED6E File Offset: 0x0081D16E
			public static float TicksToMicroseconds(long ticks)
			{
				return (float)ticks * 0.0001f;
			}

			// Token: 0x0601A14D RID: 106829 RVA: 0x0081ED78 File Offset: 0x0081D178
			public static long MicrosecondsToTicks(float microseconds)
			{
				return (long)(microseconds * 10000f);
			}

			// Token: 0x0601A14E RID: 106830 RVA: 0x0081ED82 File Offset: 0x0081D182
			public static DateTime TicksToDateTime(long ticks)
			{
				return new DateTime(ticks);
			}

			// Token: 0x0601A14F RID: 106831 RVA: 0x0081ED8C File Offset: 0x0081D18C
			public static long GetTicksNow()
			{
				return DateTime.Now.Ticks;
			}

			// Token: 0x040125B8 RID: 75192
			private const long CONST_TICKS_PER_SECOND = 10000000L;

			// Token: 0x040125B9 RID: 75193
			private const float CONST_SECOND_PER_TICKS = 1E-07f;

			// Token: 0x040125BA RID: 75194
			private const long CONST_TICKS_PER_MICRO_SECOND = 10000L;

			// Token: 0x040125BB RID: 75195
			private const float CONST_MICRO_SECOND_PER_TICKS = 0.0001f;
		}
	}
}
