using System;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001952 RID: 6482
	public class PayItem
	{
		// Token: 0x0600FBFA RID: 64506 RVA: 0x004523F0 File Offset: 0x004507F0
		public PayItem(PayItemData data, GameObject parent)
		{
			PayItem $this = this;
			this.data = data;
			this.parent = parent;
			this.root = Singleton<AssetLoader>.instance.LoadResAsGameObject(PayItem.res_payItem, true, 0U);
			if (this.root != null)
			{
				this.mBind = this.root.GetComponent<ComCommonBind>();
				this.mTxtLeftDay = this.mBind.GetCom<Text>("txtLeftDay");
				this.mImgBack = this.mBind.GetCom<Image>("imgBack");
				this.mImgIcon = this.mBind.GetCom<Image>("imgIcon");
				this.mObjMark = this.mBind.GetGameObject("objMark");
				this.mObjBonus = this.mBind.GetGameObject("objBonus");
				this.mTxtBonus = this.mBind.GetCom<Text>("txtBonus");
				this.mDescNormalRoot = this.mBind.GetGameObject("descNormalRoot");
				this.mTxtLimit = this.mBind.GetCom<Text>("txtLimit");
				this.mBgEffectRoot = this.mBind.GetGameObject("bgEffectRoot");
				this.mForeEffectRoot = this.mBind.GetGameObject("foreEffectRoot");
				this.mComGray = this.mBind.GetCom<UIGray>("comGray");
				this.mTxtGetDesc = this.mBind.GetCom<Text>("txtGetDesc");
				this.mBtnPay = this.mBind.GetCom<Button>("btnPay");
				this.mTxtPrice = this.mBind.GetCom<Text>("txtPrice");
				this.mBgEffectRoot = this.mBind.GetGameObject("bgEffectRoot");
				this.mForeEffectRoot = this.mBind.GetGameObject("foreEffectRoot");
				this.mBtnPay.onClick.AddListener(delegate()
				{
					if (data.limit <= 0)
					{
						SystemNotifyManager.SystemNotify(1121, string.Empty);
					}
					else
					{
						$this.DoPay();
					}
				});
				this.mObjMark.CustomActive(false);
				if (data.isMonthCard)
				{
					Utility.SetImageIcon(this.mImgBack.gameObject, "UI/Image/Packed/p_UI_Vip.png:UI_Vip_Item_02", false);
					this.mObjBonus.CustomActive(false);
					this.mImgIcon.gameObject.CustomActive(false);
					this.mDescNormalRoot.CustomActive(false);
				}
				Utility.AttachTo(this.root, parent, false);
			}
			this.SetData();
		}

		// Token: 0x0600FBFB RID: 64507 RVA: 0x0045264D File Offset: 0x00450A4D
		public void UpdateData(PayItemData data)
		{
			this.data = data;
			this.SetData();
		}

		// Token: 0x0600FBFC RID: 64508 RVA: 0x0045265C File Offset: 0x00450A5C
		public void SetData()
		{
			if (this.data == null)
			{
				return;
			}
			this.mTxtPrice.text = "+" + this.data.price;
			this.mTxtGetDesc.text = string.Format("*{0}", this.data.itemNum.ToString());
			if (this.data.limit <= 0)
			{
				this.mTxtLimit.text = "今日购买次数已达上限";
				this.mTxtLimit.color = Color.red;
			}
			if (this.data.HasMark())
			{
				this.mObjMark.CustomActive(true);
			}
			this.mObjBonus.CustomActive(false);
			if (!this.data.isMonthCard)
			{
				if (this.data.limit >= 255)
				{
					this.mTxtLimit.gameObject.CustomActive(false);
				}
				else if (this.data.limit > 0)
				{
					this.mTxtLimit.gameObject.CustomActive(true);
					this.mTxtLimit.text = "今日限购次数:" + this.data.limit;
				}
				if ((this.data.hasFirstBonus && this.data.firstBonusNum > 0 && !this.data.isMonthCard) || this.data.bonusNum > 0)
				{
					this.mObjBonus.CustomActive(true);
					this.mTxtBonus.text = this.data.firstBonusNum + string.Empty;
				}
				Utility.SetImageIcon(this.mImgIcon.transform.gameObject, this.data.icon, false);
			}
			else
			{
				this.mTxtPrice.gameObject.CustomActive(true);
				this.mTxtLeftDay.gameObject.CustomActive(false);
				if (this.data.remainDays > 0)
				{
					this.mTxtPrice.gameObject.CustomActive(false);
					this.mTxtLeftDay.gameObject.CustomActive(true);
					this.mTxtLeftDay.text = TR.Value("vip_month_card_remain_time", this.data.remainDays - 1);
				}
			}
		}

		// Token: 0x0600FBFD RID: 64509 RVA: 0x004528B8 File Offset: 0x00450CB8
		public void DoPay()
		{
			Singleton<PayManager>.GetInstance().lastPayIsMonthCard = this.data.isMonthCard;
			if (this.data.isMonthCard)
			{
				Singleton<PayManager>.GetInstance().lastMontchCardNeedOpenWindow = (this.data.remainDays <= 0);
			}
			Singleton<PayManager>.GetInstance().DoPay(this.data.ID, this.data.price, ChargeMallType.Charge);
		}

		// Token: 0x04009DB1 RID: 40369
		private GameObject root;

		// Token: 0x04009DB2 RID: 40370
		private GameObject parent;

		// Token: 0x04009DB3 RID: 40371
		public static string res_payItem = "UIFlatten/Prefabs/Vip/PayItem";

		// Token: 0x04009DB4 RID: 40372
		public const string dianjuanRes = "UI/Image/Icon/Icon_Duanwei/UI_Tongyong_Tubiao_Dianjuan.png:UI_Tongyong_Tubiao_Dianjuan";

		// Token: 0x04009DB5 RID: 40373
		public const int MONTH_CARD_BUY_AGAIN_NUM = 3;

		// Token: 0x04009DB6 RID: 40374
		private ComCommonBind mBind;

		// Token: 0x04009DB7 RID: 40375
		private Text mTxtLeftDay;

		// Token: 0x04009DB8 RID: 40376
		private Image mImgBack;

		// Token: 0x04009DB9 RID: 40377
		private Image mImgIcon;

		// Token: 0x04009DBA RID: 40378
		private GameObject mObjMark;

		// Token: 0x04009DBB RID: 40379
		private GameObject mObjBonus;

		// Token: 0x04009DBC RID: 40380
		private Text mTxtBonus;

		// Token: 0x04009DBD RID: 40381
		private GameObject mDescNormalRoot;

		// Token: 0x04009DBE RID: 40382
		private Text mTxtLimit;

		// Token: 0x04009DBF RID: 40383
		private GameObject mBgEffectRoot;

		// Token: 0x04009DC0 RID: 40384
		private GameObject mForeEffectRoot;

		// Token: 0x04009DC1 RID: 40385
		private UIGray mComGray;

		// Token: 0x04009DC2 RID: 40386
		private Text mTxtGetDesc;

		// Token: 0x04009DC3 RID: 40387
		private Button mBtnPay;

		// Token: 0x04009DC4 RID: 40388
		private Text mTxtPrice;

		// Token: 0x04009DC5 RID: 40389
		private Text mDescRoot;

		// Token: 0x04009DC6 RID: 40390
		private GameObject mObjDescribe;

		// Token: 0x04009DC7 RID: 40391
		public PayItemData data;
	}
}
