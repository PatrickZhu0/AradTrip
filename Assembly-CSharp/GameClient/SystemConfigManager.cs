using System;
using System.Collections.Generic;
using LitJson;
using Network;
using Protocol;

namespace GameClient
{
	// Token: 0x020045CF RID: 17871
	internal class SystemConfigManager : DataManager<SystemConfigManager>
	{
		// Token: 0x060191C2 RID: 102850 RVA: 0x007EEB39 File Offset: 0x007ECF39
		public override void Initialize()
		{
			this.InviteFriendLvLimit = 0;
			this.MaskGuildInvite = false;
			this.MaskTeamInvite = false;
			this.MaskPkInvite = false;
			this._BindNetMessage();
		}

		// Token: 0x060191C3 RID: 102851 RVA: 0x007EEB60 File Offset: 0x007ECF60
		public override void OnApplicationStart()
		{
			string text = null;
			FileArchiveAccessor.LoadFileInPersistentFileArchive(this.m_kSavePath, out text);
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			this.m_kSystemConfig = JsonMapper.ToObject<SystemConfigData>(text);
			if (this.m_kSystemConfig == null)
			{
				return;
			}
			MonoSingleton<AudioManager>.instance.SetVolume(AudioType.AudioStream, (float)this.m_kSystemConfig.SoundConfig.Volume);
			MonoSingleton<AudioManager>.instance.SetVolume(AudioType.AudioEffect, (float)this.m_kSystemConfig.MusicConfig.Volume);
			MonoSingleton<AudioManager>.instance.SetVolume(AudioType.AudioVoice, (float)this.m_kSystemConfig.MusicConfig.Volume);
			MonoSingleton<AudioManager>.instance.SetMute(AudioType.AudioStream, this.m_kSystemConfig.SoundConfig.Mute);
			MonoSingleton<AudioManager>.instance.SetMute(AudioType.AudioEffect, this.m_kSystemConfig.MusicConfig.Mute);
			MonoSingleton<AudioManager>.instance.SetMute(AudioType.AudioVoice, this.m_kSystemConfig.MusicConfig.Mute);
			Singleton<NpcVoiceCachedManager>.instance.SetVolume((float)this.m_kSystemConfig.MusicConfig.Volume);
			this._InitChatDatas();
		}

		// Token: 0x060191C4 RID: 102852 RVA: 0x007EEC67 File Offset: 0x007ED067
		public override void Clear()
		{
			this.InviteFriendLvLimit = 0;
			this.MaskGuildInvite = false;
			this.MaskTeamInvite = false;
			this.MaskPkInvite = false;
			this._UnBindNetMessage();
		}

		// Token: 0x170020A5 RID: 8357
		// (get) Token: 0x060191C5 RID: 102853 RVA: 0x007EEC8B File Offset: 0x007ED08B
		public List<bool> ChatFilters
		{
			get
			{
				return this.m_akChatToggle;
			}
		}

		// Token: 0x060191C6 RID: 102854 RVA: 0x007EEC94 File Offset: 0x007ED094
		private void _InitChatDatas()
		{
			this.m_akChatToggle.Clear();
			for (int i = 0; i < 13; i++)
			{
				this.m_akChatToggle.Add(false);
			}
			ChatConfig chatConfig = this.SystemConfigData.ChatConfig;
			this.m_akChatToggle[3] = true;
			this.m_akChatToggle[2] = true;
			this.m_akChatToggle[1] = true;
			this.m_akChatToggle[7] = true;
			this.m_akChatToggle[4] = true;
			this.m_akChatToggle[5] = true;
			this.m_akChatToggle[8] = true;
		}

		// Token: 0x060191C7 RID: 102855 RVA: 0x007EED34 File Offset: 0x007ED134
		public void SetChatToggle(ChatType eChatType, bool bValue)
		{
			this.m_akChatToggle[(int)eChatType] = bValue;
			ChatConfig chatConfig = DataManager<SystemConfigManager>.GetInstance().SystemConfigData.ChatConfig;
			switch (eChatType)
			{
			case ChatType.CT_SYSTEM:
				chatConfig.System = bValue;
				break;
			case ChatType.CT_WORLD:
				chatConfig.World = bValue;
				break;
			case ChatType.CT_NORMAL:
				chatConfig.Around = bValue;
				break;
			case ChatType.CT_GUILD:
				chatConfig.Guild = bValue;
				break;
			case ChatType.CT_TEAM:
				chatConfig.Team = bValue;
				break;
			case ChatType.CT_PRIVATE:
				chatConfig.Private = bValue;
				break;
			case ChatType.CT_ACOMMPANY:
				chatConfig.Accompany = bValue;
				break;
			}
			if (this.onChatFilterChanged != null)
			{
				this.onChatFilterChanged(this.m_akChatToggle);
			}
		}

		// Token: 0x060191C8 RID: 102856 RVA: 0x007EEDFC File Offset: 0x007ED1FC
		public bool IsChatToggleOn(ChatType eChatType)
		{
			ChatConfig chatConfig = this.SystemConfigData.ChatConfig;
			switch (eChatType)
			{
			case ChatType.CT_SYSTEM:
				return chatConfig.System;
			case ChatType.CT_WORLD:
				return chatConfig.World;
			case ChatType.CT_NORMAL:
				return chatConfig.Around;
			case ChatType.CT_GUILD:
				return chatConfig.Guild;
			case ChatType.CT_TEAM:
				return chatConfig.Team;
			case ChatType.CT_PRIVATE:
				return chatConfig.Private;
			case ChatType.CT_ACOMMPANY:
				return chatConfig.Accompany;
			}
			return false;
		}

