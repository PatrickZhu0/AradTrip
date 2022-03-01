using System;
using GameClient;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace _Settings
{
	// Token: 0x02001A2B RID: 6699
	public class SystemInfoSettings : SettingsBindUI
	{
		// Token: 0x06010707 RID: 67335 RVA: 0x004A0222 File Offset: 0x0049E622
		public SystemInfoSettings(GameObject root, ClientFrame frame) : base(root, frame)
		{
		}

		// Token: 0x06010708 RID: 67336 RVA: 0x004A022C File Offset: 0x0049E62C
		protected override string GetCurrGameObjectPath()
		{
			return "UIRoot/UI2DRoot/Middle/SettingPanel/Panel/Contents/systemSet";
		}

		// Token: 0x06010709 RID: 67337 RVA: 0x004A0234 File Offset: 0x0049E634
		protected override void InitBind()
		{
			this.bgSoundSwitch = this.mBind.GetCom<GeUISwitchButton>("BgSoundSwitch");
			this.bgSoundSwitch.onValueChanged.AddListener(new UnityAction<bool>(this.OnBgSoundSwitchChange));
			this.bgVolumnSlider = this.mBind.GetCom<Slider>("BgVolumnSlider");
			this.bgVolumnSlider.onValueChanged.AddListener(new UnityAction<float>(this.OnBgVolumnSliderChange));
			this.bgVolumnSliderGray = this.mBind.GetCom<UIGray>("BgVolumnSliderGray");
			this.seSoundSwitch = this.mBind.GetCom<GeUISwitchButton>("SESoundSwitch");
			this.seSoundSwitch.onValueChanged.AddListener(new UnityAction<bool>(this.OnSESoundSwitchChange));
			this.seVolumnSlider = this.mBind.GetCom<Slider>("SEVolumnSlider");
			this.seVolumnSlider.onValueChanged.AddListener(new UnityAction<float>(this.OnSEVolumnSliderChange));
			this.seVolumnSliderGray = this.mBind.GetCom<UIGray>("SEVolumnSliderGray");
			this.qualityLv0 = this.mBind.GetCom<Toggle>("QualityLv0");
			this.qualityLv0.onValueChanged.AddListener(new UnityAction<bool>(this.OnQualityLv0Change));
			this.qualityLv1 = this.mBind.GetCom<Toggle>("QualityLv1");
			this.qualityLv1.onValueChanged.AddListener(new UnityAction<bool>(this.OnQualityLv1Change));
			this.qualityLv2 = this.mBind.GetCom<Toggle>("QualityLv2");
			this.qualityLv2.onValueChanged.AddListener(new UnityAction<bool>(this.OnQualityLv2Change));
			this.playerDisplayLv1 = this.mBind.GetCom<Toggle>("PlayerDisplayLv1");
			this.playerDisplayLv1.onValueChanged.AddListener(new UnityAction<bool>(this.OnPlayerDisplayLv1Change));
			this.playerDisplayLv2 = this.mBind.GetCom<Toggle>("PlayerDisplayLv2");
			this.playerDisplayLv2.onValueChanged.AddListener(new UnityAction<bool>(this.OnPlayerDisplayLv2Change));
			this.playerDisplayLv3 = this.mBind.GetCom<Toggle>("PlayerDisplayLv3");
			this.playerDisplayLv3.onValueChanged.AddListener(new UnityAction<bool>(this.OnPlayerDisplayLv3Change));
			this.playerDisplayLv4 = this.mBind.GetCom<Toggle>("PlayerDisplayLv4");
			this.playerDisplayLv4.onValueChanged.AddListener(new UnityAction<bool>(this.OnPlayerDisplayLv4Change));
			this.playerDisplayLv5 = this.mBind.GetCom<Toggle>("PlayerDisplayLv5");
			this.playerDisplayLv5.onValueChanged.AddListener(new UnityAction<bool>(this.OnPlayerDisplayLv5Change));
			this.teamAskVibrateSwitch = this.mBind.GetCom<Toggle>("TeamVibrateSwitch");
			this.teamAskVibrateSwitch.onValueChanged.AddListener(new UnityAction<bool>(this._OnTeamAskVibrateSwitchChange));
			this.pk3v3VibrateSwitch = this.mBind.GetCom<Toggle>("Pk3v3VibrateSwitch");
			this.pk3v3VibrateSwitch.onValueChanged.AddListener(new UnityAction<bool>(this._OnPk3v3VibrateSwitchChange));
			this.mysteryShopSwitch = this.mBind.GetCom<Toggle>("MysteryShopSwitch");
			this.mysteryShopSwitch.onValueChanged.AddListener(new UnityAction<bool>(this._OnMysteryShopSwitchChange));
			this.inviteFriendLvMask1 = this.mBind.GetCom<Toggle>("inviteFriendLvMask1");
			this.inviteFriendLvMask1.SafeAddOnValueChangedListener(delegate(bool value)
			{
				if (value)
				{
					SystemInfoSettings.InviteFriendLvLimit = 10;
					this.SendChangeGameInviteSet();
				}
			});
			this.inviteFriendLvMask2 = this.mBind.GetCom<Toggle>("inviteFriendLvMask2");
			this.inviteFriendLvMask2.SafeAddOnValueChangedListener(delegate(bool value)
			{
				if (value)
				{
					SystemInfoSettings.InviteFriendLvLimit = 20;
					this.SendChangeGameInviteSet();
				}
			});
			this.inviteFriendLvMask3 = this.mBind.GetCom<Toggle>("inviteFriendLvMask3");
			this.inviteFriendLvMask3.SafeAddOnValueChangedListener(delegate(bool value)
			{
				if (value)
				{
					SystemInfoSettings.InviteFriendLvLimit = 30;
					this.SendChangeGameInviteSet();
				}
			});
			this.inviteFriendLvMask4 = this.mBind.GetCom<Toggle>("inviteFriendLvMask4");
			this.inviteFriendLvMask4.SafeAddOnValueChangedListener(delegate(bool value)
			{
				if (value)
				{
					SystemInfoSettings.InviteFriendLvLimit = 40;
					this.SendChangeGameInviteSet();
				}
			});
			this.guildMask = this.mBind.GetCom<Toggle>("guildMask");
			this.guildMask.SafeAddOnValueChangedListener(delegate(bool value)
			{
				SystemInfoSettings.MaskGuildInvite = value;
				this.SendChangeGameSecretSet();
			});
			this.teamMask = this.mBind.GetCom<Toggle>("teamMask");
			this.teamMask.SafeAddOnValueChangedListener(delegate(bool value)
			{
				SystemInfoSettings.MaskTeamInvite = value;
				this.SendChangeGameSecretSet();
			});
			this.pkMask = this.mBind.GetCom<Toggle>("pkMask");
			this.pkMask.SafeAddOnValueChangedListener(delegate(bool value)
			{
				SystemInfoSettings.MaskPkInvite = value;
				this.SendChangeGameSecretSet();
			});
			this.mDungeonDisSet = this.mBind.GetCom<ComCommonBind>("DungeonDisSet");
			this.InitDungeonDisBind();
			this.townSettingSet = this.mBind.GetCom<ComCommonBind>("townShowSet");
			this._bindExUITown();
			this.mPKDisSet = this.mBind.GetCom<ComCommonBind>("PKDisSet");
			this.InitPkDisBind();
		}

		// Token: 0x0601070A RID: 67338 RVA: 0x004A06EC File Offset: 0x0049EAEC
		protected override void UnInitBind()
		{
			if (this.bgSoundSwitch != null)
			{
				this.bgSoundSwitch.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnBgSoundSwitchChange));
			}
			this.bgSoundSwitch = null;
			if (this.bgVolumnSlider != null)
			{
				this.bgVolumnSlider.onValueChanged.RemoveListener(new UnityAction<float>(this.OnBgVolumnSliderChange));
			}
			this.bgVolumnSlider = null;
			this.bgVolumnSliderGray = null;
			if (this.seSoundSwitch != null)
			{
				this.seSoundSwitch.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnSESoundSwitchChange));
			}
			this.seSoundSwitch = null;
			if (this.seVolumnSlider != null)
			{
				this.seVolumnSlider.onValueChanged.RemoveListener(new UnityAction<float>(this.OnSEVolumnSliderChange));
			}
			this.seVolumnSlider = null;
			this.seVolumnSliderGray = null;
			if (this.qualityLv0 != null)
			{
				this.qualityLv0.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnQualityLv0Change));
			}
			this.qualityLv0 = null;
			if (this.qualityLv1 != null)
			{
				this.qualityLv1.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnQualityLv1Change));
			}
			this.qualityLv1 = null;
			if (this.qualityLv2 != null)
			{
				this.qualityLv2.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnQualityLv2Change));
			}
			this.qualityLv2 = null;
			if (this.playerDisplayLv1 != null)
			{
				this.playerDisplayLv1.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnPlayerDisplayLv1Change));
			}
			this.playerDisplayLv1 = null;
			if (this.playerDisplayLv2 != null)
			{
				this.playerDisplayLv2.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnPlayerDisplayLv2Change));
			}
			this.playerDisplayLv2 = null;
			if (this.playerDisplayLv3 != null)
			{
				this.playerDisplayLv3.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnPlayerDisplayLv3Change));
			}
			this.playerDisplayLv3 = null;
			if (this.playerDisplayLv4 != null)
			{
				this.playerDisplayLv4.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnPlayerDisplayLv4Change));
			}
			this.playerDisplayLv4 = null;
			if (this.playerDisplayLv5 != null)
			{
				this.playerDisplayLv5.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnPlayerDisplayLv5Change));
			}
			this.playerDisplayLv5 = null;
			if (this.teamAskVibrateSwitch != null)
			{
				this.teamAskVibrateSwitch.onValueChanged.RemoveListener(new UnityAction<bool>(this._OnTeamAskVibrateSwitchChange));
			}
			this.teamAskVibrateSwitch = null;
			if (this.pk3v3VibrateSwitch != null)
			{
				this.pk3v3VibrateSwitch.onValueChanged.RemoveListener(new UnityAction<bool>(this._OnPk3v3VibrateSwitchChange));
			}
			this.pk3v3VibrateSwitch = null;
			if (this.mysteryShopSwitch != null)
			{
				this.mysteryShopSwitch.onValueChanged.RemoveListener(new UnityAction<bool>(this._OnMysteryShopSwitchChange));
			}
			this.mysteryShopSwitch = null;
			this.inviteFriendLvMask1 = null;
			this.inviteFriendLvMask2 = null;
			this.inviteFriendLvMask3 = null;
			this.inviteFriendLvMask4 = null;
			this.guildMask = null;
			this.teamMask = null;
			this.pkMask = null;
			if (this.mDungeonDisSet != null)
			{
				this.mDungeonDisSet = null;
				this.UnInitDungeonDisBind();
			}
			if (this.townSettingSet != null)
			{
				this._unbindExUITown();
				this.townSettingSet = null;
			}
			if (this.mPKDisSet != null)
			{
				this.mPKDisSet = null;
				this.UnInitPkDisBind();
			}
		}

		// Token: 0x0601070B RID: 67339 RVA: 0x004A0AA0 File Offset: 0x0049EEA0
		protected override void OnShowOut()
		{
			Singleton<GeGraphicSetting>.CreateInstance(true);
			this.InitViewSoundVolumn();
			this.InitGraphicQualityLevel();
			this.InitPlayerDisplayLevel();
			this._InitVibrateSet();
			this._InitInviteSet();
			this._InitPrivacySet();
			this.InitDataByType("SETTING_SUMMONDISSET");
			this.InitDataByType("SETTING_SKILLEFFECTSET");
			this.InitDataByType("SETTING_HITNUMSET");
			this.InitDataByType("SETTING_TITLESET");
			this.InitDataByType("SETTING_TITLESETPVP");
			this.InitDataByType("SETTING_PETDISPLAY");
		}

		// Token: 0x0601070C RID: 67340 RVA: 0x004A0B19 File Offset: 0x0049EF19
		protected override void OnHideIn()
		{
			DataManager<SystemConfigManager>.GetInstance().SaveConfig();
			PlayerLocalSetting.SaveConfig();
			Singleton<GeGraphicSetting>.instance.SaveSetting();
		}

		// Token: 0x0601070D RID: 67341 RVA: 0x004A0B34 File Offset: 0x0049EF34
		private void InitViewSoundVolumn()
		{
			if (this.bgSoundSwitch && this.bgVolumnSlider && this.seVolumnSlider && this.seSoundSwitch)
			{
				this.bgSoundSwitch.SetSwitch(!DataManager<SystemConfigManager>.GetInstance().SystemConfigData.SoundConfig.Mute);
				this.seSoundSwitch.SetSwitch(!DataManager<SystemConfigManager>.GetInstance().SystemConfigData.MusicConfig.Mute);
				this.bgVolumnSlider.value = (float)DataManager<SystemConfigManager>.GetInstance().SystemConfigData.SoundConfig.Volume;
				this.seVolumnSlider.value = (float)DataManager<SystemConfigManager>.GetInstance().SystemConfigData.MusicConfig.Volume;
			}
		}

		// Token: 0x0601070E RID: 67342 RVA: 0x004A0C05 File Offset: 0x0049F005
		private void OnBgSoundSwitchChange(bool isOn)
		{
			this._SwitchBgSound(isOn);
		}

		// Token: 0x0601070F RID: 67343 RVA: 0x004A0C0E File Offset: 0x0049F00E
		private void OnBgVolumnSliderChange(float value)
		{
			this._AdjustBgVolumn(value);
		}

		// Token: 0x06010710 RID: 67344 RVA: 0x004A0C17 File Offset: 0x0049F017
		private void OnSESoundSwitchChange(bool isOn)
		{
			this._SwitchSESound(isOn);
		}

		// Token: 0x06010711 RID: 67345 RVA: 0x004A0C20 File Offset: 0x0049F020
		private void OnSEVolumnSliderChange(float value)
		{
			this._AdjustSEVolumn(value);
		}

		// Token: 0x06010712 RID: 67346 RVA: 0x004A0C29 File Offset: 0x0049F029
		private void OnQualityLv0Change(bool isOn)
		{
			if (isOn)
			{
				this._SwitchGraphicQaulity(0);
			}
		}

		// Token: 0x06010713 RID: 67347 RVA: 0x004A0C38 File Offset: 0x0049F038
		private void OnQualityLv1Change(bool isOn)
		{
			if (isOn)
			{
				this._SwitchGraphicQaulity(1);
			}
		}

		// Token: 0x06010714 RID: 67348 RVA: 0x004A0C47 File Offset: 0x0049F047
		private void OnQualityLv2Change(bool isOn)
		{
			if (isOn)
			{
				this._SwitchGraphicQaulity(2);
			}
		}

		// Token: 0x06010715 RID: 67349 RVA: 0x004A0C56 File Offset: 0x0049F056
		private void OnPlayerDisplayLv1Change(bool isOn)
		{
			if (isOn)
			{
				this._SetPlayerDisplayNum(0);
			}
		}

		// Token: 0x06010716 RID: 67350 RVA: 0x004A0C65 File Offset: 0x0049F065
		private void OnPlayerDisplayLv2Change(bool isOn)
		{
			if (isOn)
			{
				this._SetPlayerDisplayNum(5);
			}
		}

		// Token: 0x06010717 RID: 67351 RVA: 0x004A0C74 File Offset: 0x0049F074
		private void OnPlayerDisplayLv3Change(bool isOn)
		{
			if (isOn)
			{
				this._SetPlayerDisplayNum(10);
			}
		}

		// Token: 0x06010718 RID: 67352 RVA: 0x004A0C84 File Offset: 0x0049F084
		private void OnPlayerDisplayLv4Change(bool isOn)
		{
			if (isOn)
			{
				this._SetPlayerDisplayNum(15);
			}
		}

		// Token: 0x06010719 RID: 67353 RVA: 0x004A0C94 File Offset: 0x0049F094
		private void OnPlayerDisplayLv5Change(bool isOn)
		{
			if (isOn)
			{
				this._SetPlayerDisplayNum(20);
			}
		}

		// Token: 0x0601071A RID: 67354 RVA: 0x004A0CA4 File Offset: 0x0049F0A4
		private void _OnTeamAskVibrateSwitchChange(bool isOn)
		{
			this._SwitchTeamAskVibrate(isOn);
		}

		// Token: 0x0601071B RID: 67355 RVA: 0x004A0CAD File Offset: 0x0049F0AD
		private void _OnPk3v3VibrateSwitchChange(bool isOn)
		{
			this._SwitchPk3v3Vibrate(isOn);
		}

		// Token: 0x0601071C RID: 67356 RVA: 0x004A0CB6 File Offset: 0x0049F0B6
		private void _OnMysteryShopSwitchChange(bool isOn)
		{
			this._SwitchMysteryShop(isOn);
		}

		// Token: 0x0601071D RID: 67357 RVA: 0x004A0CC0 File Offset: 0x0049F0C0
		private void InitGraphicQualityLevel()
		{
			if (this.qualityLv0 && this.qualityLv1 && this.qualityLv2)
			{
				int num = 0;
				if (Singleton<GeGraphicSetting>.instance.GetSetting("GraphicLevel", ref num))
				{
					this.qualityLv0.isOn = (0 == num);
					this.qualityLv1.isOn = (1 == num);
					this.qualityLv2.isOn = (2 == num);
				}
				else
				{
					if (this.qualityLv0.isOn)
					{
						num = 0;
					}
					else if (this.qualityLv1.isOn)
					{
						num = 1;
					}
					else
					{
						num = 2;
					}
					this._SwitchGraphicQaulity(num);
				}
			}
		}

		// Token: 0x0601071E RID: 67358 RVA: 0x004A0D80 File Offset: 0x0049F180
		private void InitPlayerDisplayLevel()
		{
			if (this.playerDisplayLv1 && this.playerDisplayLv2 && this.playerDisplayLv3 && this.playerDisplayLv4 && this.playerDisplayLv5)
			{
				int num = 0;
				if (Singleton<GeGraphicSetting>.instance.GetSetting("PlayerDisplayNum", ref num))
				{
					this.playerDisplayLv1.isOn = (0 == num);
					this.playerDisplayLv2.isOn = (5 == num);
					this.playerDisplayLv3.isOn = (10 == num);
					this.playerDisplayLv4.isOn = (15 == num);
					this.playerDisplayLv5.isOn = (20 == num);
				}
				else
				{
					if (this.playerDisplayLv1.isOn)
					{
						num = 0;
					}
					else if (this.playerDisplayLv2.isOn)
					{
						num = 5;
					}
					else if (this.playerDisplayLv3.isOn)
					{
						num = 10;
					}
					else if (this.playerDisplayLv4.isOn)
					{
						num = 15;
					}
					else
					{
						num = 20;
					}
					this._SetPlayerDisplayNum(num);
				}
			}
		}

		// Token: 0x0601071F RID: 67359 RVA: 0x004A0EB0 File Offset: 0x0049F2B0
		private void _InitVibrateSet()
		{
			if (this.teamAskVibrateSwitch != null)
			{
				this.teamAskVibrateSwitch.isOn = Singleton<DeviceVibrateManager>.GetInstance().CheckVibrateSwitchOpen(VibrateSwitchType.Team);
			}
			if (this.pk3v3VibrateSwitch != null)
			{
				this.pk3v3VibrateSwitch.isOn = Singleton<DeviceVibrateManager>.GetInstance().CheckVibrateSwitchOpen(VibrateSwitchType.Pk3v3);
			}
			if (this.mysteryShopSwitch != null)
			{
				this.mysteryShopSwitch.isOn = Singleton<DeviceVibrateManager>.GetInstance().CheckVibrateSwitchOpen(VibrateSwitchType.MysteryShop);
			}
		}

		// Token: 0x06010720 RID: 67360 RVA: 0x004A0F34 File Offset: 0x0049F334
		private void _InitInviteSet()
		{
			Toggle toggle = null;
			SystemInfoSettings.InviteFriendLvLimit = DataManager<SystemConfigManager>.GetInstance().InviteFriendLvLimit;
			if (SystemInfoSettings.InviteFriendLvLimit == 10)
			{
				toggle = this.inviteFriendLvMask1;
			}
			else if (SystemInfoSettings.InviteFriendLvLimit == 20)
			{
				toggle = this.inviteFriendLvMask2;
			}
			else if (SystemInfoSettings.InviteFriendLvLimit == 30)
			{
				toggle = this.inviteFriendLvMask3;
			}
			else if (SystemInfoSettings.InviteFriendLvLimit == 40)
			{
				toggle = this.inviteFriendLvMask4;
			}
			toggle.SafeSetToggleOnState(true);
		}

		// Token: 0x06010721 RID: 67361 RVA: 0x004A0FB4 File Offset: 0x0049F3B4
		private void _InitPrivacySet()
		{
			SystemInfoSettings.MaskGuildInvite = DataManager<SystemConfigManager>.GetInstance().MaskGuildInvite;
			SystemInfoSettings.MaskTeamInvite = DataManager<SystemConfigManager>.GetInstance().MaskTeamInvite;
			SystemInfoSettings.MaskPkInvite = DataManager<SystemConfigManager>.GetInstance().MaskPkInvite;
			this.guildMask.SafeSetToggleOnState(SystemInfoSettings.MaskGuildInvite);
			this.teamMask.SafeSetToggleOnState(SystemInfoSettings.MaskTeamInvite);
			this.pkMask.SafeSetToggleOnState(SystemInfoSettings.MaskPkInvite);
		}

		// Token: 0x06010722 RID: 67362 RVA: 0x004A101E File Offset: 0x0049F41E
		private void SendChangeGameInviteSet()
		{
			if (SystemInfoSettings.InviteFriendLvLimit == DataManager<SystemConfigManager>.GetInstance().InviteFriendLvLimit)
			{
				return;
			}
			DataManager<SystemConfigManager>.GetInstance().SendSceneGameSetReq(GameSetType.GST_FRIEND_INVATE, (uint)SystemInfoSettings.InviteFriendLvLimit);
		}

		// Token: 0x06010723 RID: 67363 RVA: 0x004A1048 File Offset: 0x0049F448
		private void SendChangeGameSecretSet()
		{
			if (SystemInfoSettings.MaskGuildInvite == DataManager<SystemConfigManager>.GetInstance().MaskGuildInvite && SystemInfoSettings.MaskTeamInvite == DataManager<SystemConfigManager>.GetInstance().MaskTeamInvite && SystemInfoSettings.MaskPkInvite == DataManager<SystemConfigManager>.GetInstance().MaskPkInvite)
			{
				return;
			}
			uint num = 0U;
			if (SystemInfoSettings.MaskGuildInvite)
			{
				num |= 1U;
			}
			if (SystemInfoSettings.MaskTeamInvite)
			{
				num |= 2U;
			}
			if (SystemInfoSettings.MaskPkInvite)
			{
				num |= 4U;
			}
			DataManager<SystemConfigManager>.GetInstance().SendSceneGameSetReq(GameSetType.GST_SECRET, num);
		}

		// Token: 0x06010724 RID: 67364 RVA: 0x004A10CC File Offset: 0x0049F4CC
		private void _AdjustBgVolumn(float value)
		{
			if (this.bgVolumnSlider)
			{
				DataManager<SystemConfigManager>.GetInstance().SystemConfigData.SoundConfig.Volume = (double)this.bgVolumnSlider.value;
				MonoSingleton<AudioManager>.instance.SetVolume(AudioType.AudioStream, this.bgVolumnSlider.value);
			}
		}

		// Token: 0x06010725 RID: 67365 RVA: 0x004A111F File Offset: 0x0049F51F
		private void _SwitchBgSound(bool value)
		{
			DataManager<SystemConfigManager>.GetInstance().SystemConfigData.SoundConfig.Mute = !value;
			MonoSingleton<AudioManager>.instance.SetMute(AudioType.AudioStream, !value);
		}

		// Token: 0x06010726 RID: 67366 RVA: 0x004A1148 File Offset: 0x0049F548
		private void _AdjustSEVolumn(float value)
		{
			if (this.seVolumnSlider)
			{
				DataManager<SystemConfigManager>.GetInstance().SystemConfigData.MusicConfig.Volume = (double)this.seVolumnSlider.value;
				MonoSingleton<AudioManager>.instance.SetVolume(AudioType.AudioEffect, this.seVolumnSlider.value);
				MonoSingleton<AudioManager>.instance.SetVolume(AudioType.AudioVoice, this.seVolumnSlider.value);
				Singleton<NpcVoiceCachedManager>.instance.SetVolume(this.seVolumnSlider.value);
			}
		}

		// Token: 0x06010727 RID: 67367 RVA: 0x004A11C6 File Offset: 0x0049F5C6
		private void _SwitchSESound(bool value)
		{
			MonoSingleton<AudioManager>.instance.SetMute(AudioType.AudioEffect, !value);
			MonoSingleton<AudioManager>.instance.SetMute(AudioType.AudioVoice, !value);
			DataManager<SystemConfigManager>.GetInstance().SystemConfigData.MusicConfig.Mute = !value;
		}

		// Token: 0x06010728 RID: 67368 RVA: 0x004A11FE File Offset: 0x0049F5FE
		private void _SwitchGraphicQaulity(int level)
		{
			if (Singleton<GeGraphicSetting>.instance.GetGraphicLevel() == level)
			{
				return;
			}
			Singleton<GeGraphicSetting>.instance.SetGraphicLevel((GraphicLevel)level);
			this.InitPlayerDisplayLevel();
			this.SetDataByGraphicLevel();
		}

		// Token: 0x06010729 RID: 67369 RVA: 0x004A1228 File Offset: 0x0049F628
		private void _SetPlayerDisplayNum(int number)
		{
			if (!Singleton<GeGraphicSetting>.instance.SetSetting("PlayerDisplayNum", number))
			{
				Singleton<GeGraphicSetting>.instance.AddSetting("PlayerDisplayNum", number);
			}
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemTown;
			if (clientSystemTown != null)
			{
				clientSystemTown.OnGraphicSettingChange(number);
			}
		}

		// Token: 0x0601072A RID: 67370 RVA: 0x004A1278 File Offset: 0x0049F678
		private void _SwitchTeamAskVibrate(bool isOn)
		{
			Singleton<DeviceVibrateManager>.GetInstance().SetVibrateSwitch(VibrateSwitchType.Team, isOn);
		}

		// Token: 0x0601072B RID: 67371 RVA: 0x004A1286 File Offset: 0x0049F686
		private void _SwitchPk3v3Vibrate(bool isOn)
		{
			Singleton<DeviceVibrateManager>.GetInstance().SetVibrateSwitch(VibrateSwitchType.Pk3v3, isOn);
		}

		// Token: 0x0601072C RID: 67372 RVA: 0x004A1294 File Offset: 0x0049F694
		private void _SwitchMysteryShop(bool isOn)
		{
			Singleton<DeviceVibrateManager>.GetInstance().SetVibrateSwitch(VibrateSwitchType.MysteryShop, isOn);
		}

		// Token: 0x17001D47 RID: 7495
		// (get) Token: 0x0601072E RID: 67374 RVA: 0x004A12AA File Offset: 0x0049F6AA
		// (set) Token: 0x0601072D RID: 67373 RVA: 0x004A12A2 File Offset: 0x0049F6A2
		private static int InviteFriendLvLimit { get; set; }

		// Token: 0x17001D48 RID: 7496
		// (get) Token: 0x06010730 RID: 67376 RVA: 0x004A12B9 File Offset: 0x0049F6B9
		// (set) Token: 0x0601072F RID: 67375 RVA: 0x004A12B1 File Offset: 0x0049F6B1
		private static bool MaskGuildInvite { get; set; }

		// Token: 0x17001D49 RID: 7497
		// (get) Token: 0x06010732 RID: 67378 RVA: 0x004A12C8 File Offset: 0x0049F6C8
		// (set) Token: 0x06010731 RID: 67377 RVA: 0x004A12C0 File Offset: 0x0049F6C0
		private static bool MaskTeamInvite { get; set; }

		// Token: 0x17001D4A RID: 7498
		// (get) Token: 0x06010734 RID: 67380 RVA: 0x004A12D7 File Offset: 0x0049F6D7
		// (set) Token: 0x06010733 RID: 67379 RVA: 0x004A12CF File Offset: 0x0049F6CF
		private static bool MaskPkInvite { get; set; }

		// Token: 0x06010735 RID: 67381 RVA: 0x004A12E0 File Offset: 0x0049F6E0
		protected void _bindExUITown()
		{
			if (this.townSettingSet == null)
			{
				return;
			}
			this.mHaloOpen = this.townSettingSet.GetCom<Toggle>("HaloOpen");
			this.mHaloOpen.onValueChanged.AddListener(new UnityAction<bool>(this._onHaloOpenToggleValueChange));
			this.mHaloClose = this.townSettingSet.GetCom<Toggle>("HaloClose");
			this.mHaloClose.onValueChanged.AddListener(new UnityAction<bool>(this._onHaloCloseToggleValueChange));
			bool valueWithDefault = Singleton<SettingManager>.GetInstance().GetValueWithDefault("SETTING_ACTOR_HALO", true);
			this.mHaloOpen.isOn = valueWithDefault;
			this.mHaloClose.isOn = !valueWithDefault;
		}

		// Token: 0x06010736 RID: 67382 RVA: 0x004A1390 File Offset: 0x0049F790
		protected void _unbindExUITown()
		{
			if (this.townSettingSet == null)
			{
				return;
			}
			this.mHaloOpen.onValueChanged.RemoveListener(new UnityAction<bool>(this._onHaloOpenToggleValueChange));
			this.mHaloOpen = null;
			this.mHaloClose.onValueChanged.RemoveListener(new UnityAction<bool>(this._onHaloCloseToggleValueChange));
			this.mHaloClose = null;
		}

		// Token: 0x06010737 RID: 67383 RVA: 0x004A13F5 File Offset: 0x0049F7F5
		private void _onHaloOpenToggleValueChange(bool changed)
		{
			Singleton<SettingManager>.GetInstance().SetValue("SETTING_ACTOR_HALO", true);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnShowTownPlayerHalo, null, null, null, null);
		}

		// Token: 0x06010738 RID: 67384 RVA: 0x004A141A File Offset: 0x0049F81A
		private void _onHaloCloseToggleValueChange(bool changed)
		{
			Singleton<SettingManager>.GetInstance().SetValue("SETTING_ACTOR_HALO", false);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnShowTownPlayerHalo, null, null, null, null);
		}

		// Token: 0x06010739 RID: 67385 RVA: 0x004A1440 File Offset: 0x0049F840
		private void InitDungeonDisBind()
		{
			if (this.mDungeonDisSet == null)
			{
				return;
			}
			this.m_SummonOpenToggle = this.mDungeonDisSet.GetCom<Toggle>("SummonOpen");
			this.m_SummonCloseToggle = this.mDungeonDisSet.GetCom<Toggle>("SummonClose");
			this.m_SkillEffectOpenToggle = this.mDungeonDisSet.GetCom<Toggle>("SkillEffectOpen");
			this.m_SkillEffectCloseToggle = this.mDungeonDisSet.GetCom<Toggle>("SkillEffectClose");
			this.m_HitNumOpenToggle = this.mDungeonDisSet.GetCom<Toggle>("HitNumOpen");
			this.m_HitNumCloseToggle = this.mDungeonDisSet.GetCom<Toggle>("HitNumClose");
			this.mTitleOpenToggle = this.mDungeonDisSet.GetCom<Toggle>("TitleOpen");
			this.mTitleCloseToggle = this.mDungeonDisSet.GetCom<Toggle>("TitleClose");
			if (this.m_SummonOpenToggle != null)
			{
				this.m_SummonOpenToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnSummonSetOpenDis));
			}
			if (this.m_SummonCloseToggle != null)
			{
				this.m_SummonCloseToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnSummonSetCloseDis));
			}
			if (this.m_SkillEffectOpenToggle != null)
			{
				this.m_SkillEffectOpenToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnSkillEffectOpenDis));
			}
			if (this.m_SkillEffectCloseToggle != null)
			{
				this.m_SkillEffectCloseToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnSkillEffectCloseDis));
			}
			if (this.m_HitNumOpenToggle != null)
			{
				this.m_HitNumOpenToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnHitNumOpenDis));
			}
			if (this.m_HitNumCloseToggle != null)
			{
				this.m_HitNumCloseToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnHitNumCloseDis));
			}
			if (this.mTitleOpenToggle != null)
			{
				this.mTitleOpenToggle.onValueChanged.AddListener(new UnityAction<bool>(this._onTitleOpenToggleValueChange));
			}
			if (this.mTitleCloseToggle != null)
			{
				this.mTitleCloseToggle.onValueChanged.AddListener(new UnityAction<bool>(this._onTitleCloseToggleValueChange));
			}
		}

		// Token: 0x0601073A RID: 67386 RVA: 0x004A1678 File Offset: 0x0049FA78
		private void UnInitDungeonDisBind()
		{
			if (this.mDungeonDisSet == null)
			{
				return;
			}
			if (this.m_SummonOpenToggle != null)
			{
				this.m_SummonOpenToggle.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnSummonSetOpenDis));
				this.m_SummonOpenToggle = null;
			}
			if (this.m_SummonCloseToggle != null)
			{
				this.m_SummonCloseToggle.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnSummonSetCloseDis));
				this.m_SummonCloseToggle = null;
			}
			if (this.m_SkillEffectOpenToggle != null)
			{
				this.m_SkillEffectOpenToggle.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnSkillEffectOpenDis));
				this.m_SkillEffectOpenToggle = null;
			}
			if (this.m_SkillEffectCloseToggle != null)
			{
				this.m_SkillEffectCloseToggle.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnSkillEffectCloseDis));
				this.m_SkillEffectCloseToggle = null;
			}
			if (this.m_HitNumOpenToggle != null)
			{
				this.m_HitNumOpenToggle.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnHitNumOpenDis));
				this.m_HitNumOpenToggle = null;
			}
			if (this.m_HitNumCloseToggle != null)
			{
				this.m_HitNumCloseToggle.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnHitNumCloseDis));
				this.m_HitNumCloseToggle = null;
			}
			if (this.mTitleOpenToggle != null)
			{
				this.mTitleOpenToggle.onValueChanged.RemoveListener(new UnityAction<bool>(this._onTitleOpenToggleValueChange));
				this.mTitleOpenToggle = null;
			}
			if (this.mTitleCloseToggle != null)
			{
				this.mTitleCloseToggle.onValueChanged.RemoveListener(new UnityAction<bool>(this._onTitleCloseToggleValueChange));
				this.mTitleCloseToggle = null;
			}
		}

		// Token: 0x0601073B RID: 67387 RVA: 0x004A1837 File Offset: 0x0049FC37
		protected void OnSummonSetOpenDis(bool value)
		{
			this.OnDisSetValueChange(value, "SETTING_SUMMONDISSET", "open");
		}

		// Token: 0x0601073C RID: 67388 RVA: 0x004A184A File Offset: 0x0049FC4A
		protected void OnSummonSetCloseDis(bool value)
		{
			this.OnDisSetValueChange(value, "SETTING_SUMMONDISSET", "close");
		}

		// Token: 0x0601073D RID: 67389 RVA: 0x004A185D File Offset: 0x0049FC5D
		protected void OnSkillEffectOpenDis(bool value)
		{
			this.OnDisSetValueChange(value, "SETTING_SKILLEFFECTSET", "open");
		}

		// Token: 0x0601073E RID: 67390 RVA: 0x004A1870 File Offset: 0x0049FC70
		protected void OnSkillEffectCloseDis(bool value)
		{
			this.OnDisSetValueChange(value, "SETTING_SKILLEFFECTSET", "close");
		}

		// Token: 0x0601073F RID: 67391 RVA: 0x004A1883 File Offset: 0x0049FC83
		protected void OnHitNumOpenDis(bool value)
		{
			this.OnDisSetValueChange(value, "SETTING_HITNUMSET", "open");
		}

		// Token: 0x06010740 RID: 67392 RVA: 0x004A1896 File Offset: 0x0049FC96
		protected void OnHitNumCloseDis(bool value)
		{
			this.OnDisSetValueChange(value, "SETTING_HITNUMSET", "close");
		}

		// Token: 0x06010741 RID: 67393 RVA: 0x004A18A9 File Offset: 0x0049FCA9
		private void _onTitleOpenToggleValueChange(bool value)
		{
			this.OnDisSetValueChange(value, "SETTING_TITLESET", "open");
		}

		// Token: 0x06010742 RID: 67394 RVA: 0x004A18BC File Offset: 0x0049FCBC
		private void _onTitleCloseToggleValueChange(bool value)
		{
			this.OnDisSetValueChange(value, "SETTING_TITLESET", "close");
		}

		// Token: 0x06010743 RID: 67395 RVA: 0x004A18CF File Offset: 0x0049FCCF
		protected void OnDisSetValueChange(bool flag, string key, string value)
		{
			if (!flag)
			{
				return;
			}
			Singleton<SettingManager>.GetInstance().SetCommomData(key, value);
		}

		// Token: 0x06010744 RID: 67396 RVA: 0x004A18E4 File Offset: 0x0049FCE4
		private void InitPkDisBind()
		{
			this.mPKTitleOpen = this.mPKDisSet.GetCom<Toggle>("PKTitleOpen");
			this.mPKTitleOpen.onValueChanged.AddListener(new UnityAction<bool>(this._onPKTitleOpenToggleValueChange));
			this.mPKTitleClose = this.mPKDisSet.GetCom<Toggle>("PKTitleClose");
			this.mPKTitleClose.onValueChanged.AddListener(new UnityAction<bool>(this._onPKTitleCloseToggleValueChange));
			this.mPetOpen = this.mPKDisSet.GetCom<Toggle>("PetOpen");
			this.mPetOpen.onValueChanged.AddListener(new UnityAction<bool>(this._onPetOpenToggleValueChange));
			this.mPetClose = this.mPKDisSet.GetCom<Toggle>("PetClose");
			this.mPetClose.onValueChanged.AddListener(new UnityAction<bool>(this._onPetCloseToggleValueChange));
		}

		// Token: 0x06010745 RID: 67397 RVA: 0x004A19BC File Offset: 0x0049FDBC
		private void UnInitPkDisBind()
		{
			this.mPKTitleOpen.onValueChanged.RemoveListener(new UnityAction<bool>(this._onPKTitleOpenToggleValueChange));
			this.mPKTitleOpen = null;
			this.mPKTitleClose.onValueChanged.RemoveListener(new UnityAction<bool>(this._onPKTitleCloseToggleValueChange));
			this.mPKTitleClose = null;
			this.mPetOpen.onValueChanged.RemoveListener(new UnityAction<bool>(this._onPetOpenToggleValueChange));
			this.mPetOpen = null;
			this.mPetClose.onValueChanged.RemoveListener(new UnityAction<bool>(this._onPetCloseToggleValueChange));
			this.mPetClose = null;
		}

		// Token: 0x06010746 RID: 67398 RVA: 0x004A1A55 File Offset: 0x0049FE55
		private void _onPKTitleOpenToggleValueChange(bool changed)
		{
			this.OnDisSetValueChange(changed, "SETTING_TITLESETPVP", "open");
		}

		// Token: 0x06010747 RID: 67399 RVA: 0x004A1A68 File Offset: 0x0049FE68
		private void _onPKTitleCloseToggleValueChange(bool changed)
		{
			this.OnDisSetValueChange(changed, "SETTING_TITLESETPVP", "close");
		}

		// Token: 0x06010748 RID: 67400 RVA: 0x004A1A7B File Offset: 0x0049FE7B
		private void _onPetOpenToggleValueChange(bool changed)
		{
			this.OnDisSetValueChange(changed, "SETTING_PETDISPLAY", "open");
		}

		// Token: 0x06010749 RID: 67401 RVA: 0x004A1A8E File Offset: 0x0049FE8E
		private void _onPetCloseToggleValueChange(bool changed)
		{
			this.OnDisSetValueChange(changed, "SETTING_PETDISPLAY", "close");
		}

		// Token: 0x0601074A RID: 67402 RVA: 0x004A1AA4 File Offset: 0x0049FEA4
		private void SetDataByGraphicLevel()
		{
			this.RefreshDungeonDisByLevel("SETTING_SUMMONDISSET");
			this.RefreshDungeonDisByLevel("SETTING_SKILLEFFECTSET");
			this.RefreshDungeonDisByLevel("SETTING_HITNUMSET");
			if (this.mHaloOpen != null)
			{
				if (Singleton<GeGraphicSetting>.instance.IsHighLevel() || Singleton<GeGraphicSetting>.instance.IsMiddleLevel())
				{
					this.mHaloOpen.isOn = true;
				}
				else
				{
					this.mHaloClose.isOn = true;
				}
			}
		}

		// Token: 0x0601074B RID: 67403 RVA: 0x004A1B20 File Offset: 0x0049FF20
		private void InitDataByType(string type)
		{
			Toggle dungeonDisToggleByType = this.GetDungeonDisToggleByType(type, true);
			Toggle dungeonDisToggleByType2 = this.GetDungeonDisToggleByType(type, false);
			SettingManager.SetCommonType commmonSet = Singleton<SettingManager>.GetInstance().GetCommmonSet(type);
			if (commmonSet == SettingManager.SetCommonType.None)
			{
				if (type == "SETTING_SUMMONDISSET" || type == "SETTING_SKILLEFFECTSET" || type == "SETTING_HITNUMSET")
				{
					this.SetDataByGraphicLevel();
				}
				else if (type == "SETTING_TITLESET")
				{
					dungeonDisToggleByType.isOn = true;
				}
				else if (type == "SETTING_TITLESETPVP")
				{
					dungeonDisToggleByType.isOn = true;
				}
				else if (type == "SETTING_PETDISPLAY")
				{
					dungeonDisToggleByType.isOn = true;
				}
			}
			else if (commmonSet == SettingManager.SetCommonType.Open)
			{
				dungeonDisToggleByType.isOn = true;
			}
			else
			{
				dungeonDisToggleByType2.isOn = true;
			}
		}

		// Token: 0x0601074C RID: 67404 RVA: 0x004A1BFC File Offset: 0x0049FFFC
		private void RefreshDungeonDisByLevel(string type)
		{
			Toggle dungeonDisToggleByType = this.GetDungeonDisToggleByType(type, true);
			Toggle dungeonDisToggleByType2 = this.GetDungeonDisToggleByType(type, false);
			if (Singleton<GeGraphicSetting>.instance.IsHighLevel() || Singleton<GeGraphicSetting>.instance.IsMiddleLevel())
			{
				dungeonDisToggleByType.isOn = true;
			}
			else
			{
				dungeonDisToggleByType2.isOn = true;
			}
		}

		// Token: 0x0601074D RID: 67405 RVA: 0x004A1C4C File Offset: 0x004A004C
		private Toggle GetDungeonDisToggleByType(string type, bool isOpen)
		{
			Toggle result = null;
			if (type != null)
			{
				if (!(type == "SETTING_SUMMONDISSET"))
				{
					if (!(type == "SETTING_SKILLEFFECTSET"))
					{
						if (!(type == "SETTING_HITNUMSET"))
						{
							if (!(type == "SETTING_TITLESET"))
							{
								if (!(type == "SETTING_TITLESETPVP"))
								{
									if (type == "SETTING_PETDISPLAY")
									{
										result = ((!isOpen) ? this.mPetClose : this.mPetOpen);
									}
								}
								else
								{
									result = ((!isOpen) ? this.mPKTitleClose : this.mPKTitleOpen);
								}
							}
							else
							{
								result = ((!isOpen) ? this.mTitleCloseToggle : this.mTitleOpenToggle);
							}
						}
						else
						{
							result = ((!isOpen) ? this.m_HitNumCloseToggle : this.m_HitNumOpenToggle);
						}
					}
					else
					{
						result = ((!isOpen) ? this.m_SkillEffectCloseToggle : this.m_SkillEffectOpenToggle);
					}
				}
				else
				{
					result = ((!isOpen) ? this.m_SummonCloseToggle : this.m_SummonOpenToggle);
				}
			}
			return result;
		}

		// Token: 0x0400A72E RID: 42798
		private GeUISwitchButton bgSoundSwitch;

		// Token: 0x0400A72F RID: 42799
		private Slider bgVolumnSlider;

		// Token: 0x0400A730 RID: 42800
		private UIGray bgVolumnSliderGray;

		// Token: 0x0400A731 RID: 42801
		private GeUISwitchButton seSoundSwitch;

		// Token: 0x0400A732 RID: 42802
		private Slider seVolumnSlider;

		// Token: 0x0400A733 RID: 42803
		private UIGray seVolumnSliderGray;

		// Token: 0x0400A734 RID: 42804
		private Toggle qualityLv0;

		// Token: 0x0400A735 RID: 42805
		private Toggle qualityLv1;

		// Token: 0x0400A736 RID: 42806
		private Toggle qualityLv2;

		// Token: 0x0400A737 RID: 42807
		private Toggle playerDisplayLv1;

		// Token: 0x0400A738 RID: 42808
		private Toggle playerDisplayLv2;

		// Token: 0x0400A739 RID: 42809
		private Toggle playerDisplayLv3;

		// Token: 0x0400A73A RID: 42810
		private Toggle playerDisplayLv4;

		// Token: 0x0400A73B RID: 42811
		private Toggle playerDisplayLv5;

		// Token: 0x0400A73C RID: 42812
		private Toggle teamAskVibrateSwitch;

		// Token: 0x0400A73D RID: 42813
		private Toggle pk3v3VibrateSwitch;

		// Token: 0x0400A73E RID: 42814
		private Toggle mysteryShopSwitch;

		// Token: 0x0400A73F RID: 42815
		private Toggle inviteFriendLvMask1;

		// Token: 0x0400A740 RID: 42816
		private Toggle inviteFriendLvMask2;

		// Token: 0x0400A741 RID: 42817
		private Toggle inviteFriendLvMask3;

		// Token: 0x0400A742 RID: 42818
		private Toggle inviteFriendLvMask4;

		// Token: 0x0400A743 RID: 42819
		private Toggle guildMask;

		// Token: 0x0400A744 RID: 42820
		private Toggle teamMask;

		// Token: 0x0400A745 RID: 42821
		private Toggle pkMask;

		// Token: 0x0400A746 RID: 42822
		private ComCommonBind mDungeonDisSet;

		// Token: 0x0400A747 RID: 42823
		private ComCommonBind townSettingSet;

		// Token: 0x0400A748 RID: 42824
		private ComCommonBind mPKDisSet;

		// Token: 0x0400A74D RID: 42829
		private Toggle mHaloOpen;

		// Token: 0x0400A74E RID: 42830
		private Toggle mHaloClose;

		// Token: 0x0400A74F RID: 42831
		private Toggle m_SummonOpenToggle;

		// Token: 0x0400A750 RID: 42832
		private Toggle m_SummonCloseToggle;

		// Token: 0x0400A751 RID: 42833
		private Toggle m_SkillEffectOpenToggle;

		// Token: 0x0400A752 RID: 42834
		private Toggle m_SkillEffectCloseToggle;

		// Token: 0x0400A753 RID: 42835
		private Toggle m_HitNumOpenToggle;

		// Token: 0x0400A754 RID: 42836
		private Toggle m_HitNumCloseToggle;

		// Token: 0x0400A755 RID: 42837
		private Toggle mTitleOpenToggle;

		// Token: 0x0400A756 RID: 42838
		private Toggle mTitleCloseToggle;

		// Token: 0x0400A757 RID: 42839
		private Toggle mPKTitleOpen;

		// Token: 0x0400A758 RID: 42840
		private Toggle mPKTitleClose;

		// Token: 0x0400A759 RID: 42841
		private Toggle mPetOpen;

		// Token: 0x0400A75A RID: 42842
		private Toggle mPetClose;
	}
}
