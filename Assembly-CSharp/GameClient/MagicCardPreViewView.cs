using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001B6C RID: 7020
	public class MagicCardPreViewView : MonoBehaviour
	{
		// Token: 0x0601133E RID: 70462 RVA: 0x004F2FD2 File Offset: 0x004F13D2
		public void InitView(List<ItemData> data)
		{
			this.mPreViewItemList = data;
			this.InitComUIListScript();
		}

		// Token: 0x0601133F RID: 70463 RVA: 0x004F2FE4 File Offset: 0x004F13E4
		private void InitComUIListScript()
		{
			this.mComUIListScript.Initialize();
			ComUIListScript comUIListScript = this.mComUIListScript;
			comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
			ComUIListScript comUIListScript2 = this.mComUIListScript;
			comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			this.mComUIListScript.SetElementAmount(this.mPreViewItemList.Count);
		}

		// Token: 0x06011340 RID: 70464 RVA: 0x004F3060 File Offset: 0x004F1460
		private MagicCardPreViewItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<MagicCardPreViewItem>();
		}

		// Token: 0x06011341 RID: 70465 RVA: 0x004F3078 File Offset: 0x004F1478
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			MagicCardPreViewItem magicCardPreViewItem = item.gameObjectBindScript as MagicCardPreViewItem;
			if (magicCardPreViewItem != null && item.m_index >= 0 && item.m_index < this.mPreViewItemList.Count)
			{
				magicCardPreViewItem.InitItem(this.mPreViewItemList[item.m_index]);
			}
		}

		// Token: 0x06011342 RID: 70466 RVA: 0x004F30D6 File Offset: 0x004F14D6
		public void UnInitView()
		{
			this.mPreViewItemList = null;
		}

		// Token: 0x0400B192 RID: 45458
		[SerializeField]
		private ComUIListScript mComUIListScript;

		// Token: 0x0400B193 RID: 45459
		private List<ItemData> mPreViewItemList;
	}
}
