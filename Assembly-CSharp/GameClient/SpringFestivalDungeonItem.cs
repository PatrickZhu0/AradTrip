using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200190C RID: 6412
	public class SpringFestivalDungeonItem : MonoBehaviour
	{
		// Token: 0x0600F9B3 RID: 63923 RVA: 0x00444568 File Offset: 0x00442968
		public void Init(int id, Vector2 size, int i, ComItem.OnItemClicked callback)
		{
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(id, 100, 0);
			ComItem comItem = ComItemManager.Create(this.mItemRoot);
			if (itemData != null && comItem != null)
			{
				comItem.GetComponent<RectTransform>().sizeDelta = size;
				this.mNameTxt.SafeSetText(itemData.Name);
				ComItem comItem2 = comItem;
				ItemData item = itemData;
				if (SpringFestivalDungeonItem.<>f__mg$cache0 == null)
				{
					SpringFestivalDungeonItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
				}
				comItem2.Setup(item, SpringFestivalDungeonItem.<>f__mg$cache0);
			}
		}

		// Token: 0x04009BC7 RID: 39879
		[SerializeField]
		private GameObject mItemRoot;

		// Token: 0x04009BC8 RID: 39880
		[SerializeField]
		private Text mNameTxt;

		// Token: 0x04009BC9 RID: 39881
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
