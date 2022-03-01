using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ActivityLimitTime;
using AdsPush;
using Battle;
using FashionLimitTimeBuy;
using GameClient;
using Network;
using Protocol;
using ProtoTable;

namespace LimitTimeGift
{
	// Token: 0x0200172E RID: 5934
	public class LimitTimeGiftDataManager
	{
		// Token: 0x17001CC4 RID: 7364
		// (get) Token: 0x0600E911 RID: 59665 RVA: 0x003DAF71 File Offset: 0x003D9371
		// (set) Token: 0x0600E912 RID: 59666 RVA: 0x003DAF79 File Offset: 0x003D9379
		public bool PetPushFrameIsOpen
		{
			get
			{
				return this.petPushFrameIsOpen;
			}
			set
			{
				this.petPushFrameIsOpen = value;
			}
		}

		// Token: 0x0600E913 RID: 59667 RVA: 0x003DAF82 File Offset: 0x003D9382
		public List<MallItemInfo> GetPetPushItemInfo()
		{
			return this.mPetPushItemInfo;
		}

		// Token: 0x0600E914 RID: 59668 RVA: 0x003DAF8A File Offset: 0x003D938A
		public List<LimitTimeGiftData> GetAllLimitTimeGiftData()
		{
			if (this.totalLimitTimeGifts != null)
			{
				this.totalLimitTimeGifts.Sort();
			}
			return this.totalLimitTimeGifts;
		}

		// Token: 0x0600E915 RID: 59669 RVA: 0x003DAFA8 File Offset: 0x003D93A8
		public List<LimitTimeGiftData> GetGiftsDataInMall()
		{
			if (this.mLimitTimeGiftList != null)
			{
				this.mLimitTimeGiftList.Sort();
			}
			return this.mLimitTimeGiftList;
		}

		// Token: 0x0600E916 RID: 59670 RVA: 0x003DAFC8 File Offset: 0x003D93C8
		public LimitTimeGiftData GetLimitTimeGiftDataById(uint giftId)
		{
			if (this.totalLimitTimeGifts != null)
			{
				for (int i = 0; i < this.totalLimitTimeGifts.Count; i++)
				{
					if (this.totalLimitTimeGifts[i].GiftId == giftId)
					{
						return this.totalLimitTimeGifts[i];
					}
				}
			}
			return null;
		}

		// Token: 0x0600E917 RID: 59671 RVA: 0x003DB024 File Offset: 0x003D9424
		public void GetMallGiftPack()
		{
			MallTypeTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MallTypeTable>(9, string.Empty, string.Empty);
			WorldMallQueryItemReq worldMallQueryItemReq = new WorldMallQueryItemReq();
			if (tableItem.MoneyID != 0)
			{
				worldMallQueryItemReq.moneyType = (byte)tableItem.MoneyID;
			}
			worldMallQueryItemReq.tagType = 0;
			worldMallQueryItemReq.type = (byte)tableItem.MallType;
			if (tableItem.MallSubType.Count > 0 && tableItem.MallSubType[0] != MallTypeTable.eMallSubType.MST_NONE)
			{
				worldMallQueryItemReq.subType = (byte)tableItem.MallSubType[0];
			}
			else if (tableItem.MallSubType != null && tableItem.MallSubType.Count == 1)
			{
				worldMallQueryItemReq.subType = (byte)tableItem.MallSubType[0];
			}
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldMallQueryItemReq>(ServerType.GATE_SERVER, worldMallQueryItemReq);
		}

		// Token: 0x0600E918 RID: 59672 RVA: 0x003DB0F4 File Offset: 0x003D94F4
		public Dictionary<int, List<LimitTimeGiftAwardData>> GetGiftAwardsByGiftId()
		{
			if (this.totalLimitTimeGifts != null)
			{
				this.limitTimeGiftAwardDicById = new Dictionary<int, List<LimitTimeGiftAwardData>>();
				for (int i = 0; i < this.totalLimitTimeGifts.Count; i++)
				{
					uint giftId = this.totalLimitTimeGifts[i].GiftId;
					List<LimitTimeGiftAwardData> giftAwards = this.totalLimitTimeGifts[i].GiftAwards;
					if (giftAwards != null)
					{
						this.limitTimeGiftAwardDicById.Add((int)giftId, giftAwards);
					}
				}
			}
			return null;
		}

		// Token: 0x0600E919 RID: 59673 RVA: 0x003DB16B File Offset: 0x003D956B
		public bool CheckIsGift(int gift)
		{
			return gift != 0 && gift != 4;
		}

		// Token: 0x0600E91A RID: 59674 RVA: 0x003DB180 File Offset: 0x003D9580
		public void Initialize()
		{
			this.Clear();
			this.totalLimitTimeGifts = new List<LimitTimeGiftData>();
			this.mLimitTimeGiftList = new List<LimitTimeGiftData>();
			this.AddALLGiftDataListener();
			Singleton<LimitTimeGiftFrameManager>.instance.Init();
			Singleton<LimitTimeBuyActivityManager>.instance.Init();
			this.RegisterUIEvent();
			this.isLimitTimeActShow = false;
			this.GetMallGiftPack();
			this._BindNetMsg();
			this.petPushFrameIsOpen = false;
		}

