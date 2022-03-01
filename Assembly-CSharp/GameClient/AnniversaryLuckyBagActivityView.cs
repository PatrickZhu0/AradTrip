using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001815 RID: 6165
	public class AnniversaryLuckyBagActivityView : MonoBehaviour, IGiftPackActivityView
	{
		// Token: 0x0600F2DA RID: 62170 RVA: 0x00419233 File Offset: 0x00417633
		private void Awake()
		{
			this.mBuyBtn.SafeRemoveAllListener();
			this.mBuyBtn.SafeAddOnClickListener(new UnityAction(this._OnBuyClick));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSyncWorldMallBuySucceed, new ClientEventSystem.UIEventHandler(this.OnSyncWorldMallBuySucceed));
		}

		// Token: 0x0600F2DB RID: 62171 RVA: 0x00419272 File Offset: 0x00417672
		private void OnDestroy()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSyncWorldMallBuySucceed, new ClientEventSystem.UIEventHandler(this.OnSyncWorldMallBuySucceed));
		}

		// Token: 0x0600F2DC RID: 62172 RVA: 0x00419290 File Offset: 0x00417690
		public void Init(LimitTimeGiftPackModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			if (model.Id == 0U)
			{
				Logger.LogError("LimitTimeActivityModel data is empty");
				return;
			}
			this.mTimeTxt.SafeSetText(string.Format("{0}~{1}", this._TransTimeStampToStr(model.StartTime), this._TransTimeStampToStr(model.EndTime)));
			this.mRuleDesTxt.SafeSetText(model.RuleDesc);
			this.mOnItemClick = onItemClick;
			this.accountRestBuyNum = 0;
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GetGiftData, new ClientEventSystem.UIEventHandler(this._OnGetGiftData));
			this.UpdateMyData(model);
			this.UpdateAccountResNum(-1);
			this.UpdateBuyButton();
		}

		// Token: 0x0600F2DD RID: 62173 RVA: 0x00419332 File Offset: 0x00417732
		public void Close()
		{
			this.mRequestedGiftPackIds.Clear();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GetGiftData, new ClientEventSystem.UIEventHandler(this._OnGetGiftData));
			Object.Destroy(base.gameObject);
		}

		// Token: 0x0600F2DE RID: 62174 RVA: 0x00419365 File Offset: 0x00417765
		public void UpdateData(LimitTimeGiftPackModel model)
		{
			this.UpdateMyData(model);
			this.UpdateAccountResNum(-1);
			this.UpdateBuyButton();
		}

		// Token: 0x0600F2DF RID: 62175 RVA: 0x0041937C File Offset: 0x0041777C
		private void UpdateMyData(LimitTimeGiftPackModel model)
		{
			this.mModle = model;
			if (model.DetailDatas.Count > 0)
			{
				for (int i = 0; i < model.DetailDatas.Count; i++)
				{
					for (int j = 0; j < model.DetailDatas[i].mRewards.Length; j++)
					{
						DataManager<GiftPackDataManager>.GetInstance().GetGiftPackItem((int)model.DetailDatas[i].mRewards[j].id);
						ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)model.DetailDatas[i].mRewards[j].id, 100, 0);
						if (!this.mRequestedGiftPackIds.Contains(itemData.TableID))
						{
							this.mRequestedGiftPackIds.Add(itemData.TableID);
						}
					}
				}
			}
		}

		// Token: 0x0600F2E0 RID: 62176 RVA: 0x0041945C File Offset: 0x0041785C
		private void _OnGetGiftData(UIEvent param)
		{
			if (param == null || param.Param1 == null)
			{
				Logger.LogError("礼包数据为空");
				return;
			}
			GiftPackSyncInfo giftPackSyncInfo = param.Param1 as GiftPackSyncInfo;
			if (!this.mRequestedGiftPackIds.Contains((int)giftPackSyncInfo.id))
			{
				return;
			}
			PreViewDataModel preViewDataModel = new PreViewDataModel();
			preViewDataModel.isCreatItem = false;
			preViewDataModel.preViewItemList = new List<PreViewItemData>();
			if (this.mItemParent.Count < giftPackSyncInfo.gifts.Length && this.mItemNameTxt.Count < giftPackSyncInfo.gifts.Length)
			{
				Logger.LogError("礼包的数量大于ComItem位置的数量，请添加新的位置");
				return;
			}
			if (giftPackSyncInfo != null)
			{
				for (int i = 0; i < giftPackSyncInfo.gifts.Length; i++)
				{
					GiftPackItemData giftDataFromNet = GiftPackDataManager.GetGiftDataFromNet(giftPackSyncInfo.gifts[i]);
					if (giftDataFromNet.ItemID > 0)
					{
						for (int j = 0; j < this.mItemParent[i].childCount; j++)
						{
							Object.Destroy(this.mItemParent[i].GetChild(j).gameObject);
						}
						ComItem comItem = ComItemManager.Create(this.mItemParent[i].gameObject);
						if (giftDataFromNet.ItemID > 0 && comItem != null)
						{
							ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)giftPackSyncInfo.gifts[i].itemId, 100, 0);
							itemData.Count = (int)giftPackSyncInfo.gifts[i].itemNum;
							ComItem comItem2 = comItem;
							ItemData item = itemData;
							if (AnniversaryLuckyBagActivityView.<>f__mg$cache0 == null)
							{
								AnniversaryLuckyBagActivityView.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
							}
							comItem2.Setup(item, AnniversaryLuckyBagActivityView.<>f__mg$cache0);
							(comItem.transform as RectTransform).sizeDelta = this.mComItemSize;
							this.mItemNameTxt[i].SafeSetText(itemData.Name);
						}
					}
				}
			}
			if (this.mRequestedGiftPackIds.Count > 0)
			{
				for (int k = 0; k < this.mGiftParent.childCount; k++)
				{
					Object.Destroy(this.mGiftParent.GetChild(k).gameObject);
				}
				ComItem comItem3 = ComItemManager.Create(this.mGiftParent.gameObject);
				if (this.mRequestedGiftPackIds[0] > 0 && comItem3 != null)
				{
					ItemData itemData2 = ItemDataManager.CreateItemDataFromTable(this.mRequestedGiftPackIds[0], 100, 0);
					itemData2.Count = 1;
					ComItem comItem4 = comItem3;
					ItemData item2 = itemData2;
					if (AnniversaryLuckyBagActivityView.<>f__mg$cache1 == null)
					{
						AnniversaryLuckyBagActivityView.<>f__mg$cache1 = new ComItem.OnItemClicked(Utility.OnItemClicked);
					}
					comItem4.Setup(item2, AnniversaryLuckyBagActivityView.<>f__mg$cache1);
					(comItem3.transform as RectTransform).sizeDelta = this.mComItemSize;
					this.mGiftNameTxt.SafeSetText(itemData2.Name);
				}
			}
		}

		// Token: 0x0600F2E1 RID: 62177 RVA: 0x00419710 File Offset: 0x00417B10
		private void UpdateAccountResNum(int accountNum = -1)
		{
			if (this.mModle.DetailDatas != null && this.mModle.DetailDatas.Count >= 1)
			{
				if (accountNum == -1)
				{
					this.accountRestBuyNum = (int)this.mModle.DetailDatas[0].AccountRestBuyNum;
				}
				else
				{
					this.accountRestBuyNum = accountNum;
				}
				int accountLimitBuyNum = (int)this.mModle.DetailDatas[0].AccountLimitBuyNum;
				switch (this.mModle.DetailDatas[0].AccountRefreshType)
				{
				case 0U:
					this.mLimitAccountTxt.SafeSetText(string.Format(TR.Value("count_limittime_mall_limit_number_everyday"), this.accountRestBuyNum, accountLimitBuyNum));
					break;
				case 1U:
					this.mLimitAccountTxt.SafeSetText(string.Format(TR.Value("count_limittime_mall_limit_number_month"), this.accountRestBuyNum, accountLimitBuyNum));
					break;
				case 2U:
					this.mLimitAccountTxt.SafeSetText(string.Format(TR.Value("count_limittime_mall_limit_number_week"), this.accountRestBuyNum, accountLimitBuyNum));
					break;
				case 3U:
					this.mLimitAccountTxt.SafeSetText(string.Format(TR.Value("count_limittime_mall_limit_number_today"), this.accountRestBuyNum, accountLimitBuyNum));
					break;
				}
			}
		}

		// Token: 0x0600F2E2 RID: 62178 RVA: 0x00419888 File Offset: 0x00417C88
		private void OnSyncWorldMallBuySucceed(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			if (uiEvent.Param1 == null || uiEvent.Param2 == null || uiEvent.Param3 == null)
			{
				return;
			}
			if (this.mModle.DetailDatas == null || this.mModle.DetailDatas.Count < 1)
			{
				return;
			}
			uint num = (uint)uiEvent.Param1;
			int num2 = (int)uiEvent.Param3;
			if (num == this.mModle.DetailDatas[0].Id)
			{
				this.accountRestBuyNum = num2;
				this.UpdateAccountResNum(this.accountRestBuyNum);
				this.UpdateBuyButton();
				DataManager<ActivityDataManager>.GetInstance().RequestMallGiftData(MallTypeTable.eMallType.SN_GRATITUDE_LUCKYBAG);
			}
		}

		// Token: 0x0600F2E3 RID: 62179 RVA: 0x00419944 File Offset: 0x00417D44
		private void UpdateBuyButton()
		{
			bool flag = this.accountRestBuyNum > 0;
			if (this.mBuyBtn != null)
			{
				this.mBuyBtn.enabled = flag;
				this.mBuyBtn.GetComponent<UIGray>().enabled = !flag;
			}
		}

		// Token: 0x0600F2E4 RID: 62180 RVA: 0x0041998C File Offset: 0x00417D8C
		private void _OnBuyClick()
		{
			if (this.mOnItemClick != null)
			{
				this.mOnItemClick(0, 0, 0UL);
			}
		}

		// Token: 0x0600F2E5 RID: 62181 RVA: 0x004199A8 File Offset: 0x00417DA8
		private string _TransTimeStampToStr(uint timeStamp)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(timeStamp);
			return string.Format("{0}月{1}日{2:HH:mm}", dateTime.Month, dateTime.Day, dateTime);
		}

		// Token: 0x04009549 RID: 38217
		[SerializeField]
		private Button mBuyBtn;

		// Token: 0x0400954A RID: 38218
		[SerializeField]
		private List<Transform> mItemParent;

		// Token: 0x0400954B RID: 38219
		[SerializeField]
		private List<Text> mItemNameTxt;

		// Token: 0x0400954C RID: 38220
		[SerializeField]
		private Text mGiftNameTxt;

		// Token: 0x0400954D RID: 38221
		[SerializeField]
		private Transform mGiftParent;

		// Token: 0x0400954E RID: 38222
		private ActivityItemBase.OnActivityItemClick<int> mOnItemClick;

		// Token: 0x0400954F RID: 38223
		[SerializeField]
		private Text mTimeTxt;

		// Token: 0x04009550 RID: 38224
		[SerializeField]
		private Text mRuleDesTxt;

		// Token: 0x04009551 RID: 38225
		[SerializeField]
		private Text mLimitAccountTxt;

		// Token: 0x04009552 RID: 38226
		private int accountRestBuyNum;

		// Token: 0x04009553 RID: 38227
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(90f, 90f);

		// Token: 0x04009554 RID: 38228
		private LimitTimeGiftPackModel mModle;

		// Token: 0x04009555 RID: 38229
		private readonly List<int> mRequestedGiftPackIds = new List<int>();

		// Token: 0x04009556 RID: 38230
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;

		// Token: 0x04009557 RID: 38231
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache1;
	}
}
