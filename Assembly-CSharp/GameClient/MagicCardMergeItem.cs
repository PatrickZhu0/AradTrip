using System;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001743 RID: 5955
	public class MagicCardMergeItem : MonoBehaviour
	{
		// Token: 0x0600E9E7 RID: 59879 RVA: 0x003DF317 File Offset: 0x003DD717
		private void OnDestroy()
		{
			this._commonNewItem = null;
		}

		// Token: 0x0600E9E8 RID: 59880 RVA: 0x003DF320 File Offset: 0x003DD720
		public void InitItem(ItemReward itemReward)
		{
			this._itemReward = itemReward;
			if (this._itemReward == null)
			{
				return;
			}
			CommonNewItemDataModel dataModel = new CommonNewItemDataModel
			{
				ItemId = (int)this._itemReward.id,
				ItemCount = (int)this._itemReward.num,
				ItemStrengthenLevel = (int)this._itemReward.strength
			};
			if (this.itemRoot != null)
			{
				this._commonNewItem = this.itemRoot.GetComponentInChildren<CommonNewItem>();
				if (this._commonNewItem == null)
				{
					this._commonNewItem = CommonUtility.CreateCommonNewItem(this.itemRoot);
				}
			}
			if (this._commonNewItem != null)
			{
				this._commonNewItem.InitItem(dataModel);
			}
		}

		// Token: 0x04008DDA RID: 36314
		private ItemReward _itemReward;

		// Token: 0x04008DDB RID: 36315
		private CommonNewItem _commonNewItem;

		// Token: 0x04008DDC RID: 36316
		[Space(10f)]
		[Header("Content")]
		[Space(10f)]
		[SerializeField]
		private GameObject itemRoot;
	}
}
