using System;
using System.Runtime.CompilerServices;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001AFC RID: 6908
	public class EnchantmentCardItem : MonoBehaviour
	{
		// Token: 0x17001D81 RID: 7553
		// (get) Token: 0x06010F24 RID: 69412 RVA: 0x004D6DE1 File Offset: 0x004D51E1
		public EnchantmentCardItemDataModel MEnchantmentCardItemDataModel
		{
			get
			{
				return this.mEnchantmentCardItemDataModel;
			}
		}

		// Token: 0x06010F25 RID: 69413 RVA: 0x004D6DE9 File Offset: 0x004D51E9
		public void OnItemVisiable(EnchantmentCardItemDataModel model, OnEnchantmentCardItemClick onEnchantmentCardItemClick)
		{
			if (model == null || onEnchantmentCardItemClick == null)
			{
				return;
			}
			this.mEnchantmentCardItemDataModel = model;
			this.mOnEnchantmentCardItemClick = onEnchantmentCardItemClick;
			this.InitEnchantmentCardItem();
		}

		// Token: 0x06010F26 RID: 69414 RVA: 0x004D6E0C File Offset: 0x004D520C
		private void InitEnchantmentCardItem()
		{
			if (this.mEnchantmentCardItemDataModel == null)
			{
				return;
			}
			if (this.mEnchantmentCardName != null && this.mCheckEnchantmentCardName != null)
			{
				Text text = this.mEnchantmentCardName;
				string colorName = this.mEnchantmentCardItemDataModel.mEnchantmentCardItemData.GetColorName(string.Empty, false);
				this.mCheckEnchantmentCardName.text = colorName;
				text.text = colorName;
			}
			if (this.mItemParent != null)
			{
				if (this.mEnchantmentCardItem == null)
				{
					this.mEnchantmentCardItem = ComItemManager.Create(this.mItemParent);
				}
				ComItem comItem = this.mEnchantmentCardItem;
				ItemData mEnchantmentCardItemData = this.mEnchantmentCardItemDataModel.mEnchantmentCardItemData;
				if (EnchantmentCardItem.<>f__mg$cache0 == null)
				{
					EnchantmentCardItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
				}
				comItem.Setup(mEnchantmentCardItemData, EnchantmentCardItem.<>f__mg$cache0);
			}
			if (this.mEnchantmentCardItemDataModel.mUpgradePrecType == UpgradePrecType.Mounted)
			{
				if (this.mStateControl != null)
				{
					this.mStateControl.Key = this.sMounted;
				}
				if (this.mEquipItemParent != null)
				{
					if (this.mEquipItem == null)
					{
						this.mEquipItem = ComItemManager.Create(this.mEquipItemParent);
					}
					ComItem comItem2 = this.mEquipItem;
					ItemData mEquipItemData = this.mEnchantmentCardItemDataModel.mEquipItemData;
					if (EnchantmentCardItem.<>f__mg$cache1 == null)
					{
						EnchantmentCardItem.<>f__mg$cache1 = new ComItem.OnItemClicked(Utility.OnItemClicked);
					}
					comItem2.Setup(mEquipItemData, EnchantmentCardItem.<>f__mg$cache1);
				}
			}
			else if (this.mStateControl != null)
			{
				this.mStateControl.Key = this.sUnMounted;
			}
			if (this.mEnchantmentCardAttr != null && this.mEnchantmentCardItemDataModel.mEnchantmentCardItemData.mPrecEnchantmentCard != null)
			{
				this.mEnchantmentCardAttr.text = DataManager<EnchantmentsCardManager>.GetInstance().GetEnchantmentCardAttributesDesc(this.mEnchantmentCardItemDataModel.mEnchantmentCardItemData.mPrecEnchantmentCard.iEnchantmentCardID, this.mEnchantmentCardItemDataModel.mEnchantmentCardItemData.mPrecEnchantmentCard.iEnchantmentCardLevel, false);
			}
		}

		// Token: 0x06010F27 RID: 69415 RVA: 0x004D7002 File Offset: 0x004D5402
		public void OnSelectEnchantmentCardItemClick()
		{
			if (this.mOnEnchantmentCardItemClick != null)
			{
				this.mOnEnchantmentCardItemClick(this.mEnchantmentCardItemDataModel);
			}
		}

		// Token: 0x06010F28 RID: 69416 RVA: 0x004D7020 File Offset: 0x004D5420
		public void OnEnchantmentCardItemChageDisplay(bool bSelected)
		{
			if (this.mCheckMarkRoot != null)
			{
				this.mCheckMarkRoot.CustomActive(bSelected);
			}
		}

		// Token: 0x06010F29 RID: 69417 RVA: 0x004D703F File Offset: 0x004D543F
		private void OnDestroy()
		{
			this.mEnchantmentCardItemDataModel = null;
			this.mOnEnchantmentCardItemClick = null;
		}

		// Token: 0x0400AE2B RID: 44587
		[SerializeField]
		private Text mEnchantmentCardName;

		// Token: 0x0400AE2C RID: 44588
		[SerializeField]
		private Text mCheckEnchantmentCardName;

		// Token: 0x0400AE2D RID: 44589
		[SerializeField]
		private GameObject mItemParent;

		// Token: 0x0400AE2E RID: 44590
		[SerializeField]
		private GameObject mEquipItemParent;

		// Token: 0x0400AE2F RID: 44591
		[SerializeField]
		private GameObject mCheckMarkRoot;

		// Token: 0x0400AE30 RID: 44592
		[SerializeField]
		private StateController mStateControl;

		// Token: 0x0400AE31 RID: 44593
		[SerializeField]
		private Text mEnchantmentCardAttr;

		// Token: 0x0400AE32 RID: 44594
		[SerializeField]
		private string sMounted = "Mounted";

		// Token: 0x0400AE33 RID: 44595
		[SerializeField]
		private string sUnMounted = "UnMounted";

		// Token: 0x0400AE34 RID: 44596
		private EnchantmentCardItemDataModel mEnchantmentCardItemDataModel;

		// Token: 0x0400AE35 RID: 44597
		private OnEnchantmentCardItemClick mOnEnchantmentCardItemClick;

		// Token: 0x0400AE36 RID: 44598
		private ComItem mEnchantmentCardItem;

		// Token: 0x0400AE37 RID: 44599
		private ComItem mEquipItem;

		// Token: 0x0400AE38 RID: 44600
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;

		// Token: 0x0400AE39 RID: 44601
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache1;
	}
}
