using System;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001770 RID: 6000
	public class MallPackagePreviewFrame : ClientFrame
	{
		// Token: 0x0600ED06 RID: 60678 RVA: 0x003F7818 File Offset: 0x003F5C18
		protected override void _bindExUI()
		{
			this.mScroll = this.mBind.GetCom<ScrollRect>("scroll");
			this.mBtnBuy = this.mBind.GetCom<Button>("btnBuy");
			this.mBtnBuy.onClick.AddListener(new UnityAction(this._onBtnBuyButtonClick));
			this.mBtnClose = this.mBind.GetCom<Button>("btnClose");
			this.mBtnClose.onClick.AddListener(new UnityAction(this._onBtnCloseButtonClick));
			this.mBtnClose2 = this.mBind.GetCom<Button>("btnClose2");
			this.mBtnClose2.onClick.AddListener(new UnityAction(this._onBtnClose2ButtonClick));
			this.mTxtPrice = this.mBind.GetCom<Text>("txtPrice");
			this.mComGray = this.mBind.GetCom<UIGray>("comGray");
		}

		// Token: 0x0600ED07 RID: 60679 RVA: 0x003F7900 File Offset: 0x003F5D00
		protected override void _unbindExUI()
		{
			this.mScroll = null;
			this.mBtnBuy.onClick.RemoveListener(new UnityAction(this._onBtnBuyButtonClick));
			this.mBtnBuy = null;
			this.mBtnClose.onClick.RemoveListener(new UnityAction(this._onBtnCloseButtonClick));
			this.mBtnClose = null;
			this.mComGray = null;
		}

		// Token: 0x0600ED08 RID: 60680 RVA: 0x003F7964 File Offset: 0x003F5D64
		private void _onBtnBuyButtonClick()
		{
			if (this.userData != null)
			{
				MallItemInfo mallItemInfo = this.userData as MallItemInfo;
				if (this.ilImitNum > 0)
				{
					Singleton<PayManager>.GetInstance().lastPayIsMonthCard = false;
					uint price = (mallItemInfo.discountprice <= 0U) ? mallItemInfo.price : mallItemInfo.discountprice;
					Singleton<PayManager>.GetInstance().DoPay((int)mallItemInfo.id, (int)price, ChargeMallType.Packet);
				}
				this.frameMgr.CloseFrame<MallPackagePreviewFrame>(this, false);
			}
		}

		// Token: 0x0600ED09 RID: 60681 RVA: 0x003F79DC File Offset: 0x003F5DDC
		private void _onBtnCloseButtonClick()
		{
			this.frameMgr.CloseFrame<MallPackagePreviewFrame>(this, false);
		}

		// Token: 0x0600ED0A RID: 60682 RVA: 0x003F79EB File Offset: 0x003F5DEB
		private void _onBtnClose2ButtonClick()
		{
			this.frameMgr.CloseFrame<MallPackagePreviewFrame>(this, false);
		}

		// Token: 0x0600ED0B RID: 60683 RVA: 0x003F79FA File Offset: 0x003F5DFA
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Mall/MallPackgePreviewFrame";
		}

		// Token: 0x0600ED0C RID: 60684 RVA: 0x003F7A04 File Offset: 0x003F5E04
		protected override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				MallItemInfo mallItemInfo = this.userData as MallItemInfo;
				for (int i = 0; i < mallItemInfo.giftItems.Length; i++)
				{
					int id = (int)mallItemInfo.giftItems[i].id;
					int num = (int)mallItemInfo.giftItems[i].num;
					int strength = (int)mallItemInfo.giftItems[i].strength;
					GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/Mall/MallShowItemEle2", true, 0U);
					ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
					Text com = component.GetCom<Text>("txtName");
					RectTransform com2 = component.GetCom<RectTransform>("objPos");
					Text com3 = component.GetCom<Text>("txtNum");
					Image com4 = component.GetCom<Image>("sprBG");
					this.mTxtPrice.text = string.Format("购买", new object[0]);
					this.ilImitNum = 0;
					if (mallItemInfo.limitnum >= 0 && mallItemInfo.limitnum < 65535)
					{
						this.ilImitNum = (int)mallItemInfo.limitnum;
					}
					else if (mallItemInfo.limittotalnum >= 0 && mallItemInfo.limittotalnum < 65535)
					{
						this.ilImitNum = (int)mallItemInfo.limittotalnum;
					}
					else if (mallItemInfo.limitnum > 0 && mallItemInfo.limittotalnum > 0)
					{
						this.ilImitNum = -1;
					}
					int num2 = (int)(mallItemInfo.endtime - DataManager<TimeManager>.GetInstance().GetServerTime());
					if (mallItemInfo.endtime - mallItemInfo.starttime <= 0U || num2 <= 0 || this.ilImitNum <= 0)
					{
						this.mComGray.enabled = true;
						this.mBtnBuy.interactable = false;
					}
					ComItem comItem = Utility.AddItemIcon(this, com2.gameObject, (uint)id, 1, strength);
					com.text = comItem.ItemData.Name;
					com3.text = string.Format("x {0}", num);
					Utility.AttachTo(gameObject, this.mScroll.content.gameObject, false);
				}
			}
		}

		// Token: 0x0400906E RID: 36974
		private const string path = "UIFlatten/Prefabs/Mall/MallPackgePreviewFrame";

		// Token: 0x0400906F RID: 36975
		private const string itemPath = "UIFlatten/Prefabs/Mall/MallShowItemEle2";

		// Token: 0x04009070 RID: 36976
		private int ilImitNum;

		// Token: 0x04009071 RID: 36977
		private ScrollRect mScroll;

		// Token: 0x04009072 RID: 36978
		private Button mBtnBuy;

		// Token: 0x04009073 RID: 36979
		private Button mBtnClose;

		// Token: 0x04009074 RID: 36980
		private Button mBtnClose2;

		// Token: 0x04009075 RID: 36981
		private Text mTxtPrice;

		// Token: 0x04009076 RID: 36982
		private UIGray mComGray;
	}
}
