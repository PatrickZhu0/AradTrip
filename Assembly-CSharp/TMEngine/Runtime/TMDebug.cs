using System;
using UnityEngine;

namespace TMEngine.Runtime
{
	// Token: 0x02004709 RID: 18185
	public class TMDebug
	{
		// Token: 0x0601A155 RID: 106837 RVA: 0x0081EDD3 File Offset: 0x0081D1D3
		public static void SetEngineLogLevel(DebugLevel logLevel)
		{
			TMDebug.m_DisableLevel = (int)logLevel;
		}

		// Token: 0x0601A156 RID: 106838 RVA: 0x0081EDDB File Offset: 0x0081D1DB
		public static void Assert(bool condition)
		{
			if (!condition)
			{
				throw new TMEngineException();
			}
		}

		// Token: 0x0601A157 RID: 106839 RVA: 0x0081EDE9 File Offset: 0x0081D1E9
		public static void AssertFailed(string message)
		{
			TMDebug.Assert(false, message);
		}

		// Token: 0x0601A158 RID: 106840 RVA: 0x0081EDF2 File Offset: 0x0081D1F2
		public static void AssertFailed(string format, params object[] args)
		{
			TMDebug.Assert(false, format, args);
		}

		// Token: 0x0601A159 RID: 106841 RVA: 0x0081EDFC File Offset: 0x0081D1FC
		public static void Assert(bool condition, string message)
		{
			if (!condition)
			{
				TMDebug.LogErrorFormat("AssertFailed:{0}", new object[]
				{
					message
				});
			}
		}

		// Token: 0x0601A15A RID: 106842 RVA: 0x0081EE18 File Offset: 0x0081D218
		public static void Assert(bool condition, string format, params object[] args)
		{
			string text = string.Format(format, args);
			if (!condition)
			{
				TMDebug.LogErrorFormat("AssertFailed:{0}", new object[]
				{
					text
				});
			}
		}

		// Token: 0x0601A15B RID: 106843 RVA: 0x0081EE47 File Offset: 0x0081D247
		public static void LogInfoFormat(string format, params object[] args)
		{
			if (TMDebug.m_DisableLevel > 1)
			{
				return;
			}
			Debug.LogFormat(format, args);
		}

		// Token: 0x0601A15C RID: 106844 RVA: 0x0081EE5C File Offset: 0x0081D25C
		public static void LogWarningFormat(string format, params object[] args)
		{
			if (TMDebug.m_DisableLevel > 2)
			{
				return;
			}
			Debug.LogWarningFormat(format, args);
		}

		// Token: 0x0601A15D RID: 106845 RVA: 0x0081EE71 File Offset: 0x0081D271
		public static void LogErrorFormat(string format, params object[] args)
		{
			if (TMDebug.m_DisableLevel > 3)
			{
				return;
			}
			Debug.LogErrorFormat(format, args);
		}

		// Token: 0x0601A15E RID: 106846 RVA: 0x0081EE86 File Offset: 0x0081D286
		public static void LogExceptionFormat(string format, params object[] args)
		{
			if (TMDebug.m_DisableLevel > 4)
			{
				return;
			}
			Debug.LogErrorFormat(format, args);
		}

		// Token: 0x0601A15F RID: 106847 RVA: 0x0081EE9B File Offset: 0x0081D29B
		public static void LogDebugFormat(string format, params object[] args)
		{
			if (TMDebug.m_DisableLevel > 0)
			{
				return;
			}
		}

		// Token: 0x040125C3 RID: 75203
		private static int m_DisableLevel = 5;
	}
}