		// Token: 0x0600E91B RID: 59675 RVA: 0x003DB1E4 File Offset: 0x003D95E4
		public void Clear()
		{
			if (this.totalLimitTimeGifts != null)
			{
				this.totalLimitTimeGifts.Clear();
			}
			this.totalLimitTimeGifts = null;
			if (this.mLimitTimeGiftList != null)
			{
				this.mLimitTimeGiftList.Clear();
			}
			this.mLimitTimeGiftList = null;
			this.onGiftActivated = null;
			this.isFirstInTown = true;
			this.RemoveAllGiftDataListener();
			Singleton<LimitTimeGiftFrameManager>.instance.UnInit();
			Singleton<LimitTimeBuyActivityManager>.instance.UnInit();
			this.UnRegisterUIEvent();
			this._UnBindNetMsg();
			this.isLimitTimeActShow = false;
			this.isGetMallGifts = false;
			this.m_LimitTimeGiftIsClick = false;
			this.petPushFrameIsOpen = false;
			if (this.mPetPushItemInfo != null)
			{
				this.mPetPushItemInfo.Clear();
			}
			this.mPetPushItemInfo = null;
		}

		// Token: 0x0600E91C RID: 59676 RVA: 0x003DB298 File Offset: 0x003D9698
		public void Update(float a_fTime)
		{
		}

		// Token: 0x0600E91D RID: 59677 RVA: 0x003DB29A File Offset: 0x003D969A
		public void TryShowMallGift(MallGiftPackActivateCond activateCond, Action onGiftActivated = null)
		{
			this.onGiftActivated = onGiftActivated;
			this.OnSendReqActivateMallGift(activateCond);
		}

		// Token: 0x0600E91E RID: 59678 RVA: 0x003DB2AC File Offset: 0x003D96AC
		public void TryShowMallGiftByStrengthRes(Action onGiftActivated = null)
		{
			this.onGiftActivated = onGiftActivated;
			ushort level = DataManager<PlayerBaseData>.GetInstance().Level;
			this.OnSendReqActivateMallGift(this.GetGiftActivateCondByLevel((int)level));
		}

		// Token: 0x0600E91F RID: 59679 RVA: 0x003DB2D8 File Offset: 0x003D96D8
		public void RegisterPlayerDead(Action onFirstActivate = null)
		{
			BattleMain instance = BattleMain.instance;
			if (instance != null)
			{
				BattlePlayer localPlayer = instance.GetLocalPlayer(0UL);
				if (localPlayer != null)
				{
					if (localPlayer.playerActor == null)
					{
						return;
					}
					localPlayer.playerActor.RegisterEvent(BeEventType.onAfterDead, delegate(object[] args)
					{
						BattlePlayer localPlayer2 = BattleMain.instance.GetLocalPlayer(0UL);
						if (localPlayer2 == null)
						{
							return;
						}
						if (!localPlayer2.CanUseItem(DungeonItem.eType.RebornCoin, 1))
						{
							this.TryShowMallGift(MallGiftPackActivateCond.DIE, onFirstActivate);
						}
					});
				}
			}
		}

