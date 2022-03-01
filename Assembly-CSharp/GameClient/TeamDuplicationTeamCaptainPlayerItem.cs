using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001C9C RID: 7324
	public class TeamDuplicationTeamCaptainPlayerItem : TeamDuplicationBasePlayerItem
	{
		// Token: 0x06011F5B RID: 73563 RVA: 0x005401F8 File Offset: 0x0053E5F8
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationPlayerExpireTimeMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationPlayerExpireTimeMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.VoiceTalkOtherSpeakInChannel, new ClientEventSystem.UIEventHandler(this._OnVoiceTalkOtherSpeakInChannel));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.VoiceTalkLeaveAllChannel, new ClientEventSystem.UIEventHandler(this._OnVoiceLeaveAllChannel));
		}

		// Token: 0x06011F5C RID: 73564 RVA: 0x00540258 File Offset: 0x0053E658
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationPlayerExpireTimeMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationPlayerExpireTimeMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.VoiceTalkOtherSpeakInChannel, new ClientEventSystem.UIEventHandler(this._OnVoiceTalkOtherSpeakInChannel));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.VoiceTalkLeaveAllChannel, new ClientEventSystem.UIEventHandler(this._OnVoiceLeaveAllChannel));
		}

		// Token: 0x06011F5D RID: 73565 RVA: 0x005402B6 File Offset: 0x0053E6B6
		protected override void OnDestroy()
		{
			base.OnDestroy();
			this.micSpeakShow = null;
		}

		// Token: 0x06011F5E RID: 73566 RVA: 0x005402C5 File Offset: 0x0053E6C5
		public override void Init(TeamDuplicationPlayerDataModel playerDataModel)
		{
			base.Init(playerDataModel);
			this.InitPlayerGrayCover();
		}

		// Token: 0x06011F5F RID: 73567 RVA: 0x005402D4 File Offset: 0x0053E6D4
		private void InitPlayerGrayCover()
		{
			if (this.PlayerDataModel == null)
			{
				CommonUtility.UpdateGameObjectUiGray(this.playerUIGray, false);
				this._HideMicSpeakShow();
				return;
			}
			ulong expireTime = this.PlayerDataModel.ExpireTime;
			this.UpdatePlayerGrayCover(expireTime);
		}

		// Token: 0x06011F60 RID: 73568 RVA: 0x00540314 File Offset: 0x0053E714
		private void OnReceiveTeamDuplicationPlayerExpireTimeMessage(UIEvent uiEvent)
		{
			if (this.PlayerDataModel == null)
			{
				CommonUtility.UpdateGameObjectUiGray(this.playerUIGray, false);
				this._HideMicSpeakShow();
				return;
			}
			if (uiEvent == null || uiEvent.Param1 == null || uiEvent.Param2 == null)
			{
				return;
			}
			ulong num = (ulong)uiEvent.Param1;
			ulong expireTime = (ulong)uiEvent.Param2;
			if (this.PlayerDataModel.Guid != num)
			{
				return;
			}
			this.UpdatePlayerGrayCover(expireTime);
		}

		// Token: 0x06011F61 RID: 73569 RVA: 0x0054038D File Offset: 0x0053E78D
		private void UpdatePlayerGrayCover(ulong expireTime)
		{
			if (expireTime == 0UL)
			{
				CommonUtility.UpdateGameObjectUiGray(this.playerUIGray, false);
				this._HideMicSpeakShow();
			}
			else
			{
				CommonUtility.UpdateGameObjectUiGray(this.playerUIGray, true);
			}
		}

		// Token: 0x06011F62 RID: 73570 RVA: 0x005403BC File Offset: 0x0053E7BC
		private void _OnVoiceTalkOtherSpeakInChannel(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			VoiceTalkOtherSpeakInfo voiceTalkOtherSpeakInfo = uiEvent.Param1 as VoiceTalkOtherSpeakInfo;
			if (voiceTalkOtherSpeakInfo == null)
			{
				return;
			}
			if (this.PlayerDataModel == null)
			{
				return;
			}
			if (voiceTalkOtherSpeakInfo.gameAccId == this.PlayerDataModel.AccId.ToString())
			{
				this._SetMicSpeakShow(voiceTalkOtherSpeakInfo.isSpeak);
			}
		}

		// Token: 0x06011F63 RID: 73571 RVA: 0x0054042C File Offset: 0x0053E82C
		private void _OnVoiceLeaveAllChannel(UIEvent uiEvent)
		{
			this._HideMicSpeakShow();
		}

		// Token: 0x06011F64 RID: 73572 RVA: 0x00540434 File Offset: 0x0053E834
		private void _SetMicSpeakShow(bool bShow)
		{
			if (this.micSpeakShow == null)
			{
				GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/Common/ComVoice/VoiceTalkMicSpeakShow", true, 0U);
				if (gameObject)
				{
					this.micSpeakShow = gameObject.GetComponent<ComVoiceTalkMicSpeakShow>();
					Utility.AttachTo(gameObject, this.voiceTalkRoot, false);
				}
			}
			if (this.micSpeakShow)
			{
				if (bShow)
				{
					this.micSpeakShow.Show();
				}
				else
				{
					this.micSpeakShow.Hide();
				}
			}
		}

		// Token: 0x06011F65 RID: 73573 RVA: 0x005404B9 File Offset: 0x0053E8B9
		private void _HideMicSpeakShow()
		{
			if (this.micSpeakShow)
			{
				this.micSpeakShow.Hide();
			}
		}

		// Token: 0x0400BB36 RID: 47926
		[SerializeField]
		private UIGray playerUIGray;

		// Token: 0x0400BB37 RID: 47927
		[SerializeField]
		private GameObject voiceTalkRoot;

		// Token: 0x0400BB38 RID: 47928
		private ComVoiceTalkMicSpeakShow micSpeakShow;
	}
}
