using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001768 RID: 5992
	internal class TraceFrame
	{
		// Token: 0x0600EC9A RID: 60570 RVA: 0x003F2464 File Offset: 0x003F0864
		public void InitTraceFrame(ClientSystemTownFrame clientFrame, GameObject root)
		{
			this.mLastSelectFrameType = TraceFrame.TraceFrameType.TFT_NONE;
			this.clientFrame = clientFrame;
			this.root = root;
			GameObject gameObject = Utility.FindChild(root, "toggle");
			gameObject.CustomActive(false);
			string[] array = new string[]
			{
				TR.Value("traceframe_mission"),
				TR.Value("traceframe_team")
			};
			for (int i = 0; i < this.m_akToggles.Length; i++)
			{
				GameObject gameObject2 = Object.Instantiate<GameObject>(gameObject);
				if (i == 0)
				{
					gameObject2.name = "mission";
				}
				else if (i == 1)
				{
					gameObject2.name = "team";
				}
				Utility.AttachTo(gameObject2, root, false);
				gameObject2.CustomActive(true);
				this.m_akCheckNormals[i] = Utility.FindChild(gameObject2, "CheckNormal");
				this.m_akCheckMarks[i] = Utility.FindChild(gameObject2, "CheckMark");
				TraceFrame.TraceFrameType eTraceFrameType = (TraceFrame.TraceFrameType)i;
				this.m_akToggles[i] = gameObject2.GetComponent<Toggle>();
				this.m_akToggles[i].onValueChanged.AddListener(delegate(bool bValue)
				{
					this._OnToggleChanged(bValue, eTraceFrameType);
				});
				Text text = Utility.FindComponent<Text>(gameObject2, "CheckNormal/Text", true);
				text.text = array[i];
				text = Utility.FindComponent<Text>(gameObject2, "CheckMark/Text", true);
				text.text = array[i];
			}
			this.m_akToggles[0].isOn = true;
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TeamCreateSuccess, new ClientEventSystem.UIEventHandler(this._OnCreateTeamSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OutPkWaitingScene, new ClientEventSystem.UIEventHandler(this._OnSwitchToMission));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SwitchToMission, new ClientEventSystem.UIEventHandler(this._OnSwitchToMission));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TeamJoinSuccess, new ClientEventSystem.UIEventHandler(this._OnJoinTeamSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TeamRemoveMemberSuccess, new ClientEventSystem.UIEventHandler(this._OnRemoveMemberSuccess));
		}

		// Token: 0x0600EC9B RID: 60571 RVA: 0x003F2648 File Offset: 0x003F0A48
		public void UnInitTraceFrame()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TeamCreateSuccess, new ClientEventSystem.UIEventHandler(this._OnCreateTeamSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OutPkWaitingScene, new ClientEventSystem.UIEventHandler(this._OnSwitchToMission));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SwitchToMission, new ClientEventSystem.UIEventHandler(this._OnSwitchToMission));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TeamJoinSuccess, new ClientEventSystem.UIEventHandler(this._OnJoinTeamSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TeamRemoveMemberSuccess, new ClientEventSystem.UIEventHandler(this._OnRemoveMemberSuccess));
			for (int i = 0; i < this.m_akToggles.Length; i++)
			{
				this.m_akToggles[i].onValueChanged.RemoveAllListeners();
				this.m_akToggles[i] = null;
				this.m_akCheckNormals[i] = null;
				this.m_akCheckMarks[i] = null;
			}
			this.root = null;
			this.clientFrame = null;
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamMainMenuFrame>(null, false);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamMainFrame>(null, false);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<FunctionFrame>(null, false);
		}

		// Token: 0x0600EC9C RID: 60572 RVA: 0x003F2754 File Offset: 0x003F0B54
		private void _OnCreateTeamSuccess(UIEvent uiEvent)
		{
			this._SwitchPage(1);
		}

		// Token: 0x0600EC9D RID: 60573 RVA: 0x003F275D File Offset: 0x003F0B5D
		private void _OnSwitchToMission(UIEvent uiEvent)
		{
			this._SwitchPage(0);
		}

		// Token: 0x0600EC9E RID: 60574 RVA: 0x003F2766 File Offset: 0x003F0B66
		private void _OnJoinTeamSuccess(UIEvent ievent)
		{
			this._SwitchPage(1);
		}

		// Token: 0x0600EC9F RID: 60575 RVA: 0x003F276F File Offset: 0x003F0B6F
		private void _OnRemoveMemberSuccess(UIEvent ievent)
		{
			this._SwitchPage(1);
		}

		// Token: 0x0600ECA0 RID: 60576 RVA: 0x003F2778 File Offset: 0x003F0B78
		private void _SwitchPage(int iIndex)
		{
			for (int i = 0; i < this.m_akToggles.Length; i++)
			{
				if (i == iIndex)
				{
					this.mOpenByMessage = true;
					this.m_akToggles[i].isOn = false;
					this.m_akToggles[i].isOn = true;
					this.mOpenByMessage = false;
					break;
				}
			}
		}

		// Token: 0x0600ECA1 RID: 60577 RVA: 0x003F27D4 File Offset: 0x003F0BD4
		private void _OnToggleChanged(bool bValue, TraceFrame.TraceFrameType eTraceFrameType)
		{
			if (bValue)
			{
				bool flag = !this.mOpenByMessage && this.mLastSelectFrameType == eTraceFrameType;
				if (eTraceFrameType == TraceFrame.TraceFrameType.TFT_MISSION)
				{
					this._OnMissionTrace(flag);
				}
				else if (eTraceFrameType == TraceFrame.TraceFrameType.TFT_TEAM)
				{
					this._OnTeam(flag && !Singleton<NewbieGuideManager>.GetInstance().IsGuidingTask(NewbieGuideTable.eNewbieGuideTask.TeamGuide));
				}
				this.mLastSelectFrameType = eTraceFrameType;
			}
			this.m_akCheckMarks[(int)eTraceFrameType].CustomActive(bValue);
			this.m_akCheckNormals[(int)eTraceFrameType].CustomActive(!bValue);
		}

		// Token: 0x0600ECA2 RID: 60578 RVA: 0x003F285C File Offset: 0x003F0C5C
		private void _OnMissionTrace(bool openMissionFrame)
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamMainMenuFrame>(null, false);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamMainFrame>(null, false);
			if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<FunctionFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<FunctionFrame>(FrameLayer.Bottom, null, string.Empty);
			}
			TeamUtility.OnMissionTraceSelectTeam(false);
			if (openMissionFrame)
			{
				MissionFrameNewData userData = new MissionFrameNewData
				{
					iFirstFilter = 0
				};
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<MissionFrameNew>(FrameLayer.Middle, userData, string.Empty);
			}
		}

		// Token: 0x0600ECA3 RID: 60579 RVA: 0x003F28D0 File Offset: 0x003F0CD0
		private void _OnTeam(bool openTeamListFrame)
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<FunctionFrame>(null, false);
			TeamUtility.OnMissionTraceSelectTeam(true);
			if (openTeamListFrame)
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamListFrame>(FrameLayer.Middle, null, string.Empty);
			}
		}

		// Token: 0x04008FD5 RID: 36821
		private ClientSystemTownFrame clientFrame;

		// Token: 0x04008FD6 RID: 36822
		private GameObject root;

		// Token: 0x04008FD7 RID: 36823
		private Toggle[] m_akToggles = new Toggle[2];

		// Token: 0x04008FD8 RID: 36824
		private GameObject[] m_akCheckNormals = new GameObject[2];

		// Token: 0x04008FD9 RID: 36825
		private GameObject[] m_akCheckMarks = new GameObject[2];

		// Token: 0x04008FDA RID: 36826
		private bool mOpenByMessage;

		// Token: 0x04008FDB RID: 36827
		private TraceFrame.TraceFrameType mLastSelectFrameType = TraceFrame.TraceFrameType.TFT_NONE;

		// Token: 0x02001769 RID: 5993
		private enum TraceFrameType
		{
			// Token: 0x04008FDD RID: 36829
			TFT_NONE = -1,
			// Token: 0x04008FDE RID: 36830
			TFT_MISSION,
			// Token: 0x04008FDF RID: 36831
			TFT_TEAM,
			// Token: 0x04008FE0 RID: 36832
			TFT_COUNT
		}
	}
}
