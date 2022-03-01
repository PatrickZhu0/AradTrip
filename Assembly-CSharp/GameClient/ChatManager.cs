using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x0200455A RID: 17754
	public class ChatManager : DataManager<ChatManager>
	{
		// Token: 0x06018BCA RID: 101322 RVA: 0x007BAD55 File Offset: 0x007B9155
		public static int GetMapIndex(int iIndex)
		{
			return ChatManager.ms_sort_orders[iIndex];
		}

		// Token: 0x1700203C RID: 8252
		// (get) Token: 0x06018BCB RID: 101323 RVA: 0x007BAD5E File Offset: 0x007B915E
		// (set) Token: 0x06018BCC RID: 101324 RVA: 0x007BAD65 File Offset: 0x007B9165
		public static bool IsAcceptStrangerInfo
		{
			get
			{
				return ChatManager.isAcceptStrangerInfo;
			}
			set
			{
				ChatManager.isAcceptStrangerInfo = value;
			}
		}

		// Token: 0x1700203D RID: 8253
		// (get) Token: 0x06018BCD RID: 101325 RVA: 0x007BAD70 File Offset: 0x007B9170
		public static int ms_accompany_cool_down
		{
			get
			{
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(183, string.Empty, string.Empty);
				if (tableItem != null)
				{
					return tableItem.Value;
				}
				return 15;
			}
		}

		// Token: 0x1700203E RID: 8254
		// (get) Token: 0x06018BCE RID: 101326 RVA: 0x007BADA6 File Offset: 0x007B91A6
		public static int accompany_cool_time
		{
			get
			{
				return ChatManager.ms_accompany_cool_time;
			}
		}

		// Token: 0x06018BCF RID: 101327 RVA: 0x007BADB0 File Offset: 0x007B91B0
		public static bool accompany_chat_try_enter_cool_down()
		{
			if (ChatManager.ms_accompany_cool_time <= 0)
			{
				ChatManager.ms_accompany_cool_time = ChatManager.ms_accompany_cool_down;
				InvokeMethod.RmoveInvokeIntervalCall(ChatManager.ms_accompany_cool_time);
				InvokeMethod.InvokeInterval(ChatManager.ms_accompany_cool_time, 0f, 1f, (float)ChatManager.ms_accompany_cool_down, delegate
				{
					ChatManager.ms_accompany_cool_time = ChatManager.ms_accompany_cool_down;
				}, delegate
				{
					ChatManager.ms_accompany_cool_time--;
					if (ChatManager.ms_accompany_cool_time < 0)
					{
						ChatManager.ms_accompany_cool_time = 0;
					}
				}, delegate
				{
					ChatManager.ms_accompany_cool_time = 0;
				});
				return true;
			}
			return false;
		}

		// Token: 0x1700203F RID: 8255
		// (get) Token: 0x06018BD0 RID: 101328 RVA: 0x007BAE58 File Offset: 0x007B9258
		public static int ms_arround_cool_down
		{
			get
			{
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(182, string.Empty, string.Empty);
				if (tableItem != null)
				{
					return tableItem.Value;
				}
				return 15;
			}
		}

		// Token: 0x17002040 RID: 8256
		// (get) Token: 0x06018BD1 RID: 101329 RVA: 0x007BAE8E File Offset: 0x007B928E
		public static int ms_teamcopy_prepare_cool_down
		{
			get
			{
				return Utility.GetSystemValueFromTable(SystemValueTable.eType3.SVT_TEAMCOPY_PREPARE_CHANNEL_CD, 30);
			}
		}

		// Token: 0x17002041 RID: 8257
		// (get) Token: 0x06018BD2 RID: 101330 RVA: 0x007BAE9C File Offset: 0x007B929C
		public static int ms_teamcopy_team_cool_down
		{
			get
			{
				return Utility.GetSystemValueFromTable(SystemValueTable.eType3.SVT_TEAMCOPY_TEAM_CHANNEL_CD, 5);
			}
		}

		// Token: 0x17002042 RID: 8258
		// (get) Token: 0x06018BD3 RID: 101331 RVA: 0x007BAEA9 File Offset: 0x007B92A9
		public static int ms_teamcopy_squad_cool_down
		{
			get
			{
				return Utility.GetSystemValueFromTable(SystemValueTable.eType3.SVT_TEAMCOPY_SQUAD_CHANNEL_CD, 5);
			}
		}

		// Token: 0x17002043 RID: 8259
		// (get) Token: 0x06018BD4 RID: 101332 RVA: 0x007BAEB6 File Offset: 0x007B92B6
		public static int arround_cool_time
		{
			get
			{
				return ChatManager.ms_arround_cool_time;
			}
		}

		// Token: 0x17002044 RID: 8260
		// (get) Token: 0x06018BD5 RID: 101333 RVA: 0x007BAEBD File Offset: 0x007B92BD
		public static int teamcopy_prepare_cool_time
		{
			get
			{
				return ChatManager.ms_teamcopy_prepare_cool_time;
			}
		}

		// Token: 0x17002045 RID: 8261
		// (get) Token: 0x06018BD6 RID: 101334 RVA: 0x007BAEC4 File Offset: 0x007B92C4
		public static int teamcopy_team_cool_time
		{
			get
			{
				return ChatManager.ms_teamcopy_team_cool_time;
			}
		}

		// Token: 0x17002046 RID: 8262
		// (get) Token: 0x06018BD7 RID: 101335 RVA: 0x007BAECB File Offset: 0x007B92CB
		public static int teamcopy_squad_cool_time
		{
			get
			{
				return ChatManager.ms_teamcopy_squad_cool_time;
			}
		}

		// Token: 0x06018BD8 RID: 101336 RVA: 0x007BAED4 File Offset: 0x007B92D4
		public static bool arround_chat_try_enter_cool_down()
		{
			if (ChatManager.ms_arround_cool_time <= 0)
			{
				ChatManager.ms_arround_cool_time = ChatManager.ms_arround_cool_down;
				InvokeMethod.RmoveInvokeIntervalCall(ChatManager.ms_arround_cool_time);
				InvokeMethod.InvokeInterval(ChatManager.ms_arround_cool_time, 0f, 1f, (float)ChatManager.ms_arround_cool_down, delegate
				{
					ChatManager.ms_arround_cool_time = ChatManager.ms_arround_cool_down;
				}, delegate
				{
					ChatManager.ms_arround_cool_time--;
					if (ChatManager.ms_arround_cool_time < 0)
					{
						ChatManager.ms_arround_cool_time = 0;
					}
				}, delegate
				{
					ChatManager.ms_arround_cool_time = 0;
				});
				return true;
			}
			return false;
		}

		// Token: 0x06018BD9 RID: 101337 RVA: 0x007BAF7C File Offset: 0x007B937C
		public static bool teamcopy_prepare_chat_try_enter_cool_down()
		{
			if (ChatManager.ms_teamcopy_prepare_cool_time <= 0)
			{
				ChatManager.ms_teamcopy_prepare_cool_time = ChatManager.ms_teamcopy_prepare_cool_down;
				InvokeMethod.RmoveInvokeIntervalCall(ChatManager.ms_teamcopy_prepare_cool_time);
				InvokeMethod.InvokeInterval(ChatManager.ms_teamcopy_prepare_cool_time, 0f, 1f, (float)ChatManager.ms_teamcopy_prepare_cool_down, delegate
				{
					ChatManager.ms_teamcopy_prepare_cool_time = ChatManager.ms_teamcopy_prepare_cool_down;
				}, delegate
				{
					ChatManager.ms_teamcopy_prepare_cool_time--;
					if (ChatManager.ms_teamcopy_prepare_cool_time < 0)
					{
						ChatManager.ms_teamcopy_prepare_cool_time = 0;
					}
				}, delegate
				{
					ChatManager.ms_teamcopy_prepare_cool_time = 0;
				});
				return true;
			}
			return false;
		}

		// Token: 0x06018BDA RID: 101338 RVA: 0x007BB024 File Offset: 0x007B9424
		public static bool teamcopy_team_chat_try_enter_cool_down()
		{
			if (ChatManager.ms_teamcopy_team_cool_time <= 0)
			{
				ChatManager.ms_teamcopy_team_cool_time = ChatManager.ms_teamcopy_team_cool_down;
				InvokeMethod.RmoveInvokeIntervalCall(ChatManager.ms_teamcopy_team_cool_time);
				InvokeMethod.InvokeInterval(ChatManager.ms_teamcopy_team_cool_time, 0f, 1f, (float)ChatManager.ms_teamcopy_team_cool_down, delegate
				{
					ChatManager.ms_teamcopy_team_cool_time = ChatManager.ms_teamcopy_team_cool_down;
				}, delegate
				{
					ChatManager.ms_teamcopy_team_cool_time--;
					if (ChatManager.ms_teamcopy_team_cool_time < 0)
					{
						ChatManager.ms_teamcopy_team_cool_time = 0;
					}
				}, delegate
				{
					ChatManager.ms_teamcopy_team_cool_time = 0;
				});
				return true;
			}
			return false;
		}

		// Token: 0x06018BDB RID: 101339 RVA: 0x007BB0CC File Offset: 0x007B94CC
		public static bool teamcopy_squad_chat_try_enter_cool_down()
		{
			if (ChatManager.ms_teamcopy_squad_cool_time <= 0)
			{
				ChatManager.ms_teamcopy_squad_cool_time = ChatManager.ms_teamcopy_squad_cool_down;
				InvokeMethod.RmoveInvokeIntervalCall(ChatManager.ms_teamcopy_squad_cool_time);
				InvokeMethod.InvokeInterval(ChatManager.ms_teamcopy_squad_cool_time, 0f, 1f, (float)ChatManager.ms_teamcopy_squad_cool_down, delegate
				{
					ChatManager.ms_teamcopy_squad_cool_time = ChatManager.ms_teamcopy_squad_cool_down;
				}, delegate
				{
					ChatManager.ms_teamcopy_squad_cool_time--;
					if (ChatManager.ms_teamcopy_squad_cool_time < 0)
					{
						ChatManager.ms_teamcopy_squad_cool_time = 0;
					}
				}, delegate
				{
					ChatManager.ms_teamcopy_squad_cool_time = 0;
				});
				return true;
			}
			return false;
		}

		// Token: 0x17002047 RID: 8263
		// (get) Token: 0x06018BDC RID: 101340 RVA: 0x007BB174 File Offset: 0x007B9574
		public static int ms_world_cool_down
		{
			get
			{
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(181, string.Empty, string.Empty);
				if (tableItem != null)
				{
					return tableItem.Value;
				}
				return 15;
			}
		}

		// Token: 0x17002048 RID: 8264
		// (get) Token: 0x06018BDD RID: 101341 RVA: 0x007BB1AA File Offset: 0x007B95AA
		public static int world_cool_time
		{
			get
			{
				return ChatManager.ms_world_cool_time;
			}
		}

		// Token: 0x06018BDE RID: 101342 RVA: 0x007BB1B4 File Offset: 0x007B95B4
		public static bool world_chat_try_enter_cool_down()
		{
			if (ChatManager.ms_world_cool_time <= 0)
			{
				ChatManager.ms_world_cool_time = ChatManager.ms_world_cool_down;
				InvokeMethod.RmoveInvokeIntervalCall(ChatManager.ms_world_cool_time);
				InvokeMethod.InvokeInterval(ChatManager.ms_world_cool_time, 0f, 1f, (float)ChatManager.ms_world_cool_down, delegate
				{
					ChatManager.ms_world_cool_time = ChatManager.ms_world_cool_down;
				}, delegate
				{
					ChatManager.ms_world_cool_time--;
					if (ChatManager.ms_world_cool_time < 0)
					{
						ChatManager.ms_world_cool_time = 0;
					}
				}, delegate
				{
					ChatManager.ms_world_cool_time = 0;
				});
				return true;
			}
			return false;
		}

		// Token: 0x17002049 RID: 8265
		// (get) Token: 0x06018BDF RID: 101343 RVA: 0x007BB25C File Offset: 0x007B965C
		public static int WorldChatCostActivityValue
		{
			get
			{
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(178, string.Empty, string.Empty);
				if (tableItem != null)
				{
					return tableItem.Value;
				}
				return 0;
			}
		}

		// Token: 0x1700204A RID: 8266
		// (get) Token: 0x06018BE0 RID: 101344 RVA: 0x007BB294 File Offset: 0x007B9694
		public int FreeWorldChatLeftTimes
		{
			get
			{
				int count = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_WORLD_FREE_CHAT_TIMES);
				int num = (int)Utility.GetCurVipLevelPrivilegeData(VipPrivilegeTable.eType.WORLD_CHAT_FREE_TIMES);
				int num2 = num - count;
				return (int)IntMath.Clamp((long)num2, 0L, (long)num);
			}
		}

		// Token: 0x06018BE1 RID: 101345 RVA: 0x007BB2CE File Offset: 0x007B96CE
		public bool CheckWorldActivityValueEnough()
		{
			return ChatManager.WorldChatCostActivityValue <= DataManager<PlayerBaseData>.GetInstance().ActivityValue;
		}

		// Token: 0x06018BE2 RID: 101346 RVA: 0x007BB2E8 File Offset: 0x007B96E8
		private void RegisterNetHandler()
		{
			NetProcess.AddMsgHandler(500803U, new Action<MsgDATA>(this._OnSyncChat));
			NetProcess.AddMsgHandler(600815U, new Action<MsgDATA>(this._WorldChatHorn));
			NetProcess.AddMsgHandler(1100012U, new Action<MsgDATA>(this._TeamCopyTeamQuitRes));
		}

		// Token: 0x06018BE3 RID: 101347 RVA: 0x007BB338 File Offset: 0x007B9738
		private void UnRegisterNetHandler()
		{
			NetProcess.RemoveMsgHandler(500803U, new Action<MsgDATA>(this._OnSyncChat));
			NetProcess.RemoveMsgHandler(600815U, new Action<MsgDATA>(this._WorldChatHorn));
			NetProcess.RemoveMsgHandler(1100012U, new Action<MsgDATA>(this._TeamCopyTeamQuitRes));
		}

		// Token: 0x06018BE4 RID: 101348 RVA: 0x007BB388 File Offset: 0x007B9788
		public override void Initialize()
		{
			this.RegisterNetHandler();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RoleIdChanged, new ClientEventSystem.UIEventHandler(this._OnRoleIdChanged));
			ChatRecordManager instance = DataManager<ChatRecordManager>.GetInstance();
			instance.onLoadPrivateChatDataOK = (ChatRecordManager.OnLoadPrivateChatDataOK)Delegate.Combine(instance.onLoadPrivateChatDataOK, new ChatRecordManager.OnLoadPrivateChatDataOK(this._OnLoadPrivateChatDataOK));
			this._LoadChatFrameFont();
			this.privateChatLimitLevel = this.GetPrivateChatLimitLevel();
		}

		// Token: 0x06018BE5 RID: 101349 RVA: 0x007BB3F0 File Offset: 0x007B97F0
		private void _LoadChatFrameFont()
		{
			string text = TR.Value("chat_frame_font");
			this.font = (Singleton<AssetLoader>.instance.LoadRes(TR.Value("chat_frame_font"), typeof(Font), true, 0U).obj as Font);
			if (null == this.font)
			{
				Logger.LogErrorFormat("font cant not be found {0}", new object[]
				{
					TR.Value("ChatFrameFont")
				});
				return;
			}
			this.m_fontsize = 35;
			int.TryParse(TR.Value("chat_frame_font_size"), out this.m_fontsize);
			int num = 0;
			this.m_eFontStyle = 0;
			if (int.TryParse(TR.Value("chat_frame_font_type"), out num) && num >= 0 && num <= 3)
			{
				this.m_eFontStyle = num;
			}
			float.TryParse(TR.Value("chat_frame_text_max_width"), out this.m_fChatFrameMaxWidth);
		}

		// Token: 0x06018BE6 RID: 101350 RVA: 0x007BB4D0 File Offset: 0x007B98D0
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
				this.textGeneratorSetting.generationExtents = new Vector2(650f, 0f);
			}
			return this.cachedTextGenerator.GetPreferredHeight(text, this.textGeneratorSetting);
		}

		// Token: 0x06018BE7 RID: 101351 RVA: 0x007BB5C4 File Offset: 0x007B99C4
		public float GetContentHeightByGeneratorNew(string text)
		{
			if (this.cachedTextGeneratorNew == null)
			{
				this.cachedTextGeneratorNew = new TextGenerator(256);
				this.textGeneratorSettingNew.font = this.font;
				this.textGeneratorSettingNew.fontSize = this.m_chatNewFontSize;
				this.textGeneratorSettingNew.fontStyle = this.m_eFontStyle;
				this.textGeneratorSettingNew.lineSpacing = 1f;
				this.textGeneratorSettingNew.horizontalOverflow = 0;
				this.textGeneratorSettingNew.verticalOverflow = 1;
				this.textGeneratorSettingNew.alignByGeometry = false;
				this.textGeneratorSettingNew.resizeTextForBestFit = false;
				this.textGeneratorSettingNew.richText = true;
				this.textGeneratorSettingNew.scaleFactor = 1f;
				this.textGeneratorSettingNew.updateBounds = false;
				this.textGeneratorSettingNew.generationExtents = new Vector2(650f, 0f);
			}
			return this.cachedTextGeneratorNew.GetPreferredHeight(text, this.textGeneratorSettingNew);
		}

		// Token: 0x06018BE8 RID: 101352 RVA: 0x007BB6B5 File Offset: 0x007B9AB5
		public override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.ChatDataManager;
		}

		// Token: 0x06018BE9 RID: 101353 RVA: 0x007BB6BC File Offset: 0x007B9ABC
		private void _UpdateGlobalData()
		{
			if (!this.m_bDirty)
			{
				return;
			}
			for (int i = 0; i < this.m_akChatDataPool.Count; i++)
			{
				ChatBlock chatBlock = this.m_akChatDataPool[i];
				if (chatBlock.eType == ChatBlockType.CBT_NEW)
				{
					if (this.onAddGlobalChatData != null)
					{
						this.onAddGlobalChatData(chatBlock);
					}
				}
				else if (chatBlock.eType == ChatBlockType.CBT_REBUILD && this.onRebuildGlobalChatData != null)
				{
					this.onRebuildGlobalChatData(chatBlock.iPreID, chatBlock);
				}
			}
			this.m_bDirty = false;
		}

		// Token: 0x06018BEA RID: 101354 RVA: 0x007BB758 File Offset: 0x007B9B58
		private void _UpdateLocalData()
		{
			for (int i = 0; i < 15; i++)
			{
				ChatManager.ChatBlockConfig chatBlockConfig = this.m_chanelChatData[i];
				if (chatBlockConfig != null && chatBlockConfig.bDirty)
				{
					for (int j = 0; j < chatBlockConfig.cacheBlocks.Count; j++)
					{
						ChatBlock chatBlock = chatBlockConfig.cacheBlocks[j];
						if (chatBlock.eType == ChatBlockType.CBT_NEW)
						{
							if (this.onAddChatdata != null)
							{
								this.onAddChatdata(chatBlock);
							}
						}
						else if (chatBlock.eType == ChatBlockType.CBT_REBUILD && this.onRebuildChatData != null)
						{
							this.onRebuildChatData(chatBlock.iPreID, chatBlock);
						}
					}
					chatBlockConfig.bDirty = false;
				}
			}
		}

		// Token: 0x06018BEB RID: 101355 RVA: 0x007BB814 File Offset: 0x007B9C14
		public void Update()
		{
			this.m_iUpdateFrame++;
			if (this.m_iUpdateFrame == 1)
			{
				this._UpdateGlobalData();
			}
			else if (this.m_iUpdateFrame == 2)
			{
				this._UpdateLocalData();
			}
			if (this.m_iUpdateFrame >= 2)
			{
				this.m_iUpdateFrame = 0;
			}
		}

		// Token: 0x06018BEC RID: 101356 RVA: 0x007BB86C File Offset: 0x007B9C6C
		public override void Clear()
		{
			this.UnRegisterNetHandler();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RoleIdChanged, new ClientEventSystem.UIEventHandler(this._OnRoleIdChanged));
			ChatRecordManager instance = DataManager<ChatRecordManager>.GetInstance();
			instance.onLoadPrivateChatDataOK = (ChatRecordManager.OnLoadPrivateChatDataOK)Delegate.Remove(instance.onLoadPrivateChatDataOK, new ChatRecordManager.OnLoadPrivateChatDataOK(this._OnLoadPrivateChatDataOK));
			this._recvPrivateMsgNum.Clear();
			for (int i = 0; i < 15; i++)
			{
				this.m_chanelChatData[i].Clear();
			}
			this.m_akObjid2Data.Clear();
			this.m_dataCacheMax = 20;
			this.m_uniqueid = 1200121234;
			this.m_akGlobalChatDatas.Clear();
			this.m_bShareEquipmentLocked = false;
			this.m_akCachedDatas.Clear();
			this.m_akCachedChatDatas.Clear();
			this.m_bDirty = false;
			this.m_akChatDataPool.Clear();
			this.m_iDealPos = 0;
			this.m_iRollEnd = 0;
			this.m_iUpdateFrame = 0;
			this.font = null;
			ChatManager.isAcceptStrangerInfo = true;
		}

		// Token: 0x06018BED RID: 101357 RVA: 0x007BB968 File Offset: 0x007B9D68
		private void _OnSyncChat(MsgDATA msg)
		{
			int num = 0;
			SceneSyncChat sceneSyncChat = new SceneSyncChat();
			sceneSyncChat.decode(msg.bytes, ref num);
			if (ChatManager.IsTeamCopyChannel((ChanelType)sceneSyncChat.channel) && !TeamDuplicationUtility.IsInTeamDuplicationScene() && !BeUtility.IsRaidBattle())
			{
				return;
			}
			if (!ChatManager.IsTeamCopyChannel((ChanelType)sceneSyncChat.channel) && TeamDuplicationUtility.IsInTeamDuplicationScene() && !BeUtility.IsRaidBattle())
			{
				return;
			}
			ChatBlock chatData = this._NetData2LocalData(sceneSyncChat);
			this._OnDealChatData(chatData);
			if (sceneSyncChat.channel == 13 || sceneSyncChat.channel == 14)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationChatContentMessage, sceneSyncChat.objid, sceneSyncChat.word, null, null);
			}
			if (TeamDuplicationUtility.IsInTeamDuplicationScene() && ChatManager.IsTeamCopyChannel((ChanelType)sceneSyncChat.channel))
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RefreshChatData, null, null, null, null);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnChallengeTeamChatDataUpdate, null, null, null, null);
		}

		// Token: 0x06018BEE RID: 101358 RVA: 0x007BBA60 File Offset: 0x007B9E60
		private void _WorldChatHorn(MsgDATA msg)
		{
			int num = 0;
			WorldChatHorn worldChatHorn = new WorldChatHorn();
			worldChatHorn.decode(msg.bytes, ref num);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.WordChatHorn, worldChatHorn.info, null, null, null);
			ChatBlock chatData = this._WorldHorn2LocalData(worldChatHorn.info);
			this._OnDealChatData(chatData);
		}

		// Token: 0x06018BEF RID: 101359 RVA: 0x007BBAB0 File Offset: 0x007B9EB0
		public void ClearChannelChatData(ChanelType chanelType)
		{
			if (this.m_chanelChatData == null)
			{
				return;
			}
			if (chanelType >= (ChanelType)this.m_chanelChatData.Length)
			{
				return;
			}
			ChatManager.ChatBlockConfig chatBlockConfig = this.m_chanelChatData[(int)chanelType];
			if (chatBlockConfig == null)
			{
				return;
			}
			chatBlockConfig.Clear();
			chatBlockConfig.bDirty = true;
		}

		// Token: 0x06018BF0 RID: 101360 RVA: 0x007BBAF8 File Offset: 0x007B9EF8
		private void _TeamCopyTeamQuitRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyTeamQuitRes teamCopyTeamQuitRes = new TeamCopyTeamQuitRes();
			teamCopyTeamQuitRes.decode(msgData.bytes);
			if (teamCopyTeamQuitRes.retCode != 0U)
			{
				return;
			}
			this.ClearChannelChatData(ChanelType.CHAT_CHANNEL_TEAM_COPY_TEAM);
			this.ClearChannelChatData(ChanelType.CHAT_CHANNEL_TEAM_COPY_SQUAD);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RefreshChatData, null, null, null, null);
		}

		// Token: 0x06018BF1 RID: 101361 RVA: 0x007BBB4D File Offset: 0x007B9F4D
		public static bool IsTeamCopyChannel(ChanelType chanelType)
		{
			return chanelType == ChanelType.CHAT_CHANNEL_TEAM_COPY_PREPARE || chanelType == ChanelType.CHAT_CHANNEL_TEAM_COPY_TEAM || chanelType == ChanelType.CHAT_CHANNEL_TEAM_COPY_SQUAD;
		}

		// Token: 0x06018BF2 RID: 101362 RVA: 0x007BBB6A File Offset: 0x007B9F6A
		private void _OnDealChatData(ChatBlock chatData)
		{
			if (chatData == null)
			{
				return;
			}
			this._AddChatData(chatData);
			this.OnVoiceChatCome(chatData.chatData);
		}

		// Token: 0x1700204B RID: 8267
		// (get) Token: 0x06018BF3 RID: 101363 RVA: 0x007BBB86 File Offset: 0x007B9F86
		public Dictionary<ulong, List<ChatBlock>> PrivateChatObjects
		{
			get
			{
				return this.m_akObjid2Data;
			}
		}

		// Token: 0x1700204C RID: 8268
		// (get) Token: 0x06018BF4 RID: 101364 RVA: 0x007BBB8E File Offset: 0x007B9F8E
		public List<ChatData> GlobalChatDatas
		{
			get
			{
				return this.m_akGlobalChatDatas;
			}
		}

		// Token: 0x1700204D RID: 8269
		// (get) Token: 0x06018BF5 RID: 101365 RVA: 0x007BBB96 File Offset: 0x007B9F96
		public List<ChatBlock> GlobalChatBlock
		{
			get
			{
				return this.m_akChatDataPool;
			}
		}

		// Token: 0x1700204E RID: 8270
		// (get) Token: 0x06018BF6 RID: 101366 RVA: 0x007BBB9E File Offset: 0x007B9F9E
		// (set) Token: 0x06018BF7 RID: 101367 RVA: 0x007BBBA6 File Offset: 0x007B9FA6
		public int recvPrivateMsgNum { get; private set; }

		// Token: 0x06018BF8 RID: 101368 RVA: 0x007BBBB0 File Offset: 0x007B9FB0
		public List<ChatBlock> GetPrivateChat(ulong uid)
		{
			List<ChatBlock> result = null;
			if (uid != 0UL)
			{
				this.m_akObjid2Data.TryGetValue(uid, out result);
			}
			else if (this.m_akObjid2Data.Count > 0)
			{
				result = this.m_akObjid2Data[0UL];
			}
			return result;
		}

		// Token: 0x06018BF9 RID: 101369 RVA: 0x007BBBFB File Offset: 0x007B9FFB
		public void RemovePrivateChatData(ulong uid)
		{
			if (this.m_akObjid2Data.ContainsKey(uid))
			{
				this.m_akObjid2Data.Remove(uid);
			}
		}

		// Token: 0x06018BFA RID: 101370 RVA: 0x007BBC1C File Offset: 0x007BA01C
		public List<ChatBlock> GetChatDataByChanelType(ChanelType eChanelType)
		{
			ChatManager.ChatBlockConfig chatBlockConfig = null;
			if (eChanelType == ChanelType.CHAT_CHANNEL_PRIVATE)
			{
				return null;
			}
			if (eChanelType >= (ChanelType)0 && eChanelType < ChanelType.CHAT_CHANNEL_MAX)
			{
				chatBlockConfig = this.m_chanelChatData[(int)eChanelType];
			}
			if (chatBlockConfig != null)
			{
				return chatBlockConfig.cacheBlocks;
			}
			return null;
		}

		// Token: 0x06018BFB RID: 101371 RVA: 0x007BBC5C File Offset: 0x007BA05C
		private ChatBlock _AllocChatData()
		{
			this.m_bDirty = true;
			ChatBlock chatBlock;
			if (this.m_akChatDataPool.Count < 30)
			{
				chatBlock = new ChatBlock
				{
					chatData = new ChatData(),
					eType = ChatBlockType.CBT_NEW,
					iPreID = 0UL,
					iOrder = this.m_akChatDataPool.Count
				};
				this.m_akChatDataPool.Add(chatBlock);
				this.m_iRollEnd = this.m_akChatDataPool.Count - 1;
				return chatBlock;
			}
			chatBlock = this.m_akChatDataPool[0];
			this.m_akChatDataPool.RemoveAt(0);
			chatBlock.iOrder = this.m_akChatDataPool[this.m_akChatDataPool.Count - 1].iOrder + 1;
			this.m_akChatDataPool.Add(chatBlock);
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

		// Token: 0x06018BFC RID: 101372 RVA: 0x007BBD78 File Offset: 0x007BA178
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
			if (chatData.channel == 4)
			{
				chatData.shortTimeString = Function.GetDateTime((int)DataManager<TimeManager>.GetInstance().GetServerTime(), true);
			}
			else
			{
				chatData.shortTimeString = "[" + DataManager<TimeManager>.GetInstance().GetTimeT() + "]";
			}
			chatData.targetID = data.receiverId;
			chatData.eChatType = this._TransChanelType((ChanelType)chatData.channel);
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
			if (this.IsPrivateChatStrangerLevelLimit(chatData) || !ChatManager.IsAcceptStrangerInfo)
			{
				if (this.m_akChatDataPool != null && this.m_akChatDataPool.Contains(chatBlock))
				{
					this.m_akChatDataPool.Remove(chatBlock);
				}
				return null;
			}
			return chatBlock;
		}

		// Token: 0x06018BFD RID: 101373 RVA: 0x007BC014 File Offset: 0x007BA414
		private ChatBlock _WorldHorn2LocalData(HornInfo data)
		{
			ChatBlock chatBlock = this._AllocChatData();
			ChatData chatData = chatBlock.chatData;
			chatData.channel = 3;
			chatData.objid = data.roldId;
			chatData.sex = 0;
			chatData.occu = data.occu;
			chatData.level = data.level;
			chatData.viplvl = data.viplvl;
			chatData.objname = data.name;
			chatData.word = data.content;
			chatData.guid = ++this.m_uniqueid;
			chatData.shortTimeString = "[" + DataManager<TimeManager>.GetInstance().GetTimeT() + "]";
			chatData.targetID = 0UL;
			chatData.eChatType = this._TransChanelType((ChanelType)chatData.channel);
			chatData.dirty = true;
			chatData.bLink = 1;
			chatData.bGm = false;
			chatData.voiceKey = string.Empty;
			chatData.voiceDuration = 0;
			chatData.bVoice = false;
			chatData.bHorn = true;
			chatData.bRedPacket = false;
			chatData.headFrame = data.headFrame;
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			LinkParse._TryToken(stringBuilder, chatData.word, 0, null, LinkParse.EmotionSizeType.EST_72);
			string text = stringBuilder.ToString();
			chatData.height = (int)(this.GetContentHeightByGenerator(text) + 0.5f);
			StringBuilderCache.Release(stringBuilder);
			return chatBlock;
		}

		// Token: 0x06018BFE RID: 101374 RVA: 0x007BC15C File Offset: 0x007BA55C
		private ChatBlock _CopyBlock(ChatBlock src, ChatBlock data)
		{
			if (src != null)
			{
				src.chatData.channel = data.chatData.channel;
				src.chatData.objid = data.chatData.objid;
				src.chatData.sex = data.chatData.sex;
				src.chatData.occu = data.chatData.occu;
				src.chatData.level = data.chatData.level;
				src.chatData.viplvl = data.chatData.viplvl;
				src.chatData.objname = data.chatData.objname;
				src.chatData.word = data.chatData.word;
				src.chatData.guid = ++this.m_uniqueid;
				src.chatData.shortTimeString = data.chatData.shortTimeString;
				src.chatData.targetID = data.chatData.targetID;
				src.chatData.bLink = data.chatData.bLink;
				src.chatData.dirty = data.chatData.dirty;
				src.chatData.eChatType = data.chatData.eChatType;
				src.chatData.bGm = data.chatData.bGm;
				src.iOrder = data.iOrder;
				src.chatData.bVoice = data.chatData.bVoice;
				src.chatData.voiceKey = data.chatData.voiceKey;
				src.chatData.voiceDuration = data.chatData.voiceDuration;
				src.chatData.bHorn = data.chatData.bHorn;
				src.chatData.height = data.chatData.height;
				src.chatData.bRedPacket = data.chatData.bRedPacket;
				src.chatData.timeStamp = data.chatData.timeStamp;
				src.chatData.isShowTimeStamp = data.chatData.isShowTimeStamp;
				src.chatData.bAddFriend = data.chatData.bAddFriend;
				src.chatData.headFrame = data.chatData.headFrame;
				src.chatData.zoneId = data.chatData.zoneId;
				src.chatData.bNotHeadPoint = data.chatData.bNotHeadPoint;
				src.chatData.bSystem = data.chatData.bSystem;
				return src;
			}
			return new ChatBlock
			{
				chatData = new ChatData
				{
					channel = data.chatData.channel,
					objid = data.chatData.objid,
					sex = data.chatData.sex,
					occu = data.chatData.occu,
					level = data.chatData.level,
					viplvl = data.chatData.viplvl,
					objname = data.chatData.objname,
					word = data.chatData.word,
					guid = ++this.m_uniqueid,
					shortTimeString = data.chatData.shortTimeString,
					targetID = data.chatData.targetID,
					bLink = data.chatData.bLink,
					dirty = data.chatData.dirty,
					eChatType = data.chatData.eChatType,
					bGm = data.chatData.bGm,
					bVoice = data.chatData.bVoice,
					voiceKey = data.chatData.voiceKey,
					voiceDuration = data.chatData.voiceDuration,
					bHorn = data.chatData.bHorn,
					height = data.chatData.height,
					bRedPacket = data.chatData.bRedPacket,
					timeStamp = data.chatData.timeStamp,
					isShowTimeStamp = data.chatData.isShowTimeStamp,
					bAddFriend = data.chatData.bAddFriend,
					headFrame = data.chatData.headFrame,
					zoneId = data.chatData.zoneId,
					bNotHeadPoint = data.chatData.bNotHeadPoint,
					bSystem = data.chatData.bSystem
				},
				eType = ChatBlockType.CBT_NEW,
				iOrder = data.iOrder,
				iPreID = 0UL
			};
		}

		// Token: 0x06018BFF RID: 101375 RVA: 0x007BC5FC File Offset: 0x007BA9FC
		private int GetChannelMaxMsgCount(ChanelType chanelType)
		{
			if (chanelType == ChanelType.CHAT_CHANNEL_TEAM_COPY_PREPARE)
			{
				return Utility.GetSystemValueFromTable(SystemValueTable.eType3.SVT_TEAMCOPY_PREPARE_CHANNEL_MAX_MSG_COUNT, 50);
			}
			if (chanelType == ChanelType.CHAT_CHANNEL_TEAM_COPY_TEAM)
			{
				return Utility.GetSystemValueFromTable(SystemValueTable.eType3.SVT_TEAMCOPY_TEAM_CHANNEL_MAX_MSG_COUNT, 50);
			}
			if (chanelType == ChanelType.CHAT_CHANNEL_TEAM_COPY_SQUAD)
			{
				return Utility.GetSystemValueFromTable(SystemValueTable.eType3.SVT_TEAMCOPY_SQUAD_CHANNEL_MAX_MSG_COUNT, 50);
			}
			return this.m_dataCacheMax;
		}

		// Token: 0x06018C00 RID: 101376 RVA: 0x007BC650 File Offset: 0x007BAA50
		private void _AddChatData(ChatBlock data)
		{
			if (data == null)
			{
				return;
			}
			if (data.chatData.channel < 0 || data.chatData.channel >= 15)
			{
				return;
			}
			if (data.chatData.channel == 1)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PopChatMsg, data, null, null, null);
			}
			if (data.chatData.channel == 4)
			{
				ChatBlock chatBlock = this._CopyBlock(null, data);
				this.AddPrivateChatData(chatBlock);
				DataManager<ChatRecordManager>.GetInstance().AddPrivateChatData(chatBlock.chatData);
				bool flag = false;
				ulong num = 0UL;
				if (chatBlock.chatData.objid == DataManager<PlayerBaseData>.GetInstance().RoleID)
				{
					flag = true;
					num = chatBlock.chatData.targetID;
				}
				else if (chatBlock.chatData.targetID == DataManager<PlayerBaseData>.GetInstance().RoleID)
				{
					num = chatBlock.chatData.objid;
				}
				if (DataManager<RelationDataManager>.GetInstance().GetRelationByRoleID(num) == null && !flag)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RoleChatDirtyChanged, num, true, null, null);
				}
				return;
			}
			ChatManager.ChatBlockConfig chatBlockConfig = this.m_chanelChatData[(int)data.chatData.channel];
			chatBlockConfig.bDirty = true;
			int channelMaxMsgCount = this.GetChannelMaxMsgCount((ChanelType)data.chatData.channel);
			if (chatBlockConfig.cacheBlocks.Count < channelMaxMsgCount)
			{
				ChatBlock chatBlock2 = this._CopyBlock(null, data);
				chatBlock2.chatData.guid = ++this.m_uniqueid;
				chatBlockConfig.cacheBlocks.Add(chatBlock2);
				chatBlockConfig.iRollEnd = chatBlockConfig.cacheBlocks.Count - 1;
				chatBlock2.iOrder = chatBlockConfig.cacheBlocks.Count;
				chatBlock2.eType = ChatBlockType.CBT_NEW;
			}
			else
			{
				ChatBlock chatBlock2 = chatBlockConfig.cacheBlocks[0];
				chatBlockConfig.cacheBlocks.RemoveAt(0);
				ChatBlock chatBlock3 = chatBlockConfig.cacheBlocks[chatBlockConfig.cacheBlocks.Count - 1];
				this._CopyBlock(chatBlock2, data);
				chatBlock2.iOrder = chatBlock3.iOrder + 1;
				chatBlockConfig.cacheBlocks.Add(chatBlock2);
				if (chatBlock2.eType == ChatBlockType.CBT_KEEP)
				{
					chatBlock2.eType = ChatBlockType.CBT_REBUILD;
				}
				else if (chatBlock2.eType == ChatBlockType.CBT_NEW)
				{
					chatBlock2.eType = ChatBlockType.CBT_NEW;
				}
				else if (chatBlock2.eType == ChatBlockType.CBT_REBUILD)
				{
					chatBlock2.eType = ChatBlockType.CBT_REBUILD;
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.LockStatuNewMessageNumber, data, null, null, null);
		}

		// Token: 0x06018C01 RID: 101377 RVA: 0x007BC8D7 File Offset: 0x007BACD7
		public bool IsDirtyFriendChat(ulong uid)
		{
			return false;
		}

		// Token: 0x06018C02 RID: 101378 RVA: 0x007BC8DA File Offset: 0x007BACDA
		public bool IsDirtyFriendChat()
		{
			return this._recvPrivateMsgNum.Count > 0;
		}

		// Token: 0x06018C03 RID: 101379 RVA: 0x007BC8F0 File Offset: 0x007BACF0
		public void ReduceRecvPrivateMsgNum(ulong uid)
		{
			if (this._recvPrivateMsgNum.ContainsKey(uid))
			{
				this._recvPrivateMsgNum.Remove(uid);
			}
		}

		// Token: 0x06018C04 RID: 101380 RVA: 0x007BC910 File Offset: 0x007BAD10
		public void SetClean(ulong uid)
		{
		}

		// Token: 0x06018C05 RID: 101381 RVA: 0x007BC914 File Offset: 0x007BAD14
		public void ShareEquipment(ItemData data, ChatType type = ChatType.CT_WORLD)
		{
			if (data == null || this.m_bShareEquipmentLocked)
			{
				if (this.m_bShareEquipmentLocked)
				{
					SystemNotifyManager.SystemNotify(5012, string.Empty);
				}
				return;
			}
			this.m_bShareEquipmentLocked = true;
			string content = "{" + string.Format("I {0} {1} {2}", data.GUID, data.TableID, data.StrengthenLevel) + "}";
			this.SendChat(type, content, 0UL, 1);
			ChatFrame chatFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(ChatFrame)) as ChatFrame;
			if (chatFrame != null)
			{
				chatFrame.world_chat_try_enter_cool_down();
			}
			InvokeMethod.Invoke(this, 15f, delegate()
			{
				this.m_bShareEquipmentLocked = false;
			});
		}

		// Token: 0x06018C06 RID: 101382 RVA: 0x007BC9D8 File Offset: 0x007BADD8
		public void SendChat(ChatType type, string content, ulong tarId = 0UL, byte share = 0)
		{
			ChanelType chanelType = this._TransChatType(type);
			if (chanelType >= ChanelType.CHAT_CHANNEL_AROUND && chanelType < ChanelType.CHAT_CHANNEL_MAX && !string.IsNullOrEmpty(content))
			{
				int num = content.IndexOf("-cm ");
				if (num != -1)
				{
					string text = content.Substring(num + 4, content.Length - 4);
					int num2 = text.IndexOf("suitwear");
					if (num2 != -1)
					{
						string text2 = text.Substring(num2 + 9, text.Length - 9);
						string[] array = text2.Split(new char[]
						{
							' '
						});
						if (array.Length == 4)
						{
							int suitId = 0;
							int.TryParse(array[0].Substring(3), out suitId);
							int strength = 0;
							int.TryParse(array[1].Substring(4), out strength);
							int type2 = 0;
							int.TryParse(array[2].Substring(4), out type2);
							int attr = 0;
							int.TryParse(array[3].Substring(5), out attr);
							Utility.UseOneKeySuitWear(suitId, strength, type2, attr);
						}
					}
					return;
				}
				SceneChat sceneChat = new SceneChat();
				sceneChat.channel = (byte)chanelType;
				sceneChat.targetId = tarId;
				sceneChat.word = content;
				sceneChat.bLink = ((!LinkParse.IsLink(content)) ? 0 : 1);
				sceneChat.voiceKey = string.Empty;
				sceneChat.voiceDuration = 0;
				sceneChat.isShare = share;
				NetManager.Instance().SendCommand<SceneChat>(ServerType.GATE_SERVER, sceneChat);
			}
		}

		// Token: 0x06018C07 RID: 101383 RVA: 0x007BCB38 File Offset: 0x007BAF38
		public void SendVoiceChat(ChatType type, string voiceKey, string content, byte voiceTimeLength, ulong tarId = 0UL)
		{
			ChanelType chanelType = this._TransChatType(type);
			if (chanelType >= ChanelType.CHAT_CHANNEL_AROUND && chanelType < ChanelType.CHAT_CHANNEL_MAX && !string.IsNullOrEmpty(content) && !string.IsNullOrEmpty(voiceKey))
			{
				SceneChat sceneChat = new SceneChat();
				sceneChat.channel = (byte)chanelType;
				sceneChat.targetId = tarId;
				sceneChat.word = content;
				sceneChat.bLink = 0;
				sceneChat.voiceKey = voiceKey;
				sceneChat.voiceDuration = voiceTimeLength;
				NetManager.Instance().SendCommand<SceneChat>(ServerType.GATE_SERVER, sceneChat);
			}
		}

		// Token: 0x06018C08 RID: 101384 RVA: 0x007BCBB4 File Offset: 0x007BAFB4
		public void SendPrivateChat(string content, ulong targetID)
		{
			if (!string.IsNullOrEmpty(content))
			{
				SceneChat sceneChat = new SceneChat();
				sceneChat.channel = 4;
				sceneChat.targetId = targetID;
				sceneChat.word = content;
				sceneChat.voiceKey = string.Empty;
				sceneChat.voiceDuration = 0;
				sceneChat.bLink = ((!LinkParse.IsLink(content)) ? 0 : 1);
				NetManager.Instance().SendCommand<SceneChat>(ServerType.GATE_SERVER, sceneChat);
				ChatBlock chatBlock = this._AllocChatData();
				ChatData chatData = chatBlock.chatData;
				chatData.channel = 4;
				chatData.objid = DataManager<PlayerBaseData>.GetInstance().RoleID;
				chatData.sex = 0;
				chatData.occu = (byte)DataManager<PlayerBaseData>.GetInstance().JobTableID;
				chatData.level = DataManager<PlayerBaseData>.GetInstance().Level;
				chatData.objname = DataManager<PlayerBaseData>.GetInstance().Name;
				chatData.word = content;
				chatData.guid = ++this.m_uniqueid;
				chatData.shortTimeString = "[" + DataManager<TimeManager>.GetInstance().GetTimeT() + "]";
				chatData.targetID = targetID;
				chatData.eChatType = this._TransChanelType((ChanelType)chatData.channel);
				chatData.bLink = sceneChat.bLink;
				chatData.viplvl = (byte)DataManager<PlayerBaseData>.GetInstance().VipLevel;
				this._AddChatData(chatBlock);
			}
		}

		// Token: 0x06018C09 RID: 101385 RVA: 0x007BCCF8 File Offset: 0x007BB0F8
		public void AddLocalMsg(string content, ChanelType eChanel = ChanelType.CHAT_CHANNEL_TRIBE)
		{
			if (!string.IsNullOrEmpty(content))
			{
				ChatBlock chatBlock = this._AllocChatData();
				ChatData chatData = chatBlock.chatData;
				chatData.channel = (byte)eChanel;
				chatData.objid = DataManager<PlayerBaseData>.GetInstance().RoleID;
				chatData.sex = 0;
				chatData.occu = (byte)DataManager<PlayerBaseData>.GetInstance().JobTableID;
				chatData.level = DataManager<PlayerBaseData>.GetInstance().Level;
				chatData.objname = DataManager<PlayerBaseData>.GetInstance().Name;
				chatData.word = content;
				chatData.guid = ++this.m_uniqueid;
				chatData.shortTimeString = "[" + DataManager<TimeManager>.GetInstance().GetTimeT() + "]";
				chatData.targetID = 0UL;
				chatData.eChatType = this._TransChanelType((ChanelType)chatData.channel);
				chatData.bLink = ((!LinkParse.IsLink(content)) ? 0 : 1);
				chatData.viplvl = (byte)DataManager<PlayerBaseData>.GetInstance().VipLevel;
				this._AddChatData(chatBlock);
			}
		}

		// Token: 0x06018C0A RID: 101386 RVA: 0x007BCDF8 File Offset: 0x007BB1F8
		public void AddAskForPupilInvite(RelationData rd, string content, bool isSystem = false)
		{
			if (rd != null && !string.IsNullOrEmpty(content))
			{
				ChatBlock chatBlock = this._AllocChatData();
				ChatData chatData = chatBlock.chatData;
				chatData.channel = 4;
				chatData.objid = rd.uid;
				chatData.sex = 0;
				chatData.occu = rd.occu;
				chatData.level = rd.level;
				chatData.objname = rd.name;
				chatData.word = content;
				chatData.guid = ++this.m_uniqueid;
				chatData.shortTimeString = Function.GetDateTime((int)DataManager<TimeManager>.GetInstance().GetServerTime(), true);
				chatData.targetID = DataManager<PlayerBaseData>.GetInstance().RoleID;
				chatData.eChatType = this._TransChanelType((ChanelType)chatData.channel);
				chatData.bLink = ((!LinkParse.IsLink(content)) ? 0 : 1);
				chatData.viplvl = rd.vipLv;
				chatData.timeStamp = DataManager<TimeManager>.GetInstance().GetServerTime();
				chatData.isShowTimeStamp = false;
				chatData.bSystem = isSystem;
				this._AddChatData(chatBlock);
			}
		}

		// Token: 0x06018C0B RID: 101387 RVA: 0x007BCF04 File Offset: 0x007BB304
		public ChatType _TransChanelType(ChanelType type)
		{
			switch (type)
			{
			case ChanelType.CHAT_CHANNEL_AROUND:
				return ChatType.CT_NORMAL;
			case ChanelType.CHAT_CHANNEL_TEAM:
				return ChatType.CT_TEAM;
			case ChanelType.CHAT_CHANNEL_WORLD:
				return ChatType.CT_WORLD;
			case ChanelType.CHAT_CHANNEL_PRIVATE:
				return ChatType.CT_PRIVATE;
			case ChanelType.CHAT_CHANNEL_TRIBE:
				return ChatType.CT_GUILD;
			case ChanelType.CHAT_CHANNEL_SYSTEM:
				return ChatType.CT_SYSTEM;
			case ChanelType.CHAT_CHANNEL_ACCOMPANY:
				return ChatType.CT_ACOMMPANY;
			case ChanelType.CHAT_CHANNEL_TEAM_COPY_PREPARE:
				return ChatType.CT_TEAM_COPY_PREPARE;
			case ChanelType.CHAT_CHANNEL_TEAM_COPY_TEAM:
				return ChatType.CT_TEAM_COPY_TEAM;
			case ChanelType.CHAT_CHANNEL_TEAM_COPY_SQUAD:
				return ChatType.CT_TEAM_COPY_SQUAD;
			}
			return ChatType.CT_MAX_WORDS;
		}

		// Token: 0x06018C0C RID: 101388 RVA: 0x007BCF70 File Offset: 0x007BB370
		public ChanelType _TransChatType(ChatType type)
		{
			switch (type)
			{
			case ChatType.CT_SYSTEM:
				return ChanelType.CHAT_CHANNEL_SYSTEM;
			case ChatType.CT_WORLD:
				return ChanelType.CHAT_CHANNEL_WORLD;
			case ChatType.CT_NORMAL:
				return ChanelType.CHAT_CHANNEL_AROUND;
			case ChatType.CT_GUILD:
				return ChanelType.CHAT_CHANNEL_TRIBE;
			case ChatType.CT_TEAM:
				return ChanelType.CHAT_CHANNEL_TEAM;
			case ChatType.CT_PRIVATE:
				return ChanelType.CHAT_CHANNEL_PRIVATE;
			case ChatType.CT_ACOMMPANY:
				return ChanelType.CHAT_CHANNEL_ACCOMPANY;
			case ChatType.CT_PK3V3_ROOM:
				return ChanelType.CHAT_CHANNEL_PK3V3_ROOM;
			case ChatType.CT_TEAM_COPY_PREPARE:
				return ChanelType.CHAT_CHANNEL_TEAM_COPY_PREPARE;
			case ChatType.CT_TEAM_COPY_TEAM:
				return ChanelType.CHAT_CHANNEL_TEAM_COPY_TEAM;
			case ChatType.CT_TEAM_COPY_SQUAD:
				return ChanelType.CHAT_CHANNEL_TEAM_COPY_SQUAD;
			}
			return ChanelType.CHAT_CHANNEL_MAX;
		}

		// Token: 0x06018C0D RID: 101389 RVA: 0x007BCFD8 File Offset: 0x007BB3D8
		public void AddPrivateChatData(ChatBlock data)
		{
			bool flag = false;
			List<ChatBlock> list = null;
			ulong num = 0UL;
			if (data.chatData.objid == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				flag = true;
				num = data.chatData.targetID;
			}
			else if (data.chatData.targetID == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				num = data.chatData.objid;
			}
			if (!this.m_akObjid2Data.TryGetValue(num, out list))
			{
				list = new List<ChatBlock>();
				data.iOrder = list.Count;
				list.Add(data);
				this.m_akObjid2Data.Add(num, list);
			}
			else
			{
				if (list.Count >= this.m_dataCacheMax)
				{
					list.RemoveAt(0);
					data.iOrder = list[list.Count - 1].iOrder + 1;
				}
				else
				{
					data.iOrder = list.Count;
				}
				list.Add(data);
			}
			if (this.onAddChatdata != null)
			{
				this.onAddChatdata(data);
			}
			if (!flag)
			{
				RelationData relationData = DataManager<RelationDataManager>.GetInstance().GetRelationByRoleID(num);
				if (relationData == null)
				{
					relationData = new RelationData();
					relationData.uid = num;
					relationData.type = 3;
					relationData.name = data.chatData.objname;
					relationData.seasonLv = 0U;
					relationData.level = data.chatData.level;
					relationData.occu = data.chatData.occu;
					relationData.isOnline = 1;
					relationData.vipLv = data.chatData.viplvl;
				}
				DataManager<RelationDataManager>.GetInstance().OnAddPriChatList(relationData, true);
			}
		}

		// Token: 0x06018C0E RID: 101390 RVA: 0x007BD16C File Offset: 0x007BB56C
		public bool OpenPrivateChatFrame(RelationData data)
		{
			FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(31, string.Empty, string.Empty);
			if (tableItem != null && (int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.FinishLevel)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("relation_friend_chat_need_lv", tableItem.FinishLevel), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return false;
			}
			if (data == null)
			{
				return false;
			}
			DataManager<RelationDataManager>.GetInstance().OnAddPriChatList(data, false);
			RelationFrameNew.CommandOpen(new RelationFrameData
			{
				eCurrentRelationData = data
			});
			return true;
		}

		// Token: 0x06018C0F RID: 101391 RVA: 0x007BD1F0 File Offset: 0x007BB5F0
		public bool OpenTeamChatFrame()
		{
			if (!BeUtility.IsRaidBattle())
			{
				if (DataManager<TeamDataManager>.GetInstance().GetMyTeam() == null)
				{
					return false;
				}
				if (Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>((int)DataManager<TeamDataManager>.GetInstance().TeamDungeonID, string.Empty, string.Empty) == null)
				{
					return false;
				}
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ChatFrame>(null))
			{
				return false;
			}
			ChatFrame chatFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChatFrame>(FrameLayer.Middle, null, string.Empty) as ChatFrame;
			if (!BeUtility.IsRaidBattle())
			{
				chatFrame.SetTab(ChatType.CT_TEAM);
			}
			else if (DataManager<BattleEasyChatDataManager>.GetInstance() != null)
			{
				chatFrame.SetTab(DataManager<BattleEasyChatDataManager>.GetInstance().DungeonChatType);
			}
			return true;
		}

		// Token: 0x06018C10 RID: 101392 RVA: 0x007BD29C File Offset: 0x007BB69C
		public bool AddLocalGuildChatData(string content)
		{
			ChatBlock chatBlock = this._AllocChatData();
			ChatData chatData = chatBlock.chatData;
			chatData.channel = 5;
			chatData.objid = 0UL;
			chatData.sex = 0;
			chatData.occu = 0;
			chatData.level = 0;
			chatData.viplvl = 0;
			chatData.objname = "系统提示";
			chatData.word = content;
			chatData.guid = ++this.m_uniqueid;
			chatData.shortTimeString = "[" + DataManager<TimeManager>.GetInstance().GetTimeT() + "]";
			chatData.targetID = DataManager<PlayerBaseData>.GetInstance().RoleID;
			chatData.eChatType = this._TransChanelType(ChanelType.CHAT_CHANNEL_TRIBE);
			chatData.dirty = true;
			chatData.bLink = 1;
			this._AddChatData(chatBlock);
			return true;
		}

		// Token: 0x06018C11 RID: 101393 RVA: 0x007BD360 File Offset: 0x007BB760
		private void _OnRoleIdChanged(UIEvent uiEvent)
		{
			this._recvPrivateMsgNum.Clear();
			this.m_akObjid2Data.Clear();
			ulong num = (ulong)uiEvent.Param2;
			if (num > 0UL)
			{
				this.LoadPrivateDataFromRecords(num);
			}
		}

		// Token: 0x06018C12 RID: 101394 RVA: 0x007BD39E File Offset: 0x007BB79E
		private void _OnLoadPrivateChatDataOK(ulong roleId)
		{
			if (roleId > 0UL)
			{
				this.LoadPrivateDataFromRecords(roleId);
			}
		}

		// Token: 0x06018C13 RID: 101395 RVA: 0x007BD3B0 File Offset: 0x007BB7B0
		private void LoadPrivateDataFromRecords(ulong RoleId)
		{
			if (!SwitchFunctionUtility.IsOpen(3))
			{
				return;
			}
			this._recvPrivateMsgNum.Clear();
			this.m_akObjid2Data.Clear();
			RoleInfo roleInfo = null;
			for (int i = 0; i < ClientApplication.playerinfo.roleinfo.Length; i++)
			{
				if (RoleId == ClientApplication.playerinfo.roleinfo[i].roleId)
				{
					roleInfo = ClientApplication.playerinfo.roleinfo[i];
					break;
				}
			}
			if (roleInfo == null)
			{
				Logger.LogErrorFormat("LoadPrivateDataFromRecords error roleInfo is null!", new object[0]);
				return;
			}
			ChatRecordManager.RoleChatRecords chatRecords = DataManager<ChatRecordManager>.GetInstance().GetChatRecords(RoleId);
			if (chatRecords != null)
			{
				for (int j = 0; j < chatRecords.RoleChats.Count; j++)
				{
					ChatRecordManager.TargetChatRecords targetChatRecords = chatRecords.RoleChats[j];
					bool dirty = targetChatRecords.Dirty;
					RelationData rd = targetChatRecords.RelationDataRecords.ConvertTo(new RelationData());
					DataManager<RelationDataManager>.GetInstance().OnAddPriChatList(rd, dirty);
					if (targetChatRecords != null)
					{
						for (int k = 0; k < targetChatRecords.TargetChats.Count; k++)
						{
							this.AddPrivateChatData(new ChatBlock
							{
								chatData = ChatRecordManager.PrivateChatRecords.ConvertFrom(targetChatRecords.TargetChats[k], rd, roleInfo),
								chatData = 
								{
									guid = ++this.m_uniqueid
								},
								eType = ChatBlockType.CBT_NEW,
								iOrder = k,
								iPreID = 0UL
							});
						}
						if (!dirty)
						{
							DataManager<RelationDataManager>.GetInstance().ClearPriChatDirty((ulong)targetChatRecords.friendId);
						}
					}
				}
				chatRecords.TryUpdateRelation();
			}
		}

		// Token: 0x06018C14 RID: 101396 RVA: 0x007BD550 File Offset: 0x007BB950
		public void TrySendChatContent(ChatType eChatType, UnityAction cb)
		{
			switch (eChatType)
			{
			case ChatType.CT_WORLD:
			{
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(172, string.Empty, string.Empty);
				if (tableItem != null && tableItem.Value > (int)DataManager<PlayerBaseData>.GetInstance().Level)
				{
					SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("chat_world_talk_need_level"), tableItem.Value), CommonTipsDesc.eShowMode.SI_IMMEDIATELY);
				}
				else
				{
					int freeWorldChatLeftTimes = DataManager<ChatManager>.GetInstance().FreeWorldChatLeftTimes;
					if (freeWorldChatLeftTimes <= 0 && !DataManager<ChatManager>.GetInstance().CheckWorldActivityValueEnough())
					{
						SystemNotifyManager.SystemNotify(7006, delegate()
						{
							Singleton<ClientSystemManager>.GetInstance().OpenFrame<VipFrame>(FrameLayer.Middle, VipTabType.VIP, string.Empty);
						});
					}
					else if (!ChatManager.world_chat_try_enter_cool_down())
					{
						SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("chat_world_talk_need_interval"), ChatManager.world_cool_time), CommonTipsDesc.eShowMode.SI_IMMEDIATELY);
					}
					else if (cb != null)
					{
						cb.Invoke();
					}
				}
				break;
			}
			case ChatType.CT_NORMAL:
			{
				SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(173, string.Empty, string.Empty);
				if (tableItem2 != null && tableItem2.Value > (int)DataManager<PlayerBaseData>.GetInstance().Level)
				{
					SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("chat_normal_talk_need_level"), tableItem2.Value), CommonTipsDesc.eShowMode.SI_IMMEDIATELY);
				}
				else if (!ChatManager.arround_chat_try_enter_cool_down())
				{
					SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("chat_normal_talk_need_interval"), ChatManager.arround_cool_time), CommonTipsDesc.eShowMode.SI_IMMEDIATELY);
				}
				else if (cb != null)
				{
					cb.Invoke();
				}
				break;
			}
			case ChatType.CT_GUILD:
				if (DataManager<PlayerBaseData>.GetInstance().eGuildDuty == EGuildDuty.Invalid)
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("chat_guild_talk_need_guild"), CommonTipsDesc.eShowMode.SI_IMMEDIATELY);
				}
				else if (cb != null)
				{
					cb.Invoke();
				}
				break;
			case ChatType.CT_TEAM:
			{
				SystemValueTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(174, string.Empty, string.Empty);
				if (tableItem3 != null && tableItem3.Value > (int)DataManager<PlayerBaseData>.GetInstance().Level)
				{
					SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("chat_team_talk_need_level"), tableItem3.Value), CommonTipsDesc.eShowMode.SI_IMMEDIATELY);
				}
				else if (cb != null)
				{
					cb.Invoke();
				}
				break;
			}
			}
		}

		// Token: 0x06018C15 RID: 101397 RVA: 0x007BD799 File Offset: 0x007BBB99
		private int GetPrivateChatLimitLevel()
		{
			if (PlayerPrefs.HasKey("PrivateChatLimitLevel"))
			{
				return PlayerPrefs.GetInt("PrivateChatLimitLevel");
			}
			return this.privateChatLimitLevel;
		}

		// Token: 0x06018C16 RID: 101398 RVA: 0x007BD7BB File Offset: 0x007BBBBB
		private void SavePrivateLimitLevelPref(int level)
		{
			PlayerPrefs.SetInt("PrivateChatLimitLevel", level);
			PlayerPrefs.Save();
		}

		// Token: 0x06018C17 RID: 101399 RVA: 0x007BD7D0 File Offset: 0x007BBBD0
		public bool IsPrivateChatStrangerLevelLimit(ChatData chatData)
		{
			if (chatData == null)
			{
				return false;
			}
			if (chatData.channel != 4)
			{
				return false;
			}
			bool flag = false;
			ulong uid = 0UL;
			int level = (int)chatData.level;
			if (chatData.objid == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				flag = true;
				uid = chatData.targetID;
			}
			else if (chatData.targetID == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				uid = chatData.objid;
			}
			RelationData relationByRoleID = DataManager<RelationDataManager>.GetInstance().GetRelationByRoleID(uid);
			return !flag && relationByRoleID == null && level <= this.privateChatLimitLevel;
		}

		// Token: 0x06018C18 RID: 101400 RVA: 0x007BD868 File Offset: 0x007BBC68
		public void SetPrivateChatLevelLimit(PrivateChatLevelLimit levelLimit)
		{
			string key = string.Empty;
			switch (levelLimit)
			{
			case PrivateChatLevelLimit.LessLevelTen:
				key = "voice_private_chat_level_limit_ten";
				break;
			case PrivateChatLevelLimit.LessLevelTwenty:
				key = "voice_private_chat_level_limit_twenty";
				break;
			case PrivateChatLevelLimit.LessLevelThirty:
				key = "voice_private_chat_level_limit_thirty";
				break;
			case PrivateChatLevelLimit.LessLevelForty:
				key = "voice_private_chat_level_limit_forty";
				break;
			}
			if (int.TryParse(TR.Value(key), out this.privateChatLimitLevel))
			{
				this.SavePrivateLimitLevelPref(this.privateChatLimitLevel);
			}
		}

		// Token: 0x06018C19 RID: 101401 RVA: 0x007BD8E4 File Offset: 0x007BBCE4
		public bool GetIsPrivateChatLevelLimit(PrivateChatLevelLimit levelLimit)
		{
			int num = this.GetPrivateChatLimitLevel();
			int num2 = 10;
			string key = string.Empty;
			switch (levelLimit)
			{
			case PrivateChatLevelLimit.LessLevelTen:
				key = "voice_private_chat_level_limit_ten";
				break;
			case PrivateChatLevelLimit.LessLevelTwenty:
				key = "voice_private_chat_level_limit_twenty";
				break;
			case PrivateChatLevelLimit.LessLevelThirty:
				key = "voice_private_chat_level_limit_thirty";
				break;
			case PrivateChatLevelLimit.LessLevelForty:
				key = "voice_private_chat_level_limit_forty";
				break;
			}
			if (int.TryParse(TR.Value(key), out num2))
			{
				if (num2 == num)
				{
					return true;
				}
			}
			else if (levelLimit == PrivateChatLevelLimit.LessLevelTen)
			{
				return true;
			}
			return false;
		}

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x06018C1A RID: 101402 RVA: 0x007BD974 File Offset: 0x007BBD74
		// (remove) Token: 0x06018C1B RID: 101403 RVA: 0x007BD9AC File Offset: 0x007BBDAC
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event Action<ChatData> OnVoiceChatComeHandler;

		// Token: 0x06018C1C RID: 101404 RVA: 0x007BD9E2 File Offset: 0x007BBDE2
		private void OnVoiceChatCome(ChatData chatData)
		{
			if (chatData.bVoice && this.OnVoiceChatComeHandler != null)
			{
				this.OnVoiceChatComeHandler(chatData);
			}
		}

		// Token: 0x06018C1D RID: 101405 RVA: 0x007BDA06 File Offset: 0x007BBE06
		public void AddSyncVoiceChatListener(Action<ChatData> handler)
		{
			this.RemoveAllSyncVoiceChatListener();
			if (this.OnVoiceChatComeHandler == null)
			{
				this.OnVoiceChatComeHandler += handler;
			}
		}

		// Token: 0x06018C1E RID: 101406 RVA: 0x007BDA20 File Offset: 0x007BBE20
		public void RemoveAllSyncVoiceChatListener()
		{
			if (this.OnVoiceChatComeHandler != null)
			{
				foreach (Delegate @delegate in this.OnVoiceChatComeHandler.GetInvocationList())
				{
					this.OnVoiceChatComeHandler -= (@delegate as Action<ChatData>);
				}
			}
		}

		// Token: 0x04011D3E RID: 73022
		public static int[] ms_sort_orders = new int[]
		{
			8,
			0,
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			9,
			10,
			11,
			12
		};

		// Token: 0x04011D3F RID: 73023
		private static bool isAcceptStrangerInfo = true;

		// Token: 0x04011D40 RID: 73024
		private static int ms_accompany_cool_time = 0;

		// Token: 0x04011D41 RID: 73025
		private static int ms_arround_cool_time = 0;

		// Token: 0x04011D42 RID: 73026
		private static int ms_teamcopy_prepare_cool_time = 0;

		// Token: 0x04011D43 RID: 73027
		private static int ms_teamcopy_team_cool_time = 0;

		// Token: 0x04011D44 RID: 73028
		private static int ms_teamcopy_squad_cool_time = 0;

		// Token: 0x04011D45 RID: 73029
		private static int ms_world_cool_time = 0;

		// Token: 0x04011D46 RID: 73030
		public ChatManager.OnAddChatData onAddChatdata;

		// Token: 0x04011D47 RID: 73031
		public ChatManager.OnRebuildChatData onRebuildChatData;

		// Token: 0x04011D48 RID: 73032
		public ChatManager.OnAddGlobalChatData onAddGlobalChatData;

		// Token: 0x04011D49 RID: 73033
		public ChatManager.OnRebuildGlobalChatData onRebuildGlobalChatData;

		// Token: 0x04011D4A RID: 73034
		public Dictionary<ulong, int> _recvPrivateMsgNum = new Dictionary<ulong, int>();

		// Token: 0x04011D4B RID: 73035
		private UIEventRecvPrivateChat _eventChat = new UIEventRecvPrivateChat(true);

		// Token: 0x04011D4C RID: 73036
		private Font font;

		// Token: 0x04011D4D RID: 73037
		private int m_fontsize = 35;

		// Token: 0x04011D4E RID: 73038
		private FontStyle m_eFontStyle;

		// Token: 0x04011D4F RID: 73039
		private float m_fChatFrameMaxWidth = 646f;

		// Token: 0x04011D50 RID: 73040
		private int m_chatNewFontSize = 28;

		// Token: 0x04011D51 RID: 73041
		private TextGenerator cachedTextGenerator;

		// Token: 0x04011D52 RID: 73042
		private TextGenerationSettings textGeneratorSetting = default(TextGenerationSettings);

		// Token: 0x04011D53 RID: 73043
		private TextGenerator cachedTextGeneratorNew;

		// Token: 0x04011D54 RID: 73044
		private TextGenerationSettings textGeneratorSettingNew = default(TextGenerationSettings);

		// Token: 0x04011D55 RID: 73045
		protected ChatManager.ChatBlockConfig[] m_chanelChatData = new ChatManager.ChatBlockConfig[]
		{
			new ChatManager.ChatBlockConfig(),
			new ChatManager.ChatBlockConfig(),
			new ChatManager.ChatBlockConfig(),
			new ChatManager.ChatBlockConfig(),
			new ChatManager.ChatBlockConfig(),
			new ChatManager.ChatBlockConfig(),
			new ChatManager.ChatBlockConfig(),
			new ChatManager.ChatBlockConfig(),
			new ChatManager.ChatBlockConfig(),
			new ChatManager.ChatBlockConfig(),
			new ChatManager.ChatBlockConfig(),
			new ChatManager.ChatBlockConfig(),
			new ChatManager.ChatBlockConfig(),
			new ChatManager.ChatBlockConfig(),
			new ChatManager.ChatBlockConfig()
		};

		// Token: 0x04011D56 RID: 73046
		protected int m_dataCacheMax;

		// Token: 0x04011D57 RID: 73047
		protected int m_uniqueid;

		// Token: 0x04011D58 RID: 73048
		protected Dictionary<ulong, List<ChatBlock>> m_akObjid2Data = new Dictionary<ulong, List<ChatBlock>>();

		// Token: 0x04011D59 RID: 73049
		protected List<ChatData> m_akGlobalChatDatas = new List<ChatData>();

		// Token: 0x04011D5A RID: 73050
		private List<ChatData> m_akCachedDatas = new List<ChatData>();

		// Token: 0x04011D5C RID: 73052
		private List<ChatData> m_akCachedChatDatas = new List<ChatData>();

		// Token: 0x04011D5D RID: 73053
		private List<ChatBlock> m_akChatDataPool = new List<ChatBlock>();

		// Token: 0x04011D5E RID: 73054
		private int m_iRollEnd;

		// Token: 0x04011D5F RID: 73055
		private int m_iDealPos;

		// Token: 0x04011D60 RID: 73056
		private bool m_bDirty;

		// Token: 0x04011D61 RID: 73057
		private int m_iUpdateFrame;

		// Token: 0x04011D62 RID: 73058
		private const int teamCopyChannelMaxMsgCount = 50;

		// Token: 0x04011D63 RID: 73059
		private bool m_bShareEquipmentLocked;

		// Token: 0x04011D64 RID: 73060
		public const string PRIVATE_CHAT_LIMIT_LEVEL = "PrivateChatLimitLevel";

		// Token: 0x04011D65 RID: 73061
		private int privateChatLimitLevel = 10;

		// Token: 0x0200455B RID: 17755
		// (Invoke) Token: 0x06018C35 RID: 101429
		public delegate void OnAddChatData(ChatBlock data);

		// Token: 0x0200455C RID: 17756
		// (Invoke) Token: 0x06018C39 RID: 101433
		public delegate void OnRebuildChatData(ulong pre, ChatBlock current);

		// Token: 0x0200455D RID: 17757
		// (Invoke) Token: 0x06018C3D RID: 101437
		public delegate void OnAddGlobalChatData(ChatBlock data);

		// Token: 0x0200455E RID: 17758
		// (Invoke) Token: 0x06018C41 RID: 101441
		public delegate void OnRebuildGlobalChatData(ulong pre, ChatBlock current);

		// Token: 0x0200455F RID: 17759
		public class ChatBlockConfig
		{
			// Token: 0x06018C45 RID: 101445 RVA: 0x007BDC1D File Offset: 0x007BC01D
			public void Clear()
			{
				this.iDealPos = 0;
				this.iRollEnd = 0;
				this.bDirty = false;
				this.cacheBlocks.Clear();
			}

			// Token: 0x04011D7A RID: 73082
			public List<ChatBlock> cacheBlocks = new List<ChatBlock>();

			// Token: 0x04011D7B RID: 73083
			public int iDealPos;

			// Token: 0x04011D7C RID: 73084
			public int iRollEnd;

			// Token: 0x04011D7D RID: 73085
			public bool bDirty;
		}
	}
}
