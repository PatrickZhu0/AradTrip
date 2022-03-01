using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014E5 RID: 5349
	public class ChampionshipBigRewardPreviewItem : MonoBehaviour
	{
		// Token: 0x0600CF8C RID: 53132 RVA: 0x0033384B File Offset: 0x00331C4B
		private void Awake()
		{
		}

		// Token: 0x0600CF8D RID: 53133 RVA: 0x0033384D File Offset: 0x00331C4D
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x0600CF8E RID: 53134 RVA: 0x00333855 File Offset: 0x00331C55
		private void ClearData()
		{
			this._rewardItemId = 0;
			this._rewardItemCount = 0;
		}

		// Token: 0x0600CF8F RID: 53135 RVA: 0x00333865 File Offset: 0x00331C65
		public void InitRewardItem(int rewardItemId, int itemCount)
		{
			this._rewardItemId = rewardItemId;
			this._rewardItemCount = itemCount;
			this.InitItemView();
		}

		// Token: 0x0600CF90 RID: 53136 RVA: 0x0033387C File Offset: 0x00331C7C
		private void InitItemView()
		{
			if (this.rewardItemRoot == null)
			{
				return;
			}
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this._rewardItemId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			CommonNewItem commonNewItem = this.rewardItemRoot.GetComponentInChildren<CommonNewItem>();
			if (commonNewItem == null)
			{
				commonNewItem = CommonUtility.CreateCommonNewItem(this.rewardItemRoot);
			}
			if (commonNewItem != null)
			{
				commonNewItem.Reset();
				commonNewItem.InitItem(tableItem, this._rewardItemCount, 0);
			}
			if (this.rewardItemNameLabel != null)
			{
				string itemColorName = CommonUtility.GetItemColorName(tableItem);
				this.rewardItemNameLabel.text = itemColorName;
			}
		}

		// Token: 0x0600CF91 RID: 53137 RVA: 0x00333925 File Offset: 0x00331D25
		public void OnRecycleItem()
		{
			this._rewardItemId = 0;
		}

		// Token: 0x04007962 RID: 31074
		private int _rewardItemId;

		// Token: 0x04007963 RID: 31075
		private int _rewardItemCount;

		// Token: 0x04007964 RID: 31076
		[Space(10f)]
		[Header("Item")]
		[Space(10f)]
		[SerializeField]
		private GameObject rewardItemRoot;

		// Token: 0x04007965 RID: 31077
		[SerializeField]
		private Text rewardItemNameLabel;
	}
}
