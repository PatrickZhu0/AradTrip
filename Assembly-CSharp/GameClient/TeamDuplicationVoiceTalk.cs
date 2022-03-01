using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001CA3 RID: 7331
	public class TeamDuplicationVoiceTalk
	{
		// Token: 0x06011FCD RID: 73677 RVA: 0x00542648 File Offset: 0x00540A48
		public TeamDuplicationVoiceTalk(GameObject attachRoot)
		{
			this.UnInit();
			this.mVoiceTalkParent = attachRoot;
			this.mVoiceTalkChannelIds = new List<string>();
			this._Init();
		}

		// Token: 0x06011FCE RID: 73678 RVA: 0x0054269D File Offset: 0x00540A9D
		private void _Init()
		{
			this._BindUIEvent();
			if (DataManager<TeamDuplicationDataManager>.GetInstance().IsTeamDuplicationOwnerTeam)
			{
				this._InitComVoiceTalk();
				this._UpdateComVoiceTalk();
			}
		}

		// Token: 0x06011FCF RID: 73679 RVA: 0x005426C0 File Offset: 0x00540AC0
		public void UnInit()
		{
			this._UnInitComVoiceTalk();
			this._UnBindUIEvent();
			this.mVoiceTalkParent = null;
			if (this.mVoiceTalkChannelIds != null)
			{
				this.mVoiceTalkChannelIds.Clear();
			}
			this.isTeamDuplicationBuild = false;
			this.isLeader = false;
			this.isPreLeader = false;
			this.isMicStatusUpdateDirty = true;
			this.isTalkChannelSwitchDirty = true;
			this.captainId = string.Empty;
			this.teamId = string.Empty;
			this.localData.Clear();
		}

		// Token: 0x06011FD0 RID: 73680 RVA: 0x0054273A File Offset: 0x00540B3A
		public void HideVoiceTalk()
		{
			if (this.mVoiceTalk != null)
			{
				ComVoiceTalk.Hidden();
			}
		}

		// Token: 0x06011FD1 RID: 73681 RVA: 0x00542754 File Offset: 0x00540B54
		private void _InitComVoiceTalk()
		{
			this._UnInitComVoiceTalk();
			if (TeamDuplicationUtility.IsSelfPlayerIsTeamLeaderInTeamDuplication())
			{
				this._SetLocalVoiceConfig();
				this.mVoiceTalk = ComVoiceTalk.Create(this.mVoiceTalkParent, this.localData, ComVoiceTalk.ComVoiceTalkType.TeamDuplicationMainBuild, true, false);
			}
			else
			{
				this.mVoiceTalk = ComVoiceTalk.Create(this.mVoiceTalkParent, this.localData, ComVoiceTalk.ComVoiceTalkType.TeamDuplicationMainBuild, true, false);
			}
			this.isPreLeader = (this.isLeader = TeamDuplicationUtility.IsSelfPlayerIsTeamLeaderInTeamDuplication());
			this.isMicStatusUpdateDirty = true;
			this.isTalkChannelSwitchDirty = true;
		}

		// Token: 0x06011FD2 RID: 73682 RVA: 0x005427D4 File Offset: 0x00540BD4
		private void _SetLocalVoiceConfig()
		{
			this.localData = default(ComVoiceTalk.LocalCacheData);
			string text = Singleton<PlayerPrefsManager>.GetInstance().HasTypeKey(PlayerPrefsManager.PlayerPrefsKeyType.TeamDuplicationVoiceTalkMicOn);
			if (!string.IsNullOrEmpty(text))
			{
				this.localData.hasSetMicStatus = true;
				this.localData.isMicOn = (Singleton<PlayerPrefsManager>.GetInstance().GetTypeKeyIntValue(text) == 1);
			}
			string text2 = Singleton<PlayerPrefsManager>.GetInstance().HasTypeKey(PlayerPrefsManager.PlayerPrefsKeyType.TeamDuplicationVoiceTalkPlayerOn);
			if (!string.IsNullOrEmpty(text2))
			{
				this.localData.hasSetPlayerStatus = true;
				this.localData.isPlayerOn = (Singleton<PlayerPrefsManager>.GetInstance().GetTypeKeyIntValue(text2) == 1);
			}
		}

		// Token: 0x06011FD3 RID: 73683 RVA: 0x0054286C File Offset: 0x00540C6C
		private void _SaveLocalVoiceConfig()
		{
			int value = (!ComVoiceTalk.IsVoiceTalkMicOn()) ? 0 : 1;
			Singleton<PlayerPrefsManager>.GetInstance().SetTypeKeyIntValueNoExtra(PlayerPrefsManager.PlayerPrefsKeyType.TeamDuplicationVoiceTalkMicOn, value);
			int value2 = (!ComVoiceTalk.IsVoiceTalkPlayerOn()) ? 0 : 1;
			Singleton<PlayerPrefsManager>.GetInstance().SetTypeKeyIntValueNoExtra(PlayerPrefsManager.PlayerPrefsKeyType.TeamDuplicationVoiceTalkPlayerOn, value2);
		}

		// Token: 0x06011FD4 RID: 73684 RVA: 0x005428B7 File Offset: 0x00540CB7
		private void _UnInitComVoiceTalk()
		{
			if (this.mVoiceTalk != null)
			{
				ComVoiceTalk.Hidden();
				this.mVoiceTalk = null;
			}
		}

		// Token: 0x06011FD5 RID: 73685 RVA: 0x005428D6 File Offset: 0x00540CD6
		private void _DestoryComVoiceTalk()
		{
			if (this.mVoiceTalk != null)
			{
				if (!this._IsVoiceOpenInTeamDuplitionBattle())
				{
					this._SaveLocalVoiceConfig();
				}
				ComVoiceTalk.ForceDestroy();
				this.mVoiceTalk = null;
			}
		}

		// Token: 0x06011FD6 RID: 73686 RVA: 0x00542908 File Offset: 0x00540D08
		private void _UpdateComVoiceTalk()
		{
			if (this.mVoiceTalk == null)
			{
				this._InitComVoiceTalk();
			}
			if (this.mVoiceTalk != null)
			{
				this.teamId = this._TryGetTeamDuplicationSceneID();
				this.captainId = this._TryGetCaptainSceneID();
				if (this.mVoiceTalkChannelIds != null && (!this.mVoiceTalkChannelIds.Contains(this.teamId) || !this.mVoiceTalkChannelIds.Contains(this.captainId)))
				{
					this.mVoiceTalkChannelIds.Clear();
					this.mVoiceTalkChannelIds.Add(this.teamId);
					this.mVoiceTalkChannelIds.Add(this.captainId);
					ComVoiceTalk.UpdateChannelID(this.mVoiceTalkChannelIds);
				}
				this.isPreLeader = this.isLeader;
				this.isLeader = TeamDuplicationUtility.IsSelfPlayerIsTeamLeaderInTeamDuplication();
				if (this.isLeader)
				{
					ComVoiceTalk.ShowLimitSpeakBtn(true);
				}
				else
				{
					ComVoiceTalk.ShowLimitSpeakBtn(false);
				}
				if (this.isMicStatusUpdateDirty)
				{
					ComVoiceTalk.UpdateAllMicShowStatus();
					if (this._IsVoiceOpenInTeamDuplitionBattle())
					{
						ComVoiceTalk.UpdateMicBtnGroupStatus(true);
					}
					else
					{
						ComVoiceTalk.UpdateMicBtnGroupStatus(false);
					}
					this.isMicStatusUpdateDirty = false;
				}
				this._TrySelectSpeakTalkChannel();
				if (!this.isPreLeader && this.isLeader)
				{
					ComVoiceTalk.ResetCurrentGlobalSilence();
					ComVoiceTalk.SetSelctPlayerMicEnable(TeamDuplicationUtility.GetTeamLeaderPlayerAccId().ToString(), true);
				}
				if (this.isPreLeader && !this.isLeader)
				{
					ComVoiceTalk.UpdateAllMicShowStatus();
				}
			}
		}

		// Token: 0x06011FD7 RID: 73687 RVA: 0x00542A80 File Offset: 0x00540E80
		private void _TrySelectSpeakTalkChannel()
		{
			if (this.isTalkChannelSwitchDirty)
			{
				string empty = string.Empty;
				bool canSwitch = false;
				if (this._IsVoiceOpenInTeamDuplitionBattle())
				{
					if (ComVoiceTalk.IsVoiceTalkMicOn())
					{
						canSwitch = true;
					}
					if (this.isLeader)
					{
						empty = this.teamId;
					}
					else
					{
						empty = this.captainId;
					}
				}
				else
				{
					empty = this.teamId;
					canSwitch = true;
				}
				if (!string.IsNullOrEmpty(empty) && ComVoiceTalk.CheckJoinedTalkChannel(empty))
				{
					ComVoiceTalk.TrySwitchTalkChannelId(empty, canSwitch);
					this.isTalkChannelSwitchDirty = false;
				}
			}
		}

		// Token: 0x06011FD8 RID: 73688 RVA: 0x00542B08 File Offset: 0x00540F08
		private bool _IsTeamAllPlayerMoreThanOne()
		{
			return BattleMain.instance != null && BattleMain.instance.GetPlayerManager() != null && BattleMain.instance.GetPlayerManager().GetAllPlayers() != null && BattleMain.instance.GetPlayerManager().GetAllPlayers().Count > 0;
		}

		// Token: 0x06011FD9 RID: 73689 RVA: 0x00542B60 File Offset: 0x00540F60
		private bool _IsVoiceOpenInTeamDuplitionBattle()
		{
			bool flag = this._IsTeamAllPlayerMoreThanOne();
			bool flag2 = BattleMain.IsModeTeamDuplication(BattleMain.battleType);
			return (Singleton<PluginManager>.GetInstance().GetVoiceSDKSwitch(PluginManager.VoiceSDKSwitch.TalkVoiceInTeamDuplication) || !flag2) && flag && flag2;
		}

		// Token: 0x06011FDA RID: 73690 RVA: 0x00542BA4 File Offset: 0x00540FA4
		private string _TryGetTeamDuplicationSceneID()
		{
			string empty = string.Empty;
			TeamDuplicationTeamDataModel teamDuplicationTeamDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetTeamDuplicationTeamDataModel();
			if (teamDuplicationTeamDataModel == null)
			{
				return empty;
			}
			return teamDuplicationTeamDataModel.VoiceTalkRoomId;
		}

		// Token: 0x06011FDB RID: 73691 RVA: 0x00542BD4 File Offset: 0x00540FD4
		private string _TryGetCaptainSceneID()
		{
			string text = this._TryGetTeamDuplicationSceneID();
			int teamDuplicationCaptainIdByPlayerGuid = TeamDuplicationUtility.GetTeamDuplicationCaptainIdByPlayerGuid(DataManager<PlayerBaseData>.GetInstance().RoleID);
			if (teamDuplicationCaptainIdByPlayerGuid > 0)
			{
				text = string.Format("{0}_{1}", text, teamDuplicationCaptainIdByPlayerGuid);
			}
			return text;
		}

		// Token: 0x06011FDC RID: 73692 RVA: 0x00542C14 File Offset: 0x00541014
		private void _BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationBuildTeamSuccessMessage, new ClientEventSystem.UIEventHandler(this._OnReceiveTeamDuplicationBuildTeamSuccessMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationTeamDataMessage, new ClientEventSystem.UIEventHandler(this._OnReceiveTeamDuplicationTeamDataMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationCaptainNotifyMessage, new ClientEventSystem.UIEventHandler(this._OnReceiveTeamDuplicationCaptainNotifyMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationDismissMessage, new ClientEventSystem.UIEventHandler(this._OnReceiveTeamDuplicationDismissMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationQuitTeamMessage, new ClientEventSystem.UIEventHandler(this._OnReceiveTeamDuplicationQuitTeamMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.VoiceTalkJoinChannelAndMicChanged, new ClientEventSystem.UIEventHandler(this._OnVoiceTalkJoinChannelAndMicChanged));
		}

		// Token: 0x06011FDD RID: 73693 RVA: 0x00542CC4 File Offset: 0x005410C4
		private void _UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationBuildTeamSuccessMessage, new ClientEventSystem.UIEventHandler(this._OnReceiveTeamDuplicationBuildTeamSuccessMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationTeamDataMessage, new ClientEventSystem.UIEventHandler(this._OnReceiveTeamDuplicationTeamDataMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationCaptainNotifyMessage, new ClientEventSystem.UIEventHandler(this._OnReceiveTeamDuplicationCaptainNotifyMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationDismissMessage, new ClientEventSystem.UIEventHandler(this._OnReceiveTeamDuplicationDismissMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationQuitTeamMessage, new ClientEventSystem.UIEventHandler(this._OnReceiveTeamDuplicationQuitTeamMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.VoiceTalkJoinChannelAndMicChanged, new ClientEventSystem.UIEventHandler(this._OnVoiceTalkJoinChannelAndMicChanged));
		}

		// Token: 0x06011FDE RID: 73694 RVA: 0x00542D73 File Offset: 0x00541173
		private void _OnReceiveTeamDuplicationBuildTeamSuccessMessage(UIEvent uiEvent)
		{
			this.isTeamDuplicationBuild = true;
		}

		// Token: 0x06011FDF RID: 73695 RVA: 0x00542D7C File Offset: 0x0054117C
		private void _OnReceiveTeamDuplicationTeamDataMessage(UIEvent uiEvent)
		{
			if (this.isTeamDuplicationBuild)
			{
				this._InitComVoiceTalk();
				this.isTeamDuplicationBuild = false;
			}
			this._UpdateComVoiceTalk();
		}

		// Token: 0x06011FE0 RID: 73696 RVA: 0x00542D9C File Offset: 0x0054119C
		private void _OnReceiveTeamDuplicationCaptainNotifyMessage(UIEvent uiEvent)
		{
			this._UpdateComVoiceTalk();
		}

		// Token: 0x06011FE1 RID: 73697 RVA: 0x00542DA4 File Offset: 0x005411A4
		private void _OnReceiveTeamDuplicationDismissMessage(UIEvent uiEvent)
		{
			this._DestoryComVoiceTalk();
		}

		// Token: 0x06011FE2 RID: 73698 RVA: 0x00542DAC File Offset: 0x005411AC
		private void _OnReceiveTeamDuplicationQuitTeamMessage(UIEvent uiEvent)
		{
			this._DestoryComVoiceTalk();
		}

		// Token: 0x06011FE3 RID: 73699 RVA: 0x00542DB4 File Offset: 0x005411B4
		private void _OnVoiceTalkJoinChannelAndMicChanged(UIEvent uiEvent)
		{
			this.isTalkChannelSwitchDirty = true;
			this._TrySelectSpeakTalkChannel();
		}

		// Token: 0x0400BB87 RID: 48007
		private ComVoiceTalk mVoiceTalk;

		// Token: 0x0400BB88 RID: 48008
		private GameObject mVoiceTalkParent;

		// Token: 0x0400BB89 RID: 48009
		private List<string> mVoiceTalkChannelIds;

		// Token: 0x0400BB8A RID: 48010
		private bool isTeamDuplicationBuild;

		// Token: 0x0400BB8B RID: 48011
		private bool isLeader;

		// Token: 0x0400BB8C RID: 48012
		private bool isPreLeader;

		// Token: 0x0400BB8D RID: 48013
		private bool isMicStatusUpdateDirty = true;

		// Token: 0x0400BB8E RID: 48014
		private bool isTalkChannelSwitchDirty = true;

		// Token: 0x0400BB8F RID: 48015
		private string captainId = string.Empty;

		// Token: 0x0400BB90 RID: 48016
		private string teamId = string.Empty;

		// Token: 0x0400BB91 RID: 48017
		private ComVoiceTalk.LocalCacheData localData;
	}
}
