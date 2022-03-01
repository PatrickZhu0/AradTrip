using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B7B RID: 7035
	public class GrowthExpendItem : MonoBehaviour
	{
		// Token: 0x17001D9F RID: 7583
		// (get) Token: 0x06011422 RID: 70690 RVA: 0x004FA1FD File Offset: 0x004F85FD
		public ItemData ItemData
		{
			get
			{
				return this.itemData;
			}
		}

		// Token: 0x06011423 RID: 70691 RVA: 0x004FA208 File Offset: 0x004F8608
		public void OnItemVisiable(ItemData data)
		{
			if (data == null)
			{
				return;
			}
			this.itemData = data;
			if (this.mComItem == null)
			{
				this.mComItem = ComItemManager.Create(this.mItemParent);
			}
			ComItem comItem = this.mComItem;
			ItemData item = this.itemData;
			if (GrowthExpendItem.<>f__mg$cache0 == null)
			{
				GrowthExpendItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
			}
			comItem.Setup(item, GrowthExpendItem.<>f__mg$cache0);
			this.mName.text = this.itemData.GetColorName(string.Empty, false);
			if (this.itemData.Description.Length >= 30)
			{
				string text = this.itemData.Description.Substring(0, 30);
				text += "......";
				this.mItemDesc.text = text;
			}
			else
			{
				this.mItemDesc.text = this.itemData.Description;
			}
		}

		// Token: 0x06011424 RID: 70692 RVA: 0x004FA2ED File Offset: 0x004F86ED
		private void OnDestroy()
		{
			this.mComItem = null;
			this.itemData = null;
		}

		// Token: 0x0400B259 RID: 45657
		[SerializeField]
		private GameObject mItemParent;

		// Token: 0x0400B25A RID: 45658
		[SerializeField]
		private Text mName;

		// Token: 0x0400B25B RID: 45659
		[SerializeField]
		private Text mItemDesc;

		// Token: 0x0400B25C RID: 45660
		private ComItem mComItem;

		// Token: 0x0400B25D RID: 45661
		private ItemData itemData;

		// Token: 0x0400B25E RID: 45662
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
