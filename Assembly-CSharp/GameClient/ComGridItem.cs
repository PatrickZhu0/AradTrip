using System;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B24 RID: 6948
	internal class ComGridItem : MonoBehaviour
	{
		// Token: 0x17001D96 RID: 7574
		// (get) Token: 0x06011110 RID: 69904 RVA: 0x004E4517 File Offset: 0x004E2917
		public ItemData Value
		{
			get
			{
				return (!(null == this.comItem)) ? this.comItem.ItemData : null;
			}
		}

		// Token: 0x06011111 RID: 69905 RVA: 0x004E453C File Offset: 0x004E293C
		public void OnItemVisible(ItemData itemData)
		{
			if (null == this.comItem)
			{
				this.comItem = ComItemManager.Create(this.goItemParent);
			}
			if (null != this.comItem)
			{
				this.comItem.Setup(itemData, null);
			}
			if (null == this.comSelect)
			{
				this.comSelect = base.GetComponent<ComUIListElementSelectionScript>();
			}
			if (null != this.comSelect)
			{
				this.comSelect.enabled = (null != itemData);
			}
			if (null != this.itemName)
			{
				if (itemData != null)
				{
					this.itemName.text = itemData.GetColorName(string.Empty, false);
				}
				else
				{
					this.itemName.text = string.Empty;
				}
			}
			this.goBack.CustomActive(null == itemData);
			this.comItem.CustomActive(null != itemData);
		}

		// Token: 0x06011112 RID: 69906 RVA: 0x004E462D File Offset: 0x004E2A2D
		private void _OnItemClicked(GameObject go, ItemData item)
		{
			if (item != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
			}
		}

		// Token: 0x06011113 RID: 69907 RVA: 0x004E4648 File Offset: 0x004E2A48
		public void OnItemChangeDisplay(bool bSelected)
		{
			if (null != this.comItem)
			{
				this.comItem.SetEnable(!bSelected);
			}
			this.goCheck.CustomActive(bSelected);
			if (null != this.comState)
			{
				this.comState.Key = ((!bSelected) ? ComGridItem.ms_disable : ComGridItem.ms_enable);
			}
		}

		// Token: 0x0400AFD3 RID: 45011
		public GameObject goItemParent;

		// Token: 0x0400AFD4 RID: 45012
		public GameObject goBack;

		// Token: 0x0400AFD5 RID: 45013
		public GameObject goCheck;

		// Token: 0x0400AFD6 RID: 45014
		public StateController comState;

		// Token: 0x0400AFD7 RID: 45015
		public Text itemName;

		// Token: 0x0400AFD8 RID: 45016
		private static string ms_enable = "Enable";

		// Token: 0x0400AFD9 RID: 45017
		private static string ms_disable = "Disable";

		// Token: 0x0400AFDA RID: 45018
		private ComItem comItem;

		// Token: 0x0400AFDB RID: 45019
		private ComUIListElementSelectionScript comSelect;
	}
}
