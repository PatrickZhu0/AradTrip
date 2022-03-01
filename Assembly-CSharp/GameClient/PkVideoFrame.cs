using System;
using System.Collections;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200199D RID: 6557
	internal class PkVideoFrame : ClientFrame
	{
		// Token: 0x0600FF37 RID: 65335 RVA: 0x0046A423 File Offset: 0x00468823
		protected override void _bindExUI()
		{
			this.mPkNum = this.mBind.GetCom<Text>("pkNum");
			this.mPkWinRate = this.mBind.GetCom<Text>("pkWinRate");
		}

		// Token: 0x0600FF38 RID: 65336 RVA: 0x0046A451 File Offset: 0x00468851
		protected override void _unbindExUI()
		{
			this.mPkNum = null;
			this.mPkWinRate = null;
		}

		// Token: 0x0600FF39 RID: 65337 RVA: 0x0046A461 File Offset: 0x00468861
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/PkVideo/PkVideo";
		}

		// Token: 0x0600FF3A RID: 65338 RVA: 0x0046A468 File Offset: 0x00468868
		protected override void _OnOpenFrame()
		{
			this._RegisterUIEvent();
			this._InitUI();
		}

		// Token: 0x0600FF3B RID: 65339 RVA: 0x0046A476 File Offset: 0x00468876
		protected override void _OnCloseFrame()
		{
			this._UnRegisterUIEvent();
			this._ClearUI();
		}

		// Token: 0x0600FF3C RID: 65340 RVA: 0x0046A484 File Offset: 0x00468884
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PKMyRecordUpdated, new ClientEventSystem.UIEventHandler(this._OnMyPkUpdated));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PKPeakRecordUpdated, new ClientEventSystem.UIEventHandler(this._OnPeakPkUpdated));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnUploadFileSucc, new ClientEventSystem.UIEventHandler(this._onUpLoadSucc));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnUploadFileClose, new ClientEventSystem.UIEventHandler(this._onUpLoadClose));
		}

		// Token: 0x0600FF3D RID: 65341 RVA: 0x0046A500 File Offset: 0x00468900
		private void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PKMyRecordUpdated, new ClientEventSystem.UIEventHandler(this._OnMyPkUpdated));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PKPeakRecordUpdated, new ClientEventSystem.UIEventHandler(this._OnPeakPkUpdated));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnUploadFileSucc, new ClientEventSystem.UIEventHandler(this._onUpLoadSucc));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnUploadFileClose, new ClientEventSystem.UIEventHandler(this._onUpLoadClose));
		}

		// Token: 0x0600FF3E RID: 65342 RVA: 0x0046A57C File Offset: 0x0046897C
		private void _onUpLoadSucc(UIEvent a_event)
		{
			VideoInfo videoInfo = a_event.Param1 as VideoInfo;
			if (videoInfo != null && videoInfo.btnGo != null)
			{
				videoInfo.btnGo.CustomActive(false);
			}
		}

		// Token: 0x0600FF3F RID: 65343 RVA: 0x0046A5B8 File Offset: 0x004689B8
		private void _onUpLoadClose(UIEvent a_event)
		{
		}

		// Token: 0x0600FF40 RID: 65344 RVA: 0x0046A5BC File Offset: 0x004689BC
		private void _InitUI()
		{
			this._InitMyPkUI();
			this._InitPeakPkUI();
			this._Init3V3PkUI();
			this.m_togMyPk.onValueChanged.AddListener(delegate(bool var)
			{
				if (var)
				{
					DataManager<SeasonDataManager>.GetInstance().RequsetMyPkRecord();
					PkVideoFrame.isShowMyVideo = true;
					PkVideoFrame.isShow3V3Video = false;
				}
			});
			this.m_tog3V3Pk.onValueChanged.AddListener(delegate(bool var)
			{
				if (var)
				{
					DataManager<SeasonDataManager>.GetInstance().RequsetMyPkRecord();
					PkVideoFrame.isShow3V3Video = true;
					PkVideoFrame.isShowMyVideo = false;
				}
			});
			this.m_togPeakPk.onValueChanged.AddListener(delegate(bool var)
			{
				if (var)
				{
					DataManager<SeasonDataManager>.GetInstance().RequsetPeakPkRecord();
					PkVideoFrame.isShowMyVideo = false;
					PkVideoFrame.isShow3V3Video = false;
				}
			});
			if (PkVideoFrame.isShowMyVideo)
			{
				this.m_togMyPk.isOn = true;
			}
			else if (PkVideoFrame.isShow3V3Video)
			{
				this.m_tog3V3Pk.isOn = true;
			}
			else
			{
				this.m_togPeakPk.isOn = true;
			}
			this.SetPKInfo();
		}

		// Token: 0x0600FF41 RID: 65345 RVA: 0x0046A6AC File Offset: 0x00468AAC
		private void SetPKInfo()
		{
			int num = 0;
			int num2 = 0;
			for (int i = 0; i <= 4; i++)
			{
				PkStatistic pkStatisticDataByPkType = DataManager<PlayerBaseData>.GetInstance().GetPkStatisticDataByPkType((PkType)i);
				if (pkStatisticDataByPkType != null)
				{
					num += (int)pkStatisticDataByPkType.totalNum;
					num2 += (int)pkStatisticDataByPkType.totalWinNum;
				}
			}
			this.mPkNum.text = num.ToString();
			if (num <= 0)
			{
				this.mPkWinRate.text = "0%";
			}
			else
			{
				this.mPkWinRate.text = string.Format("{0:F1}%", (float)num2 / (float)num * 100f);
			}
		}

		// Token: 0x0600FF42 RID: 65346 RVA: 0x0046A74C File Offset: 0x00468B4C
		private void _ClearUI()
		{
			this._ClearMyPkUI();
			this._ClearPeakPkUI();
		}

		// Token: 0x0600FF43 RID: 65347 RVA: 0x0046A75A File Offset: 0x00468B5A
		private void _InitMyPkUI()
		{
			this.m_comMyPkList.Initialize();
			this.m_comMyPkList.onItemVisiable = delegate(ComUIListElementScript var)
			{
				if (this.m_myPkRecords != null && var.m_index >= 0 && var.m_index < this.m_myPkRecordsLst.Count)
				{
					ComMyPkRecord comUI = var.GetComponent<ComMyPkRecord>();
					if (comUI != null)
					{
						ReplayInfo recordData = this.m_myPkRecordsLst[this.m_myPkRecordsLst.Count - var.m_index - 1];
						bool flag = false;
						ReplayFighterInfo a_data;
						ReplayFighterInfo a_data2;
						if (recordData.fighters[0].roleId == DataManager<PlayerBaseData>.GetInstance().RoleID)
						{
							a_data = recordData.fighters[0];
							a_data2 = recordData.fighters[1];
						}
						else
						{
							a_data = recordData.fighters[1];
							a_data2 = recordData.fighters[0];
							flag = true;
						}
						this._SetupPlayerInfo(comUI.imgLeftSeasonIcon, comUI.labLeftName, comUI.labLeftJob, comUI.labLeftSeasonName, a_data);
						this._SetupPlayerInfo(comUI.imgRightSeasonIcon, comUI.labRightName, comUI.labRightJob, comUI.labRightSeasonName, a_data2);
						PKVideoResult pkvideoResult = (PKVideoResult)recordData.result;
						if (flag)
						{
							if (pkvideoResult == PKVideoResult.WIN)
							{
								pkvideoResult = PKVideoResult.LOSE;
							}
							else if (pkvideoResult == PKVideoResult.LOSE)
							{
								pkvideoResult = PKVideoResult.WIN;
							}
						}
						switch (pkvideoResult)
						{
						case PKVideoResult.WIN:
							ETCImageLoader.LoadSprite(ref comUI.imgPkResult, "UI/Image/Packed/p_UI_BattleInterface.png:UI_Zhandou_Zi_Shengli", true);
							comUI.imgPkResult.SetNativeSize();
							break;
						case PKVideoResult.LOSE:
							ETCImageLoader.LoadSprite(ref comUI.imgPkResult, "UI/Image/Packed/p_UI_BattleInterface.png:UI_Season_Zi_Shibai", true);
							comUI.imgPkResult.SetNativeSize();
							break;
						case PKVideoResult.DRAW:
							ETCImageLoader.LoadSprite(ref comUI.imgPkResult, "UI/Image/Packed/p_UI_BattleInterface.png:UI_Season_Duanwen_Pingju", true);
							comUI.imgPkResult.SetNativeSize();
							break;
						default:
							ETCImageLoader.LoadSprite(ref comUI.imgPkResult, "UI/Image/Packed/p_UI_SeasonNumber.png:UI_Season_Duanwen_Jieguoyichang", true);
							comUI.imgPkResult.SetNativeSize();
							break;
						}
						this._SetupCreateTime(comUI.labCreateTime, recordData.recordTime);
						comUI.btnPlay.onClick.RemoveAllListeners();
						comUI.btnUpLoad.onClick.RemoveAllListeners();
						comUI.btnPlay.onClick.AddListener(delegate()
						{
							this.PlayReplay(recordData.raceId, true, 0U);
						});
						comUI.btnUpLoad.onClick.AddListener(delegate()
						{
							this.onUpLoadRecord(recordData.raceId, comUI.btnUpLoad.gameObject, true, 0U);
						});
					}
				}
			};
		}

		// Token: 0x0600FF44 RID: 65348 RVA: 0x0046A780 File Offset: 0x00468B80
		private void onUpLoadRecord(ulong a_raceID, GameObject btn, bool normal = true, uint version = 0U)
		{
			string text = a_raceID.ToString();
			if (Singleton<ReplayServer>.GetInstance().HasReplay(text))
			{
				ReplayErrorCode replayErrorCode = Singleton<ReplayServer>.GetInstance().CompressRecord(text);
				if (replayErrorCode == ReplayErrorCode.SUCCEED)
				{
					VideoInfo userData = new VideoInfo
					{
						sessionId = text,
						btnGo = btn
					};
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<PKReporterFrame>(FrameLayer.Middle, userData, string.Empty);
				}
				else
				{
					this.ShowNotify(replayErrorCode);
				}
			}
			else if (normal)
			{
				this.ShowNotify(ReplayErrorCode.FILE_NOT_FOUND);
			}
			else if (!Singleton<ReplayServer>.GetInstance().CheckVersion(version))
			{
				this.ShowNotify(ReplayErrorCode.VERSION_NOT_MATCH);
			}
			else
			{
				this.StartDownloadReplayFileAndUpLoad(a_raceID, btn);
			}
		}

		// Token: 0x0600FF45 RID: 65349 RVA: 0x0046A830 File Offset: 0x00468C30
		private void StartDownloadReplayFileAndUpLoad(ulong a_raceID, GameObject btnGo)
		{
			PkVideoFrame.<StartDownloadReplayFileAndUpLoad>c__AnonStorey4 <StartDownloadReplayFileAndUpLoad>c__AnonStorey = new PkVideoFrame.<StartDownloadReplayFileAndUpLoad>c__AnonStorey4();
			<StartDownloadReplayFileAndUpLoad>c__AnonStorey.btnGo = btnGo;
			<StartDownloadReplayFileAndUpLoad>c__AnonStorey.$this = this;
			<StartDownloadReplayFileAndUpLoad>c__AnonStorey.sessionID = a_raceID.ToString();
			if (this.mCurrentLoadServerCo != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.mCurrentLoadServerCo);
			}
			this.mCurrentLoadServerCo = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this.SendHttpReqReplayFile(<StartDownloadReplayFileAndUpLoad>c__AnonStorey.sessionID, delegate(string sid)
			{
				Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(2000, delegate
				{
					ReplayErrorCode replayErrorCode = Singleton<ReplayServer>.GetInstance().CompressRecord(sid);
					if (replayErrorCode == ReplayErrorCode.SUCCEED)
					{
						VideoInfo userData = new VideoInfo
						{
							sessionId = <StartDownloadReplayFileAndUpLoad>c__AnonStorey.sessionID,
							btnGo = <StartDownloadReplayFileAndUpLoad>c__AnonStorey.btnGo
						};
						Singleton<ClientSystemManager>.GetInstance().OpenFrame<PKReporterFrame>(FrameLayer.Middle, userData, string.Empty);
					}
					else
					{
						<StartDownloadReplayFileAndUpLoad>c__AnonStorey.ShowNotify(replayErrorCode);
					}
				}, 0, 0, false);
			}));
		}

		// Token: 0x0600FF46 RID: 65350 RVA: 0x0046A8A8 File Offset: 0x00468CA8
		private void _UpdateMyPkUI(SceneReplayListRes a_data)
		{
			this.m_3v3PkRecordLst.Clear();
			this.m_myPkRecordsLst.Clear();
			this.m_myPkRecords = a_data;
			for (int i = 0; i < this.m_myPkRecords.replays.Length; i++)
			{
				if (this.m_myPkRecords.replays[i].type == 7 || this.m_myPkRecords.replays[i].type == 8)
				{
					this.m_3v3PkRecordLst.Add(this.m_myPkRecords.replays[i]);
				}
				else
				{
					this.m_myPkRecordsLst.Add(this.m_myPkRecords.replays[i]);
				}
			}
			if (this.m_myPkRecords != null && this.m_myPkRecords.replays != null && this.m_myPkRecordsLst.Count > 0)
			{
				this.m_comMyPkList.SetElementAmount(this.m_myPkRecordsLst.Count);
			}
			else
			{
				this.m_comMyPkList.SetElementAmount(0);
			}
			if (this.m_myPkRecords != null && this.m_myPkRecords.replays != null && this.m_3v3PkRecordLst.Count > 0)
			{
				this.m_com3v3PkList.SetElementAmount(this.m_3v3PkRecordLst.Count);
			}
			else
			{
				this.m_com3v3PkList.SetElementAmount(0);
			}
		}

		// Token: 0x0600FF47 RID: 65351 RVA: 0x0046A9FB File Offset: 0x00468DFB
		private void _ClearMyPkUI()
		{
			this.m_myPkRecords = null;
			this.m_myPkRecordsLst.Clear();
			this.m_3v3PkRecordLst.Clear();
		}

		// Token: 0x0600FF48 RID: 65352 RVA: 0x0046AA1A File Offset: 0x00468E1A
		private void _Init3V3PkUI()
		{
			this.m_com3v3PkList.Initialize();
			this.m_com3v3PkList.onItemVisiable = delegate(ComUIListElementScript var)
			{
				if (this.m_3v3PkRecordLst != null && var.m_index >= 0 && var.m_index < this.m_3v3PkRecordLst.Count)
				{
					ComMyPkRecord comUI = var.GetComponent<ComMyPkRecord>();
					if (comUI != null)
					{
						ReplayInfo recordData = this.m_3v3PkRecordLst[this.m_3v3PkRecordLst.Count - var.m_index - 1];
						bool flag = false;
						if (comUI.playerNames != null)
						{
							bool flag2 = false;
							bool flag3 = false;
							int num = 0;
							int num2 = 0;
							for (int i = 0; i < recordData.fighters.Length; i++)
							{
								bool flag4 = false;
								ReplayFighterInfo replayFighterInfo = recordData.fighters[i];
								if (replayFighterInfo.pos >= 0 && replayFighterInfo.pos <= 2)
								{
									num++;
									flag4 = true;
									if (!flag2)
									{
										flag2 = true;
										ETCImageLoader.LoadSprite(ref comUI.imgLeftSeasonIcon, DataManager<SeasonDataManager>.GetInstance().GetMainSeasonLevelIcon((int)replayFighterInfo.seasonLevel), true);
									}
									if (replayFighterInfo.roleId == DataManager<PlayerBaseData>.GetInstance().RoleID)
									{
										flag = false;
									}
								}
								else
								{
									num2++;
									if (replayFighterInfo.roleId == DataManager<PlayerBaseData>.GetInstance().RoleID)
									{
										flag = true;
									}
									if (!flag3)
									{
										flag3 = true;
										ETCImageLoader.LoadSprite(ref comUI.imgRightSeasonIcon, DataManager<SeasonDataManager>.GetInstance().GetMainSeasonLevelIcon((int)replayFighterInfo.seasonLevel), true);
									}
								}
								if ((int)replayFighterInfo.pos > comUI.playerNames.Length)
								{
									Logger.LogErrorFormat("fighter id {0} name {1} Index [2] pos {3} out of playerNames Length {4}", new object[]
									{
										replayFighterInfo.roleId,
										replayFighterInfo.name,
										i,
										replayFighterInfo.pos,
										comUI.playerNames.Length
									});
									comUI.playerNames[(int)replayFighterInfo.pos].text = string.Empty;
								}
								else if (flag4)
								{
									comUI.playerNames[num - 1].text = replayFighterInfo.name;
								}
								else
								{
									comUI.playerNames[num2 - 1 + 3].text = replayFighterInfo.name;
								}
							}
							if (comUI.playerNames.Length != 6)
							{
								Logger.LogErrorFormat("3v3 playerNameLength number is not right {0}", new object[]
								{
									comUI.playerNames.Length
								});
							}
							else
							{
								for (int j = num; j < 3; j++)
								{
									comUI.playerNames[j].text = string.Empty;
								}
								for (int k = num2; k < 3; k++)
								{
									comUI.playerNames[k + 3].text = string.Empty;
								}
							}
						}
						PKVideoResult pkvideoResult = (PKVideoResult)recordData.result;
						if (flag)
						{
							if (pkvideoResult == PKVideoResult.WIN)
							{
								pkvideoResult = PKVideoResult.LOSE;
							}
							else if (pkvideoResult == PKVideoResult.LOSE)
							{
								pkvideoResult = PKVideoResult.WIN;
							}
						}
						switch (pkvideoResult)
						{
						case PKVideoResult.WIN:
							ETCImageLoader.LoadSprite(ref comUI.imgPkResult, "UI/Image/Packed/p_UI_BattleInterface.png:UI_Zhandou_Zi_Shengli", true);
							comUI.imgPkResult.SetNativeSize();
							break;
						case PKVideoResult.LOSE:
							ETCImageLoader.LoadSprite(ref comUI.imgPkResult, "UI/Image/Packed/p_UI_BattleInterface.png:UI_Season_Zi_Shibai", true);
							comUI.imgPkResult.SetNativeSize();
							break;
						case PKVideoResult.DRAW:
							ETCImageLoader.LoadSprite(ref comUI.imgPkResult, "UI/Image/Packed/p_UI_BattleInterface.png:UI_Season_Duanwen_Pingju", true);
							comUI.imgPkResult.SetNativeSize();
							break;
						default:
							ETCImageLoader.LoadSprite(ref comUI.imgPkResult, "UI/Image/Packed/p_UI_SeasonNumber.png:UI_Season_Duanwen_Jieguoyichang", true);
							comUI.imgPkResult.SetNativeSize();
							break;
						}
						this._SetupCreateTime(comUI.labCreateTime, recordData.recordTime);
						comUI.btnPlay.onClick.RemoveAllListeners();
						comUI.btnUpLoad.onClick.RemoveAllListeners();
						comUI.btnPlay.onClick.AddListener(delegate()
						{
							this.PlayReplay(recordData.raceId, true, 0U);
						});
						comUI.btnUpLoad.onClick.AddListener(delegate()
						{
							this.onUpLoadRecord(recordData.raceId, comUI.btnUpLoad.gameObject, true, 0U);
						});
					}
				}
			};
		}

		// Token: 0x0600FF49 RID: 65353 RVA: 0x0046AA3E File Offset: 0x00468E3E
		private void _InitPeakPkUI()
		{
			this.m_comPeakPkList.Initialize();
			this.m_comPeakPkList.onItemVisiable = delegate(ComUIListElementScript var)
			{
				if (this.m_peakPkRecords != null)
				{
					ReplayInfo[] replays = this.m_peakPkRecords.replays;
					Array.Sort<ReplayInfo>(replays, delegate(ReplayInfo x, ReplayInfo y)
					{
						if (x.viewNum != y.viewNum)
						{
							return x.viewNum.CompareTo(y.viewNum);
						}
						if (x.recordTime != y.recordTime)
						{
							return x.recordTime.CompareTo(y.recordTime);
						}
						return 0;
					});
					if (var.m_index >= 0 && var.m_index < replays.Length)
					{
						ComPeakPkRecord comUI = var.GetComponent<ComPeakPkRecord>();
						if (comUI != null)
						{
							ReplayInfo recordData = replays[replays.Length - var.m_index - 1];
							this._SetupPlayerInfo(comUI.imgLeftSeasonIcon, comUI.labLeftName, comUI.labLeftJob, comUI.labLeftSeasonName, recordData.fighters[0]);
							this._SetupPlayerInfo(comUI.imgRightSeasonIcon, comUI.labRightName, comUI.labRightJob, comUI.labRightSeasonName, recordData.fighters[1]);
							switch (recordData.result)
							{
							case 1:
								comUI.labPkResult.text = TR.Value("pk_record_result_win");
								break;
							case 2:
								comUI.labPkResult.text = TR.Value("pk_record_result_lose");
								break;
							case 3:
								comUI.labPkResult.text = TR.Value("pk_record_result_draw");
								break;
							default:
								comUI.labPkResult.text = string.Empty;
								break;
							}
							this._SetupCreateTime(comUI.labCreateTime, recordData.recordTime);
							comUI.labPlayTime.text = TR.Value("pk_record_play_time", recordData.viewNum);
							comUI.labScore.text = TR.Value("pk_record_score", recordData.score);
							comUI.btnPlay.onClick.RemoveAllListeners();
							comUI.btnUpload.onClick.RemoveAllListeners();
							comUI.btnPlay.onClick.AddListener(delegate()
							{
								this.PlayReplay(recordData.raceId, false, recordData.version);
							});
							comUI.btnUpload.onClick.AddListener(delegate()
							{
								this.onUpLoadRecord(recordData.raceId, comUI.btnUpload.gameObject, false, recordData.version);
							});
						}
					}
				}
			};
		}

		// Token: 0x0600FF4A RID: 65354 RVA: 0x0046AA64 File Offset: 0x00468E64
		private void _UpdatePeakPkUI(SceneReplayListRes a_data)
		{
			this.m_peakPkRecords = a_data;
			if (this.m_peakPkRecords != null && this.m_peakPkRecords.replays != null)
			{
				this.m_comPeakPkList.SetElementAmount(this.m_peakPkRecords.replays.Length);
			}
			else
			{
				this.m_comPeakPkList.SetElementAmount(0);
			}
		}

		// Token: 0x0600FF4B RID: 65355 RVA: 0x0046AABC File Offset: 0x00468EBC
		private void _ClearPeakPkUI()
		{
			this.m_peakPkRecords = null;
		}

		// Token: 0x0600FF4C RID: 65356 RVA: 0x0046AAC8 File Offset: 0x00468EC8
		private void _SetupCreateTime(Text a_lab, uint a_nRecordTime)
		{
			int num = 0;
			uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
			if (serverTime > a_nRecordTime)
			{
				num = (int)(serverTime - a_nRecordTime);
			}
			if (num < 3600)
			{
				int num2 = num / 60;
				a_lab.text = TR.Value("pk_record_time_minute", num2);
			}
			else if (num < 86400)
			{
				int num3 = num / 3600;
				a_lab.text = TR.Value("pk_record_time_hour", num3);
			}
			else
			{
				int num4 = num / 86400;
				if (num4 > 30)
				{
					num4 = 30;
				}
				a_lab.text = TR.Value("pk_record_time_day", num4);
			}
		}

		// Token: 0x0600FF4D RID: 65357 RVA: 0x0046AB74 File Offset: 0x00468F74
		private void _SetupPlayerInfo(Image a_imgSeasonIcon, Text a_labName, Text a_labJob, Text a_labSeasonName, ReplayFighterInfo a_data)
		{
			ETCImageLoader.LoadSprite(ref a_imgSeasonIcon, DataManager<SeasonDataManager>.GetInstance().GetMainSeasonLevelIcon((int)a_data.seasonLevel), true);
			a_labName.text = a_data.name;
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)a_data.occu, string.Empty, string.Empty);
			if (tableItem != null)
			{
				a_labJob.text = tableItem.Name;
			}
			else
			{
				a_labJob.text = string.Empty;
			}
			a_labSeasonName.text = DataManager<SeasonDataManager>.GetInstance().GetRankName((int)a_data.seasonLevel, true);
		}

		// Token: 0x0600FF4E RID: 65358 RVA: 0x0046ABFF File Offset: 0x00468FFF
		private void _OnMyPkUpdated(UIEvent a_event)
		{
			this._UpdateMyPkUI(a_event.Param1 as SceneReplayListRes);
		}

		// Token: 0x0600FF4F RID: 65359 RVA: 0x0046AC12 File Offset: 0x00469012
		private void _OnPeakPkUpdated(UIEvent a_event)
		{
			this._UpdatePeakPkUI(a_event.Param1 as SceneReplayListRes);
		}

		// Token: 0x0600FF50 RID: 65360 RVA: 0x0046AC25 File Offset: 0x00469025
		[UIEventHandle("BG/Title/Close")]
		private void _OnCloseClicked()
		{
			PkVideoFrame.isShowMyVideo = true;
			PkVideoFrame.isShow3V3Video = false;
			this.frameMgr.CloseFrame<PkVideoFrame>(this, false);
		}

		// Token: 0x0600FF51 RID: 65361 RVA: 0x0046AC40 File Offset: 0x00469040
		private void PlayReplay(ulong a_raceID, bool normal = true, uint version = 0U)
		{
			string filename = a_raceID.ToString();
			if (Singleton<ReplayServer>.GetInstance().HasReplay(filename))
			{
				ReplayErrorCode replayErrorCode = Singleton<ReplayServer>.GetInstance().StartReplay(filename, ReplayPlayFrom.VIDEO_FRAME, false, false, false);
				if (replayErrorCode == ReplayErrorCode.SUCCEED)
				{
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
			else if (!Singleton<ReplayServer>.GetInstance().CheckVersion(version))
			{
				this.ShowNotify(ReplayErrorCode.VERSION_NOT_MATCH);
			}
			else
			{
				this.StartDownloadReplayFile(a_raceID);
			}
		}

		// Token: 0x0600FF52 RID: 65362 RVA: 0x0046ACDC File Offset: 0x004690DC
		private void ShowNotify(ReplayErrorCode code)
		{
			MoneyRewardsDataManager.ShowErrorNotify(code);
		}

		// Token: 0x0600FF53 RID: 65363 RVA: 0x0046ACE4 File Offset: 0x004690E4
		private void StartDownloadReplayFile(ulong a_raceID)
		{
			PkVideoFrame.<StartDownloadReplayFile>c__AnonStoreyA <StartDownloadReplayFile>c__AnonStoreyA = new PkVideoFrame.<StartDownloadReplayFile>c__AnonStoreyA();
			<StartDownloadReplayFile>c__AnonStoreyA.a_raceID = a_raceID;
			<StartDownloadReplayFile>c__AnonStoreyA.$this = this;
			string sessionID = <StartDownloadReplayFile>c__AnonStoreyA.a_raceID.ToString();
			if (this.mCurrentLoadServerCo != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.mCurrentLoadServerCo);
			}
			this.mCurrentLoadServerCo = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this.SendHttpReqReplayFile(sessionID, delegate(string sid)
			{
				Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(2000, delegate
				{
					ReplayErrorCode replayErrorCode = Singleton<ReplayServer>.GetInstance().StartReplay(sid, ReplayPlayFrom.VIDEO_FRAME, false, false, false);
					if (replayErrorCode == ReplayErrorCode.SUCCEED)
					{
						DataManager<SeasonDataManager>.GetInstance().NotifyVideoPlayed(<StartDownloadReplayFile>c__AnonStoreyA.a_raceID);
					}
					else
					{
						Singleton<ReplayServer>.GetInstance().Clear();
					}
					<StartDownloadReplayFile>c__AnonStoreyA.ShowNotify(replayErrorCode);
				}, 0, 0, false);
			}));
		}

		// Token: 0x0600FF54 RID: 65364 RVA: 0x0046AD58 File Offset: 0x00469158
		private IEnumerator SendHttpReqReplayFile(string sessionID, Action<string> cb = null)
		{
			ReplayWaitHttpRequest req = new ReplayWaitHttpRequest(sessionID, false);
			yield return req;
			if (req.GetResult() == BaseWaitHttpRequest.eState.Success)
			{
				byte[] resultBytes = req.GetResultBytes();
				if (resultBytes == null || resultBytes.Length <= 0)
				{
					this.ShowNotify(ReplayErrorCode.DOWNLOAD_FAILED);
					yield break;
				}
				byte[] array = resultBytes;
				RecordData.SaveReplayFile(sessionID, array, array.Length, string.Empty);
				if (cb != null)
				{
					cb(sessionID);
				}
			}
			else
			{
				this.ShowNotify(ReplayErrorCode.DOWNLOAD_FAILED);
			}
			yield break;
		}

		// Token: 0x0400A0F9 RID: 41209
		[UIControl("Content/Tabs/Viewport/Content/MyPk", null, 0)]
		private Toggle m_togMyPk;

		// Token: 0x0400A0FA RID: 41210
		[UIControl("Content/Tabs/Viewport/Content/PeakPk", null, 0)]
		private Toggle m_togPeakPk;

		// Token: 0x0400A0FB RID: 41211
		[UIControl("Content/Tabs/Viewport/Content/3V3Pk", null, 0)]
		private Toggle m_tog3V3Pk;

		// Token: 0x0400A0FC RID: 41212
		[UIControl("Content/Tabs/Viewport/Content/StorePk", null, 0)]
		private Toggle m_togStorePk;

		// Token: 0x0400A0FD RID: 41213
		[UIControl("Content/Groups/MyPkGroup/Records", null, 0)]
		private ComUIListScript m_comMyPkList;

		// Token: 0x0400A0FE RID: 41214
		[UIControl("Content/Groups/PeakPkGroup/Records", null, 0)]
		private ComUIListScript m_comPeakPkList;

		// Token: 0x0400A0FF RID: 41215
		[UIControl("Content/Groups/3V3PkGroup/Records", null, 0)]
		private ComUIListScript m_com3v3PkList;

		// Token: 0x0400A100 RID: 41216
		private SceneReplayListRes m_myPkRecords;

		// Token: 0x0400A101 RID: 41217
		private SceneReplayListRes m_peakPkRecords;

		// Token: 0x0400A102 RID: 41218
		private List<ReplayInfo> m_myPkRecordsLst = new List<ReplayInfo>();

		// Token: 0x0400A103 RID: 41219
		private List<ReplayInfo> m_3v3PkRecordLst = new List<ReplayInfo>();

		// Token: 0x0400A104 RID: 41220
		private const string m_strPkResultWin = "UI/Image/Packed/p_UI_BattleInterface.png:UI_Zhandou_Zi_Shengli";

		// Token: 0x0400A105 RID: 41221
		private const string m_strPkResultLose = "UI/Image/Packed/p_UI_BattleInterface.png:UI_Season_Zi_Shibai";

		// Token: 0x0400A106 RID: 41222
		private const string m_strPkResultDraw = "UI/Image/Packed/p_UI_BattleInterface.png:UI_Season_Duanwen_Pingju";

		// Token: 0x0400A107 RID: 41223
		private Text mPkNum;

		// Token: 0x0400A108 RID: 41224
		private Text mPkWinRate;

		// Token: 0x0400A109 RID: 41225
		private static bool isShowMyVideo = true;

		// Token: 0x0400A10A RID: 41226
		private static bool isShow3V3Video;

		// Token: 0x0400A10B RID: 41227
		private Coroutine mCurrentLoadServerCo;
	}
}
