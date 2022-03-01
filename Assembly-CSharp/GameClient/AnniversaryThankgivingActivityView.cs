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
	// Token: 0x02001817 RID: 6167
	public class AnniversaryThankgivingActivityView : MonoBehaviour, IGiftPackActivityView
	{
		// Token: 0x0600F2F2 RID: 62194 RVA: 0x00419D56 File Offset: 0x00418156
		private void Awake()
		{
			this.mBuyBtn.SafeRemoveAllListener();
			this.mBuyBtn.SafeAddOnClickListener(new UnityAction(this._OnBuyClick));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSyncWorldMallBuySucceed, new ClientEventSystem.UIEventHandler(this.OnSyncWorldMallBuySucceed));
		}

		// Token: 0x0600F2F3 RID: 62195 RVA: 0x00419D95 File Offset: 0x00418195
		private void OnDestroy()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSyncWorldMallBuySucceed, new ClientEventSystem.UIEventHandler(this.OnSyncWorldMallBuySucceed));
		}

		// Token: 0x0600F2F4 RID: 62196 RVA: 0x00419DB4 File Offset: 0x004181B4
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

		// Token: 0x0600F2F5 RID: 62197 RVA: 0x00419E56 File Offset: 0x00418256
		public void Close()
		{
			this.mRequestedGiftPackIds.Clear();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GetGiftData, new ClientEventSystem.UIEventHandler(this._OnGetGiftData));
			Object.Destroy(base.gameObject);
		}

		// Token: 0x0600F2F6 RID: 62198 RVA: 0x00419E89 File Offset: 0x00418289
		public void UpdateData(LimitTimeGiftPackModel model)
		{
			this.UpdateMyData(model);
			this.UpdateAccountResNum(-1);
			this.UpdateBuyButton();
		}

		// Token: 0x0600F2F7 RID: 62199 RVA: 0x00419EA0 File Offset: 0x004182A0
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

		// Token: 0x0600F2F8 RID: 62200 RVA: 0x00419F80 File Offset: 0x00418380
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
			if (this.mItemParent.Count < giftPackSyncInfo.gifts.Length && this.mNameTxt.Count < giftPackSyncInfo.gifts.Length)
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
							if (AnniversaryThankgivingActivityView.<>f__mg$cache0 == null)
							{
								AnniversaryThankgivingActivityView.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
							}
							comItem2.Setup(item, AnniversaryThankgivingActivityView.<>f__mg$cache0);
							(comItem.transform as RectTransform).sizeDelta = this.mComItemSize;
							if (itemData.Type == ItemTable.eType.FASHION || (itemData.SubType == 29 && itemData.ThirdType == ItemTable.eThirdType.FashionGift) || itemData.SubType == 10 || itemData.SubType == 44)
							{
								PreViewItemData preViewItemData = new PreViewItemData();
								preViewItemData.activityId = (int)this.mModle.Id;
								preViewItemData.itemId = itemData.TableID;
								preViewDataModel.preViewItemList.Add(preViewItemData);
							}
							this.mNameTxt[i].SafeSetText(itemData.Name);
						}
					}
				}
				this.mPreviewBtn.SafeRemoveAllListener();
				this.mPreviewBtn.SafeAddOnClickListener(delegate
				{
					if (preViewDataModel.preViewItemList.Count > 0)
					{
						Singleton<ClientSystemManager>.GetInstance().OpenFrame<PreviewModelFrame>(FrameLayer.Middle, preViewDataModel, string.Empty);
					}
				});
			}
		}

		// Token: 0x0600F2F9 RID: 62201 RVA: 0x0041A208 File Offset: 0x00418608
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

		// Token: 0x0600F2FA RID: 62202 RVA: 0x0041A380 File Offset: 0x00418780
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
				DataManager<ActivityDataManager>.GetInstance().RequestMallGiftData(MallTypeTable.eMallType.SN_GRATITUDE_GIFT);
			}
		}

		// Token: 0x0600F2FB RID: 62203 RVA: 0x0041A43C File Offset: 0x0041883C
		private void UpdateBuyButton()
		{
			bool flag = this.accountRestBuyNum > 0;
			if (this.mBuyBtn != null)
			{
				this.mBuyBtn.enabled = flag;
				this.mBuyBtn.GetComponent<UIGray>().enabled = !flag;
			}
		}

		// Token: 0x0600F2FC RID: 62204 RVA: 0x0041A484 File Offset: 0x00418884
		private void _OnBuyClick()
		{
			if (this.mOnItemClick != null)
			{
				this.mOnItemClick(0, 0, 0UL);
			}
		}

		// Token: 0x0600F2FD RID: 62205 RVA: 0x0041A4A0 File Offset: 0x004188A0
		private string _TransTimeStampToStr(uint timeStamp)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(timeStamp);
			return string.Format("{0}月{1}日{2:HH:mm}", dateTime.Month, dateTime.Day, dateTime);
		}

		// Token: 0x04009565 RID: 38245
		[SerializeField]
		private Button mBuyBtn;

		// Token: 0x04009566 RID: 38246
		[SerializeField]
		private Button mPreviewBtn;

		// Token: 0x04009567 RID: 38247
		[SerializeField]
		private List<Transform> mItemParent;

		// Token: 0x04009568 RID: 38248
		[SerializeField]
		private List<Text> mNameTxt;

		// Token: 0x04009569 RID: 38249
		private ActivityItemBase.OnActivityItemClick<int> mOnItemClick;

		// Token: 0x0400956A RID: 38250
		[SerializeField]
		private Text mTimeTxt;

		// Token: 0x0400956B RID: 38251
		[SerializeField]
		private Text mRuleDesTxt;

		// Token: 0x0400956C RID: 38252
		[SerializeField]
		private Text mLimitAccountTxt;

		// Token: 0x0400956D RID: 38253
		private List<LimitTimeGiftPackDetailModel> mMallItemInfoList = new List<LimitTimeGiftPackDetailModel>();

		// Token: 0x0400956E RID: 38254
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(120f, 120f);

		// Token: 0x0400956F RID: 38255
		private LimitTimeGiftPackModel mModle;

		// Token: 0x04009570 RID: 38256
		private readonly List<int> mRequestedGiftPackIds = new List<int>();

		// Token: 0x04009571 RID: 38257
		private int accountRestBuyNum;

		// Token: 0x04009572 RID: 38258
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
