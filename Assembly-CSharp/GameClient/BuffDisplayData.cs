using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02000E74 RID: 3700
	public class BuffDisplayData
	{
		// Token: 0x060092C0 RID: 37568 RVA: 0x001B4418 File Offset: 0x001B2818
		public BuffDisplayData(int buffDesTabId)
		{
			this.mTableData = Singleton<TableManager>.GetInstance().GetTableItem<BuffTable>(buffDesTabId, string.Empty, string.Empty);
			this.m_Icon = this.mTableData.Icon;
			this.m_BuffDisName = this.mTableData.BuffDisName;
			this.m_BuffDescription = this.mTableData.Description;
		}

		// Token: 0x170018FD RID: 6397
		// (get) Token: 0x060092C1 RID: 37569 RVA: 0x001B4479 File Offset: 0x001B2879
		public string Icon
		{
			get
			{
				if (string.IsNullOrEmpty(this.m_Icon))
				{
					return string.Empty;
				}
				return this.m_Icon;
			}
		}

		// Token: 0x170018FE RID: 6398
		// (get) Token: 0x060092C2 RID: 37570 RVA: 0x001B4497 File Offset: 0x001B2897
		public string BuffDisName
		{
			get
			{
				if (string.IsNullOrEmpty(this.m_BuffDisName))
				{
					return string.Empty;
				}
				return this.m_BuffDisName;
			}
		}

		// Token: 0x170018FF RID: 6399
		// (get) Token: 0x060092C3 RID: 37571 RVA: 0x001B44B5 File Offset: 0x001B28B5
		public string BuffDescription
		{
			get
			{
				if (string.IsNullOrEmpty(this.m_BuffDescription))
				{
					return string.Empty;
				}
				return this.m_BuffDescription;
			}
		}

		// Token: 0x17001900 RID: 6400
		// (get) Token: 0x060092C4 RID: 37572 RVA: 0x001B44D3 File Offset: 0x001B28D3
		public int BuffTableID
		{
			get
			{
				if (this.TableData != null)
				{
					return this.mTableData.ID;
				}
				return 0;
			}
		}

		// Token: 0x17001901 RID: 6401
		// (get) Token: 0x060092C5 RID: 37573 RVA: 0x001B44ED File Offset: 0x001B28ED
		// (set) Token: 0x060092C6 RID: 37574 RVA: 0x001B44F5 File Offset: 0x001B28F5
		public BuffTable TableData
		{
			get
			{
				return this.mTableData;
			}
			set
			{
				this.mTableData = value;
			}
		}

		// Token: 0x040049DC RID: 18908
		private string m_Icon;

		// Token: 0x040049DD RID: 18909
		private string m_BuffDisName;

		// Token: 0x040049DE RID: 18910
		private string m_BuffDescription;

		// Token: 0x040049DF RID: 18911
		private BuffTable mTableData;
	}
}