		// Token: 0x060191C9 RID: 102857 RVA: 0x007EEE74 File Offset: 0x007ED274
		public override void OnApplicationQuit()
		{
			this.SaveConfig();
		}

		// Token: 0x060191CA RID: 102858 RVA: 0x007EEE7C File Offset: 0x007ED27C
		private void _BindNetMessage()
		{
		}

		// Token: 0x060191CB RID: 102859 RVA: 0x007EEE7E File Offset: 0x007ED27E
		private void _UnBindNetMessage()
		{
		}

		// Token: 0x060191CC RID: 102860 RVA: 0x007EEE80 File Offset: 0x007ED280
		public void SaveConfig()
		{
			try
			{
				string text = JsonMapper.ToJson(this.SystemConfigData);
				if (!string.IsNullOrEmpty(text))
				{
					FileArchiveAccessor.SaveFileInPersistentFileArchive(this.m_kSavePath, text);
				}
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.ToString());
			}
		}

		// Token: 0x170020A6 RID: 8358
		// (get) Token: 0x060191CD RID: 102861 RVA: 0x007EEED8 File Offset: 0x007ED2D8
		// (set) Token: 0x060191CE RID: 102862 RVA: 0x007EEEE0 File Offset: 0x007ED2E0
		public SystemConfigData SystemConfigData
		{
			get
			{
				return this.m_kSystemConfig;
			}
			set
			{
				this.m_kSystemConfig = value;
			}
		}

		// Token: 0x060191CF RID: 102863 RVA: 0x007EEEEC File Offset: 0x007ED2EC
		public void SendSceneGameSetReq(GameSetType gameSetType, uint setValue)
		{
			SceneGameSetReq sceneGameSetReq = new SceneGameSetReq();
			sceneGameSetReq.gameSetType = (uint)gameSetType;
			sceneGameSetReq.setValue = setValue.ToString();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneGameSetReq>(ServerType.GATE_SERVER, sceneGameSetReq);
		}

		// Token: 0x060191D0 RID: 102864 RVA: 0x007EEF28 File Offset: 0x007ED328
		public void ParseGameSet(string gameSetValue)
		{
			if (string.IsNullOrEmpty(gameSetValue))
			{
				return;
			}
			string[] array = gameSetValue.Split(new char[]
			{
				'|'
			});
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Split(new char[]
				{
					'_'
				});
				if (array2.Length >= 2)
				{
					int num = 0;
					int.TryParse(array2[0], out num);
					if (num == 1)
					{
						int inviteFriendLvLimit = 0;
						int.TryParse(array2[1], out inviteFriendLvLimit);
						this.InviteFriendLvLimit = inviteFriendLvLimit;
					}
					else if (num == 2)
					{
						int num2 = 0;
						int.TryParse(array2[1], out num2);
						this.MaskGuildInvite = ((num2 & 1) == 1);
						this.MaskTeamInvite = ((num2 & 2) == 2);
						this.MaskPkInvite = ((num2 & 4) == 4);
					}
				}
			}
		}

		// Token: 0x170020A7 RID: 8359
		// (get) Token: 0x060191D2 RID: 102866 RVA: 0x007EEFF8 File Offset: 0x007ED3F8
		// (set) Token: 0x060191D1 RID: 102865 RVA: 0x007EEFEF File Offset: 0x007ED3EF
		public int InviteFriendLvLimit { get; private set; }

		// Token: 0x170020A8 RID: 8360
		// (get) Token: 0x060191D4 RID: 102868 RVA: 0x007EF009 File Offset: 0x007ED409
		// (set) Token: 0x060191D3 RID: 102867 RVA: 0x007EF000 File Offset: 0x007ED400
		public bool MaskGuildInvite { get; private set; }

		// Token: 0x170020A9 RID: 8361
		// (get) Token: 0x060191D6 RID: 102870 RVA: 0x007EF01A File Offset: 0x007ED41A
		// (set) Token: 0x060191D5 RID: 102869 RVA: 0x007EF011 File Offset: 0x007ED411
		public bool MaskTeamInvite { get; private set; }

		// Token: 0x170020AA RID: 8362
		// (get) Token: 0x060191D8 RID: 102872 RVA: 0x007EF02B File Offset: 0x007ED42B
		// (set) Token: 0x060191D7 RID: 102871 RVA: 0x007EF022 File Offset: 0x007ED422
		public bool MaskPkInvite { get; private set; }

		// Token: 0x04012003 RID: 73731
		public SystemConfigManager.OnChatFilterChanged onChatFilterChanged;

		// Token: 0x04012004 RID: 73732
		private string m_kSavePath = "systemConfig.json";

		// Token: 0x04012005 RID: 73733
		private List<bool> m_akChatToggle = new List<bool>();

		// Token: 0x04012006 RID: 73734
		private SystemConfigData m_kSystemConfig = new SystemConfigData();

		// Token: 0x020045D0 RID: 17872
		// (Invoke) Token: 0x060191DA RID: 102874
		public delegate void OnChatFilterChanged(List<bool> chatTypes);
	}
}
