using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018F5 RID: 6389
	public class GoblinShopActivityItem : MonoBehaviour
	{
		// Token: 0x0600F91A RID: 63770 RVA: 0x0043ECD4 File Offset: 0x0043D0D4
		public void Init(int id, Vector2 size)
		{
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(id, 100, 0);
			ComItem comItem = ComItemManager.Create(this.mItemRoot);
			if (itemData != null && comItem != null)
			{
				comItem.GetComponent<RectTransform>().sizeDelta = size;
				ComItem comItem2 = comItem;
				ItemData item = itemData;
				if (GoblinShopActivityItem.<>f__mg$cache0 == null)
				{
					GoblinShopActivityItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
				}
				comItem2.Setup(item, GoblinShopActivityItem.<>f__mg$cache0);
				this.mNameTxt.SafeSetText(itemData.Name);
			}
		}

		// Token: 0x04009ABF RID: 39615
		[SerializeField]
		private GameObject mItemRoot;

		// Token: 0x04009AC0 RID: 39616
		[SerializeField]
		private Text mNameTxt;

		// Token: 0x04009AC1 RID: 39617
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
