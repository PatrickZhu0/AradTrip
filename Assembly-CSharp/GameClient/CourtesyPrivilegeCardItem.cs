using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200181C RID: 6172
	public class CourtesyPrivilegeCardItem : MonoBehaviour
	{
		// Token: 0x0600F322 RID: 62242 RVA: 0x0041B23A File Offset: 0x0041963A
		private void Awake()
		{
			if (this.mBuyBtn != null)
			{
				this.mBuyBtn.onClick.RemoveAllListeners();
				this.mBuyBtn.onClick.AddListener(new UnityAction(this.OnBuyClick));
			}
		}

		// Token: 0x0600F323 RID: 62243 RVA: 0x0041B27C File Offset: 0x0041967C
		private void OnDestroy()
		{
			if (this.mBuyBtn != null)
			{
				this.mBuyBtn.onClick.RemoveListener(new UnityAction(this.OnBuyClick));
			}
			this.chargeMallTable = null;
			this.itemTable = null;
			this.buyEndTimeStamp = 0;
		}

		// Token: 0x0600F324 RID: 62244 RVA: 0x0041B2CC File Offset: 0x004196CC
		public void InitItemInfo(ILimitTimeActivityModel model)
		{
			if (model == null)
			{
				return;
			}
			this.buyEndTimeStamp = (int)model.Param;
			this.chargeMallTable = Singleton<TableManager>.GetInstance().GetTableItem<ChargeMallTable>(this.chargeMallTableID, string.Empty, string.Empty);
			if (this.chargeMallTable == null)
			{
				return;
			}
			this.itemTable = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.chargeMallTable.itemID, string.Empty, string.Empty);
			if (this.itemTable == null)
			{
				return;
			}
			if (this.mName != null)
			{
				this.mName.text = CommonUtility.GetItemColorName(this.itemTable);
			}
			if (this.mRMB != null)
			{
				this.mRMB.text = string.Format(this.mRMBDesc, this.chargeMallTable.ChargeMoney);
			}
			CommonNewItemDataModel dataModel = new CommonNewItemDataModel
			{
				ItemId = this.chargeMallTable.itemID,
				ItemCount = this.chargeMallTable.itemNum
			};
			CommonNewItem commonNewItem = CommonUtility.CreateCommonNewItem(this.mItemRoot);
			if (commonNewItem != null)
			{
				commonNewItem.InitItem(dataModel);
				commonNewItem.SetItemCountFontSize(30);
				commonNewItem.SetItemLevelFontSize(30);
			}
			this.UpdateCardIsActive();
		}

		// Token: 0x0600F325 RID: 62245 RVA: 0x0041B408 File Offset: 0x00419808
		public void UpdateCardIsActive()
		{
			if (this.miIactiveRoot != null)
			{
				this.miIactiveRoot.CustomActive(false);
			}
			if (this.mTimeRoot != null)
			{
				this.mTimeRoot.CustomActive(false);
			}
			if (this.mBuyBtn != null)
			{
				this.mBuyBtn.CustomActive(false);
			}
			if (this.mActiveRoot != null)
			{
				this.mActiveRoot.CustomActive(false);
			}
			if (this.mExpiredRoot != null)
			{
				this.mExpiredRoot.CustomActive(false);
			}
			int count = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.GIFT_RIGHT_CARD);
			if (count == 1)
			{
				if (this.mActiveRoot != null)
				{
					this.mActiveRoot.CustomActive(true);
				}
				if (this.mTimeRoot != null)
				{
					this.mTimeRoot.CustomActive(true);
				}
				int count2 = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.GIFT_RIGHT_CARD_BUY_TIME);
				DateTime dt = Function.ConvertIntDateTime((double)count2).AddDays((double)this.day);
				int num = Function.GetTimeStamp(dt) - (int)DataManager<TimeManager>.GetInstance().GetServerTime();
				if (this.mSimpleTimer != null)
				{
					if (num <= 86400)
					{
						this.mSimpleTimer.useSystemUpdate = true;
					}
					else
					{
						this.mSimpleTimer.useSystemUpdate = false;
					}
					this.mSimpleTimer.SetCountdown(num);
					this.mSimpleTimer.StartTimer();
				}
			}
			else if (count == 0)
			{
				int count3 = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.GIFT_RIGHT_CARD_BUY_TIME);
				if (count3 > 0)
				{
					if (this.mExpiredRoot != null)
					{
						this.mExpiredRoot.CustomActive(true);
					}
				}
				else
				{
					bool flag = this.buyEndTimeStamp - (int)DataManager<TimeManager>.GetInstance().GetServerTime() > 0;
					if (flag)
					{
						if (this.mBuyBtn != null)
						{
							this.mBuyBtn.CustomActive(true);
						}
						if (this.miIactiveRoot != null)
						{
							this.miIactiveRoot.CustomActive(true);
						}
					}
					else
					{
						if (this.mExpiredRoot != null)
						{
							this.mExpiredRoot.CustomActive(true);
						}
						if (this.mSimpleTimer != null)
						{
							this.mSimpleTimer.StopTimer();
						}
					}
				}
			}
		}

		// Token: 0x0600F326 RID: 62246 RVA: 0x0041B65E File Offset: 0x00419A5E
		private void OnBuyClick()
		{
			if (this.chargeMallTable == null || this.itemTable == null)
			{
				return;
			}
			Singleton<PayManager>.GetInstance().DoPay(this.chargeMallTable.ID, this.chargeMallTable.ChargeMoney, ChargeMallType.GiftRightCard);
		}

		// Token: 0x0400959B RID: 38299
		[SerializeField]
		private Text mName;

		// Token: 0x0400959C RID: 38300
		[SerializeField]
		private Text mRMB;

		// Token: 0x0400959D RID: 38301
		[SerializeField]
		private GameObject mItemRoot;

		// Token: 0x0400959E RID: 38302
		[SerializeField]
		private GameObject miIactiveRoot;

		// Token: 0x0400959F RID: 38303
		[SerializeField]
		private GameObject mTimeRoot;

		// Token: 0x040095A0 RID: 38304
		[SerializeField]
		private SimpleTimer mSimpleTimer;

		// Token: 0x040095A1 RID: 38305
		[SerializeField]
		private GameObject mActiveRoot;

		// Token: 0x040095A2 RID: 38306
		[SerializeField]
		private GameObject mExpiredRoot;

		// Token: 0x040095A3 RID: 38307
		[SerializeField]
		private Button mBuyBtn;

		// Token: 0x040095A4 RID: 38308
		[SerializeField]
		private UIGray mBuyGray;

		// Token: 0x040095A5 RID: 38309
		[SerializeField]
		private string mRMBDesc = "￥{0}";

		// Token: 0x040095A6 RID: 38310
		[SerializeField]
		private int chargeMallTableID = 15;

		// Token: 0x040095A7 RID: 38311
		[SerializeField]
		private int day = 30;

		// Token: 0x040095A8 RID: 38312
		private ChargeMallTable chargeMallTable;

		// Token: 0x040095A9 RID: 38313
		private ItemTable itemTable;

		// Token: 0x040095AA RID: 38314
		private int buyEndTimeStamp;
	}
}
