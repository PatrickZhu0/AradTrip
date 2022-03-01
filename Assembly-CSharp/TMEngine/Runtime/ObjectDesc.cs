using System;

namespace TMEngine.Runtime
{
	// Token: 0x0200470A RID: 18186
	public struct ObjectDesc
	{
		// Token: 0x0601A161 RID: 106849 RVA: 0x0081EEB1 File Offset: 0x0081D2B1
		public ObjectDesc(string name, bool locked, long timeStamp, int spawnCount, bool inUse)
		{
			this.m_Name = (name ?? string.Empty);
			this.m_Locked = locked;
			this.m_InUse = inUse;
			this.m_LastUseTime = Utility.Time.TicksToDateTime(timeStamp);
			this.m_SpawnCount = spawnCount;
		}

		// Token: 0x170021DA RID: 8666
		// (get) Token: 0x0601A162 RID: 106850 RVA: 0x0081EEE9 File Offset: 0x0081D2E9
		public string Name
		{
			get
			{
				return this.m_Name;
			}
		}

		// Token: 0x170021DB RID: 8667
		// (get) Token: 0x0601A163 RID: 106851 RVA: 0x0081EEF1 File Offset: 0x0081D2F1
		public bool IsLocked
		{
			get
			{
				return this.m_Locked;
			}
		}

		// Token: 0x170021DC RID: 8668
		// (get) Token: 0x0601A164 RID: 106852 RVA: 0x0081EEF9 File Offset: 0x0081D2F9
		public bool IsInUse
		{
			get
			{
				return this.m_InUse;
			}
		}

		// Token: 0x170021DD RID: 8669
		// (get) Token: 0x0601A165 RID: 106853 RVA: 0x0081EF01 File Offset: 0x0081D301
		public DateTime LastUseTime
		{
			get
			{
				return this.m_LastUseTime;
			}
		}

		// Token: 0x170021DE RID: 8670
		// (get) Token: 0x0601A166 RID: 106854 RVA: 0x0081EF09 File Offset: 0x0081D309
		public int SpawnCount
		{
			get
			{
				return this.m_SpawnCount;
			}
		}

		// Token: 0x040125C4 RID: 75204
		private readonly string m_Name;

		// Token: 0x040125C5 RID: 75205
		private readonly bool m_Locked;

		// Token: 0x040125C6 RID: 75206
		private readonly DateTime m_LastUseTime;

		// Token: 0x040125C7 RID: 75207
		private readonly int m_SpawnCount;

		// Token: 0x040125C8 RID: 75208
		private readonly bool m_InUse;
	}
}