		// Token: 0x0600E920 RID: 59680 RVA: 0x003DB33C File Offset: 0x003D973C
		public bool HasNewGiftPackOrToBuy()
		{
			if (this.totalLimitTimeGifts == null)
			{
				return false;
			}
			if (this.totalLimitTimeGifts.Count == 0)
			{
				return false;
			}
			FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(37, string.Empty, string.Empty);
			if (tableItem != null && tableItem.StartLevel > (int)DataManager<PlayerBaseData>.GetInstance().Level)
			{
				return false;
			}
			for (int i = 0; i < this.totalLimitTimeGifts.Count; i++)
			{
				if (this.totalLimitTimeGifts[i].GiftState == LimitTimeGiftState.OnSale)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600E921 RID: 59681 RVA: 0x003DB3D4 File Offset: 0x003D97D4
		private WorldMallQueryItemReq ReadReqInfoFromTable(int tableId)
		{
			WorldMallQueryItemReq worldMallQueryItemReq = null;
			MallTypeTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MallTypeTable>(tableId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				worldMallQueryItemReq = new WorldMallQueryItemReq();
				worldMallQueryItemReq.type = (byte)tableItem.MallType;
				FlatBufferArray<MallTypeTable.eMallSubType> mallSubType = tableItem.MallSubType;
				if (mallSubType != null && mallSubType.Count > 0)
				{
					worldMallQueryItemReq.subType = 0;
					if (mallSubType[0] == MallTypeTable.eMallSubType.MST_NONE)
					{
						worldMallQueryItemReq.subType = 0;
					}
				}
				worldMallQueryItemReq.occu = (byte)tableItem.ClassifyJob;
				worldMallQueryItemReq.moneyType = (byte)tableItem.MoneyID;
			}
			return worldMallQueryItemReq;
		}

		// Token: 0x0600E922 RID: 59682 RVA: 0x003DB460 File Offset: 0x003D9860
		public void SendReqLimitGiftData()
		{
			WorldMallQueryItemReq worldMallQueryItemReq = new WorldMallQueryItemReq();
			worldMallQueryItemReq.type = 6;
			worldMallQueryItemReq.subType = 0;
			worldMallQueryItemReq.occu = 0;
			worldMallQueryItemReq.moneyType = 0;
			WorldMallQueryItemReq worldMallQueryItemReq2 = this.ReadReqInfoFromTable(9);
			if (worldMallQueryItemReq2 != null)
			{
				worldMallQueryItemReq = worldMallQueryItemReq2;
			}
			NetManager.Instance().SendCommand<WorldMallQueryItemReq>(ServerType.GATE_SERVER, worldMallQueryItemReq);
		}

		// Token: 0x0600E923 RID: 59683 RVA: 0x003DB4B0 File Offset: 0x003D98B0
		public void SendReqLimitTimeActivityData()
		{
			WorldMallQueryItemReq worldMallQueryItemReq = new WorldMallQueryItemReq();
			worldMallQueryItemReq.type = 7;
			worldMallQueryItemReq.subType = 0;
			worldMallQueryItemReq.occu = 0;
			worldMallQueryItemReq.moneyType = 18;
			WorldMallQueryItemReq worldMallQueryItemReq2 = this.ReadReqInfoFromTable(10);
			if (worldMallQueryItemReq2 != null)
			{
				worldMallQueryItemReq = worldMallQueryItemReq2;
			}
			NetManager.Instance().SendCommand<WorldMallQueryItemReq>(ServerType.GATE_SERVER, worldMallQueryItemReq);
		}

		// Token: 0x0600E924 RID: 59684 RVA: 0x003DB500 File Offset: 0x003D9900
		private void OnSendReqLimitGiftDetailData()
		{
			WorldMallQueryItemDetailReq cmd = new WorldMallQueryItemDetailReq();
			NetManager.Instance().SendCommand<WorldMallQueryItemDetailReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600E925 RID: 59685 RVA: 0x003DB520 File Offset: 0x003D9920
		public void SendReqBuyGift(uint giftId, int giftNum)
		{
			WorldMallBuy worldMallBuy = new WorldMallBuy();
			worldMallBuy.itemId = giftId;
			worldMallBuy.num = (ushort)giftNum;
			NetManager.Instance().SendCommand<WorldMallBuy>(ServerType.GATE_SERVER, worldMallBuy);
		}

		// Token: 0x0600E926 RID: 59686 RVA: 0x003DB550 File Offset: 0x003D9950
		public void SendReqBuyGiftInMall(uint giftId, int price, int giftNum)
		{
			CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
			costInfo.nMoneyID = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.POINT);
			DataManager<ItemTipManager>.GetInstance().CloseAll();
			costInfo.nCount = price;
			DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
			{
				WorldMallBuy worldMallBuy = new WorldMallBuy();
				worldMallBuy.itemId = giftId;
				worldMallBuy.num = (ushort)giftNum;
				NetManager netManager = NetManager.Instance();
				netManager.SendCommand<WorldMallBuy>(ServerType.GATE_SERVER, worldMallBuy);
			}, "common_money_cost", null);
		}

		// Token: 0x0600E927 RID: 59687 RVA: 0x003DB5B8 File Offset: 0x003D99B8
		public void SendReqBuyFashionInMall(int price, uint[] giftItemIds, SelectMallItemInfoData detailData)
		{
			if (detailData == null || giftItemIds == null)
			{
				return;
			}
			if (detailData.SelectItemInfos == null)
			{
				return;
			}
			int num = giftItemIds.Length;
			ItemReward[] items = new ItemReward[num];
			for (int i = 0; i < num; i++)
			{
				ItemReward itemReward = new ItemReward();
				itemReward.id = giftItemIds[i];
				itemReward.num = 1U;
				items[i] = itemReward;
			}
			CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
			costInfo.nMoneyID = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.POINT);
			DataManager<ItemTipManager>.GetInstance().CloseAll();
			costInfo.nCount = price;
			DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
			{
				CWMallBatchBuyReq cwmallBatchBuyReq = new CWMallBatchBuyReq();
				cwmallBatchBuyReq.items = items;
				NetManager netManager = NetManager.Instance();
				netManager.SendCommand<CWMallBatchBuyReq>(ServerType.GATE_SERVER, cwmallBatchBuyReq);
			}, "common_money_cost", null);
		}

