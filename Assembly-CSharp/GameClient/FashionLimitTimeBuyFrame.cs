using System;
using System.Collections.Generic;
using ActivityLimitTime;
using FashionLimitTimeBuy;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001726 RID: 5926
	public class FashionLimitTimeBuyFrame : ClientFrame
	{
		// Token: 0x17001CBA RID: 7354
		// (get) Token: 0x0600E8B4 RID: 59572 RVA: 0x003D8C8C File Offset: 0x003D708C
		// (set) Token: 0x0600E8B5 RID: 59573 RVA: 0x003D8C94 File Offset: 0x003D7094
		public SelectMallItemInfoData SelectMallItemInfo { get; set; }

		// Token: 0x0600E8B6 RID: 59574 RVA: 0x003D8C9D File Offset: 0x003D709D
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/LimitTimeGift/FashionLimitTimeBuyFrame";
		}

		// Token: 0x0600E8B7 RID: 59575 RVA: 0x003D8CA4 File Offset: 0x003D70A4
		protected override void _bindExUI()
		{
			this.awardParent = this.mBind.GetGameObject("AwardParent");
			this.chooseItemParent = this.mBind.GetGameObject("ChooseItemParent");
			this.buyBtn = this.mBind.GetCom<Button>("BuyBtn");
			if (this.buyBtn)
			{
				this.buyBtn.onClick.RemoveListener(new UnityAction(this.OnBuyBtnClick));
				this.buyBtn.onClick.AddListener(new UnityAction(this.OnBuyBtnClick));
			}
			this.toggleGroup = this.mBind.GetCom<ToggleGroup>("ChooseItemGroup");
			this.mSetButtonCD = this.mBind.GetCom<SetButtonCD>("SetButtonCD");
			DataManager<FashionLimitTimeBuyManager>.GetInstance().haveFashionDiscount = false;
		}

		// Token: 0x0600E8B8 RID: 59576 RVA: 0x003D8D74 File Offset: 0x003D7174
		protected override void _unbindExUI()
		{
			this.awardParent = null;
			this.chooseItemParent = null;
			if (this.buyBtn)
			{
				this.buyBtn.onClick.RemoveListener(new UnityAction(this.OnBuyBtnClick));
			}
			this.buyBtn = null;
			this.toggleGroup = null;
			this.mSetButtonCD = null;
			DataManager<FashionLimitTimeBuyManager>.GetInstance().haveFashionDiscount = false;
		}

		// Token: 0x0600E8B9 RID: 59577 RVA: 0x003D8DDC File Offset: 0x003D71DC
		protected override void _OnOpenFrame()
		{
			this.sevenData = new SelectMallItemInfoData();
			this.monthData = new SelectMallItemInfoData();
			this.foreverData = new SelectMallItemInfoData();
			this._OnUpdate(1f);
			if (this.userData == null)
			{
				return;
			}
			FashionOutComeData fashionOutComeData = this.userData as FashionOutComeData;
			if (fashionOutComeData != null)
			{
				this.showMallItemInfos = fashionOutComeData.mallItemInfos;
				this.currFashionTypeIndex = fashionOutComeData.fashionTypeIndex;
				if (this.currFashionTypeIndex == FashionMallMainIndex.FashionOne)
				{
					this.allFashionInfosById = DataManager<FashionLimitTimeBuyManager>.GetInstance().GetAllLimitTimeFashionById();
					this.allFashionInfosByType = DataManager<FashionLimitTimeBuyManager>.GetInstance().GetAllLimtTimeFashionInfosByType();
				}
				else if (this.currFashionTypeIndex == FashionMallMainIndex.FashionAll)
				{
					this.allFashionInfosById = DataManager<FashionLimitTimeBuyManager>.GetInstance().GetAllFashionSuitsById();
					this.allFashionInfosByType = DataManager<FashionLimitTimeBuyManager>.GetInstance().GetAllFashionSuitsByType();
				}
			}
			MonoSingleton<FashionLimitTimeItemManager>.instance.Initialize(this.chooseItemParent);
			this.chooseItems = new List<FashionLimitTimeItem>();
			this.InitAwardItems();
		}

		// Token: 0x0600E8BA RID: 59578 RVA: 0x003D8EC8 File Offset: 0x003D72C8
		protected override void _OnCloseFrame()
		{
			this.sevenData = null;
			this.monthData = null;
			this.foreverData = null;
			this.showMallItemInfos = null;
			this.SelectMallItemInfo = null;
			this.allFashionInfosById = null;
			this.allFashionInfosByType = null;
			if (this.comItems != null)
			{
				for (int i = 0; i < this.comItems.Length; i++)
				{
					ComItemManager.Destroy(this.comItems[i]);
				}
				this.comItems = null;
			}
			if (this.chooseItems != null)
			{
				for (int j = 0; j < this.chooseItems.Count; j++)
				{
					this.chooseItems[j].Destory();
				}
			}
			this.chooseItems = null;
			MonoSingleton<FashionLimitTimeItemManager>.instance.UnInitialize();
		}

		// Token: 0x0600E8BB RID: 59579 RVA: 0x003D8F88 File Offset: 0x003D7388
		private void OnBuyBtnClick()
		{
			if (!this.mSetButtonCD.BtIsWork)
			{
				return;
			}
			this.mSetButtonCD.BtIsWork = false;
			if (this.SelectMallItemInfo != null)
			{
				int moneyType = (int)this.SelectMallItemInfo.MoneyType;
				uint giftId = 0U;
				int price = 0;
				bool isCreditTicketDeduction = false;
				if (this.SelectMallItemInfo.SelectItemInfos != null && this.SelectMallItemInfo.SelectItemInfos.Count == 1)
				{
					giftId = this.SelectMallItemInfo.SelectItemInfos[0].id;
					price = (int)this.SelectMallItemInfo.SelectItemInfos[0].discountprice;
					MallItemInfo mallItemInfo = this.SelectMallItemInfo.SelectItemInfos[0];
					ItemReward[] giftItems = mallItemInfo.giftItems;
					uint[] array = DataManager<FashionLimitTimeBuyManager>.GetInstance().TryGetItemIdsInMallItemInfo(mallItemInfo, (int)this.currFashionTypeIndex);
					isCreditTicketDeduction = MallNewUtility.IsMallItemCanCreditPointDeduction(this.SelectMallItemInfo.SelectItemInfos[0]);
				}
				if (moneyType == 18)
				{
					DataManager<ActivityLimitTimeCombineManager>.GetInstance().GiftDataManager.SendReqBuyFashionInMall(giftId, price, 1, this.SelectMallItemInfo, isCreditTicketDeduction);
				}
			}
			else
			{
				string msgContent = TR.Value("fashion_buy_noone_select_tip");
				SystemNotifyManager.SysNotifyTextAnimation(msgContent, CommonTipsDesc.eShowMode.SI_UNIQUE);
			}
		}

		// Token: 0x0600E8BC RID: 59580 RVA: 0x003D90B0 File Offset: 0x003D74B0
		private void InitAwardItems()
		{
			if (this.showMallItemInfos == null)
			{
				return;
			}
			int count = this.showMallItemInfos.Count;
			this.comItems = new ComItem[count];
			for (int i = 0; i < count; i++)
			{
				if (this.allFashionInfosById != null && this.allFashionInfosById.ContainsKey(this.showMallItemInfos[i].id))
				{
					this.showMallItemInfos[i] = this.allFashionInfosById[this.showMallItemInfos[i].id];
				}
				MallItemInfo itemInfo = this.showMallItemInfos[i];
				uint[] array = DataManager<FashionLimitTimeBuyManager>.GetInstance().TryGetItemIdsInMallItemInfo(itemInfo, (int)this.currFashionTypeIndex);
				if (array != null)
				{
					int num = array.Length;
					if (this.comItems != null && this.comItems.Length < num)
					{
						this.comItems = new ComItem[num];
					}
					for (int j = 0; j < num; j++)
					{
						GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject("UIFlatten/Prefabs/LimitTimeGift/LimitTimeAwardItem_2", true, 0U);
						if (gameObject != null)
						{
							Utility.AttachTo(gameObject, this.awardParent, false);
							Image componentInChildren = gameObject.GetComponentInChildren<Image>();
							Text componentInChildren2 = gameObject.GetComponentInChildren<Text>();
							if (componentInChildren2 == null && componentInChildren == null)
							{
								return;
							}
							ComItem comItem = base.CreateComItem(componentInChildren.gameObject);
							ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)array[j], 100, 0);
							if (itemData != null)
							{
								componentInChildren2.text = itemData.Name;
								ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)array[j], string.Empty, string.Empty);
								if (tableItem != null)
								{
									DataManager<FashionLimitTimeBuyManager>.GetInstance().ResetItemNameColor(tableItem, componentInChildren2);
								}
								comItem.Setup(itemData, delegate(GameObject go, ItemData clickedItemData)
								{
									DataManager<ItemTipManager>.GetInstance().ShowTipWithoutModelAvatar(clickedItemData);
								});
							}
							this.comItems[j] = comItem;
						}
					}
				}
			}
			this.CreateLimitTimeItems(this.showMallItemInfos);
		}

		// Token: 0x0600E8BD RID: 59581 RVA: 0x003D92A8 File Offset: 0x003D76A8
		private void CreateLimitTimeItems(List<MallItemInfo> showInfoList)
		{
			if (showInfoList != null)
			{
				List<MallItemInfo> list = null;
				for (int i = 0; i < showInfoList.Count; i++)
				{
					MallItemInfo mallItemInfo = showInfoList[i];
					int goodsSubType = (int)mallItemInfo.goodsSubType;
					if (this.allFashionInfosByType != null && this.allFashionInfosByType.TryGetValue(goodsSubType, out list))
					{
						this.SaveSameTypeItemInfo(list);
					}
				}
				if (list != null && this.sevenData != null && this.monthData != null && this.foreverData != null)
				{
					this.ReSortTypeMallInfoList(list);
					for (int j = 0; j < list.Count; j++)
					{
						Toggle toggle = null;
						FashionLimitTime itemInfoType = this.GetItemInfoType(list[j]);
						if (itemInfoType != FashionLimitTime.SevenDay)
						{
							if (itemInfoType != FashionLimitTime.OneMonth)
							{
								if (itemInfoType == FashionLimitTime.Forever)
								{
									FashionLimitTimeItem fashionLimitTimeItem = this.CreateLimitTimeItems(this.foreverData);
									toggle = fashionLimitTimeItem.GetCurrToggle();
									if (toggle)
									{
										toggle.isOn = true;
									}
								}
							}
							else
							{
								FashionLimitTimeItem fashionLimitTimeItem = this.CreateLimitTimeItems(this.monthData);
								toggle = fashionLimitTimeItem.GetCurrToggle();
							}
						}
						else
						{
							FashionLimitTimeItem fashionLimitTimeItem = this.CreateLimitTimeItems(this.sevenData);
							toggle = fashionLimitTimeItem.GetCurrToggle();
						}
						if (toggle && this.toggleGroup)
						{
							toggle.group = this.toggleGroup;
						}
					}
				}
			}
		}

		// Token: 0x0600E8BE RID: 59582 RVA: 0x003D9418 File Offset: 0x003D7818
		private void SaveSameTypeItemInfo(List<MallItemInfo> typeMallInfoList)
		{
			if (typeMallInfoList != null)
			{
				for (int i = 0; i < typeMallInfoList.Count; i++)
				{
					MallItemInfo mallItemInfo = typeMallInfoList[i];
					if (this.GetItemInfoType(mallItemInfo) == FashionLimitTime.SevenDay)
					{
						this.sevenData.SelectItemInfos.Add(mallItemInfo);
						this.sevenData.FashionTypeIndex = this.currFashionTypeIndex;
					}
					else if (this.GetItemInfoType(mallItemInfo) == FashionLimitTime.OneMonth)
					{
						this.monthData.SelectItemInfos.Add(mallItemInfo);
						this.monthData.FashionTypeIndex = this.currFashionTypeIndex;
					}
					else if (this.GetItemInfoType(mallItemInfo) == FashionLimitTime.Forever)
					{
						this.foreverData.SelectItemInfos.Add(mallItemInfo);
						this.foreverData.FashionTypeIndex = this.currFashionTypeIndex;
					}
				}
			}
		}

		// Token: 0x0600E8BF RID: 59583 RVA: 0x003D94E4 File Offset: 0x003D78E4
		private FashionLimitTime GetItemInfoType(MallItemInfo mallItem)
		{
			if (mallItem != null)
			{
				uint id = DataManager<FashionLimitTimeBuyManager>.GetInstance().TryGetItemIdInMallItemInfo(mallItem, (int)this.currFashionTypeIndex);
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)id, string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (tableItem.TimeLeft == 604800)
					{
						return FashionLimitTime.SevenDay;
					}
					if (tableItem.TimeLeft == 2592000)
					{
						return FashionLimitTime.OneMonth;
					}
					if (tableItem.TimeLeft == 0)
					{
						return FashionLimitTime.Forever;
					}
				}
			}
			return FashionLimitTime.Invalid;
		}

		// Token: 0x0600E8C0 RID: 59584 RVA: 0x003D9558 File Offset: 0x003D7958
		private FashionLimitTimeItem CreateLimitTimeItems(SelectMallItemInfoData selectData)
		{
			FashionLimitTimeItem fashionLimitTimeItem = new FashionLimitTimeItem();
			fashionLimitTimeItem.Init(this.chooseItemParent, this, selectData);
			if (this.chooseItems != null)
			{
				this.chooseItems.Add(fashionLimitTimeItem);
			}
			return fashionLimitTimeItem;
		}

		// Token: 0x0600E8C1 RID: 59585 RVA: 0x003D9591 File Offset: 0x003D7991
		private void ReSortTypeMallInfoList(List<MallItemInfo> typeInfoList)
		{
			if (typeInfoList != null)
			{
				typeInfoList.Sort((MallItemInfo x, MallItemInfo y) => x.discountprice.CompareTo(y.discountprice));
			}
		}

		// Token: 0x04008D16 RID: 36118
		private const string AwardItemPath = "UIFlatten/Prefabs/LimitTimeGift/LimitTimeAwardItem_2";

		// Token: 0x04008D17 RID: 36119
		private const string SelectToBuy_Tip = "请选择一款购买";

		// Token: 0x04008D18 RID: 36120
		private GameObject awardParent;

		// Token: 0x04008D19 RID: 36121
		private GameObject chooseItemParent;

		// Token: 0x04008D1A RID: 36122
		private Button buyBtn;

		// Token: 0x04008D1B RID: 36123
		private SetButtonCD mSetButtonCD;

		// Token: 0x04008D1C RID: 36124
		private ToggleGroup toggleGroup;

		// Token: 0x04008D1D RID: 36125
		private List<FashionLimitTimeItem> chooseItems;

		// Token: 0x04008D1E RID: 36126
		private ComItem[] comItems;

		// Token: 0x04008D1F RID: 36127
		private FashionMallMainIndex currFashionTypeIndex = FashionMallMainIndex.None;

		// Token: 0x04008D20 RID: 36128
		private List<MallItemInfo> showMallItemInfos;

		// Token: 0x04008D21 RID: 36129
		private Dictionary<uint, MallItemInfo> allFashionInfosById;

		// Token: 0x04008D22 RID: 36130
		private Dictionary<int, List<MallItemInfo>> allFashionInfosByType;

		// Token: 0x04008D24 RID: 36132
		private SelectMallItemInfoData sevenData;

		// Token: 0x04008D25 RID: 36133
		private SelectMallItemInfoData monthData;

		// Token: 0x04008D26 RID: 36134
		private SelectMallItemInfoData foreverData;
	}
}
