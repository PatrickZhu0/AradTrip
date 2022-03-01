using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B85 RID: 7045
	public class StrengthenGrowthEquipItem : MonoBehaviour
	{
		// Token: 0x17001DA1 RID: 7585
		// (get) Token: 0x0601147E RID: 70782 RVA: 0x004FC1B8 File Offset: 0x004FA5B8
		public ItemData EquipItemData
		{
			get
			{
				return (!(this.comItem == null)) ? this.comItem.ItemData : null;
			}
		}

		// Token: 0x0601147F RID: 70783 RVA: 0x004FC1DC File Offset: 0x004FA5DC
		public void OnItemChangeDisplay(bool bSelected)
		{
			if (this.mCheckMark != null)
			{
				this.mCheckMark.CustomActive(bSelected);
			}
		}

		// Token: 0x06011480 RID: 70784 RVA: 0x004FC1FC File Offset: 0x004FA5FC
		public void OnItemVisible(ItemData itemData, StrengthenGrowthType eStrengthenGrowthType)
		{
			if (itemData == null)
			{
				return;
			}
			if (this.comItem == null)
			{
				this.comItem = ComItemManager.Create(this.mItemParent);
			}
			this.mNameRoot.CustomActive(itemData.EquipType == EEquipType.ET_COMMON);
			this.mAttrRoot.CustomActive(itemData.EquipType != EEquipType.ET_COMMON);
			ComItem comItem = this.comItem;
			if (StrengthenGrowthEquipItem.<>f__mg$cache0 == null)
			{
				StrengthenGrowthEquipItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
			}
			comItem.Setup(itemData, StrengthenGrowthEquipItem.<>f__mg$cache0);
			Text text = this.mName;
			string colorName = itemData.GetColorName(string.Empty, false);
			this.mAttrName.text = colorName;
			text.text = colorName;
			if (this.mAttrDescs != null)
			{
				if (itemData.EquipType == EEquipType.ET_BREATH)
				{
					this.mAttrDescs.text = TR.Value("growth_breath_des");
				}
				else if (itemData.EquipType == EEquipType.ET_REDMARK)
				{
					this.mAttrDescs.text = TR.Value("growth_attr_des", DataManager<EquipGrowthDataManager>.GetInstance().GetGrowthAttrDesc(itemData.GrowthAttrType), itemData.GrowthAttrNum);
				}
			}
			this.mEquipMark.CustomActive(itemData.PackageType == EPackageType.WearEquip);
		}

		// Token: 0x06011481 RID: 70785 RVA: 0x004FC332 File Offset: 0x004FA732
		private void OnDestroy()
		{
			this.comItem = null;
		}

		// Token: 0x0400B294 RID: 45716
		[SerializeField]
		private Text mName;

		// Token: 0x0400B295 RID: 45717
		[SerializeField]
		private Text mAttrName;

		// Token: 0x0400B296 RID: 45718
		[SerializeField]
		private Text mAttrDescs;

		// Token: 0x0400B297 RID: 45719
		[SerializeField]
		private GameObject mItemParent;

		// Token: 0x0400B298 RID: 45720
		[SerializeField]
		private GameObject mEquipMark;

		// Token: 0x0400B299 RID: 45721
		[SerializeField]
		private GameObject mAttrRoot;

		// Token: 0x0400B29A RID: 45722
		[SerializeField]
		private GameObject mNameRoot;

		// Token: 0x0400B29B RID: 45723
		[SerializeField]
		private GameObject mCheckMark;

		// Token: 0x0400B29C RID: 45724
		private ComItem comItem;

		// Token: 0x0400B29D RID: 45725
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
