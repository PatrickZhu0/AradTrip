using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000F84 RID: 3972
	public class GiftBagItem : MonoBehaviour
	{
		// Token: 0x06009984 RID: 39300 RVA: 0x001D8CFE File Offset: 0x001D70FE
		private void Start()
		{
			this.IsSelect = false;
			this.Update();
		}

		// Token: 0x06009985 RID: 39301 RVA: 0x001D8D0D File Offset: 0x001D710D
		public void RegistClickCallBack()
		{
			if (this.btnSelect != null)
			{
				this.btnSelect.onClick.RemoveAllListeners();
				this.btnSelect.onClick.AddListener(new UnityAction(this.OnClickSelect));
			}
		}

		// Token: 0x06009986 RID: 39302 RVA: 0x001D8D4C File Offset: 0x001D714C
		public void CancleClickCallBack()
		{
			if (this.btnSelect != null)
			{
				this.btnSelect.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x06009987 RID: 39303 RVA: 0x001D8D70 File Offset: 0x001D7170
		private void Update()
		{
			if (this.imgFrame != null && this.imgCheckMark != null)
			{
				this.imgFrame.CustomActive(this.IsSelect);
				this.imgCheckMark.CustomActive(this.IsSelect);
			}
		}

		// Token: 0x06009988 RID: 39304 RVA: 0x001D8DC1 File Offset: 0x001D71C1
		private void OnClickSelect()
		{
			if (this.m_callback != null)
			{
				this.m_callback(base.gameObject, this.m_item);
			}
		}

		// Token: 0x17001928 RID: 6440
		// (get) Token: 0x06009989 RID: 39305 RVA: 0x001D8DE5 File Offset: 0x001D71E5
		// (set) Token: 0x0600998A RID: 39306 RVA: 0x001D8DED File Offset: 0x001D71ED
		public bool IsSelect { get; set; }

		// Token: 0x17001929 RID: 6441
		// (get) Token: 0x0600998B RID: 39307 RVA: 0x001D8DF6 File Offset: 0x001D71F6
		// (set) Token: 0x0600998C RID: 39308 RVA: 0x001D8DFE File Offset: 0x001D71FE
		public int Index { get; set; }

		// Token: 0x0600998D RID: 39309 RVA: 0x001D8E07 File Offset: 0x001D7207
		private void OnItemClick(GameObject gameObject, ItemData itemData)
		{
			DataManager<ItemTipManager>.GetInstance().CloseAll();
			DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
		}

		// Token: 0x0600998E RID: 39310 RVA: 0x001D8E24 File Offset: 0x001D7224
		public void Setup(int iIndex, ItemData itemData, ComItem.OnItemClicked callBack)
		{
			if (this.btnSelect != null)
			{
				this.btnSelect.onClick.RemoveAllListeners();
				this.btnSelect.onClick.AddListener(new UnityAction(this.OnClickSelect));
			}
			this.Index = iIndex;
			this.m_item = itemData;
			this.m_callback = callBack;
			ComItem component = this.item.GetComponent<ComItem>();
			if (component != null)
			{
				component.Setup(itemData, new ComItem.OnItemClicked(this.OnItemClick));
			}
			if (this.txtItemName != null)
			{
				this.txtItemName.text = itemData.GetColorName(string.Empty, false);
			}
			if (this.imgOwn != null)
			{
				if (itemData.Type == ItemTable.eType.EQUIP && DataManager<ItemDataManager>.GetInstance().GetItemByTableID(itemData.TableID, true, true) != null)
				{
					this.imgOwn.CustomActive(true);
				}
				else
				{
					this.imgOwn.CustomActive(false);
				}
			}
		}

		// Token: 0x04004F13 RID: 20243
		[SerializeField]
		private Image imgFrame;

		// Token: 0x04004F14 RID: 20244
		[SerializeField]
		private Image imgCheckMark;

		// Token: 0x04004F15 RID: 20245
		[SerializeField]
		private Button btnSelect;

		// Token: 0x04004F16 RID: 20246
		[SerializeField]
		private GameObject item;

		// Token: 0x04004F17 RID: 20247
		[SerializeField]
		private Image imgOwn;

		// Token: 0x04004F18 RID: 20248
		[SerializeField]
		private Text txtItemName;

		// Token: 0x04004F19 RID: 20249
		private ItemData m_item;

		// Token: 0x04004F1A RID: 20250
		private ComItem.OnItemClicked m_callback;
	}
}
