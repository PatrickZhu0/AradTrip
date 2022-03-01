using System;
using System.Collections.Generic;
using System.Text;
using Network;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200454C RID: 17740
	public class BattleEasyChatDataManager : DataManager<BattleEasyChatDataManager>
	{
		// Token: 0x17002021 RID: 8225
		// (get) Token: 0x06018B26 RID: 101158 RVA: 0x007B781E File Offset: 0x007B5C1E
		// (set) Token: 0x06018B27 RID: 101159 RVA: 0x007B7826 File Offset: 0x007B5C26
		public ChatType DungeonChatType
		{
			get
			{
				return this.dungeonChatType;
			}
			set
			{
				this.dungeonChatType = value;
			}
		}

		// Token: 0x06018B28 RID: 101160 RVA: 0x007B782F File Offset: 0x007B5C2F
		public override void Clear()
		{
			if (this.m_akChatDataPool != null)
			{
				this.m_akChatDataPool.Clear();
			}
			this.UnRegisterNetHandler();
			this.m_uniqueid = 1200121234;
		}

		// Token: 0x06018B29 RID: 101161 RVA: 0x007B7858 File Offset: 0x007B5C58
		public override void Initialize()
		{
			if (this.m_akChatDataPool == null)
			{
				this.m_akChatDataPool = new Queue<ChatBlock>();
			}
			this.m_akChatDataPool.Clear();
			this.RegisterNetHandler();
			this._LoadChatFrameFont();
		}

		// Token: 0x06018B2A RID: 101162 RVA: 0x007B7888 File Offset: 0x007B5C88
		private void InitTRValue()
		{
			if (this.mEasyChatTips == null)
			{
				this.mEasyChatTips = new List<string>();
			}
			this.mEasyChatTips.Clear();
			string format;
			if (this.IsRaidBattle())
			{
				format = "raid_dungeon_easy_chat_tip{0}";
			}
			else
			{
				format = "dungeon_easy_chat_tip{0}";
			}
			for (int i = 0; i < 6; i++)
			{
				this.mEasyChatTips.Add(TR.Value(string.Format(format, i)));
			}
		}

		// Token: 0x06018B2B RID: 101163 RVA: 0x007B7900 File Offset: 0x007B5D00
		private void UnInitTRValue()
		{
			if (this.mEasyChatTips != null)
			{
				this.mEasyChatTips.Clear();
			}
		}

		// Token: 0x06018B2C RID: 101164 RVA: 0x007B7918 File Offset: 0x007B5D18
		private void RegisterNetHandler()
		{
			NetProcess.AddMsgHandler(500803U, new Action<MsgDATA>(this._OnSyncChat));
		}

		// Token: 0x06018B2D RID: 101165 RVA: 0x007B7930 File Offset: 0x007B5D30
		private void UnRegisterNetHandler()
		{
			NetProcess.RemoveMsgHandler(500803U, new Action<MsgDATA>(this._OnSyncChat));
		}

		// Token: 0x06018B2E RID: 101166 RVA: 0x007B7948 File Offset: 0x007B5D48
		public void SendEasyChatTipsByIndex(int index)
		{
			if (this.mEasyChatTips == null || (index > this.mEasyChatTips.Count - 1 && index < 0))
			{
				return;
			}
			DataManager<ChatManager>.GetInstance().SendChat(this.dungeonChatType, this.mEasyChatTips[index], 0UL, 0);
		}

		// Token: 0x06018B2F RID: 101167 RVA: 0x007B799A File Offset: 0x007B5D9A
		public void SendBattleChatMsg(string content)
		{
			DataManager<ChatManager>.GetInstance().SendChat(this.dungeonChatType, content, 0UL, 0);
		}

		// Token: 0x06018B30 RID: 101168 RVA: 0x007B79B0 File Offset: 0x007B5DB0
		public string GetEasyChatStringByIndex(int index)
		{
			if (this.mEasyChatTips == null || (index > this.mEasyChatTips.Count - 1 && index < 0))
			{
				return string.Empty;
			}
			return this.mEasyChatTips[index];
		}

		// Token: 0x06018B31 RID: 101169 RVA: 0x007B79E9 File Offset: 0x007B5DE9
		public void SetReceiveNetMsg()
		{
			this.InitTRValue();
		}

		// Token: 0x06018B32 RID: 101170 RVA: 0x007B79F1 File Offset: 0x007B5DF1
		public void SetRejectNetMsg()
		{
			this.UnInitTRValue();
		}

		// Token: 0x06018B33 RID: 101171 RVA: 0x007B79F9 File Offset: 0x007B5DF9
		public int GetChatDataArrayLength()
		{
			if (this.m_bDirty)
			{
				this.mChatDataArray = this.m_akChatDataPool.ToArray();
				this.m_bDirty = false;
			}
			if (this.mChatDataArray == null)
			{
				return 0;
			}
			return this.mChatDataArray.Length;
		}

		// Token: 0x06018B34 RID: 101172 RVA: 0x007B7A34 File Offset: 0x007B5E34
		public List<Vector2> GetChatDataArraySize()
		{
			if (this.m_bDirty)
			{
				this.mChatDataArray = this.m_akChatDataPool.ToArray();
				this.m_bDirty = false;
			}
			List<Vector2> list = new List<Vector2>();
			for (int i = 0; i < this.mChatDataArray.Length; i++)
			{
				List<Vector2> list2 = list;
				Vector2 item = default(Vector2);
				item.x = 258.8f;
				item.y = (float)this.mChatDataArray[i].chatData.height + 58.8f;
				list2.Add(item);
			}
			return list;
		}

		// Token: 0x06018B35 RID: 101173 RVA: 0x007B7AC0 File Offset: 0x007B5EC0
		public ChatBlock GetChatBlockByIndex(int index)
		{
			if (this.m_bDirty)
			{
				this.mChatDataArray = this.m_akChatDataPool.ToArray();
				this.m_bDirty = false;
			}
			if (this.mChatDataArray == null || index < 0 || index >= this.mChatDataArray.Length)
			{
				return null;
			}
			return this.mChatDataArray[index];
		}

		// Token: 0x06018B36 RID: 101174 RVA: 0x007B7B1C File Offset: 0x007B5F1C
		private void _OnSyncChat(MsgDATA msg)
		{
			int num = 0;
			SceneSyncChat sceneSyncChat = new SceneSyncChat();
			sceneSyncChat.decode(msg.bytes, ref num);
			if (this.IsRaidBattle())
			{
				if (sceneSyncChat.channel != 14 && sceneSyncChat.channel != 13)
				{
					return;
				}
			}
			else if (sceneSyncChat.channel != 2)
			{
				return;
			}
			ChatBlock chatBlock = this._NetData2LocalData(sceneSyncChat);
			if (chatBlock != null)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DungeonChatMsgDataUpdate, chatBlock, null, null, null);
			}
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemBattle;
			if (!Singleton<ClientSystemManager>.instance.IsFrameOpen<DungeonChatRecordFrame>(null) && !Singleton<ClientSystemManager>.instance.IsFrameOpen<DungeonTeamChatFrame>(null) && clientSystemBattle != null)
			{
				Singleton<ClientSystemManager>.instance.OpenFrame<DungeonChatRecordFrame>((BattleMain.battleType != BattleType.RaidPVE) ? FrameLayer.Middle : FrameLayer.HorseLamp, new object[]
				{
					chatBlock,
					BattleMain.battleType == BattleType.RaidPVE
				}, string.Empty);
			}
		}

		// Token: 0x06018B37 RID: 101175 RVA: 0x007B7C0C File Offset: 0x007B600C
		private ChatBlock _NetData2LocalData(SceneSyncChat data)
		{
			ChatBlock chatBlock = this._AllocChatData();
			ChatData chatData = chatBlock.chatData;
			chatData.channel = data.channel;
			chatData.objid = data.objid;
			chatData.sex = data.sex;
			chatData.occu = data.occu;
			chatData.level = data.level;
			chatData.viplvl = data.viplvl;
			chatData.objname = data.objname;
			RelationData relationData = null;
			DataManager<RelationDataManager>.GetInstance().FindPlayerIsRelation(chatData.objid, ref relationData);
			if (relationData != null && relationData.remark != null && relationData.remark != string.Empty)
			{
				chatData.objname = relationData.remark;
			}
			chatData.word = data.word;
			chatData.guid = ++this.m_uniqueid;
			chatData.shortTimeString = "[" + DataManager<TimeManager>.GetInstance().GetTimeT() + "]";
			chatData.targetID = data.receiverId;
			chatData.eChatType = DataManager<ChatManager>.GetInstance()._TransChanelType((ChanelType)chatData.channel);
			chatData.dirty = true;
			chatData.bLink = data.bLink;
			chatData.bGm = (data.isGm == 1);
			chatData.voiceKey = data.voiceKey;
			chatData.voiceDuration = data.voiceDuration;
			chatData.bVoice = (!string.IsNullOrEmpty(data.voiceKey) && data.voiceKey.Length > 1);
			chatData.bHorn = false;
			chatData.bRedPacket = ((data.mask & 1U) == 1U);
			chatData.timeStamp = DataManager<TimeManager>.GetInstance().GetServerTime();
			chatData.isShowTimeStamp = false;
			chatData.bAddFriend = ((data.mask & 2U) == 2U);
			chatData.headFrame = data.headFrame;
			chatData.zoneId = data.zoneId;
			chatData.bNotHeadPoint = ((data.mask & 4U) == 4U);
			chatData.bSystem = ((data.mask & 8U) == 8U);
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			LinkParse._TryToken(stringBuilder, chatData.word, 0, null, LinkParse.EmotionSizeType.EST_72);
			string text = stringBuilder.ToString();
			chatData.height = (int)(this.GetContentHeightByGenerator(text) + 0.5f);
			StringBuilderCache.Release(stringBuilder);
			return chatBlock;
		}

		// Token: 0x06018B38 RID: 101176 RVA: 0x007B7E44 File Offset: 0x007B6244
		private ChatBlock _AllocChatData()
		{
			this.m_bDirty = true;
			ChatBlock chatBlock;
			if (this.m_akChatDataPool.Count < 20)
			{
				chatBlock = new ChatBlock
				{
					chatData = new ChatData(),
					eType = ChatBlockType.CBT_NEW,
					iPreID = 0UL
				};
				this.m_akChatDataPool.Enqueue(chatBlock);
				return chatBlock;
			}
			chatBlock = this.m_akChatDataPool.Dequeue();
			this.m_akChatDataPool.Enqueue(chatBlock);
			if (chatBlock.eType == ChatBlockType.CBT_KEEP)
			{
				chatBlock.iPreID = (ulong)((long)chatBlock.chatData.guid);
				chatBlock.eType = ChatBlockType.CBT_REBUILD;
			}
			else if (chatBlock.eType == ChatBlockType.CBT_NEW)
			{
				chatBlock.eType = ChatBlockType.CBT_NEW;
			}
			else if (chatBlock.eType == ChatBlockType.CBT_REBUILD)
			{
				chatBlock.eType = ChatBlockType.CBT_REBUILD;
			}
			return chatBlock;
		}

		// Token: 0x06018B39 RID: 101177 RVA: 0x007B7F0C File Offset: 0x007B630C
		private void _LoadChatFrameFont()
		{
			string text = TR.Value("dungeon_battle_chat_frame_font");
			this.font = (Singleton<AssetLoader>.instance.LoadRes(TR.Value("dungeon_battle_chat_frame_font"), typeof(Font), true, 0U).obj as Font);
			if (null == this.font)
			{
				Logger.LogErrorFormat("font cant not be found {0}", new object[]
				{
					TR.Value("ChatFrameFont")
				});
				return;
			}
			int.TryParse(TR.Value("dungeon_battle_chat_frame_font_size"), out this.m_fontsize);
			int num = 0;
			this.m_eFontStyle = 0;
			if (int.TryParse(TR.Value("dungeon_battle_chat_frame_font_type"), out num) && num >= 0 && num <= 3)
			{
				this.m_eFontStyle = num;
			}
			float.TryParse(TR.Value("dungeon_battle_chat_frame_text_max_width"), out this.m_fChatFrameMaxWidth);
		}

		// Token: 0x06018B3A RID: 101178 RVA: 0x007B7FE4 File Offset: 0x007B63E4
		public float GetContentHeightByGenerator(string text)
		{
			if (this.cachedTextGenerator == null)
			{
				this.cachedTextGenerator = new TextGenerator(256);
				this.textGeneratorSetting.font = this.font;
				this.textGeneratorSetting.fontSize = this.m_fontsize;
				this.textGeneratorSetting.fontStyle = this.m_eFontStyle;
				this.textGeneratorSetting.lineSpacing = 1f;
				this.textGeneratorSetting.horizontalOverflow = 0;
				this.textGeneratorSetting.verticalOverflow = 1;
				this.textGeneratorSetting.alignByGeometry = false;
				this.textGeneratorSetting.resizeTextForBestFit = false;
				this.textGeneratorSetting.richText = true;
				this.textGeneratorSetting.scaleFactor = 1f;
				this.textGeneratorSetting.updateBounds = false;
				this.textGeneratorSetting.generationExtents = new Vector2(244f, 0f);
			}
			return this.cachedTextGenerator.GetPreferredHeight(string.Format("XX", text), this.textGeneratorSetting);
		}

		// Token: 0x06018B3B RID: 101179 RVA: 0x007B80E0 File Offset: 0x007B64E0
		private bool IsRaidBattle()
		{
			bool flag = TeamDuplicationUtility.IsInTeamDuplicationScene();
			bool flag2 = BeUtility.IsRaidBattle();
			return flag || flag2;
		}

		// Token: 0x04011CC9 RID: 72905
		private ChatType dungeonChatType = ChatType.CT_TEAM;

		// Token: 0x04011CCA RID: 72906
		public bool isRaidBattle;

		// Token: 0x04011CCB RID: 72907
		public List<string> mEasyChatTips = new List<string>();

		// Token: 0x04011CCC RID: 72908
		private const string dungeonEasyChatTR = "dungeon_easy_chat_tip{0}";

		// Token: 0x04011CCD RID: 72909
		private const string raidDungeonEasyChatTR = "raid_dungeon_easy_chat_tip{0}";

		// Token: 0x04011CCE RID: 72910
		private Font font;

		// Token: 0x04011CCF RID: 72911
		private int m_fontsize = 27;

		// Token: 0x04011CD0 RID: 72912
		private FontStyle m_eFontStyle;

		// Token: 0x04011CD1 RID: 72913
		private float m_fChatFrameMaxWidth = 244f;

		// Token: 0x04011CD2 RID: 72914
		private TextGenerator cachedTextGenerator;

		// Token: 0x04011CD3 RID: 72915
		private TextGenerationSettings textGeneratorSetting = default(TextGenerationSettings);

		// Token: 0x04011CD4 RID: 72916
		private Queue<ChatBlock> m_akChatDataPool = new Queue<ChatBlock>();

		// Token: 0x04011CD5 RID: 72917
		private ChatBlock[] mChatDataArray;

		// Token: 0x04011CD6 RID: 72918
		private bool m_bDirty;

		// Token: 0x04011CD7 RID: 72919
		private const int CHAT_BLOCK_MAX_SIZE = 20;

		// Token: 0x04011CD8 RID: 72920
		protected int m_uniqueid;
	}
}
