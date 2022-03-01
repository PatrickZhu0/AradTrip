using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014C1 RID: 5313
	public class ChallengeDungeonRewardItem : MonoBehaviour
	{
		// Token: 0x0600CDFB RID: 52731 RVA: 0x0032BDCA File Offset: 0x0032A1CA
		private void Awake()
		{
		}

		// Token: 0x0600CDFC RID: 52732 RVA: 0x0032BDCC File Offset: 0x0032A1CC
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x0600CDFD RID: 52733 RVA: 0x0032BDD4 File Offset: 0x0032A1D4
		private void ClearData()
		{
			this._awardItemData = null;
			this._itemData = null;
		}

		// Token: 0x0600CDFE RID: 52734 RVA: 0x0032BDE4 File Offset: 0x0032A1E4
		public void InitItem(AwardItemData awardItemData)
		{
			this._awardItemData = awardItemData;
			if (this._awardItemData == null)
			{
				Logger.LogErrorFormat("AwardItemData is null", new object[0]);
				return;
			}
			this.InitContent();
		}

		// Token: 0x0600CDFF RID: 52735 RVA: 0x0032BE10 File Offset: 0x0032A210
		private void InitContent()
		{
			this._itemData = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(this._awardItemData.ID);
			if (this._itemData != null)
			{
				this._itemData.Count = this._awardItemData.Num;
				if (this.itemRoot != null)
				{
					ComItem comItem = this.itemRoot.GetComponentInChildren<ComItem>();
					if (comItem == null)
					{
						comItem = ComItemManager.Create(this.itemRoot);
					}
					if (comItem != null)
					{
						comItem.Setup(this._itemData, new ComItem.OnItemClicked(this.OnItemClicked));
					}
				}
				if (this.itemName != null)
				{
					this.itemName.text = this._itemData.GetColorName(string.Empty, false);
				}
			}
		}

		// Token: 0x0600CE00 RID: 52736 RVA: 0x0032BEDF File Offset: 0x0032A2DF
		private void OnItemClicked(GameObject go, ItemData itemData)
		{
			if (this._awardItemData == null)
			{
				return;
			}
			if (itemData != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
			}
		}

		// Token: 0x0600CE01 RID: 52737 RVA: 0x0032BF03 File Offset: 0x0032A303
		public void OnItemRecycle()
		{
			this.ClearData();
		}

		// Token: 0x04007843 RID: 30787
		private AwardItemData _awardItemData;

		// Token: 0x04007844 RID: 30788
		private ItemData _itemData;

		// Token: 0x04007845 RID: 30789
		[SerializeField]
		private Text itemName;

		// Token: 0x04007846 RID: 30790
		[SerializeField]
		private GameObject itemRoot;
	}
}