		// Token: 0x0600E928 RID: 59688 RVA: 0x003DB670 File Offset: 0x003D9A70
		public void SendReqBuyFashionInMall(uint giftId, int price, int giftNum, SelectMallItemInfoData detailData, bool isCreditTicketDeduction = false)
		{
			if (detailData == null)
			{
				return;
			}
			if (detailData.SelectItemInfos == null)
			{
				return;
			}
			int count = detailData.SelectItemInfos.Count;
			ItemReward[] items = new ItemReward[count];
			for (int i = 0; i < count; i++)
			{
				ItemReward itemReward = new ItemReward();
				itemReward.id = detailData.SelectItemInfos[i].id;
				itemReward.num = 1U;
				items[i] = itemReward;
			}
			CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
			costInfo.nMoneyID = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.POINT);
			DataManager<ItemTipManager>.GetInstance().CloseAll();
			costInfo.nCount = price;
			costInfo.IsCreditPointDeduction = isCreditTicketDeduction;
			DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
			{
				if (detailData.multiple > 0)
				{
					string text = string.Empty;
					if ((int)DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket == MallNewUtility.GetIntergralMallTicketUpper() && !DataManager<MallNewDataManager>.GetInstance().bItemMallIntergralMallScoreIsEqual)
					{
						text = TR.Value("mall_buy_intergral_mall_score_equal_upper_value_desc");
						string content = text;
						if (LimitTimeGiftDataManager.<>f__mg$cache0 == null)
						{
							LimitTimeGiftDataManager.<>f__mg$cache0 = new OnCommonMsgBoxToggleClick(MallNewUtility.ItemMallIntergralMallScoreIsEqual);
						}
						MallNewUtility.CommonIntergralMallPopupWindow(content, LimitTimeGiftDataManager.<>f__mg$cache0, delegate
						{
							this.OnSendCWMallBatchBuyReq(count, items);
						});
					}
					else
					{
						int num = MallNewUtility.GetTicketConvertIntergalNumnber(detailData.TotalPrice) * detailData.multiple;
						int num2 = (int)DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket + num;
						if (num2 > MallNewUtility.GetIntergralMallTicketUpper() && (int)DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket != MallNewUtility.GetIntergralMallTicketUpper() && !DataManager<MallNewDataManager>.GetInstance().bItemMallIntergralMallScoreIsExceed)
						{
							text = TR.Value("mall_buy_intergral_mall_score_exceed_upper_value_desc", (int)DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket, MallNewUtility.GetIntergralMallTicketUpper(), MallNewUtility.GetIntergralMallTicketUpper() - (int)DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket);
							string content2 = text;
							if (LimitTimeGiftDataManager.<>f__mg$cache1 == null)
							{
								LimitTimeGiftDataManager.<>f__mg$cache1 = new OnCommonMsgBoxToggleClick(MallNewUtility.ItemMallIntergralMallScoreIsExceed);
							}
							MallNewUtility.CommonIntergralMallPopupWindow(content2, LimitTimeGiftDataManager.<>f__mg$cache1, delegate
							{
								this.OnSendCWMallBatchBuyReq(count, items);
							});
						}
						else
						{
							this.OnSendCWMallBatchBuyReq(count, items);
						}
					}
				}
				else
				{
					this.OnSendCWMallBatchBuyReq(count, items);
				}
			}, "common_money_cost", null);
		}

		// Token: 0x0600E929 RID: 59689 RVA: 0x003DB770 File Offset: 0x003D9B70
		private void OnSendCWMallBatchBuyReq(int count, ItemReward[] items)
		{
			CWMallBatchBuyReq cwmallBatchBuyReq = new CWMallBatchBuyReq();
			cwmallBatchBuyReq.items = new ItemReward[count];
			cwmallBatchBuyReq.items = items;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<CWMallBatchBuyReq>(ServerType.GATE_SERVER, cwmallBatchBuyReq);
		}

		// Token: 0x0600E92A RID: 59690 RVA: 0x003DB7A8 File Offset: 0x003D9BA8
		private void OnSendReqActivateMallGift(MallGiftPackActivateCond activeCond)
		{
			WorldMallGiftPackActivateReq worldMallGiftPackActivateReq = new WorldMallGiftPackActivateReq();
			worldMallGiftPackActivateReq.giftPackActCond = (byte)activeCond;
			NetManager.Instance().SendCommand<WorldMallGiftPackActivateReq>(ServerType.GATE_SERVER, worldMallGiftPackActivateReq);
		}

		// Token: 0x0600E92B RID: 59691 RVA: 0x003DB7D0 File Offset: 0x003D9BD0
		private void OnSendReqActivateMallGift(int testCond)
		{
			WorldMallGiftPackActivateReq worldMallGiftPackActivateReq = new WorldMallGiftPackActivateReq();
			worldMallGiftPackActivateReq.giftPackActCond = (byte)testCond;
			NetManager.Instance().SendCommand<WorldMallGiftPackActivateReq>(ServerType.GATE_SERVER, worldMallGiftPackActivateReq);
		}

		// Token: 0x0600E92C RID: 59692 RVA: 0x003DB7F8 File Offset: 0x003D9BF8
		private void AddALLGiftDataListener()
		{
			NetProcess.AddMsgHandler(602804U, new Action<MsgDATA>(this.OnSyncLimitTimeGiftData));
			NetProcess.AddMsgHandler(602802U, new Action<MsgDATA>(this.OnGiftBuyRes));
			NetProcess.AddMsgHandler(602815U, new Action<MsgDATA>(this.OnActivateGiftRes));
			NetProcess.AddMsgHandler(602817U, new Action<MsgDATA>(this.OnSyncLimitTimeAct));
		}

		// Token: 0x0600E92D RID: 59693 RVA: 0x003DB860 File Offset: 0x003D9C60
		private void RemoveAllGiftDataListener()
		{
			NetProcess.RemoveMsgHandler(602804U, new Action<MsgDATA>(this.OnSyncLimitTimeGiftData));
			NetProcess.RemoveMsgHandler(602802U, new Action<MsgDATA>(this.OnGiftBuyRes));
			NetProcess.RemoveMsgHandler(602815U, new Action<MsgDATA>(this.OnActivateGiftRes));
			NetProcess.RemoveMsgHandler(602817U, new Action<MsgDATA>(this.OnSyncLimitTimeAct));
		}

		// Token: 0x0600E92E RID: 59694 RVA: 0x003DB8C5 File Offset: 0x003D9CC5
		private void _BindNetMsg()
		{
			NetProcess.AddMsgHandler(602826U, new Action<MsgDATA>(this.OnWorldPushMallItems));
		}

		// Token: 0x0600E92F RID: 59695 RVA: 0x003DB8DD File Offset: 0x003D9CDD
		private void _UnBindNetMsg()
		{
			NetProcess.RemoveMsgHandler(602826U, new Action<MsgDATA>(this.OnWorldPushMallItems));
		}

		// Token: 0x0600E930 RID: 59696 RVA: 0x003DB8F5 File Offset: 0x003D9CF5
		private void RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnPayResultNotify, new ClientEventSystem.UIEventHandler(this.OnPayGiftData));
		}

		// Token: 0x0600E931 RID: 59697 RVA: 0x003DB912 File Offset: 0x003D9D12
		private void UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnPayResultNotify, new ClientEventSystem.UIEventHandler(this.OnPayGiftData));
		}

		// Token: 0x0600E932 RID: 59698 RVA: 0x003DB930 File Offset: 0x003D9D30
		private void OnSyncLimitTimeGiftData(MsgDATA msg)
		{
			WorldMallQueryItemRet worldMallQueryItemRet = new WorldMallQueryItemRet();
			worldMallQueryItemRet.decode(msg.bytes);
			this.SyncNetGiftDataToLocal(worldMallQueryItemRet);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnLimitTimeGiftViewRefresh, null, null, null, null);
		}

		// Token: 0x0600E933 RID: 59699 RVA: 0x003DB96C File Offset: 0x003D9D6C
		private void OnSyncLimitTimeGiftDetailData(MsgDATA msg)
		{
			WorldMallQueryItemDetailRet stream = new WorldMallQueryItemDetailRet();
			stream.decode(msg.bytes);
		}

		// Token: 0x0600E934 RID: 59700 RVA: 0x003DB98C File Offset: 0x003D9D8C
		private void OnGiftBuyRes(MsgDATA msg)
		{
			WorldMallBuyRet worldMallBuyRet = new WorldMallBuyRet();
			worldMallBuyRet.decode(msg.bytes);
			if (worldMallBuyRet.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldMallBuyRet.code, string.Empty);
			}
			this.UpdateLocalLimitTimeGift(worldMallBuyRet);
			this.UpdateActivityPriceShow(worldMallBuyRet);
		}

		// Token: 0x0600E935 RID: 59701 RVA: 0x003DB9DC File Offset: 0x003D9DDC
		private void OnActivateGiftRes(MsgDATA msg)
		{
			WorldMallGiftPackActivateRet worldMallGiftPackActivateRet = new WorldMallGiftPackActivateRet();
			worldMallGiftPackActivateRet.decode(msg.bytes);
			this.ActivateLimitTimeGift(worldMallGiftPackActivateRet);
		}

		// Token: 0x0600E936 RID: 59702 RVA: 0x003DBA04 File Offset: 0x003D9E04
		private void OnSyncLimitTimeAct(MsgDATA msg)
		{
			SyncWorldMallGiftPackActivityState syncWorldMallGiftPackActivityState = new SyncWorldMallGiftPackActivityState();
			syncWorldMallGiftPackActivityState.decode(msg.bytes);
			this.SyncLimitTimeActivty(syncWorldMallGiftPackActivityState);
		}

		// Token: 0x0600E937 RID: 59703 RVA: 0x003DBA2A File Offset: 0x003D9E2A
		private void OnPayGiftData(MsgDATA msg)
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MallNewFrame>(null))
			{
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<LimitTimeGiftFrame>(null))
			{
				this.RefreshPayGiftData();
			}
		}

		// Token: 0x0600E938 RID: 59704 RVA: 0x003DBA54 File Offset: 0x003D9E54
		private void OnWorldPushMallItems(MsgDATA msg)
		{
			WorldPushMallItems worldPushMallItems = new WorldPushMallItems();
			worldPushMallItems.decode(msg.bytes);
			this.mPetPushItemInfo = new List<MallItemInfo>();
			if (worldPushMallItems.mallItems.Length > 0)
			{
				for (int i = 0; i < worldPushMallItems.mallItems.Length; i++)
				{
					this.mPetPushItemInfo.Add(worldPushMallItems.mallItems[i]);
				}
			}
			if (this.mPetPushItemInfo != null)
			{
				ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
				if (clientSystemTown != null)
				{
					this.OpenLimitTimePetGiftFrame(this.mPetPushItemInfo);
				}
				else
				{
					this.petPushFrameIsOpen = true;
				}
			}
		}

		// Token: 0x0600E939 RID: 59705 RVA: 0x003DBAF1 File Offset: 0x003D9EF1
		public void OpenLimitTimePetGiftFrame(List<MallItemInfo> data)
		{
			if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<LimitTimePetGiftFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<LimitTimePetGiftFrame>(FrameLayer.Middle, data, string.Empty);
			}
		}

		// Token: 0x0600E93A RID: 59706 RVA: 0x003DBB18 File Offset: 0x003D9F18
		private void OnPayGiftData(UIEvent uiEvent)
		{
			if (uiEvent != null && uiEvent.Param1.Equals("0"))
			{
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MallNewFrame>(null))
				{
					return;
				}
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<LimitTimeGiftFrame>(null))
				{
					this.RefreshPayGiftData();
				}
			}
		}

		// Token: 0x0600E93B RID: 59707 RVA: 0x003DBB68 File Offset: 0x003D9F68
		public void SyncNetGiftDataToLocal(WorldMallQueryItemRet res)
		{
			if (res == null)
			{
				return;
			}
			MallItemInfo[] items = res.items;
			if (items != null)
			{
				if (res.type == 7)
				{
					if (this.mLimitTimeGiftList == null)
					{
						this.mLimitTimeGiftList = new List<LimitTimeGiftData>();
					}
					this.mLimitTimeGiftList.Clear();
				}
				else if (res.type == 0)
				{
					return;
				}
				if (items.Length <= 0)
				{
					if (res.type == 6)
					{
						if (this.totalLimitTimeGifts != null)
						{
							this.totalLimitTimeGifts.Clear();
						}
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnLimitTimeGiftDataRefresh, null, null, null, null);
					}
					return;
				}
				bool flag = this.CheckSyncMallItemInfoType(items, MallGoodsType.INVALID);
				if (flag)
				{
					return;
				}
				bool flag2 = this.CheckSyncMallItemInfoType(items, MallGoodsType.COMMON_CHOOSE_ONE);
				if (flag2)
				{
					return;
				}
				bool flag3 = this.CheckSyncMallItemInfoType(items, MallGoodsType.GIFT_ACTIVITY);
				if (flag3)
				{
					if (items.Length >= 2)
					{
					}
					for (int i = 0; i < items.Length; i++)
					{
						this.mLimitTimeGiftList.Add(this.SyncMallItemInfoToLimitTimeGift(items[i]));
					}
					LimitTimeGiftData limitTimeGiftData = this.SyncMallItemInfoToLimitTimeGift(items[0]);
					Singleton<LimitTimeBuyActivityManager>.instance.SyncLimitTimeActivityData(this.mLimitTimeGiftList);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnLimitTimeGiftDataRefresh, null, null, null, null);
					return;
				}
				if (this.totalLimitTimeGifts != null)
				{
					this.totalLimitTimeGifts.Clear();
				}
				this.totalLimitTimeGifts = new List<LimitTimeGiftData>();
				foreach (MallItemInfo mallItem in items)
				{
					LimitTimeGiftData item = this.SyncMallItemInfoToLimitTimeGift(mallItem);
					this.totalLimitTimeGifts.Add(item);
				}
				if (this.OnItemPayRetHandler != null)
				{
					this.OnItemPayRetHandler();
					if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<LimitTimeGiftFrame>(null))
					{
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.HasLimitTimeGiftToBuy, null, null, null, null);
					}
				}
				else if (this.isFirstInTown)
				{
					if (Singleton<LoginPushManager>.GetInstance().IsFirstLogin())
					{
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.HasLimitTimeGiftToBuy, null, null, null, null);
					}
					this.isFirstInTown = false;
				}
				if (!this.isGetMallGifts)
				{
					DataManager<ActivityLimitTimeCombineManager>.GetInstance().IsCheckedLimitTimeMallGift = (this.totalLimitTimeGifts.Count <= 0 || !Singleton<LoginPushManager>.GetInstance().IsFirstLogin());
					this.isGetMallGifts = true;
				}
			}
		}

		// Token: 0x0600E93C RID: 59708 RVA: 0x003DBDA0 File Offset: 0x003DA1A0
		private bool CheckSyncMallItemInfoType(MallItemInfo[] mallinfos, MallGoodsType goodType)
		{
			if (mallinfos == null || mallinfos.Length <= 0)
			{
				return false;
			}
			int num = mallinfos.Length;
			for (int i = 0; i < num; i++)
			{
				if ((MallGoodsType)mallinfos[i].gift != goodType)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600E93D RID: 59709 RVA: 0x003DBDE8 File Offset: 0x003DA1E8
		private void SaveThreeToOneGiftsInDic(MallItemInfo mallItem)
		{
			if (this.threeToOneGiftDicBySubType != null)
			{
				LimitTimeGiftData item = this.SyncMallItemInfoToLimitTimeGift(mallItem);
				int subtype = (int)mallItem.subtype;
				if (this.threeToOneGiftDicBySubType.ContainsKey(subtype))
				{
					this.threeToOneGiftDicBySubType[subtype].Add(item);
				}
				else
				{
					this.threeToOneGiftDicBySubType.Add(subtype, new List<LimitTimeGiftData>
					{
						item
					});
				}
			}
		}

		// Token: 0x0600E93E RID: 59710 RVA: 0x003DBE54 File Offset: 0x003DA254
		private void SyncThreeToOnGiftsToTotalGifts()
		{
			if (this.threeToOneGiftDicBySubType != null && this.totalLimitTimeGifts != null)
			{
				Dictionary<int, List<LimitTimeGiftData>>.Enumerator enumerator = this.threeToOneGiftDicBySubType.GetEnumerator();
				int num = 0;
				while (enumerator.MoveNext())
				{
					KeyValuePair<int, List<LimitTimeGiftData>> keyValuePair = enumerator.Current;
					List<LimitTimeGiftData> value = keyValuePair.Value;
					if (value != null && value.Count > 0)
					{
						LimitTimeGiftData limitTimeGiftData = new LimitTimeGiftData();
						limitTimeGiftData.GiftId = value[0].GiftId;
						limitTimeGiftData.GiftName = value[0].GiftName;
						limitTimeGiftData.RemainingTimeSec = value[0].RemainingTimeSec;
						limitTimeGiftData.PriceType = value[0].PriceType;
						limitTimeGiftData.GiftPrice = value[0].GiftPrice;
						limitTimeGiftData.LimitType = value[0].LimitType;
						limitTimeGiftData.GiftType = value[0].GiftType;
						limitTimeGiftData.GiftAwards = new List<LimitTimeGiftAwardData>();
						limitTimeGiftData.ThreeToOneGifts = new List<LimitTimeGiftData>();
						for (int i = 0; i < value.Count; i++)
						{
							int limitPurchaseNum = value[i].LimitPurchaseNum;
							if (limitPurchaseNum == 0)
							{
								num = 0;
							}
							if (i == 0)
							{
								num = limitPurchaseNum;
							}
							if (num > limitPurchaseNum)
							{
								num = limitPurchaseNum;
							}
							if (value[i].GiftAwards != null && limitTimeGiftData.GiftAwards != null && value[i].GiftAwards.Count > 0)
							{
								limitTimeGiftData.GiftAwards.Add(value[i].GiftAwards[0]);
							}
							limitTimeGiftData.ThreeToOneGifts.Add(value[i]);
						}
						limitTimeGiftData.LimitPurchaseNum = num;
						if (this.totalLimitTimeGifts != null)
						{
							this.totalLimitTimeGifts.Add(limitTimeGiftData);
						}
					}
				}
			}
		}

		// Token: 0x0600E93F RID: 59711 RVA: 0x003DC030 File Offset: 0x003DA430
		private void UpdateLocalLimitTimeGift(WorldMallBuyRet buyRes)
		{
			if (this.totalLimitTimeGifts != null)
			{
				for (int i = 0; i < this.totalLimitTimeGifts.Count; i++)
				{
					if (this.totalLimitTimeGifts[i].GiftId == buyRes.mallitemid)
					{
						this.totalLimitTimeGifts[i].LimitPurchaseNum = buyRes.restLimitNum;
						if (this.OnItemBuyRetHandler != null)
						{
							this.OnItemBuyRetHandler(this.totalLimitTimeGifts[i]);
							if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<LimitTimeGiftFrame>(null))
							{
								UIEventSystem.GetInstance().SendUIEvent(EUIEventID.HasLimitTimeGiftToBuy, null, null, null, null);
							}
						}
					}
				}
			}
		}

		// Token: 0x0600E940 RID: 59712 RVA: 0x003DC0DC File Offset: 0x003DA4DC
		private void UpdateActivityPriceShow(WorldMallBuyRet buyRes)
		{
			if (buyRes.code == 0U && Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<LimitTimeGiftFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<LimitTimeGiftFrame>(null, false);
			}
		}

		// Token: 0x0600E941 RID: 59713 RVA: 0x003DC108 File Offset: 0x003DA508
		private void ActivateLimitTimeGift(WorldMallGiftPackActivateRet actRes)
		{
			if (actRes.code == 0U)
			{
				if (actRes.items != null)
				{
					MallItemInfo[] items = actRes.items;
					if (items == null)
					{
						return;
					}
					if (items.Length == 0)
					{
						return;
					}
					if (items[0] != null)
					{
						LimitTimeGiftData limitTimeGiftData = new LimitTimeGiftData();
						limitTimeGiftData = this.SyncMallItemInfoToLimitTimeGift(items[0]);
						if (this.totalLimitTimeGifts != null && limitTimeGiftData != null && !this.totalLimitTimeGifts.Contains(limitTimeGiftData))
						{
							this.totalLimitTimeGifts.Add(limitTimeGiftData);
						}
						Singleton<LimitTimeGiftFrameManager>.instance.AddCurrShowGiftFrame(limitTimeGiftData);
					}
				}
			}
			else if (this.onGiftActivated != null)
			{
				this.onGiftActivated();
				this.onGiftActivated = null;
			}
		}

		// Token: 0x0600E942 RID: 59714 RVA: 0x003DC1B8 File Offset: 0x003DA5B8
		private void SyncLimitTimeActivty(SyncWorldMallGiftPackActivityState res)
		{
			if (res != null)
			{
				if (res.state == 1)
				{
					this.isLimitTimeActShow = true;
					DataManager<ActivityLimitTimeCombineManager>.GetInstance().GiftDataManager.SendReqLimitTimeActivityData();
				}
				else if (res.state == 2)
				{
					this.isLimitTimeActShow = false;
				}
				else
				{
					Logger.LogErrorFormat("SyncWorldMallGiftPackActivityState's state is error", new object[0]);
					this.isLimitTimeActShow = false;
				}
				Singleton<LimitTimeBuyActivityManager>.GetInstance().NeedRefreshIcon = this.isLimitTimeActShow;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ShowLimitTimeActivityBtn, this.isLimitTimeActShow, null, null, null);
			}
		}

		// Token: 0x0600E943 RID: 59715 RVA: 0x003DC24E File Offset: 0x003DA64E
		private void RefreshPayGiftData()
		{
			this.SendReqLimitGiftData();
		}

		// Token: 0x0600E944 RID: 59716 RVA: 0x003DC258 File Offset: 0x003DA658
		public LimitTimeGiftData SyncMallItemInfoToLimitTimeGift(MallItemInfo mallItem)
		{
			LimitTimeGiftData limitTimeGiftData = new LimitTimeGiftData();
			if (mallItem == null)
			{
				return limitTimeGiftData;
			}
			limitTimeGiftData.mallItemInfoData = mallItem;
			limitTimeGiftData.GiftId = mallItem.id;
			limitTimeGiftData.GiftName = mallItem.giftName;
			limitTimeGiftData.GiftType = (MallGoodsType)mallItem.gift;
			limitTimeGiftData.GiftDesc = mallItem.giftDesc;
			if (mallItem.gift == 1 || mallItem.gift == 7)
			{
				limitTimeGiftData.LimitPurchaseNum = (int)mallItem.limitnum;
			}
			else
			{
				limitTimeGiftData.LimitPurchaseNum = (int)mallItem.limittotalnum;
			}
			limitTimeGiftData.LimitNum = (int)mallItem.limitnum;
			limitTimeGiftData.LimitTotalNum = (int)mallItem.limittotalnum;
			bool flag = false;
			limitTimeGiftData.LimitLastNum = Utility.GetLeftLimitNum(mallItem, ref flag);
			limitTimeGiftData.RemainingTimeSec = mallItem.endtime - DataManager<TimeManager>.GetInstance().GetServerTime();
			limitTimeGiftData.PriceType = (LimitTimeGiftPriceType)mallItem.moneytype;
			limitTimeGiftData.GiftPrice = Utility.GetMallRealPrice(mallItem);
			limitTimeGiftData.LimitType = (ELimitiTimeGiftDataLimitType)mallItem.limit;
			limitTimeGiftData.GiftIconPath = mallItem.icon;
			limitTimeGiftData.GiftStartTime = mallItem.starttime;
			limitTimeGiftData.GiftEndTime = mallItem.endtime;
			if (mallItem.giftItems != null)
			{
				limitTimeGiftData.GiftAwards = new List<LimitTimeGiftAwardData>();
				for (int i = 0; i < mallItem.giftItems.Length; i++)
				{
					LimitTimeGiftAwardData limitTimeGiftAwardData = new LimitTimeGiftAwardData();
					limitTimeGiftAwardData.AwardId = mallItem.giftItems[i].id;
					limitTimeGiftAwardData.AwardCount = mallItem.giftItems[i].num;
					limitTimeGiftAwardData.StrengthLevel = (int)mallItem.giftItems[i].strength;
					limitTimeGiftData.GiftAwards.Add(limitTimeGiftAwardData);
				}
			}
			return limitTimeGiftData;
		}

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x0600E945 RID: 59717 RVA: 0x003DC3E4 File Offset: 0x003DA7E4
		// (remove) Token: 0x0600E946 RID: 59718 RVA: 0x003DC41C File Offset: 0x003DA81C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event Action<LimitTimeGiftData> OnItemBuyRetHandler;

		// Token: 0x0600E947 RID: 59719 RVA: 0x003DC452 File Offset: 0x003DA852
		public void AddItemBuyRetListener(Action<LimitTimeGiftData> handler)
		{
			this.RemoveAllItemBuyRetListener();
			if (this.OnItemBuyRetHandler == null)
			{
				this.OnItemBuyRetHandler += handler;
			}
		}

		// Token: 0x0600E948 RID: 59720 RVA: 0x003DC46C File Offset: 0x003DA86C
		public void RemoveAllItemBuyRetListener()
		{
			if (this.OnItemBuyRetHandler != null)
			{
				Delegate[] invocationList = this.OnItemBuyRetHandler.GetInvocationList();
				if (invocationList != null)
				{
					int num = invocationList.Length;
					for (int i = 0; i < num; i++)
					{
						this.OnItemBuyRetHandler -= (invocationList[i] as Action<LimitTimeGiftData>);
					}
				}
			}
		}

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x0600E949 RID: 59721 RVA: 0x003DC4BC File Offset: 0x003DA8BC
		// (remove) Token: 0x0600E94A RID: 59722 RVA: 0x003DC4F4 File Offset: 0x003DA8F4
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event Action OnItemPayRetHandler;

		// Token: 0x0600E94B RID: 59723 RVA: 0x003DC52A File Offset: 0x003DA92A
		public void AddItemPayRetListener(Action handler)
		{
			this.RemoveAllItemPayRetListener();
			if (this.OnItemPayRetHandler == null)
			{
				this.OnItemPayRetHandler += handler;
			}
		}

		// Token: 0x0600E94C RID: 59724 RVA: 0x003DC544 File Offset: 0x003DA944
		public void RemoveAllItemPayRetListener()
		{
			if (this.OnItemPayRetHandler != null)
			{
				Delegate[] invocationList = this.OnItemPayRetHandler.GetInvocationList();
				if (invocationList != null)
				{
					int num = invocationList.Length;
					for (int i = 0; i < num; i++)
					{
						this.OnItemPayRetHandler -= (invocationList[i] as Action);
					}
				}
			}
		}

		// Token: 0x0600E94D RID: 59725 RVA: 0x003DC594 File Offset: 0x003DA994
		private MallGiftPackActivateCond GetGiftActivateCondByLevel(int playerLevel)
		{
			if (playerLevel >= 10 && playerLevel < 15)
			{
				return MallGiftPackActivateCond.STRENGEN_BROKE_TEN;
			}
			if (playerLevel >= 15 && playerLevel < 20)
			{
				return MallGiftPackActivateCond.STRENGEN_BROKE_FIFTEEN;
			}
			if (playerLevel >= 20 && playerLevel < 25)
			{
				return MallGiftPackActivateCond.STRENGEN_BROKE_TWENTY;
			}
			if (playerLevel >= 25 && playerLevel < 30)
			{
				return MallGiftPackActivateCond.STRENGEN_BROKE_TWENTY_FIVE;
			}
			if (playerLevel >= 30 && playerLevel < 35)
			{
				return MallGiftPackActivateCond.STRENGEN_BROKE_THIRTY;
			}
			if (playerLevel >= 35 && playerLevel < 40)
			{
				return MallGiftPackActivateCond.STRENGEN_BROKE_THIRTY_FIVE;
			}
			if (playerLevel >= 40 && playerLevel < 45)
			{
				return MallGiftPackActivateCond.STRENGEN_BROKE_FORTY;
			}
			if (playerLevel >= 45 && playerLevel < 50)
			{
				return MallGiftPackActivateCond.STRENGEN_BROKE_FORTY_FIVE;
			}
			if (playerLevel >= 50)
			{
				return MallGiftPackActivateCond.STRENGEN_BROKE_FIFTY;
			}
			return MallGiftPackActivateCond.INVALID;
		}

		// Token: 0x04008D5A RID: 36186
		private List<LimitTimeGiftData> totalLimitTimeGifts;

		// Token: 0x04008D5B RID: 36187
		private List<LimitTimeGiftData> mLimitTimeGiftList;

		// Token: 0x04008D5C RID: 36188
		private Dictionary<int, List<LimitTimeGiftAwardData>> limitTimeGiftAwardDicById;

		// Token: 0x04008D5D RID: 36189
		private const int GIFT_MALL_TYPE_TABLE_ID = 9;

		// Token: 0x04008D5E RID: 36190
		private Dictionary<int, List<LimitTimeGiftData>> threeToOneGiftDicBySubType;

		// Token: 0x04008D5F RID: 36191
		private Dictionary<int, List<LimitTimeGiftAwardData>> threeToOneGiftAwardDicById;

		// Token: 0x04008D60 RID: 36192
		private List<ulong> BuyFahionItemResUids = new List<ulong>();

		// Token: 0x04008D61 RID: 36193
		private Action onGiftActivated;

		// Token: 0x04008D62 RID: 36194
		private bool isFirstInTown;

		// Token: 0x04008D63 RID: 36195
		private bool isGetMallGifts;

		// Token: 0x04008D64 RID: 36196
		public bool isLimitTimeActShow;

		// Token: 0x04008D65 RID: 36197
		public bool m_LimitTimeGiftIsClick;

		// Token: 0x04008D66 RID: 36198
		private bool petPushFrameIsOpen;

		// Token: 0x04008D67 RID: 36199
		private List<MallItemInfo> mPetPushItemInfo;

		// Token: 0x04008D6A RID: 36202
		[CompilerGenerated]
		private static OnCommonMsgBoxToggleClick <>f__mg$cache0;

		// Token: 0x04008D6B RID: 36203
		[CompilerGenerated]
		private static OnCommonMsgBoxToggleClick <>f__mg$cache1;
	}
}
