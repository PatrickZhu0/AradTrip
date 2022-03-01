using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200110E RID: 4366
	public class ChijiMainFrame : ClientFrame
	{
		// Token: 0x0600A56C RID: 42348 RVA: 0x0022215B File Offset: 0x0022055B
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Chiji/ChijiMainFrame";
		}

		// Token: 0x0600A56D RID: 42349 RVA: 0x00222162 File Offset: 0x00220562
		private void InitData()
		{
			this.mLastJoyStickPosition = Vector2.zero;
			this.mLastJoyStickFizzyCheck = false;
			this.mIsStopMoveFunction = false;
		}

		// Token: 0x0600A56E RID: 42350 RVA: 0x00222180 File Offset: 0x00220580
		protected override void _OnOpenFrame()
		{
			DataManager<ChijiDataManager>.GetInstance().SwitchingPrepareToChijiScene = false;
			this.mBtReport.CustomActive(false);
			this.InitData();
			this.InitJoystick();
			this._BindUIEvent();
			if (this.userData != null)
			{
				this.roomData = (this.userData as ChijiRoomData);
			}
			if (DataManager<ChijiDataManager>.GetInstance().CurBattleStage < ChiJiTimeTable.eBattleStage.BS_PUT_ITEM_1)
			{
				ChiJiTimeTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ChiJiTimeTable>(5, string.Empty, string.Empty);
				if (tableItem != null)
				{
					this.LastTime = tableItem.StartTime;
				}
				this.LeftTime = this.LastTime;
			}
			this.StartServerTime = DataManager<TimeManager>.GetInstance().GetServerTime();
			this._LoadChijiPlayerHeadPortraitInfoView();
			this._InitInterface();
			if (DataManager<ChijiDataManager>.GetInstance().GuardForPickUpOtherPlayerItems)
			{
				DataManager<ChijiDataManager>.GetInstance().GuardForPickUpOtherPlayerItems = false;
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<PlayerItemFrame>(FrameLayer.Middle, null, string.Empty);
			}
			if (DataManager<PlayerBaseData>.GetInstance().BuffMgr.HasBuffByID(402000003))
			{
				this.ShowPoisionEffect(true);
			}
			this._InitPoisonData();
		}

		// Token: 0x0600A56F RID: 42351 RVA: 0x00222284 File Offset: 0x00220684
		protected override void _OnCloseFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<SelectOccupationFrame>(null, false);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<SelectMapAreaFrame>(null, false);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<MapItemFrame>(null, false);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<PlayerItemFrame>(null, false);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChijiFullMapFrame>(null, false);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChijiSkillFrame>(null, false);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<PackageNewFrame>(null, false);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChijiNpcDialogFrame>(null, false);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChijiHandInEquipmentFrame>(null, false);
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ClientSystemTownFrame>(null))
			{
				ClientSystemTownFrame clientSystemTownFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(ClientSystemTownFrame)) as ClientSystemTownFrame;
				clientSystemTownFrame.SetForbidFadeIn(false);
			}
			if (this.mDeadTips != null)
			{
				this.mDeadTips.CustomActive(false);
			}
			this._UnBindUIEvent();
			this._UnloadInput();
			this._ClearData();
			if (this._chijiShopView != null)
			{
				Object.Destroy(this._chijiShopView.gameObject);
				this._chijiShopView = null;
			}
		}

		// Token: 0x0600A570 RID: 42352 RVA: 0x00222388 File Offset: 0x00220788
		private void _ClearData()
		{
			if (this.roomData != null)
			{
				this.roomData.Clear();
			}
			if (this.m_mapFrame != null)
			{
				this.m_mapFrame = null;
			}
			this.mLastJoyStickFizzyCheck = false;
			this.mLastJoyStickPosition = Vector2.zero;
			this.mIsStopMoveFunction = false;
			this._inputManager = null;
			this.LastTime = 60;
			this.fTimeIntrval = 0f;
			this.StartServerTime = 0U;
			this.KillInfoShowTimeIntrval = 0f;
			this.fLocalTime = 0f;
			this.DelayHideTime = 0f;
			this.picktype = PickUpType.None;
			if (this.skillList != null)
			{
				this.skillList = null;
			}
			if (this.equipList != null)
			{
				this.equipList = null;
			}
			this._ClearChijiMap();
			this.mChijiPlayerHeadPortraitInfoView = null;
			this.SettlementTime = 0f;
			this.center = Vector2.zero;
			this.radius = 0f;
			this.durTime = 0f;
			this.shrinkTime = 0f;
			this.lastCenter = Vector2.zero;
			this.lastRadius = 0f;
			this.bRefreshPickUpState = false;
			this.bPickUpFinish = false;
			this.bWaitPickUpMsg = false;
			if (this.mAttackAreaEffect != null)
			{
				this.mAttackAreaEffect = null;
			}
		}

		// Token: 0x0600A571 RID: 42353 RVA: 0x002224C4 File Offset: 0x002208C4
		private void _InitInterface()
		{
			ChiJiTimeTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ChiJiTimeTable>((int)DataManager<ChijiDataManager>.GetInstance().CurBattleStage, string.Empty, string.Empty);
			DisplayAttribute mainPlayerActorAttribute = BeUtility.GetMainPlayerActorAttribute(true, true);
			if (this.mChijiPlayerHeadPortraitInfoView != null)
			{
				this.mChijiPlayerHeadPortraitInfoView.InitView(mainPlayerActorAttribute);
			}
			if (this.mSurvivePlayerNum != null)
			{
				this.mSurvivePlayerNum.text = DataManager<ChijiDataManager>.GetInstance().SurvivePlayerNum.ToString();
			}
			this._InitChijiMap();
			if (DataManager<ChijiDataManager>.GetInstance().RecentKillPlayerID != 0UL)
			{
				this.KillInfoShowTimeIntrval = 0f;
				this._UpdateShowKillInfo();
			}
			if (this.mShowKill != null)
			{
				this.mShowKill.text = DataManager<ChijiDataManager>.GetInstance().KillNum.ToString();
			}
			if (tableItem != null)
			{
				ChijiMainFrame.mStagename = tableItem.StageTip;
			}
			this.mTime.text = ChijiMainFrame.mStagename + this.LeftTime.ToString();
			this._UpdateShowDeathPlayerInfo();
			if (DataManager<ChijiDataManager>.GetInstance().IsReadyPk)
			{
				this.mPkText.text = "取消挑战";
			}
			else
			{
				this.mPkText.text = "挑战";
			}
			this.mPickUpProcess.CustomActive(false);
		}

		// Token: 0x0600A572 RID: 42354 RVA: 0x00222624 File Offset: 0x00220A24
		private void _BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ChijiBattleStageChanged, new ClientEventSystem.UIEventHandler(this._OnStageChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.JobIDReset, new ClientEventSystem.UIEventHandler(this._OnResetAttr));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ChijiPlayerDead, new ClientEventSystem.UIEventHandler(this._OnPlayerDead));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PoisonStatChange, new ClientEventSystem.UIEventHandler(this._OnPlayerPoisonStatChange));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.BlueCircleChange, new ClientEventSystem.UIEventHandler(this._OnBlueCircleChange));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.StartOpenChijiItem, new ClientEventSystem.UIEventHandler(this._OnStartOpenChijiItem));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.FinishOpenChijiItem, new ClientEventSystem.UIEventHandler(this._OnFinishOpenChijiItem));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.CancelOpenChijiItem, new ClientEventSystem.UIEventHandler(this._OnCancelOpenChijiItem));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OpenChijiSkillChooseFrame, new ClientEventSystem.UIEventHandler(this._OnOpenChijiSkillChooseFrame));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ChijiPkReady, new ClientEventSystem.UIEventHandler(this._OnChijiPkReady));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ChijiPKButtonChange, new ClientEventSystem.UIEventHandler(this._OnPKButtonChange));
		}

		// Token: 0x0600A573 RID: 42355 RVA: 0x00222758 File Offset: 0x00220B58
		private void _UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ChijiBattleStageChanged, new ClientEventSystem.UIEventHandler(this._OnStageChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.JobIDReset, new ClientEventSystem.UIEventHandler(this._OnResetAttr));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ChijiPlayerDead, new ClientEventSystem.UIEventHandler(this._OnPlayerDead));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PoisonStatChange, new ClientEventSystem.UIEventHandler(this._OnPlayerPoisonStatChange));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.BlueCircleChange, new ClientEventSystem.UIEventHandler(this._OnBlueCircleChange));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.StartOpenChijiItem, new ClientEventSystem.UIEventHandler(this._OnStartOpenChijiItem));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.FinishOpenChijiItem, new ClientEventSystem.UIEventHandler(this._OnFinishOpenChijiItem));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.CancelOpenChijiItem, new ClientEventSystem.UIEventHandler(this._OnCancelOpenChijiItem));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OpenChijiSkillChooseFrame, new ClientEventSystem.UIEventHandler(this._OnOpenChijiSkillChooseFrame));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ChijiPkReady, new ClientEventSystem.UIEventHandler(this._OnChijiPkReady));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ChijiPKButtonChange, new ClientEventSystem.UIEventHandler(this._OnPKButtonChange));
		}

		// Token: 0x0600A574 RID: 42356 RVA: 0x0022288C File Offset: 0x00220C8C
		private void _OnStageChanged(UIEvent iEvent)
		{
			ChiJiTimeTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ChiJiTimeTable>((int)DataManager<ChijiDataManager>.GetInstance().CurBattleStage, string.Empty, string.Empty);
			if (tableItem != null && tableItem.StageTip != string.Empty)
			{
				ChijiMainFrame.mStagename = tableItem.StageTip;
			}
		}

		// Token: 0x0600A575 RID: 42357 RVA: 0x002228E0 File Offset: 0x00220CE0
		private void _OnResetAttr(UIEvent iEvent)
		{
			DisplayAttribute mainPlayerActorAttribute = BeUtility.GetMainPlayerActorAttribute(true, true);
			if (this.mChijiPlayerHeadPortraitInfoView != null)
			{
				this.mChijiPlayerHeadPortraitInfoView.InitView(mainPlayerActorAttribute);
			}
		}

		// Token: 0x0600A576 RID: 42358 RVA: 0x00222914 File Offset: 0x00220D14
		private void _OnPlayerDead(UIEvent iEvent)
		{
			if (this.mSurvivePlayerNum != null)
			{
				this.mSurvivePlayerNum.text = DataManager<ChijiDataManager>.GetInstance().SurvivePlayerNum.ToString();
			}
			if (DataManager<ChijiDataManager>.GetInstance().RecentKillPlayerID != 0UL)
			{
				this.KillInfoShowTimeIntrval = 0f;
				this._UpdateShowKillInfo();
			}
			if (this.mShowKill != null)
			{
				this.mShowKill.text = DataManager<ChijiDataManager>.GetInstance().KillNum.ToString();
			}
			this._UpdateShowDeathPlayerInfo();
		}

		// Token: 0x0600A577 RID: 42359 RVA: 0x002229B4 File Offset: 0x00220DB4
		private void _OnPlayerPoisonStatChange(UIEvent iEvent)
		{
			bool isShow = (bool)iEvent.Param1;
			this.ShowPoisionEffect(isShow);
		}

		// Token: 0x0600A578 RID: 42360 RVA: 0x002229D4 File Offset: 0x00220DD4
		private void _OnBlueCircleChange(UIEvent iEvent)
		{
			this.lastCenter = this.center;
			this.lastRadius = this.radius;
			this.center = (Vector2)iEvent.Param1;
			this.radius = (float)iEvent.Param2;
			this.durTime = (float)iEvent.Param3;
			this.shrinkTime = (float)iEvent.Param4;
			if (this.m_mapFrame != null)
			{
				this.m_mapFrame.SetWhiteCircle(this.center, this.radius);
				this.m_mapFrame.SetBlueCircle(this.center, this.radius, this.durTime, this.shrinkTime);
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ChijiFullMapFrame>(null))
			{
				ChijiFullMapFrame chijiFullMapFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(ChijiFullMapFrame)) as ChijiFullMapFrame;
				if (chijiFullMapFrame != null && chijiFullMapFrame.MapFrame != null)
				{
					chijiFullMapFrame.MapFrame.SetWhiteCircle(this.center, this.radius);
					chijiFullMapFrame.MapFrame.SetBlueCircle(this.center, this.radius, this.durTime, this.shrinkTime);
				}
			}
		}

		// Token: 0x0600A579 RID: 42361 RVA: 0x00222AF8 File Offset: 0x00220EF8
		private void _OnStartOpenChijiItem(UIEvent iEvent)
		{
			if (this.mPickUpProcess.IsActive())
			{
				return;
			}
			this.PickUpItemLastTime = (int)((uint)iEvent.Param1 - DataManager<TimeManager>.GetInstance().GetServerTime());
			int num = (int)iEvent.Param2;
			if (this.PickUpItemLastTime > num)
			{
				this.PickUpItemLastTime = num;
			}
			Logger.LogErrorFormat("TimeLeft = {0}", new object[]
			{
				this.PickUpItemLastTime
			});
			this.mPickUpProcess.value = 0f;
			this.fLocalTime = 0f;
			this.DelayHideTime = 0f;
			this.bRefreshPickUpState = true;
			this.bPickUpFinish = false;
			this.bWaitPickUpMsg = false;
			this.mPickUpProcess.CustomActive(true);
		}

		// Token: 0x0600A57A RID: 42362 RVA: 0x00222BB8 File Offset: 0x00220FB8
		private void _OnFinishOpenChijiItem(UIEvent iEvent)
		{
			if (!this.mPickUpProcess.IsActive())
			{
				return;
			}
			if (this.mPickUpProcess != null)
			{
				this.mPickUpProcess.value = 1f;
			}
			this.bPickUpFinish = true;
			this.DelayHideTime = this.fLocalTime;
		}

		// Token: 0x0600A57B RID: 42363 RVA: 0x00222C0A File Offset: 0x0022100A
		private void _OnCancelOpenChijiItem(UIEvent iEvent)
		{
			if (!this.mPickUpProcess.IsActive())
			{
				return;
			}
			this.bRefreshPickUpState = false;
			this.mPickUpProcess.CustomActive(false);
		}

		// Token: 0x0600A57C RID: 42364 RVA: 0x00222C30 File Offset: 0x00221030
		private void _OnOpenChijiSkillChooseFrame(UIEvent iEvent)
		{
			this.picktype = (PickUpType)iEvent.Param1;
			ChijiSkillChooseFrame.pickUpType = this.picktype;
			if (this.picktype == PickUpType.PickUpSkill)
			{
				this.skillList = (iEvent.Param2 as ChiJiSkill[]);
			}
			else if (this.picktype == PickUpType.PickUpItem)
			{
				this.equipList = (iEvent.Param2 as uint[]);
			}
			if (this.bWaitPickUpMsg)
			{
				this.bWaitPickUpMsg = false;
				if (this.picktype == PickUpType.PickUpSkill)
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChijiSkillChooseFrame>(FrameLayer.Middle, this.skillList, string.Empty);
				}
				else if (this.picktype == PickUpType.PickUpItem)
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChijiSkillChooseFrame>(FrameLayer.Middle, this.equipList, string.Empty);
				}
				this.picktype = PickUpType.None;
			}
		}

		// Token: 0x0600A57D RID: 42365 RVA: 0x00222CFC File Offset: 0x002210FC
		private void _OnChijiPkReady(UIEvent iEvent)
		{
			this.mPkText.text = "挑战";
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChijiSkillFrame>(null, false);
			if (this.mChallengeTipRoot != null)
			{
				this.mChallengeTipRoot.CustomActive(false);
			}
		}

		// Token: 0x0600A57E RID: 42366 RVA: 0x00222D38 File Offset: 0x00221138
		private void _LoadChijiPlayerHeadPortraitInfoView()
		{
			UIPrefabWrapper component = this.mPlayerHeadPortraitInfoRoot.GetComponent<UIPrefabWrapper>();
			if (component != null)
			{
				GameObject gameObject = component.LoadUIPrefab();
				if (gameObject != null)
				{
					gameObject.transform.SetParent(this.mPlayerHeadPortraitInfoRoot.transform, false);
					if (this.mChijiPlayerHeadPortraitInfoView == null)
					{
						this.mChijiPlayerHeadPortraitInfoView = gameObject.GetComponent<ChijiPlayerHeadPortraitInfoView>();
					}
				}
			}
		}

		// Token: 0x0600A57F RID: 42367 RVA: 0x00222DA4 File Offset: 0x002211A4
		private void _UpdateShowKillInfo()
		{
			if (this.mKillInfo != null)
			{
				if (DataManager<ChijiDataManager>.GetInstance().RecentKillPlayerID == DataManager<PlayerBaseData>.GetInstance().RoleID)
				{
					this.mKillInfo.text = "你 淘汰了 你自己";
				}
				else
				{
					JoinPlayerInfo joinPlayerInfo = DataManager<ChijiDataManager>.GetInstance().JoinPlayerInfoList.Find((JoinPlayerInfo x) => x.playerId == DataManager<ChijiDataManager>.GetInstance().RecentKillPlayerID);
					if (joinPlayerInfo != null)
					{
						this.mKillInfo.text = string.Format("你 淘汰了 {0}", joinPlayerInfo.playerName);
					}
				}
				this.mKillInfo.CustomActive(true);
			}
			if (this.mKills != null)
			{
				this.mKills.text = DataManager<ChijiDataManager>.GetInstance().KillNum.ToString();
			}
		}

		// Token: 0x0600A580 RID: 42368 RVA: 0x00222E80 File Offset: 0x00221280
		private void _UpdateShowDeathPlayerInfo()
		{
			if (this.mDeathPlayer0 != null && DataManager<ChijiDataManager>.GetInstance().ShowDeathPlayerList.Count >= 1)
			{
				if (this.mDeathplayer0Bg != null)
				{
					this.mDeathplayer0Bg.CustomActive(true);
				}
				this.mDeathPlayer0.text = this._ShowDeathInfo(DataManager<ChijiDataManager>.GetInstance().ShowDeathPlayerList[0]);
			}
			if (this.mDeathPlayer1 != null && DataManager<ChijiDataManager>.GetInstance().ShowDeathPlayerList.Count >= 2)
			{
				if (this.mDeathplayer1Bg != null)
				{
					this.mDeathplayer1Bg.CustomActive(true);
				}
				this.mDeathPlayer1.text = this._ShowDeathInfo(DataManager<ChijiDataManager>.GetInstance().ShowDeathPlayerList[1]);
			}
			if (this.mDeathPlayer2 != null && DataManager<ChijiDataManager>.GetInstance().ShowDeathPlayerList.Count >= 3)
			{
				if (this.mDeathplayer2Bg != null)
				{
					this.mDeathplayer2Bg.CustomActive(true);
				}
				this.mDeathPlayer2.text = this._ShowDeathInfo(DataManager<ChijiDataManager>.GetInstance().ShowDeathPlayerList[2]);
			}
		}

		// Token: 0x0600A581 RID: 42369 RVA: 0x00222FBC File Offset: 0x002213BC
		private string _ShowDeathInfo(PlayerDeathReason data)
		{
			string result = string.Empty;
			if (data == null)
			{
				return result;
			}
			if (data.playerID == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				if (data.killerID == 0UL)
				{
					result = string.Format("<color=#FF0025FF>你 在安全区外阵亡</color>", new object[0]);
				}
				else
				{
					JoinPlayerInfo joinPlayerInfo = DataManager<ChijiDataManager>.GetInstance().JoinPlayerInfoList.Find((JoinPlayerInfo x) => x.playerId == data.killerID);
					if (joinPlayerInfo != null)
					{
						result = string.Format("<color=#FF0025FF>{0} 淘汰了 你</color>", joinPlayerInfo.playerName);
					}
				}
			}
			else
			{
				JoinPlayerInfo joinPlayerInfo2 = DataManager<ChijiDataManager>.GetInstance().JoinPlayerInfoList.Find((JoinPlayerInfo x) => x.playerId == data.playerID);
				if (data.killerID == DataManager<PlayerBaseData>.GetInstance().RoleID)
				{
					if (joinPlayerInfo2 != null)
					{
						result = string.Format("<color=#3F9AFFFF>你 淘汰了 {0}</color>", joinPlayerInfo2.playerName);
					}
				}
				else if (data.killerID != 0UL)
				{
					JoinPlayerInfo joinPlayerInfo3 = DataManager<ChijiDataManager>.GetInstance().JoinPlayerInfoList.Find((JoinPlayerInfo x) => x.playerId == data.killerID);
					if (joinPlayerInfo3 != null)
					{
						result = string.Format("<color=#FFFFFFFF>{0} 淘汰了 {1}</color>", joinPlayerInfo3.playerName, joinPlayerInfo2.playerName);
					}
				}
				else if (joinPlayerInfo2 != null)
				{
					result = string.Format("<color=#FFFFFFFF>{0} 在安全区外阵亡</color>", joinPlayerInfo2.playerName);
				}
			}
			return result;
		}

		// Token: 0x0600A582 RID: 42370 RVA: 0x00223120 File Offset: 0x00221520
		private void _OnLeaveChiji()
		{
			ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemGameBattle;
			if (clientSystemGameBattle == null)
			{
				Logger.LogError("Current System is not Game Battle!!![_OnLeaveChiji]");
				return;
			}
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(clientSystemGameBattle._NetSyncChangeScene(new SceneParams
			{
				currSceneID = clientSystemGameBattle.CurrentSceneID,
				currDoorID = 0,
				targetSceneID = 10101,
				targetDoorID = 0
			}, false));
			DataManager<ChijiDataManager>.GetInstance().SwitchingChijiSceneToPrepare = true;
			this.frameMgr.CloseFrame<ChijiMainFrame>(this, false);
		}

		// Token: 0x0600A583 RID: 42371 RVA: 0x002231A4 File Offset: 0x002215A4
		private void _ClearChijiMap()
		{
			this.frameMgr.CloseFrame<ChijiMapFrame>(null, false);
			this.m_mapFrame = null;
		}

		// Token: 0x0600A584 RID: 42372 RVA: 0x002231BC File Offset: 0x002215BC
		private void _InitChijiMap()
		{
			this.m_mapFrame = (this.frameMgr.OpenFrame<ChijiMapFrame>(this.mMapContent, null, string.Empty) as ChijiMapFrame);
			this.m_mapFrame.SetScale(new Vector2(0.8f, 0.8f));
			this.mMapContent.GetComponent<RectTransform>().sizeDelta = this.m_mapFrame.GetSize();
			this._UpdateChijiMap();
		}

		// Token: 0x0600A585 RID: 42373 RVA: 0x00223228 File Offset: 0x00221628
		private void _UpdateChijiMap()
		{
			if (this.m_mapFrame != null && this.mMapscrollRect != null)
			{
				Vector2 playerMainPos = this.m_mapFrame.GetPlayerMainPos();
				Vector2 size = this.m_mapFrame.GetSize();
				Vector2 size2 = this.mMapscrollRect.viewport.rect.size;
				this.mMapscrollRect.normalizedPosition = new Vector2((playerMainPos.x - size2.x * 0.5f) / (size.x - size2.x), (playerMainPos.y - size2.y * 0.5f) / (size.y - size2.y));
			}
		}

		// Token: 0x0600A586 RID: 42374 RVA: 0x002232DC File Offset: 0x002216DC
		private void _InitPoisonData()
		{
			this.center = DataManager<ChijiDataManager>.GetInstance().PoisonRing.center;
			this.radius = DataManager<ChijiDataManager>.GetInstance().PoisonRing.radius;
			this.durTime = DataManager<ChijiDataManager>.GetInstance().PoisonRing.durTime;
			this.shrinkTime = DataManager<ChijiDataManager>.GetInstance().PoisonRing.shrinkTime;
			this.lastCenter = DataManager<ChijiDataManager>.GetInstance().PoisonRing.lastCenter;
			this.lastRadius = DataManager<ChijiDataManager>.GetInstance().PoisonRing.lastRadius;
			Vector2 nextStageCenter = DataManager<ChijiDataManager>.GetInstance().PoisonRing.nextStageCenter;
			float nextStageRadius = DataManager<ChijiDataManager>.GetInstance().PoisonRing.nextStageRadius;
			if (this.m_mapFrame != null)
			{
				this.m_mapFrame.ResetSourceCircle(this.lastCenter, this.lastRadius);
				this.m_mapFrame.SetWhiteCircle(this.center, this.radius);
				this.m_mapFrame.SetBlueCircle(this.center, this.radius, this.durTime, this.shrinkTime);
			}
		}

		// Token: 0x0600A587 RID: 42375 RVA: 0x002233E3 File Offset: 0x002217E3
		public void ShowPoisionEffect(bool isShow)
		{
			if (null != this.mDeadTips)
			{
				this.mDeadTips.CustomActive(isShow);
			}
		}

		// Token: 0x0600A588 RID: 42376 RVA: 0x00223404 File Offset: 0x00221804
		private void InitJoystick()
		{
			this._inputManager = new InputManager();
			this._inputManager.LoadJoystick(Singleton<SettingManager>.GetInstance().GetJoystickMode());
			GameObject joyStick = this._inputManager.GetJoyStick();
			if (joyStick != null)
			{
				Utility.AttachTo(joyStick, Singleton<ClientSystemManager>.instance.BottomLayer, false);
				joyStick.transform.SetAsFirstSibling();
			}
			this._inputManager.SetJoyStickMoveCallback(new UnityAction<Vector2>(this._OnJoyStickMove));
			this._inputManager.SetJoyStickMoveEndCallback(new UnityAction(this._OnJoyStickStop));
		}

		// Token: 0x0600A589 RID: 42377 RVA: 0x00223494 File Offset: 0x00221894
		private void _OnJoyStickStop()
		{
			if (DataManager<ChijiDataManager>.GetInstance().IsMainPlayerDead)
			{
				return;
			}
			this.mIsStopMoveFunction = false;
			this.mLastJoyStickFizzyCheck = false;
			ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemGameBattle;
			if (clientSystemGameBattle != null && clientSystemGameBattle.MainPlayer != null)
			{
				if (clientSystemGameBattle.MainPlayer.MoveState == BeFighterMain.EMoveState.AutoMoving)
				{
					return;
				}
				clientSystemGameBattle.MainPlayer.CommandStopMove();
			}
		}

		// Token: 0x0600A58A RID: 42378 RVA: 0x00223500 File Offset: 0x00221900
		private void _OnJoyStickMove(Vector2 pos)
		{
			ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemGameBattle;
			if (clientSystemGameBattle == null || clientSystemGameBattle.MainPlayer == null || DataManager<ChijiDataManager>.GetInstance().IsMainPlayerDead)
			{
				return;
			}
			if (pos == Vector2.zero)
			{
				return;
			}
			if (this.mLastJoyStickFizzyCheck)
			{
				if ((this.mLastJoyStickPosition - pos).magnitude < 0.438f)
				{
					return;
				}
				this.mLastJoyStickFizzyCheck = false;
			}
			this.mLastJoyStickPosition = pos;
			if (this.mIsStopMoveFunction)
			{
				return;
			}
			Vector2 normalized = pos.normalized;
			if (normalized.x > this.m_sin60)
			{
				normalized.x = 1f;
				normalized.y = 0f;
			}
			else if (normalized.x > this.m_sin30 && normalized.x <= this.m_sin60)
			{
				normalized.x = this.m_sin45;
				if (normalized.y > 0f)
				{
					normalized.y = this.m_sin45;
				}
				else
				{
					normalized.y = -this.m_sin45;
				}
			}
			else if (normalized.x > -this.m_sin30 && normalized.x <= this.m_sin30)
			{
				normalized.x = 0f;
				if (normalized.y > 0f)
				{
					normalized.y = 1f;
				}
				else
				{
					normalized.y = -1f;
				}
			}
			else if (normalized.x > -this.m_sin60 && normalized.x <= -this.m_sin30)
			{
				normalized.x = -this.m_sin45;
				if (normalized.y > 0f)
				{
					normalized.y = this.m_sin45;
				}
				else
				{
					normalized.y = -this.m_sin45;
				}
			}
			else if (normalized.x <= -this.m_sin60)
			{
				normalized.x = -1f;
				normalized.y = 0f;
			}
			Vector3 vector;
			vector..ctor(normalized.x, 0f, normalized.y);
			BeBaseActorData actorData = clientSystemGameBattle.MainPlayer.ActorData;
			if (actorData != null)
			{
				ActorMoveData moveData = actorData.MoveData;
				if (moveData.TargetDirection != vector)
				{
					clientSystemGameBattle.MainPlayer.CommandMoveForward(vector);
				}
			}
		}

		// Token: 0x0600A58B RID: 42379 RVA: 0x0022377F File Offset: 0x00221B7F
		private void _UnloadInput()
		{
			if (this._inputManager != null)
			{
				this._inputManager.Unload();
				this._inputManager = null;
			}
		}

		// Token: 0x0600A58C RID: 42380 RVA: 0x0022379E File Offset: 0x00221B9E
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600A58D RID: 42381 RVA: 0x002237A4 File Offset: 0x00221BA4
		protected override void _OnUpdate(float timeElapsed)
		{
			this.durTime += timeElapsed;
			if (this._inputManager != null)
			{
				this._inputManager.SingleUpdate(0);
			}
			if (DataManager<ChijiDataManager>.GetInstance().CurBattleStage < ChiJiTimeTable.eBattleStage.BS_PUT_ITEM_1 && this.LeftTime >= 0)
			{
				this.fTimeIntrval += timeElapsed;
				if (this.fTimeIntrval >= 0.4f)
				{
					this.fTimeIntrval = 0f;
					uint num = DataManager<TimeManager>.GetInstance().GetServerTime() - this.StartServerTime;
					this.LeftTime = this.LastTime - (int)num;
					if (this.mTime != null)
					{
						this.mTime.text = ChijiMainFrame.mStagename + Function.GetLeftTime((int)(this.StartServerTime + (uint)this.LastTime), (int)DataManager<TimeManager>.GetInstance().GetServerTime(), ShowtimeType.OnlineGift);
					}
				}
			}
			if (this.bRefreshPickUpState)
			{
				if (this.mPickUpProcess != null)
				{
					if (this.bPickUpFinish)
					{
						if (this.fLocalTime - this.DelayHideTime >= 0.2f)
						{
							this.bRefreshPickUpState = false;
							this.bPickUpFinish = false;
							this.mPickUpProcess.CustomActive(false);
							this.fLocalTime = 0f;
							this.DelayHideTime = 0f;
							Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChijiSkillChooseFrame>(null, false);
							if (this.picktype == PickUpType.PickUpSkill)
							{
								Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChijiSkillChooseFrame>(FrameLayer.Middle, this.skillList, string.Empty);
							}
							else if (this.picktype == PickUpType.PickUpItem)
							{
								Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChijiSkillChooseFrame>(FrameLayer.Middle, this.equipList, string.Empty);
							}
							else
							{
								this.bWaitPickUpMsg = true;
							}
							this.picktype = PickUpType.None;
						}
					}
					else
					{
						this.mPickUpProcess.value = this.fLocalTime / (float)this.PickUpItemLastTime;
					}
				}
				this.fLocalTime += timeElapsed * 1.35f;
			}
			if (DataManager<ChijiDataManager>.GetInstance().RecentKillPlayerID != 0UL)
			{
				this.KillInfoShowTimeIntrval += timeElapsed;
				if (this.KillInfoShowTimeIntrval >= 4f)
				{
					this.mKillInfo.CustomActive(false);
					this.KillInfoShowTimeIntrval = 0f;
					DataManager<ChijiDataManager>.GetInstance().RecentKillPlayerID = 0UL;
				}
			}
			if (DataManager<ChijiDataManager>.GetInstance().GuardForSettlement)
			{
				this.SettlementTime += timeElapsed;
				if (this.SettlementTime >= 0.4f)
				{
					this.SettlementTime = 0f;
					if (DataManager<TimeManager>.GetInstance().GetServerTime() - this.StartServerTime >= 2.4f)
					{
						DataManager<ChijiDataManager>.GetInstance().OpenSettlementFrame();
						DataManager<ChijiDataManager>.GetInstance().GuardForSettlement = false;
					}
				}
			}
			this._UpdateChijiMap();
		}

		// Token: 0x0600A58E RID: 42382 RVA: 0x00223A4C File Offset: 0x00221E4C
		protected override void _bindExUI()
		{
			this.mBtClose = this.mBind.GetCom<Button>("btClose");
			if (null != this.mBtClose)
			{
				this.mBtClose.onClick.AddListener(new UnityAction(this._onBtCloseButtonClick));
			}
			this.mBtBag = this.mBind.GetCom<Button>("btBag");
			if (null != this.mBtBag)
			{
				this.mBtBag.onClick.AddListener(new UnityAction(this._onBtBagButtonClick));
			}
			this.mBtSkill = this.mBind.GetCom<Button>("btSkill");
			if (null != this.mBtSkill)
			{
				this.mBtSkill.onClick.AddListener(new UnityAction(this._onBtSkillButtonClick));
			}
			this.mTime = this.mBind.GetCom<Text>("Time");
			this.mMapscrollRect = this.mBind.GetCom<ScrollRect>("MapscrollRect");
			this.mMapContent = this.mBind.GetGameObject("MapContent");
			this.mBtMap = this.mBind.GetCom<Button>("btMap");
			if (null != this.mBtMap)
			{
				this.mBtMap.onClick.AddListener(new UnityAction(this._onBtMapButtonClick));
			}
			this.mSurvivePlayerNum = this.mBind.GetCom<Text>("SurvivePlayerNum");
			this.mPlayerHeadPortraitInfoRoot = this.mBind.GetGameObject("HeadRoot");
			this.mDeadTips = this.mBind.GetGameObject("Canxue");
			this.mDeathPlayer0 = this.mBind.GetCom<Text>("DeathPlayer0");
			this.mDeathPlayer1 = this.mBind.GetCom<Text>("DeathPlayer1");
			this.mDeathPlayer2 = this.mBind.GetCom<Text>("DeathPlayer2");
			this.mKillInfo = this.mBind.GetCom<Text>("KillInfo");
			this.mKills = this.mBind.GetCom<Text>("kills");
			this.mShowKill = this.mBind.GetCom<Text>("ShowKill");
			this.mBtPk = this.mBind.GetCom<Button>("btPk");
			if (null != this.mBtPk)
			{
				this.mBtPk.onClick.AddListener(new UnityAction(this._onBtPkButtonClick));
			}
			this.mPkText = this.mBind.GetCom<Text>("pkText");
			this.mPickUpProcess = this.mBind.GetCom<Slider>("PickUpProcess");
			this.mChallengeTipRoot = this.mBind.GetGameObject("ChallengeTipRoot");
			this.mBtReport = this.mBind.GetCom<Button>("btReport");
			this.mBtReport.onClick.AddListener(new UnityAction(this._onBtReportButtonClick));
			this.mShopButton = this.mBind.GetCom<Button>("shopButton");
			if (this.mShopButton != null)
			{
				this.mShopButton.onClick.AddListener(new UnityAction(this.OnShopButtonClicked));
			}
			this.mShopViewRoot = this.mBind.GetGameObject("shopViewRoot");
			this.mDeathplayer2Bg = this.mBind.GetGameObject("Deathplayer2Bg");
			this.mDeathplayer1Bg = this.mBind.GetGameObject("Deathplayer1Bg");
			this.mDeathplayer0Bg = this.mBind.GetGameObject("Deathplayer0Bg");
		}

		// Token: 0x0600A58F RID: 42383 RVA: 0x00223DC0 File Offset: 0x002221C0
		protected override void _unbindExUI()
		{
			if (null != this.mBtClose)
			{
				this.mBtClose.onClick.RemoveListener(new UnityAction(this._onBtCloseButtonClick));
			}
			this.mBtClose = null;
			if (null != this.mBtBag)
			{
				this.mBtBag.onClick.RemoveListener(new UnityAction(this._onBtBagButtonClick));
			}
			this.mBtBag = null;
			if (null != this.mBtSkill)
			{
				this.mBtSkill.onClick.RemoveListener(new UnityAction(this._onBtSkillButtonClick));
			}
			this.mBtSkill = null;
			this.mTime = null;
			this.mMapscrollRect = null;
			this.mMapContent = null;
			if (null != this.mBtMap)
			{
				this.mBtMap.onClick.RemoveListener(new UnityAction(this._onBtMapButtonClick));
			}
			this.mBtMap = null;
			this.mSurvivePlayerNum = null;
			this.mPlayerHeadPortraitInfoRoot = null;
			this.mDeadTips = null;
			this.mDeathPlayer0 = null;
			this.mDeathPlayer1 = null;
			this.mDeathPlayer2 = null;
			this.mKillInfo = null;
			this.mKills = null;
			this.mShowKill = null;
			if (null != this.mBtPk)
			{
				this.mBtPk.onClick.RemoveListener(new UnityAction(this._onBtPkButtonClick));
			}
			this.mBtPk = null;
			this.mPkText = null;
			this.mPickUpProcess = null;
			this.mChallengeTipRoot = null;
			this.mBtReport.onClick.RemoveListener(new UnityAction(this._onBtReportButtonClick));
			this.mBtReport = null;
			if (this.mShopButton != null)
			{
				this.mShopButton.onClick.RemoveListener(new UnityAction(this.OnShopButtonClicked));
				this.mShopButton = null;
			}
			this.mShopViewRoot = null;
			this.mDeathplayer2Bg = null;
			this.mDeathplayer1Bg = null;
			this.mDeathplayer0Bg = null;
		}

		// Token: 0x0600A590 RID: 42384 RVA: 0x00223FAD File Offset: 0x002223AD
		private void _onBtCloseButtonClick()
		{
			SystemNotifyManager.SystemNotify(4200007, new UnityAction(this._OnLeaveChiji));
		}

		// Token: 0x0600A591 RID: 42385 RVA: 0x00223FC5 File Offset: 0x002223C5
		private void _onBtBagButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<PackageNewFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600A592 RID: 42386 RVA: 0x00223FD9 File Offset: 0x002223D9
		private void _onBtSkillButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChijiSkillFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600A593 RID: 42387 RVA: 0x00223FF0 File Offset: 0x002223F0
		private void _onBtMapButtonClick()
		{
			ChijiFullMapFrame chijiFullMapFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChijiFullMapFrame>(FrameLayer.Middle, null, string.Empty) as ChijiFullMapFrame;
			if (chijiFullMapFrame != null && chijiFullMapFrame.MapFrame != null)
			{
				chijiFullMapFrame.MapFrame.ResetSourceCircle(this.lastCenter, this.lastRadius);
				chijiFullMapFrame.MapFrame.SetWhiteCircle(this.center, this.radius);
				chijiFullMapFrame.MapFrame.SetBlueCircle(this.center, this.radius, this.durTime, this.shrinkTime);
			}
		}

		// Token: 0x0600A594 RID: 42388 RVA: 0x00224076 File Offset: 0x00222476
		private void _onBtPkButtonClick()
		{
			DataManager<ChijiDataManager>.GetInstance().IsReadyPk = !DataManager<ChijiDataManager>.GetInstance().IsReadyPk;
			this._OnPKButtonChange(null);
		}

		// Token: 0x0600A595 RID: 42389 RVA: 0x00224098 File Offset: 0x00222498
		private void _OnPKButtonChange(UIEvent iEvent)
		{
			ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemGameBattle;
			if (DataManager<ChijiDataManager>.GetInstance().IsReadyPk)
			{
				this.mPkText.text = "取消挑战";
				if (this.mChallengeTipRoot != null)
				{
					this.mChallengeTipRoot.CustomActive(true);
				}
				if (clientSystemGameBattle != null && clientSystemGameBattle.MainPlayer != null)
				{
					if (this.mAttackAreaEffect == null)
					{
						this.mAttackAreaEffect = clientSystemGameBattle.MainPlayer.CreateAttackAreaEffect("Effects/Scene_effects/Scene_Chiji/Prefab/Eff_Scene_Chiji_yujingguangquan");
						this.mAttackAreaEffect.SetScale(1.5f);
					}
					else
					{
						this.mAttackAreaEffect.SetVisible(true);
					}
				}
			}
			else
			{
				this.mPkText.text = "挑战";
				if (this.mChallengeTipRoot != null)
				{
					this.mChallengeTipRoot.CustomActive(false);
				}
				if (this.mAttackAreaEffect != null)
				{
					this.mAttackAreaEffect.SetVisible(false);
				}
			}
		}

		// Token: 0x0600A596 RID: 42390 RVA: 0x0022418D File Offset: 0x0022258D
		private void _onBtReportButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChijiBugReportFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600A597 RID: 42391 RVA: 0x002241A4 File Offset: 0x002225A4
		private void OnShopButtonClicked()
		{
			if (this._chijiShopView == null)
			{
				GameObject gameObject = CommonUtility.LoadGameObject(this.mShopViewRoot);
				if (gameObject != null)
				{
					this._chijiShopView = gameObject.GetComponent<ChijiShopView>();
				}
				if (this._chijiShopView != null)
				{
					this._chijiShopView.InitShopView();
				}
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this._chijiShopView.gameObject, true);
				this._chijiShopView.OnEnableShopView();
			}
		}

		// Token: 0x04005C50 RID: 23632
		private ChijiRoomData roomData = new ChijiRoomData();

		// Token: 0x04005C51 RID: 23633
		private ChijiMapFrame m_mapFrame;

		// Token: 0x04005C52 RID: 23634
		public static string mStagename = string.Empty;

		// Token: 0x04005C53 RID: 23635
		private int LastTime = 30;

		// Token: 0x04005C54 RID: 23636
		private int LeftTime;

		// Token: 0x04005C55 RID: 23637
		private float fTimeIntrval;

		// Token: 0x04005C56 RID: 23638
		private uint StartServerTime;

		// Token: 0x04005C57 RID: 23639
		private float KillInfoShowTimeIntrval;

		// Token: 0x04005C58 RID: 23640
		private float SettlementTime;

		// Token: 0x04005C59 RID: 23641
		private GameObject mDeadTips;

		// Token: 0x04005C5A RID: 23642
		private bool bRefreshPickUpState;

		// Token: 0x04005C5B RID: 23643
		private bool bPickUpFinish;

		// Token: 0x04005C5C RID: 23644
		private bool bWaitPickUpMsg;

		// Token: 0x04005C5D RID: 23645
		private int PickUpItemLastTime = 4;

		// Token: 0x04005C5E RID: 23646
		private float fLocalTime;

		// Token: 0x04005C5F RID: 23647
		private float DelayHideTime;

		// Token: 0x04005C60 RID: 23648
		private PickUpType picktype;

		// Token: 0x04005C61 RID: 23649
		private ChiJiSkill[] skillList;

		// Token: 0x04005C62 RID: 23650
		private uint[] equipList;

		// Token: 0x04005C63 RID: 23651
		private Vector2 center = Vector2.zero;

		// Token: 0x04005C64 RID: 23652
		private float radius;

		// Token: 0x04005C65 RID: 23653
		private float durTime;

		// Token: 0x04005C66 RID: 23654
		private float shrinkTime;

		// Token: 0x04005C67 RID: 23655
		private Vector2 lastCenter = Vector2.zero;

		// Token: 0x04005C68 RID: 23656
		private float lastRadius;

		// Token: 0x04005C69 RID: 23657
		private bool mIsStopMoveFunction;

		// Token: 0x04005C6A RID: 23658
		private bool mLastJoyStickFizzyCheck;

		// Token: 0x04005C6B RID: 23659
		private Vector2 mLastJoyStickPosition = Vector2.zero;

		// Token: 0x04005C6C RID: 23660
		private float m_sin60 = 0.8660254f;

		// Token: 0x04005C6D RID: 23661
		private float m_sin45 = 0.7071067f;

		// Token: 0x04005C6E RID: 23662
		private float m_sin30 = 0.5f;

		// Token: 0x04005C6F RID: 23663
		private InputManager _inputManager;

		// Token: 0x04005C70 RID: 23664
		private GeEffectEx mAttackAreaEffect;

		// Token: 0x04005C71 RID: 23665
		private ChijiPlayerHeadPortraitInfoView mChijiPlayerHeadPortraitInfoView;

		// Token: 0x04005C72 RID: 23666
		private Button mBtClose;

		// Token: 0x04005C73 RID: 23667
		private Button mBtBag;

		// Token: 0x04005C74 RID: 23668
		private Button mBtSkill;

		// Token: 0x04005C75 RID: 23669
		private Text mTime;

		// Token: 0x04005C76 RID: 23670
		private ScrollRect mMapscrollRect;

		// Token: 0x04005C77 RID: 23671
		private GameObject mMapContent;

		// Token: 0x04005C78 RID: 23672
		private Button mBtMap;

		// Token: 0x04005C79 RID: 23673
		private Text mSurvivePlayerNum;

		// Token: 0x04005C7A RID: 23674
		private GameObject mPlayerHeadPortraitInfoRoot;

		// Token: 0x04005C7B RID: 23675
		private Text mDeathPlayer0;

		// Token: 0x04005C7C RID: 23676
		private Text mDeathPlayer1;

		// Token: 0x04005C7D RID: 23677
		private Text mDeathPlayer2;

		// Token: 0x04005C7E RID: 23678
		private Text mKillInfo;

		// Token: 0x04005C7F RID: 23679
		private Text mKills;

		// Token: 0x04005C80 RID: 23680
		private Text mShowKill;

		// Token: 0x04005C81 RID: 23681
		private Button mBtPk;

		// Token: 0x04005C82 RID: 23682
		private Text mPkText;

		// Token: 0x04005C83 RID: 23683
		private Slider mPickUpProcess;

		// Token: 0x04005C84 RID: 23684
		private GameObject mChallengeTipRoot;

		// Token: 0x04005C85 RID: 23685
		private Button mBtReport;

		// Token: 0x04005C86 RID: 23686
		private Button mShopButton;

		// Token: 0x04005C87 RID: 23687
		private GameObject mShopViewRoot;

		// Token: 0x04005C88 RID: 23688
		private GameObject mDeathplayer2Bg;

		// Token: 0x04005C89 RID: 23689
		private GameObject mDeathplayer1Bg;

		// Token: 0x04005C8A RID: 23690
		private GameObject mDeathplayer0Bg;

		// Token: 0x04005C8B RID: 23691
		private ChijiShopView _chijiShopView;
	}
}
