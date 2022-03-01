using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B70 RID: 7024
	public class MergeCardItem : MonoBehaviour
	{
		// Token: 0x0601136B RID: 70507 RVA: 0x004F40CB File Offset: 0x004F24CB
		private void OnDestroy()
		{
			this.mOnEmptyClick = null;
			this.mComItem = null;
		}

		// Token: 0x0601136C RID: 70508 RVA: 0x004F40DB File Offset: 0x004F24DB
		public void InitMergeCardItem(OnEmptyClick onEmptyClick)
		{
			this.mOnEmptyClick = onEmptyClick;
			if (this.mComItem == null)
			{
				this.mComItem = ComItemManager.Create(this.mItemParent);
			}
			this.mComItem.Setup(null, null);
		}

		// Token: 0x0601136D RID: 70509 RVA: 0x004F4114 File Offset: 0x004F2514
		public void UpdateMergeCardItem(ItemData itemData)
		{
			if (itemData == null)
			{
				return;
			}
			ItemData itemData2 = ItemDataManager.CreateItemDataFromTable(itemData.TableID, 100, 0);
			if (itemData2 == null)
			{
				return;
			}
			itemData2.mPrecEnchantmentCard.iEnchantmentCardLevel = itemData.mPrecEnchantmentCard.iEnchantmentCardLevel;
			this.mCardRoot.CustomActive(true);
			if (this.mComItem != null)
			{
				ComItem comItem = this.mComItem;
				ItemData item = itemData2;
				if (MergeCardItem.<>f__mg$cache0 == null)
				{
					MergeCardItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
				}
				comItem.Setup(item, MergeCardItem.<>f__mg$cache0);
			}
			if (this.mCardName != null)
			{
				this.mCardName.text = itemData2.GetColorName(string.Empty, false);
			}
			if (this.mCardAttr != null)
			{
				this.mCardAttr.text = DataManager<EnchantmentsCardManager>.GetInstance().GetEnchantmentCardAttributesDesc(itemData2.TableID, itemData2.mPrecEnchantmentCard.iEnchantmentCardLevel, false);
			}
			if (this.mCardLevel != null)
			{
				if (itemData2.mPrecEnchantmentCard.iEnchantmentCardLevel > 0)
				{
					this.mCardLevel.text = string.Format("+{0}", itemData2.mPrecEnchantmentCard.iEnchantmentCardLevel);
				}
				else
				{
					this.mCardLevel.text = string.Empty;
				}
			}
		}

		// Token: 0x0601136E RID: 70510 RVA: 0x004F4256 File Offset: 0x004F2656
		public void OnEmptyClick()
		{
			this.Reset();
			if (this.mOnEmptyClick != null)
			{
				this.mOnEmptyClick(this.IsCardA);
			}
		}

		// Token: 0x0601136F RID: 70511 RVA: 0x004F427C File Offset: 0x004F267C
		public void Reset()
		{
			this.mCardRoot.CustomActive(false);
			if (this.mComItem != null)
			{
				this.mComItem.Setup(null, null);
			}
			if (this.mCardName != null)
			{
				this.mCardName.text = string.Empty;
			}
			if (this.mCardAttr != null)
			{
				this.mCardAttr.text = string.Empty;
			}
			if (this.mCardLevel != null)
			{
				this.mCardLevel.text = string.Empty;
			}
		}

		// Token: 0x0400B1BC RID: 45500
		[SerializeField]
		private GameObject mCardRoot;

		// Token: 0x0400B1BD RID: 45501
		[SerializeField]
		private GameObject mItemParent;

		// Token: 0x0400B1BE RID: 45502
		[SerializeField]
		private Text mCardName;

		// Token: 0x0400B1BF RID: 45503
		[SerializeField]
		private Text mCardAttr;

		// Token: 0x0400B1C0 RID: 45504
		[SerializeField]
		private Text mCardLevel;

		// Token: 0x0400B1C1 RID: 45505
		[SerializeField]
		private bool IsCardA;

		// Token: 0x0400B1C2 RID: 45506
		private OnEmptyClick mOnEmptyClick;

		// Token: 0x0400B1C3 RID: 45507
		private ComItem mComItem;

		// Token: 0x0400B1C4 RID: 45508
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
