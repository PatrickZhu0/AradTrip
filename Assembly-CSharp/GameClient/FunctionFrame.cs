using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02004605 RID: 17925
	public class FunctionFrame : ClientFrame
	{
		// Token: 0x06019311 RID: 103185 RVA: 0x007F7E43 File Offset: 0x007F6243
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/FunctionFrame/FunctionFrame";
		}

		// Token: 0x06019312 RID: 103186 RVA: 0x007F7E4C File Offset: 0x007F624C
		protected override void _OnCloseFrame()
		{
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onAddNewMission = (MissionManager.DelegateAddNewMission)Delegate.Remove(instance.onAddNewMission, new MissionManager.DelegateAddNewMission(this.OnAddNewMission));
			MissionManager instance2 = DataManager<MissionManager>.GetInstance();
			instance2.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Remove(instance2.onUpdateMission, new MissionManager.DelegateUpdateMission(this.OnUpdateMission));
			MissionManager instance3 = DataManager<MissionManager>.GetInstance();
			instance3.onDeleteMission = (MissionManager.DelegateDeleteMission)Delegate.Remove(instance3.onDeleteMission, new MissionManager.DelegateDeleteMission(this.OnDeleteMission));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this.FrameUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.FunctionFrameUpdate, new ClientEventSystem.UIEventHandler(this.FrameUpdate));
			this.m_akMissionTraceObjects.DestroyAllObjects();
			this.scrollRect.onValueChanged.RemoveAllListeners();
			this.scrollRect = null;
		}

		// Token: 0x06019313 RID: 103187 RVA: 0x007F7F20 File Offset: 0x007F6320
		protected override void _OnOpenFrame()
		{
			this.eFunctionItemType = FunctionFrame.FunctionItemType.FIT_MISSION;
			this.m_goMissionParent = Utility.FindChild(this.frame, "ScrollView/ViewPort/Content");
			this.m_goMissionPrefab = Utility.FindChild(this.frame, "ScrollView/ViewPort/Content/Prefab");
			this.m_goMissionPrefab.CustomActive(false);
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onAddNewMission = (MissionManager.DelegateAddNewMission)Delegate.Combine(instance.onAddNewMission, new MissionManager.DelegateAddNewMission(this.OnAddNewMission));
			MissionManager instance2 = DataManager<MissionManager>.GetInstance();
			instance2.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Combine(instance2.onUpdateMission, new MissionManager.DelegateUpdateMission(this.OnUpdateMission));
			MissionManager instance3 = DataManager<MissionManager>.GetInstance();
			instance3.onDeleteMission = (MissionManager.DelegateDeleteMission)Delegate.Combine(instance3.onDeleteMission, new MissionManager.DelegateDeleteMission(this.OnDeleteMission));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this.FrameUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.FunctionFrameUpdate, new ClientEventSystem.UIEventHandler(this.FrameUpdate));
			this.scrollRect = Utility.FindComponent<ScrollRect>(this.frame, "ScrollView", true);
			this.scrollRect.onValueChanged.RemoveAllListeners();
			this.scrollRect.onValueChanged.AddListener(new UnityAction<Vector2>(this._OnValueChanged));
			this._SetFunction();
		}

		// Token: 0x06019314 RID: 103188 RVA: 0x007F805A File Offset: 0x007F645A
		private void _OnValueChanged(Vector2 value)
		{
			if (this.m_akMissionTraceObjects.ActiveObjects.Count > 2)
			{
				if (value.y <= 0f)
				{
				}
			}
		}

		// Token: 0x06019315 RID: 103189 RVA: 0x007F808D File Offset: 0x007F648D
		private void FrameUpdate(UIEvent uiEvent)
		{
			this._SetFunction();
		}

		// Token: 0x06019316 RID: 103190 RVA: 0x007F8098 File Offset: 0x007F6498
		public bool IsNormalMission(uint iMissionID)
		{
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)iMissionID, string.Empty, string.Empty);
			return tableItem != null && (tableItem.TaskType == MissionTable.eTaskType.TT_BRANCH || tableItem.TaskType == MissionTable.eTaskType.TT_MAIN || tableItem.TaskType == MissionTable.eTaskType.TT_CYCLE || tableItem.TaskType == MissionTable.eTaskType.TT_CHANGEJOB || tableItem.TaskType == MissionTable.eTaskType.TT_TITLE || tableItem.TaskType == MissionTable.eTaskType.TT_AWAKEN);
		}

		// Token: 0x06019317 RID: 103191 RVA: 0x007F8110 File Offset: 0x007F6510
		private void OnAddNewMission(uint iTaskID)
		{
			if (this.IsNormalMission(iTaskID))
			{
				this._SetFunction();
			}
		}

		// Token: 0x06019318 RID: 103192 RVA: 0x007F8124 File Offset: 0x007F6524
		private void OnUpdateMission(uint iTaskID)
		{
			if (this.IsNormalMission(iTaskID))
			{
				this._SetFunction();
			}
		}

		// Token: 0x06019319 RID: 103193 RVA: 0x007F8138 File Offset: 0x007F6538
		private void OnDeleteMission(uint iTaskID)
		{
			if (this.IsNormalMission(iTaskID))
			{
				this._SetFunction();
			}
		}

		// Token: 0x0601931A RID: 103194 RVA: 0x007F814C File Offset: 0x007F654C
		private void _SetSelectedButton()
		{
		}

		// Token: 0x0601931B RID: 103195 RVA: 0x007F814E File Offset: 0x007F654E
		private void OnClickLink(int iTaskID)
		{
			if (Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemTown)
			{
				DataManager<MissionManager>.GetInstance().AutoTraceTask(iTaskID, null, null, false);
			}
		}

		// Token: 0x0601931C RID: 103196 RVA: 0x007F8174 File Offset: 0x007F6574
		private void _SetFunction()
		{
			this.m_akMissionTraceObjects.RecycleAllObject();
			int[] traceTaskList = DataManager<MissionManager>.GetInstance().GetTraceTaskList();
			if (DataManager<MissionManager>.GetInstance().ListCnt > 0)
			{
				for (int i = 0; i < DataManager<MissionManager>.GetInstance().ListCnt; i++)
				{
					int num = traceTaskList[i];
					FunctionFrame.MissionTraceObject missionTraceObject = this.m_akMissionTraceObjects.Create(new object[]
					{
						this.m_goMissionParent,
						this.m_goMissionPrefab,
						num,
						this
					});
					if (missionTraceObject != null)
					{
						if (num != 0 && num != 1 && num != 2)
						{
							missionTraceObject.SetAsLastSibling();
						}
						else
						{
							missionTraceObject.SetAsFirstSibling();
						}
					}
				}
			}
			this._OnValueChanged(this.scrollRect.normalizedPosition);
			ClientSystemTown targetSystem = ClientSystem.GetTargetSystem<ClientSystemTown>();
			if (targetSystem != null && targetSystem.MainPlayer != null && DataManager<MissionManager>.GetInstance().ListCnt > 0)
			{
				targetSystem.MainPlayer.CreateMissionLink((uint)traceTaskList[0]);
			}
		}

		// Token: 0x040120C6 RID: 73926
		private FunctionFrame.FunctionItemType eFunctionItemType;

		// Token: 0x040120C7 RID: 73927
		private ScrollRect scrollRect;

		// Token: 0x040120C8 RID: 73928
		private GameObject goArrowDown;

		// Token: 0x040120C9 RID: 73929
		private GameObject goArrowUp;

		// Token: 0x040120CA RID: 73930
		private GameObject m_goMissionParent;

		// Token: 0x040120CB RID: 73931
		private GameObject m_goMissionPrefab;

		// Token: 0x040120CC RID: 73932
		private CachedObjectListManager<FunctionFrame.MissionTraceObject> m_akMissionTraceObjects = new CachedObjectListManager<FunctionFrame.MissionTraceObject>();

		// Token: 0x02004606 RID: 17926
		public enum FunctionItemType
		{
			// Token: 0x040120CE RID: 73934
			FIT_MISSION,
			// Token: 0x040120CF RID: 73935
			FIT_TEAM,
			// Token: 0x040120D0 RID: 73936
			FIT_COUNT
		}

		// Token: 0x02004607 RID: 17927
		private class MissionTraceObject : CachedObject
		{
			// Token: 0x0601931E RID: 103198 RVA: 0x007F8274 File Offset: 0x007F6674
			public override void OnCreate(object[] param)
			{
				this.goParent = (param[0] as GameObject);
				this.goPrefab = (param[1] as GameObject);
				this.iId = (int)param[2];
				this.THIS = (param[3] as FunctionFrame);
				if (this.goLocal == null)
				{
					this.goLocal = Object.Instantiate<GameObject>(this.goPrefab);
					Utility.AttachTo(this.goLocal, this.goParent, false);
					this.content = Utility.FindComponent<LinkParse>(this.goLocal, "ScrollView/ViewPort/Content", true);
					this.name = Utility.FindComponent<Text>(this.goLocal, "Tittle", true);
					this.jumpHint = Utility.FindComponent<Text>(this.goLocal, "JumpHint", true);
					this.goJumpLink = Utility.FindChild(this.goLocal, "JumpLink");
					this.link = this.goLocal.GetComponent<Button>();
					this.goAwake = Utility.FindChild(this.goLocal, "Awake");
					this.comEffect = this.goLocal.GetComponent<ComEffect>();
					this.comAward = this.THIS.CreateComItem(Utility.FindChild(this.goLocal, "ItemParent"));
					this.comAward.transform.SetAsFirstSibling();
					this.onClickAward = Utility.FindComponent<Button>(this.goLocal, "ItemParent/OnClick", true);
					this.onClickAward.onClick.RemoveAllListeners();
					this.onClickAward.onClick.AddListener(delegate()
					{
						if (null != this.comAward && this.comAward.gameObject.activeSelf)
						{
							DataManager<ItemTipManager>.GetInstance().ShowTip(this.comAward.ItemData, null, 4, true, false, true);
						}
					});
				}
				UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.CurGuideStart, new ClientEventSystem.UIEventHandler(this.OnNewbieGuideStart));
				UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.CurGuideFinish, new ClientEventSystem.UIEventHandler(this.OnNewbieGuideFinish));
				this.goLocal.name = FunctionFrame.MissionTraceObject.ms_created;
				this.Enable();
				this._Update();
			}

			// Token: 0x170020B1 RID: 8369
			// (get) Token: 0x0601931F RID: 103199 RVA: 0x007F8446 File Offset: 0x007F6846
			public bool IsTaskGuiding
			{
				get
				{
					return Singleton<NewbieGuideManager>.GetInstance().IsGuidingControl();
				}
			}

			// Token: 0x06019320 RID: 103200 RVA: 0x007F8452 File Offset: 0x007F6852
			private void OnNewbieGuideStart(UIEvent uiEvent)
			{
				this._Update();
			}

			// Token: 0x06019321 RID: 103201 RVA: 0x007F845A File Offset: 0x007F685A
			private void OnNewbieGuideFinish(UIEvent uiEvent)
			{
				this._Update();
			}

			// Token: 0x06019322 RID: 103202 RVA: 0x007F8464 File Offset: 0x007F6864
			public override void OnRecycle()
			{
				UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.CurGuideStart, new ClientEventSystem.UIEventHandler(this.OnNewbieGuideStart));
				UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.CurGuideFinish, new ClientEventSystem.UIEventHandler(this.OnNewbieGuideFinish));
				if (this.goLocal != null)
				{
					this.comEffect.Stop("mainEffect");
					this.comEffect.Stop("attachEffect");
					this.goLocal.CustomActive(false);
				}
				this.goLocal.name = FunctionFrame.MissionTraceObject.ms_empty;
			}

			// Token: 0x06019323 RID: 103203 RVA: 0x007F84F4 File Offset: 0x007F68F4
			public override void OnDecycle(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x06019324 RID: 103204 RVA: 0x007F8500 File Offset: 0x007F6900
			public override void OnDestroy()
			{
				UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.CurGuideStart, new ClientEventSystem.UIEventHandler(this.OnNewbieGuideStart));
				UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.CurGuideFinish, new ClientEventSystem.UIEventHandler(this.OnNewbieGuideFinish));
				if (null != this.onClickAward)
				{
					this.onClickAward.onClick.RemoveAllListeners();
					this.onClickAward = null;
				}
				if (null != this.link)
				{
					this.link.onClick.RemoveAllListeners();
					this.link = null;
				}
			}

			// Token: 0x06019325 RID: 103205 RVA: 0x007F8593 File Offset: 0x007F6993
			public void SetAsFirstSibling()
			{
				if (this.goLocal != null)
				{
					this.goLocal.transform.SetAsFirstSibling();
				}
			}

			// Token: 0x06019326 RID: 103206 RVA: 0x007F85B6 File Offset: 0x007F69B6
			public override void SetAsLastSibling()
			{
				if (this.goLocal != null)
				{
					this.goLocal.transform.SetAsLastSibling();
				}
			}

			// Token: 0x06019327 RID: 103207 RVA: 0x007F85D9 File Offset: 0x007F69D9
			public override void OnRefresh(object[] param)
			{
				this._Update();
			}

			// Token: 0x06019328 RID: 103208 RVA: 0x007F85E1 File Offset: 0x007F69E1
			public override void Enable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(true);
				}
			}

			// Token: 0x06019329 RID: 103209 RVA: 0x007F8600 File Offset: 0x007F6A00
			public override void Disable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x0601932A RID: 103210 RVA: 0x007F861F File Offset: 0x007F6A1F
			public override bool NeedFilter(object[] param)
			{
				return false;
			}

			// Token: 0x0601932B RID: 103211 RVA: 0x007F8624 File Offset: 0x007F6A24
			private void _Update()
			{
				if (this.comAward == null)
				{
					return;
				}
				this.comEffect.Stop("mainEffect");
				this.comEffect.Stop("attachEffect");
				this.comEffect.Stop("awakeEffect");
				this.comAward.CustomActive(false);
				this.comAward.Setup(null, null);
				this.onClickAward.gameObject.CustomActive(false);
				this.goAwake.CustomActive(false);
				if (this.iId != 0 && this.iId != 1 && this.iId != 2)
				{
					this.jumpHint.CustomActive(false);
					this.goJumpLink.CustomActive(false);
					this.missionItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(this.iId, string.Empty, string.Empty);
					DataManager<MissionManager>.GetInstance().taskGroup.TryGetValue((uint)this.iId, out this.value);
					if (this.value != null)
					{
						this.name.text = DataManager<MissionManager>.GetInstance().GetMissionName((uint)this.missionItem.ID) + DataManager<MissionManager>.GetInstance().GetMissionNameAppendBystatus((int)this.value.status, this.value.missionItem.ID);
						if (this.content != null)
						{
							this.content.SetText(Utility.ParseMissionText(this.iId, true, false, false), true);
						}
						if (this.link != null)
						{
							this.link.onClick.RemoveAllListeners();
							this.link.onClick.AddListener(delegate()
							{
								this.THIS.OnClickLink(this.iId);
							});
						}
						if (this.missionItem.TaskType == MissionTable.eTaskType.TT_MAIN)
						{
							this.comEffect.Play("mainEffect");
							if (this.missionItem.MinPlayerLv <= 10 && !this.IsTaskGuiding)
							{
								this.comEffect.Play("attachEffect");
							}
						}
						if (this.value.missionItem.TaskType == MissionTable.eTaskType.TT_TITLE)
						{
							int finalTitleMission = DataManager<MissionManager>.GetInstance().GetFinalTitleMission(this.value.missionItem.ID);
							List<AwardItemData> missionAwards = DataManager<MissionManager>.GetInstance().GetMissionAwards(finalTitleMission, DataManager<PlayerBaseData>.GetInstance().JobTableID);
							if (missionAwards != null && missionAwards.Count > 0)
							{
								AwardItemData awardItemData = missionAwards[missionAwards.Count - 1];
								ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(awardItemData.ID);
								if (commonItemTableDataByID != null)
								{
									this.comAward.Setup(commonItemTableDataByID, null);
									this.comAward.CustomActive(true);
									this.onClickAward.gameObject.CustomActive(true);
								}
							}
						}
						if (this.value.missionItem.TaskType == MissionTable.eTaskType.TT_AWAKEN)
						{
							this.comEffect.Play("awakeEffect");
							this.goAwake.CustomActive(true);
						}
					}
				}
				else
				{
					this.missionItem = null;
					this.value = null;
					if (this.iId == 1)
					{
						this.jumpHint.CustomActive(false);
						this.goJumpLink.CustomActive(false);
						this.name.text = TR.Value("mission_has_no_mission");
						this.content.SetText(TR.Value("mission_finish_all"), false);
						if (this.link != null)
						{
							this.link.onClick.RemoveAllListeners();
						}
						return;
					}
					if (this.iId == 2)
					{
						this.jumpHint.CustomActive(false);
						this.goJumpLink.CustomActive(false);
						this.name.text = TR.Value("mission_has_no_main");
						this.content.SetText(TR.Value("mission_finish_all_main"), false);
						if (this.link != null)
						{
							this.link.onClick.RemoveAllListeners();
						}
						return;
					}
					MissionTable nextMissionItem = DataManager<MissionManager>.GetInstance().GetNextMissionItem((int)DataManager<PlayerBaseData>.GetInstance().Level);
					if (nextMissionItem == null)
					{
						this.jumpHint.CustomActive(false);
						this.goJumpLink.CustomActive(false);
						this.name.text = TR.Value("mission_has_no_main");
						this.content.SetText(TR.Value("mission_finish_all_main"), false);
						if (this.link != null)
						{
							this.link.onClick.RemoveAllListeners();
						}
					}
					else
					{
						this.jumpHint.CustomActive(true);
						this.goJumpLink.CustomActive(true);
						this.name.text = DataManager<MissionManager>.GetInstance().GetMissionName((uint)nextMissionItem.ID);
						int nextLevelMission = DataManager<MissionManager>.GetInstance().GetNextLevelMission((int)DataManager<PlayerBaseData>.GetInstance().Level);
						this.content.SetText(string.Empty, false);
						this.jumpHint.text = string.Format(TR.Value("mission_need_lv"), nextLevelMission);
						if (this.link != null)
						{
							this.link.onClick.RemoveAllListeners();
							this.link.onClick.AddListener(delegate()
							{
								DataManager<ActiveManager>.GetInstance().OnClickLinkInfo("<type=framename param=1 value=GameClient.DevelopGuidanceMainFrame>", null, false);
							});
						}
					}
				}
			}

			// Token: 0x040120D1 RID: 73937
			private static string ms_empty = "empty";

			// Token: 0x040120D2 RID: 73938
			private static string ms_created = "alive";

			// Token: 0x040120D3 RID: 73939
			private GameObject goLocal;

			// Token: 0x040120D4 RID: 73940
			private GameObject goPrefab;

			// Token: 0x040120D5 RID: 73941
			private GameObject goParent;

			// Token: 0x040120D6 RID: 73942
			private int iId;

			// Token: 0x040120D7 RID: 73943
			private FunctionFrame THIS;

			// Token: 0x040120D8 RID: 73944
			private LinkParse content;

			// Token: 0x040120D9 RID: 73945
			private Text name;

			// Token: 0x040120DA RID: 73946
			private Button link;

			// Token: 0x040120DB RID: 73947
			private Text jumpHint;

			// Token: 0x040120DC RID: 73948
			private GameObject goJumpLink;

			// Token: 0x040120DD RID: 73949
			private MissionManager.SingleMissionInfo value;

			// Token: 0x040120DE RID: 73950
			private MissionTable missionItem;

			// Token: 0x040120DF RID: 73951
			private ComEffect comEffect;

			// Token: 0x040120E0 RID: 73952
			private ComItem comAward;

			// Token: 0x040120E1 RID: 73953
			private Button onClickAward;

			// Token: 0x040120E2 RID: 73954
			private GameObject goAwake;
		}
	}
}
