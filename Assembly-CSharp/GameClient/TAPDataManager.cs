using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02001300 RID: 4864
	internal class TAPDataManager : DataManager<TAPDataManager>
	{
		// Token: 0x0600BCAE RID: 48302 RVA: 0x002C161C File Offset: 0x002BFA1C
		public override void Initialize()
		{
			this.RegisterNetHandler();
			this.AddSystemInvoke();
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Combine(instance.onLevelChanged, new PlayerBaseData.OnLevelChanged(this._OnLevelChanged));
			this.onFirstCheckFlag = true;
			this.hasCheckedToday = this.IsCheckedToday();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSearchedTeacherListChanged, new ClientEventSystem.UIEventHandler(this.OnSearchedTeacherListChanged));
		}

		// Token: 0x0600BCAF RID: 48303 RVA: 0x002C168C File Offset: 0x002BFA8C
		public override void Clear()
		{
			this.UnRegisterNetHandler();
			this.m_akQueriedIds.Clear();
			this.m_akIWantApplyedPupils.Clear();
			this.RemoveSystemInvoke();
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Remove(instance.onLevelChanged, new PlayerBaseData.OnLevelChanged(this._OnLevelChanged));
			this.onFirstCheckFlag = true;
			this.hasCheckedToday = false;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSearchedTeacherListChanged, new ClientEventSystem.UIEventHandler(this.OnSearchedTeacherListChanged));
		}

		// Token: 0x0600BCB0 RID: 48304 RVA: 0x002C170C File Offset: 0x002BFB0C
		private void RegisterNetHandler()
		{
			this.UnRegisterNetHandler();
			NetProcess.AddMsgHandler(601721U, new Action<MsgDATA>(this._OnRecvQueryMasterSettingRes));
			NetProcess.AddMsgHandler(601719U, new Action<MsgDATA>(this._OnRecvSetRecvDiscipleStateRet));
			NetProcess.AddMsgHandler(601717U, new Action<MsgDATA>(this._OnRecvSetMasterNoteRet));
		}

		// Token: 0x0600BCB1 RID: 48305 RVA: 0x002C1764 File Offset: 0x002BFB64
		private void UnRegisterNetHandler()
		{
			NetProcess.RemoveMsgHandler(601721U, new Action<MsgDATA>(this._OnRecvQueryMasterSettingRes));
			NetProcess.RemoveMsgHandler(601719U, new Action<MsgDATA>(this._OnRecvSetRecvDiscipleStateRet));
			NetProcess.RemoveMsgHandler(601717U, new Action<MsgDATA>(this._OnRecvSetMasterNoteRet));
		}

		// Token: 0x0600BCB2 RID: 48306 RVA: 0x002C17B4 File Offset: 0x002BFBB4
		private void OnSearchedTeacherListChanged(UIEvent uiEvent)
		{
			if (this.bFlagToOpenSearchTeacherFrame && !this.bLoadingScene)
			{
				if (DataManager<RelationDataManager>.GetInstance().SearchedTeacherList.Count <= 0)
				{
					this.bFlagToOpenSearchTeacherFrame = false;
					return;
				}
				SystemNotifyManager.SystemNotifyOkCancel(7021, delegate
				{
					TAPSystemMainFrame.OpenLinkFrame(string.Format("{0}", 0));
					this.OpenSearchTeacherFrame();
				}, null, FrameLayer.High, true);
				this.bFlagToOpenSearchTeacherFrame = false;
			}
		}

		// Token: 0x0600BCB3 RID: 48307 RVA: 0x002C1814 File Offset: 0x002BFC14
		private void _OnLevelChanged(int iPreLv, int iCurLv)
		{
			if (iPreLv > 0 && iCurLv > iPreLv && ComTAPOpenControl.IsOpen() && !this.hasTeacher && !DataManager<PlayerBaseData>.GetInstance().IsLevelFull && DataManager<PlayerBaseData>.GetInstance().Level % 5 == 0)
			{
				this.bFlagToOpenSearchTeacherFrame = true;
				this._TryPopTapSearchTeacherFrame();
			}
		}

		// Token: 0x0600BCB4 RID: 48308 RVA: 0x002C1871 File Offset: 0x002BFC71
		public void AddSystemInvoke()
		{
			this.RemoveSystemInvoke();
			Singleton<ClientSystemManager>.GetInstance().OnSwitchSystemBegin.AddListener(new UnityAction(this.OnSceneLoadBegin));
			Singleton<ClientSystemManager>.GetInstance().OnSwitchSystemFinished.AddListener(new UnityAction(this.OnSceneLoadEnd));
		}

		// Token: 0x0600BCB5 RID: 48309 RVA: 0x002C18AF File Offset: 0x002BFCAF
		public void RemoveSystemInvoke()
		{
			Singleton<ClientSystemManager>.GetInstance().OnSwitchSystemBegin.RemoveListener(new UnityAction(this.OnSceneLoadBegin));
			Singleton<ClientSystemManager>.GetInstance().OnSwitchSystemFinished.RemoveListener(new UnityAction(this.OnSceneLoadEnd));
		}

		// Token: 0x0600BCB6 RID: 48310 RVA: 0x002C18E7 File Offset: 0x002BFCE7
		public void OnSceneLoadBegin()
		{
			this.bLoadingScene = true;
		}

		// Token: 0x0600BCB7 RID: 48311 RVA: 0x002C18F0 File Offset: 0x002BFCF0
		public void OnSceneLoadEnd()
		{
			this.bLoadingScene = false;
			this._TryPopTapSearchTeacherFrame();
		}

		// Token: 0x0600BCB8 RID: 48312 RVA: 0x002C1900 File Offset: 0x002BFD00
		private void _TryPopTapSearchTeacherFrame()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return;
			}
			if (DataManager<PlayerBaseData>.GetInstance().IsFlyUpState)
			{
				return;
			}
			CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.SceneType == CitySceneTable.eSceneType.BATTLE || tableItem.SceneType == CitySceneTable.eSceneType.BATTLEPEPARE)
			{
				return;
			}
			if (this.bLoadingScene)
			{
				return;
			}
			if (!this.bFlagToOpenSearchTeacherFrame)
			{
				return;
			}
			if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() > TAPType.Pupil)
			{
				return;
			}
			if (DataManager<PlayerBaseData>.GetInstance().Level < 10)
			{
				return;
			}
			if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() == TAPType.Pupil)
			{
				DataManager<TAPNewDataManager>.GetInstance().SendChangeSearchedPupilList(RelationFindType.Master);
			}
		}

		// Token: 0x17001B71 RID: 7025
		// (get) Token: 0x0600BCB9 RID: 48313 RVA: 0x002C19C8 File Offset: 0x002BFDC8
		public int teacherMinLevel
		{
			get
			{
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(277, string.Empty, string.Empty);
				if (tableItem != null)
				{
					return tableItem.Value;
				}
				return 99;
			}
		}

		// Token: 0x17001B72 RID: 7026
		// (get) Token: 0x0600BCBA RID: 48314 RVA: 0x002C1A00 File Offset: 0x002BFE00
		public int apprentLevelMax
		{
			get
			{
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(414, string.Empty, string.Empty);
				if (tableItem != null)
				{
					return tableItem.Value;
				}
				return 99;
			}
		}

		// Token: 0x17001B73 RID: 7027
		// (get) Token: 0x0600BCBB RID: 48315 RVA: 0x002C1A36 File Offset: 0x002BFE36
		public bool canGetpupil
		{
			get
			{
				return (int)DataManager<PlayerBaseData>.GetInstance().Level >= this.teacherMinLevel;
			}
		}

		// Token: 0x17001B74 RID: 7028
		// (get) Token: 0x0600BCBC RID: 48316 RVA: 0x002C1A50 File Offset: 0x002BFE50
		public bool hasPupil
		{
			get
			{
				List<RelationData> relation = DataManager<RelationDataManager>.GetInstance().GetRelation(5);
				return relation != null && relation.Count > 0;
			}
		}

		// Token: 0x17001B75 RID: 7029
		// (get) Token: 0x0600BCBD RID: 48317 RVA: 0x002C1A7C File Offset: 0x002BFE7C
		public bool isPupilFull
		{
			get
			{
				List<RelationData> relation = DataManager<RelationDataManager>.GetInstance().GetRelation(5);
				return relation != null && this.pupilMaxCount <= relation.Count;
			}
		}

		// Token: 0x17001B76 RID: 7030
		// (get) Token: 0x0600BCBE RID: 48318 RVA: 0x002C1AB0 File Offset: 0x002BFEB0
		public bool hasTeacher
		{
			get
			{
				List<RelationData> relation = DataManager<RelationDataManager>.GetInstance().GetRelation(4);
				return relation != null && relation.Count > 0;
			}
		}

		// Token: 0x0600BCBF RID: 48319 RVA: 0x002C1ADC File Offset: 0x002BFEDC
		public bool HasPupil(ulong uid)
		{
			List<RelationData> relation = DataManager<RelationDataManager>.GetInstance().GetRelation(5);
			if (relation != null)
			{
				RelationData relationData = relation.Find((RelationData x) => x.uid == uid);
				return null != relationData;
			}
			return false;
		}

		// Token: 0x17001B77 RID: 7031
		// (get) Token: 0x0600BCC0 RID: 48320 RVA: 0x002C1B24 File Offset: 0x002BFF24
		public int pupilMaxCount
		{
			get
			{
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(278, string.Empty, string.Empty);
				if (tableItem != null)
				{
					return tableItem.Value;
				}
				return 0;
			}
		}

		// Token: 0x0600BCC1 RID: 48321 RVA: 0x002C1B59 File Offset: 0x002BFF59
		public void OpenApplyPupilFrame()
		{
			if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() == TAPType.TeacherSoon)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("tap_cannot_enter_searchFrame"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			else
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<TAPSearchFrame>(FrameLayer.Middle, 1, string.Empty);
			}
		}

		// Token: 0x0600BCC2 RID: 48322 RVA: 0x002C1B98 File Offset: 0x002BFF98
		public void OpenSearchPupilFrame()
		{
			if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() == TAPType.TeacherSoon)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("tap_cannot_enter_searchFrame"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			else
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<TAPSearchFrame>(FrameLayer.Middle, 0, string.Empty);
			}
		}

		// Token: 0x0600BCC3 RID: 48323 RVA: 0x002C1BD7 File Offset: 0x002BFFD7
		public void OpenSearchTeacherFrame()
		{
			if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() == TAPType.TeacherSoon)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("tap_cannot_enter_searchFrame"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			else
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<TAPSearchFrame>(FrameLayer.Middle, 0, string.Empty);
			}
		}

		// Token: 0x0600BCC4 RID: 48324 RVA: 0x002C1C18 File Offset: 0x002C0018
		public void SendChangeSearchedTeacherList()
		{
			WorldRelationFindPlayersReq worldRelationFindPlayersReq = new WorldRelationFindPlayersReq();
			worldRelationFindPlayersReq.type = 3;
			worldRelationFindPlayersReq.name = string.Empty;
			MonoSingleton<NetManager>.instance.SendCommand<WorldRelationFindPlayersReq>(ServerType.GATE_SERVER, worldRelationFindPlayersReq);
		}

		// Token: 0x0600BCC5 RID: 48325 RVA: 0x002C1C4C File Offset: 0x002C004C
		public void SendChangeSearchedPupilList()
		{
			WorldRelationFindPlayersReq worldRelationFindPlayersReq = new WorldRelationFindPlayersReq();
			worldRelationFindPlayersReq.type = 4;
			worldRelationFindPlayersReq.name = string.Empty;
			MonoSingleton<NetManager>.instance.SendCommand<WorldRelationFindPlayersReq>(ServerType.GATE_SERVER, worldRelationFindPlayersReq);
		}

		// Token: 0x0600BCC6 RID: 48326 RVA: 0x002C1C80 File Offset: 0x002C0080
		public void SendQueryMasterSetting()
		{
			QueryMasterSettingReq cmd = new QueryMasterSettingReq();
			MonoSingleton<NetManager>.instance.SendCommand<QueryMasterSettingReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600BCC7 RID: 48327 RVA: 0x002C1CA0 File Offset: 0x002C00A0
		protected void _OnRecvQueryMasterSettingRes(MsgDATA msg)
		{
			QueryMasterSettingRes queryMasterSettingRes = new QueryMasterSettingRes();
			queryMasterSettingRes.decode(msg.bytes);
			DataManager<PlayerBaseData>.GetInstance().getPupil = (queryMasterSettingRes.isRecv != 0);
			DataManager<PlayerBaseData>.GetInstance().Announcement = queryMasterSettingRes.masternote;
		}

		// Token: 0x0600BCC8 RID: 48328 RVA: 0x002C1CE5 File Offset: 0x002C00E5
		public void SendApplyTeacher(ulong uid)
		{
			DataManager<RelationDataManager>.GetInstance().AddRelationByID(uid, RequestType.RequestMaster);
		}

		// Token: 0x0600BCC9 RID: 48329 RVA: 0x002C1CF3 File Offset: 0x002C00F3
		public void SendApplyPupil(ulong uid)
		{
			DataManager<RelationDataManager>.GetInstance().AddRelationByID(uid, RequestType.RequestDisciple);
		}

		// Token: 0x0600BCCA RID: 48330 RVA: 0x002C1D04 File Offset: 0x002C0104
		public bool CheckApplyPupil(bool bNeedPopMsg = false)
		{
			if (!DataManager<TAPDataManager>.GetInstance().canGetpupil)
			{
				if (bNeedPopMsg)
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("tap_self_get_pupil_need_lv", DataManager<TAPDataManager>.GetInstance().teacherMinLevel), CommonTipsDesc.eShowMode.SI_UNIQUE);
				}
				return false;
			}
			if (DataManager<TAPDataManager>.GetInstance().isPupilFull)
			{
				if (bNeedPopMsg)
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("tap_get_pupil_full", DataManager<TAPDataManager>.GetInstance().pupilMaxCount), CommonTipsDesc.eShowMode.SI_UNIQUE);
				}
				return false;
			}
			return true;
		}

		// Token: 0x0600BCCB RID: 48331 RVA: 0x002C1D7E File Offset: 0x002C017E
		public void AddQueryInfo(ulong uid)
		{
			if (!this.m_akQueriedIds.Contains(uid))
			{
				this.m_akQueriedIds.Add(uid);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnQueryTeacherChanged, uid, null, null, null);
		}

		// Token: 0x0600BCCC RID: 48332 RVA: 0x002C1DB5 File Offset: 0x002C01B5
		public void RemoveQueryInfo(ulong uid)
		{
			if (this.m_akQueriedIds.Contains(uid))
			{
				this.m_akQueriedIds.Remove(uid);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnQueryTeacherChanged, uid, null, null, null);
		}

		// Token: 0x0600BCCD RID: 48333 RVA: 0x002C1DED File Offset: 0x002C01ED
		public void ClearQueryInfo()
		{
			this.m_akQueriedIds.Clear();
		}

		// Token: 0x0600BCCE RID: 48334 RVA: 0x002C1DFA File Offset: 0x002C01FA
		public bool CanQuery(ulong uid)
		{
			return !this.m_akQueriedIds.Contains(uid);
		}

		// Token: 0x0600BCCF RID: 48335 RVA: 0x002C1E0B File Offset: 0x002C020B
		public void AddApplyedPupil(ulong uid)
		{
			if (!this.m_akIWantApplyedPupils.Contains(uid))
			{
				this.m_akIWantApplyedPupils.Add(uid);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnWanApplyedPupilChanged, uid, null, null, null);
		}

		// Token: 0x0600BCD0 RID: 48336 RVA: 0x002C1E42 File Offset: 0x002C0242
		public void RemoveApplyedPupil(ulong uid)
		{
			if (this.m_akIWantApplyedPupils.Contains(uid))
			{
				this.m_akIWantApplyedPupils.Remove(uid);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnWanApplyedPupilChanged, uid, null, null, null);
		}

		// Token: 0x0600BCD1 RID: 48337 RVA: 0x002C1E7A File Offset: 0x002C027A
		public bool CanApplyedPupil(ulong uid)
		{
			return !this.m_akIWantApplyedPupils.Contains(uid);
		}

		// Token: 0x0600BCD2 RID: 48338 RVA: 0x002C1E8B File Offset: 0x002C028B
		public void ClearApplyedPupils()
		{
			this.m_akIWantApplyedPupils.Clear();
		}

		// Token: 0x0600BCD3 RID: 48339 RVA: 0x002C1E98 File Offset: 0x002C0298
		private void _OnRecvSetRecvDiscipleStateRet(MsgDATA msg)
		{
			SetRecvDiscipleStateRet setRecvDiscipleStateRet = new SetRecvDiscipleStateRet();
			setRecvDiscipleStateRet.decode(msg.bytes);
			if (setRecvDiscipleStateRet.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)setRecvDiscipleStateRet.code, string.Empty);
			}
			else
			{
				DataManager<PlayerBaseData>.GetInstance().getPupil = (setRecvDiscipleStateRet.state != 0);
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("tap_get_pupil_modify_ok"), CommonTipsDesc.eShowMode.SI_UNIQUE);
			}
		}

		// Token: 0x0600BCD4 RID: 48340 RVA: 0x002C1F00 File Offset: 0x002C0300
		private void _OnRecvSetMasterNoteRet(MsgDATA msg)
		{
			SetMasterNoteRet setMasterNoteRet = new SetMasterNoteRet();
			setMasterNoteRet.decode(msg.bytes);
			if (setMasterNoteRet.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)setMasterNoteRet.code, string.Empty);
			}
			else
			{
				DataManager<PlayerBaseData>.GetInstance().Announcement = setMasterNoteRet.note;
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("tap_announce_modify_ok"), CommonTipsDesc.eShowMode.SI_UNIQUE);
			}
		}

		// Token: 0x0600BCD5 RID: 48341 RVA: 0x002C1F5F File Offset: 0x002C035F
		public bool CheckTapRedPointIsShow()
		{
			return this.OnFirstCheckFlag;
		}

		// Token: 0x17001B78 RID: 7032
		// (get) Token: 0x0600BCD6 RID: 48342 RVA: 0x002C1F67 File Offset: 0x002C0367
		// (set) Token: 0x0600BCD7 RID: 48343 RVA: 0x002C1F80 File Offset: 0x002C0380
		public bool OnFirstCheckFlag
		{
			get
			{
				return this.onFirstCheckFlag && !this.hasCheckedToday;
			}
			set
			{
				if (!value)
				{
					this.onFirstCheckFlag = value;
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTAPRedPointUpdate, null, null, null, null);
					if (!this.hasCheckedToday)
					{
						this.SaveCheckTimestamp();
						this.hasCheckedToday = this.IsCheckedToday();
					}
				}
			}
		}

		// Token: 0x0600BCD8 RID: 48344 RVA: 0x002C1FC0 File Offset: 0x002C03C0
		private void SaveCheckTimestamp()
		{
			int currTimeStamp = Function.GetCurrTimeStamp();
			Singleton<PlayerPrefsManager>.GetInstance().SetTypeKeyIntValue(PlayerPrefsManager.PlayerPrefsKeyType.TapRedPointCheck, currTimeStamp, new object[0]);
		}

		// Token: 0x0600BCD9 RID: 48345 RVA: 0x002C1FE8 File Offset: 0x002C03E8
		private bool IsCheckedToday()
		{
			int typeKeyIntValue = Singleton<PlayerPrefsManager>.GetInstance().GetTypeKeyIntValue(PlayerPrefsManager.PlayerPrefsKeyType.TapRedPointCheck, new object[0]);
			return typeKeyIntValue > Function.GetRefreshHourTimeStamp(this.refreshHour);
		}

		// Token: 0x04006A26 RID: 27174
		private bool bLoadingScene;

		// Token: 0x04006A27 RID: 27175
		private bool bFlagToOpenSearchTeacherFrame;

		// Token: 0x04006A28 RID: 27176
		private List<ulong> m_akQueriedIds = new List<ulong>();

		// Token: 0x04006A29 RID: 27177
		private List<ulong> m_akIWantApplyedPupils = new List<ulong>();

		// Token: 0x04006A2A RID: 27178
		private int refreshHour = 6;

		// Token: 0x04006A2B RID: 27179
		private bool hasCheckedToday;

		// Token: 0x04006A2C RID: 27180
		private bool onFirstCheckFlag = true;
	}
}
