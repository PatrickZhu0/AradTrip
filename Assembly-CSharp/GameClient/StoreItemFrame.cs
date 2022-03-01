using System;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200170D RID: 5901
	internal class StoreItemFrame : ClientFrame
	{
		// Token: 0x0600E7EC RID: 59372 RVA: 0x003D37EC File Offset: 0x003D1BEC
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Package/StoreItem";
		}

		// Token: 0x0600E7ED RID: 59373 RVA: 0x003D37F3 File Offset: 0x003D1BF3
		protected override void _OnOpenFrame()
		{
			this.m_editCount.onValueChanged.RemoveAllListeners();
			this.m_editCount.onValueChanged.AddListener(delegate(string value)
			{
				this._OnValueChanged(value);
			});
			this._Update();
		}

		// Token: 0x0600E7EE RID: 59374 RVA: 0x003D3827 File Offset: 0x003D1C27
		protected override void _OnCloseFrame()
		{
			this.m_editCount = null;
			this.m_comItem = null;
			this.m_itemName = null;
			this.m_itemData = null;
			this.m_count = 0;
		}

		// Token: 0x0600E7EF RID: 59375 RVA: 0x003D384C File Offset: 0x003D1C4C
		public void StoreItem(ItemData data)
		{
			if (data != null)
			{
				this.m_itemData = data;
				this.m_count = this.m_itemData.Count;
			}
			else
			{
				Logger.LogError("item data is null!");
			}
			Utility.FindGameObject(this.frame, "store", true).SetActive(true);
			Utility.FindGameObject(this.frame, "take", true).SetActive(false);
			this._Update();
		}

		// Token: 0x0600E7F0 RID: 59376 RVA: 0x003D38BC File Offset: 0x003D1CBC
		public void TakeItem(ItemData data)
		{
			if (data != null)
			{
				this.m_itemData = data;
				this.m_count = this.m_itemData.Count;
			}
			else
			{
				Logger.LogError("item data is null!");
			}
			Utility.FindGameObject(this.frame, "store", true).SetActive(false);
			Utility.FindGameObject(this.frame, "take", true).SetActive(true);
			this._Update();
		}

		// Token: 0x0600E7F1 RID: 59377 RVA: 0x003D392C File Offset: 0x003D1D2C
		protected void _Update()
		{
			if (this.m_comItem == null)
			{
				this.m_comItem = base.CreateComItem(Utility.FindGameObject(this.frame, "ItemInfo/PackageItem", true));
			}
			if (this.m_itemData == null)
			{
				this.m_editCount.text = "0";
				this.m_comItem.Setup(null, null);
				this.m_itemName.text = string.Empty;
			}
			else
			{
				this.m_editCount.text = this.m_count.ToString();
				this.m_comItem.Setup(this.m_itemData, null);
				this.m_itemName.text = this.m_itemData.GetColorName(string.Empty, false);
			}
		}

		// Token: 0x0600E7F2 RID: 59378 RVA: 0x003D39EE File Offset: 0x003D1DEE
		[UIEventHandle("Title/closeicon")]
		protected void _OnClose()
		{
			this.frameMgr.CloseFrame<StoreItemFrame>(this, false);
		}

		// Token: 0x0600E7F3 RID: 59379 RVA: 0x003D3A00 File Offset: 0x003D1E00
		[UIEventHandle("NumberArea/Increase")]
		protected void _OnIncreaseNumber()
		{
			int num = int.Parse(this.m_editCount.text);
			num++;
			if (num >= 1 && num <= this.m_itemData.Count)
			{
				this.m_editCount.text = num.ToString();
			}
		}

		// Token: 0x0600E7F4 RID: 59380 RVA: 0x003D3A54 File Offset: 0x003D1E54
		[UIEventHandle("NumberArea/Decrease")]
		protected void _OnDecreaseNumber()
		{
			int num = int.Parse(this.m_editCount.text);
			num--;
			if (num >= 1 && num <= this.m_itemData.Count)
			{
				this.m_editCount.text = num.ToString();
			}
		}

		// Token: 0x0600E7F5 RID: 59381 RVA: 0x003D3AA6 File Offset: 0x003D1EA6
		[UIEventHandle("NumberArea/MaxNum")]
		protected void _OnMaxNumber()
		{
			this.m_editCount.text = this.m_itemData.Count.ToString();
		}

		// Token: 0x0600E7F6 RID: 59382 RVA: 0x003D3ACC File Offset: 0x003D1ECC
		[UIEventHandle("store")]
		protected void _OnStore()
		{
			if (this.m_itemData != null && this.m_count >= 1 && this.m_count <= this.m_itemData.Count)
			{
				DataManager<StorageDataManager>.GetInstance().OnSendStoreItemReq(this.m_itemData, this.m_count);
				this.frameMgr.CloseFrame<StoreItemFrame>(this, false);
				DataManager<ItemTipManager>.GetInstance().CloseAll();
			}
		}

		// Token: 0x0600E7F7 RID: 59383 RVA: 0x003D3B34 File Offset: 0x003D1F34
		[UIEventHandle("take")]
		protected void _OnTake()
		{
			if (this.m_itemData != null && this.m_count >= 1 && this.m_count <= this.m_itemData.Count)
			{
				DataManager<ItemDataManager>.GetInstance().TakeItem(this.m_itemData, this.m_count);
				this.frameMgr.CloseFrame<StoreItemFrame>(this, false);
				DataManager<ItemTipManager>.GetInstance().CloseAll();
			}
		}

		// Token: 0x0600E7F8 RID: 59384 RVA: 0x003D3B9C File Offset: 0x003D1F9C
		protected void _OnValueChanged(string value)
		{
			if (this.m_itemData == null)
			{
				return;
			}
			this.m_count = 0;
			try
			{
				this.m_count = int.Parse(value);
			}
			catch (Exception ex)
			{
			}
			if (this.m_count < 1)
			{
				this.m_count = 1;
			}
			if (this.m_count > this.m_itemData.Count)
			{
				this.m_count = this.m_itemData.Count;
			}
			this._Update();
		}

		// Token: 0x04008C9D RID: 35997
		protected ItemData m_itemData;

		// Token: 0x04008C9E RID: 35998
		protected int m_count;

		// Token: 0x04008C9F RID: 35999
		protected ComItem m_comItem;

		// Token: 0x04008CA0 RID: 36000
		[UIControl("NumberArea/InputField", typeof(InputField), 0)]
		protected InputField m_editCount;

		// Token: 0x04008CA1 RID: 36001
		[UIControl("ItemInfo/ItemName", typeof(Text), 0)]
		protected Text m_itemName;
	}
}
