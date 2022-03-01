using System;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020017BD RID: 6077
	internal class ComFunction : MonoBehaviour
	{
		// Token: 0x0600EF90 RID: 61328 RVA: 0x00406D4C File Offset: 0x0040514C
		private void _BinderMissionRedPoint(GameObject goLocal, FunctionType eFunctionType)
		{
			if (null != goLocal && eFunctionType == FunctionType.FT_MISSION)
			{
				GameObject goRedPoint = Utility.FindChild(goLocal, "RedPoint");
				if (null != this.comRedBinder)
				{
					if (this.comRedBinder.onSucceed != null)
					{
						this.comRedBinder.onSucceed.RemoveAllListeners();
						this.comRedBinder.onSucceed.AddListener(delegate()
						{
							goRedPoint.CustomActive(true);
						});
					}
					if (this.comRedBinder.onFailed != null)
					{
						this.comRedBinder.onFailed.RemoveAllListeners();
						this.comRedBinder.onFailed.AddListener(delegate()
						{
							goRedPoint.CustomActive(false);
						});
					}
				}
			}
		}

		// Token: 0x0600EF91 RID: 61329 RVA: 0x00406E0C File Offset: 0x0040520C
		private void _InitToggles()
		{
			if (this.m_bInit)
			{
				return;
			}
			this.m_bInit = true;
			if (null == this.goTogglePrefab)
			{
				return;
			}
			for (int i = 0; i < this.toggles.Length; i++)
			{
				GameObject gameObject = Object.Instantiate<GameObject>(this.goTogglePrefab);
				if (!(null == gameObject))
				{
					Utility.AttachTo(gameObject, base.gameObject, false);
					gameObject.CustomActive(true);
					this.toggles[i] = gameObject.GetComponent<Toggle>();
					if (null != gameObject)
					{
						gameObject.name = this.m_toggle_names[i];
					}
					this._BinderMissionRedPoint(gameObject, (FunctionType)i);
					if (null != this.toggles[i])
					{
						Text text = Utility.FindComponent<Text>(gameObject, "CheckNormal/Text", true);
						if (null != text)
						{
							text.text = this.m_names[i];
						}
						Text text2 = Utility.FindComponent<Text>(gameObject, "CheckMark/Text", true);
						if (null != text2)
						{
							text2.text = this.m_names[i];
						}
						Image image = Utility.FindComponent<Image>(gameObject, "CheckNormal/Icon", true);
						if (image != null)
						{
							ETCImageLoader.LoadSprite(ref image, this.m_iconPath[i], true);
						}
						Image image2 = Utility.FindComponent<Image>(gameObject, "CheckMark/CheckIcon", true);
						if (image2 != null)
						{
							ETCImageLoader.LoadSprite(ref image2, this.m_iconPath[i], true);
						}
						FunctionType functionType = (FunctionType)i;
						if (functionType != FunctionType.FT_MISSION)
						{
							if (functionType == FunctionType.FT_TEAM)
							{
								this.toggles[i].onValueChanged.RemoveListener(new UnityAction<bool>(this._OnTeam));
								this.toggles[i].onValueChanged.AddListener(new UnityAction<bool>(this._OnTeam));
							}
						}
						else
						{
							this.toggles[i].onValueChanged.RemoveListener(new UnityAction<bool>(this._OnMission));
							this.toggles[i].onValueChanged.AddListener(new UnityAction<bool>(this._OnMission));
						}
					}
				}
			}
			this.goTogglePrefab.CustomActive(false);
		}

		// Token: 0x0600EF92 RID: 61330 RVA: 0x00407018 File Offset: 0x00405418
		private void _RegisterEvent()
		{
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onAddNewMission = (MissionManager.DelegateAddNewMission)Delegate.Combine(instance.onAddNewMission, new MissionManager.DelegateAddNewMission(this.OnAddNewMission));
			MissionManager instance2 = DataManager<MissionManager>.GetInstance();
			instance2.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Combine(instance2.onUpdateMission, new MissionManager.DelegateUpdateMission(this.OnUpdateMission));
			MissionManager instance3 = DataManager<MissionManager>.GetInstance();
			instance3.onDeleteMission = (MissionManager.DelegateDeleteMission)Delegate.Combine(instance3.onDeleteMission, new MissionManager.DelegateDeleteMission(this.OnDeleteMission));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this._UpdateMission));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.FunctionFrameUpdate, new ClientEventSystem.UIEventHandler(this._UpdateMission));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TeamCreateSuccess, new ClientEventSystem.UIEventHandler(this._OnCreateTeamSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OutPkWaitingScene, new ClientEventSystem.UIEventHandler(this._OnSwitchToMission));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SwitchToMission, new ClientEventSystem.UIEventHandler(this._OnSwitchToMission));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TeamJoinSuccess, new ClientEventSystem.UIEventHandler(this._OnJoinTeamSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TeamRemoveMemberSuccess, new ClientEventSystem.UIEventHandler(this._OnRemoveMemberSuccess));
		}

		// Token: 0x0600EF93 RID: 61331 RVA: 0x00407154 File Offset: 0x00405554
		private void _UnRegisterEvent()
		{
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onAddNewMission = (MissionManager.DelegateAddNewMission)Delegate.Remove(instance.onAddNewMission, new MissionManager.DelegateAddNewMission(this.OnAddNewMission));
			MissionManager instance2 = DataManager<MissionManager>.GetInstance();
			instance2.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Remove(instance2.onUpdateMission, new MissionManager.DelegateUpdateMission(this.OnUpdateMission));
			MissionManager instance3 = DataManager<MissionManager>.GetInstance();
			instance3.onDeleteMission = (MissionManager.DelegateDeleteMission)Delegate.Remove(instance3.onDeleteMission, new MissionManager.DelegateDeleteMission(this.OnDeleteMission));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this._UpdateMission));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.FunctionFrameUpdate, new ClientEventSystem.UIEventHandler(this._UpdateMission));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TeamCreateSuccess, new ClientEventSystem.UIEventHandler(this._OnCreateTeamSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OutPkWaitingScene, new ClientEventSystem.UIEventHandler(this._OnSwitchToMission));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SwitchToMission, new ClientEventSystem.UIEventHandler(this._OnSwitchToMission));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TeamJoinSuccess, new ClientEventSystem.UIEventHandler(this._OnJoinTeamSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TeamRemoveMemberSuccess, new ClientEventSystem.UIEventHandler(this._OnRemoveMemberSuccess));
		}

		// Token: 0x0600EF94 RID: 61332 RVA: 0x0040728D File Offset: 0x0040568D
		public void Initialize()
		{
			this._InitToggles();
			this.m_bFromEvent = true;
			this._SetToggle(FunctionType.FT_MISSION);
			this.m_bFromEvent = false;
			this._RegisterEvent();
			this.m_bDirty = false;
			this._UpdateMission();
		}

		// Token: 0x0600EF95 RID: 61333 RVA: 0x004072BD File Offset: 0x004056BD
		private void _UpdateMission(UIEvent uiEvent)
		{
			this._UpdateMission();
		}

		// Token: 0x0600EF96 RID: 61334 RVA: 0x004072C5 File Offset: 0x004056C5
		private void OnAddNewMission(uint iTaskID)
		{
			this._UpdateMission();
		}

		// Token: 0x0600EF97 RID: 61335 RVA: 0x004072CD File Offset: 0x004056CD
		private void OnUpdateMission(uint iTaskID)
		{
			this._UpdateMission();
		}

		// Token: 0x0600EF98 RID: 61336 RVA: 0x004072D5 File Offset: 0x004056D5
		private void OnDeleteMission(uint iTaskID)
		{
			this._UpdateMission();
		}

		// Token: 0x0600EF99 RID: 61337 RVA: 0x004072DD File Offset: 0x004056DD
		private void _OnCreateTeamSuccess(UIEvent uiEvent)
		{
			this.m_bFromEvent = true;
			this._SetToggle(FunctionType.FT_TEAM);
			this.m_bFromEvent = false;
		}

		// Token: 0x0600EF9A RID: 61338 RVA: 0x004072F4 File Offset: 0x004056F4
		private void _OnSwitchToMission(UIEvent uiEvent)
		{
			this.m_bFromEvent = true;
			this._SetToggle(FunctionType.FT_MISSION);
			this.m_bFromEvent = false;
		}

		// Token: 0x0600EF9B RID: 61339 RVA: 0x0040730B File Offset: 0x0040570B
		private void _OnJoinTeamSuccess(UIEvent ievent)
		{
			this.m_bFromEvent = true;
			this._SetToggle(FunctionType.FT_TEAM);
			this.m_bFromEvent = false;
		}

		// Token: 0x0600EF9C RID: 61340 RVA: 0x00407322 File Offset: 0x00405722
		private void _OnRemoveMemberSuccess(UIEvent ievent)
		{
			this.m_bFromEvent = true;
			this._SetToggle(FunctionType.FT_TEAM);
			this.m_bFromEvent = false;
		}

		// Token: 0x0600EF9D RID: 61341 RVA: 0x0040733C File Offset: 0x0040573C
		public void UnInitialize()
		{
			this.goTogglePrefab = null;
			for (int i = 0; i < this.toggles.Length; i++)
			{
				Toggle toggle = this.toggles[i];
				if (null != toggle)
				{
					FunctionType functionType = (FunctionType)i;
					if (functionType != FunctionType.FT_MISSION)
					{
						if (functionType == FunctionType.FT_TEAM)
						{
							toggle.onValueChanged.RemoveListener(new UnityAction<bool>(this._OnTeam));
						}
					}
					else
					{
						toggle.onValueChanged.RemoveListener(new UnityAction<bool>(this._OnMission));
					}
				}
				this.toggles[i] = null;
			}
			this.m_eFunctionType = FunctionType.FT_COUNT;
			this.goFunctionRoot = null;
			this.goMission = null;
			if (null != this.comListScript)
			{
				this.comListScript.onBindItem = null;
				this.comListScript.onItemVisiable = null;
				this.comListScript.onItemSelected = null;
				this.comListScript = null;
			}
			this._UnRegisterEvent();
		}

		// Token: 0x0600EF9E RID: 61342 RVA: 0x0040742C File Offset: 0x0040582C
		private void _SetToggle(FunctionType eFunctionType)
		{
			this.m_eFunctionType = eFunctionType;
			if (eFunctionType != FunctionType.FT_MISSION)
			{
				if (eFunctionType == FunctionType.FT_TEAM)
				{
					Toggle toggle = this.toggles[1];
					if (null != toggle)
					{
						toggle.onValueChanged.RemoveListener(new UnityAction<bool>(this._OnTeam));
						toggle.isOn = true;
						toggle.onValueChanged.AddListener(new UnityAction<bool>(this._OnTeam));
					}
					this._OnTeam(true);
				}
			}
			else
			{
				Toggle toggle2 = this.toggles[0];
				if (null != toggle2)
				{
					toggle2.onValueChanged.RemoveListener(new UnityAction<bool>(this._OnMission));
					toggle2.isOn = true;
					toggle2.onValueChanged.AddListener(new UnityAction<bool>(this._OnMission));
				}
				this._OnMission(true);
			}
		}

		// Token: 0x0600EF9F RID: 61343 RVA: 0x00407500 File Offset: 0x00405900
		private void _OnMission(bool bValue)
		{
			if (bValue)
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamMainMenuFrame>(null, false);
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamMainFrame>(null, false);
				TeamUtility.OnMissionTraceSelectTeam(false);
				if (this.m_eFunctionType == FunctionType.FT_MISSION)
				{
					if (!this.m_bFromEvent)
					{
						MissionFrameNewData missionFrameNewData = new MissionFrameNewData();
						missionFrameNewData.iFirstFilter = 0;
						Singleton<ClientSystemManager>.GetInstance().OpenFrame<MissionFrameNew>(FrameLayer.Middle, missionFrameNewData, string.Empty);
						Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("Mission");
					}
				}
				else
				{
					this.m_eFunctionType = FunctionType.FT_MISSION;
				}
				if (null == this.comListScript)
				{
					this.goMission = (Singleton<AssetLoader>.instance.LoadRes(this.m_mission_prefab_path, typeof(GameObject), true, 0U).obj as GameObject);
					if (null != this.goMission)
					{
						Utility.AttachTo(this.goMission, this.goFunctionRoot, false);
						this.comListScript = Utility.FindComponent<ComUIListScript>(this.goMission, "ScrollView", true);
					}
					if (null != this.comListScript)
					{
						this.comListScript.Initialize();
						this.comListScript.onBindItem = delegate(GameObject go)
						{
							if (null != go)
							{
								return go.GetComponent<ComFunctionItem>();
							}
							return null;
						};
						this.comListScript.onItemVisiable = delegate(ComUIListElementScript item)
						{
							int[] traceList = DataManager<MissionManager>.GetInstance().TraceList;
							if (null != item && item.m_index >= 0 && item.m_index < DataManager<MissionManager>.GetInstance().ListCnt)
							{
								ComFunctionItem comFunctionItem = item.gameObjectBindScript as ComFunctionItem;
								if (null != comFunctionItem)
								{
									comFunctionItem.OnItemVisible(traceList[item.m_index]);
								}
							}
						};
					}
				}
			}
			if (null != this.goMission)
			{
				this.goMission.CustomActive(bValue);
			}
		}

		// Token: 0x0600EFA0 RID: 61344 RVA: 0x00407681 File Offset: 0x00405A81
		private void _OnConfirmToUpdate()
		{
			if (null != this.comListScript)
			{
				DataManager<MissionManager>.GetInstance().GetTraceTaskList();
				this.comListScript.SetElementAmount(DataManager<MissionManager>.GetInstance().ListCnt);
			}
			this.m_bDirty = false;
		}

		// Token: 0x0600EFA1 RID: 61345 RVA: 0x004076BB File Offset: 0x00405ABB
		private void _UpdateMission()
		{
			if (!this.m_bDirty)
			{
				this.m_bDirty = true;
				InvokeMethod.Invoke(this, 0.33f, new UnityAction(this._OnConfirmToUpdate));
			}
		}

		// Token: 0x0600EFA2 RID: 61346 RVA: 0x004076E8 File Offset: 0x00405AE8
		private void _OnTeam(bool bValue)
		{
			if (!bValue)
			{
				return;
			}
			if (!Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Team))
			{
				FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(30, string.Empty, string.Empty);
				if (tableItem != null)
				{
					SystemNotifyManager.SystemNotify(tableItem.CommDescID, string.Empty);
				}
				this.m_bFromEvent = true;
				this._SetToggle(FunctionType.FT_MISSION);
				this.m_bFromEvent = false;
				return;
			}
			TeamUtility.OnMissionTraceSelectTeam(true);
			if (this.m_eFunctionType == FunctionType.FT_TEAM)
			{
				if (!this.m_bFromEvent && !Singleton<NewbieGuideManager>.GetInstance().IsGuidingTask(NewbieGuideTable.eNewbieGuideTask.TeamGuide))
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamListFrame>(FrameLayer.Middle, null, string.Empty);
					Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("Team");
				}
			}
			else
			{
				this.m_eFunctionType = FunctionType.FT_TEAM;
			}
		}

		// Token: 0x0600EFA3 RID: 61347 RVA: 0x004077A6 File Offset: 0x00405BA6
		private void OnDestroy()
		{
			InvokeMethod.RemoveInvokeCall(this);
		}

		// Token: 0x040092DF RID: 37599
		public GameObject goTogglePrefab;

		// Token: 0x040092E0 RID: 37600
		private bool m_bInit;

		// Token: 0x040092E1 RID: 37601
		private Toggle[] toggles = new Toggle[2];

		// Token: 0x040092E2 RID: 37602
		private FunctionType m_eFunctionType = FunctionType.FT_COUNT;

		// Token: 0x040092E3 RID: 37603
		private string[] m_names = new string[]
		{
			"任务",
			"组队"
		};

		// Token: 0x040092E4 RID: 37604
		private string[] m_toggle_names = new string[]
		{
			"mission",
			"team"
		};

		// Token: 0x040092E5 RID: 37605
		private string[] m_iconPath = new string[]
		{
			"UI/Image/Packed/p_MainUI01.png:UI_MainUI_Renwudaohang_Di_Icon_01",
			"UI/Image/Packed/p_MainUI01.png:UI_MainUI_Renwudaohang_Di_Icon_02"
		};

		// Token: 0x040092E6 RID: 37606
		public GameObject goFunctionRoot;

		// Token: 0x040092E7 RID: 37607
		private string m_mission_prefab_path = "UIFlatten/Prefabs/FunctionFrame/FunctionFrame";

		// Token: 0x040092E8 RID: 37608
		private GameObject goMission;

		// Token: 0x040092E9 RID: 37609
		private ComUIListScript comListScript;

		// Token: 0x040092EA RID: 37610
		private bool m_bFromEvent;

		// Token: 0x040092EB RID: 37611
		public ComMissionRedBinder comRedBinder;

		// Token: 0x040092EC RID: 37612
		private bool m_bDirty;
	}
}
