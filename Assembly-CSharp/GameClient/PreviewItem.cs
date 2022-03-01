using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001596 RID: 5526
	public class PreviewItem : MonoBehaviour
	{
		// Token: 0x17001C25 RID: 7205
		// (get) Token: 0x0600D83D RID: 55357 RVA: 0x00360F58 File Offset: 0x0035F358
		public int Index
		{
			get
			{
				return this.iIndex;
			}
		}

		// Token: 0x0600D83E RID: 55358 RVA: 0x00360F60 File Offset: 0x0035F360
		private void OnDestroy()
		{
			this.iIndex = 0;
			this.mPreviewItemData = null;
		}

		// Token: 0x0600D83F RID: 55359 RVA: 0x00360F70 File Offset: 0x0035F370
		public void OnItemVisiable(int index, PreViewItemData previewItemData)
		{
			this.iIndex = index;
			this.mPreviewItemData = previewItemData;
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.mPreviewItemData.itemId, 100, 0);
			if (itemData != null)
			{
				ETCImageLoader.LoadSprite(ref this.mBg, itemData.GetQualityInfo().Background, true);
			}
			if (itemData.SubType == 44)
			{
				int petID = Utility.GetPetID(itemData.TableID);
				PetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>(petID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					ETCImageLoader.LoadSprite(ref this.mIcon, tableItem.IconPath, true);
				}
			}
			else
			{
				ETCImageLoader.LoadSprite(ref this.mIcon, itemData.Icon, true);
			}
			if (this.mName != null)
			{
				this.mName.text = itemData.GetColorName(string.Empty, false);
			}
		}

		// Token: 0x0600D840 RID: 55360 RVA: 0x00361045 File Offset: 0x0035F445
		public void OnItemChangeDisplay(bool bSelected)
		{
			if (this.mSelectGo != null)
			{
				this.mSelectGo.gameObject.CustomActive(bSelected);
			}
		}

		// Token: 0x04007EF1 RID: 32497
		[SerializeField]
		private Image mBg;

		// Token: 0x04007EF2 RID: 32498
		[SerializeField]
		private Image mIcon;

		// Token: 0x04007EF3 RID: 32499
		[SerializeField]
		private Text mName;

		// Token: 0x04007EF4 RID: 32500
		[SerializeField]
		private GameObject mSelectGo;

		// Token: 0x04007EF5 RID: 32501
		private int iIndex;

		// Token: 0x04007EF6 RID: 32502
		private PreViewItemData mPreviewItemData;
	}
}
