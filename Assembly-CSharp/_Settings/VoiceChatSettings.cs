using System;
using GameClient;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace _Settings
{
	// Token: 0x02001A2F RID: 6703
	public class VoiceChatSettings : SettingsBindUI
	{
		// Token: 0x06010770 RID: 67440 RVA: 0x004A2328 File Offset: 0x004A0728
		public VoiceChatSettings(GameObject root, ClientFrame frame) : base(root, frame)
		{
		}

		// Token: 0x06010771 RID: 67441 RVA: 0x004A2332 File Offset: 0x004A0732
		protected override string GetCurrGameObjectPath()
		{
			return "UIRoot/UI2DRoot/Middle/SettingPanel/Panel/Contents/voiceChatSet";
		}

		// Token: 0x06010772 RID: 67442 RVA: 0x004A233C File Offset: 0x004A073C
		protected override void InitBind()
		{
			this.worldToggle = this.mBind.GetCom<Toggle>("WorldToggle");
			this.worldToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnWorldToggleChange));
			this.teamToggle = this.mBind.GetCom<Toggle>("TeamToggle");
			this.teamToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnTeamToggleChange));
			this.guildToggle = this.mBind.GetCom<Toggle>("GuildToggle");
			this.guildToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnGuildToggleChange));
			this.nearbyToggle = this.mBind.GetCom<Toggle>("NearbyToggle");
			this.nearbyToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnNearbyToggleChange));
			this.privateToggle = this.mBind.GetCom<Toggle>("PrivateToggle");
			this.privateToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnPrivateToggleChange));
			this.switchMic = this.mBind.GetCom<GeUISwitchButton>("SwitchMic");
			this.switchMic.onValueChanged.AddListener(new UnityAction<bool>(this.OnSwitchMicChange));
			this.switchPlayer = this.mBind.GetCom<GeUISwitchButton>("SwitchPlayer");
			this.switchPlayer.onValueChanged.AddListener(new UnityAction<bool>(this.OnSwitchPlayerChange));
			this.mVolumeSlider = this.mBind.GetCom<Slider>("VolumeSlider");
			this.mVolumeSlider.onValueChanged.AddListener(new UnityAction<float>(this.OnVolumeSliderChange));
			this.mPrivateTenToggle = this.mBind.GetCom<Toggle>("PrivateTenToggle");
			this.mPrivateTenToggle.onValueChanged.AddListener(new UnityAction<bool>(this._onPrivateTenToggleToggleValueChange));
			this.mPrivateTwentyToggle = this.mBind.GetCom<Toggle>("PrivateTwentyToggle");
			this.mPrivateTwentyToggle.onValueChanged.AddListener(new UnityAction<bool>(this._onPrivateTwentyToggleToggleValueChange));
			this.mPrivateThirtyToggle = this.mBind.GetCom<Toggle>("PrivateThirtyToggle");
			this.mPrivateThirtyToggle.onValueChanged.AddListener(new UnityAction<bool>(this._onPrivateThirtyToggleToggleValueChange));
			this.mPrivateFortyToggle = this.mBind.GetCom<Toggle>("PrivateFortyToggle");
			this.mPrivateFortyToggle.onValueChanged.AddListener(new UnityAction<bool>(this._onPrivateFortyToggleToggleValueChange));
		}

		// Token: 0x06010773 RID: 67443 RVA: 0x004A25A4 File Offset: 0x004A09A4
		protected override void UnInitBind()
		{
			if (this.worldToggle)
			{
				this.worldToggle.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnWorldToggleChange));
			}
			this.worldToggle = null;
			if (this.teamToggle)
			{
				this.teamToggle.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnTeamToggleChange));
			}
			this.teamToggle = null;
			if (this.guildToggle)
			{
				this.guildToggle.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnGuildToggleChange));
			}
			this.guildToggle = null;
			if (this.nearbyToggle)
			{
				this.nearbyToggle.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnNearbyToggleChange));
			}
			this.nearbyToggle = null;
			if (this.privateToggle)
			{
				this.privateToggle.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnPrivateToggleChange));
			}
			this.privateToggle = null;
			if (this.switchMic)
			{
				this.switchMic.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnSwitchMicChange));
			}
			this.switchMic = null;
			if (this.switchPlayer)
			{
				this.switchPlayer.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnSwitchPlayerChange));
			}
			this.switchPlayer = null;
			if (this.mVolumeSlider)
			{
				this.mVolumeSlider.onValueChanged.RemoveListener(new UnityAction<float>(this.OnVolumeSliderChange));
			}
			this.mVolumeSlider = null;
			if (this.mPrivateTenToggle)
			{
				this.mPrivateTenToggle.onValueChanged.RemoveListener(new UnityAction<bool>(this._onPrivateTenToggleToggleValueChange));
			}
			this.mPrivateTenToggle = null;
			if (this.mPrivateTwentyToggle)
			{
				this.mPrivateTwentyToggle.onValueChanged.RemoveListener(new UnityAction<bool>(this._onPrivateTwentyToggleToggleValueChange));
			}
			this.mPrivateTwentyToggle = null;
			if (this.mPrivateThirtyToggle)
			{
				this.mPrivateThirtyToggle.onValueChanged.RemoveListener(new UnityAction<bool>(this._onPrivateThirtyToggleToggleValueChange));
			}
			this.mPrivateThirtyToggle = null;
			if (this.mPrivateFortyToggle)
			{
				this.mPrivateFortyToggle.onValueChanged.RemoveListener(new UnityAction<bool>(this._onPrivateFortyToggleToggleValueChange));
			}
			this.mPrivateFortyToggle = null;
		}

		// Token: 0x06010774 RID: 67444 RVA: 0x004A2815 File Offset: 0x004A0C15
		protected override void OnShowOut()
		{
			this.SetVoiceSDKParams();
			this.isFrameShowed = true;
		}

		// Token: 0x06010775 RID: 67445 RVA: 0x004A2824 File Offset: 0x004A0C24
		protected override void OnHideIn()
		{
			this.isFrameShowed = false;
		}

		// Token: 0x06010776 RID: 67446 RVA: 0x004A2830 File Offset: 0x004A0C30
		private void SetVoiceSDKParams()
		{
			this.switchMic.states = Singleton<SDKVoiceManager>.GetInstance().IsRecordVoiceEnabled;
			this.switchPlayer.states = Singleton<SDKVoiceManager>.GetInstance().IsPlayVoiceEnabled;
			this.worldToggle.isOn = Singleton<SDKVoiceManager>.GetInstance().IsAutoPlayInWorld;
			this.teamToggle.isOn = Singleton<SDKVoiceManager>.GetInstance().IsAutoPlayInTeam;
			this.guildToggle.isOn = Singleton<SDKVoiceManager>.GetInstance().IsAutoPlayInGuild;
			this.nearbyToggle.isOn = Singleton<SDKVoiceManager>.GetInstance().IsAutoPlayInNearby;
			this.privateToggle.isOn = Singleton<SDKVoiceManager>.GetInstance().IsAutoPlayInPrivate;
			this.mVolumeSlider.value = Singleton<SDKVoiceManager>.GetInstance().VoicePlayerVolume;
			this.mPrivateTenToggle.isOn = DataManager<ChatManager>.GetInstance().GetIsPrivateChatLevelLimit(PrivateChatLevelLimit.LessLevelTen);
			this.mPrivateTwentyToggle.isOn = DataManager<ChatManager>.GetInstance().GetIsPrivateChatLevelLimit(PrivateChatLevelLimit.LessLevelTwenty);
			this.mPrivateThirtyToggle.isOn = DataManager<ChatManager>.GetInstance().GetIsPrivateChatLevelLimit(PrivateChatLevelLimit.LessLevelThirty);
			this.mPrivateFortyToggle.isOn = DataManager<ChatManager>.GetInstance().GetIsPrivateChatLevelLimit(PrivateChatLevelLimit.LessLevelForty);
		}

		// Token: 0x06010777 RID: 67447 RVA: 0x004A293D File Offset: 0x004A0D3D
		private void OnWorldToggleChange(bool isOn)
		{
			Singleton<SDKVoiceManager>.GetInstance().SaveWorldAutoPlayValue(isOn);
		}

		// Token: 0x06010778 RID: 67448 RVA: 0x004A294A File Offset: 0x004A0D4A
		private void OnTeamToggleChange(bool isOn)
		{
			Singleton<SDKVoiceManager>.GetInstance().SaveTeamAutoPlayValue(isOn);
		}

		// Token: 0x06010779 RID: 67449 RVA: 0x004A2957 File Offset: 0x004A0D57
		private void OnGuildToggleChange(bool isOn)
		{
			Singleton<SDKVoiceManager>.GetInstance().SaveGuildAutoPlayValue(isOn);
		}

		// Token: 0x0601077A RID: 67450 RVA: 0x004A2964 File Offset: 0x004A0D64
		private void OnNearbyToggleChange(bool isOn)
		{
			Singleton<SDKVoiceManager>.GetInstance().SaveNearbyAutoPlayValue(isOn);
		}

		// Token: 0x0601077B RID: 67451 RVA: 0x004A2971 File Offset: 0x004A0D71
		private void OnPrivateToggleChange(bool isOn)
		{
			Singleton<SDKVoiceManager>.GetInstance().SavePrivateAutoPlayValue(isOn);
		}

		// Token: 0x0601077C RID: 67452 RVA: 0x004A2980 File Offset: 0x004A0D80
		private void OnSwitchMicChange(bool isOn)
		{
			if (!this.isFrameShowed)
			{
				return;
			}
			bool flag = Singleton<SDKVoiceManager>.GetInstance().IsTalkRealMicOn();
			if (!isOn && flag)
			{
				Singleton<SDKVoiceManager>.GetInstance().CloseRealMic();
			}
			Singleton<SDKVoiceManager>.GetInstance().SaveMicPref(isOn);
		}

		// Token: 0x0601077D RID: 67453 RVA: 0x004A29C8 File Offset: 0x004A0DC8
		private void OnSwitchPlayerChange(bool isOn)
		{
			if (!this.isFrameShowed)
			{
				return;
			}
			bool flag = Singleton<SDKVoiceManager>.GetInstance().IsTalkRealPlayerOn();
			if (!isOn && flag)
			{
				Singleton<SDKVoiceManager>.GetInstance().CloseReaPlayer();
			}
			Singleton<SDKVoiceManager>.GetInstance().SavePlayerPref(isOn);
		}

		// Token: 0x0601077E RID: 67454 RVA: 0x004A2A0D File Offset: 0x004A0E0D
		private void OnVolumeSliderChange(float volumn)
		{
			Singleton<SDKVoiceManager>.GetInstance().SetVoiceVolume(volumn);
			Singleton<SDKVoiceManager>.GetInstance().SetPlayerVolume(volumn);
			Singleton<SDKVoiceManager>.GetInstance().SavePlayerVolumnPref(volumn);
		}

		// Token: 0x0601077F RID: 67455 RVA: 0x004A2A30 File Offset: 0x004A0E30
		private void _onPrivateTenToggleToggleValueChange(bool changed)
		{
			if (!this.isFrameShowed)
			{
				return;
			}
			if (changed)
			{
				DataManager<ChatManager>.GetInstance().SetPrivateChatLevelLimit(PrivateChatLevelLimit.LessLevelTen);
			}
		}

		// Token: 0x06010780 RID: 67456 RVA: 0x004A2A4F File Offset: 0x004A0E4F
		private void _onPrivateTwentyToggleToggleValueChange(bool changed)
		{
			if (!this.isFrameShowed)
			{
				return;
			}
			if (changed)
			{
				DataManager<ChatManager>.GetInstance().SetPrivateChatLevelLimit(PrivateChatLevelLimit.LessLevelTwenty);
			}
		}

		// Token: 0x06010781 RID: 67457 RVA: 0x004A2A6E File Offset: 0x004A0E6E
		private void _onPrivateThirtyToggleToggleValueChange(bool changed)
		{
			if (!this.isFrameShowed)
			{
				return;
			}
			if (changed)
			{
				DataManager<ChatManager>.GetInstance().SetPrivateChatLevelLimit(PrivateChatLevelLimit.LessLevelThirty);
			}
		}

		// Token: 0x06010782 RID: 67458 RVA: 0x004A2A8D File Offset: 0x004A0E8D
		private void _onPrivateFortyToggleToggleValueChange(bool changed)
		{
			if (!this.isFrameShowed)
			{
				return;
			}
			if (changed)
			{
				DataManager<ChatManager>.GetInstance().SetPrivateChatLevelLimit(PrivateChatLevelLimit.LessLevelForty);
			}
		}

		// Token: 0x0400A765 RID: 42853
		private Toggle worldToggle;

		// Token: 0x0400A766 RID: 42854
		private Toggle teamToggle;

		// Token: 0x0400A767 RID: 42855
		private Toggle guildToggle;

		// Token: 0x0400A768 RID: 42856
		private Toggle nearbyToggle;

		// Token: 0x0400A769 RID: 42857
		private Toggle privateToggle;

		// Token: 0x0400A76A RID: 42858
		private GeUISwitchButton switchMic;

		// Token: 0x0400A76B RID: 42859
		private GeUISwitchButton switchPlayer;

		// Token: 0x0400A76C RID: 42860
		private Slider mVolumeSlider;

		// Token: 0x0400A76D RID: 42861
		private Toggle mPrivateTenToggle;

		// Token: 0x0400A76E RID: 42862
		private Toggle mPrivateTwentyToggle;

		// Token: 0x0400A76F RID: 42863
		private Toggle mPrivateThirtyToggle;

		// Token: 0x0400A770 RID: 42864
		private Toggle mPrivateFortyToggle;

		// Token: 0x0400A771 RID: 42865
		private bool isFrameShowed;
	}
}
