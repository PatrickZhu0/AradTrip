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
	// Token: 0x020014AA RID: 5290
	internal class BudoArenaFrame : ClientFrame
	{
		// Token: 0x0600CD05 RID: 52485 RVA: 0x00325F81 File Offset: 0x00324381
		public static void Open(BudoArenaFrameData data = null)
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<BudoArenaFrame>(null, false);
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<BudoArenaFrame>(FrameLayer.Bottom, data, string.Empty);
		}

		// Token: 0x0600CD06 RID: 52486 RVA: 0x00325FA1 File Offset: 0x003243A1
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Budo/BudoArenaFrame";
		}

		// Token: 0x0600CD07 RID: 52487 RVA: 0x00325FA8 File Offset: 0x003243A8
		private GameObject _LoadSeekCom(GameObject goParent, string path = "UIFlatten/Prefabs/Pk/Seek")
		{
			if (goParent == null || string.IsNullOrEmpty(path))
			{
				return null;
			}
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadRes(path, typeof(GameObject), true, 0U).obj as GameObject;
			Utility.AttachTo(gameObject, goParent, false);
			gameObject.CustomActive(true);
			this.comAudio = gameObject.GetComponent<UIAudioProxy>();
			if (null != this.comAudio)
			{
				this.comAudio.TriggerAudio(8888);
			}
			this.comCounterDown = Utility.FindComponent<MatchCounterDown>(gameObject, "CountDown", true);
			this.comCounterDown.enabled = false;
			return gameObject;
		}

		// Token: 0x0600CD08 RID: 52488 RVA: 0x0032604C File Offset: 0x0032444C
		protected override void _OnOpenFrame()
		{
			this.m_kData = (this.userData as BudoArenaFrameData);
			this.btnToTraditional = Utility.FindComponent<Button>(this.frame, "BtnSwitchToFight", true);
			if (this.btnToTraditional != null)
			{
				this.btnToTraditional.onClick.AddListener(new UnityAction(this._OnClickSwithToTraditional));
			}
			this.goMask = Utility.FindChild(this.frame, "FrontPage");
			this.goMask.CustomActive(false);
			this.goTimer = Utility.FindChild(this.frame, "MatchInfo");
			this.goTimer.CustomActive(false);
			this.goSeek = this._LoadSeekCom(Utility.FindChild(this.frame, "MatchInfo"), "UIFlatten/Prefabs/Pk/Seek");
			this.bIsMatch = false;
			this.btnMatch = Utility.FindComponent<Button>(this.frame, "BtnStartMatch", true);
			this.btnMatch.onClick.AddListener(new UnityAction(this._OnClickMatch));
			this.btnMatch.CustomActive(true);
			this.btnStopMatch = Utility.FindComponent<Button>(this.frame, "BtnStopMatch", true);
			this.btnStopMatch.onClick.AddListener(new UnityAction(this._OnClickStopMatch));
			this.btnStopMatch.CustomActive(false);
			this.bIsWaiting = false;
			this._InitStars();
			this._UpdateBudoInfo();
			BudoManager instance = DataManager<BudoManager>.GetInstance();
			instance.onBudoInfoChanged = (BudoManager.OnBudoInfoChanged)Delegate.Combine(instance.onBudoInfoChanged, new BudoManager.OnBudoInfoChanged(this._UpdateBudoInfo));
			BudoManager instance2 = DataManager<BudoManager>.GetInstance();
			instance2.onBudoInfoChanged = (BudoManager.OnBudoInfoChanged)Delegate.Combine(instance2.onBudoInfoChanged, new BudoManager.OnBudoInfoChanged(this.OnBudoInfoChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityUpdate, new ClientEventSystem.UIEventHandler(this._OnActiveUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PkMatchStartSuccess, new ClientEventSystem.UIEventHandler(this._OnMatchOk));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PkMatchFailed, new ClientEventSystem.UIEventHandler(this._OnMatchStop));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PkMatchCancelSuccess, new ClientEventSystem.UIEventHandler(this._OnMatchCancelOk));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PkMatchCancelFailed, new ClientEventSystem.UIEventHandler(this._OnMatchCancelFailed));
			this.comTalk = ComTalk.Create(Utility.FindChild(this.frame, "TalkParent"));
		}

		// Token: 0x0600CD09 RID: 52489 RVA: 0x0032629C File Offset: 0x0032469C
		private void _OnActiveUpdate(UIEvent uiEvent)
		{
			uint num = (uint)uiEvent.Param1;
			if ((ulong)num == (ulong)((long)BudoManager.ActiveID) && DataManager<ActiveManager>.GetInstance().allActivities.ContainsKey((int)num))
			{
				ActivityInfo activityInfo = DataManager<ActiveManager>.GetInstance().allActivities[(int)num];
				if (activityInfo != null && activityInfo.state == 0 && this.bIsMatch)
				{
					WorldMatchCancelReq cmd = new WorldMatchCancelReq();
					NetManager.Instance().SendCommand<WorldMatchCancelReq>(ServerType.GATE_SERVER, cmd);
				}
			}
		}

		// Token: 0x0600CD0A RID: 52490 RVA: 0x00326317 File Offset: 0x00324717
		private void _OnMatchOk(UIEvent uiEvent)
		{
			this.bIsWaiting = false;
			this.bIsMatch = true;
			this.goMask.CustomActive(true);
		}

		// Token: 0x0600CD0B RID: 52491 RVA: 0x00326334 File Offset: 0x00324734
		private void _OnMatchStop(UIEvent uiEvent)
		{
			this.bIsWaiting = false;
			this.bIsMatch = false;
			this.goMask.CustomActive(false);
			this.btnMatch.CustomActive(true);
			this.btnStopMatch.CustomActive(false);
			this.goTimer.CustomActive(false);
			this.comCounterDown.enabled = false;
		}

		// Token: 0x0600CD0C RID: 52492 RVA: 0x0032638C File Offset: 0x0032478C
		private void _OnMatchCancelOk(UIEvent uiEvent)
		{
			this.bIsWaiting = false;
			this.bIsMatch = false;
			this.goMask.CustomActive(false);
			this.btnMatch.CustomActive(true);
			this.btnStopMatch.CustomActive(false);
			this.goTimer.CustomActive(false);
			this.comCounterDown.enabled = false;
		}

		// Token: 0x0600CD0D RID: 52493 RVA: 0x003263E3 File Offset: 0x003247E3
		private void _OnMatchCancelFailed(UIEvent uiEvent)
		{
			this.bIsWaiting = false;
			this.bIsMatch = true;
			this.goMask.CustomActive(true);
			this.btnMatch.CustomActive(false);
			this.btnStopMatch.CustomActive(true);
		}

		// Token: 0x0600CD0E RID: 52494 RVA: 0x00326417 File Offset: 0x00324817
		private void _OnClickAward()
		{
			DataManager<BudoManager>.GetInstance().SendSceneWudaoRewardReq();
		}

		// Token: 0x0600CD0F RID: 52495 RVA: 0x00326424 File Offset: 0x00324824
		private void _InitStars()
		{
			this.comJarItem = base.CreateComItem(Utility.FindChild(this.frame, "ResultIntimeShow/Content/ItemParent"));
			this.comJarItem.Setup(null, null);
			this.btnAward = Utility.FindComponent<Button>(this.frame, "ResultIntimeShow/BtnTaskAward", true);
			this.btnAward.onClick.AddListener(new UnityAction(this._OnClickAward));
			this.grayAward = this.btnAward.gameObject.GetComponent<UIGray>();
			for (int i = 0; i < this.goBudoParent.transform.childCount; i++)
			{
				GameObject gameObject = this.goBudoParent.transform.GetChild(i).gameObject;
				this.m_akRoots.Add(gameObject);
				this.m_akStarBacks.Add(gameObject.transform.Find("bg").gameObject);
				this.m_akStarFronts.Add(gameObject.transform.Find("child").gameObject);
			}
		}

		// Token: 0x0600CD10 RID: 52496 RVA: 0x00326528 File Offset: 0x00324928
		private void _UnInitStars()
		{
			this.m_akRoots.Clear();
			this.m_akStarBacks.Clear();
			this.m_akStarFronts.Clear();
			if (this.btnAward != null)
			{
				this.btnAward.onClick.RemoveAllListeners();
				this.btnAward = null;
			}
		}

		// Token: 0x0600CD11 RID: 52497 RVA: 0x0032657E File Offset: 0x0032497E
		private void _PreViewItem(GameObject obj, ItemData item)
		{
			if (item != null)
			{
				DataManager<BudoManager>.GetInstance().OpenBudoPreviewFrame(item.TableID);
			}
		}

		// Token: 0x0600CD12 RID: 52498 RVA: 0x00326596 File Offset: 0x00324996
		private void OnBudoInfoChanged()
		{
		}

		// Token: 0x0600CD13 RID: 52499 RVA: 0x00326598 File Offset: 0x00324998
		private void _UpdateBudoInfo()
		{
			ItemData jarDataByTimes = DataManager<BudoManager>.GetInstance().GetJarDataByTimes();
			if (jarDataByTimes != null)
			{
				this.m_kJarName.text = jarDataByTimes.GetColorName(string.Empty, false);
				this.comJarItem.Setup(jarDataByTimes, new ComItem.OnItemClicked(this._PreViewItem));
			}
			else
			{
				this.comJarItem.Setup(null, null);
			}
			this.m_kBudoWinTimes.text = string.Format(TR.Value("budo_win_times"), DataManager<BudoManager>.GetInstance().WinTimes);
			for (int i = 0; i < this.m_akStarBacks.Count; i++)
			{
				this.m_akRoots[i].CustomActive(i < DataManager<BudoManager>.GetInstance().MaxLoseTimes);
				this.m_akStarBacks[i].CustomActive(i < DataManager<BudoManager>.GetInstance().MaxLoseTimes);
				this.m_akStarFronts[i].CustomActive(i < DataManager<BudoManager>.GetInstance().LoseTimes);
			}
			this.m_kBudoFriendlyHint.text = string.Format(TR.Value("budo_result_hint"), DataManager<BudoManager>.GetInstance().MaxWinTimes, DataManager<BudoManager>.GetInstance().MaxLoseTimes);
			bool canAcqured = DataManager<BudoManager>.GetInstance().CanAcqured;
			this.btnAward.enabled = canAcqured;
			this.grayAward.enabled = !canAcqured;
			this.btnAward.CustomActive(false);
		}

		// Token: 0x0600CD14 RID: 52500 RVA: 0x00326700 File Offset: 0x00324B00
		[UIEventHandle("btMainMenu")]
		private void OnClickMainMenu()
		{
		}

		// Token: 0x0600CD15 RID: 52501 RVA: 0x00326704 File Offset: 0x00324B04
		[UIEventHandle("btReturnToTown")]
		private void OnClickReturnToTown()
		{
			if (this.bIsMatch)
			{
				SystemNotifyManager.SystemNotify(4004, string.Empty);
				return;
			}
			if (this.m_kData == null)
			{
				return;
			}
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
			if (clientSystemTown == null)
			{
				Logger.LogError("Current System is not Town!!!");
				return;
			}
			if (Singleton<TableManager>.instance.GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty) == null)
			{
				return;
			}
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(clientSystemTown._NetSyncChangeScene(new SceneParams
			{
				currSceneID = this.m_kData.CurrentSceneID,
				currDoorID = 0,
				targetSceneID = this.m_kData.TargetTownSceneID,
				targetDoorID = 0
			}, true));
			this.frameMgr.CloseFrame<BudoArenaFrame>(this, false);
		}

		// Token: 0x0600CD16 RID: 52502 RVA: 0x003267D1 File Offset: 0x00324BD1
		[UIEventHandle("btMenu")]
		private void OnBtnMebuClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<PkMenuFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600CD17 RID: 52503 RVA: 0x003267E8 File Offset: 0x00324BE8
		private void _OnClickMatch()
		{
			if (this.bIsMatch)
			{
				return;
			}
			if (!DataManager<BudoManager>.GetInstance().CanMatch)
			{
				Logger.LogErrorFormat("CanNotMatch!!!!", new object[0]);
				return;
			}
			if (DataManager<TeamDataManager>.GetInstance().HasTeam())
			{
				SystemNotifyManager.SystemNotify(1104, string.Empty);
				return;
			}
			if (this.bIsWaiting)
			{
				return;
			}
			this.bIsWaiting = true;
			this.bIsMatch = true;
			this._BeginMatch();
			this.goTimer.CustomActive(true);
			this.comCounterDown.enabled = true;
			DataManager<BudoManager>.GetInstance().SendMatchParty();
		}

		// Token: 0x0600CD18 RID: 52504 RVA: 0x00326884 File Offset: 0x00324C84
		private void _OnClickStopMatch()
		{
			if (!this.bIsMatch)
			{
				return;
			}
			if (this.bIsWaiting)
			{
				return;
			}
			this.bIsWaiting = true;
			this.bIsMatch = false;
			this.btnMatch.CustomActive(true);
			this.btnStopMatch.CustomActive(false);
			this.goMask.CustomActive(true);
			WorldMatchCancelReq cmd = new WorldMatchCancelReq();
			NetManager.Instance().SendCommand<WorldMatchCancelReq>(ServerType.GATE_SERVER, cmd);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldMatchCancelRes>(delegate(WorldMatchCancelRes msgRet)
			{
				if (msgRet == null)
				{
					return;
				}
				if (msgRet.result != 0U)
				{
					SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PkMatchCancelFailed, null, null, null, null);
					return;
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PkMatchCancelSuccess, null, null, null, null);
			}, true, 15f, null);
		}

		// Token: 0x0600CD19 RID: 52505 RVA: 0x0032691D File Offset: 0x00324D1D
		private void _BeginMatch()
		{
			this.btnMatch.CustomActive(false);
			this.btnStopMatch.CustomActive(true);
			this.goMask.CustomActive(true);
		}

		// Token: 0x0600CD1A RID: 52506 RVA: 0x00326944 File Offset: 0x00324D44
		protected override void _OnCloseFrame()
		{
			if (this.bIsMatch)
			{
				this.bIsMatch = false;
			}
			if (this.btnMatch != null)
			{
				this.btnMatch.onClick.RemoveAllListeners();
				this.btnMatch = null;
			}
			if (this.btnStopMatch != null)
			{
				this.btnStopMatch.onClick.RemoveAllListeners();
				this.btnStopMatch = null;
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PkMatchStartSuccess, new ClientEventSystem.UIEventHandler(this._OnMatchOk));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PkMatchFailed, new ClientEventSystem.UIEventHandler(this._OnMatchStop));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PkMatchCancelSuccess, new ClientEventSystem.UIEventHandler(this._OnMatchCancelOk));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PkMatchCancelFailed, new ClientEventSystem.UIEventHandler(this._OnMatchCancelFailed));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityUpdate, new ClientEventSystem.UIEventHandler(this._OnActiveUpdate));
			if (this.btnToTraditional != null)
			{
				this.btnToTraditional.onClick.RemoveAllListeners();
				this.btnToTraditional = null;
			}
			this.m_kData = null;
			this.comJarItem.Setup(null, null);
			this.comJarItem = null;
			if (this.comTalk != null)
			{
				ComTalk.Recycle();
				this.comTalk = null;
			}
			BudoManager instance = DataManager<BudoManager>.GetInstance();
			instance.onBudoInfoChanged = (BudoManager.OnBudoInfoChanged)Delegate.Remove(instance.onBudoInfoChanged, new BudoManager.OnBudoInfoChanged(this._UpdateBudoInfo));
			BudoManager instance2 = DataManager<BudoManager>.GetInstance();
			instance2.onBudoInfoChanged = (BudoManager.OnBudoInfoChanged)Delegate.Remove(instance2.onBudoInfoChanged, new BudoManager.OnBudoInfoChanged(this.OnBudoInfoChanged));
			this._UnInitStars();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SwitchToMission, null, null, null, null);
		}

		// Token: 0x0600CD1B RID: 52507 RVA: 0x00326AFF File Offset: 0x00324EFF
		private void _OnClickSwithToTraditional()
		{
			if (this.bIsMatch)
			{
				SystemNotifyManager.SystemNotify(4004, string.Empty);
				return;
			}
			Utility.SwitchToPkWaitingRoom(PkRoomType.TraditionPk);
			base.Close(false);
		}

		// Token: 0x0400776B RID: 30571
		private BudoArenaFrameData m_kData;

		// Token: 0x0400776C RID: 30572
		private Button btnToTraditional;

		// Token: 0x0400776D RID: 30573
		private Button btnMatch;

		// Token: 0x0400776E RID: 30574
		private Button btnStopMatch;

		// Token: 0x0400776F RID: 30575
		private MatchCounterDown comCounterDown;

		// Token: 0x04007770 RID: 30576
		private ComTalk comTalk;

		// Token: 0x04007771 RID: 30577
		private GameObject goSeek;

		// Token: 0x04007772 RID: 30578
		private UIAudioProxy comAudio;

		// Token: 0x04007773 RID: 30579
		[UIControl("ResultIntimeShow/Name", typeof(Text), 0)]
		private Text m_kJarName;

		// Token: 0x04007774 RID: 30580
		[UIControl("ResultIntimeShow/Content/HintWin", typeof(Text), 0)]
		private Text m_kBudoWinTimes;

		// Token: 0x04007775 RID: 30581
		[UIControl("ResultIntimeShow/FriendlyHint", null, 0)]
		private Text m_kBudoFriendlyHint;

		// Token: 0x04007776 RID: 30582
		[UIObject("ResultIntimeShow/Content/Results")]
		private GameObject goBudoParent;

		// Token: 0x04007777 RID: 30583
		private List<GameObject> m_akRoots = new List<GameObject>();

		// Token: 0x04007778 RID: 30584
		private List<GameObject> m_akStarBacks = new List<GameObject>();

		// Token: 0x04007779 RID: 30585
		private List<GameObject> m_akStarFronts = new List<GameObject>();

		// Token: 0x0400777A RID: 30586
		private Button btnAward;

		// Token: 0x0400777B RID: 30587
		private UIGray grayAward;

		// Token: 0x0400777C RID: 30588
		private ComItem comJarItem;

		// Token: 0x0400777D RID: 30589
		private GameObject goMask;

		// Token: 0x0400777E RID: 30590
		private GameObject goTimer;

		// Token: 0x0400777F RID: 30591
		private bool bIsWaiting;

		// Token: 0x04007780 RID: 30592
		private bool bIsMatch;
	}
}
