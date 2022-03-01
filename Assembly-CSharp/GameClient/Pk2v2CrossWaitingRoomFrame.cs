using System;
using System.Collections.Generic;
using DG.Tweening;
using Network;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019A7 RID: 6567
	public class Pk2v2CrossWaitingRoomFrame : GameFrame
	{
		// Token: 0x0600FFF9 RID: 65529 RVA: 0x0046F12B File Offset: 0x0046D52B
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk2v2Cross/Pk2v2CrossWaitingRoom";
		}

		// Token: 0x0600FFFA RID: 65530 RVA: 0x0046F134 File Offset: 0x0046D534
		protected override void OnOpenFrame()
		{
			this.InitTestComUIList();
			this.UpdateTestComUIList();
			if (this.userData != null)
			{
				this.RoomData = (this.userData as PkWaitingRoomData);
			}
			this._InitTalk();
			this.BindUIEvent();
			this.bMatchLock = false;
			this.bIsMatching = false;
			this.UpdateBeginButton();
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<ScoreWar2v2RewardTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					ScoreWar2v2RewardTable scoreWar2v2RewardTable = keyValuePair.Value as ScoreWar2v2RewardTable;
					if (scoreWar2v2RewardTable != null)
					{
						if (scoreWar2v2RewardTable.BattleCount == 1 && this.iFirstBattleAwardID == 0)
						{
							this.iFirstBattleAwardID = scoreWar2v2RewardTable.RewardId;
						}
						if (scoreWar2v2RewardTable.BattleCount == 5 && this.iFiveBattleAwardID == 0)
						{
							this.iFiveBattleAwardID = scoreWar2v2RewardTable.RewardId;
						}
						if (scoreWar2v2RewardTable.BattleCount == 10 && this.iTenBattleAwardID == 0)
						{
							this.iTenBattleAwardID = scoreWar2v2RewardTable.RewardId;
						}
						if (scoreWar2v2RewardTable.WinCount == 1 && this.iFirstWinBattleID == 0)
						{
							this.iFirstWinBattleID = scoreWar2v2RewardTable.RewardId;
						}
						if (this.iFirstBattleAwardID > 0 && this.iFirstWinBattleID > 0 && this.iFiveBattleAwardID > 0 && this.iTenBattleAwardID > 0)
						{
							break;
						}
					}
				}
			}
			this.OnPk2v2CrossRewardInfoUpdate(null);
		}

		// Token: 0x0600FFFB RID: 65531 RVA: 0x0046F29C File Offset: 0x0046D69C
		protected override void OnCloseFrame()
		{
			this.iFirstBattleAwardID = 0;
			this.iFiveBattleAwardID = 0;
			this.iTenBattleAwardID = 0;
			this.iFirstWinBattleID = 0;
			this.UnBindUIEvent();
			if (this.RoomData != null)
			{
				this.RoomData.Clear();
			}
			this.RoomData = null;
			this.bMatchLock = false;
			this.bIsMatching = false;
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ClientSystemTownFrame>(null))
			{
				ClientSystemTownFrame clientSystemTownFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(ClientSystemTownFrame)) as ClientSystemTownFrame;
				clientSystemTownFrame.SetForbidFadeIn(false);
			}
			if (this.m_miniTalk != null)
			{
				ComTalk.Recycle();
				this.m_miniTalk = null;
			}
		}

		// Token: 0x0600FFFC RID: 65532 RVA: 0x0046F344 File Offset: 0x0046D744
		protected override void _bindExUI()
		{
			this.testComUIList = this.mBind.GetCom<ComUIListScript>("testComUIList");
			this.testTxt = this.mBind.GetCom<Text>("testTxt");
			this.btClose = this.mBind.GetCom<Button>("btClose");
			this.btClose.SafeSetOnClickListener(delegate
			{
				if (this.bIsMatching || this.frameMgr.IsFrameOpen<PkSeekWaiting>(null) || DataManager<Pk2v2CrossDataManager>.GetInstance().IsMathcing())
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("2v2melee_score_war_is_matching"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				this.SwitchSceneToTown();
			});
			this.testImg = this.mBind.GetCom<Image>("testImg");
			this.testSlider = this.mBind.GetCom<Slider>("testSlider");
			this.testSlider.SafeSetValueChangeListener(delegate(float value)
			{
			});
			this.testToggle = this.mBind.GetCom<Toggle>("testToggle");
			this.testToggle.SafeSetOnValueChangedListener(delegate(bool value)
			{
			});
			this.testGo = this.mBind.GetGameObject("testGo");
			this.mTalkRoot = this.mBind.GetGameObject("TalkRoot");
			this.mRoomName = this.mBind.GetCom<Text>("RoomName");
			this.mBtMatchText = this.mBind.GetCom<Text>("btMatchText");
			this.mBeginGray = this.mBind.GetCom<UIGray>("btnBeginGray");
			this.mBtBegin = this.mBind.GetCom<Button>("btBegin");
			this.mBtBegin.SafeSetOnClickListener(delegate
			{
				if (this.bMatchLock)
				{
					return;
				}
				this.bMatchLock = true;
				if (!DataManager<Pk2v2CrossDataManager>.GetInstance().IsMathcing())
				{
					this.SendBeginOnePersonMatchGameReq();
				}
				else
				{
					this.SendCancelOnePersonMatchGameReq();
				}
			});
			this.mBtnRank = this.mBind.GetCom<Button>("btnRank");
			this.mBtnRank.SafeSetOnClickListener(delegate
			{
				this.frameMgr.OpenFrame<Pk2v2CrossRankListFrame>(FrameLayer.Middle, null, string.Empty);
			});
			this.btnFirstBattleChest = this.mBind.GetCom<Button>("btnFirstBattleChest");
			this.btnFirstWinChest = this.mBind.GetCom<Button>("btnFirstWinChest");
			this.btnFiveBattleChest = this.mBind.GetCom<Button>("btnFiveBattleChest");
			this.btnTenBattleChest = this.mBind.GetCom<Button>("btnTenBattleChest");
			this.goFirstBattleGet = this.mBind.GetCom<Image>("goFirstBattleGet");
			this.goFiveBattleGet = this.mBind.GetCom<Image>("goFiveBattleGet");
			this.goFirstWinGet = this.mBind.GetCom<Image>("goFirstWinGet");
			this.goTenBattleGet = this.mBind.GetCom<Image>("goTenBattleGet");
			this.gofiveBattleAward = this.mBind.GetGameObject("gofiveBattleAward");
			this.gofirstBattleAward = this.mBind.GetGameObject("gofirstBattleAward");
			this.gotenBattleAward = this.mBind.GetGameObject("gotenBattleAward");
			this.txtPkCountInfo = this.mBind.GetCom<Text>("PkCountInfo");
			this.goScoreWarStateTimeInfo = this.mBind.GetGameObject("goScoreWarStateTimeInfo");
			this.txtTimeInfo = this.mBind.GetCom<Text>("txtTimeInfo");
		}

		// Token: 0x0600FFFD RID: 65533 RVA: 0x0046F638 File Offset: 0x0046DA38
		protected override void _unbindExUI()
		{
			this.testComUIList = null;
			this.testTxt = null;
			this.btClose = null;
			this.testImg = null;
			this.testSlider = null;
			this.testToggle = null;
			this.testGo = null;
			this.mTalkRoot = null;
			this.mRoomName = null;
			this.mBtMatchText = null;
			this.mBeginGray = null;
			this.mBtBegin = null;
			this.mBtnRank = null;
			this.btnFirstBattleChest = null;
			this.btnFirstWinChest = null;
			this.btnFiveBattleChest = null;
			this.btnTenBattleChest = null;
			this.goFirstBattleGet = null;
			this.goFiveBattleGet = null;
			this.goTenBattleGet = null;
			this.goFirstWinGet = null;
			this.gofiveBattleAward = null;
			this.gotenBattleAward = null;
			this.gofirstBattleAward = null;
			this.txtPkCountInfo = null;
			this.goScoreWarStateTimeInfo = null;
			this.txtTimeInfo = null;
		}

		// Token: 0x0600FFFE RID: 65534 RVA: 0x0046F702 File Offset: 0x0046DB02
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600FFFF RID: 65535 RVA: 0x0046F708 File Offset: 0x0046DB08
		protected override void _OnUpdate(float timeElapsed)
		{
			ScoreWar2V2Status scoreWar2V2Status = DataManager<Pk2v2CrossDataManager>.GetInstance().Get2v2CrossWarStatus();
			if (scoreWar2V2Status == ScoreWar2V2Status.SWS_2V2_PREPARE || scoreWar2V2Status == ScoreWar2V2Status.SWS_2V2_BATTLE)
			{
				if (this.goScoreWarStateTimeInfo != null)
				{
					this.goScoreWarStateTimeInfo.CustomActive(true);
				}
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				int num4 = 0;
				this.GetLeftTime(DataManager<Pk2v2CrossDataManager>.GetInstance().Get2v2CrossWarStatusEndTime(), DataManager<TimeManager>.GetInstance().GetServerTime(), ref num, ref num2, ref num3, ref num4);
				if (scoreWar2V2Status == ScoreWar2V2Status.SWS_2V2_PREPARE)
				{
					this.txtTimeInfo.text = TR.Value("2v2melee_score_war_prepare_time_info", string.Format("{0:00}", num2), string.Format("{0:00}", num3), string.Format("{0:00}", num4));
				}
				else if (scoreWar2V2Status == ScoreWar2V2Status.SWS_2V2_BATTLE)
				{
					this.txtTimeInfo.text = TR.Value("2v2melee_score_war_pking_time_info", string.Format("{0:00}", num2), string.Format("{0:00}", num3), string.Format("{0:00}", num4));
				}
			}
			else if (this.goScoreWarStateTimeInfo != null)
			{
				this.goScoreWarStateTimeInfo.CustomActive(false);
			}
		}

		// Token: 0x06010000 RID: 65536 RVA: 0x0046F838 File Offset: 0x0046DC38
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnOnCountValueChange));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk2v2CrossBeginMatch, new ClientEventSystem.UIEventHandler(this.OnBeginMatch));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk2v2CrossBeginMatchRes, new ClientEventSystem.UIEventHandler(this.OnBeginMatchRes));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk2v2CrossCancelMatch, new ClientEventSystem.UIEventHandler(this.OnCancelMatch));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk2v2CrossCancelMatchRes, new ClientEventSystem.UIEventHandler(this.OnCancelMatchRes));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk2v2CrossPkAwardInfoUpdate, new ClientEventSystem.UIEventHandler(this.OnPk2v2CrossRewardInfoUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PK2V2CrossStatusUpdate, new ClientEventSystem.UIEventHandler(this.OnPK2V2CrossStatusUpdate));
		}

		// Token: 0x06010001 RID: 65537 RVA: 0x0046F904 File Offset: 0x0046DD04
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnOnCountValueChange));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk2v2CrossBeginMatch, new ClientEventSystem.UIEventHandler(this.OnBeginMatch));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk2v2CrossBeginMatchRes, new ClientEventSystem.UIEventHandler(this.OnBeginMatchRes));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk2v2CrossCancelMatch, new ClientEventSystem.UIEventHandler(this.OnCancelMatch));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk2v2CrossCancelMatchRes, new ClientEventSystem.UIEventHandler(this.OnCancelMatchRes));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk2v2CrossPkAwardInfoUpdate, new ClientEventSystem.UIEventHandler(this.OnPk2v2CrossRewardInfoUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PK2V2CrossStatusUpdate, new ClientEventSystem.UIEventHandler(this.OnPK2V2CrossStatusUpdate));
		}

		// Token: 0x06010002 RID: 65538 RVA: 0x0046F9CE File Offset: 0x0046DDCE
		private void _InitTalk()
		{
			this.m_miniTalk = ComTalk.Create(this.mTalkRoot);
		}

		// Token: 0x06010003 RID: 65539 RVA: 0x0046F9E4 File Offset: 0x0046DDE4
		private void SendBeginOnePersonMatchGameReq()
		{
			WorldMatchStartReq worldMatchStartReq = new WorldMatchStartReq();
			worldMatchStartReq.type = 15;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldMatchStartReq>(ServerType.GATE_SERVER, worldMatchStartReq);
		}

		// Token: 0x06010004 RID: 65540 RVA: 0x0046FA10 File Offset: 0x0046DE10
		private void SendCancelOnePersonMatchGameReq()
		{
			WorldMatchCancelReq cmd = new WorldMatchCancelReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldMatchCancelReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x06010005 RID: 65541 RVA: 0x0046FA34 File Offset: 0x0046DE34
		private bool IsGetFirstBattleAward()
		{
			Pk2v2CrossDataManager.My2v2PkInfo pkInfo = DataManager<Pk2v2CrossDataManager>.GetInstance().PkInfo;
			for (int i = 0; i < pkInfo.arrAwardIDs.Count; i++)
			{
				if ((long)this.iFirstBattleAwardID == (long)((ulong)pkInfo.arrAwardIDs[i]))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06010006 RID: 65542 RVA: 0x0046FA84 File Offset: 0x0046DE84
		private bool IsGetFiveBattleAward()
		{
			Pk2v2CrossDataManager.My2v2PkInfo pkInfo = DataManager<Pk2v2CrossDataManager>.GetInstance().PkInfo;
			for (int i = 0; i < pkInfo.arrAwardIDs.Count; i++)
			{
				if ((long)this.iFiveBattleAwardID == (long)((ulong)pkInfo.arrAwardIDs[i]))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06010007 RID: 65543 RVA: 0x0046FAD4 File Offset: 0x0046DED4
		private bool IsGetTenBattleAward()
		{
			Pk2v2CrossDataManager.My2v2PkInfo pkInfo = DataManager<Pk2v2CrossDataManager>.GetInstance().PkInfo;
			for (int i = 0; i < pkInfo.arrAwardIDs.Count; i++)
			{
				if ((long)this.iTenBattleAwardID == (long)((ulong)pkInfo.arrAwardIDs[i]))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06010008 RID: 65544 RVA: 0x0046FB24 File Offset: 0x0046DF24
		private bool IsGetFirstWinAward()
		{
			Pk2v2CrossDataManager.My2v2PkInfo pkInfo = DataManager<Pk2v2CrossDataManager>.GetInstance().PkInfo;
			for (int i = 0; i < pkInfo.arrAwardIDs.Count; i++)
			{
				if ((long)this.iFirstWinBattleID == (long)((ulong)pkInfo.arrAwardIDs[i]))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06010009 RID: 65545 RVA: 0x0046FB74 File Offset: 0x0046DF74
		private void UpdateAwardInfo(int iAwardID, Func<bool> isGet, Func<bool> canGet, Button btnChest, Image goImageGet, GameObject goAni)
		{
			goAni.CustomActive(false);
			if (isGet())
			{
				btnChest.onClick.RemoveAllListeners();
				btnChest.interactable = false;
				goImageGet.CustomActive(true);
				btnChest.GetComponent<Image>().raycastTarget = false;
				UIGray component = btnChest.gameObject.GetComponent<UIGray>();
				if (component != null)
				{
					component.SetEnable(true);
				}
				btnChest.gameObject.GetComponent<DOTweenAnimation>().DOPause();
			}
			else if (canGet())
			{
				btnChest.onClick.RemoveAllListeners();
				btnChest.onClick.AddListener(delegate()
				{
					Scene2V2ScoreWarRewardReq scene2V2ScoreWarRewardReq = new Scene2V2ScoreWarRewardReq();
					scene2V2ScoreWarRewardReq.rewardId = (byte)iAwardID;
					NetManager netManager = NetManager.Instance();
					netManager.SendCommand<Scene2V2ScoreWarRewardReq>(ServerType.GATE_SERVER, scene2V2ScoreWarRewardReq);
				});
				btnChest.interactable = true;
				goImageGet.CustomActive(false);
				btnChest.GetComponent<Image>().raycastTarget = true;
				UIGray component2 = btnChest.gameObject.GetComponent<UIGray>();
				if (component2 != null)
				{
					component2.SetEnable(false);
				}
				goAni.CustomActive(true);
				btnChest.gameObject.GetComponent<DOTweenAnimation>().DORestart(false);
			}
			else
			{
				btnChest.onClick.RemoveAllListeners();
				btnChest.onClick.AddListener(delegate()
				{
					AwardRankItem awardRankItem = new AwardRankItem();
					ScoreWar2v2RewardTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ScoreWar2v2RewardTable>(iAwardID, string.Empty, string.Empty);
					if (tableItem != null)
					{
						for (int i = 0; i < tableItem.ItemReward.Count; i++)
						{
							string text = tableItem.ItemRewardArray(i);
							string[] array = text.Split(new char[]
							{
								'_'
							});
							if (array.Length >= 2)
							{
								int tableId = int.Parse(array[0]);
								int count = int.Parse(array[1]);
								ItemData itemData = ItemDataManager.CreateItemDataFromTable(tableId, 100, 0);
								itemData.Count = count;
								if (itemData != null)
								{
									DataManager<ItemTipManager>.GetInstance().CloseAll();
									DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
								}
							}
						}
					}
				});
				btnChest.interactable = true;
				goImageGet.CustomActive(false);
				btnChest.GetComponent<Image>().raycastTarget = true;
				UIGray component3 = btnChest.gameObject.GetComponent<UIGray>();
				if (component3 != null)
				{
					component3.SetEnable(false);
				}
				btnChest.gameObject.GetComponent<DOTweenAnimation>().DOPause();
			}
		}

		// Token: 0x0601000A RID: 65546 RVA: 0x0046FD00 File Offset: 0x0046E100
		private void UpdateFirstBattleAwardChest(UIEvent uiEvent)
		{
			if (this.IsGetFirstBattleAward())
			{
				this.gofirstBattleAward.CustomActive(false);
			}
			else
			{
				this.gofirstBattleAward.CustomActive(true);
			}
			this.UpdateAwardInfo(this.iFirstBattleAwardID, new Func<bool>(this.IsGetFirstBattleAward), delegate
			{
				Pk2v2CrossDataManager.My2v2PkInfo pkInfo = DataManager<Pk2v2CrossDataManager>.GetInstance().PkInfo;
				return pkInfo.nCurPkCount >= 1;
			}, this.btnFirstBattleChest, this.goFirstBattleGet, this.mBind.GetGameObject("goFirstBattleAni"));
		}

		// Token: 0x0601000B RID: 65547 RVA: 0x0046FD88 File Offset: 0x0046E188
		private void UpdateFiveBattleAwardChest(UIEvent uiEvent)
		{
			if (!this.IsGetFirstBattleAward())
			{
				this.gofiveBattleAward.CustomActive(false);
				return;
			}
			this.gofiveBattleAward.CustomActive(true);
			this.UpdateAwardInfo(this.iFiveBattleAwardID, new Func<bool>(this.IsGetFiveBattleAward), delegate
			{
				Pk2v2CrossDataManager.My2v2PkInfo pkInfo = DataManager<Pk2v2CrossDataManager>.GetInstance().PkInfo;
				return pkInfo.nCurPkCount >= 5;
			}, this.btnFiveBattleChest, this.goFiveBattleGet, this.mBind.GetGameObject("goFiveBattleAni"));
		}

		// Token: 0x0601000C RID: 65548 RVA: 0x0046FE10 File Offset: 0x0046E210
		private void UpdateTenBattleAwardChest(UIEvent uiEvent)
		{
			if (!this.IsGetFiveBattleAward())
			{
				this.gotenBattleAward.CustomActive(false);
				return;
			}
			this.gotenBattleAward.CustomActive(true);
			this.UpdateAwardInfo(this.iTenBattleAwardID, new Func<bool>(this.IsGetTenBattleAward), delegate
			{
				Pk2v2CrossDataManager.My2v2PkInfo pkInfo = DataManager<Pk2v2CrossDataManager>.GetInstance().PkInfo;
				return pkInfo.nCurPkCount >= 10;
			}, this.btnTenBattleChest, this.goTenBattleGet, this.mBind.GetGameObject("goTenBattleAni"));
		}

		// Token: 0x0601000D RID: 65549 RVA: 0x0046FE98 File Offset: 0x0046E298
		private void UpdateFirstWinAwardChest(UIEvent uiEvent)
		{
			this.UpdateAwardInfo(this.iFirstWinBattleID, new Func<bool>(this.IsGetFirstWinAward), delegate
			{
				Pk2v2CrossDataManager.My2v2PkInfo pkInfo = DataManager<Pk2v2CrossDataManager>.GetInstance().PkInfo;
				return pkInfo.nWinCount >= 1;
			}, this.btnFirstWinChest, this.goFirstWinGet, this.mBind.GetGameObject("goFirstWinAni"));
		}

		// Token: 0x0601000E RID: 65550 RVA: 0x0046FEF8 File Offset: 0x0046E2F8
		private void UpdateBeginButton()
		{
			ScoreWar2V2Status scoreWar2V2Status = DataManager<Pk2v2CrossDataManager>.GetInstance().Get2v2CrossWarStatus();
			this.mBeginGray.SetEnable(false);
			this.mBtBegin.interactable = true;
			this.mBtBegin.CustomActive(true);
			Pk2v2CrossDataManager.My2v2PkInfo pkInfo = DataManager<Pk2v2CrossDataManager>.GetInstance().PkInfo;
			if (pkInfo != null && (pkInfo.nCurPkCount >= Pk2v2CrossDataManager.MAX_PK_COUNT || scoreWar2V2Status != ScoreWar2V2Status.SWS_2V2_BATTLE))
			{
				this.mBeginGray.SetEnable(true);
				this.mBtBegin.interactable = false;
			}
		}

		// Token: 0x0601000F RID: 65551 RVA: 0x0046FF74 File Offset: 0x0046E374
		private void GetLeftTime(uint nEndTime, uint nNowTime, ref int nLeftDay, ref int nLeftHour, ref int nLeftMin, ref int nLeftSec)
		{
			nLeftDay = 0;
			nLeftHour = 0;
			nLeftMin = 0;
			nLeftSec = 0;
			if (nEndTime <= nNowTime)
			{
				return;
			}
			uint num = nEndTime - nNowTime;
			uint num2 = num / 86400U;
			num -= num2 * 24U * 60U * 60U;
			uint num3 = num / 3600U;
			num -= num3 * 60U * 60U;
			uint num4 = num / 60U;
			num -= num4 * 60U;
			uint num5 = num;
			nLeftDay = (int)num2;
			nLeftHour = (int)num3;
			nLeftMin = (int)num4;
			nLeftSec = (int)num5;
		}

		// Token: 0x06010010 RID: 65552 RVA: 0x0046FFE4 File Offset: 0x0046E3E4
		private void InitTestComUIList()
		{
			if (this.testComUIList == null)
			{
				return;
			}
			this.testComUIList.Initialize();
			this.testComUIList.onBindItem = ((GameObject go) => go);
			this.testComUIList.onItemVisiable = delegate(ComUIListElementScript go)
			{
				if (go == null)
				{
					return;
				}
				if (this.testComUIListDatas == null)
				{
					return;
				}
				ComUIListTemplateItem component = go.GetComponent<ComUIListTemplateItem>();
				if (component == null)
				{
					return;
				}
				if (go.m_index >= 0 && go.m_index < this.testComUIListDatas.Count)
				{
					component.SetUp(this.testComUIListDatas[go.m_index]);
				}
			};
		}

		// Token: 0x06010011 RID: 65553 RVA: 0x0047004D File Offset: 0x0046E44D
		private void CalcTestComUIListDatas()
		{
			this.testComUIListDatas = new List<object>();
			if (this.testComUIListDatas == null)
			{
				return;
			}
		}

		// Token: 0x06010012 RID: 65554 RVA: 0x00470066 File Offset: 0x0046E466
		private void UpdateTestComUIList()
		{
			if (this.testComUIList == null)
			{
				return;
			}
			this.CalcTestComUIListDatas();
			if (this.testComUIListDatas == null)
			{
				return;
			}
			this.testComUIList.SetElementAmount(this.testComUIListDatas.Count);
		}

		// Token: 0x06010013 RID: 65555 RVA: 0x004700A4 File Offset: 0x0046E4A4
		private void SwitchSceneToTown()
		{
			if (this.RoomData == null)
			{
				return;
			}
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
			if (clientSystemTown == null)
			{
				Logger.LogError("Current System is not Town from Pk2v2WaitingRoom");
				return;
			}
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(clientSystemTown._NetSyncChangeScene(new SceneParams
			{
				currSceneID = this.RoomData.CurrentSceneID,
				currDoorID = 0,
				targetSceneID = this.RoomData.TargetTownSceneID,
				targetDoorID = 0
			}, true));
			this.frameMgr.CloseFrame<Pk2v2CrossWaitingRoomFrame>(this, false);
		}

		// Token: 0x06010014 RID: 65556 RVA: 0x00470134 File Offset: 0x0046E534
		private void _OnOnCountValueChange(UIEvent uiEvent)
		{
		}

		// Token: 0x06010015 RID: 65557 RVA: 0x00470138 File Offset: 0x0046E538
		private void OnBeginMatch(UIEvent iEvent)
		{
			this.bIsMatching = true;
			this.UpdateBeginButton();
			PkSeekWaitingData pkSeekWaitingData = new PkSeekWaitingData();
			pkSeekWaitingData.roomtype = PkRoomType.Pk2v2Cross;
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<PkSeekWaiting>(FrameLayer.Middle, pkSeekWaitingData, string.Empty);
			this.mBtMatchText.text = TR.Value("2v2melee_score_war_cancel_match");
		}

		// Token: 0x06010016 RID: 65558 RVA: 0x00470186 File Offset: 0x0046E586
		private void OnBeginMatchRes(UIEvent iEvent)
		{
			this.bMatchLock = false;
		}

		// Token: 0x06010017 RID: 65559 RVA: 0x0047018F File Offset: 0x0046E58F
		private void OnCancelMatch(UIEvent iEvent)
		{
			this.bIsMatching = false;
			this.UpdateBeginButton();
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<PkSeekWaiting>(null, false);
			this.mBtMatchText.text = TR.Value("2v2melee_score_war_start_match");
		}

		// Token: 0x06010018 RID: 65560 RVA: 0x004701BF File Offset: 0x0046E5BF
		private void OnCancelMatchRes(UIEvent iEvent)
		{
			this.bMatchLock = false;
		}

		// Token: 0x06010019 RID: 65561 RVA: 0x004701C8 File Offset: 0x0046E5C8
		private void OnPK2V2CrossStatusUpdate(UIEvent iEvent)
		{
			this.UpdateBeginButton();
		}

		// Token: 0x0601001A RID: 65562 RVA: 0x004701D0 File Offset: 0x0046E5D0
		private void OnPk2v2CrossRewardInfoUpdate(UIEvent iEvent)
		{
			Pk2v2CrossDataManager.My2v2PkInfo pkInfo = DataManager<Pk2v2CrossDataManager>.GetInstance().PkInfo;
			if (pkInfo == null)
			{
				return;
			}
			this.txtPkCountInfo.text = TR.Value("2v2melee_score_war_pk_count_info", Pk2v2CrossDataManager.MAX_PK_COUNT - pkInfo.nCurPkCount, Pk2v2CrossDataManager.MAX_PK_COUNT);
			this.UpdateFirstBattleAwardChest(null);
			this.UpdateFiveBattleAwardChest(null);
			this.UpdateFirstWinAwardChest(null);
			ScoreWar2V2Status scoreWar2V2Status = DataManager<Pk2v2CrossDataManager>.GetInstance().Get2v2CrossWarStatus();
			if (pkInfo.nCurPkCount >= Pk2v2CrossDataManager.MAX_PK_COUNT || scoreWar2V2Status != ScoreWar2V2Status.SWS_2V2_BATTLE)
			{
				this.mBeginGray.SetEnable(true);
				this.mBtBegin.interactable = false;
			}
		}

		// Token: 0x0400A16D RID: 41325
		private List<object> testComUIListDatas = new List<object>();

		// Token: 0x0400A16E RID: 41326
		private ComTalk m_miniTalk;

		// Token: 0x0400A16F RID: 41327
		private PkWaitingRoomData RoomData = new PkWaitingRoomData();

		// Token: 0x0400A170 RID: 41328
		private bool bMatchLock;

		// Token: 0x0400A171 RID: 41329
		private bool bIsMatching;

		// Token: 0x0400A172 RID: 41330
		private int iFirstBattleAwardID;

		// Token: 0x0400A173 RID: 41331
		private int iFiveBattleAwardID;

		// Token: 0x0400A174 RID: 41332
		private int iTenBattleAwardID;

		// Token: 0x0400A175 RID: 41333
		private int iFirstWinBattleID;

		// Token: 0x0400A176 RID: 41334
		private ComUIListScript testComUIList;

		// Token: 0x0400A177 RID: 41335
		private Text testTxt;

		// Token: 0x0400A178 RID: 41336
		private Button btClose;

		// Token: 0x0400A179 RID: 41337
		private Image testImg;

		// Token: 0x0400A17A RID: 41338
		private Slider testSlider;

		// Token: 0x0400A17B RID: 41339
		private Toggle testToggle;

		// Token: 0x0400A17C RID: 41340
		private GameObject testGo;

		// Token: 0x0400A17D RID: 41341
		private GameObject mTalkRoot;

		// Token: 0x0400A17E RID: 41342
		private Text mRoomName;

		// Token: 0x0400A17F RID: 41343
		private Text mBtMatchText;

		// Token: 0x0400A180 RID: 41344
		private UIGray mBeginGray;

		// Token: 0x0400A181 RID: 41345
		private Button mBtBegin;

		// Token: 0x0400A182 RID: 41346
		private Button mBtnRank;

		// Token: 0x0400A183 RID: 41347
		private Button btnFirstBattleChest;

		// Token: 0x0400A184 RID: 41348
		private Image goFirstBattleGet;

		// Token: 0x0400A185 RID: 41349
		private Button btnFiveBattleChest;

		// Token: 0x0400A186 RID: 41350
		private Image goFiveBattleGet;

		// Token: 0x0400A187 RID: 41351
		private Button btnFirstWinChest;

		// Token: 0x0400A188 RID: 41352
		private Image goFirstWinGet;

		// Token: 0x0400A189 RID: 41353
		private Button btnTenBattleChest;

		// Token: 0x0400A18A RID: 41354
		private Image goTenBattleGet;

		// Token: 0x0400A18B RID: 41355
		private GameObject gofiveBattleAward;

		// Token: 0x0400A18C RID: 41356
		private GameObject gofirstBattleAward;

		// Token: 0x0400A18D RID: 41357
		private GameObject gotenBattleAward;

		// Token: 0x0400A18E RID: 41358
		private Text txtPkCountInfo;

		// Token: 0x0400A18F RID: 41359
		private GameObject goScoreWarStateTimeInfo;

		// Token: 0x0400A190 RID: 41360
		private Text txtTimeInfo;
	}
}
