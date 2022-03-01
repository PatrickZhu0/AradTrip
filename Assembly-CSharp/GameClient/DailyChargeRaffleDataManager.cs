using System;
using System.Collections.Generic;
using AdsPush;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001354 RID: 4948
	public class DailyChargeRaffleDataManager : DataManager<DailyChargeRaffleDataManager>
	{
		// Token: 0x17001B9B RID: 7067
		// (get) Token: 0x0600BFC9 RID: 49097 RVA: 0x002D27BD File Offset: 0x002D0BBD
		// (set) Token: 0x0600BFCA RID: 49098 RVA: 0x002D27C5 File Offset: 0x002D0BC5
		public bool FirstRedPointFlag
		{
			get
			{
				return this.mFirstRedPointFlag;
			}
			set
			{
				if (this.mFirstRedPointFlag != value)
				{
					this.mFirstRedPointFlag = value;
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DailyChargeRedPointChanged, null, null, null, null);
				}
			}
		}

		// Token: 0x0600BFCB RID: 49099 RVA: 0x002D27ED File Offset: 0x002D0BED
		private void BindNetEvents()
		{
			NetProcess.AddMsgHandler(501127U, new Action<MsgDATA>(this.OnRecvSceneNotifyActiveTaskStatus));
			NetProcess.AddMsgHandler(507413U, new Action<MsgDATA>(this._OnSceneOpActivityGetCounterRes));
		}

		// Token: 0x0600BFCC RID: 49100 RVA: 0x002D281B File Offset: 0x002D0C1B
		private void UnBindNetEvents()
		{
			NetProcess.RemoveMsgHandler(501127U, new Action<MsgDATA>(this.OnRecvSceneNotifyActiveTaskStatus));
			NetProcess.RemoveMsgHandler(507413U, new Action<MsgDATA>(this._OnSceneOpActivityGetCounterRes));
		}

		// Token: 0x0600BFCD RID: 49101 RVA: 0x002D284C File Offset: 0x002D0C4C
		private void OnRecvSceneNotifyActiveTaskStatus(MsgDATA data)
		{
			SceneNotifyActiveTaskStatus sceneNotifyActiveTaskStatus = new SceneNotifyActiveTaskStatus();
			sceneNotifyActiveTaskStatus.decode(data.bytes);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DailyChargeResultNotify, (int)sceneNotifyActiveTaskStatus.taskId, (int)sceneNotifyActiveTaskStatus.status, null, null);
		}

		// Token: 0x0600BFCE RID: 49102 RVA: 0x002D2894 File Offset: 0x002D0C94
		private void _OnSceneOpActivityGetCounterRes(MsgDATA data)
		{
			int num = 0;
			SceneOpActivityGetCounterRes sceneOpActivityGetCounterRes = new SceneOpActivityGetCounterRes();
			sceneOpActivityGetCounterRes.decode(data.bytes, ref num);
			DailyChargeCounter param = new DailyChargeCounter(sceneOpActivityGetCounterRes.opActId, sceneOpActivityGetCounterRes.counterId, sceneOpActivityGetCounterRes.counterValue);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DailyChargeCounterChanged, param, null, null, null);
		}

		// Token: 0x0600BFCF RID: 49103 RVA: 0x002D28E2 File Offset: 0x002D0CE2
		public override void Initialize()
		{
			this.BindNetEvents();
		}

		// Token: 0x0600BFD0 RID: 49104 RVA: 0x002D28EA File Offset: 0x002D0CEA
		public override void Clear()
		{
			this.UnBindNetEvents();
		}

		// Token: 0x0600BFD1 RID: 49105 RVA: 0x002D28F4 File Offset: 0x002D0CF4
		public List<DailyChargeRaffleModel> GetDailyChargeModels()
		{
			List<DailyChargeRaffleModel> list = null;
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(8700);
			if (activeData == null)
			{
				return list;
			}
			if (activeData.akChildItems == null)
			{
				return list;
			}
			for (int i = 0; i < activeData.akChildItems.Count; i++)
			{
				ActiveManager.ActivityData activityData = activeData.akChildItems[i];
				if (activityData != null)
				{
					DailyChargeRaffleModel dailyChargeRaffleModel = new DailyChargeRaffleModel();
					dailyChargeRaffleModel.Id = activityData.ID;
					dailyChargeRaffleModel.Status = (TaskStatus)activityData.status;
					Dictionary<uint, int> awards = activityData.GetAwards();
					if (awards != null)
					{
						Dictionary<uint, int>.Enumerator enumerator = awards.GetEnumerator();
						while (enumerator.MoveNext())
						{
							KeyValuePair<uint, int> keyValuePair = enumerator.Current;
							uint key = keyValuePair.Key;
							KeyValuePair<uint, int> keyValuePair2 = enumerator.Current;
							int value = keyValuePair2.Value;
							ItemSimpleData sData = new ItemSimpleData();
							sData.ItemID = (int)key;
							sData.Count = value;
							if (dailyChargeRaffleModel.AwardItemDataList == null)
							{
								dailyChargeRaffleModel.AwardItemDataList = new List<ItemSimpleData>();
							}
							ItemSimpleData itemSimpleData = dailyChargeRaffleModel.AwardItemDataList.Find((ItemSimpleData x) => x.ItemID == sData.ItemID);
							if (itemSimpleData != null)
							{
								itemSimpleData.Count += sData.Count;
							}
							else
							{
								dailyChargeRaffleModel.AwardItemDataList.Add(sData);
							}
						}
					}
					ActiveTable activeItem = activityData.activeItem;
					if (activeItem != null)
					{
						int param = activeItem.Param1;
						ChargeMallTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ChargeMallTable>(param, string.Empty, string.Empty);
						if (tableItem != null)
						{
							dailyChargeRaffleModel.ChargeItemId = param;
							dailyChargeRaffleModel.ChargePrice = tableItem.ChargeMoney;
							dailyChargeRaffleModel.ChargeMallType = ChargeMallType.DayChargeWelfare;
						}
						int num = 0;
						if (int.TryParse(activeItem.Param2, out num))
						{
							dailyChargeRaffleModel.RaffleTableId = num;
							DrawPrizeTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<DrawPrizeTable>(num, string.Empty, string.Empty);
							if (tableItem2 != null)
							{
								dailyChargeRaffleModel.RaffleTicketType = tableItem2.RaffleTicketType;
							}
						}
						dailyChargeRaffleModel.SortIndex = activeItem.SortPriority2;
					}
					SystemValueTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(579, string.Empty, string.Empty);
					if (tableItem3 != null)
					{
						dailyChargeRaffleModel.accLimitChargeMax = tableItem3.Value;
					}
					if (list == null)
					{
						list = new List<DailyChargeRaffleModel>();
					}
					if (list.Contains(dailyChargeRaffleModel))
					{
						list.Remove(dailyChargeRaffleModel);
					}
					list.Add(dailyChargeRaffleModel);
				}
			}
			if (list != null)
			{
				list.Sort((DailyChargeRaffleModel x, DailyChargeRaffleModel y) => x.SortIndex.CompareTo(y.SortIndex));
			}
			return list;
		}

		// Token: 0x0600BFD2 RID: 49106 RVA: 0x002D2B9C File Offset: 0x002D0F9C
		public int GetRaffleTicketCountByRaffleTableId(int raffleTableId)
		{
			DrawPrizeTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DrawPrizeTable>(raffleTableId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return 0;
			}
			string getCountKey = tableItem.GetCountKey;
			return DataManager<CountDataManager>.GetInstance().GetCount(getCountKey);
		}

		// Token: 0x0600BFD3 RID: 49107 RVA: 0x002D2BDB File Offset: 0x002D0FDB
		public void SendBuyDailyChargeReq(DailyChargeRaffleModel model)
		{
			if (model == null)
			{
				Logger.LogError("pay model is null !!!");
			}
			Singleton<PayManager>.GetInstance().DoPay(model.ChargeItemId, model.ChargePrice, model.ChargeMallType);
		}

		// Token: 0x0600BFD4 RID: 49108 RVA: 0x002D2C09 File Offset: 0x002D1009
		public void OpenRaffleTurnTableFrame(int raffleTableId)
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<DailyChargeRaffleTurnTable>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<DailyChargeRaffleTurnTable>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<DailyChargeRaffleTurnTable>(FrameLayer.Middle, raffleTableId, string.Empty);
		}

		// Token: 0x0600BFD5 RID: 49109 RVA: 0x002D2C40 File Offset: 0x002D1040
		public void OpenRaffleTurnTableFrame(List<DailyChargeRaffleModel> models)
		{
			if (models == null)
			{
				return;
			}
			models.Sort((DailyChargeRaffleModel x, DailyChargeRaffleModel y) => x.SortIndex.CompareTo(y.SortIndex));
			int num = 0;
			for (int i = 0; i < models.Count; i++)
			{
				int raffleTableId = models[i].RaffleTableId;
				num = this.GetRaffleTicketCountByRaffleTableId(raffleTableId);
				if (num > 0)
				{
					this.OpenRaffleTurnTableFrame(raffleTableId);
					break;
				}
			}
			if (num <= 0 && models.Count >= 0)
			{
				this.OpenRaffleTurnTableFrame(models[0].RaffleTableId);
			}
		}

		// Token: 0x0600BFD6 RID: 49110 RVA: 0x002D2CDD File Offset: 0x002D10DD
		public bool IsRedPointShow()
		{
			return Singleton<LoginPushManager>.GetInstance().IsFirstLogin() && this.mFirstRedPointFlag;
		}

		// Token: 0x0600BFD7 RID: 49111 RVA: 0x002D2CF7 File Offset: 0x002D10F7
		public void ResetRedPoint()
		{
			if (this.FirstRedPointFlag)
			{
				this.FirstRedPointFlag = false;
			}
		}

		// Token: 0x0600BFD8 RID: 49112 RVA: 0x002D2D0C File Offset: 0x002D110C
		public void ReqDailyChargeCounter(int dailyChargeTaskId)
		{
			SceneOpActivityGetCounterReq sceneOpActivityGetCounterReq = new SceneOpActivityGetCounterReq();
			sceneOpActivityGetCounterReq.opActId = (uint)dailyChargeTaskId;
			sceneOpActivityGetCounterReq.counterId = 1001U;
			MonoSingleton<NetManager>.instance.SendCommand<SceneOpActivityGetCounterReq>(ServerType.GATE_SERVER, sceneOpActivityGetCounterReq);
		}

		// Token: 0x04006C3C RID: 27708
		public const int ACTIVITY_CONFIG_ID = 9380;

		// Token: 0x04006C3D RID: 27709
		public const int ACTIVITY_TEMPLATE_ID = 8700;

		// Token: 0x04006C3E RID: 27710
		private bool mFirstRedPointFlag = true;
	}
}
