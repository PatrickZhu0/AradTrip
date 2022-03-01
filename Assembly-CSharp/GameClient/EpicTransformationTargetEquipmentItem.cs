using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B0B RID: 6923
	public class EpicTransformationTargetEquipmentItem : MonoBehaviour
	{
		// Token: 0x17001D88 RID: 7560
		// (get) Token: 0x06010FEF RID: 69615 RVA: 0x004DC825 File Offset: 0x004DAC25
		public ItemData EquipmentItemData
		{
			get
			{
				return this.equipItemData;
			}
		}

		// Token: 0x06010FF0 RID: 69616 RVA: 0x004DC830 File Offset: 0x004DAC30
		public void OnItemVisiable(ItemData itemData)
		{
			if (itemData == null)
			{
				return;
			}
			this.equipItemData = itemData;
			if (this.equipmentComItem == null)
			{
				this.equipmentComItem = ComItemManager.Create(this.mItemParent);
			}
			ComItem comItem = this.equipmentComItem;
			ItemData item = this.equipItemData;
			if (EpicTransformationTargetEquipmentItem.<>f__mg$cache0 == null)
			{
				EpicTransformationTargetEquipmentItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
			}
			comItem.Setup(item, EpicTransformationTargetEquipmentItem.<>f__mg$cache0);
			if (this.mItemName != null)
			{
				this.mItemName.text = this.equipItemData.GetColorName(string.Empty, false);
			}
		}

		// Token: 0x06010FF1 RID: 69617 RVA: 0x004DC8C8 File Offset: 0x004DACC8
		private void OnDestroy()
		{
			this.equipmentComItem = null;
			this.equipItemData = null;
		}

		// Token: 0x0400AEE2 RID: 44770
		[SerializeField]
		private GameObject mItemParent;

		// Token: 0x0400AEE3 RID: 44771
		[SerializeField]
		private Text mItemName;

		// Token: 0x0400AEE4 RID: 44772
		private ItemData equipItemData;

		// Token: 0x0400AEE5 RID: 44773
		private ComItem equipmentComItem;

		// Token: 0x0400AEE6 RID: 44774
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
