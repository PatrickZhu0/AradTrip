using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B7F RID: 7039
	public class MaterialSynthesisItem : MonoBehaviour
	{
		// Token: 0x17001DA0 RID: 7584
		// (get) Token: 0x06011439 RID: 70713 RVA: 0x004FAB7F File Offset: 0x004F8F7F
		// (set) Token: 0x0601143A RID: 70714 RVA: 0x004FAB87 File Offset: 0x004F8F87
		public MaterialsSynthesisData mMaterialsSynthesisData { get; set; }

		// Token: 0x0601143B RID: 70715 RVA: 0x004FAB90 File Offset: 0x004F8F90
		public void OnItemVisiable(MaterialsSynthesisData data)
		{
			if (data == null)
			{
				return;
			}
			this.mMaterialsSynthesisData = data;
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(data.tableID, 100, 0);
			if (itemData == null)
			{
				return;
			}
			if (this.mComItem == null)
			{
				this.mComItem = ComItemManager.Create(this.mItemParent);
			}
			ComItem comItem = this.mComItem;
			ItemData item = itemData;
			if (MaterialSynthesisItem.<>f__mg$cache0 == null)
			{
				MaterialSynthesisItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
			}
			comItem.Setup(item, MaterialSynthesisItem.<>f__mg$cache0);
			Text text = this.mName;
			string colorName = itemData.GetColorName(string.Empty, false);
			this.mCheckName.text = colorName;
			text.text = colorName;
		}

		// Token: 0x0601143C RID: 70716 RVA: 0x004FAC31 File Offset: 0x004F9031
		public void OnOnItemChangeDisplayDelegate(bool bSelected)
		{
			this.mCheckMarkRoot.CustomActive(bSelected);
		}

		// Token: 0x0601143D RID: 70717 RVA: 0x004FAC3F File Offset: 0x004F903F
		private void OnDestroy()
		{
			this.mComItem = null;
			this.mMaterialsSynthesisData = null;
		}

		// Token: 0x0400B26D RID: 45677
		[SerializeField]
		private GameObject mItemParent;

		// Token: 0x0400B26E RID: 45678
		[SerializeField]
		private GameObject mCheckMarkRoot;

		// Token: 0x0400B26F RID: 45679
		[SerializeField]
		private Text mName;

		// Token: 0x0400B270 RID: 45680
		[SerializeField]
		private Text mCheckName;

		// Token: 0x0400B271 RID: 45681
		private ComItem mComItem;

		// Token: 0x0400B273 RID: 45683
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
