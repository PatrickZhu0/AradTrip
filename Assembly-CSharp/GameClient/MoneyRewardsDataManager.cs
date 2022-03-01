using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x020012B1 RID: 4785
	internal sealed class MoneyRewardsDataManager : DataManager<MoneyRewardsDataManager>
	{
		// Token: 0x17001B0E RID: 6926
		// (get) Token: 0x0600B849 RID: 47177 RVA: 0x002A2F72 File Offset: 0x002A1372
		public int ActiveID
		{
			get
			{
				return this.m_iActiveID;
			}
		}

		// Token: 0x17001B0F RID: 6927
		// (get) Token: 0x0600B84A RID: 47178 RVA: 0x002A2F7C File Offset: 0x002A137C
		public int SceneID
		{
			get
			{
				if (this.m_iSceneID > 0)
				{
					return this.m_iSceneID;
				}
				Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<CitySceneTable>();
				if (table != null)
				{
					foreach (KeyValuePair<int, object> keyValuePair in table)
					{
						CitySceneTable citySceneTable = keyValuePair.Value as CitySceneTable;
						if (citySceneTable != null && citySceneTable.SceneSubType == CitySceneTable.eSceneSubType.MoneyRewards)
						{
							this.m_iSceneID = citySceneTable.ID;
							break;
						}
					}
				}
				if (this.m_iSceneID < 0)
				{
					this.m_iSceneID = -this.m_iSceneID;
				}
				return this.m_iSceneID;
			}
		}

		// Token: 0x17001B10 RID: 6928
		// (get) Token: 0x0600B84B RID: 47179 RVA: 0x002A301C File Offset: 0x002A141C
		public int MoneyID
		{
			get
			{
				int result = 0;
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(291, string.Empty, string.Empty);
				if (tableItem != null)
				{
					result = tableItem.Value;
				}
				return result;
			}
		}

		// Token: 0x17001B11 RID: 6929
		// (get) Token: 0x0600B84C RID: 47180 RVA: 0x002A3054 File Offset: 0x002A1454
		public int SecondMoneyID
		{
			get
			{
				int result = 0;
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(345, string.Empty, string.Empty);
				if (tableItem != null)
				{
					result = tableItem.Value;
				}
				return result;
			}
		}

		// Token: 0x17001B12 RID: 6930
		// (get) Token: 0x0600B84D RID: 47181 RVA: 0x002A308C File Offset: 0x002A148C
		public int EnrollItemID
		{
			get
			{
				int result = 0;
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(340, string.Empty, string.Empty);
				if (tableItem != null)
				{
					result = tableItem.Value;
				}
				return result;
			}
		}

		// Token: 0x17001B13 RID: 6931
		// (get) Token: 0x0600B84E RID: 47182 RVA: 0x002A30C4 File Offset: 0x002A14C4
		public int EnrollCount
		{
			get
			{
				int result = 0;
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(341, string.Empty, string.Empty);
				if (tableItem != null)
				{
					result = tableItem.Value;
				}
				return result;
			}
		}

		// Token: 0x17001B14 RID: 6932
		// (get) Token: 0x0600B84F RID: 47183 RVA: 0x002A30FC File Offset: 0x002A14FC
		public int MaxAwardEachVS
		{
			get
			{
				int result = 0;
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(344, string.Empty, string.Empty);
				if (tableItem != null)
				{
					result = tableItem.Value;
				}
				return result;
			}
		}

		// Token: 0x17001B15 RID: 6933
		// (get) Token: 0x0600B850 RID: 47184 RVA: 0x002A3134 File Offset: 0x002A1534
		public int FixedAwardEachVS
		{
			get
			{
				int result = 0;
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(343, string.Empty, string.Empty);
				if (tableItem != null)
				{
					result = tableItem.Value;
				}
				return result;
			}
		}

		// Token: 0x17001B16 RID: 6934
		// (get) Token: 0x0600B851 RID: 47185 RVA: 0x002A316C File Offset: 0x002A156C
		public string MoneyIcon
		{
			get
			{
				int moneyID = this.MoneyID;
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(moneyID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					return tableItem.Icon;
				}
				return string.Empty;
			}
		}

		// Token: 0x17001B17 RID: 6935
		// (get) Token: 0x0600B852 RID: 47186 RVA: 0x002A31A8 File Offset: 0x002A15A8
		public bool IsMoneyEnough
		{
			get
			{
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.MoneyID, true);
				return ownedItemCount >= this.MoneyCount;
			}
		}

		// Token: 0x17001B18 RID: 6936
		// (get) Token: 0x0600B853 RID: 47187 RVA: 0x002A31D8 File Offset: 0x002A15D8
		public int MoneyCount
		{
			get
			{
				int result = 0;
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(292, string.Empty, string.Empty);
				if (tableItem != null)
				{
					result = tableItem.Value;
				}
				return result;
			}
		}

		// Token: 0x17001B19 RID: 6937
		// (get) Token: 0x0600B854 RID: 47188 RVA: 0x002A320F File Offset: 0x002A160F
		// (set) Token: 0x0600B855 RID: 47189 RVA: 0x002A3217 File Offset: 0x002A1617
		public int playerCount
		{
			get
			{
				return this._playerCount;
			}
			private set
			{
				this._playerCount = value;
			}
		}

		// Token: 0x17001B1A RID: 6938
		// (get) Token: 0x0600B856 RID: 47190 RVA: 0x002A3220 File Offset: 0x002A1620
		// (set) Token: 0x0600B857 RID: 47191 RVA: 0x002A3228 File Offset: 0x002A1628
		public int addPartyTimes
		{
			get
			{
				return this._addPratyTimes;
			}
			private set
			{
				this._addPratyTimes = value;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMoneyRewardsAddPartyTimesChanged, null, null, null, null);
			}
		}

		// Token: 0x17001B1B RID: 6939
		// (get) Token: 0x0600B859 RID: 47193 RVA: 0x002A324D File Offset: 0x002A164D
		// (set) Token: 0x0600B858 RID: 47192 RVA: 0x002A3244 File Offset: 0x002A1644
		public int moneysInPool
		{
			get
			{
				return this._moneys;
			}
			private set
			{
				this._moneys = value;
			}
		}

		// Token: 0x17001B1C RID: 6940
		// (get) Token: 0x0600B85A RID: 47194 RVA: 0x002A3255 File Offset: 0x002A1655
		// (set) Token: 0x0600B85B RID: 47195 RVA: 0x002A325D File Offset: 0x002A165D
		public int vsAwards
		{
			get
			{
				return this._vsAwards;
			}
			private set
			{
				this._vsAwards = value;
			}
		}

		// Token: 0x17001B1D RID: 6941
		// (get) Token: 0x0600B85C RID: 47196 RVA: 0x002A3268 File Offset: 0x002A1668
		public int needLevel
		{
			get
			{
				int result = 0;
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(290, string.Empty, string.Empty);
				if (tableItem != null)
				{
					result = tableItem.Value;
				}
				return result;
			}
		}

		// Token: 0x17001B1E RID: 6942
		// (get) Token: 0x0600B85D RID: 47197 RVA: 0x002A32A0 File Offset: 0x002A16A0
		public string MoneyName
		{
			get
			{
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.MoneyID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					return tableItem.Name;
				}
				return string.Empty;
			}
		}

		// Token: 0x17001B1F RID: 6943
		// (get) Token: 0x0600B85E RID: 47198 RVA: 0x002A32DC File Offset: 0x002A16DC
		public string SecondMoneyName
		{
			get
			{
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.SecondMoneyID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					return tableItem.Name;
				}
				return string.Empty;
			}
		}

		// Token: 0x17001B20 RID: 6944
		// (get) Token: 0x0600B85F RID: 47199 RVA: 0x002A3318 File Offset: 0x002A1718
		public int secondMatchCost
		{
			get
			{
				int result = 0;
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(293, string.Empty, string.Empty);
				if (tableItem != null)
				{
					result = tableItem.Value;
				}
				return result;
			}
		}

		// Token: 0x17001B21 RID: 6945
		// (get) Token: 0x0600B860 RID: 47200 RVA: 0x002A3350 File Offset: 0x002A1750
		public bool IsSecondMoneyEnough
		{
			get
			{
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.SecondMoneyID, true);
				return ownedItemCount >= this.secondMatchCost;
			}
		}

		// Token: 0x17001B22 RID: 6946
		// (get) Token: 0x0600B861 RID: 47201 RVA: 0x002A337D File Offset: 0x002A177D
		public bool bHasParty
		{
			get
			{
				return this._addPratyTimes > 0;
			}
		}

		// Token: 0x17001B23 RID: 6947
		// (get) Token: 0x0600B862 RID: 47202 RVA: 0x002A3388 File Offset: 0x002A1788
		public bool bCanAddOnceParty
		{
			get
			{
				return this._addPratyTimes == 1;
			}
		}

		// Token: 0x17001B24 RID: 6948
		// (get) Token: 0x0600B863 RID: 47203 RVA: 0x002A3394 File Offset: 0x002A1794
		public int DefChampAward
		{
			get
			{
				if (this.iDefChampAward != -1)
				{
					return this.iDefChampAward;
				}
				this.iDefChampAward = 0;
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(296, string.Empty, string.Empty);
				if (tableItem != null)
				{
					this.iDefChampAward = tableItem.Value;
				}
				return this.iDefChampAward;
			}
		}

		// Token: 0x17001B25 RID: 6949
		// (get) Token: 0x0600B864 RID: 47204 RVA: 0x002A33F0 File Offset: 0x002A17F0
		public int ChampAward
		{
			get
			{
				int num = 0;
				if (DataManager<MoneyRewardsDataManager>.GetInstance().awardsList.Count > 0)
				{
					num = DataManager<MoneyRewardsDataManager>.GetInstance().awardsList[0];
				}
				int defChampAward = this.DefChampAward;
				if (num <= 0)
				{
					num = defChampAward;
				}
				return num;
			}
		}

		// Token: 0x17001B26 RID: 6950
		// (get) Token: 0x0600B865 RID: 47205 RVA: 0x002A3436 File Offset: 0x002A1836
		public List<int> awardsList
		{
			get
			{
				return this._awardsList;
			}
		}

		// Token: 0x17001B27 RID: 6951
		// (get) Token: 0x0600B867 RID: 47207 RVA: 0x002A3447 File Offset: 0x002A1847
		// (set) Token: 0x0600B866 RID: 47206 RVA: 0x002A343E File Offset: 0x002A183E
		public int WinTimes
		{
			get
			{
				return this._winTimes;
			}
			private set
			{
				this._winTimes = value;
			}
		}

		// Token: 0x17001B28 RID: 6952
		// (get) Token: 0x0600B869 RID: 47209 RVA: 0x002A3458 File Offset: 0x002A1858
		// (set) Token: 0x0600B868 RID: 47208 RVA: 0x002A344F File Offset: 0x002A184F
		public int LoseTime
		{
			get
			{
				return this._loseTimes;
			}
			private set
			{
				this._loseTimes = value;
			}
		}

		// Token: 0x17001B29 RID: 6953
		// (get) Token: 0x0600B86B RID: 47211 RVA: 0x002A3469 File Offset: 0x002A1869
		// (set) Token: 0x0600B86A RID: 47210 RVA: 0x002A3460 File Offset: 0x002A1860
		public int Rank
		{
			get
			{
				return this._rank;
			}
			set
			{
				this._rank = value;
			}
		}

		// Token: 0x17001B2A RID: 6954
		// (get) Token: 0x0600B86D RID: 47213 RVA: 0x002A347A File Offset: 0x002A187A
		// (set) Token: 0x0600B86C RID: 47212 RVA: 0x002A3471 File Offset: 0x002A1871
		public int Score
		{
			get
			{
				return this._score;
			}
			set
			{
				this._score = value;
			}
		}

		// Token: 0x17001B2B RID: 6955
		// (get) Token: 0x0600B86F RID: 47215 RVA: 0x002A348B File Offset: 0x002A188B
		// (set) Token: 0x0600B86E RID: 47214 RVA: 0x002A3482 File Offset: 0x002A1882
		public int MaxScore
		{
			get
			{
				return this._maxScore;
			}
			set
			{
				this._maxScore = value;
			}
		}

		// Token: 0x17001B2C RID: 6956
		// (get) Token: 0x0600B870 RID: 47216 RVA: 0x002A3493 File Offset: 0x002A1893
		public bool CanMatch
		{
			get
			{
				return this.Status == PremiumLeagueStatus.PLS_PRELIMINAY;
			}
		}

		// Token: 0x17001B2D RID: 6957
		// (get) Token: 0x0600B871 RID: 47217 RVA: 0x002A34A0 File Offset: 0x002A18A0
		public int matchMaxTimes
		{
			get
			{
				int result = 0;
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(294, string.Empty, string.Empty);
				if (tableItem != null)
				{
					result = tableItem.Value;
				}
				return result;
			}
		}

		// Token: 0x17001B2E RID: 6958
		// (get) Token: 0x0600B872 RID: 47218 RVA: 0x002A34D7 File Offset: 0x002A18D7
		public MoneyRewaradsRankItemData[] RankItems
		{
			get
			{
				return this._rankItems;
			}
		}

		// Token: 0x17001B2F RID: 6959
		// (get) Token: 0x0600B873 RID: 47219 RVA: 0x002A34DF File Offset: 0x002A18DF
		public MoneyRewaradsRankItemData RankItemSelf
		{
			get
			{
				return this._rankItemSelf;
			}
		}

		// Token: 0x0600B874 RID: 47220 RVA: 0x002A34E7 File Offset: 0x002A18E7
		private void _clearSelfRank()
		{
			this._rankItemSelf.name = string.Empty;
			this._rankItemSelf.score = 0;
			this._rankItemSelf.maxScore = 0;
			this._rankItemSelf.rank = 999;
		}

		// Token: 0x0600B875 RID: 47221 RVA: 0x002A3524 File Offset: 0x002A1924
		public void ClearRankItems()
		{
			for (int i = 0; i < this._rankItems.Length; i++)
			{
				this._rankItems[i] = null;
			}
		}

		// Token: 0x0600B876 RID: 47222 RVA: 0x002A3554 File Offset: 0x002A1954
		public bool isRcdInQueue(ulong a_raceId)
		{
			for (int i = 0; i < this._records.Count; i++)
			{
				if (this._records[i] != null && this._records[i].a_raceId == a_raceId)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600B877 RID: 47223 RVA: 0x002A35A8 File Offset: 0x002A19A8
		public void downloadRcd(ulong a_raceId, UnityAction<ulong> cb, bool isCrossService = false)
		{
			if (!this.isRcdInQueue(a_raceId))
			{
				this._records.Add(new MoneyRewardsDataManager.RecordDownLoad
				{
					a_raceId = a_raceId,
					cb = cb,
					IsCrossService = isCrossService
				});
			}
		}

		// Token: 0x0600B878 RID: 47224 RVA: 0x002A35E8 File Offset: 0x002A19E8
		public static void ShowErrorNotify(ReplayErrorCode code)
		{
			if (code == ReplayErrorCode.FILE_NOT_FOUND)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("pk_video_file_not_found"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			else if (code == ReplayErrorCode.VERSION_NOT_MATCH)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("pk_video_version_not_match"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			else if (code == ReplayErrorCode.DOWNLOAD_FAILED)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("pk_video_download_failed"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			else if (code == ReplayErrorCode.HAS_TEAM)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("pk_video_has_team"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
		}

		// Token: 0x0600B879 RID: 47225 RVA: 0x002A3664 File Offset: 0x002A1A64
		public override void Update(float a_fTime)
		{
			bool flag = false;
			for (int i = 0; i < this._records.Count; i++)
			{
				MoneyRewardsDataManager.RecordDownLoad recordDownLoad = this._records[i];
				if (recordDownLoad != null)
				{
					MoneyRewardsDataManager.RecordDownLoadType eRecordDownLoadType = recordDownLoad.eRecordDownLoadType;
					if (eRecordDownLoadType != MoneyRewardsDataManager.RecordDownLoadType.RDT_INIT)
					{
						if (eRecordDownLoadType == MoneyRewardsDataManager.RecordDownLoadType.RDT_LOADING)
						{
							if (!recordDownLoad.req.MoveNext())
							{
								BaseWaitHttpRequest.eState result = recordDownLoad.req.GetResult();
								if (result == BaseWaitHttpRequest.eState.Success)
								{
									byte[] resultBytes = recordDownLoad.req.GetResultBytes();
									if (resultBytes == null || resultBytes.Length <= 0)
									{
										MoneyRewardsDataManager.ShowErrorNotify(ReplayErrorCode.DOWNLOAD_FAILED);
										recordDownLoad.eRecordDownLoadType = MoneyRewardsDataManager.RecordDownLoadType.RDT_FAILED;
									}
									else
									{
										byte[] array = resultBytes;
										RecordData.SaveReplayFile(recordDownLoad.sessionID, array, array.Length, string.Empty);
										recordDownLoad.eRecordDownLoadType = MoneyRewardsDataManager.RecordDownLoadType.RDT_FINISH;
										if (recordDownLoad.cb != null)
										{
											recordDownLoad.cb.Invoke(recordDownLoad.a_raceId);
										}
									}
								}
								else if (result == BaseWaitHttpRequest.eState.TimeOut)
								{
									recordDownLoad.eRecordDownLoadType = MoneyRewardsDataManager.RecordDownLoadType.RDT_FAILED;
									MoneyRewardsDataManager.ShowErrorNotify(ReplayErrorCode.DOWNLOAD_FAILED);
								}
								else if (result == BaseWaitHttpRequest.eState.Error)
								{
									recordDownLoad.eRecordDownLoadType = MoneyRewardsDataManager.RecordDownLoadType.RDT_FAILED;
									MoneyRewardsDataManager.ShowErrorNotify(ReplayErrorCode.DOWNLOAD_FAILED);
								}
								flag = true;
							}
						}
					}
					else
					{
						recordDownLoad.sessionID = recordDownLoad.a_raceId.ToString();
						recordDownLoad.req = new ReplayWaitHttpRequest(recordDownLoad.sessionID, recordDownLoad.IsCrossService);
						recordDownLoad.eRecordDownLoadType = MoneyRewardsDataManager.RecordDownLoadType.RDT_LOADING;
					}
				}
			}
			this._records.RemoveAll((MoneyRewardsDataManager.RecordDownLoad x) => x == null || x.eRecordDownLoadType == MoneyRewardsDataManager.RecordDownLoadType.RDT_FAILED || x.eRecordDownLoadType == MoneyRewardsDataManager.RecordDownLoadType.RDT_FINISH);
			if (flag)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMoneyRewardsRcdStatusChanged, null, null, null, null);
			}
		}

		// Token: 0x17001B30 RID: 6960
		// (get) Token: 0x0600B87A RID: 47226 RVA: 0x002A380C File Offset: 0x002A1C0C
		public int getValidRankCount
		{
			get
			{
				int num = 0;
				for (int i = 0; i < this._rankItems.Length; i++)
				{
					if (this._rankItems[i] == null)
					{
						break;
					}
					num++;
				}
				return num;
			}
		}

		// Token: 0x0600B87B RID: 47227 RVA: 0x002A3850 File Offset: 0x002A1C50
		public void TryCallEnterMsgBox(int iMsgID, UnityAction onOk)
		{
			if (!(Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemTown))
			{
				return;
			}
			if (onOk != null)
			{
				onOk.Invoke();
			}
			SystemNotifyManager.SystemNotify(iMsgID, delegate()
			{
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MoneyRewardsEnterFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<MoneyRewardsEnterFrame>(null, false);
				}
				DataManager<MoneyRewardsDataManager>.GetInstance().GotoPvpFight();
			});
		}

		// Token: 0x0600B87C RID: 47228 RVA: 0x002A38A4 File Offset: 0x002A1CA4
		public void SendAddParty(UnityAction callback)
		{
			this.SendAddMoneyRewards();
			DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldPremiumLeagueEnrollRes>(delegate(WorldPremiumLeagueEnrollRes msgRet)
			{
				if (msgRet.result != 0U)
				{
					SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
				}
				else if (callback != null)
				{
					callback.Invoke();
				}
			}, true, 15f, null);
		}

		// Token: 0x0600B87D RID: 47229 RVA: 0x002A38E4 File Offset: 0x002A1CE4
		public void SendAddMoneyRewards()
		{
			WorldPremiumLeagueEnrollReq cmd = new WorldPremiumLeagueEnrollReq();
			NetManager.Instance().SendCommand<WorldPremiumLeagueEnrollReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600B87E RID: 47230 RVA: 0x002A3904 File Offset: 0x002A1D04
		private void OnRecvWorldPremiumLeagueEnrollRes(MsgDATA msg)
		{
			WorldPremiumLeagueEnrollRes worldPremiumLeagueEnrollRes = new WorldPremiumLeagueEnrollRes();
			worldPremiumLeagueEnrollRes.decode(msg.bytes);
			if (worldPremiumLeagueEnrollRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldPremiumLeagueEnrollRes.result, string.Empty);
			}
		}

		// Token: 0x0600B87F RID: 47231 RVA: 0x002A3944 File Offset: 0x002A1D44
		private void OnRecvWorldPremiumLeagueSelfInfo(MsgDATA msg)
		{
			WorldPremiumLeagueSelfInfo worldPremiumLeagueSelfInfo = new WorldPremiumLeagueSelfInfo();
			worldPremiumLeagueSelfInfo.decode(msg.bytes);
			this.Score = (int)worldPremiumLeagueSelfInfo.info.score;
			this.WinTimes = (int)worldPremiumLeagueSelfInfo.info.winNum;
			this.LoseTime = (int)worldPremiumLeagueSelfInfo.info.loseNum;
			this.addPartyTimes = (int)worldPremiumLeagueSelfInfo.info.enrollCount;
			this.vsAwards = (int)worldPremiumLeagueSelfInfo.info.preliminayRewardNum;
			this._rankItemSelf.score = this.Score;
			this._rankItemSelf.maxScore = this.MaxScore;
			this._rankItemSelf.name = DataManager<PlayerBaseData>.GetInstance().Name;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMoneyRewardsSelfResultChanged, null, null, null, null);
		}

		// Token: 0x0600B880 RID: 47232 RVA: 0x002A3A02 File Offset: 0x002A1E02
		public override void Initialize()
		{
			this.RegisterNetHandler();
			InvokeMethod.InvokeInterval(this, 3f, 1f, 999999f, null, new UnityAction(this._UpdateMsgHint), null);
		}

		// Token: 0x0600B881 RID: 47233 RVA: 0x002A3A30 File Offset: 0x002A1E30
		private void RegisterNetHandler()
		{
			NetProcess.AddMsgHandler(607708U, new Action<MsgDATA>(this.OnRecvWorldPremiumLeagueSelfInfo));
			NetProcess.AddMsgHandler(607713U, new Action<MsgDATA>(this.OnRecvWorldPremiumLeagueBattleInfoInit));
			NetProcess.AddMsgHandler(607714U, new Action<MsgDATA>(this.OnRecvWorldPremiumLeagueBattleInfoUpdate));
			NetProcess.AddMsgHandler(607701U, new Action<MsgDATA>(this.OnRecvWorldPremiumLeagueSyncStatus));
			NetProcess.AddMsgHandler(607707U, new Action<MsgDATA>(this.OnRecvWorldPremiumLeagueBattleGamerUpdate));
			NetProcess.AddMsgHandler(607706U, new Action<MsgDATA>(this.OnRecvWorldPremiumLeagueBattleGamerInit));
			NetProcess.AddMsgHandler(607703U, new Action<MsgDATA>(this.OnRecvWorldPremiumLeagueRewardPoolRes));
			NetProcess.AddMsgHandler(607711U, new Action<MsgDATA>(this.OnRecvWorldPremiumLeagueBattleRecordSync));
		}

		// Token: 0x0600B882 RID: 47234 RVA: 0x002A3AF0 File Offset: 0x002A1EF0
		private void UnRegisterNetHandler()
		{
			NetProcess.RemoveMsgHandler(607708U, new Action<MsgDATA>(this.OnRecvWorldPremiumLeagueSelfInfo));
			NetProcess.RemoveMsgHandler(607713U, new Action<MsgDATA>(this.OnRecvWorldPremiumLeagueBattleInfoInit));
			NetProcess.RemoveMsgHandler(607714U, new Action<MsgDATA>(this.OnRecvWorldPremiumLeagueBattleInfoUpdate));
			NetProcess.RemoveMsgHandler(607701U, new Action<MsgDATA>(this.OnRecvWorldPremiumLeagueSyncStatus));
			NetProcess.RemoveMsgHandler(607707U, new Action<MsgDATA>(this.OnRecvWorldPremiumLeagueBattleGamerUpdate));
			NetProcess.RemoveMsgHandler(607706U, new Action<MsgDATA>(this.OnRecvWorldPremiumLeagueBattleGamerInit));
			NetProcess.RemoveMsgHandler(607703U, new Action<MsgDATA>(this.OnRecvWorldPremiumLeagueRewardPoolRes));
			NetProcess.RemoveMsgHandler(607711U, new Action<MsgDATA>(this.OnRecvWorldPremiumLeagueBattleRecordSync));
		}

		// Token: 0x0600B883 RID: 47235 RVA: 0x002A3BB0 File Offset: 0x002A1FB0
		private void OnRecvWorldPremiumLeagueBattleInfoInit(MsgDATA msg)
		{
			WorldPremiumLeagueBattleInfoInit worldPremiumLeagueBattleInfoInit = new WorldPremiumLeagueBattleInfoInit();
			worldPremiumLeagueBattleInfoInit.decode(msg.bytes);
			this.m_battles.Clear();
			for (int i = 0; i < worldPremiumLeagueBattleInfoInit.battles.Length; i++)
			{
				this.m_battles.Add(worldPremiumLeagueBattleInfoInit.battles[i]);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMoneyRewardsBattleInfoChanged, null, null, null, null);
		}

		// Token: 0x0600B884 RID: 47236 RVA: 0x002A3C1C File Offset: 0x002A201C
		private void OnRecvWorldPremiumLeagueBattleInfoUpdate(MsgDATA msg)
		{
			WorldPremiumLeagueBattleInfoUpdate recv = new WorldPremiumLeagueBattleInfoUpdate();
			recv.decode(msg.bytes);
			this.m_battles.RemoveAll((CLPremiumLeagueBattle x) => x.raceId == recv.battle.raceId);
			this.m_battles.Add(recv.battle);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMoneyRewardsBattleInfoChanged, null, null, null, null);
		}

		// Token: 0x0600B885 RID: 47237 RVA: 0x002A3C8C File Offset: 0x002A208C
		public CLPremiumLeagueBattle GetChampionRelationInfo()
		{
			for (int i = 0; i < this.m_battles.Count; i++)
			{
				CLPremiumLeagueBattle clpremiumLeagueBattle = this.m_battles[i];
				if (clpremiumLeagueBattle != null && clpremiumLeagueBattle.raceId != 0UL && clpremiumLeagueBattle.type == 6 && clpremiumLeagueBattle.fighter1 != null && clpremiumLeagueBattle.fighter2 != null)
				{
					return clpremiumLeagueBattle;
				}
			}
			return null;
		}

		// Token: 0x0600B886 RID: 47238 RVA: 0x002A3CFC File Offset: 0x002A20FC
		public CLPremiumLeagueBattle GetRelationBattleInfo(ulong roleId, PremiumLeagueStatus ePremiumLeagueStatus)
		{
			for (int i = 0; i < this.m_battles.Count; i++)
			{
				CLPremiumLeagueBattle clpremiumLeagueBattle = this.m_battles[i];
				if (clpremiumLeagueBattle != null && clpremiumLeagueBattle.raceId != 0UL && clpremiumLeagueBattle.fighter1 != null && clpremiumLeagueBattle.fighter2 != null && clpremiumLeagueBattle.type == (byte)ePremiumLeagueStatus && (clpremiumLeagueBattle.fighter1.id == roleId || clpremiumLeagueBattle.fighter2.id == roleId))
				{
					return clpremiumLeagueBattle;
				}
			}
			return null;
		}

		// Token: 0x0600B887 RID: 47239 RVA: 0x002A3D90 File Offset: 0x002A2190
		private void _resetAwards()
		{
			if (this._awardsList.Count == 5)
			{
				for (int i = 0; i < this._awardsList.Count; i++)
				{
					this._awardsList[i] = 0;
				}
			}
			else
			{
				this._awardsList.Clear();
				for (int j = 0; j < 5; j++)
				{
					this._awardsList.Add(0);
				}
			}
		}

		// Token: 0x0600B888 RID: 47240 RVA: 0x002A3E08 File Offset: 0x002A2208
		public override void Clear()
		{
			this._resetAwards();
			for (int i = 0; i < this._rankItems.Length; i++)
			{
				this._rankItems[i] = null;
			}
			this.records.Clear();
			this._totalRecordsCount = 0;
			this.activeInfo.status = 0;
			for (int j = 0; j < this.resultDatas.Length; j++)
			{
				this.resultDatas[j] = null;
			}
			this.moneysInPool = 0;
			this.Rank = 999;
			this.WinTimes = 0;
			this.LoseTime = 0;
			this.Score = 0;
			this.MaxScore = 0;
			this.vsAwards = 0;
			this._clearSelfRank();
			this.m_battles.Clear();
			Array.Clear(this._stages, 0, this._stages.Length);
			InvokeMethod.RmoveInvokeIntervalCall(this);
			this.UnRegisterNetHandler();
		}

		// Token: 0x0600B889 RID: 47241 RVA: 0x002A3EE4 File Offset: 0x002A22E4
		private void _OnConfirmToPvpFight()
		{
			if (DataManager<TeamDataManager>.GetInstance().HasTeam())
			{
				SystemNotifyManager.SystemNotify(1104, string.Empty);
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MoneyRewardsEnterFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<MoneyRewardsEnterFrame>(null, false);
			}
			DataManager<MoneyRewardsDataManager>.GetInstance().GotoPvpFight();
		}

		// Token: 0x0600B88A RID: 47242 RVA: 0x002A3F38 File Offset: 0x002A2338
		private void _UpdateMsgHint()
		{
			if (this.addPartyTimes <= 0)
			{
				return;
			}
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return;
			}
			if (clientSystemTown.CurrentSceneID == this.SceneID)
			{
				return;
			}
			if (clientSystemTown != null)
			{
				uint num = (DataManager<MoneyRewardsDataManager>.GetInstance().StatusEndTime < DataManager<TimeManager>.GetInstance().GetServerTime()) ? 0U : (DataManager<MoneyRewardsDataManager>.GetInstance().StatusEndTime - DataManager<TimeManager>.GetInstance().GetServerTime());
				if (this.Status == PremiumLeagueStatus.PLS_ENROLL)
				{
					if (this._stages[0] == 0 && num <= 300U)
					{
						this._stages[0] = 1;
						SystemNotifyManager.SystemNotify(7024, new UnityAction(this._OnConfirmToPvpFight), null, new object[]
						{
							0
						});
					}
				}
				else if (this.Status == PremiumLeagueStatus.PLS_FINAL_EIGHT_PREPARE)
				{
					if (this._stages[1] == 0 && num <= 300U && this.Rank <= 8 && this.Rank >= 1)
					{
						this._stages[1] = 1;
						string text = Utility.ToUtcTime2Local((long)((ulong)DataManager<MoneyRewardsDataManager>.GetInstance().StatusEndTime)).ToString("HH:mm", Utility.cultureInfo);
						SystemNotifyManager.SystemNotify(7025, new UnityAction(this._OnConfirmToPvpFight), null, new object[]
						{
							text
						});
					}
				}
				else if (this.Status == PremiumLeagueStatus.PLS_FINAL_EIGHT)
				{
					if (this._stages[2] == 0 && num <= 60U && this.WinTimes == 1)
					{
						this._stages[2] = 1;
						string text2 = Utility.ToUtcTime2Local((long)((ulong)DataManager<MoneyRewardsDataManager>.GetInstance().StatusEndTime)).ToString("HH:mm", Utility.cultureInfo);
						SystemNotifyManager.SystemNotify(7026, new UnityAction(this._OnConfirmToPvpFight), null, new object[]
						{
							text2
						});
					}
				}
				else if (this.Status == PremiumLeagueStatus.PLS_FINAL_FOUR && this._stages[3] == 0 && num <= 60U && this.WinTimes == 2)
				{
					this._stages[3] = 1;
					string text3 = Utility.ToUtcTime2Local((long)((ulong)DataManager<MoneyRewardsDataManager>.GetInstance().StatusEndTime)).ToString("HH:mm", Utility.cultureInfo);
					SystemNotifyManager.SystemNotify(7027, new UnityAction(this._OnConfirmToPvpFight), null, new object[]
					{
						text3
					});
				}
			}
		}

		// Token: 0x17001B31 RID: 6961
		// (get) Token: 0x0600B88B RID: 47243 RVA: 0x002A419B File Offset: 0x002A259B
		public PremiumLeagueStatus Status
		{
			get
			{
				if (this.activeInfo.status >= 0 && this.activeInfo.status <= 7)
				{
					return (PremiumLeagueStatus)this.activeInfo.status;
				}
				return PremiumLeagueStatus.PLS_INIT;
			}
		}

		// Token: 0x17001B32 RID: 6962
		// (get) Token: 0x0600B88C RID: 47244 RVA: 0x002A41CC File Offset: 0x002A25CC
		public uint StatusEndTime
		{
			get
			{
				return this.activeInfo.endTime;
			}
		}

		// Token: 0x0600B88D RID: 47245 RVA: 0x002A41DC File Offset: 0x002A25DC
		private void OnRecvWorldPremiumLeagueSyncStatus(MsgDATA msg)
		{
			this.activeInfo.decode(msg.bytes);
			if (this.activeInfo.status == 0)
			{
				for (int i = 0; i < this.resultDatas.Length; i++)
				{
					this.resultDatas[i] = null;
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMoneyRewardsResultChanged, null, null, null, null);
				this.m_battles.Clear();
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMoneyRewardsBattleInfoChanged, null, null, null, null);
				Array.Clear(this._stages, 0, this._stages.Length);
				this.vsAwards = 0;
			}
			NotifyInfo a_info = new NotifyInfo
			{
				type = 6U
			};
			if (this.needEnterance)
			{
				DataManager<ActivityNoticeDataManager>.GetInstance().AddActivityNotice(a_info);
				DataManager<DeadLineReminderDataManager>.GetInstance().AddActivityNotice(a_info);
			}
			else
			{
				DataManager<ActivityNoticeDataManager>.GetInstance().DeleteActivityNotice(a_info);
				DataManager<DeadLineReminderDataManager>.GetInstance().DeleteActivityNotice(a_info);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMoneyRewardsStatusChanged, null, null, null, null);
		}

		// Token: 0x0600B88E RID: 47246 RVA: 0x002A42D8 File Offset: 0x002A26D8
		private void OnRecvWorldPremiumLeagueBattleGamerUpdate(MsgDATA msg)
		{
			WorldPremiumLeagueBattleGamerUpdate worldPremiumLeagueBattleGamerUpdate = new WorldPremiumLeagueBattleGamerUpdate();
			worldPremiumLeagueBattleGamerUpdate.decode(msg.bytes);
			for (int i = 0; i < this.resultDatas.Length; i++)
			{
				if (this.resultDatas[i] != null && this.resultDatas[i].recordId == worldPremiumLeagueBattleGamerUpdate.roleId)
				{
					this.resultDatas[i].winTimes = (int)worldPremiumLeagueBattleGamerUpdate.winNum;
					this.resultDatas[i].losed = (worldPremiumLeagueBattleGamerUpdate.isLose != 0);
					break;
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMoneyRewardsResultChanged, null, null, null, null);
		}

		// Token: 0x0600B88F RID: 47247 RVA: 0x002A437C File Offset: 0x002A277C
		private void OnRecvWorldPremiumLeagueBattleGamerInit(MsgDATA msg)
		{
			WorldPremiumLeagueBattleGamerInit worldPremiumLeagueBattleGamerInit = new WorldPremiumLeagueBattleGamerInit();
			worldPremiumLeagueBattleGamerInit.decode(msg.bytes);
			for (int i = 0; i < this.resultDatas.Length; i++)
			{
				this.resultDatas[i] = null;
			}
			for (int j = 0; j < worldPremiumLeagueBattleGamerInit.gamers.Length; j++)
			{
				PremiumLeagueBattleGamer premiumLeagueBattleGamer = worldPremiumLeagueBattleGamerInit.gamers[j];
				if (premiumLeagueBattleGamer != null && premiumLeagueBattleGamer.ranking >= 1U && (ulong)premiumLeagueBattleGamer.ranking <= (ulong)((long)this.resultDatas.Length))
				{
					ComMoneyRewardsResultData comMoneyRewardsResultData = new ComMoneyRewardsResultData
					{
						recordId = premiumLeagueBattleGamer.roleId,
						name = premiumLeagueBattleGamer.name,
						occu = (int)premiumLeagueBattleGamer.occu,
						winTimes = (int)premiumLeagueBattleGamer.winNum,
						rank = (int)premiumLeagueBattleGamer.ranking,
						losed = (premiumLeagueBattleGamer.isLose != 0)
					};
					this.resultDatas[(int)((UIntPtr)(premiumLeagueBattleGamer.ranking - 1U))] = comMoneyRewardsResultData;
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMoneyRewardsResultChanged, null, null, null, null);
		}

		// Token: 0x0600B890 RID: 47248 RVA: 0x002A4490 File Offset: 0x002A2890
		private void OnRecvWorldPremiumLeagueRewardPoolRes(MsgDATA msg)
		{
			WorldPremiumLeagueRewardPoolRes worldPremiumLeagueRewardPoolRes = new WorldPremiumLeagueRewardPoolRes();
			worldPremiumLeagueRewardPoolRes.decode(msg.bytes);
			this.moneysInPool = (int)worldPremiumLeagueRewardPoolRes.money;
			this.playerCount = (int)worldPremiumLeagueRewardPoolRes.enrollPlayerNum;
			this._resetAwards();
			int num = 0;
			while (num < worldPremiumLeagueRewardPoolRes.rewards.Length && num < this._awardsList.Count)
			{
				this._awardsList[num] = (int)worldPremiumLeagueRewardPoolRes.rewards[num];
				num++;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMoneyRewardsPoolsMoneyChanged, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMoneyRewardsPlayerCountChanged, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMoneyRewardsAwardListChanged, null, null, null, null);
		}

		// Token: 0x17001B33 RID: 6963
		// (get) Token: 0x0600B891 RID: 47249 RVA: 0x002A4544 File Offset: 0x002A2944
		// (set) Token: 0x0600B892 RID: 47250 RVA: 0x002A454C File Offset: 0x002A294C
		public int TotalRecordsCount
		{
			get
			{
				return this._totalRecordsCount;
			}
			private set
			{
				this._totalRecordsCount = value;
			}
		}

		// Token: 0x0600B893 RID: 47251 RVA: 0x002A4558 File Offset: 0x002A2958
		private void OnRecvWorldPremiumLeagueBattleRecordSync(MsgDATA msg)
		{
			WorldPremiumLeagueBattleRecordSync worldPremiumLeagueBattleRecordSync = new WorldPremiumLeagueBattleRecordSync();
			worldPremiumLeagueBattleRecordSync.decode(msg.bytes);
			this._AddRecords(worldPremiumLeagueBattleRecordSync.record);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMoneyRewardsRecordsChanged, null, null, null, null);
		}

		// Token: 0x0600B894 RID: 47252 RVA: 0x002A4598 File Offset: 0x002A2998
		private void _AddRecords(PremiumLeagueRecordEntry current)
		{
			if (current != null && this.Records.Find((ComMoneyRewardsRecordsData x) => (long)x.iIndex == (long)((ulong)current.index)) == null)
			{
				ComMoneyRewardsRecordsData item = new ComMoneyRewardsRecordsData
				{
					iIndex = (int)current.index,
					measured = false,
					time = current.time,
					srcId = current.winner.id,
					tarId = current.loser.id,
					srcName = current.winner.name,
					tarName = current.loser.name,
					srcBeatCount = (int)current.winner.winStreak,
					dstBeatCount = (int)current.loser.winStreak,
					scoreChanged = (int)current.winner.gotScore
				};
				this.Records.Add(item);
			}
		}

		// Token: 0x0600B895 RID: 47253 RVA: 0x002A46B4 File Offset: 0x002A2AB4
		public void RequestRecords(bool isSelf, int start, int count, UnityAction onAction)
		{
			WorldPremiumLeagueBattleRecordReq cmd = new WorldPremiumLeagueBattleRecordReq
			{
				isSelf = ((!isSelf) ? 0 : 1),
				startIndex = (uint)start,
				count = (uint)count
			};
			NetManager.Instance().SendCommand<WorldPremiumLeagueBattleRecordReq>(ServerType.GATE_SERVER, cmd);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldPremiumLeagueBattleRecordRes>(delegate(WorldPremiumLeagueBattleRecordRes recv)
			{
				this.TotalRecordsCount = (int)recv.totalCount;
				for (int i = 0; i < recv.records.Length; i++)
				{
					this._AddRecords(recv.records[i]);
				}
				this.Records.Sort((ComMoneyRewardsRecordsData x, ComMoneyRewardsRecordsData y) => x.iIndex - y.iIndex);
				if (onAction != null)
				{
					onAction.Invoke();
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMoneyRewardsRecordsChanged, null, null, null, null);
			}, true, 15f, null);
		}

		// Token: 0x17001B34 RID: 6964
		// (get) Token: 0x0600B896 RID: 47254 RVA: 0x002A472A File Offset: 0x002A2B2A
		public ComMoneyRewardsResultData[] ResultDatas
		{
			get
			{
				return this.resultDatas;
			}
		}

		// Token: 0x0600B897 RID: 47255 RVA: 0x002A4734 File Offset: 0x002A2B34
		public ComMoneyRewardsResultData GetOtherResultData(ComMoneyRewardsResultData value)
		{
			if (value != null)
			{
				for (int i = 0; i < this.m_pairs.Length; i++)
				{
					int num = value.rank - 1;
					int num2 = -1;
					if (num == this.m_pairs[num, 0])
					{
						num2 = this.m_pairs[num, 1];
					}
					else if (num == this.m_pairs[num, 1])
					{
						num2 = this.m_pairs[num, 0];
					}
					if (num2 >= 0 && num2 < this.ResultDatas.Length)
					{
						return this.ResultDatas[num2];
					}
				}
			}
			return null;
		}

		// Token: 0x0600B898 RID: 47256 RVA: 0x002A47D4 File Offset: 0x002A2BD4
		public ComMoneyRewardsResultData GetLocalResultData()
		{
			for (int i = 0; i < this.ResultDatas.Length; i++)
			{
				if (this.ResultDatas[i] != null && this.ResultDatas[i].recordId == DataManager<PlayerBaseData>.GetInstance().RoleID)
				{
					return this.ResultDatas[i];
				}
			}
			return null;
		}

		// Token: 0x0600B899 RID: 47257 RVA: 0x002A4830 File Offset: 0x002A2C30
		public int getIndexByRoleId(ulong roleId)
		{
			for (int i = 0; i < this.ResultDatas.Length; i++)
			{
				if (this.ResultDatas[i] != null && this.ResultDatas[i].recordId == roleId)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x0600B89A RID: 47258 RVA: 0x002A487C File Offset: 0x002A2C7C
		public ComMoneyRewardsResultData GetNextVsData(int iIndex, PremiumLeagueStatus status, ref bool hasNext)
		{
			hasNext = false;
			if (iIndex >= 0 && iIndex < this.ResultDatas.Length)
			{
				int i = 0;
				while (i < this.m_map_pairs.Length)
				{
					if (this.m_map_pairs[i] >> 24 == iIndex)
					{
						ComMoneyRewardsResultData comMoneyRewardsResultData = this.ResultDatas[iIndex];
						if (comMoneyRewardsResultData == null)
						{
							hasNext = false;
							return null;
						}
						if (status == PremiumLeagueStatus.PLS_FINAL_EIGHT_PREPARE)
						{
							ComMoneyRewardsResultData resultByIndex = this.getResultByIndex(this.m_map_pairs[i] >> 16 & 255);
							hasNext = true;
							return resultByIndex;
						}
						if (status == PremiumLeagueStatus.PLS_FINAL_EIGHT)
						{
							if (comMoneyRewardsResultData.winTimes > 0)
							{
								hasNext = true;
								ComMoneyRewardsResultData resultByIndex2 = this.getResultByIndex(this.m_map_pairs[i] >> 8 & 255);
								if (resultByIndex2 != null && resultByIndex2.winTimes > 0)
								{
									return resultByIndex2;
								}
								ComMoneyRewardsResultData resultByIndex3 = this.getResultByIndex(this.m_map_pairs[i] & 255);
								if (resultByIndex3 != null && resultByIndex3.winTimes > 0)
								{
									return resultByIndex3;
								}
							}
							else
							{
								ComMoneyRewardsResultData resultByIndex4 = this.getResultByIndex(this.m_map_pairs[i] >> 16 & 255);
								if (resultByIndex4 == null)
								{
									hasNext = true;
								}
								else
								{
									if (resultByIndex4.winTimes <= 0)
									{
										hasNext = true;
										return resultByIndex4;
									}
									hasNext = false;
								}
							}
							return null;
						}
						if (status == PremiumLeagueStatus.PLS_FINAL_FOUR)
						{
							if (comMoneyRewardsResultData.winTimes < 1)
							{
								hasNext = false;
								return null;
							}
							if (comMoneyRewardsResultData.winTimes != 1)
							{
								if (comMoneyRewardsResultData.winTimes > 1)
								{
									hasNext = true;
									for (int j = 0; j < this.resultDatas.Length; j++)
									{
										if (this.resultDatas[j] != null && this.resultDatas[j].recordId != comMoneyRewardsResultData.recordId && this.resultDatas[j].winTimes == 2)
										{
											return this.resultDatas[j];
										}
									}
								}
								return null;
							}
							ComMoneyRewardsResultData resultByIndex5 = this.getResultByIndex(this.m_map_pairs[i] >> 8 & 255);
							ComMoneyRewardsResultData resultByIndex6 = this.getResultByIndex(this.m_map_pairs[i] & 255);
							if (resultByIndex5 == null && resultByIndex6 == null)
							{
								hasNext = true;
								return null;
							}
							if (resultByIndex5 == null || resultByIndex6 == null)
							{
								hasNext = false;
								return null;
							}
							ComMoneyRewardsResultData comMoneyRewardsResultData2 = (resultByIndex5.winTimes <= resultByIndex6.winTimes) ? resultByIndex6 : resultByIndex5;
							if (comMoneyRewardsResultData2.winTimes > 1)
							{
								hasNext = false;
								return null;
							}
							hasNext = true;
							return resultByIndex5;
						}
						else
						{
							if (status != PremiumLeagueStatus.PLS_FINAL)
							{
								break;
							}
							if (comMoneyRewardsResultData.winTimes < 2)
							{
								hasNext = false;
								return null;
							}
							if (comMoneyRewardsResultData.winTimes == 2)
							{
								for (int k = 0; k < this.resultDatas.Length; k++)
								{
									if (this.resultDatas[k] != null && this.resultDatas[k].recordId != comMoneyRewardsResultData.recordId && this.resultDatas[k].winTimes == 2)
									{
										hasNext = true;
										return this.resultDatas[k];
									}
								}
							}
							return null;
						}
					}
					else
					{
						i++;
					}
				}
			}
			return null;
		}

		// Token: 0x0600B89B RID: 47259 RVA: 0x002A4B68 File Offset: 0x002A2F68
		public ComMoneyRewardsResultData getResultByIndex(int iIndex)
		{
			if (iIndex >= 0 && iIndex < this.ResultDatas.Length)
			{
				return this.ResultDatas[iIndex];
			}
			return null;
		}

		// Token: 0x17001B35 RID: 6965
		// (get) Token: 0x0600B89C RID: 47260 RVA: 0x002A4B8C File Offset: 0x002A2F8C
		public ComMoneyRewardsResultData getChampionData
		{
			get
			{
				ComMoneyRewardsResultData result = null;
				for (int i = 0; i < this.resultDatas.Length; i++)
				{
					if (this.resultDatas[i] != null && this.resultDatas[i].winTimes == 3)
					{
						result = this.resultDatas[i];
						break;
					}
				}
				return result;
			}
		}

		// Token: 0x17001B36 RID: 6966
		// (get) Token: 0x0600B89D RID: 47261 RVA: 0x002A4BE3 File Offset: 0x002A2FE3
		public bool isLevelFit
		{
			get
			{
				return this.needLevel <= (int)DataManager<PlayerBaseData>.GetInstance().Level;
			}
		}

		// Token: 0x17001B37 RID: 6967
		// (get) Token: 0x0600B89E RID: 47262 RVA: 0x002A4BFA File Offset: 0x002A2FFA
		public bool isOpen
		{
			get
			{
				return this.Status != PremiumLeagueStatus.PLS_INIT;
			}
		}

		// Token: 0x17001B38 RID: 6968
		// (get) Token: 0x0600B89F RID: 47263 RVA: 0x002A4C08 File Offset: 0x002A3008
		public bool needEnterance
		{
			get
			{
				return this.Status != PremiumLeagueStatus.PLS_INIT && this.Status != PremiumLeagueStatus.PLS_FINAL_WAIT_CLEAR;
			}
		}

		// Token: 0x17001B39 RID: 6969
		// (get) Token: 0x0600B8A0 RID: 47264 RVA: 0x002A4C24 File Offset: 0x002A3024
		public MoneyRewardsStatus eMoneyRewardsStatus
		{
			get
			{
				switch (this.Status)
				{
				case PremiumLeagueStatus.PLS_INIT:
					return MoneyRewardsStatus.MRS_INVALID;
				case PremiumLeagueStatus.PLS_ENROLL:
					return MoneyRewardsStatus.MRS_READY;
				case PremiumLeagueStatus.PLS_PRELIMINAY:
					return MoneyRewardsStatus.MRS_8_RACE;
				case PremiumLeagueStatus.PLS_FINAL_EIGHT_PREPARE:
					return MoneyRewardsStatus.MRS_PRE_4_RACE;
				case PremiumLeagueStatus.PLS_FINAL_EIGHT:
					return MoneyRewardsStatus.MRS_4_RACE;
				case PremiumLeagueStatus.PLS_FINAL_FOUR:
					return MoneyRewardsStatus.MRS_2_RACE;
				case PremiumLeagueStatus.PLS_FINAL:
					return MoneyRewardsStatus.MRS_RACE;
				case PremiumLeagueStatus.PLS_FINAL_WAIT_CLEAR:
					return MoneyRewardsStatus.MRS_END;
				default:
					return MoneyRewardsStatus.MRS_INVALID;
				}
			}
		}

		// Token: 0x17001B3A RID: 6970
		// (get) Token: 0x0600B8A1 RID: 47265 RVA: 0x002A4C74 File Offset: 0x002A3074
		public List<ComMoneyRewardsRecordsData> Records
		{
			get
			{
				return this.records;
			}
		}

		// Token: 0x0600B8A2 RID: 47266 RVA: 0x002A4C7C File Offset: 0x002A307C
		public int getDataCount(bool bSelfRelation)
		{
			int num = 0;
			for (int i = 0; i < this.records.Count; i++)
			{
				if (!bSelfRelation || this.records[i].HasSelfInfo)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x0600B8A3 RID: 47267 RVA: 0x002A4CC8 File Offset: 0x002A30C8
		public ComMoneyRewardsRecordsData getData(int iIndex, bool bSelfRelation)
		{
			if (iIndex >= 0 && iIndex < this.records.Count)
			{
				if (!bSelfRelation)
				{
					return this.records[iIndex];
				}
				int num = -1;
				for (int i = 0; i < this.records.Count; i++)
				{
					if (this.records[i].HasSelfInfo)
					{
						num++;
						if (iIndex == num)
						{
							return this.records[i];
						}
					}
				}
			}
			return null;
		}

		// Token: 0x0600B8A4 RID: 47268 RVA: 0x002A4D4D File Offset: 0x002A314D
		private void _TryStartSecondMatch()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMoneyRewardsTrySecondMatch, null, null, null, null);
		}

		// Token: 0x0600B8A5 RID: 47269 RVA: 0x002A4D64 File Offset: 0x002A3164
		public void SendMatchParty()
		{
			if (!this.CanMatch)
			{
				return;
			}
			WorldMatchStartReq cmd = new WorldMatchStartReq
			{
				type = 5
			};
			NetManager.Instance().SendCommand<WorldMatchStartReq>(ServerType.GATE_SERVER, cmd);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldMatchStartRes>(delegate(WorldMatchStartRes msgRet)
			{
				if (msgRet == null)
				{
					return;
				}
				if (msgRet.result != 0U)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PkMatchFailed, null, null, null, null);
					if (msgRet.result == 3302003U)
					{
						if (this.addPartyTimes == 1)
						{
							this._TryStartSecondMatch();
						}
						else
						{
							SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
						}
					}
					else
					{
						SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
					}
					return;
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PkMatchStartSuccess, null, null, null, null);
			}, true, 15f, null);
		}

		// Token: 0x0600B8A6 RID: 47270 RVA: 0x002A4DB8 File Offset: 0x002A31B8
		public void GotoPvpFight()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return;
			}
			if (Singleton<TableManager>.instance.GetTableItem<CitySceneTable>(DataManager<MoneyRewardsDataManager>.GetInstance().SceneID, string.Empty, string.Empty) == null)
			{
				return;
			}
			int sceneID = DataManager<MoneyRewardsDataManager>.GetInstance().SceneID;
			if (clientSystemTown.CurrentSceneID != sceneID && sceneID > 0)
			{
				MonoSingleton<GameFrameWork>.instance.StartCoroutine(clientSystemTown._NetSyncChangeScene(new SceneParams
				{
					currSceneID = clientSystemTown.CurrentSceneID,
					currDoorID = 0,
					targetSceneID = sceneID,
					targetDoorID = 0
				}, false));
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<PkWaitingRoom>(null, false);
			}
		}

		// Token: 0x040067E6 RID: 26598
		private int m_iActiveID = 8888;

		// Token: 0x040067E7 RID: 26599
		private int m_iSceneID = -5005;

		// Token: 0x040067E8 RID: 26600
		private int _playerCount;

		// Token: 0x040067E9 RID: 26601
		private int _addPratyTimes;

		// Token: 0x040067EA RID: 26602
		private int _moneys;

		// Token: 0x040067EB RID: 26603
		private int _vsAwards;

		// Token: 0x040067EC RID: 26604
		private int iDefChampAward = -1;

		// Token: 0x040067ED RID: 26605
		private List<int> _awardsList = new List<int>();

		// Token: 0x040067EE RID: 26606
		private int[] _stages = new int[4];

		// Token: 0x040067EF RID: 26607
		private int _winTimes;

		// Token: 0x040067F0 RID: 26608
		private int _loseTimes;

		// Token: 0x040067F1 RID: 26609
		private int _rank;

		// Token: 0x040067F2 RID: 26610
		private int _score;

		// Token: 0x040067F3 RID: 26611
		private int _maxScore;

		// Token: 0x040067F4 RID: 26612
		private MoneyRewaradsRankItemData[] _rankItems = new MoneyRewaradsRankItemData[100];

		// Token: 0x040067F5 RID: 26613
		private MoneyRewaradsRankItemData _rankItemSelf = new MoneyRewaradsRankItemData();

		// Token: 0x040067F6 RID: 26614
		private List<MoneyRewardsDataManager.RecordDownLoad> _records = new List<MoneyRewardsDataManager.RecordDownLoad>();

		// Token: 0x040067F7 RID: 26615
		private List<CLPremiumLeagueBattle> m_battles = new List<CLPremiumLeagueBattle>();

		// Token: 0x040067F8 RID: 26616
		private PremiumLeagueStatusInfo activeInfo = new PremiumLeagueStatusInfo();

		// Token: 0x040067F9 RID: 26617
		private int _totalRecordsCount;

		// Token: 0x040067FA RID: 26618
		private ComMoneyRewardsResultData[] resultDatas = new ComMoneyRewardsResultData[8];

		// Token: 0x040067FB RID: 26619
		private int[,] m_pairs = new int[,]
		{
			{
				0,
				7
			},
			{
				1,
				6
			},
			{
				2,
				5
			},
			{
				3,
				4
			},
			{
				4,
				3
			},
			{
				5,
				2
			},
			{
				6,
				1
			},
			{
				7,
				0
			}
		};

		// Token: 0x040067FC RID: 26620
		private int[] m_map_pairs = new int[]
		{
			459524,
			117441284,
			50593799,
			67305479,
			17170949,
			100729349,
			33882374,
			84017414
		};

		// Token: 0x040067FD RID: 26621
		private List<ComMoneyRewardsRecordsData> records = new List<ComMoneyRewardsRecordsData>();

		// Token: 0x020012B2 RID: 4786
		public enum RecordDownLoadType
		{
			// Token: 0x04006801 RID: 26625
			RDT_INIT,
			// Token: 0x04006802 RID: 26626
			RDT_LOADING,
			// Token: 0x04006803 RID: 26627
			RDT_FINISH,
			// Token: 0x04006804 RID: 26628
			RDT_FAILED
		}

		// Token: 0x020012B3 RID: 4787
		public class RecordDownLoad
		{
			// Token: 0x04006805 RID: 26629
			public ulong a_raceId;

			// Token: 0x04006806 RID: 26630
			public UnityAction<ulong> cb;

			// Token: 0x04006807 RID: 26631
			public MoneyRewardsDataManager.RecordDownLoadType eRecordDownLoadType;

			// Token: 0x04006808 RID: 26632
			public string sessionID;

			// Token: 0x04006809 RID: 26633
			public ReplayWaitHttpRequest req;

			// Token: 0x0400680A RID: 26634
			public bool IsCrossService;
		}
	}
}
