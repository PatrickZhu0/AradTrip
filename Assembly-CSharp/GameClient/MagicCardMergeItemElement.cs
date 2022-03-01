using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B68 RID: 7016
	public class MagicCardMergeItemElement : MonoBehaviour
	{
		// Token: 0x17001D9D RID: 7581
		// (get) Token: 0x06011306 RID: 70406 RVA: 0x004F1A35 File Offset: 0x004EFE35
		// (set) Token: 0x06011307 RID: 70407 RVA: 0x004F1A3D File Offset: 0x004EFE3D
		public ItemData MagicCardItemData
		{
			get
			{
				return this.magicCardItem;
			}
			set
			{
				this.magicCardItem = value;
			}
		}

		// Token: 0x06011308 RID: 70408 RVA: 0x004F1A48 File Offset: 0x004EFE48
		private void Awake()
		{
			if (this.mAddMagicCardBtn != null)
			{
				this.mAddMagicCardBtn.onClick.RemoveAllListeners();
				this.mAddMagicCardBtn.onClick.AddListener(new UnityAction(this.OnMagicCardItemClick));
			}
			if (this.mMagicCardItemBtn != null)
			{
				this.mMagicCardItemBtn.onClick.RemoveAllListeners();
				this.mMagicCardItemBtn.onClick.AddListener(new UnityAction(this.OnMagicCardItemClick));
			}
		}

		// Token: 0x06011309 RID: 70409 RVA: 0x004F1ACF File Offset: 0x004EFECF
		private void OnDestroy()
		{
			this.comItem = null;
			this.mOnMagicCardMergeItemClick = null;
			this.mDataMerge = null;
			this.MagicCardItemData = null;
		}

		// Token: 0x0601130A RID: 70410 RVA: 0x004F1AF0 File Offset: 0x004EFEF0
		public void OnItemVisiable(ItemData itemData, int selectMagicCardQultity, OnMagicCardMergeItemClick onMagicCardMergeItemClick, EnchantmentsFunctionData dataMerge)
		{
			if (itemData == null)
			{
				return;
			}
			this.MagicCardItemData = itemData;
			this.currentSelectMagicCardQultity = selectMagicCardQultity;
			this.mDataMerge = dataMerge;
			this.mOnMagicCardMergeItemClick = onMagicCardMergeItemClick;
			if (this.comItem == null)
			{
				this.comItem = ComItemManager.Create(this.mItemParent);
			}
			ComItem comItem = this.comItem;
			ItemData magicCardItemData = this.MagicCardItemData;
			if (MagicCardMergeItemElement.<>f__mg$cache0 == null)
			{
				MagicCardMergeItemElement.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
			}
			comItem.Setup(magicCardItemData, MagicCardMergeItemElement.<>f__mg$cache0);
			this.mItemName.text = this.MagicCardItemData.GetColorName(string.Empty, false);
			this.mItemAttrs.text = DataManager<EnchantmentsCardManager>.GetInstance().GetEnchantmentCardAttributesDesc(this.MagicCardItemData.TableID, this.MagicCardItemData.mPrecEnchantmentCard.iEnchantmentCardLevel, false);
			if (this.currentSelectMagicCardQultity != 0)
			{
				if (this.currentSelectMagicCardQultity != (int)this.MagicCardItemData.Quality)
				{
					this.mMaskRoot.CustomActive(true);
					this.SetCheckMaskRoot(false);
				}
				else
				{
					this.mMaskRoot.CustomActive(false);
					this.UpdateSelectedMagicCardNumber();
				}
			}
			else
			{
				this.mMaskRoot.CustomActive(false);
				this.SetCheckMaskRoot(false);
			}
		}

		// Token: 0x0601130B RID: 70411 RVA: 0x004F1C24 File Offset: 0x004F0024
		private void UpdateSelectedMagicCardNumber()
		{
			if (this.mDataMerge != null)
			{
				int num = 0;
				if (this.mDataMerge.leftItem != null && this.mDataMerge.leftItem.GUID == this.MagicCardItemData.GUID)
				{
					num++;
				}
				if (this.mDataMerge.rightItem != null && this.mDataMerge.rightItem.GUID == this.MagicCardItemData.GUID)
				{
					num++;
				}
				if (num > 0)
				{
					this.SetCheckMaskRoot(true);
					this.mSelectedMagicCardNum.text = string.Format("已选:{0}", num);
					this.mAddMagicCardGray.enabled = (num >= this.MagicCardItemData.Count);
				}
				else
				{
					this.SetCheckMaskRoot(false);
				}
			}
			else
			{
				this.SetCheckMaskRoot(false);
			}
		}

		// Token: 0x0601130C RID: 70412 RVA: 0x004F1D03 File Offset: 0x004F0103
		private void OnMagicCardItemClick()
		{
			if (this.mOnMagicCardMergeItemClick != null)
			{
				this.mOnMagicCardMergeItemClick(this.MagicCardItemData, this);
			}
		}

		// Token: 0x0601130D RID: 70413 RVA: 0x004F1D22 File Offset: 0x004F0122
		public void SetCheckMaskRoot(bool value)
		{
			if (this.mCheckMaskRoot != null)
			{
				this.mCheckMaskRoot.CustomActive(value);
			}
		}

		// Token: 0x0400B16F RID: 45423
		[SerializeField]
		private GameObject mItemParent;

		// Token: 0x0400B170 RID: 45424
		[SerializeField]
		private Text mItemName;

		// Token: 0x0400B171 RID: 45425
		[SerializeField]
		private Text mItemAttrs;

		// Token: 0x0400B172 RID: 45426
		[SerializeField]
		private GameObject mMaskRoot;

		// Token: 0x0400B173 RID: 45427
		[SerializeField]
		private GameObject mCheckMaskRoot;

		// Token: 0x0400B174 RID: 45428
		[SerializeField]
		private Text mSelectedMagicCardNum;

		// Token: 0x0400B175 RID: 45429
		[SerializeField]
		private Button mAddMagicCardBtn;

		// Token: 0x0400B176 RID: 45430
		[SerializeField]
		private UIGray mAddMagicCardGray;

		// Token: 0x0400B177 RID: 45431
		[SerializeField]
		private Button mMagicCardItemBtn;

		// Token: 0x0400B178 RID: 45432
		private OnMagicCardMergeItemClick mOnMagicCardMergeItemClick;

		// Token: 0x0400B179 RID: 45433
		private EnchantmentsFunctionData mDataMerge;

		// Token: 0x0400B17A RID: 45434
		private ComItem comItem;

		// Token: 0x0400B17B RID: 45435
		private ItemData magicCardItem;

		// Token: 0x0400B17C RID: 45436
		private int currentSelectMagicCardQultity;

		// Token: 0x0400B17D RID: 45437
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
