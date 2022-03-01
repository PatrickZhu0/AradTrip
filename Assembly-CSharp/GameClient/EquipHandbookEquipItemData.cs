using System;
using System.Collections.Generic;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020015C5 RID: 5573
	public class EquipHandbookEquipItemData : IComparable<EquipHandbookEquipItemData>
	{
		// Token: 0x0600DA3B RID: 55867 RVA: 0x0036DCA8 File Offset: 0x0036C0A8
		public EquipHandbookEquipItemData(int id)
		{
			this.id = id;
			this.bind = null;
			EquipHandbookAttachedTable tableItem = Singleton<TableManager>.instance.GetTableItem<EquipHandbookAttachedTable>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.fitOccupations.AddRange(tableItem.OccopationLimit);
				this.baseOccupation.AddRange(tableItem.BaseOccopationLimit);
			}
		}

		// Token: 0x17001C50 RID: 7248
		// (get) Token: 0x0600DA3C RID: 55868 RVA: 0x0036DD1D File Offset: 0x0036C11D
		public bool isFitOccupation
		{
			get
			{
				return EquipHandbookUtility.IsFitOccupation(this.fitOccupations, this.baseOccupation);
			}
		}

		// Token: 0x17001C51 RID: 7249
		// (get) Token: 0x0600DA3E RID: 55870 RVA: 0x0036DD39 File Offset: 0x0036C139
		// (set) Token: 0x0600DA3D RID: 55869 RVA: 0x0036DD30 File Offset: 0x0036C130
		public int id { get; private set; }

		// Token: 0x17001C52 RID: 7250
		// (get) Token: 0x0600DA40 RID: 55872 RVA: 0x0036DD4A File Offset: 0x0036C14A
		// (set) Token: 0x0600DA3F RID: 55871 RVA: 0x0036DD41 File Offset: 0x0036C141
		public int baseScore { get; private set; }

		// Token: 0x0600DA41 RID: 55873 RVA: 0x0036DD52 File Offset: 0x0036C152
		public void CalculateBaseScore()
		{
			if (this.baseScore != 0)
			{
				return;
			}
			this.baseScore = DataManager<ItemSourceInfoTableManager>.GetInstance().GetItemBaseScore(this.id);
		}

		// Token: 0x0600DA42 RID: 55874 RVA: 0x0036DD76 File Offset: 0x0036C176
		public int CompareTo(EquipHandbookEquipItemData other)
		{
			return this.baseScore - other.baseScore;
		}

		// Token: 0x17001C53 RID: 7251
		// (get) Token: 0x0600DA43 RID: 55875 RVA: 0x0036DD85 File Offset: 0x0036C185
		// (set) Token: 0x0600DA44 RID: 55876 RVA: 0x0036DD8D File Offset: 0x0036C18D
		public ComCommonBind bind { get; set; }

		// Token: 0x04008060 RID: 32864
		public List<int> fitOccupations = new List<int>();

		// Token: 0x04008061 RID: 32865
		public List<int> baseOccupation = new List<int>();
	}
}
