using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020014D1 RID: 5329
	public class ChallengeMapMoneyControl : MonoBehaviour
	{
		// Token: 0x0600CE8E RID: 52878 RVA: 0x0032E8FF File Offset: 0x0032CCFF
		private void Awake()
		{
		}

		// Token: 0x0600CE8F RID: 52879 RVA: 0x0032E901 File Offset: 0x0032CD01
		private void OnDestroy()
		{
		}

		// Token: 0x0600CE90 RID: 52880 RVA: 0x0032E903 File Offset: 0x0032CD03
		private void OnEnable()
		{
			this.BindEvents();
		}

		// Token: 0x0600CE91 RID: 52881 RVA: 0x0032E90B File Offset: 0x0032CD0B
		private void OnDisable()
		{
			this.UnBindEvents();
		}

		// Token: 0x0600CE92 RID: 52882 RVA: 0x0032E913 File Offset: 0x0032CD13
		private void BindEvents()
		{
		}

		// Token: 0x0600CE93 RID: 52883 RVA: 0x0032E915 File Offset: 0x0032CD15
		private void UnBindEvents()
		{
		}

		// Token: 0x0600CE94 RID: 52884 RVA: 0x0032E917 File Offset: 0x0032CD17
		public void Init(DungeonModelTable.eType modelTableType)
		{
			this.ResetCostMoneyItemList();
			this.UpdateMapMoneyItemList(modelTableType);
		}

		// Token: 0x0600CE95 RID: 52885 RVA: 0x0032E928 File Offset: 0x0032CD28
		private void ResetCostMoneyItemList()
		{
			if (this.spriteConsumeItem != null)
			{
				CommonUtility.UpdateGameObjectVisible(this.spriteConsumeItem.gameObject, false);
			}
			if (this.costItemList == null || this.costItemList.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < this.costItemList.Count; i++)
			{
				ComCommonConsume comCommonConsume = this.costItemList[i];
				if (!(comCommonConsume == null))
				{
					CommonUtility.UpdateGameObjectVisible(comCommonConsume.gameObject, false);
				}
			}
		}

		// Token: 0x0600CE96 RID: 52886 RVA: 0x0032E9BC File Offset: 0x0032CDBC
		private void UpdateMapMoneyItemList(DungeonModelTable.eType modelTableType)
		{
			bool dungeonModelShowSpriteFlag = ChallengeUtility.GetDungeonModelShowSpriteFlag(modelTableType);
			if (this.spriteConsumeItem != null)
			{
				CommonUtility.UpdateGameObjectVisible(this.spriteConsumeItem.gameObject, dungeonModelShowSpriteFlag);
				if (dungeonModelShowSpriteFlag)
				{
					this.spriteConsumeItem.SetData(ComCommonConsume.eType.Count, ComCommonConsume.eCountType.Fatigue, 0);
				}
			}
			List<int> dungeonModelCostDataList = ChallengeUtility.GetDungeonModelCostDataList(modelTableType);
			if (dungeonModelCostDataList == null || dungeonModelCostDataList.Count <= 0)
			{
				return;
			}
			if (this.costItemList == null || this.costItemList.Count <= 0)
			{
				return;
			}
			int count = dungeonModelCostDataList.Count;
			int count2 = this.costItemList.Count;
			int num = 0;
			while (num < count && num < count2)
			{
				int num2 = dungeonModelCostDataList[num];
				ComCommonConsume comCommonConsume = this.costItemList[num];
				if (num2 > 0 && comCommonConsume != null)
				{
					comCommonConsume.SetData(ComCommonConsume.eType.Item, ComCommonConsume.eCountType.Fatigue, num2);
					CommonUtility.UpdateGameObjectVisible(comCommonConsume.gameObject, true);
				}
				num++;
			}
		}

		// Token: 0x040078AB RID: 30891
		[Space(10f)]
		[Header("NormalCostItemList")]
		[Space(10f)]
		[SerializeField]
		private List<ComCommonConsume> costItemList = new List<ComCommonConsume>();

		// Token: 0x040078AC RID: 30892
		[Space(10f)]
		[Header("SpriteCostItem")]
		[Space(10f)]
		[SerializeField]
		private ComCommonConsume spriteConsumeItem;
	}
}
