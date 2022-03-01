using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x0200168E RID: 5774
	public class HorseGamblingRecordFrame : ClientFrame
	{
		// Token: 0x0600E2DF RID: 58079 RVA: 0x003A4680 File Offset: 0x003A2A80
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/HorseGambling/HorseGamblingRecordFrame";
		}

		// Token: 0x0600E2E0 RID: 58080 RVA: 0x003A4688 File Offset: 0x003A2A88
		protected override void _OnOpenFrame()
		{
			HorseGamblingRecordFrameParam horseGamblingRecordFrameParam = (HorseGamblingRecordFrameParam)this.userData;
			if (horseGamblingRecordFrameParam != null)
			{
				this.mRecordType = horseGamblingRecordFrameParam.RecordType;
				this.mParam = horseGamblingRecordFrameParam.Param;
			}
			this.mView = this.frame.GetComponent<HorseGamblingRecordView>();
			this.BindEvents();
			if (this.mView != null)
			{
				List<string> list = new List<string>();
				int defaultSelectId = 0;
				EHorseGamblingRecord ehorseGamblingRecord = this.mRecordType;
				if (ehorseGamblingRecord != EHorseGamblingRecord.Stake)
				{
					if (ehorseGamblingRecord != EHorseGamblingRecord.HistoryAndRank)
					{
						if (ehorseGamblingRecord == EHorseGamblingRecord.ShooterHistory)
						{
							list.Add(this.mView.ShooterRecordToggleName);
						}
					}
					else
					{
						defaultSelectId = this.mParam;
						list.Add(this.mView.GameRecordToggleName);
						list.Add(this.mView.ShooterRankToggleName);
					}
				}
				else
				{
					list.Add(this.mView.StakeToggleName);
				}
				this.mView.Init(list.ToArray(), new ComTabGroup.OnToggleValueChanged(this.OnSelectTab), new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible), new ComUIListScript.OnItemUpdateDelegate(this.OnItemVisible), new UnityAction(this.OnClose), defaultSelectId);
			}
		}

		// Token: 0x0600E2E1 RID: 58081 RVA: 0x003A47AC File Offset: 0x003A2BAC
		protected override void _OnCloseFrame()
		{
			if (this.mView != null)
			{
				this.mView.Dispose();
				this.mView = null;
			}
			this.UnBindEvents();
		}

		// Token: 0x0600E2E2 RID: 58082 RVA: 0x003A47D7 File Offset: 0x003A2BD7
		private void OnClose()
		{
			base.Close(false);
		}

		// Token: 0x0600E2E3 RID: 58083 RVA: 0x003A47E0 File Offset: 0x003A2BE0
		private void OnItemVisible(ComUIListElementScript item)
		{
			EHorseGamblingRecord ehorseGamblingRecord = this.mRecordType;
			if (ehorseGamblingRecord != EHorseGamblingRecord.Stake)
			{
				if (ehorseGamblingRecord != EHorseGamblingRecord.HistoryAndRank)
				{
					if (ehorseGamblingRecord == EHorseGamblingRecord.ShooterHistory)
					{
						this.InitShooterHistoryItem(item);
					}
				}
				else if (this.mSelectId == 0)
				{
					this.InitGameHistoryItem(item);
				}
				else
				{
					this.InitShooterRankItem(item);
				}
			}
			else
			{
				this.InitStakeItem(item);
			}
		}

		// Token: 0x0600E2E4 RID: 58084 RVA: 0x003A484C File Offset: 0x003A2C4C
		private void InitStakeItem(ComUIListElementScript item)
		{
			HorseGamblingStakeRecordItem component = item.GetComponent<HorseGamblingStakeRecordItem>();
			List<IHorseGamblingStakeModel> stakeHistory = DataManager<HorseGamblingDataManager>.GetInstance().GetStakeHistory();
			if (this.mView != null && component != null && item.m_index < stakeHistory.Count)
			{
				IHorseGamblingStakeModel horseGamblingStakeModel = stakeHistory[item.m_index];
				string name = horseGamblingStakeModel.ShooterName;
				string imagePath = DataManager<HorseGamblingDataManager>.GetInstance().GetShooterIconPath(horseGamblingStakeModel.ShooterId);
				if (DataManager<HorseGamblingDataManager>.GetInstance().State == BetHorsePhaseType.PHASE_TYPE_STAKE && horseGamblingStakeModel.ShooterId == DataManager<HorseGamblingDataManager>.GetInstance().UnknownShooterId && horseGamblingStakeModel.Profit == -1)
				{
					BetHorseShooter tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BetHorseShooter>(0, string.Empty, string.Empty);
					if (tableItem != null)
					{
						name = tableItem.Name;
						imagePath = tableItem.IconPath;
					}
				}
				component.Init(horseGamblingStakeModel.GameId.ToString(), name, horseGamblingStakeModel.Odds.ToString(), horseGamblingStakeModel.Stake.ToString(), horseGamblingStakeModel.Profit, imagePath, (item.m_index % 2 != 0) ? this.mView.ItemBg1 : this.mView.ItemBg2);
			}
		}

		// Token: 0x0600E2E5 RID: 58085 RVA: 0x003A4998 File Offset: 0x003A2D98
		private void InitGameHistoryItem(ComUIListElementScript item)
		{
			HorseGamblingGameRecordItem component = item.GetComponent<HorseGamblingGameRecordItem>();
			List<HorseGamblingHistoryModel> gameHistory = DataManager<HorseGamblingDataManager>.GetInstance().GetGameHistory();
			if (this.mView != null && component != null && item.m_index < gameHistory.Count)
			{
				HorseGamblingHistoryModel horseGamblingHistoryModel = gameHistory[item.m_index];
				component.Init(horseGamblingHistoryModel.GameId.ToString(), horseGamblingHistoryModel.ChampionName, horseGamblingHistoryModel.Odds.ToString(), horseGamblingHistoryModel.MaxProfit.ToString(), DataManager<HorseGamblingDataManager>.GetInstance().GetShooterIconPath(horseGamblingHistoryModel.ShooterId), (item.m_index % 2 != 0) ? this.mView.ItemBg1 : this.mView.ItemBg2);
			}
		}

		// Token: 0x0600E2E6 RID: 58086 RVA: 0x003A4A7C File Offset: 0x003A2E7C
		private void InitShooterRankItem(ComUIListElementScript item)
		{
			HorseGamblingGameRecordItem component = item.GetComponent<HorseGamblingGameRecordItem>();
			List<HorseGamblingRankModel> shooterRank = DataManager<HorseGamblingDataManager>.GetInstance().GetShooterRank();
			if (this.mView != null && component != null && item.m_index < shooterRank.Count)
			{
				HorseGamblingRankModel horseGamblingRankModel = shooterRank[item.m_index];
				component.Init((item.m_index + 1).ToString(), horseGamblingRankModel.ShooterName, horseGamblingRankModel.BattleNum.ToString(), string.Format(TR.Value("horse_gambling_shooter_win_rate"), horseGamblingRankModel.WinRate), DataManager<HorseGamblingDataManager>.GetInstance().GetShooterIconPath(horseGamblingRankModel.ShooterId), (item.m_index % 2 != 0) ? this.mView.ItemBg1 : this.mView.ItemBg2);
			}
		}

		// Token: 0x0600E2E7 RID: 58087 RVA: 0x003A4B64 File Offset: 0x003A2F64
		private void InitShooterHistoryItem(ComUIListElementScript item)
		{
			HorseGamblingShooterHistoryItem component = item.GetComponent<HorseGamblingShooterHistoryItem>();
			ShooterRecord[] shooterHistory = DataManager<HorseGamblingDataManager>.GetInstance().GetShooterHistory(this.mParam);
			if (this.mView != null && component != null && item.m_index < shooterHistory.Length)
			{
				BetHorseShooter tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BetHorseShooter>(this.mParam, string.Empty, string.Empty);
				if (tableItem == null)
				{
					return;
				}
				int num = shooterHistory.Length - 1 - item.m_index;
				if (num >= 0 && num < shooterHistory.Length)
				{
					ShooterRecord shooterRecord = shooterHistory[num];
					component.Init(shooterRecord.coutrId.ToString(), tableItem.Name, (shooterRecord.odds / 10000f).ToString(), DataManager<HorseGamblingDataManager>.GetInstance().GetShooterIconPath(this.mParam), shooterRecord.result == 1U, (item.m_index % 2 != 0) ? this.mView.ItemBg1 : this.mView.ItemBg2);
				}
			}
		}

		// Token: 0x0600E2E8 RID: 58088 RVA: 0x003A4C78 File Offset: 0x003A3078
		private void OnSelectTab(bool value, int id)
		{
			if (value)
			{
				EHorseGamblingRecord ehorseGamblingRecord = this.mRecordType;
				if (ehorseGamblingRecord != EHorseGamblingRecord.Stake)
				{
					if (ehorseGamblingRecord != EHorseGamblingRecord.HistoryAndRank)
					{
						if (ehorseGamblingRecord == EHorseGamblingRecord.ShooterHistory)
						{
							if (this.mView != null)
							{
								ShooterRecord[] shooterHistory = DataManager<HorseGamblingDataManager>.GetInstance().GetShooterHistory(this.mParam);
								int dataCount = 0;
								if (shooterHistory != null)
								{
									dataCount = shooterHistory.Length;
								}
								this.mView.SetData(this.mView.ShooterRecordToggleName, this.mView.ShooterRecordTitleNames, dataCount, this.mView.ShooterRecordItemPrefab);
							}
						}
					}
					else if (this.mView != null)
					{
						this.mSelectId = id;
						int count = DataManager<HorseGamblingDataManager>.GetInstance().GetGameHistory().Count;
						string titleName = this.mView.GameRecordToggleName;
						string itemPrefabPath = this.mView.GameRecordItemPrefab;
						List<string> titles = this.mView.GameRecordTitleNames;
						if (id == 1)
						{
							count = DataManager<HorseGamblingDataManager>.GetInstance().GetShooterRank().Count;
							titleName = this.mView.ShooterRankToggleName;
							itemPrefabPath = this.mView.ShooterRankItemPrefab;
							titles = this.mView.ShooterRankTitleNames;
						}
						this.mView.SetData(titleName, titles, count, itemPrefabPath);
					}
				}
				else if (this.mView != null)
				{
					this.mView.SetData(this.mView.StakeToggleName, this.mView.StakeTitleNames, DataManager<HorseGamblingDataManager>.GetInstance().GetStakeHistory().Count, this.mView.StakeItemPrefab);
				}
			}
		}

		// Token: 0x0600E2E9 RID: 58089 RVA: 0x003A4E04 File Offset: 0x003A3204
		private void BindEvents()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.HorseGamblingShooterStakeUpdate, new ClientEventSystem.UIEventHandler(this.OnStakeHistoryUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.HorseGamblingGameHistoryUpdate, new ClientEventSystem.UIEventHandler(this.OnGameHistoryUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.HorseGamblingRankListUpdate, new ClientEventSystem.UIEventHandler(this.OnRankListUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.HorseGamblingShooterHistoryUpdate, new ClientEventSystem.UIEventHandler(this.OnShooterHistoryUpdate));
		}

		// Token: 0x0600E2EA RID: 58090 RVA: 0x003A4E80 File Offset: 0x003A3280
		private void UnBindEvents()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.HorseGamblingShooterStakeUpdate, new ClientEventSystem.UIEventHandler(this.OnStakeHistoryUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.HorseGamblingGameHistoryUpdate, new ClientEventSystem.UIEventHandler(this.OnGameHistoryUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.HorseGamblingRankListUpdate, new ClientEventSystem.UIEventHandler(this.OnRankListUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.HorseGamblingShooterHistoryUpdate, new ClientEventSystem.UIEventHandler(this.OnShooterHistoryUpdate));
		}

		// Token: 0x0600E2EB RID: 58091 RVA: 0x003A4EFC File Offset: 0x003A32FC
		private void OnGameHistoryUpdate(UIEvent data)
		{
			if (this.mRecordType == EHorseGamblingRecord.HistoryAndRank && this.mSelectId == 0 && this.mView != null && data != null && data.Param1 != null)
			{
				List<HorseGamblingHistoryModel> list = (List<HorseGamblingHistoryModel>)data.Param1;
				if (list != null)
				{
					this.mView.UpdateData(list.Count);
				}
			}
		}

		// Token: 0x0600E2EC RID: 58092 RVA: 0x003A4F68 File Offset: 0x003A3368
		private void OnRankListUpdate(UIEvent data)
		{
			if (this.mRecordType == EHorseGamblingRecord.HistoryAndRank && this.mSelectId == 1 && this.mView != null && data != null && data.Param1 != null)
			{
				List<HorseGamblingRankModel> list = (List<HorseGamblingRankModel>)data.Param1;
				if (list != null)
				{
					this.mView.UpdateData(list.Count);
				}
			}
		}

		// Token: 0x0600E2ED RID: 58093 RVA: 0x003A4FD4 File Offset: 0x003A33D4
		private void OnStakeHistoryUpdate(UIEvent data)
		{
			if (this.mRecordType == EHorseGamblingRecord.Stake && this.mView != null && data != null && data.Param1 != null)
			{
				List<IHorseGamblingStakeModel> list = (List<IHorseGamblingStakeModel>)data.Param1;
				if (list != null)
				{
					this.mView.UpdateData(list.Count);
				}
			}
		}

		// Token: 0x0600E2EE RID: 58094 RVA: 0x003A5034 File Offset: 0x003A3434
		private void OnShooterHistoryUpdate(UIEvent data)
		{
			if (this.mRecordType == EHorseGamblingRecord.ShooterHistory && this.mView != null && data != null && data.Param1 != null)
			{
				IHorseGamblingShooterModel horseGamblingShooterModel = (IHorseGamblingShooterModel)data.Param1;
				if (horseGamblingShooterModel != null && horseGamblingShooterModel.Records != null)
				{
					this.mView.UpdateData(horseGamblingShooterModel.Records.Length);
				}
			}
		}

		// Token: 0x040087CB RID: 34763
		private EHorseGamblingRecord mRecordType;

		// Token: 0x040087CC RID: 34764
		private HorseGamblingRecordView mView;

		// Token: 0x040087CD RID: 34765
		private int mParam;

		// Token: 0x040087CE RID: 34766
		private int mSelectId;
	}
}
