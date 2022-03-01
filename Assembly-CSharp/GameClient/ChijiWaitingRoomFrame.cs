using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001126 RID: 4390
	public class ChijiWaitingRoomFrame : ClientFrame
	{
		// Token: 0x0600A6AC RID: 42668 RVA: 0x0022A65A File Offset: 0x00228A5A
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Chiji/ChijiWaitingRoomFrame";
		}

		// Token: 0x0600A6AD RID: 42669 RVA: 0x0022A661 File Offset: 0x00228A61
		private void InitData()
		{
			this.mLastJoyStickPosition = Vector2.zero;
			this.mLastJoyStickFizzyCheck = false;
			this.mIsStopMoveFunction = false;
		}

		// Token: 0x0600A6AE RID: 42670 RVA: 0x0022A67C File Offset: 0x00228A7C
		private void InitJoystick()
		{
			this._inputManager = new InputManager();
			this._inputManager.LoadJoystick(Singleton<SettingManager>.GetInstance().GetJoystickMode());
			this._inputManager.SetJoyStickMoveCallback(new UnityAction<Vector2>(this._OnJoyStickMove));
			this._inputManager.SetJoyStickMoveEndCallback(new UnityAction(this._OnJoyStickStop));
		}

		// Token: 0x0600A6AF RID: 42671 RVA: 0x0022A6D8 File Offset: 0x00228AD8
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

		// Token: 0x0600A6B0 RID: 42672 RVA: 0x0022A744 File Offset: 0x00228B44
		private void _OnJoyStickMove(Vector2 pos)
		{
			ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemGameBattle;
			if (clientSystemGameBattle.MainPlayer == null || DataManager<ChijiDataManager>.GetInstance().IsMainPlayerDead)
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
			if (clientSystemGameBattle.MainPlayer.ActorData.MoveData.TargetDirection != vector)
			{
				clientSystemGameBattle.MainPlayer.CommandMoveForward(vector);
			}
		}

		// Token: 0x0600A6B1 RID: 42673 RVA: 0x0022A9B0 File Offset: 0x00228DB0
		protected sealed override void _OnOpenFrame()
		{
			this.mBtLog.CustomActive(false);
			this.StartServerTime = DataManager<TimeManager>.GetInstance().GetServerTime();
			DataManager<ChijiDataManager>.GetInstance().IsMatching = false;
			DataManager<ChijiDataManager>.GetInstance().SwitchingTownToPrepare = false;
			DataManager<ChijiDataManager>.GetInstance().SwitchingChijiSceneToPrepare = false;
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MapItemFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<MapItemFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChijiSkillChooseFrame>(null, false);
			DataManager<ItemTipManager>.GetInstance().CloseAll();
			this.InitData();
			this.InitJoystick();
			this._BindUIEvent();
			if (this.userData != null)
			{
				this.roomData = (this.userData as ChijiRoomData);
				if (this.roomData != null && this.mtxtDesc != null)
				{
					this.mtxtDesc.text = "开始匹配";
				}
			}
			this._InitInterface();
			this._InitTalk();
			if (DataManager<ChijiDataManager>.GetInstance().GuardForSettlement)
			{
			}
			BattleEnrollReq cmd = new BattleEnrollReq
			{
				isMatch = 0U,
				accId = ClientApplication.playerinfo.accid,
				roleId = DataManager<PlayerBaseData>.GetInstance().RoleID,
				playerName = DataManager<PlayerBaseData>.GetInstance().Name,
				playerOccu = (byte)DataManager<PlayerBaseData>.GetInstance().JobTableID
			};
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<BattleEnrollReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600A6B2 RID: 42674 RVA: 0x0022AB00 File Offset: 0x00228F00
		protected sealed override void _OnCloseFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ClientSystemTownFrame>(null))
			{
				ClientSystemTownFrame clientSystemTownFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(ClientSystemTownFrame)) as ClientSystemTownFrame;
				clientSystemTownFrame.SetForbidFadeIn(false);
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<RanklistFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<RanklistFrame>(null, false);
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ChijiHelpFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChijiHelpFrame>(null, false);
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ChijiSeekWaitingFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChijiSeekWaitingFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChatFrame>(null, false);
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<RelationMenuFram>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<RelationMenuFram>(null, false);
			}
			this._UnBindUIEvent();
			this.UnloadInput();
			this._ClearData();
		}

		// Token: 0x0600A6B3 RID: 42675 RVA: 0x0022ABCC File Offset: 0x00228FCC
		private void UnloadInput()
		{
			if (this._inputManager != null)
			{
				this._inputManager.Unload();
				this._inputManager = null;
			}
		}

		// Token: 0x0600A6B4 RID: 42676 RVA: 0x0022ABEC File Offset: 0x00228FEC
		private void _ClearData()
		{
			this.roomData.Clear();
			this.mLastJoyStickFizzyCheck = false;
			this.mLastJoyStickPosition = Vector2.zero;
			this.mIsStopMoveFunction = false;
			this._inputManager = null;
			this.StartServerTime = 0U;
			this.SettlementTime = 0f;
			if (this.mComTalk != null)
			{
				ComTalk.Recycle();
				this.mComTalk = null;
			}
		}

		// Token: 0x0600A6B5 RID: 42677 RVA: 0x0022AC54 File Offset: 0x00229054
		private void _InitInterface()
		{
			if (this.mtxtDesc != null)
			{
				this.mtxtDesc.text = "开始匹配";
			}
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChijiSeekWaitingFrame>(null, false);
			if (this.mNum != null)
			{
				ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemGameBattle;
				if (clientSystemGameBattle != null && clientSystemGameBattle.OtherFighters != null)
				{
					this.mNum.text = string.Format("{0}", clientSystemGameBattle.OtherFighters.GetFightCount() + 1);
				}
			}
			if (this.mRobot != null)
			{
				this.mRobot.CustomActive(false);
			}
			this._UpdateReward();
			this.UpdateHonorSystemExpValue();
			this.UpdateIntegralRankBtn();
		}

		// Token: 0x0600A6B6 RID: 42678 RVA: 0x0022AD16 File Offset: 0x00229116
		private void _InitTalk()
		{
			this.mComTalk = ComTalk.Create(this.mTalkParent);
		}

		// Token: 0x0600A6B7 RID: 42679 RVA: 0x0022AD2C File Offset: 0x0022912C
		private void _BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.UpdateChijiPrepareScenePlayerNum, new ClientEventSystem.UIEventHandler(this._OnUpdatePlayerNum));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ChijiBestRank, new ClientEventSystem.UIEventHandler(this._OnUpdateBestRank));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.DisConnect, new ClientEventSystem.UIEventHandler(this._OnDisConnect));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this.OnCountValueChangeChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityUpdate, new ClientEventSystem.UIEventHandler(this.OnActivityUpdate));
		}

		// Token: 0x0600A6B8 RID: 42680 RVA: 0x0022ADC0 File Offset: 0x002291C0
		private void _UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.UpdateChijiPrepareScenePlayerNum, new ClientEventSystem.UIEventHandler(this._OnUpdatePlayerNum));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ChijiBestRank, new ClientEventSystem.UIEventHandler(this._OnUpdateBestRank));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.DisConnect, new ClientEventSystem.UIEventHandler(this._OnDisConnect));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this.OnCountValueChangeChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityUpdate, new ClientEventSystem.UIEventHandler(this.OnActivityUpdate));
		}

		// Token: 0x0600A6B9 RID: 42681 RVA: 0x0022AE54 File Offset: 0x00229254
		private void _OnUpdatePlayerNum(UIEvent iEvent)
		{
			if (this.mNum != null)
			{
				this.mNum.text = DataManager<ChijiDataManager>.GetInstance().GetPrepareScenePlayerNum().ToString();
			}
		}

		// Token: 0x0600A6BA RID: 42682 RVA: 0x0022AE95 File Offset: 0x00229295
		private void _OnUpdateBestRank(UIEvent iEvent)
		{
			this._UpdateReward();
		}

		// Token: 0x0600A6BB RID: 42683 RVA: 0x0022AEA0 File Offset: 0x002292A0
		private void _OnDisConnect(UIEvent iEvent)
		{
			DataManager<ChijiDataManager>.GetInstance().IsMatching = false;
			if (this.mtxtDesc != null)
			{
				this.mtxtDesc.text = "开始匹配";
			}
			DataManager<ChijiDataManager>.GetInstance().SwitchingPrepareToChijiScene = false;
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChijiSeekWaitingFrame>(null, false);
		}

		// Token: 0x0600A6BC RID: 42684 RVA: 0x0022AEF0 File Offset: 0x002292F0
		private void _UpdateReward()
		{
			if (this.mBestRank != null)
			{
				this.mBestRank.text = DataManager<ChijiDataManager>.GetInstance().BestRank.ToString();
			}
			if (this.mItemRoot != null)
			{
				int tableId = this._CalBestRankAward(DataManager<ChijiDataManager>.GetInstance().BestRank);
				ComItem comItem = this.mItemRoot.GetComponentInChildren<ComItem>();
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(tableId, 100, 0);
				if (itemData == null)
				{
					if (comItem != null)
					{
						comItem.CustomActive(false);
					}
				}
				else
				{
					if (comItem == null)
					{
						comItem = base.CreateComItem(this.mItemRoot);
					}
					comItem.CustomActive(true);
					comItem.Setup(itemData, new ComItem.OnItemClicked(this._ShowItemTip));
				}
			}
		}

		// Token: 0x0600A6BD RID: 42685 RVA: 0x0022AFBA File Offset: 0x002293BA
		private void _ShowItemTip(GameObject go, ItemData itemData)
		{
			if (itemData != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
			}
		}

		// Token: 0x0600A6BE RID: 42686 RVA: 0x0022AFD4 File Offset: 0x002293D4
		private int _CalBestRankAward(int BestRank)
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<ChijiRewardTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					ChijiRewardTable chijiRewardTable = keyValuePair.Value as ChijiRewardTable;
					if (chijiRewardTable != null)
					{
						if (BestRank <= chijiRewardTable.MinRank && BestRank >= chijiRewardTable.MaxRank)
						{
							return chijiRewardTable.RewardBoxID;
						}
					}
				}
			}
			return 0;
		}

		// Token: 0x0600A6BF RID: 42687 RVA: 0x0022B04F File Offset: 0x0022944F
		public sealed override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600A6C0 RID: 42688 RVA: 0x0022B054 File Offset: 0x00229454
		protected sealed override void _OnUpdate(float timeElapsed)
		{
			if (this._inputManager != null)
			{
				this._inputManager.SingleUpdate(0);
			}
			if (DataManager<ChijiDataManager>.GetInstance().GuardForSettlement)
			{
				this.SettlementTime += timeElapsed;
				if (this.SettlementTime > 0.3f)
				{
					this.SettlementTime = 0f;
					if (DataManager<TimeManager>.GetInstance().GetServerTime() - this.StartServerTime >= 1U)
					{
						DataManager<ChijiDataManager>.GetInstance().OpenSettlementFrame();
						DataManager<ChijiDataManager>.GetInstance().GuardForSettlement = false;
					}
				}
			}
		}

		// Token: 0x0600A6C1 RID: 42689 RVA: 0x0022B0DC File Offset: 0x002294DC
		protected sealed override void _bindExUI()
		{
			this.mBtClose = this.mBind.GetCom<Button>("btClose");
			if (null != this.mBtClose)
			{
				this.mBtClose.onClick.AddListener(new UnityAction(this._onBtCloseButtonClick));
			}
			this.mBtnEnrollChiji = this.mBind.GetCom<Button>("btnEnrollChiji");
			if (null != this.mBtnEnrollChiji)
			{
				this.mBtnEnrollChiji.onClick.AddListener(new UnityAction(this._onBtnEnrollChijiButtonClick));
			}
			this.mtxtDesc = this.mBind.GetCom<Text>("txtEnrollDes");
			this.mRobot = this.mBind.GetCom<Button>("btRobot");
			if (this.mRobot != null)
			{
				this.mRobot.onClick.AddListener(new UnityAction(this._onBtnAddRobotButtonClick));
			}
			this.mNum = this.mBind.GetCom<Text>("num");
			this.mRuleBtn = this.mBind.GetCom<Button>("RuleBtn");
			if (null != this.mRuleBtn)
			{
				this.mRuleBtn.onClick.AddListener(new UnityAction(this._onRuleButtonClick));
			}
			this.mIntegralRankBtn = this.mBind.GetCom<Button>("IntegralRankBtn");
			if (null != this.mIntegralRankBtn)
			{
				this.mIntegralRankBtn.onClick.AddListener(new UnityAction(this._onIntegralRankButtonClick));
			}
			this.mTalkParent = this.mBind.GetGameObject("TalkParent");
			this.mShopBtn = this.mBind.GetCom<Button>("Shop");
			if (this.mShopBtn != null)
			{
				this.mShopBtn.onClick.AddListener(new UnityAction(this._OnShopButtonClick));
			}
			this.mBestRank = this.mBind.GetCom<Text>("BestRank");
			this.mItemRoot = this.mBind.GetGameObject("itemRoot");
			this.mBtPreview = this.mBind.GetCom<Button>("btPreview");
			this.mBtPreview.onClick.AddListener(new UnityAction(this._onBtPreviewButtonClick));
			this.mHonorExpValueLabel = this.mBind.GetCom<Text>("honorExpValueLabel");
			this.mBtLog = this.mBind.GetCom<Button>("btLog");
			this.mBtLog.onClick.AddListener(new UnityAction(this._onBtLogButtonClick));
		}

		// Token: 0x0600A6C2 RID: 42690 RVA: 0x0022B364 File Offset: 0x00229764
		protected sealed override void _unbindExUI()
		{
			if (null != this.mBtClose)
			{
				this.mBtClose.onClick.RemoveListener(new UnityAction(this._onBtCloseButtonClick));
			}
			this.mBtClose = null;
			if (null != this.mBtnEnrollChiji)
			{
				this.mBtnEnrollChiji.onClick.RemoveListener(new UnityAction(this._onBtnEnrollChijiButtonClick));
			}
			this.mBtnEnrollChiji = null;
			if (this.mRobot != null)
			{
				this.mRobot.onClick.RemoveListener(new UnityAction(this._onBtnAddRobotButtonClick));
			}
			this.mNum = null;
			if (null != this.mRuleBtn)
			{
				this.mRuleBtn.onClick.RemoveListener(new UnityAction(this._onRuleButtonClick));
			}
			this.mRuleBtn = null;
			if (null != this.mIntegralRankBtn)
			{
				this.mIntegralRankBtn.onClick.RemoveListener(new UnityAction(this._onIntegralRankButtonClick));
			}
			this.mIntegralRankBtn = null;
			this.mTalkParent = null;
			if (this.mShopBtn != null)
			{
				this.mShopBtn.onClick.RemoveListener(new UnityAction(this._OnShopButtonClick));
			}
			this.mShopBtn = null;
			this.mBestRank = null;
			this.mItemRoot = null;
			this.mBtPreview.onClick.RemoveListener(new UnityAction(this._onBtPreviewButtonClick));
			this.mBtPreview = null;
			this.mHonorExpValueLabel = null;
			this.mBtLog.onClick.RemoveListener(new UnityAction(this._onBtLogButtonClick));
			this.mBtLog = null;
		}

		// Token: 0x0600A6C3 RID: 42691 RVA: 0x0022B50C File Offset: 0x0022990C
		private void _onBtCloseButtonClick()
		{
			if (DataManager<ChijiDataManager>.GetInstance().IsMatching)
			{
				SystemNotifyManager.SystemNotify(4200006, string.Empty);
				return;
			}
			DataManager<ChijiDataManager>.GetInstance().SwitchingPrepareToTown = true;
			if (!(Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() is ClientSystemGameBattle))
			{
				Logger.LogError("Current System is not GameBattle!!!");
				return;
			}
			BattleEnrollReq cmd = new BattleEnrollReq
			{
				isMatch = 0U,
				accId = ClientApplication.playerinfo.accid,
				roleId = DataManager<PlayerBaseData>.GetInstance().RoleID,
				playerName = DataManager<PlayerBaseData>.GetInstance().Name,
				playerOccu = (byte)DataManager<PlayerBaseData>.GetInstance().JobTableID
			};
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<BattleEnrollReq>(ServerType.GATE_SERVER, cmd);
			Singleton<ClientSystemManager>.GetInstance().SwitchSystem<ClientSystemTown>(null, null, false);
			this.frameMgr.CloseFrame<ChijiWaitingRoomFrame>(this, false);
		}

		// Token: 0x0600A6C4 RID: 42692 RVA: 0x0022B5E0 File Offset: 0x002299E0
		private void _onBtnEnrollChijiButtonClick()
		{
			if (DataManager<TeamDataManager>.GetInstance().HasTeam())
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("Chiji_has_team_Cannotmatch"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (!DataManager<ChijiDataManager>.GetInstance().MainFrameChijiButtonIsShow())
			{
				if (DataManager<ChijiDataManager>.GetInstance().IsMatching)
				{
					this.SendBattleEnrollReq();
				}
				else
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("Chiji_Activity_Close"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				}
				return;
			}
			this.SendBattleEnrollReq();
		}

		// Token: 0x0600A6C5 RID: 42693 RVA: 0x0022B650 File Offset: 0x00229A50
		private void SendBattleEnrollReq()
		{
			BattleEnrollReq cmd = new BattleEnrollReq
			{
				isMatch = (DataManager<ChijiDataManager>.GetInstance().IsMatching ? 0U : 1U),
				accId = ClientApplication.playerinfo.accid,
				roleId = DataManager<PlayerBaseData>.GetInstance().RoleID,
				playerName = DataManager<PlayerBaseData>.GetInstance().Name,
				playerOccu = (byte)DataManager<PlayerBaseData>.GetInstance().JobTableID
			};
			DataManager<ChijiDataManager>.GetInstance().IsMatching = !DataManager<ChijiDataManager>.GetInstance().IsMatching;
			if (DataManager<ChijiDataManager>.GetInstance().IsMatching)
			{
				this.mtxtDesc.text = "取消匹配";
				DataManager<ChijiDataManager>.GetInstance().SwitchingPrepareToChijiScene = true;
			}
			else
			{
				this.mtxtDesc.text = "开始匹配";
				DataManager<ChijiDataManager>.GetInstance().SwitchingPrepareToChijiScene = false;
			}
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<BattleEnrollReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600A6C6 RID: 42694 RVA: 0x0022B734 File Offset: 0x00229B34
		private void _onBtnAddRobotButtonClick()
		{
			BattleServerAddPkRobot cmd = new BattleServerAddPkRobot();
			NetManager.Instance().SendCommand<BattleServerAddPkRobot>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600A6C7 RID: 42695 RVA: 0x0022B754 File Offset: 0x00229B54
		private void _onRuleButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChijiHelpFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600A6C8 RID: 42696 RVA: 0x0022B768 File Offset: 0x00229B68
		private void _onIntegralRankButtonClick()
		{
			if (DataManager<ChijiDataManager>.GetInstance().IsMatching)
			{
				SystemNotifyManager.SystemNotify(4200006, string.Empty);
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<RanklistFrame>(FrameLayer.Middle, SortListType.SORTLIST_CHIJI_SCORE, string.Empty);
		}

		// Token: 0x0600A6C9 RID: 42697 RVA: 0x0022B7A4 File Offset: 0x00229BA4
		private void _OnShopButtonClick()
		{
			DataManager<ShopNewDataManager>.GetInstance().OpenShopNewFrame(29, 0, 0, -1);
		}

		// Token: 0x0600A6CA RID: 42698 RVA: 0x0022B7B5 File Offset: 0x00229BB5
		private void _onBtPreviewButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChijiRewardPreviewFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600A6CB RID: 42699 RVA: 0x0022B7C9 File Offset: 0x00229BC9
		private void _onBtLogButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChijiBugReportFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600A6CC RID: 42700 RVA: 0x0022B7E0 File Offset: 0x00229BE0
		private void OnCountValueChangeChanged(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			string a = (string)uiEvent.Param1;
			if (string.Equals(a, DataManager<HonorSystemDataManager>.GetInstance().ChiJiHonorExpCounterStr))
			{
				this.UpdateHonorSystemExpValue();
			}
		}

		// Token: 0x0600A6CD RID: 42701 RVA: 0x0022B828 File Offset: 0x00229C28
		private void OnActivityUpdate(UIEvent a_event)
		{
			uint item = (uint)a_event.Param1;
			List<int> list = DataManager<ChijiDataManager>.GetInstance().ChijiActivityIDs.ToList<int>();
			if (list != null && list.Contains((int)item))
			{
				this.UpdateIntegralRankBtn();
			}
		}

		// Token: 0x0600A6CE RID: 42702 RVA: 0x0022B86C File Offset: 0x00229C6C
		private void UpdateHonorSystemExpValue()
		{
			if (this.mHonorExpValueLabel == null)
			{
				return;
			}
			string thisWeekHonorExpStrInChiJi = HonorSystemUtility.GetThisWeekHonorExpStrInChiJi();
			this.mHonorExpValueLabel.text = thisWeekHonorExpStrInChiJi;
		}

		// Token: 0x0600A6CF RID: 42703 RVA: 0x0022B89D File Offset: 0x00229C9D
		private void UpdateIntegralRankBtn()
		{
			this.mIntegralRankBtn.CustomActive(DataManager<ChijiDataManager>.GetInstance().MainFrameChijiButtonIsShow());
		}

		// Token: 0x04005D40 RID: 23872
		private ChijiRoomData roomData = new ChijiRoomData();

		// Token: 0x04005D41 RID: 23873
		private uint StartServerTime;

		// Token: 0x04005D42 RID: 23874
		private float SettlementTime;

		// Token: 0x04005D43 RID: 23875
		private bool mIsStopMoveFunction;

		// Token: 0x04005D44 RID: 23876
		private bool mLastJoyStickFizzyCheck;

		// Token: 0x04005D45 RID: 23877
		private Vector2 mLastJoyStickPosition = Vector2.zero;

		// Token: 0x04005D46 RID: 23878
		private float m_sin60 = 0.8660254f;

		// Token: 0x04005D47 RID: 23879
		private float m_sin45 = 0.7071067f;

		// Token: 0x04005D48 RID: 23880
		private float m_sin30 = 0.5f;

		// Token: 0x04005D49 RID: 23881
		private InputManager _inputManager;

		// Token: 0x04005D4A RID: 23882
		private ComTalk mComTalk;

		// Token: 0x04005D4B RID: 23883
		private Button mBtClose;

		// Token: 0x04005D4C RID: 23884
		private Button mBtnEnrollChiji;

		// Token: 0x04005D4D RID: 23885
		private Button mRobot;

		// Token: 0x04005D4E RID: 23886
		private Text mtxtDesc;

		// Token: 0x04005D4F RID: 23887
		private Text mNum;

		// Token: 0x04005D50 RID: 23888
		private Button mRuleBtn;

		// Token: 0x04005D51 RID: 23889
		private Button mIntegralRankBtn;

		// Token: 0x04005D52 RID: 23890
		private GameObject mTalkParent;

		// Token: 0x04005D53 RID: 23891
		private Button mShopBtn;

		// Token: 0x04005D54 RID: 23892
		private Text mBestRank;

		// Token: 0x04005D55 RID: 23893
		private GameObject mItemRoot;

		// Token: 0x04005D56 RID: 23894
		private Button mBtPreview;

		// Token: 0x04005D57 RID: 23895
		private Text mHonorExpValueLabel;

		// Token: 0x04005D58 RID: 23896
		private Button mBtLog;
	}
}
