using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B4A RID: 6986
	public class InscriptionItemElement : MonoBehaviour
	{
		// Token: 0x17001D9A RID: 7578
		// (get) Token: 0x0601124F RID: 70223 RVA: 0x004EC6BC File Offset: 0x004EAABC
		// (set) Token: 0x06011250 RID: 70224 RVA: 0x004EC6C4 File Offset: 0x004EAAC4
		public ItemData CurrentItemData
		{
			get
			{
				return this.currentItemData;
			}
			set
			{
				this.currentItemData = value;
			}
		}

		// Token: 0x06011251 RID: 70225 RVA: 0x004EC6D0 File Offset: 0x004EAAD0
		public void OnItemVisiable(ItemData itemData)
		{
			this.currentItemData = itemData;
			if (this.mComItem == null)
			{
				this.mComItem = ComItemManager.Create(this.mItemParent);
			}
			ComItem comItem = this.mComItem;
			ItemData item = this.currentItemData;
			if (InscriptionItemElement.<>f__mg$cache0 == null)
			{
				InscriptionItemElement.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
			}
			comItem.Setup(item, InscriptionItemElement.<>f__mg$cache0);
			if (this.mInscriptionName != null)
			{
				this.mInscriptionName.text = this.currentItemData.GetColorName(string.Empty, false);
			}
			if (this.mInscriptionAttr != null)
			{
				this.mInscriptionAttr.text = DataManager<InscriptionMosaicDataManager>.GetInstance().GetInscriptionAttributesDesc(this.currentItemData.TableID, true);
			}
		}

		// Token: 0x06011252 RID: 70226 RVA: 0x004EC793 File Offset: 0x004EAB93
		public void OnItemChangeDisplay(bool isSelected)
		{
			if (this.mCheckMark != null)
			{
				this.mCheckMark.CustomActive(isSelected);
			}
		}

		// Token: 0x06011253 RID: 70227 RVA: 0x004EC7B2 File Offset: 0x004EABB2
		private void OnDestroy()
		{
			this.currentItemData = null;
			this.mComItem = null;
		}

		// Token: 0x0400B0EB RID: 45291
		[SerializeField]
		private GameObject mItemParent;

		// Token: 0x0400B0EC RID: 45292
		[SerializeField]
		private GameObject mCheckMark;

		// Token: 0x0400B0ED RID: 45293
		[SerializeField]
		private Text mInscriptionName;

		// Token: 0x0400B0EE RID: 45294
		[SerializeField]
		private Text mInscriptionAttr;

		// Token: 0x0400B0EF RID: 45295
		private ItemData currentItemData;

		// Token: 0x0400B0F0 RID: 45296
		private ComItem mComItem;

		// Token: 0x0400B0F1 RID: 45297
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
