using System;

namespace behaviac
{
	// Token: 0x020048BB RID: 18619
	public static class Config
	{
		// Token: 0x0601AC54 RID: 109652 RVA: 0x0083C7C9 File Offset: 0x0083ABC9
		public static void LogInfo()
		{
		}

		// Token: 0x170022A1 RID: 8865
		// (get) Token: 0x0601AC55 RID: 109653 RVA: 0x0083C7CB File Offset: 0x0083ABCB
		// (set) Token: 0x0601AC56 RID: 109654 RVA: 0x0083C7D2 File Offset: 0x0083ABD2
		public static bool IsProfiling
		{
			get
			{
				return Config.m_bProfiling;
			}
			set
			{
				if (Config.m_bProfiling)
				{
				}
			}
		}

		// Token: 0x170022A2 RID: 8866
		// (get) Token: 0x0601AC57 RID: 109655 RVA: 0x0083C7DE File Offset: 0x0083ABDE
		public static bool IsLoggingOrSocketing
		{
			get
			{
				return Config.IsLogging || Config.IsSocketing;
			}
		}

		// Token: 0x170022A3 RID: 8867
		// (get) Token: 0x0601AC58 RID: 109656 RVA: 0x0083C7F2 File Offset: 0x0083ABF2
		// (set) Token: 0x0601AC59 RID: 109657 RVA: 0x0083C7F9 File Offset: 0x0083ABF9
		public static bool IsLogging
		{
			get
			{
				return Config.m_bIsLogging;
			}
			set
			{
				if (Config.m_bIsLogging)
				{
				}
			}
		}

		// Token: 0x170022A4 RID: 8868
		// (get) Token: 0x0601AC5A RID: 109658 RVA: 0x0083C805 File Offset: 0x0083AC05
		// (set) Token: 0x0601AC5B RID: 109659 RVA: 0x0083C80C File Offset: 0x0083AC0C
		public static bool IsLoggingFlush
		{
			get
			{
				return Config.m_bIsLoggingFlush;
			}
			set
			{
				if (Config.m_bIsLoggingFlush)
				{
				}
			}
		}

		// Token: 0x170022A5 RID: 8869
		// (get) Token: 0x0601AC5C RID: 109660 RVA: 0x0083C818 File Offset: 0x0083AC18
		// (set) Token: 0x0601AC5D RID: 109661 RVA: 0x0083C81F File Offset: 0x0083AC1F
		public static bool IsSocketing
		{
			get
			{
				return Config.m_bIsSocketing;
			}
			set
			{
				if (Config.m_bIsLogging)
				{
				}
			}
		}

		// Token: 0x170022A6 RID: 8870
		// (get) Token: 0x0601AC5E RID: 109662 RVA: 0x0083C82B File Offset: 0x0083AC2B
		// (set) Token: 0x0601AC5F RID: 109663 RVA: 0x0083C832 File Offset: 0x0083AC32
		public static bool IsSocketBlocking
		{
			get
			{
				return Config.m_bIsSocketBlocking;
			}
			set
			{
				Config.m_bIsSocketBlocking = value;
			}
		}

		// Token: 0x170022A7 RID: 8871
		// (get) Token: 0x0601AC60 RID: 109664 RVA: 0x0083C83A File Offset: 0x0083AC3A
		// (set) Token: 0x0601AC61 RID: 109665 RVA: 0x0083C841 File Offset: 0x0083AC41
		public static ushort SocketPort
		{
			get
			{
				return Config.m_socketPort;
			}
			set
			{
				Config.m_socketPort = value;
			}
		}

		// Token: 0x170022A8 RID: 8872
		// (get) Token: 0x0601AC62 RID: 109666 RVA: 0x0083C849 File Offset: 0x0083AC49
		// (set) Token: 0x0601AC63 RID: 109667 RVA: 0x0083C850 File Offset: 0x0083AC50
		public static bool IsHotReload
		{
			get
			{
				return Config.m_bIsHotReload;
			}
			set
			{
				Config.m_bIsHotReload = value;
			}
		}

		// Token: 0x170022A9 RID: 8873
		// (get) Token: 0x0601AC64 RID: 109668 RVA: 0x0083C858 File Offset: 0x0083AC58
		// (set) Token: 0x0601AC65 RID: 109669 RVA: 0x0083C85F File Offset: 0x0083AC5F
		public static bool IsSuppressingNonPublicWarning
		{
			get
			{
				return Config.m_bIsSuppressingNonPublicWarning;
			}
			set
			{
				Config.m_bIsSuppressingNonPublicWarning = value;
			}
		}

		// Token: 0x170022AA RID: 8874
		// (get) Token: 0x0601AC66 RID: 109670 RVA: 0x0083C867 File Offset: 0x0083AC67
		// (set) Token: 0x0601AC67 RID: 109671 RVA: 0x0083C86E File Offset: 0x0083AC6E
		public static bool PreloadBehaviors
		{
			get
			{
				return Config.m_bPreloadBehaviors;
			}
			set
			{
				Config.m_bPreloadBehaviors = value;
			}
		}

		// Token: 0x04012A2B RID: 76331
		private static bool m_bProfiling;

		// Token: 0x04012A2C RID: 76332
		private static bool m_bIsLogging;

		// Token: 0x04012A2D RID: 76333
		private static bool m_bIsLoggingFlush;

		// Token: 0x04012A2E RID: 76334
		private static bool m_bIsSocketing;

		// Token: 0x04012A2F RID: 76335
		private static bool m_bIsSocketBlocking;

		// Token: 0x04012A30 RID: 76336
		private static ushort m_socketPort = 60636;

		// Token: 0x04012A31 RID: 76337
		private static bool m_bIsHotReload = true;

		// Token: 0x04012A32 RID: 76338
		private static bool m_bIsSuppressingNonPublicWarning;

		// Token: 0x04012A33 RID: 76339
		private static bool m_bPreloadBehaviors = true;
	}
}
