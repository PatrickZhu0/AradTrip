using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000F85 RID: 3973
	public class GiftBagItemEx : MonoBehaviour
	{
		// Token: 0x06009990 RID: 39312 RVA: 0x001D8F31 File Offset: 0x001D7331
		private void Start()
		{
			this.IsSelect = false;
			this.Update();
		}

		// Token: 0x06009991 RID: 39313 RVA: 0x001D8F40 File Offset: 0x001D7340
		public void RegistClickCallBack()
		{
			if (this.btnSelect != null)
			{
				this.btnSelect.onClick.RemoveAllListeners();
				this.btnSelect.onClick.AddListener(new UnityAction(this.OnClickSelect));
			}
		}

		// Token: 0x06009992 RID: 39314 RVA: 0x001D8F7F File Offset: 0x001D737F
		public void CancleClickCallBack()
		{
			if (this.btnSelect != null)
			{
				this.btnSelect.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x06009993 RID: 39315 RVA: 0x001D8FA4 File Offset: 0x001D73A4
		private void Update()
		{
			if (this.imgFrame != null && this.imgCheckMark != null && this.imgMask != null)
			{
				this.imgFrame.CustomActive(this.IsSelect);
				this.imgCheckMark.CustomActive(this.IsSelect);
				this.imgMask.CustomActive(this.IsSelect);
			}
		}

		// Token: 0x06009994 RID: 39316 RVA: 0x001D9017 File Offset: 0x001D7417
		private void OnClickSelect()
		{
			if (this.m_callback != null)
			{
				this.m_callback(base.gameObject, this.m_item);
			}
		}

		// Token: 0x1700192A RID: 6442
		// (get) Token: 0x06009995 RID: 39317 RVA: 0x001D903B File Offset: 0x001D743B
		// (set) Token: 0x06009996 RID: 39318 RVA: 0x001D9043 File Offset: 0x001D7443
		public bool IsSelect { get; set; }

		// Token: 0x1700192B RID: 6443
		// (get) Token: 0x06009997 RID: 39319 RVA: 0x001D904C File Offset: 0x001D744C
		// (set) Token: 0x06009998 RID: 39320 RVA: 0x001D9054 File Offset: 0x001D7454
		public int Index { get; set; }

		// Token: 0x06009999 RID: 39321 RVA: 0x001D905D File Offset: 0x001D745D
		private void OnItemClick(GameObject gameObject, ItemData itemData)
		{
			DataManager<ItemTipManager>.GetInstance().CloseAll();
			DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
		}

		// Token: 0x0600999A RID: 39322 RVA: 0x001D907C File Offset: 0x001D747C
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
			if (this.txtItemDesc != null)
			{
				this.txtItemDesc.text = itemData.GetDescription();
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

		// Token: 0x04004F1D RID: 20253
		[SerializeField]
		private Image imgFrame;

		// Token: 0x04004F1E RID: 20254
		[SerializeField]
		private Image imgCheckMark;

		// Token: 0x04004F1F RID: 20255
		[SerializeField]
		private Button btnSelect;

		// Token: 0x04004F20 RID: 20256
		[SerializeField]
		private GameObject item;

		// Token: 0x04004F21 RID: 20257
		[SerializeField]
		private Image imgOwn;

		// Token: 0x04004F22 RID: 20258
		[SerializeField]
		private Text txtItemName;

		// Token: 0x04004F23 RID: 20259
		[SerializeField]
		private Text txtItemDesc;

		// Token: 0x04004F24 RID: 20260
		[SerializeField]
		private Image imgMask;

		// Token: 0x04004F25 RID: 20261
		private ItemData m_item;

		// Token: 0x04004F26 RID: 20262
		private ComItem.OnItemClicked m_callback;
	}
}
