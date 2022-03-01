using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020012A2 RID: 4770
	public class MagicJarBuyInfo : JarBuyInfo
	{
		// Token: 0x0600B791 RID: 46993 RVA: 0x0029EBCC File Offset: 0x0029CFCC
		public MagicJarBuyInfo(int JarID)
		{
			this.JarTableID = JarID;
		}

		// Token: 0x17001AFB RID: 6907
		// (get) Token: 0x0600B792 RID: 46994 RVA: 0x0029EBDC File Offset: 0x0029CFDC
		// (set) Token: 0x0600B793 RID: 46995 RVA: 0x0029EC3C File Offset: 0x0029D03C
		public override int nFreeTimestamp
		{
			get
			{
				JarBonus tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JarBonus>(this.JarTableID, string.Empty, string.Empty);
				if (tableItem == null)
				{
					Logger.LogErrorFormat("Get JarDataManager nFreeTimestamp is wrong, JarTableID = {0}", new object[]
					{
						this.JarTableID
					});
					return 0;
				}
				return DataManager<CountDataManager>.GetInstance().GetCount(tableItem.NextFreeTimeCounterKey);
			}
			set
			{
				JarBonus tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JarBonus>(this.JarTableID, string.Empty, string.Empty);
				if (tableItem == null)
				{
					Logger.LogErrorFormat("Set JarDataManager nFreeTimestamp is wrong, JarTableID = {0}", new object[]
					{
						this.JarTableID
					});
					return;
				}
				DataManager<CountDataManager>.GetInstance().SetCount(tableItem.NextFreeTimeCounterKey, (uint)value);
			}
		}

		// Token: 0x17001AFC RID: 6908
		// (get) Token: 0x0600B794 RID: 46996 RVA: 0x0029EC9C File Offset: 0x0029D09C
		// (set) Token: 0x0600B795 RID: 46997 RVA: 0x0029EDB4 File Offset: 0x0029D1B4
		public override int nFreeCount
		{
			get
			{
				if (this.nMaxFreeCount <= 0 || this.nFreeCD <= 0)
				{
					return 0;
				}
				JarBonus tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JarBonus>(this.JarTableID, string.Empty, string.Empty);
				if (tableItem == null)
				{
					Logger.LogErrorFormat("Get JarDataManager nFreeCount is wrong, JarTableID = {0}", new object[]
					{
						this.JarTableID
					});
					return 0;
				}
				int num = DataManager<CountDataManager>.GetInstance().GetCount(tableItem.FreeNumCounterKey);
				if (num >= 0 && num < this.nMaxFreeCount)
				{
					bool flag = false;
					int serverTime = (int)DataManager<TimeManager>.GetInstance().GetServerTime();
					while (this.nFreeTimestamp <= serverTime)
					{
						flag = true;
						num++;
						if (num < 0)
						{
							num = 0;
						}
						else if (num > this.nMaxFreeCount)
						{
							num = this.nMaxFreeCount;
						}
						if (num >= this.nMaxFreeCount)
						{
							break;
						}
						this.nFreeTimestamp += this.nFreeCD;
					}
					if (flag)
					{
						this.nFreeCount = num;
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.JarFreeTimeChanged, null, null, null, null);
					}
				}
				return num;
			}
			set
			{
				int num = value;
				if (num < 0)
				{
					num = 0;
				}
				else if (num > this.nMaxFreeCount)
				{
					num = this.nMaxFreeCount;
				}
				JarBonus tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JarBonus>(this.JarTableID, string.Empty, string.Empty);
				if (tableItem == null)
				{
					Logger.LogErrorFormat("Set JarDataManager nFreeCount is wrong, JarTableID = {0}", new object[]
					{
						this.JarTableID
					});
					return;
				}
				DataManager<CountDataManager>.GetInstance().SetCount(tableItem.FreeNumCounterKey, (uint)num);
			}
		}

		// Token: 0x04006785 RID: 26501
		private int JarTableID;
	}
}
