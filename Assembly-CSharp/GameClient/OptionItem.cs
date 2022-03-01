using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B37 RID: 6967
	internal class OptionItem : CachedNormalObject<OptionItemData>
	{
		// Token: 0x060111A9 RID: 70057 RVA: 0x004E824C File Offset: 0x004E664C
		public override void OnRecycle()
		{
		}

		// Token: 0x060111AA RID: 70058 RVA: 0x004E8250 File Offset: 0x004E6650
		public override void Initialize()
		{
			this.comOption = this.goLocal.GetComponent<ComOptionItem>();
			if (this.comItem == null)
			{
				this.comItem = base.Value.frame.CreateComItem(this.comOption.itemParent);
			}
		}

		// Token: 0x060111AB RID: 70059 RVA: 0x004E82A0 File Offset: 0x004E66A0
		public override void UnInitialize()
		{
			this.comOption.Value = null;
		}

		// Token: 0x060111AC RID: 70060 RVA: 0x004E82B0 File Offset: 0x004E66B0
		public override void OnUpdate()
		{
			this.comOption.Value = base.Value;
			if (base.Value.IsMaterial)
			{
				this.comOption.stateController.Key = OptionItem.ms_keys[0];
			}
			else if (base.Value.itemData != null)
			{
				this.comOption.stateController.Key = OptionItem.ms_keys[1];
			}
			else
			{
				this.comOption.stateController.Key = OptionItem.ms_keys[2];
			}
			this.comItem.Setup(base.Value.itemData, delegate(GameObject obj, ItemData item)
			{
				if (!base.Value.IsMaterial)
				{
					DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
				}
				else
				{
					int fashionMergeMaterialID2 = DataManager<FashionMergeManager>.GetInstance().FashionMergeMaterialID;
					int ownedItemCount2 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(fashionMergeMaterialID2, true);
					int num2 = 1;
					if (ownedItemCount2 < num2)
					{
						ItemComeLink.OnLink(fashionMergeMaterialID2, 0, true, null, false, false, false, null, string.Empty);
					}
					else
					{
						DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
					}
				}
			});
			if (base.Value.itemData != null)
			{
				if (base.Value.IsMaterial)
				{
				}
			}
			if (base.Value.itemData != null)
			{
				Text itemName = this.comOption.itemName;
				string colorName = base.Value.itemData.GetColorName(string.Empty, false);
				this.comOption.itemRealName.text = colorName;
				itemName.text = colorName;
			}
			this.comOption.buttonAdd.enabled = (base.Value.itemData == null && !base.Value.IsMaterial);
			if (!base.Value.IsMaterial && base.Value.itemData != null)
			{
				this.comOption.itemRealAttribute.text = DataManager<FashionAttributeSelectManager>.GetInstance().GetAttributesDesc(base.Value.itemData.FashionAttributeID, "fashion_attribute_color", string.Empty);
			}
			if (base.Value.IsMaterial && base.Value.itemData != null)
			{
				int fashionMergeMaterialID = DataManager<FashionMergeManager>.GetInstance().FashionMergeMaterialID;
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(fashionMergeMaterialID, true);
				int num = 1;
				this.comOption.itemCount.text = string.Format("{0}/{1}", ownedItemCount, num);
				if (ownedItemCount < num)
				{
					this.comOption.itemCount.color = Color.red;
				}
				else
				{
					this.comOption.itemCount.color = Color.white;
				}
				this.comItem.SetShowNotEnoughState(ownedItemCount < num);
				this.comOption.acquiredHint.CustomActive(ownedItemCount < num);
			}
			else
			{
				this.comItem.SetShowNotEnoughState(false);
				this.comOption.acquiredHint.CustomActive(false);
			}
		}

		// Token: 0x0400B04C RID: 45132
		public ComOptionItem comOption;

		// Token: 0x0400B04D RID: 45133
		public ComItem comItem;

		// Token: 0x0400B04E RID: 45134
		private static readonly string[] ms_keys = new string[]
		{
			"material_data",
			"data_is_not_null",
			"data_is_null"
		};
	}
}
