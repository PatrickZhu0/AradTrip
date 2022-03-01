using System;

namespace TMEngine.Runtime
{
	// Token: 0x02004711 RID: 18193
	internal abstract class RecyclePoolBase
	{
		// Token: 0x0601A191 RID: 106897 RVA: 0x0081F2C8 File Offset: 0x0081D6C8
		public RecyclePoolBase(int poolID, int reserveCount)
		{
			if (poolID == -1)
			{
				TMDebug.AssertFailed("Pool ID is invalid!");
			}
			this.m_PoolID = poolID;
			this.m_UsingObjectCount = 0;
			this.m_AcquireCount = 0;
			this.m_RecycleCount = 0;
			this.m_CreateCount = 0;
			this.m_ReleaseCount = 0;
			this.m_ReserveCount = reserveCount;
		}

		// Token: 0x170021E9 RID: 8681
		// (get) Token: 0x0601A192 RID: 106898 RVA: 0x0081F31D File Offset: 0x0081D71D
		public int ReserveCount
		{
			get
			{
				return this.m_ReserveCount;
			}
		}

		// Token: 0x170021EA RID: 8682
		// (get) Token: 0x0601A193 RID: 106899 RVA: 0x0081F325 File Offset: 0x0081D725
		public float ExpireTime
		{
			get
			{
				return Utility.Time.TicksToSeconds(this.m_TimeStamp);
			}
		}

		// Token: 0x170021EB RID: 8683
		// (get) Token: 0x0601A194 RID: 106900 RVA: 0x0081F332 File Offset: 0x0081D732
		public int Priority
		{
			get
			{
				return this.m_Priority;
			}
		}

		// Token: 0x170021EC RID: 8684
		// (get) Token: 0x0601A195 RID: 106901
		public abstract int UnusedObjectCount { get; }

		// Token: 0x170021ED RID: 8685
		// (get) Token: 0x0601A196 RID: 106902 RVA: 0x0081F33A File Offset: 0x0081D73A
		public int UsingObjectCount
		{
			get
			{
				return this.m_UsingObjectCount;
			}
		}

		// Token: 0x170021EE RID: 8686
		// (get) Token: 0x0601A197 RID: 106903 RVA: 0x0081F342 File Offset: 0x0081D742
		public int AcquireCount
		{
			get
			{
				return this.m_AcquireCount;
			}
		}

		// Token: 0x170021EF RID: 8687
		// (get) Token: 0x0601A198 RID: 106904 RVA: 0x0081F34A File Offset: 0x0081D74A
		public int RecycleCount
		{
			get
			{
				return this.m_RecycleCount;
			}
		}

		// Token: 0x170021F0 RID: 8688
		// (get) Token: 0x0601A199 RID: 106905 RVA: 0x0081F352 File Offset: 0x0081D752
		public int CreateCount
		{
			get
			{
				return this.m_CreateCount;
			}
		}

		// Token: 0x170021F1 RID: 8689
		// (get) Token: 0x0601A19A RID: 106906 RVA: 0x0081F35A File Offset: 0x0081D75A
		public int ReleaseCount
		{
			get
			{
				return this.m_ReleaseCount;
			}
		}

		// Token: 0x170021F2 RID: 8690
		// (get) Token: 0x0601A19B RID: 106907 RVA: 0x0081F362 File Offset: 0x0081D762
		public int PoolID
		{
			get
			{
				return this.m_PoolID;
			}
		}

		// Token: 0x0601A19C RID: 106908 RVA: 0x0081F36A File Offset: 0x0081D76A
		public void SetReserveCount(int reserveCount)
		{
			if (reserveCount < 0)
			{
				TMDebug.LogWarningFormat("Reserve count can not less than zero!", new object[0]);
				return;
			}
			this.m_ReserveCount = reserveCount;
		}

		// Token: 0x0601A19D RID: 106909 RVA: 0x0081F38B File Offset: 0x0081D78B
		public void SetExpireTime(float expireTime)
		{
			this.m_TimeStamp = Utility.Time.SecondsToTicks(expireTime);
		}

		// Token: 0x0601A19E RID: 106910 RVA: 0x0081F399 File Offset: 0x0081D799
		public void SetPriority(int priority)
		{
			this.m_Priority = priority;
		}

		// Token: 0x0601A19F RID: 106911
		internal abstract I QureyInterface<I>() where I : class;

		// Token: 0x0601A1A0 RID: 106912
		public abstract void PurgePool(bool clearAll);

		// Token: 0x0601A1A1 RID: 106913
		internal abstract void Shutdown();

		// Token: 0x040125CE RID: 75214
		private readonly int m_PoolID;

		// Token: 0x040125CF RID: 75215
		protected int m_UsingObjectCount;

		// Token: 0x040125D0 RID: 75216
		protected int m_AcquireCount;

		// Token: 0x040125D1 RID: 75217
		protected int m_RecycleCount;

		// Token: 0x040125D2 RID: 75218
		protected int m_CreateCount;

		// Token: 0x040125D3 RID: 75219
		protected int m_ReleaseCount;

		// Token: 0x040125D4 RID: 75220
		protected int m_ReserveCount;

		// Token: 0x040125D5 RID: 75221
		protected int m_Priority;

		// Token: 0x040125D6 RID: 75222
		protected long m_TimeStamp;
	}
}
