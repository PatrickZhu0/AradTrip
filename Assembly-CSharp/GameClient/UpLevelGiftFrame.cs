using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200176B RID: 5995
	internal class UpLevelGiftFrame : ClientFrame
	{
		// Token: 0x0600ECA5 RID: 60581 RVA: 0x003F2938 File Offset: 0x003F0D38
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/MainFrameTown/UpLevelGiftFrame";
		}

		// Token: 0x0600ECA6 RID: 60582 RVA: 0x003F2940 File Offset: 0x003F0D40
		protected override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				this.eGiftType = (GiftType)this.userData;
			}
			ActiveManager.ActiveData activeData = null;
			if (this.eGiftType == GiftType.UplevelGift)
			{
				activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(4000);
			}
			else if (this.eGiftType == GiftType.OnLineGift)
			{
				this.mTitle.text = TR.Value("OnlineGiftTitle");
				this.mWords.text = TR.Value("OnlineGiftWords");
				activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(5000);
			}
			if (activeData == null)
			{
				return;
			}
			if (activeData.akChildItems == null)
			{
				return;
			}
			int num = -1;
			int num2 = -1;
			Utility.CalShowUplevelGiftIndex(activeData, ref num, ref num2);
			int index = 0;
			if (num != -1)
			{
				index = num;
			}
			else if (num2 != -1)
			{
				index = num2;
			}
			if (num == -1 && num2 == -1)
			{
				this.mGiftTitle.text = "已没有可领取奖励";
			}
			else if (this.eGiftType == GiftType.UplevelGift)
			{
				if ((int)DataManager<PlayerBaseData>.GetInstance().Level >= activeData.akChildItems[index].activeItem.LevelLimit)
				{
					this.mGiftTitle.text = string.Format(TR.Value("LevelupFinishGift"), activeData.akChildItems[index].activeItem.LevelLimit);
				}
				else
				{
					this.mGiftTitle.text = string.Format(TR.Value("LevelupUnfinishGift"), activeData.akChildItems[index].activeItem.LevelLimit);
				}
			}
			else if (this.eGiftType == GiftType.OnLineGift)
			{
				int dayOnLineTime = Utility.GetDayOnLineTime();
				int num3 = int.Parse(activeData.akChildItems[index].activeItem.Param0);
				if (dayOnLineTime >= num3 * 60)
				{
					this.mGiftTitle.text = string.Format(TR.Value("OnlineFinishGift"), num3);
				}
				else
				{
					this.mGiftTitle.text = string.Format(TR.Value("OnlineUnfinishGift"), num3);
				}
			}
			this.ItemdataList = DataManager<ActiveManager>.GetInstance().GetActiveAwards(activeData.akChildItems[index].ID);
			if (!Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Welfare) || activeData.akChildItems[index].status != 2)
			{
				UIGray component = this.mBtReceive.GetComponent<UIGray>();
				component.enabled = true;
				this.mBtReceive.interactable = false;
			}
			if (this.ItemdataList != null)
			{
				for (int i = 0; i < this.GiftRoot.Length; i++)
				{
					if (i < this.ItemdataList.Count)
					{
						ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.ItemdataList[i].ID, 100, 0);
						if (itemData != null)
						{
							this.GiftRoot[i].gameObject.SetActive(true);
							itemData.Count = this.ItemdataList[i].Num;
							ComItem comItem = base.CreateComItem(this.GiftRoot[i].gameObject);
							int idx = i;
							comItem.Setup(itemData, delegate(GameObject Obj, ItemData sitem)
							{
								this.OnShowItemDetailData(idx);
							});
						}
					}
				}
			}
		}

		// Token: 0x0600ECA7 RID: 60583 RVA: 0x003F2C99 File Offset: 0x003F1099
		protected override void _OnCloseFrame()
		{
			this.ClearData();
		}

		// Token: 0x0600ECA8 RID: 60584 RVA: 0x003F2CA1 File Offset: 0x003F10A1
		private void ClearData()
		{
			this.eGiftType = GiftType.None;
			this.ItemdataList = null;
		}

		// Token: 0x0600ECA9 RID: 60585 RVA: 0x003F2CB4 File Offset: 0x003F10B4
		private void OnShowItemDetailData(int iIndex)
		{
			if (iIndex < 0 || iIndex >= this.ItemdataList.Count)
			{
				return;
			}
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.ItemdataList[iIndex].ID, 100, 0);
			if (itemData == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
		}

		// Token: 0x0600ECAA RID: 60586 RVA: 0x003F2D0C File Offset: 0x003F110C
		protected override void _bindExUI()
		{
			this.mTitle = this.mBind.GetCom<Text>("Title");
			this.mGiftTitle = this.mBind.GetCom<Text>("GiftTitle");
			this.mGiftTitleBack = this.mBind.GetCom<Image>("GiftTitleBack");
			this.mBtReceive = this.mBind.GetCom<Button>("BtReceive");
			this.mBtReceive.onClick.AddListener(new UnityAction(this._onBtReceiveButtonClick));
			this.mBtClose = this.mBind.GetCom<Button>("BtClose");
			this.mBtClose.onClick.AddListener(new UnityAction(this._onBtCloseButtonClick));
			this.mWords = this.mBind.GetCom<Text>("Words");
		}

		// Token: 0x0600ECAB RID: 60587 RVA: 0x003F2DD8 File Offset: 0x003F11D8
		protected override void _unbindExUI()
		{
			this.mTitle = null;
			this.mGiftTitle = null;
			this.mGiftTitleBack = null;
			this.mBtReceive.onClick.RemoveListener(new UnityAction(this._onBtReceiveButtonClick));
			this.mBtReceive = null;
			this.mBtClose.onClick.RemoveListener(new UnityAction(this._onBtCloseButtonClick));
			this.mBtClose = null;
			this.mWords = null;
		}

		// Token: 0x0600ECAC RID: 60588 RVA: 0x003F2E48 File Offset: 0x003F1248
		private void _onBtReceiveButtonClick()
		{
			if (this.eGiftType == GiftType.UplevelGift)
			{
				DataManager<ActiveManager>.GetInstance().OpenActiveFrame(9380, 4000);
			}
			else if (this.eGiftType == GiftType.OnLineGift)
			{
				DataManager<ActiveManager>.GetInstance().OpenActiveFrame(9380, 5000);
			}
			base.Close(false);
		}

		// Token: 0x0600ECAD RID: 60589 RVA: 0x003F2EA1 File Offset: 0x003F12A1
		private void _onBtCloseButtonClick()
		{
			base.Close(false);
		}

		// Token: 0x04008FE5 RID: 36837
		private const int iShowGiftNum = 5;

		// Token: 0x04008FE6 RID: 36838
		private GiftType eGiftType;

		// Token: 0x04008FE7 RID: 36839
		private List<AwardItemData> ItemdataList;

		// Token: 0x04008FE8 RID: 36840
		[UIControl("Back/GiftList/Panel/pos{0}", typeof(RectTransform), 1)]
		private RectTransform[] GiftRoot = new RectTransform[5];

		// Token: 0x04008FE9 RID: 36841
		[UIControl("Back/GiftList/Panel/pos{0}/Text", typeof(Text), 1)]
		private Text[] GiftText = new Text[5];

		// Token: 0x04008FEA RID: 36842
		private Text mTitle;

		// Token: 0x04008FEB RID: 36843
		private Text mGiftTitle;

		// Token: 0x04008FEC RID: 36844
		private Image mGiftTitleBack;

		// Token: 0x04008FED RID: 36845
		private Button mBtReceive;

		// Token: 0x04008FEE RID: 36846
		private Button mBtClose;

		// Token: 0x04008FEF RID: 36847
		private Text mWords;
	}
}
