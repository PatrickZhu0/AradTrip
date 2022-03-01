using System;
using System.Text;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001543 RID: 5443
	public class ChatData
	{
		// Token: 0x0600D499 RID: 54425 RVA: 0x003510C7 File Offset: 0x0034F4C7
		public string GetWords()
		{
			if (!this.bGm)
			{
				return this.word;
			}
			return "<color=#FFFF00>" + this.word + "</color>";
		}

		// Token: 0x0600D49A RID: 54426 RVA: 0x003510F0 File Offset: 0x0034F4F0
		public bool IsWordsEmpty()
		{
			return string.IsNullOrEmpty(this.word);
		}

		// Token: 0x0600D49B RID: 54427 RVA: 0x00351100 File Offset: 0x0034F500
		public string GetNameLink()
		{
			if (string.IsNullOrEmpty(this.objname))
			{
				return string.Empty;
			}
			if (!this.bGm)
			{
				if (this.objid == 0UL)
				{
					return string.Empty;
				}
				MyExtensionMethods.Clear(ChatData.kBuilder);
				ChatData.kBuilder.Append("{P ");
				ChatData.kBuilder.AppendFormat("{0} {1} {2} {3}", new object[]
				{
					this.objid,
					this.objname,
					this.occu,
					this.level
				});
				ChatData.kBuilder.Append("}");
			}
			else
			{
				MyExtensionMethods.Clear(ChatData.kBuilder);
				ChatData.kBuilder.AppendFormat(TR.Value("chat_gm_name"), this.objname);
			}
			return ChatData.kBuilder.ToString();
		}

		// Token: 0x0600D49C RID: 54428 RVA: 0x003511F0 File Offset: 0x0034F5F0
		public string GetChannelString()
		{
			if (this.bHorn)
			{
				return TR.Value("chat_channel_horn");
			}
			if (this.eChatType >= ChatType.CT_ALL && this.eChatType < (ChatType)ChatData.ms_channel_string.Length)
			{
				return TR.Value(ChatData.ms_channel_string[(int)this.eChatType]);
			}
			return null;
		}

		// Token: 0x0600D49D RID: 54429 RVA: 0x00351244 File Offset: 0x0034F644
		public static string GetChannelString(ChatType eChatType)
		{
			if (eChatType >= ChatType.CT_ALL && eChatType < (ChatType)ChatData.ms_channel_string.Length)
			{
				return TR.Value(ChatData.ms_channel_string[(int)eChatType]);
			}
			return null;
		}

		// Token: 0x0600D49E RID: 54430 RVA: 0x00351268 File Offset: 0x0034F668
		public void GetSystemIcon(ref Image img)
		{
			ETCImageLoader.LoadSprite(ref img, "UI/Image/Packed/p_UI_Chat.png:UI_Liaotian_Tubiao_Xitong", true);
		}

		// Token: 0x04007CC0 RID: 31936
		public const ushort CD_MAX_WORDS = 100;

		// Token: 0x04007CC1 RID: 31937
		public byte channel;

		// Token: 0x04007CC2 RID: 31938
		public ulong objid;

		// Token: 0x04007CC3 RID: 31939
		public byte sex;

		// Token: 0x04007CC4 RID: 31940
		public byte occu;

		// Token: 0x04007CC5 RID: 31941
		public ushort level;

		// Token: 0x04007CC6 RID: 31942
		public byte viplvl;

		// Token: 0x04007CC7 RID: 31943
		public string objname;

		// Token: 0x04007CC8 RID: 31944
		public string word;

		// Token: 0x04007CC9 RID: 31945
		public int guid;

		// Token: 0x04007CCA RID: 31946
		public string shortTimeString;

		// Token: 0x04007CCB RID: 31947
		public ulong targetID;

		// Token: 0x04007CCC RID: 31948
		public byte bLink;

		// Token: 0x04007CCD RID: 31949
		public bool bGm;

		// Token: 0x04007CCE RID: 31950
		public string voiceKey;

		// Token: 0x04007CCF RID: 31951
		public byte voiceDuration;

		// Token: 0x04007CD0 RID: 31952
		public bool bVoice;

		// Token: 0x04007CD1 RID: 31953
		public bool bVoicePlayFirst;

		// Token: 0x04007CD2 RID: 31954
		public bool bHorn;

		// Token: 0x04007CD3 RID: 31955
		public bool bRedPacket;

		// Token: 0x04007CD4 RID: 31956
		public uint timeStamp;

		// Token: 0x04007CD5 RID: 31957
		public bool bAddFriend;

		// Token: 0x04007CD6 RID: 31958
		public bool bNotHeadPoint;

		// Token: 0x04007CD7 RID: 31959
		public bool bSystem;

		// Token: 0x04007CD8 RID: 31960
		public bool dirty;

		// Token: 0x04007CD9 RID: 31961
		public ChatType eChatType;

		// Token: 0x04007CDA RID: 31962
		public int height;

		// Token: 0x04007CDB RID: 31963
		public bool isShowTimeStamp;

		// Token: 0x04007CDC RID: 31964
		public uint headFrame;

		// Token: 0x04007CDD RID: 31965
		public uint zoneId;

		// Token: 0x04007CDE RID: 31966
		private static StringBuilder kBuilder = StringBuilderCache.Acquire(256);

		// Token: 0x04007CDF RID: 31967
		private static string[] ms_channel_string = new string[]
		{
			string.Empty,
			"chat_chanel_system",
			"chat_chanel_world",
			"chat_chanel_normal",
			"chat_chanel_guild",
			"chat_chanel_team",
			string.Empty,
			"chat_chanel_private",
			"chat_chanel_accompany",
			string.Empty,
			"chat_chanel_team_copy_prepare",
			"chat_chanel_team_copy_team",
			"chat_chanel_team_copy_squad"
		};

		// Token: 0x04007CE0 RID: 31968
		private static string ms_horn_string = "chat_channel_horn";
	}
}
