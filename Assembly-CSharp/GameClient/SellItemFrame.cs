using System;
using ProtoTable;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020016FD RID: 5885
	internal class SellItemFrame : ClientFrame
	{
		// Token: 0x0600E723 RID: 59171 RVA: 0x003CD428 File Offset: 0x003CB828
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Package/SellItem";
		}

		// Token: 0x0600E724 RID: 59172 RVA: 0x003CD430 File Offset: 0x003CB830
		protected override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				this.m_itemData = (ItemData)this.userData;
			}
			if (this.m_itemData != null)
			{
				if (this.m_editCount != null)
				{
					this.m_editCount.text = this.m_itemData.Count.ToString();
					this.m_editCount.onValueChanged.RemoveAllListeners();
					this.m_editCount.onValueChanged.AddListener(delegate(string value)
					{
						this._OnValueChanged(value);
					});
				}
				if (this.m_totalPrice != null)
				{
					this.m_totalPrice.gameObject.SetActive(true);
					int num = this.m_itemData.Count * this.m_itemData.Price;
					this.m_totalPrice.text = num.ToString();
				}
				if (this.m_imgIcon != null)
				{
					this.m_imgIcon.gameObject.SetActive(true);
					string icon = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(this.m_itemData.PriceItemID).Icon;
					ETCImageLoader.LoadSprite(ref this.m_imgIcon, icon, true);
				}
			}
			else
			{
				if (this.m_editCount != null)
				{
					this.m_editCount.text = "0";
				}
				if (this.m_totalPrice != null)
				{
					this.m_totalPrice.gameObject.SetActive(false);
				}
				if (this.m_imgIcon != null)
				{
					this.m_imgIcon.gameObject.SetActive(false);
				}
				Logger.LogError("sell item frame -> item data is null!");
			}
		}

		// Token: 0x0600E725 RID: 59173 RVA: 0x003CD5D3 File Offset: 0x003CB9D3
		protected override void _OnCloseFrame()
		{
			this.m_itemData = null;
		}

		// Token: 0x0600E726 RID: 59174 RVA: 0x003CD5DC File Offset: 0x003CB9DC
		private void _OnValueChanged(string value)
		{
			int num = 0;
			if (!int.TryParse(value, out num))
			{
				Logger.LogErrorFormat("value = {0}", new object[]
				{
					value
				});
			}
			if (num < 0)
			{
				num = 0;
			}
			if (num > this.m_itemData.Count)
			{
				num = this.m_itemData.Count;
			}
			int num2 = num * this.m_itemData.Price;
			this.m_totalPrice.text = num2.ToString();
			this.m_editCount.text = num.ToString();
		}

		// Token: 0x0600E727 RID: 59175 RVA: 0x003CD670 File Offset: 0x003CBA70
		[UIEventHandle("Title/closeicon")]
		private void _OnClose()
		{
			this.frameMgr.CloseFrame<SellItemFrame>(this, false);
		}

		// Token: 0x0600E728 RID: 59176 RVA: 0x003CD680 File Offset: 0x003CBA80
		[UIEventHandle("NumberArea/Increase")]
		private void _OnIncreaseNumber()
		{
			int num = int.Parse(this.m_editCount.text);
			num++;
			if (num >= 1 && num <= this.m_itemData.Count)
			{
				this.m_editCount.text = num.ToString();
			}
		}

		// Token: 0x0600E729 RID: 59177 RVA: 0x003CD6D4 File Offset: 0x003CBAD4
		[UIEventHandle("NumberArea/Decrease")]
		private void _OnDecreaseNumber()
		{
			int num = int.Parse(this.m_editCount.text);
			num--;
			if (num >= 0 && num <= this.m_itemData.Count)
			{
				this.m_editCount.text = num.ToString();
			}
		}

		// Token: 0x0600E72A RID: 59178 RVA: 0x003CD726 File Offset: 0x003CBB26
		[UIEventHandle("NumberArea/MaxNum")]
		private void _OnMaxNumber()
		{
			this.m_editCount.text = this.m_itemData.Count.ToString();
		}

		// Token: 0x0600E72B RID: 59179 RVA: 0x003CD74C File Offset: 0x003CBB4C
		[UIEventHandle("Sell")]
		private void _OnSell()
		{
			if (this.m_itemData != null)
			{
				int count = int.Parse(this.m_editCount.text);
				if (count >= 1 && count <= this.m_itemData.Count)
				{
					if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(() => this.m_itemData != null && this.m_itemData.Quality >= ItemTable.eColor.PURPLE, null))
					{
						return;
					}
					if (this.m_itemData.EquipType == EEquipType.ET_REDMARK)
					{
						string msgContent = TR.Value("growth_equip_desc", "确定要出售吗");
						SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
						{
							this.SellItem(count);
						}, null, 0f, false);
					}
					else
					{
						this.SellItem(count);
					}
				}
			}
		}

		// Token: 0x0600E72C RID: 59180 RVA: 0x003CD814 File Offset: 0x003CBC14
		private void SellItem(int count)
		{
			DataManager<ItemDataManager>.GetInstance().SellItem(this.m_itemData, count);
			if (count == this.m_itemData.Count)
			{
				this.frameMgr.CloseFrame<SellItemFrame>(this, false);
				DataManager<ItemTipManager>.GetInstance().CloseAll();
			}
			else
			{
				this.frameMgr.CloseFrame<SellItemFrame>(this, false);
			}
		}

		// Token: 0x04008C21 RID: 35873
		protected ItemData m_itemData;

		// Token: 0x04008C22 RID: 35874
		[UIControl("Price/Image", null, 0)]
		private Image m_imgIcon;

		// Token: 0x04008C23 RID: 35875
		[UIControl("NumberArea/InputField", typeof(InputField), 0)]
		private InputField m_editCount;

		// Token: 0x04008C24 RID: 35876
		[UIControl("Price/Text", null, 0)]
		private Text m_totalPrice;
	}
}
