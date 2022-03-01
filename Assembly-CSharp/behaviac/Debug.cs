using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace behaviac
{
	// Token: 0x02004838 RID: 18488
	public static class Debug
	{
		// Token: 0x0601A927 RID: 108839 RVA: 0x00837101 File Offset: 0x00835501
		[Conditional("BEHAVIAC_DEBUG")]
		public static void CheckEqual<T>(T l, T r)
		{
			if (!EqualityComparer<T>.Default.Equals(l, r))
			{
			}
		}

		// Token: 0x0601A928 RID: 108840 RVA: 0x00837114 File Offset: 0x00835514
		[Conditional("BEHAVIAC_DEBUG")]
		public static void Check(bool b)
		{
			if (!b)
			{
			}
		}

		// Token: 0x0601A929 RID: 108841 RVA: 0x0083711C File Offset: 0x0083551C
		[Conditional("BEHAVIAC_DEBUG")]
		public static void Check(bool b, string message)
		{
			if (!b)
			{
			}
		}

		// Token: 0x0601A92A RID: 108842 RVA: 0x00837124 File Offset: 0x00835524
		[Conditional("BEHAVIAC_DEBUG")]
		public static void Check(bool b, string format, object arg0)
		{
			if (!b)
			{
				string text = string.Format(format, arg0);
			}
		}

		// Token: 0x0601A92B RID: 108843 RVA: 0x0083713F File Offset: 0x0083553F
		[Conditional("BEHAVIAC_DEBUG")]
		public static void Log(string message)
		{
			Debug.Log(message);
		}

		// Token: 0x0601A92C RID: 108844 RVA: 0x00837147 File Offset: 0x00835547
		[Conditional("UNITY_EDITOR")]
		public static void LogWarning(string message)
		{
			Debug.LogWarning(message);
		}

		// Token: 0x0601A92D RID: 108845 RVA: 0x0083714F File Offset: 0x0083554F
		[Conditional("UNITY_EDITOR")]
		public static void LogError(string message)
		{
			LogManager.Instance.Flush(null);
			Debug.LogError(message);
		}

		// Token: 0x0601A92E RID: 108846 RVA: 0x00837162 File Offset: 0x00835562
		[Conditional("UNITY_EDITOR")]
		public static void LogError(Exception ex)
		{
			LogManager.Instance.Flush(null);
			Debug.LogError(ex.Message);
		}

		// Token: 0x0601A92F RID: 108847 RVA: 0x0083717A File Offset: 0x0083557A
		[Conditional("UNITY_EDITOR")]
		public static void Break(string msg)
		{
			Debug.Break();
		}
	}
}
