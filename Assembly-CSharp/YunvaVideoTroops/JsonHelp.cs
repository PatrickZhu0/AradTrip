using System;
using LitJson;

namespace YunvaVideoTroops
{
	// Token: 0x02004697 RID: 18071
	public class JsonHelp
	{
		// Token: 0x060198BB RID: 104635 RVA: 0x0080D9AC File Offset: 0x0080BDAC
		public static string getStringValue(JsonData data, string keyName)
		{
			if (data == null || keyName == null)
			{
				return string.Empty;
			}
			string result = string.Empty;
			try
			{
				result = (string)data[keyName];
			}
			catch (Exception ex)
			{
			}
			finally
			{
			}
			return result;
		}

		// Token: 0x060198BC RID: 104636 RVA: 0x0080DA08 File Offset: 0x0080BE08
		public static bool getBoolValue(JsonData data, string keyName)
		{
			if (data == null || keyName == null)
			{
				return false;
			}
			bool result = false;
			try
			{
				result = (bool)data[keyName];
			}
			catch (Exception ex)
			{
				result = ((int)data[keyName] != 0);
			}
			finally
			{
			}
			return result;
		}

		// Token: 0x060198BD RID: 104637 RVA: 0x0080DA7C File Offset: 0x0080BE7C
		public static int getIntValue(JsonData data, string keyName)
		{
			int result = 0;
			try
			{
				result = (int)data[keyName];
			}
			catch (Exception ex)
			{
			}
			finally
			{
			}
			return result;
		}

		// Token: 0x060198BE RID: 104638 RVA: 0x0080DAC4 File Offset: 0x0080BEC4
		public static short getInt16Value(JsonData data, string keyName)
		{
			short result = 0;
			try
			{
				result = (short)((int)data[keyName]);
			}
			catch (Exception ex)
			{
			}
			finally
			{
			}
			return result;
		}

		// Token: 0x060198BF RID: 104639 RVA: 0x0080DB0C File Offset: 0x0080BF0C
		public static int getInt32Value(JsonData data, string keyName)
		{
			int result = 0;
			try
			{
				result = (int)data[keyName];
			}
			catch (Exception ex)
			{
			}
			finally
			{
			}
			return result;
		}

		// Token: 0x060198C0 RID: 104640 RVA: 0x0080DB54 File Offset: 0x0080BF54
		public static long getInt64Value(JsonData data, string keyName)
		{
			long result = 0L;
			try
			{
				result = (long)data[keyName];
			}
			catch (Exception ex)
			{
			}
			finally
			{
			}
			return result;
		}

		// Token: 0x060198C1 RID: 104641 RVA: 0x0080DB9C File Offset: 0x0080BF9C
		public static ulong getUInt64Value(JsonData data, string keyName)
		{
			ulong result = 0UL;
			try
			{
				result = (ulong)((double)data[keyName]);
			}
			catch (Exception ex)
			{
			}
			finally
			{
			}
			return result;
		}

		// Token: 0x060198C2 RID: 104642 RVA: 0x0080DBE4 File Offset: 0x0080BFE4
		public static uint getUInt32Value(JsonData data, string keyName)
		{
			uint result = 0U;
			try
			{
				result = (uint)((long)data[keyName]);
			}
			catch (Exception ex)
			{
			}
			finally
			{
			}
			return result;
		}

		// Token: 0x060198C3 RID: 104643 RVA: 0x0080DC2C File Offset: 0x0080C02C
		public static ushort getUInt16Value(JsonData data, string keyName)
		{
			ushort result = 0;
			try
			{
				result = (ushort)((int)data[keyName]);
			}
			catch (Exception ex)
			{
			}
			finally
			{
			}
			return result;
		}

		// Token: 0x060198C4 RID: 104644 RVA: 0x0080DC74 File Offset: 0x0080C074
		public static uint getUIntValue(JsonData data, string keyName)
		{
			uint result = 0U;
			try
			{
				result = (uint)((long)data[keyName]);
			}
			catch (Exception ex)
			{
			}
			finally
			{
			}
			return result;
		}
	}
}
