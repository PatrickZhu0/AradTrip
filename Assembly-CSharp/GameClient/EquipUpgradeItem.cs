using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B0D RID: 6925
	public class EquipUpgradeItem : MonoBehaviour
	{
		// Token: 0x17001D89 RID: 7561
		// (get) Token: 0x06010FF9 RID: 69625 RVA: 0x004DCC41 File Offset: 0x004DB041
		// (set) Token: 0x06010FFA RID: 69626 RVA: 0x004DCC49 File Offset: 0x004DB049
		public ItemData ItemData
		{
			get
			{
				return this.itemData;
			}
			set
			{
				this.itemData = value;
			}
		}

		// Token: 0x06010FFB RID: 69627 RVA: 0x004DCC54 File Offset: 0x004DB054
		public void OnItemVisiable(ItemData item)
		{
			this.itemData = item;
			if (this.comItem == null)
			{
				this.comItem = ComItemManager.Create(this.mItemParent);
			}
			ComItem comItem = this.comItem;
			ItemData item2 = this.itemData;
			if (EquipUpgradeItem.<>f__mg$cache0 == null)
			{
				EquipUpgradeItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
			}
			comItem.Setup(item2, EquipUpgradeItem.<>f__mg$cache0);
			if (this.mName != null)
			{
				Text text = this.mName;
				string colorName = this.itemData.GetColorName(string.Empty, false);
				this.mCheckName.text = colorName;
				text.text = colorName;
			}
			bool bActive = this.itemData.PackageType == EPackageType.WearEquip;
			if (this.mEquiptedMark != null)
			{
				this.mEquiptedMark.CustomActive(bActive);
			}
			bool enabled = this.itemData.PackageType == EPackageType.WearEquip || this.itemData.IsItemInUnUsedEquipPlan;
			if (this.mGrayObj != null)
			{
				this.mGrayObj.enabled = enabled;
			}
		}

		// Token: 0x06010FFC RID: 69628 RVA: 0x004DCD5F File Offset: 0x004DB15F
		public void OnItemChangeDisplay(bool bSelected)
		{
			if (this.mGoCheckMark != null)
			{
				this.mGoCheckMark.CustomActive(bSelected);
			}
		}

		// Token: 0x06010FFD RID: 69629 RVA: 0x004DCD7E File Offset: 0x004DB17E
		private void OnDestroy()
		{
			this.comItem = null;
			this.itemData = null;
		}

		// Token: 0x0400AEF0 RID: 44784
		public static ItemData ms_selected;

		// Token: 0x0400AEF1 RID: 44785
		[SerializeField]
		private GameObject mItemParent;

		// Token: 0x0400AEF2 RID: 44786
		[SerializeField]
		private Text mName;

		// Token: 0x0400AEF3 RID: 44787
		[SerializeField]
		private Text mCheckName;

		// Token: 0x0400AEF4 RID: 44788
		[SerializeField]
		private GameObject mGoCheckMark;

		// Token: 0x0400AEF5 RID: 44789
		[SerializeField]
		private GameObject mEquiptedMark;

		// Token: 0x0400AEF6 RID: 44790
		[SerializeField]
		private UIGray mGrayObj;

		// Token: 0x0400AEF7 RID: 44791
		private ItemData itemData;

		// Token: 0x0400AEF8 RID: 44792
		private ComItem comItem;

		// Token: 0x0400AEF9 RID: 44793
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
