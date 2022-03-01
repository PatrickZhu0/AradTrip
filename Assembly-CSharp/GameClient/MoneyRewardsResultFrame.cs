using System;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020017EF RID: 6127
	internal class MoneyRewardsResultFrame : ClientFrame
	{
		// Token: 0x0600F179 RID: 61817 RVA: 0x004111B2 File Offset: 0x0040F5B2
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/MoneyRewards/MoneyRewardsResultFrame";
		}

		// Token: 0x0600F17A RID: 61818 RVA: 0x004111B9 File Offset: 0x0040F5B9
		public static void CommandOpen(object argv)
		{
			if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MoneyRewardsResultFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<MoneyRewardsResultFrame>(FrameLayer.Middle, null, string.Empty);
			}
		}

		// Token: 0x0600F17B RID: 61819 RVA: 0x004111E0 File Offset: 0x0040F5E0
		protected sealed override void _OnOpenFrame()
		{
			base._AddButton("Close", delegate
			{
				this.frameMgr.CloseFrame<MoneyRewardsResultFrame>(this, false);
			});
			if (null != this.comTime)
			{
				ComTimeTick comTimeTick = this.comTime;
				comTimeTick.onTick = (UnityAction<uint>)Delegate.Combine(comTimeTick.onTick, new UnityAction<uint>(this._OnTick));
			}
			this._RegisterEvent();
			this._UpdateTimeTick();
			this._UpdateStage();
			this._UpdateInfoList();
			this._UpdateWatchInfos();
			this._UpdateChampAwardsText();
		}

		// Token: 0x0600F17C RID: 61820 RVA: 0x00411260 File Offset: 0x0040F660
		private void _RegisterEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMoneyRewardsResultChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsResultChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMoneyRewardsStatusChanged, new ClientEventSystem.UIEventHandler(this._OnOnMoneyRewardsStatusChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMoneyRewardsBattleInfoChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsBattleInfoChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMoneyRewardsRcdStatusChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsRcdStatusChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMoneyRewardsAwardsChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsAwardsChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMoneyRewardsAwardListChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsAwardListChanged));
		}

		// Token: 0x0600F17D RID: 61821 RVA: 0x0041130F File Offset: 0x0040F70F
		private void _OnMoneyRewardsResultChanged(UIEvent uiEvent)
		{
			this._UpdateInfoList();
		}

		// Token: 0x0600F17E RID: 61822 RVA: 0x00411317 File Offset: 0x0040F717
		private void _OnOnMoneyRewardsStatusChanged(UIEvent uiEvent)
		{
			this._UpdateStage();
			this._UpdateTimeTick();
		}

		// Token: 0x0600F17F RID: 61823 RVA: 0x00411325 File Offset: 0x0040F725
		private void _OnMoneyRewardsBattleInfoChanged(UIEvent uiEvent)
		{
			this._UpdateWatchInfos();
		}

		// Token: 0x0600F180 RID: 61824 RVA: 0x0041132D File Offset: 0x0040F72D
		private void _OnMoneyRewardsRcdStatusChanged(UIEvent uiEvent)
		{
			this._UpdateWatchInfos();
		}

		// Token: 0x0600F181 RID: 61825 RVA: 0x00411335 File Offset: 0x0040F735
		private void _OnMoneyRewardsAwardsChanged(UIEvent uiEvent)
		{
			this._UpdateChampAwardsText();
		}

		// Token: 0x0600F182 RID: 61826 RVA: 0x0041133D File Offset: 0x0040F73D
		private void _OnMoneyRewardsAwardListChanged(UIEvent uiEvent)
		{
			this._UpdateChampAwardsText();
		}

		// Token: 0x0600F183 RID: 61827 RVA: 0x00411348 File Offset: 0x0040F748
		private void _UnRegisterEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMoneyRewardsResultChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsResultChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMoneyRewardsStatusChanged, new ClientEventSystem.UIEventHandler(this._OnOnMoneyRewardsStatusChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMoneyRewardsBattleInfoChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsBattleInfoChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMoneyRewardsRcdStatusChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsRcdStatusChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMoneyRewardsAwardsChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsAwardsChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMoneyRewardsAwardListChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsAwardListChanged));
		}

		// Token: 0x0600F184 RID: 61828 RVA: 0x004113F8 File Offset: 0x0040F7F8
		private void _UpdateStage()
		{
			if (null != this.comState)
			{
				MoneyRewardsStatus eMoneyRewardsStatus = DataManager<MoneyRewardsDataManager>.GetInstance().eMoneyRewardsStatus;
				switch (eMoneyRewardsStatus + 1)
				{
				case MoneyRewardsStatus.MRS_READY:
					this.comState.Key = "finish";
					break;
				case MoneyRewardsStatus.MRS_8_RACE:
					this.comState.Key = "ready";
					break;
				case MoneyRewardsStatus.MRS_PRE_4_RACE:
					this.comState.Key = "8level";
					break;
				case MoneyRewardsStatus.MRS_4_RACE:
					this.comState.Key = "4pre_level";
					break;
				case MoneyRewardsStatus.MRS_2_RACE:
					this.comState.Key = "4level";
					break;
				case MoneyRewardsStatus.MRS_RACE:
					this.comState.Key = "2level";
					break;
				case MoneyRewardsStatus.MRS_END:
					this.comState.Key = "1level";
					break;
				case (MoneyRewardsStatus)7:
					this.comState.Key = "finish";
					break;
				}
			}
		}

		// Token: 0x0600F185 RID: 61829 RVA: 0x004114F6 File Offset: 0x0040F8F6
		[UIEventHandle("Go")]
		private void _OnClickGoMail()
		{
			Singleton<ClientSystemManager>.instance.OpenFrame<MailNewFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600F186 RID: 61830 RVA: 0x0041150A File Offset: 0x0040F90A
		private void _UpdateTimeTick()
		{
			if (null != this.comTime)
			{
				this.comTime.SetEndTime(DataManager<MoneyRewardsDataManager>.GetInstance().StatusEndTime);
			}
		}

		// Token: 0x0600F187 RID: 61831 RVA: 0x00411534 File Offset: 0x0040F934
		private void PlayReplay(ulong a_raceID, bool normal = true)
		{
			string filename = a_raceID.ToString();
			if (DataManager<TeamDataManager>.GetInstance().HasTeam())
			{
				this.ShowNotify(ReplayErrorCode.HAS_TEAM);
				return;
			}
			if (Singleton<ReplayServer>.GetInstance().HasReplay(filename))
			{
				ReplayErrorCode replayErrorCode = Singleton<ReplayServer>.GetInstance().StartReplay(filename, ReplayPlayFrom.MONEY_REWARD, false, false, false);
				if (replayErrorCode == ReplayErrorCode.SUCCEED)
				{
					this.frameMgr.CloseFrame<MoneyRewardsResultFrame>(this, false);
					DataManager<SeasonDataManager>.GetInstance().NotifyVideoPlayed(a_raceID);
				}
				else
				{
					Singleton<ReplayServer>.GetInstance().Clear();
				}
				this.ShowNotify(replayErrorCode);
			}
			else if (normal)
			{
				this.ShowNotify(ReplayErrorCode.FILE_NOT_FOUND);
			}
			else
			{
				this.StartDownloadReplayFile(a_raceID);
			}
		}

		// Token: 0x0600F188 RID: 61832 RVA: 0x004115D8 File Offset: 0x0040F9D8
		private void ShowNotify(ReplayErrorCode code)
		{
			MoneyRewardsDataManager.ShowErrorNotify(code);
		}

		// Token: 0x0600F189 RID: 61833 RVA: 0x004115E0 File Offset: 0x0040F9E0
		private void StartDownloadReplayFile(ulong a_raceID)
		{
			string text = a_raceID.ToString();
			if (!DataManager<MoneyRewardsDataManager>.GetInstance().isRcdInQueue(a_raceID))
			{
				DataManager<MoneyRewardsDataManager>.GetInstance().downloadRcd(a_raceID, delegate(ulong raceId)
				{
					string filename = raceId.ToString();
					ReplayErrorCode replayErrorCode = Singleton<ReplayServer>.GetInstance().StartReplay(filename, ReplayPlayFrom.MONEY_REWARD, false, false, false);
					if (replayErrorCode == ReplayErrorCode.SUCCEED)
					{
						this.frameMgr.CloseFrame<MoneyRewardsResultFrame>(this, false);
						DataManager<SeasonDataManager>.GetInstance().NotifyVideoPlayed(a_raceID);
					}
					else
					{
						Singleton<ReplayServer>.GetInstance().Clear();
					}
					this.ShowNotify(replayErrorCode);
				}, false);
			}
		}

		// Token: 0x0600F18A RID: 61834 RVA: 0x00411648 File Offset: 0x0040FA48
		private void _OpenObserverRecord(CLPremiumLeagueBattle battle)
		{
			if (battle == null || battle.fighter1 == null || battle.fighter2 == null)
			{
				return;
			}
			if (DataManager<TeamDataManager>.GetInstance().HasTeam())
			{
				this.ShowNotify(ReplayErrorCode.HAS_TEAM);
				return;
			}
			int indexByRoleId = DataManager<MoneyRewardsDataManager>.GetInstance().getIndexByRoleId(DataManager<PlayerBaseData>.GetInstance().RoleID);
			bool flag = false;
			DataManager<MoneyRewardsDataManager>.GetInstance().GetNextVsData(indexByRoleId, DataManager<MoneyRewardsDataManager>.GetInstance().Status, ref flag);
			if (flag)
			{
				SystemNotifyManager.SystemNotify(9019, string.Empty);
				return;
			}
			if (MonoSingleton<NetManager>.instance.ConnectToRelayServer(battle.relayAddr.ip, battle.relayAddr.port, ClientApplication.playerinfo.accid, 4000U))
			{
				if (MonoSingleton<NetManager>.instance != null)
				{
					RelaySvrObserveReq cmd = new RelaySvrObserveReq
					{
						accid = ClientApplication.playerinfo.accid,
						roleId = DataManager<PlayerBaseData>.GetInstance().RoleID,
						raceId = battle.raceId,
						startFrame = 0U
					};
					MonoSingleton<NetManager>.instance.SendCommand<RelaySvrObserveReq>(ServerType.RELAY_SERVER, cmd);
				}
				if (Singleton<ReplayServer>.GetInstance() != null)
				{
					Singleton<ReplayServer>.GetInstance().LiveShowServerAddr = battle.relayAddr;
				}
			}
			if (this.frameMgr != null)
			{
				this.frameMgr.CloseFrame<MoneyRewardsResultFrame>(this, false);
			}
		}

		// Token: 0x0600F18B RID: 61835 RVA: 0x0041178C File Offset: 0x0040FB8C
		private void _WatchRecord(CLPremiumLeagueBattle battle)
		{
			if (battle != null && battle.fighter1 != null && battle.fighter2 != null)
			{
				int indexByRoleId = DataManager<MoneyRewardsDataManager>.GetInstance().getIndexByRoleId(DataManager<PlayerBaseData>.GetInstance().RoleID);
				bool flag = false;
				DataManager<MoneyRewardsDataManager>.GetInstance().GetNextVsData(indexByRoleId, DataManager<MoneyRewardsDataManager>.GetInstance().Status, ref flag);
				if (flag)
				{
					SystemNotifyManager.SystemNotify(9019, string.Empty);
					return;
				}
				this.PlayReplay(battle.raceId, false);
			}
		}

		// Token: 0x0600F18C RID: 61836 RVA: 0x0041180C File Offset: 0x0040FC0C
		private void _PopWatchBattleErrMsg(MoneyRewardsResultFrame.WatchBattleErrorCode code)
		{
			if (code == MoneyRewardsResultFrame.WatchBattleErrorCode.WBEC_NO_RECORD)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("money_rewards_watch_battle_error_no_record"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			else if (code == MoneyRewardsResultFrame.WatchBattleErrorCode.WBEC_IN_FIGHTER)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("money_rewards_watch_battle_error_in_fighter"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			else if (code == MoneyRewardsResultFrame.WatchBattleErrorCode.WBEC_UN_START)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("money_rewards_watch_battle_error_un_start"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
		}

		// Token: 0x0600F18D RID: 61837 RVA: 0x0041186C File Offset: 0x0040FC6C
		private void _UpdateInfoList()
		{
			if (null != this.comRewardsInfoList)
			{
				for (int i = 0; i < this.comRewardsInfoList.results.Length; i++)
				{
					ComMoneyRewardsResultInfo comMoneyRewardsResultInfo = this.comRewardsInfoList.results[i];
					if (null != comMoneyRewardsResultInfo && i >= 0 && i < DataManager<MoneyRewardsDataManager>.GetInstance().ResultDatas.Length)
					{
						comMoneyRewardsResultInfo.SetValue(DataManager<MoneyRewardsDataManager>.GetInstance().ResultDatas[i]);
					}
				}
				if (this.comRewardsInfoList.results.Length == 9)
				{
					ComMoneyRewardsResultInfo comMoneyRewardsResultInfo2 = this.comRewardsInfoList.results[this.comRewardsInfoList.results.Length - 1];
					if (null != comMoneyRewardsResultInfo2)
					{
						comMoneyRewardsResultInfo2.SetValue(DataManager<MoneyRewardsDataManager>.GetInstance().getChampionData);
					}
				}
				int[] array = new int[]
				{
					0,
					7,
					3,
					4,
					2,
					5,
					1,
					6
				};
				for (int j = 0; j < this.comRewardsInfoList.result4s.Length; j++)
				{
					ComMoneyRewardsResultInfo comMoneyRewardsResultInfo3 = this.comRewardsInfoList.result4s[j];
					if (null != comMoneyRewardsResultInfo3)
					{
						int num = array[2 * j];
						int num2 = array[2 * j + 1];
						ComMoneyRewardsResultData comMoneyRewardsResultData = DataManager<MoneyRewardsDataManager>.GetInstance().ResultDatas[num];
						ComMoneyRewardsResultData comMoneyRewardsResultData2 = DataManager<MoneyRewardsDataManager>.GetInstance().ResultDatas[num2];
						int num3 = (comMoneyRewardsResultData != null) ? comMoneyRewardsResultData.winTimes : 0;
						int num4 = (comMoneyRewardsResultData2 != null) ? comMoneyRewardsResultData2.winTimes : 0;
						ComMoneyRewardsResultData value;
						if (num3 > 0)
						{
							value = comMoneyRewardsResultData;
						}
						else if (num4 > 0)
						{
							value = comMoneyRewardsResultData2;
						}
						else
						{
							value = null;
						}
						comMoneyRewardsResultInfo3.SetValue(value);
					}
				}
				for (int k = 0; k < this.comRewardsInfoList.result2s.Length; k++)
				{
					ComMoneyRewardsResultInfo comMoneyRewardsResultInfo4 = this.comRewardsInfoList.result2s[k];
					if (null != comMoneyRewardsResultInfo4)
					{
						ComMoneyRewardsResultData value2 = null;
						for (int l = 0; l < array.Length / 2; l++)
						{
							int num5 = 4 * k + l;
							ComMoneyRewardsResultData comMoneyRewardsResultData3 = DataManager<MoneyRewardsDataManager>.GetInstance().ResultDatas[array[num5]];
							if (comMoneyRewardsResultData3 != null && comMoneyRewardsResultData3.winTimes >= 2)
							{
								value2 = comMoneyRewardsResultData3;
							}
						}
						comMoneyRewardsResultInfo4.SetValue(value2);
					}
				}
			}
		}

		// Token: 0x0600F18E RID: 61838 RVA: 0x00411AB0 File Offset: 0x0040FEB0
		private void _UpdateChampAwardsText()
		{
			if (null != this.champAwards)
			{
				int champAward = DataManager<MoneyRewardsDataManager>.GetInstance().ChampAward;
				this.champAwards.text = TR.Value("money_rewards_champ_awards_text", champAward);
			}
		}

		// Token: 0x0600F18F RID: 61839 RVA: 0x00411AF4 File Offset: 0x0040FEF4
		private void _UpdateWatchInfos()
		{
			int[] array = new int[]
			{
				0,
				7,
				3,
				4,
				2,
				5,
				1,
				6
			};
			for (int i = 0; i < array.Length / 2; i++)
			{
				if (i < this.comRewardsInfoList.buttons.Length)
				{
					int num = array[2 * i];
					int num2 = array[2 * i + 1];
					Button button = this.comRewardsInfoList.buttons[i];
					if (null != button)
					{
						button.onClick.RemoveAllListeners();
						button.CustomActive(true);
					}
					StateController stateController = this.comRewardsInfoList.btnWatchStatus[i];
					CLPremiumLeagueBattle battleInfo = null;
					ComMoneyRewardsResultData comMoneyRewardsResultData = DataManager<MoneyRewardsDataManager>.GetInstance().ResultDatas[num];
					ComMoneyRewardsResultData comMoneyRewardsResultData2 = DataManager<MoneyRewardsDataManager>.GetInstance().ResultDatas[num2];
					if (comMoneyRewardsResultData != null && comMoneyRewardsResultData2 != null)
					{
						battleInfo = DataManager<MoneyRewardsDataManager>.GetInstance().GetRelationBattleInfo(comMoneyRewardsResultData.recordId, PremiumLeagueStatus.PLS_FINAL_EIGHT);
					}
					if (null != stateController)
					{
						switch (DataManager<MoneyRewardsDataManager>.GetInstance().Status)
						{
						case PremiumLeagueStatus.PLS_INIT:
						case PremiumLeagueStatus.PLS_ENROLL:
						case PremiumLeagueStatus.PLS_PRELIMINAY:
						case PremiumLeagueStatus.PLS_FINAL_EIGHT_PREPARE:
							stateController.Key = this.mUnStart;
							if (null != button)
							{
								button.onClick.AddListener(delegate()
								{
									this._PopWatchBattleErrMsg(MoneyRewardsResultFrame.WatchBattleErrorCode.WBEC_UN_START);
								});
							}
							break;
						case PremiumLeagueStatus.PLS_FINAL_EIGHT:
						case PremiumLeagueStatus.PLS_FINAL_FOUR:
						case PremiumLeagueStatus.PLS_FINAL:
						case PremiumLeagueStatus.PLS_FINAL_WAIT_CLEAR:
							if (battleInfo == null)
							{
								stateController.Key = this.mDisable;
								if (null != button)
								{
									button.onClick.AddListener(delegate()
									{
										this._PopWatchBattleErrMsg(MoneyRewardsResultFrame.WatchBattleErrorCode.WBEC_NO_RECORD);
									});
								}
							}
							else if (battleInfo.isEnd != 0)
							{
								stateController.Key = this.mNormal;
								if (null != button)
								{
									button.onClick.AddListener(delegate()
									{
										this._WatchRecord(battleInfo);
									});
								}
							}
							else
							{
								stateController.Key = this.mRunning;
								if (null != button)
								{
									button.onClick.AddListener(delegate()
									{
										this._OpenObserverRecord(battleInfo);
									});
								}
							}
							break;
						}
					}
				}
			}
			int[] array2 = new int[]
			{
				0,
				7,
				3,
				4,
				2,
				5,
				1,
				6
			};
			for (int j = 0; j < array2.Length / 4; j++)
			{
				if (4 + j < this.comRewardsInfoList.buttons.Length)
				{
					Button button2 = this.comRewardsInfoList.buttons[4 + j];
					if (null != button2)
					{
						button2.onClick.RemoveAllListeners();
						button2.CustomActive(true);
					}
					StateController stateController2 = this.comRewardsInfoList.btnWatchStatus[4 + j];
					CLPremiumLeagueBattle battleInfo = null;
					for (int k = 0; k < 4; k++)
					{
						int num3 = array2[4 * j + k];
						ComMoneyRewardsResultData comMoneyRewardsResultData3 = DataManager<MoneyRewardsDataManager>.GetInstance().ResultDatas[num3];
						if (comMoneyRewardsResultData3 != null)
						{
							battleInfo = DataManager<MoneyRewardsDataManager>.GetInstance().GetRelationBattleInfo(comMoneyRewardsResultData3.recordId, PremiumLeagueStatus.PLS_FINAL_FOUR);
							if (battleInfo != null)
							{
								break;
							}
						}
					}
					if (null != stateController2)
					{
						switch (DataManager<MoneyRewardsDataManager>.GetInstance().Status)
						{
						case PremiumLeagueStatus.PLS_INIT:
						case PremiumLeagueStatus.PLS_ENROLL:
						case PremiumLeagueStatus.PLS_PRELIMINAY:
						case PremiumLeagueStatus.PLS_FINAL_EIGHT_PREPARE:
						case PremiumLeagueStatus.PLS_FINAL_EIGHT:
							stateController2.Key = this.mUnStart;
							if (null != button2)
							{
								button2.onClick.AddListener(delegate()
								{
									this._PopWatchBattleErrMsg(MoneyRewardsResultFrame.WatchBattleErrorCode.WBEC_UN_START);
								});
							}
							break;
						case PremiumLeagueStatus.PLS_FINAL_FOUR:
						case PremiumLeagueStatus.PLS_FINAL:
						case PremiumLeagueStatus.PLS_FINAL_WAIT_CLEAR:
							if (battleInfo == null)
							{
								stateController2.Key = this.mDisable;
								if (null != button2)
								{
									button2.onClick.AddListener(delegate()
									{
										this._PopWatchBattleErrMsg(MoneyRewardsResultFrame.WatchBattleErrorCode.WBEC_NO_RECORD);
									});
								}
							}
							else if (battleInfo.isEnd != 0)
							{
								stateController2.Key = this.mNormal;
								if (null != button2)
								{
									button2.onClick.AddListener(delegate()
									{
										this._WatchRecord(battleInfo);
									});
								}
							}
							else
							{
								stateController2.Key = this.mRunning;
								if (null != button2)
								{
									button2.onClick.AddListener(delegate()
									{
										this._OpenObserverRecord(battleInfo);
									});
								}
							}
							break;
						}
					}
				}
			}
			if (this.comRewardsInfoList.buttons.Length > 0)
			{
				Button button3 = this.comRewardsInfoList.buttons[this.comRewardsInfoList.buttons.Length - 1];
				if (null != button3)
				{
					button3.onClick.RemoveAllListeners();
					button3.CustomActive(true);
				}
				CLPremiumLeagueBattle battleInfo = DataManager<MoneyRewardsDataManager>.GetInstance().GetChampionRelationInfo();
				StateController stateController3 = this.comRewardsInfoList.btnWatchStatus[this.comRewardsInfoList.buttons.Length - 1];
				if (null != stateController3)
				{
					switch (DataManager<MoneyRewardsDataManager>.GetInstance().Status)
					{
					case PremiumLeagueStatus.PLS_INIT:
					case PremiumLeagueStatus.PLS_ENROLL:
					case PremiumLeagueStatus.PLS_PRELIMINAY:
					case PremiumLeagueStatus.PLS_FINAL_EIGHT_PREPARE:
					case PremiumLeagueStatus.PLS_FINAL_EIGHT:
					case PremiumLeagueStatus.PLS_FINAL_FOUR:
						stateController3.Key = this.mUnStart;
						if (null != button3)
						{
							button3.onClick.AddListener(delegate()
							{
								this._PopWatchBattleErrMsg(MoneyRewardsResultFrame.WatchBattleErrorCode.WBEC_UN_START);
							});
						}
						break;
					case PremiumLeagueStatus.PLS_FINAL:
					case PremiumLeagueStatus.PLS_FINAL_WAIT_CLEAR:
						if (battleInfo == null)
						{
							stateController3.Key = this.mDisable;
							if (null != button3)
							{
								button3.onClick.AddListener(delegate()
								{
									this._PopWatchBattleErrMsg(MoneyRewardsResultFrame.WatchBattleErrorCode.WBEC_NO_RECORD);
								});
							}
						}
						else if (battleInfo.isEnd != 0)
						{
							stateController3.Key = this.mNormal;
							if (null != button3)
							{
								button3.onClick.AddListener(delegate()
								{
									this._WatchRecord(battleInfo);
								});
							}
						}
						else
						{
							stateController3.Key = this.mRunning;
							if (null != button3)
							{
								button3.onClick.AddListener(delegate()
								{
									this._OpenObserverRecord(battleInfo);
								});
							}
						}
						break;
					}
				}
			}
		}

		// Token: 0x0600F190 RID: 61840 RVA: 0x00412138 File Offset: 0x00410538
		private void _OnTick(uint time)
		{
			uint num = time % 60U;
			uint num2 = time / 60U % 60U;
			uint num3 = time / 3600U % 24U;
			if (null != this.minutes)
			{
				this.minutes.text = string.Format("{0:D2}", num2);
			}
			if (null != this.seconds)
			{
				this.seconds.text = string.Format("{0:D2}", num);
			}
		}

		// Token: 0x0600F191 RID: 61841 RVA: 0x004121B5 File Offset: 0x004105B5
		protected override void _OnCloseFrame()
		{
			if (null != this.comTime)
			{
				ComTimeTick comTimeTick = this.comTime;
				comTimeTick.onTick = (UnityAction<uint>)Delegate.Remove(comTimeTick.onTick, new UnityAction<uint>(this._OnTick));
			}
			this._UnRegisterEvent();
		}

		// Token: 0x0400945D RID: 37981
		[UIControl("Time", typeof(ComTimeTick), 0)]
		private ComTimeTick comTime;

		// Token: 0x0400945E RID: 37982
		[UIControl("Time/UINumber0", typeof(Text), 0)]
		private Text minutes;

		// Token: 0x0400945F RID: 37983
		[UIControl("Time/UINumber1", typeof(Text), 0)]
		private Text seconds;

		// Token: 0x04009460 RID: 37984
		[UIControl("", typeof(ComMoneyRewardsInfoList), 0)]
		private ComMoneyRewardsInfoList comRewardsInfoList;

		// Token: 0x04009461 RID: 37985
		[UIControl("", typeof(StateController), 0)]
		private StateController comState;

		// Token: 0x04009462 RID: 37986
		[UIControl("ChampAward", typeof(Text), 0)]
		private Text champAwards;

		// Token: 0x04009463 RID: 37987
		private string mNormal = "normal";

		// Token: 0x04009464 RID: 37988
		private string mUnStart = "unstart";

		// Token: 0x04009465 RID: 37989
		private string mDisable = "disable";

		// Token: 0x04009466 RID: 37990
		private string mRunning = "running";

		// Token: 0x04009467 RID: 37991
		private Coroutine mCurrentLoadServerCo;

		// Token: 0x020017F0 RID: 6128
		public enum WatchBattleErrorCode
		{
			// Token: 0x04009469 RID: 37993
			WBEC_OK,
			// Token: 0x0400946A RID: 37994
			WBEC_NO_RECORD,
			// Token: 0x0400946B RID: 37995
			WBEC_IN_FIGHTER,
			// Token: 0x0400946C RID: 37996
			WBEC_UN_START
		}
	}
}
