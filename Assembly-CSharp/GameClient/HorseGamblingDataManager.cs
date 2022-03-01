using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x0200127F RID: 4735
	public class HorseGamblingDataManager : DataManager<HorseGamblingDataManager>, IHorseGablingDataManager
	{
		// Token: 0x17001AEB RID: 6891
		// (get) Token: 0x0600B61B RID: 46619 RVA: 0x00291527 File Offset: 0x0028F927
		// (set) Token: 0x0600B61C RID: 46620 RVA: 0x0029152F File Offset: 0x0028F92F
		public List<IHorseGamblingMapZoneModel> MapZoneModels { get; private set; }

		// Token: 0x17001AEC RID: 6892
		// (get) Token: 0x0600B61D RID: 46621 RVA: 0x00291538 File Offset: 0x0028F938
		// (set) Token: 0x0600B61E RID: 46622 RVA: 0x00291540 File Offset: 0x0028F940
		public BetHorsePhaseType State { get; private set; }

		// Token: 0x17001AED RID: 6893
		// (get) Token: 0x0600B61F RID: 46623 RVA: 0x00291549 File Offset: 0x0028F949
		// (set) Token: 0x0600B620 RID: 46624 RVA: 0x00291551 File Offset: 0x0028F951
		public int LeftSupply { get; private set; }

		// Token: 0x17001AEE RID: 6894
		// (get) Token: 0x0600B621 RID: 46625 RVA: 0x0029155A File Offset: 0x0028F95A
		// (set) Token: 0x0600B622 RID: 46626 RVA: 0x00291562 File Offset: 0x0028F962
		public bool mIsOpen { get; private set; }

		// Token: 0x17001AEF RID: 6895
		// (get) Token: 0x0600B623 RID: 46627 RVA: 0x0029156B File Offset: 0x0028F96B
		public bool IsOpen
		{
			get
			{
				return this.mIsOpen && Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.HorseGambling);
			}
		}

		// Token: 0x17001AF0 RID: 6896
		// (get) Token: 0x0600B624 RID: 46628 RVA: 0x00291582 File Offset: 0x0028F982
		// (set) Token: 0x0600B625 RID: 46629 RVA: 0x0029158A File Offset: 0x0028F98A
		public uint TimeStamp { get; private set; }

		// Token: 0x17001AF1 RID: 6897
		// (get) Token: 0x0600B626 RID: 46630 RVA: 0x00291593 File Offset: 0x0028F993
		// (set) Token: 0x0600B627 RID: 46631 RVA: 0x0029159B File Offset: 0x0028F99B
		public BetHorseCfg ConfigData { get; private set; }

		// Token: 0x17001AF2 RID: 6898
		// (get) Token: 0x0600B628 RID: 46632 RVA: 0x002915A4 File Offset: 0x0028F9A4
		// (set) Token: 0x0600B629 RID: 46633 RVA: 0x002915AC File Offset: 0x0028F9AC
		public int UnknownShooterId { get; private set; }

		// Token: 0x17001AF3 RID: 6899
		// (get) Token: 0x0600B62A RID: 46634 RVA: 0x002915B5 File Offset: 0x0028F9B5
		// (set) Token: 0x0600B62B RID: 46635 RVA: 0x002915BD File Offset: 0x0028F9BD
		public WeatherType Weather { get; private set; }

		// Token: 0x0600B62C RID: 46636 RVA: 0x002915C8 File Offset: 0x0028F9C8
		public override void Initialize()
		{
			this.mIsOpen = false;
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<BetHorseCfg>();
			Dictionary<int, object>.ValueCollection.Enumerator enumerator = table.Values.GetEnumerator();
			enumerator.MoveNext();
			this.ConfigData = (BetHorseCfg)enumerator.Current;
			NetProcess.AddMsgHandler(501145U, new Action<MsgDATA>(this.OnSyncActivities));
			NetProcess.AddMsgHandler(501149U, new Action<MsgDATA>(this.OnSyncActivityStateChange));
			NetProcess.AddMsgHandler(708302U, new Action<MsgDATA>(this.OnDataResponse));
			NetProcess.AddMsgHandler(708304U, new Action<MsgDATA>(this.OnShooterDataResponse));
			NetProcess.AddMsgHandler(708306U, new Action<MsgDATA>(this.OnShooterHistoryResponse));
			NetProcess.AddMsgHandler(708308U, new Action<MsgDATA>(this.OnShooterStakeResponse));
			NetProcess.AddMsgHandler(708309U, new Action<MsgDATA>(this.OnSyncStateChanged));
			NetProcess.AddMsgHandler(708313U, new Action<MsgDATA>(this.OnGameHistoryResponse));
			NetProcess.AddMsgHandler(708315U, new Action<MsgDATA>(this.OnShooterRankListResponse));
			NetProcess.AddMsgHandler(708311U, new Action<MsgDATA>(this.OnStakeHistoryResponse));
			NetProcess.AddMsgHandler(602802U, new Action<MsgDATA>(this.OnBuyBulletRes));
		}

		// Token: 0x0600B62D RID: 46637 RVA: 0x00291700 File Offset: 0x0028FB00
		public override void Clear()
		{
			this.mIsOpen = false;
			NetProcess.RemoveMsgHandler(708302U, new Action<MsgDATA>(this.OnDataResponse));
			NetProcess.RemoveMsgHandler(708304U, new Action<MsgDATA>(this.OnShooterDataResponse));
			NetProcess.RemoveMsgHandler(708306U, new Action<MsgDATA>(this.OnShooterHistoryResponse));
			NetProcess.RemoveMsgHandler(708308U, new Action<MsgDATA>(this.OnShooterStakeResponse));
			NetProcess.RemoveMsgHandler(708309U, new Action<MsgDATA>(this.OnSyncStateChanged));
			NetProcess.RemoveMsgHandler(708313U, new Action<MsgDATA>(this.OnGameHistoryResponse));
			NetProcess.RemoveMsgHandler(708315U, new Action<MsgDATA>(this.OnShooterRankListResponse));
			NetProcess.RemoveMsgHandler(708311U, new Action<MsgDATA>(this.OnStakeHistoryResponse));
			NetProcess.RemoveMsgHandler(501145U, new Action<MsgDATA>(this.OnSyncActivities));
			NetProcess.RemoveMsgHandler(501149U, new Action<MsgDATA>(this.OnSyncActivityStateChange));
			NetProcess.RemoveMsgHandler(602802U, new Action<MsgDATA>(this.OnBuyBulletRes));
			this.ClearDatas();
			if (this.mStakeHistory != null)
			{
				this.mStakeHistory.Clear();
			}
			if (this.mGameHistoryList != null)
			{
				this.mGameHistoryList.Clear();
			}
			if (this.mShooterRankList != null)
			{
				this.mShooterRankList.Clear();
			}
		}

		// Token: 0x0600B62E RID: 46638 RVA: 0x00291850 File Offset: 0x0028FC50
		public void RequestData()
		{
			BetHorseReq cmd = new BetHorseReq();
			NetManager.Instance().SendCommand<BetHorseReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600B62F RID: 46639 RVA: 0x00291870 File Offset: 0x0028FC70
		public void RequestShooterOdds()
		{
			ShooterOddsReq cmd = new ShooterOddsReq();
			NetManager.Instance().SendCommand<ShooterOddsReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600B630 RID: 46640 RVA: 0x00291890 File Offset: 0x0028FC90
		public HorseGamblingShooterModel GetShooterModel(int shooterId)
		{
			if (this.mShooterModels.ContainsKey(shooterId))
			{
				return this.mShooterModels[shooterId];
			}
			return null;
		}

		// Token: 0x0600B631 RID: 46641 RVA: 0x002918B1 File Offset: 0x0028FCB1
		public List<HorseGamblingRankModel> GetShooterRank()
		{
			if (this.mShooterRankList.Count <= 0)
			{
				this.RequestShooterRank();
			}
			return this.mShooterRankList;
		}

		// Token: 0x0600B632 RID: 46642 RVA: 0x002918D0 File Offset: 0x0028FCD0
		public List<HorseGamblingHistoryModel> GetGameHistory()
		{
			return this.mGameHistoryList;
		}

		// Token: 0x0600B633 RID: 46643 RVA: 0x002918D8 File Offset: 0x0028FCD8
		public ShooterRecord[] GetShooterHistory(int shooterId)
		{
			if (this.mShooterModels.ContainsKey(shooterId) && this.mShooterModels[shooterId].Records != null && this.mShooterModels[shooterId].Records.Length > 0)
			{
				return this.mShooterModels[shooterId].Records;
			}
			this.RequestShooterHistory((uint)shooterId);
			return null;
		}

		// Token: 0x0600B634 RID: 46644 RVA: 0x00291940 File Offset: 0x0028FD40
		public string GetShooterIconPath(int shooterId)
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<BetHorseShooter>();
			if (table.ContainsKey(shooterId))
			{
				return ((BetHorseShooter)table[shooterId]).IconPath;
			}
			return null;
		}

		// Token: 0x0600B635 RID: 46645 RVA: 0x00291977 File Offset: 0x0028FD77
		public float GetShooterOdds(int shooterId)
		{
			if (this.mShooterModels.ContainsKey(shooterId))
			{
				return this.mShooterModels[shooterId].Odds;
			}
			this.RequestShooterOdds();
			return 0f;
		}

		// Token: 0x0600B636 RID: 46646 RVA: 0x002919A8 File Offset: 0x0028FDA8
		public void ShooterStake(int shooterId, int num)
		{
			stakeReq stakeReq = new stakeReq();
			stakeReq.id = (uint)shooterId;
			stakeReq.num = (uint)num;
			NetManager.Instance().SendCommand<stakeReq>(ServerType.GATE_SERVER, stakeReq);
		}

		// Token: 0x0600B637 RID: 46647 RVA: 0x002919D8 File Offset: 0x0028FDD8
		public void ExchangeBullet(int num)
		{
			if (this.ConfigData != null)
			{
				WorldMallBuy worldMallBuy = new WorldMallBuy();
				worldMallBuy.itemId = (uint)this.ConfigData.BulletMallItemId;
				worldMallBuy.num = (ushort)num;
				NetManager netManager = NetManager.Instance();
				netManager.SendCommand<WorldMallBuy>(ServerType.GATE_SERVER, worldMallBuy);
			}
		}

		// Token: 0x0600B638 RID: 46648 RVA: 0x00291A1E File Offset: 0x0028FE1E
		public List<IHorseGamblingStakeModel> GetStakeHistory()
		{
			if (this.mStakeHistory.Count <= 0)
			{
				this.RequestStakeHistory();
			}
			return this.mStakeHistory;
		}

		// Token: 0x0600B639 RID: 46649 RVA: 0x00291A40 File Offset: 0x0028FE40
		public void RequestStakeHistory()
		{
			StakeRecordReq cmd = new StakeRecordReq();
			NetManager.Instance().SendCommand<StakeRecordReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600B63A RID: 46650 RVA: 0x00291A60 File Offset: 0x0028FE60
		public void RequestGameHistory()
		{
			BattleRecordReq cmd = new BattleRecordReq();
			NetManager.Instance().SendCommand<BattleRecordReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600B63B RID: 46651 RVA: 0x00291A80 File Offset: 0x0028FE80
		private void RequestShooterRank()
		{
			shooterRankReq cmd = new shooterRankReq();
			NetManager.Instance().SendCommand<shooterRankReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600B63C RID: 46652 RVA: 0x00291AA0 File Offset: 0x0028FEA0
		private void ClearDatas()
		{
			if (this.MapZoneModels != null)
			{
				this.MapZoneModels.Clear();
			}
			if (this.mShooterModels != null)
			{
				this.mShooterModels.Clear();
			}
		}

		// Token: 0x0600B63D RID: 46653 RVA: 0x00291AD0 File Offset: 0x0028FED0
		private void OnDataResponse(MsgDATA data)
		{
			BetHorseRes betHorseRes = new BetHorseRes();
			betHorseRes.decode(data.bytes);
			this.Weather = (WeatherType)betHorseRes.weather;
			this.State = (BetHorsePhaseType)betHorseRes.phase;
			this.TimeStamp = betHorseRes.stamp;
			this.UnknownShooterId = (int)betHorseRes.mysteryShooter;
			if (betHorseRes.shooterList == null)
			{
				Logger.LogError("������������Ϊ�գ�������˴�����������");
				return;
			}
			this.mShooterModels.Clear();
			for (int i = 0; i < betHorseRes.shooterList.Length; i++)
			{
				uint id = betHorseRes.shooterList[i].id;
				this.mShooterModels.Add((int)id, new HorseGamblingShooterModel(betHorseRes.shooterList[i], id == betHorseRes.mysteryShooter));
				this.RequestShooterHistory(id);
			}
			this.MapZoneModels = new List<IHorseGamblingMapZoneModel>(betHorseRes.mapList.Length);
			for (int j = 0; j < betHorseRes.mapList.Length; j++)
			{
				this.MapZoneModels.Add(new HorseGamblingMapZoneModel(betHorseRes.mapList[j]));
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.HorseGamblingUpdate, null, null, null, null);
		}

		// Token: 0x0600B63E RID: 46654 RVA: 0x00291BE8 File Offset: 0x0028FFE8
		private void RequestShooterHistory(uint shooterId)
		{
			ShooterHistoryRecordReq cmd = new ShooterHistoryRecordReq
			{
				id = shooterId
			};
			NetManager.Instance().SendCommand<ShooterHistoryRecordReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600B63F RID: 46655 RVA: 0x00291C14 File Offset: 0x00290014
		private void OnShooterDataResponse(MsgDATA data)
		{
			ShooterOddsRes shooterOddsRes = new ShooterOddsRes();
			shooterOddsRes.decode(data.bytes);
			if (shooterOddsRes.oddsList == null)
			{
				return;
			}
			for (int i = 0; i < shooterOddsRes.oddsList.Length; i++)
			{
				if (this.mShooterModels.ContainsKey((int)shooterOddsRes.oddsList[i].id))
				{
					this.mShooterModels[(int)shooterOddsRes.oddsList[i].id].UpdateOdds((int)shooterOddsRes.oddsList[i].odds);
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.HorseGamblingOddsUpdate, null, null, null, null);
		}

		// Token: 0x0600B640 RID: 46656 RVA: 0x00291CB4 File Offset: 0x002900B4
		private void OnShooterHistoryResponse(MsgDATA data)
		{
			ShooterHistoryRecordRes shooterHistoryRecordRes = new ShooterHistoryRecordRes();
			shooterHistoryRecordRes.decode(data.bytes);
			if (this.mShooterModels.ContainsKey((int)shooterHistoryRecordRes.id))
			{
				this.mShooterModels[(int)shooterHistoryRecordRes.id].UpdateRecords(shooterHistoryRecordRes.recordList);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.HorseGamblingShooterHistoryUpdate, this.mShooterModels[(int)shooterHistoryRecordRes.id], null, null, null);
			}
		}

		// Token: 0x0600B641 RID: 46657 RVA: 0x00291D28 File Offset: 0x00290128
		private void OnShooterStakeResponse(MsgDATA data)
		{
			stakeRes stakeRes = new stakeRes();
			stakeRes.decode(data.bytes);
			if (stakeRes.ret == 0U)
			{
				this.LeftSupply -= (int)stakeRes.num;
			}
			this.RequestStakeHistory();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.HorseGamblingShooterStakeResp, (int)stakeRes.ret, null, null, null);
		}

		// Token: 0x0600B642 RID: 46658 RVA: 0x00291D88 File Offset: 0x00290188
		private void OnSyncStateChanged(MsgDATA data)
		{
			BetHorsePhaseSycn betHorsePhaseSycn = new BetHorsePhaseSycn();
			betHorsePhaseSycn.decode(data.bytes);
			switch (betHorsePhaseSycn.phaseSycn)
			{
			case 2U:
				this.ClearDatas();
				break;
			case 4U:
				this.RequestGameHistory();
				this.RequestStakeHistory();
				this.RequestShooterRank();
				break;
			}
			this.TimeStamp = betHorsePhaseSycn.stamp;
			this.State = (BetHorsePhaseType)betHorsePhaseSycn.phaseSycn;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.HorseGamblingGameStateUpdate, (BetHorsePhaseType)betHorsePhaseSycn.phaseSycn, null, null, null);
		}

		// Token: 0x0600B643 RID: 46659 RVA: 0x00291E2C File Offset: 0x0029022C
		private void OnGameHistoryResponse(MsgDATA data)
		{
			BattleRecordRes battleRecordRes = new BattleRecordRes();
			battleRecordRes.decode(data.bytes);
			if (battleRecordRes.BattleRecordList != null)
			{
				this.mGameHistoryList.Clear();
				for (int i = battleRecordRes.BattleRecordList.Length - 1; i >= 0; i--)
				{
					this.mGameHistoryList.Add(new HorseGamblingHistoryModel(battleRecordRes.BattleRecordList[i]));
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.HorseGamblingGameHistoryUpdate, this.mGameHistoryList, null, null, null);
			}
		}

		// Token: 0x0600B644 RID: 46660 RVA: 0x00291EAC File Offset: 0x002902AC
		private void OnShooterRankListResponse(MsgDATA data)
		{
			shooterRankRes shooterRankRes = new shooterRankRes();
			shooterRankRes.decode(data.bytes);
			if (shooterRankRes.shooterRankList != null)
			{
				this.mShooterRankList.Clear();
				for (int i = shooterRankRes.shooterRankList.Length - 1; i >= 0; i--)
				{
					HorseGamblingRankModel item = new HorseGamblingRankModel(shooterRankRes.shooterRankList[i]);
					int j;
					for (j = 0; j < this.mShooterRankList.Count; j++)
					{
						if (this.mShooterRankList[j].WinRate <= item.WinRate)
						{
							this.mShooterRankList.Insert(j, item);
							break;
						}
					}
					if (j == this.mShooterRankList.Count)
					{
						this.mShooterRankList.Add(item);
					}
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.HorseGamblingRankListUpdate, this.mShooterRankList, null, null, null);
			}
		}

		// Token: 0x0600B645 RID: 46661 RVA: 0x00291F94 File Offset: 0x00290394
		private void OnStakeHistoryResponse(MsgDATA data)
		{
			StakeRecordRes stakeRecordRes = new StakeRecordRes();
			stakeRecordRes.decode(data.bytes);
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<BetHorseCfg>();
			Dictionary<int, object>.ValueCollection.Enumerator enumerator = table.Values.GetEnumerator();
			enumerator.MoveNext();
			BetHorseCfg betHorseCfg = (BetHorseCfg)enumerator.Current;
			this.LeftSupply = betHorseCfg.StakeMax;
			if (stakeRecordRes.StakeRecordList != null)
			{
				this.mStakeHistory.Clear();
				for (int i = 0; i < stakeRecordRes.StakeRecordList.Length; i++)
				{
					this.mStakeHistory.Add(new HorseGamblingStakeModel(stakeRecordRes.StakeRecordList[i]));
					if (stakeRecordRes.StakeRecordList[i].profit == -1 && betHorseCfg != null)
					{
						this.LeftSupply -= (int)stakeRecordRes.StakeRecordList[i].stakeNum;
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.HorseGamblingShooterStakeUpdate, this.mStakeHistory, null, null, null);
		}

		// Token: 0x0600B646 RID: 46662 RVA: 0x00292084 File Offset: 0x00290484
		private void OnSyncActivities(MsgDATA data)
		{
			SyncOpActivityDatas syncOpActivityDatas = new SyncOpActivityDatas();
			syncOpActivityDatas.decode(data.bytes);
			for (int i = 0; i < syncOpActivityDatas.datas.Length; i++)
			{
				if (syncOpActivityDatas.datas[i].tmpType == 5100U)
				{
					this.OnStateChange((OpActivityState)syncOpActivityDatas.datas[i].state);
					break;
				}
			}
		}

		// Token: 0x0600B647 RID: 46663 RVA: 0x002920EC File Offset: 0x002904EC
		private void OnSyncActivityStateChange(MsgDATA data)
		{
			SyncOpActivityStateChange syncOpActivityStateChange = new SyncOpActivityStateChange();
			syncOpActivityStateChange.decode(data.bytes);
			if (syncOpActivityStateChange.data.tmpType == 5100U)
			{
				this.OnStateChange((OpActivityState)syncOpActivityStateChange.data.state);
			}
		}

		// Token: 0x0600B648 RID: 46664 RVA: 0x00292131 File Offset: 0x00290531
		private void OnStateChange(OpActivityState state)
		{
			if (state == OpActivityState.OAS_IN)
			{
				this.mIsOpen = true;
			}
			else
			{
				this.mIsOpen = false;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.HorseGamblingStateUpdate, null, null, null, null);
		}

		// Token: 0x0600B649 RID: 46665 RVA: 0x00292160 File Offset: 0x00290560
		private void OnBuyBulletRes(MsgDATA data)
		{
			WorldMallBuyRet worldMallBuyRet = new WorldMallBuyRet();
			worldMallBuyRet.decode(data.bytes);
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<BetHorseCfg>();
			Dictionary<int, object>.ValueCollection.Enumerator enumerator = table.Values.GetEnumerator();
			enumerator.MoveNext();
			BetHorseCfg betHorseCfg = (BetHorseCfg)enumerator.Current;
			if (betHorseCfg != null && (ulong)worldMallBuyRet.mallitemid == (ulong)((long)betHorseCfg.BulletMallItemId))
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.HorseGamblingBuyBulletResponse, (int)worldMallBuyRet.code, null, null, null);
			}
		}

		// Token: 0x04006708 RID: 26376
		private readonly List<IHorseGamblingStakeModel> mStakeHistory = new List<IHorseGamblingStakeModel>();

		// Token: 0x04006709 RID: 26377
		private readonly List<HorseGamblingHistoryModel> mGameHistoryList = new List<HorseGamblingHistoryModel>();

		// Token: 0x0400670A RID: 26378
		private readonly List<HorseGamblingRankModel> mShooterRankList = new List<HorseGamblingRankModel>();

		// Token: 0x0400670B RID: 26379
		private readonly Dictionary<int, HorseGamblingShooterModel> mShooterModels = new Dictionary<int, HorseGamblingShooterModel>();
	}
}
