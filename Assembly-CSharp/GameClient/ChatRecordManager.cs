using System;
using System.Collections.Generic;
using LitJson;
using Protocol;

namespace GameClient
{
	// Token: 0x02004560 RID: 17760
	internal class ChatRecordManager : DataManager<ChatRecordManager>
	{
		// Token: 0x1700204F RID: 8271
		// (get) Token: 0x06018C47 RID: 101447 RVA: 0x007BDC52 File Offset: 0x007BC052
		// (set) Token: 0x06018C48 RID: 101448 RVA: 0x007BDC5A File Offset: 0x007BC05A
		private ChatRecordManager.ChatRecordsConfig PrivateChatRecordsConfig
		{
			get
			{
				return this.m_kChatRecords;
			}
			set
			{
				this.m_kChatRecords = value;
			}
		}

		// Token: 0x06018C49 RID: 101449 RVA: 0x007BDC63 File Offset: 0x007BC063
		public string GetSavePath(ulong RoleId)
		{
			if (RoleId != 0UL)
			{
				return string.Format("ChatRecords_{0}.json", DataManager<PlayerBaseData>.GetInstance().RoleID);
			}
			return string.Empty;
		}

		// Token: 0x06018C4A RID: 101450 RVA: 0x007BDC8C File Offset: 0x007BC08C
		public void AddPrivateChatData(ChatData chatData)
		{
			RoleInfo roleInfo = null;
			for (int i = 0; i < ClientApplication.playerinfo.roleinfo.Length; i++)
			{
				if (DataManager<PlayerBaseData>.GetInstance().RoleID == ClientApplication.playerinfo.roleinfo[i].roleId)
				{
					roleInfo = ClientApplication.playerinfo.roleinfo[i];
					break;
				}
			}
			this.PrivateChatRecordsConfig.AddPrivateChatData(chatData, roleInfo);
		}

		// Token: 0x06018C4B RID: 101451 RVA: 0x007BDCF7 File Offset: 0x007BC0F7
		public override void OnApplicationStart()
		{
		}

		// Token: 0x06018C4C RID: 101452 RVA: 0x007BDCF9 File Offset: 0x007BC0F9
		public override void OnApplicationQuit()
		{
			this.PrivateChatRecordsConfig.SaveData2Jason(DataManager<PlayerBaseData>.GetInstance().RoleID);
		}

		// Token: 0x06018C4D RID: 101453 RVA: 0x007BDD10 File Offset: 0x007BC110
		public override void Initialize()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RoleIdChanged, new ClientEventSystem.UIEventHandler(this._OnRoleIdChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RoleChatDirtyChanged, new ClientEventSystem.UIEventHandler(this._OnRoleChatDirtyChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnRelationChanged, new ClientEventSystem.UIEventHandler(this._OnRelationChanged));
		}

		// Token: 0x06018C4E RID: 101454 RVA: 0x007BDD6E File Offset: 0x007BC16E
		public override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.ChatRecordManager;
		}

		// Token: 0x06018C4F RID: 101455 RVA: 0x007BDD74 File Offset: 0x007BC174
		public override void Clear()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RoleIdChanged, new ClientEventSystem.UIEventHandler(this._OnRoleIdChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RoleChatDirtyChanged, new ClientEventSystem.UIEventHandler(this._OnRoleChatDirtyChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnRelationChanged, new ClientEventSystem.UIEventHandler(this._OnRelationChanged));
		}

		// Token: 0x06018C50 RID: 101456 RVA: 0x007BDDD2 File Offset: 0x007BC1D2
		private void _OnRoleIdChanged(ulong ulPreRoleId, ulong ulAftRoleId)
		{
			if (ulPreRoleId != 0UL)
			{
				this.PrivateChatRecordsConfig.SaveData2Jason(ulPreRoleId);
			}
			if (ulAftRoleId != 0UL)
			{
				this.PrivateChatRecordsConfig.ReadDataFromJson(ulAftRoleId, this.onLoadPrivateChatDataOK);
			}
		}

		// Token: 0x06018C51 RID: 101457 RVA: 0x007BDE02 File Offset: 0x007BC202
		private void _OnRoleIdChanged(UIEvent uiEvent)
		{
			this._OnRoleIdChanged((ulong)uiEvent.Param1, (ulong)uiEvent.Param2);
		}

		// Token: 0x06018C52 RID: 101458 RVA: 0x007BDE20 File Offset: 0x007BC220
		private void _OnRoleChatDirtyChanged(UIEvent uiEvent)
		{
			ulong num = (ulong)uiEvent.Param1;
			bool dirty = (bool)uiEvent.Param2;
			ChatRecordManager.RoleChatRecords chatRecords = this.PrivateChatRecordsConfig.GetChatRecords(DataManager<PlayerBaseData>.GetInstance().RoleID);
			if (chatRecords != null)
			{
				for (int i = 0; i < chatRecords.RoleChats.Count; i++)
				{
					ChatRecordManager.TargetChatRecords targetChatRecords = chatRecords.RoleChats[i];
					if (targetChatRecords != null && targetChatRecords.friendId == (long)num)
					{
						targetChatRecords.Dirty = dirty;
						break;
					}
				}
			}
		}

		// Token: 0x06018C53 RID: 101459 RVA: 0x007BDEAC File Offset: 0x007BC2AC
		private void _OnRelationChanged(UIEvent uiEvent)
		{
			RelationData rd = uiEvent.Param1 as RelationData;
			bool flag = (bool)uiEvent.Param2;
			ChatRecordManager.RoleChatRecords chatRecords = this.PrivateChatRecordsConfig.GetChatRecords(DataManager<PlayerBaseData>.GetInstance().RoleID);
			if (chatRecords == null)
			{
				return;
			}
			ChatRecordManager.TargetChatRecords targetChatRecords = chatRecords.RoleChats.Find((ChatRecordManager.TargetChatRecords x) => x.friendId == (long)rd.uid);
			if (targetChatRecords == null)
			{
				return;
			}
			if (flag)
			{
				rd.type = 3;
			}
			targetChatRecords.RelationDataRecords.ConvertFrom(rd);
		}

		// Token: 0x06018C54 RID: 101460 RVA: 0x007BDF3C File Offset: 0x007BC33C
		public ChatRecordManager.RoleChatRecords GetChatRecords(ulong RoleId)
		{
			return this.PrivateChatRecordsConfig.GetChatRecords(RoleId);
		}

		// Token: 0x06018C55 RID: 101461 RVA: 0x007BDF4C File Offset: 0x007BC34C
		public void RemoveChatRecords(ulong RoleId, ulong friendId)
		{
			ChatRecordManager.RoleChatRecords chatRecords = this.PrivateChatRecordsConfig.GetChatRecords(RoleId);
			if (chatRecords != null)
			{
				chatRecords.RoleChats.RemoveAll((ChatRecordManager.TargetChatRecords x) => x.friendId == (long)friendId);
			}
		}

		// Token: 0x04011D7E RID: 73086
		public ChatRecordManager.OnLoadPrivateChatDataOK onLoadPrivateChatDataOK;

		// Token: 0x04011D7F RID: 73087
		public const int functionId = 3;

		// Token: 0x04011D80 RID: 73088
		private ChatRecordManager.ChatRecordsConfig m_kChatRecords = new ChatRecordManager.ChatRecordsConfig();

		// Token: 0x02004561 RID: 17761
		// (Invoke) Token: 0x06018C57 RID: 101463
		public delegate void OnLoadPrivateChatDataOK(ulong roleId);

		// Token: 0x02004562 RID: 17762
		public class RoleChatRecords
		{
			// Token: 0x17002050 RID: 8272
			// (get) Token: 0x06018C5B RID: 101467 RVA: 0x007BDFA4 File Offset: 0x007BC3A4
			// (set) Token: 0x06018C5C RID: 101468 RVA: 0x007BDFAC File Offset: 0x007BC3AC
			public long RoleId { get; set; }

			// Token: 0x17002051 RID: 8273
			// (get) Token: 0x06018C5D RID: 101469 RVA: 0x007BDFB5 File Offset: 0x007BC3B5
			// (set) Token: 0x06018C5E RID: 101470 RVA: 0x007BDFBD File Offset: 0x007BC3BD
			public List<ChatRecordManager.TargetChatRecords> RoleChats
			{
				get
				{
					return this.targetRecords;
				}
				set
				{
					this.targetRecords = value;
				}
			}

			// Token: 0x06018C5F RID: 101471 RVA: 0x007BDFC6 File Offset: 0x007BC3C6
			public void Clear()
			{
				this.targetRecords.Clear();
			}

			// Token: 0x06018C60 RID: 101472 RVA: 0x007BDFD4 File Offset: 0x007BC3D4
			public void AddChatRecords(ulong targetId, ChatData data, RoleInfo roleInfo)
			{
				ChatRecordManager.TargetChatRecords targetChatRecords = this.RoleChats.Find((ChatRecordManager.TargetChatRecords x) => x.friendId == (long)targetId);
				if (targetChatRecords == null)
				{
					targetChatRecords = new ChatRecordManager.TargetChatRecords();
					targetChatRecords.friendId = (long)targetId;
					PrivateChatPlayerData privateChatPlayerData = DataManager<RelationDataManager>.GetInstance().GetPriChatList().Find((PrivateChatPlayerData x) => x.relationData.uid == targetId);
					if (privateChatPlayerData != null)
					{
						targetChatRecords.RelationDataRecords.ConvertFrom(privateChatPlayerData.relationData);
					}
					if (targetChatRecords.RelationDataRecords.uid > 0L)
					{
						this.RoleChats.Add(targetChatRecords);
					}
				}
				if (targetChatRecords != null)
				{
					ChatRecordManager.PrivateChatRecords privateChatRecords;
					if (targetChatRecords.TargetChats.Count < ChatRecordManager.TargetChatRecords.ms_max_records)
					{
						privateChatRecords = ChatRecordManager.PrivateChatRecords.ConvertFrom(data, roleInfo.roleId);
					}
					else
					{
						privateChatRecords = targetChatRecords.TargetChats[0];
						targetChatRecords.TargetChats.RemoveAt(0);
						privateChatRecords.Convert(data, roleInfo.roleId);
					}
					targetChatRecords.TargetChats.Add(privateChatRecords);
				}
			}

			// Token: 0x06018C61 RID: 101473 RVA: 0x007BE0D8 File Offset: 0x007BC4D8
			public void TryUpdateRelation()
			{
				for (int i = 0; i < this.RoleChats.Count; i++)
				{
					ChatRecordManager.TargetChatRecords targetChatRecords = this.RoleChats[i];
					if (targetChatRecords != null)
					{
						RelationData relationByRoleID = DataManager<RelationDataManager>.GetInstance().GetRelationByRoleID((ulong)targetChatRecords.friendId);
						if (relationByRoleID != null)
						{
							targetChatRecords.RelationDataRecords.ConvertFrom(relationByRoleID);
						}
						else
						{
							targetChatRecords.RelationDataRecords.type = 3;
						}
					}
				}
			}

			// Token: 0x04011D82 RID: 73090
			private List<ChatRecordManager.TargetChatRecords> targetRecords = new List<ChatRecordManager.TargetChatRecords>();
		}

		// Token: 0x02004563 RID: 17763
		public class RelationDataRecords
		{
			// Token: 0x17002052 RID: 8274
			// (get) Token: 0x06018C63 RID: 101475 RVA: 0x007BE183 File Offset: 0x007BC583
			// (set) Token: 0x06018C64 RID: 101476 RVA: 0x007BE18B File Offset: 0x007BC58B
			public byte type { get; set; }

			// Token: 0x17002053 RID: 8275
			// (get) Token: 0x06018C65 RID: 101477 RVA: 0x007BE194 File Offset: 0x007BC594
			// (set) Token: 0x06018C66 RID: 101478 RVA: 0x007BE19C File Offset: 0x007BC59C
			public long uid { get; set; }

			// Token: 0x17002054 RID: 8276
			// (get) Token: 0x06018C67 RID: 101479 RVA: 0x007BE1A5 File Offset: 0x007BC5A5
			// (set) Token: 0x06018C68 RID: 101480 RVA: 0x007BE1AD File Offset: 0x007BC5AD
			public string name { get; set; }

			// Token: 0x17002055 RID: 8277
			// (get) Token: 0x06018C69 RID: 101481 RVA: 0x007BE1B6 File Offset: 0x007BC5B6
			// (set) Token: 0x06018C6A RID: 101482 RVA: 0x007BE1BE File Offset: 0x007BC5BE
			public int seasonlv { get; set; }

			// Token: 0x17002056 RID: 8278
			// (get) Token: 0x06018C6B RID: 101483 RVA: 0x007BE1C7 File Offset: 0x007BC5C7
			// (set) Token: 0x06018C6C RID: 101484 RVA: 0x007BE1CF File Offset: 0x007BC5CF
			public ushort level { get; set; }

			// Token: 0x17002057 RID: 8279
			// (get) Token: 0x06018C6D RID: 101485 RVA: 0x007BE1D8 File Offset: 0x007BC5D8
			// (set) Token: 0x06018C6E RID: 101486 RVA: 0x007BE1E0 File Offset: 0x007BC5E0
			public byte occu { get; set; }

			// Token: 0x17002058 RID: 8280
			// (get) Token: 0x06018C6F RID: 101487 RVA: 0x007BE1E9 File Offset: 0x007BC5E9
			// (set) Token: 0x06018C70 RID: 101488 RVA: 0x007BE1F1 File Offset: 0x007BC5F1
			public byte dayGiftNum { get; set; }

			// Token: 0x17002059 RID: 8281
			// (get) Token: 0x06018C71 RID: 101489 RVA: 0x007BE1FA File Offset: 0x007BC5FA
			// (set) Token: 0x06018C72 RID: 101490 RVA: 0x007BE202 File Offset: 0x007BC602
			public byte isOnline { get; set; }

			// Token: 0x1700205A RID: 8282
			// (get) Token: 0x06018C73 RID: 101491 RVA: 0x007BE20B File Offset: 0x007BC60B
			// (set) Token: 0x06018C74 RID: 101492 RVA: 0x007BE213 File Offset: 0x007BC613
			public uint createTime { get; set; }

			// Token: 0x1700205B RID: 8283
			// (get) Token: 0x06018C75 RID: 101493 RVA: 0x007BE21C File Offset: 0x007BC61C
			// (set) Token: 0x06018C76 RID: 101494 RVA: 0x007BE224 File Offset: 0x007BC624
			public byte vipLv { get; set; }

			// Token: 0x06018C77 RID: 101495 RVA: 0x007BE230 File Offset: 0x007BC630
			public ChatRecordManager.RelationDataRecords ConvertFrom(RelationData rd)
			{
				if (rd != null)
				{
					this.type = rd.type;
					this.uid = (long)rd.uid;
					this.name = rd.name;
					this.seasonlv = (int)rd.seasonLv;
					this.level = rd.level;
					this.occu = rd.occu;
					this.dayGiftNum = rd.dayGiftNum;
					this.isOnline = rd.isOnline;
					this.createTime = rd.createTime;
					this.vipLv = rd.vipLv;
				}
				return this;
			}

			// Token: 0x06018C78 RID: 101496 RVA: 0x007BE2BC File Offset: 0x007BC6BC
			public RelationData ConvertTo(RelationData target)
			{
				if (target != null)
				{
					target.type = this.type;
					target.uid = (ulong)this.uid;
					target.name = this.name;
					target.seasonLv = (uint)this.seasonlv;
					target.level = this.level;
					target.occu = this.occu;
					target.dayGiftNum = this.dayGiftNum;
					target.isOnline = this.isOnline;
					target.createTime = this.createTime;
					target.vipLv = this.vipLv;
				}
				return target;
			}
		}

		// Token: 0x02004564 RID: 17764
		public class TargetChatRecords
		{
			// Token: 0x1700205C RID: 8284
			// (get) Token: 0x06018C7A RID: 101498 RVA: 0x007BE366 File Offset: 0x007BC766
			// (set) Token: 0x06018C7B RID: 101499 RVA: 0x007BE36E File Offset: 0x007BC76E
			public bool Dirty { get; set; }

			// Token: 0x1700205D RID: 8285
			// (get) Token: 0x06018C7C RID: 101500 RVA: 0x007BE377 File Offset: 0x007BC777
			// (set) Token: 0x06018C7D RID: 101501 RVA: 0x007BE384 File Offset: 0x007BC784
			public long friendId
			{
				get
				{
					return this.RelationDataRecords.uid;
				}
				set
				{
					this.RelationDataRecords.uid = value;
				}
			}

			// Token: 0x1700205E RID: 8286
			// (get) Token: 0x06018C7E RID: 101502 RVA: 0x007BE392 File Offset: 0x007BC792
			// (set) Token: 0x06018C7F RID: 101503 RVA: 0x007BE39A File Offset: 0x007BC79A
			public ChatRecordManager.RelationDataRecords RelationDataRecords
			{
				get
				{
					return this.relationRecords;
				}
				set
				{
					this.relationRecords = value;
				}
			}

			// Token: 0x1700205F RID: 8287
			// (get) Token: 0x06018C80 RID: 101504 RVA: 0x007BE3A3 File Offset: 0x007BC7A3
			// (set) Token: 0x06018C81 RID: 101505 RVA: 0x007BE3AB File Offset: 0x007BC7AB
			public List<ChatRecordManager.PrivateChatRecords> TargetChats
			{
				get
				{
					return this.targetChats;
				}
				set
				{
					this.targetChats = value;
				}
			}

			// Token: 0x04011D8D RID: 73101
			public static int ms_max_records = 50;

			// Token: 0x04011D8F RID: 73103
			private ChatRecordManager.RelationDataRecords relationRecords = new ChatRecordManager.RelationDataRecords();

			// Token: 0x04011D90 RID: 73104
			private List<ChatRecordManager.PrivateChatRecords> targetChats = new List<ChatRecordManager.PrivateChatRecords>();
		}

		// Token: 0x02004565 RID: 17765
		public class PrivateChatRecords
		{
			// Token: 0x17002060 RID: 8288
			// (get) Token: 0x06018C84 RID: 101508 RVA: 0x007BE3C5 File Offset: 0x007BC7C5
			// (set) Token: 0x06018C85 RID: 101509 RVA: 0x007BE3CD File Offset: 0x007BC7CD
			public byte Mark { get; set; }

			// Token: 0x17002061 RID: 8289
			// (get) Token: 0x06018C86 RID: 101510 RVA: 0x007BE3D6 File Offset: 0x007BC7D6
			// (set) Token: 0x06018C87 RID: 101511 RVA: 0x007BE3DE File Offset: 0x007BC7DE
			public string word { get; set; }

			// Token: 0x17002062 RID: 8290
			// (get) Token: 0x06018C88 RID: 101512 RVA: 0x007BE3E7 File Offset: 0x007BC7E7
			// (set) Token: 0x06018C89 RID: 101513 RVA: 0x007BE3EF File Offset: 0x007BC7EF
			public string shortTimeString { get; set; }

			// Token: 0x17002063 RID: 8291
			// (get) Token: 0x06018C8A RID: 101514 RVA: 0x007BE3F8 File Offset: 0x007BC7F8
			// (set) Token: 0x06018C8B RID: 101515 RVA: 0x007BE400 File Offset: 0x007BC800
			public string voiceKey { get; set; }

			// Token: 0x17002064 RID: 8292
			// (get) Token: 0x06018C8C RID: 101516 RVA: 0x007BE409 File Offset: 0x007BC809
			// (set) Token: 0x06018C8D RID: 101517 RVA: 0x007BE411 File Offset: 0x007BC811
			public byte voiceDuration { get; set; }

			// Token: 0x17002065 RID: 8293
			// (get) Token: 0x06018C8E RID: 101518 RVA: 0x007BE41A File Offset: 0x007BC81A
			// (set) Token: 0x06018C8F RID: 101519 RVA: 0x007BE422 File Offset: 0x007BC822
			public byte timeStamp { get; set; }

			// Token: 0x17002066 RID: 8294
			// (get) Token: 0x06018C90 RID: 101520 RVA: 0x007BE42B File Offset: 0x007BC82B
			// (set) Token: 0x06018C91 RID: 101521 RVA: 0x007BE433 File Offset: 0x007BC833
			public bool isShowTimeStamp { get; set; }

			// Token: 0x17002067 RID: 8295
			// (get) Token: 0x06018C92 RID: 101522 RVA: 0x007BE43C File Offset: 0x007BC83C
			// (set) Token: 0x06018C93 RID: 101523 RVA: 0x007BE444 File Offset: 0x007BC844
			public uint headFrame { get; set; }

			// Token: 0x06018C94 RID: 101524 RVA: 0x007BE44D File Offset: 0x007BC84D
			public static ChatRecordManager.PrivateChatRecords ConvertFrom(ChatData chatData, ulong RoleId)
			{
				return new ChatRecordManager.PrivateChatRecords().Convert(chatData, RoleId);
			}

			// Token: 0x06018C95 RID: 101525 RVA: 0x007BE45C File Offset: 0x007BC85C
			public ChatRecordManager.PrivateChatRecords Convert(ChatData chatData, ulong RoleId)
			{
				this.Mark = 0;
				if (RoleId == chatData.objid)
				{
					this.Mark |= 1;
				}
				this.word = chatData.word;
				this.shortTimeString = chatData.shortTimeString;
				this.timeStamp = (byte)chatData.timeStamp;
				this.isShowTimeStamp = chatData.isShowTimeStamp;
				this.headFrame = chatData.headFrame;
				if (chatData.bLink == 1)
				{
					this.Mark |= 2;
				}
				if (chatData.bGm)
				{
					this.Mark |= 4;
				}
				if (chatData.bVoice)
				{
					this.Mark |= 8;
					this.voiceKey = chatData.voiceKey;
					this.voiceDuration = chatData.voiceDuration;
					if (chatData.bVoicePlayFirst)
					{
						this.Mark |= 16;
					}
				}
				else
				{
					this.voiceKey = string.Empty;
					this.voiceDuration = 0;
				}
				if (chatData.bRedPacket)
				{
					this.Mark |= 32;
				}
				if (chatData.bAddFriend)
				{
					this.Mark |= 64;
				}
				return this;
			}

			// Token: 0x06018C96 RID: 101526 RVA: 0x007BE598 File Offset: 0x007BC998
			public static ChatData ConvertFrom(ChatRecordManager.PrivateChatRecords chatData, RelationData rd, RoleInfo roleInfo)
			{
				return new ChatData
				{
					channel = (byte)DataManager<ChatManager>.GetInstance()._TransChatType(ChatType.CT_PRIVATE),
					objid = (((chatData.Mark & 1) <= 0) ? rd.uid : roleInfo.roleId),
					sex = 0,
					occu = (((chatData.Mark & 1) <= 0) ? rd.occu : roleInfo.occupation),
					level = (((chatData.Mark & 1) <= 0) ? rd.level : roleInfo.level),
					viplvl = (((chatData.Mark & 1) <= 0) ? rd.vipLv : ((byte)((DataManager<PlayerBaseData>.GetInstance().VipLevel > 0) ? DataManager<PlayerBaseData>.GetInstance().VipLevel : 0))),
					objname = (((chatData.Mark & 1) <= 0) ? rd.name : roleInfo.name),
					word = chatData.word,
					guid = 0,
					shortTimeString = chatData.shortTimeString,
					targetID = (((chatData.Mark & 1) <= 0) ? roleInfo.roleId : rd.uid),
					bLink = (((chatData.Mark & 2) <= 0) ? 0 : 1),
					bGm = ((chatData.Mark & 4) > 0),
					eChatType = ChatType.CT_PRIVATE,
					bVoice = ((chatData.Mark & 8) > 0),
					bVoicePlayFirst = ((chatData.Mark & 16) > 0),
					voiceKey = chatData.voiceKey,
					voiceDuration = chatData.voiceDuration,
					bRedPacket = ((chatData.Mark & 32) > 0),
					timeStamp = (uint)chatData.timeStamp,
					isShowTimeStamp = chatData.isShowTimeStamp,
					bAddFriend = ((chatData.Mark & 64) > 0),
					headFrame = chatData.headFrame
				};
			}

			// Token: 0x02004566 RID: 17766
			public enum ChatMark
			{
				// Token: 0x04011D9A RID: 73114
				CM_SELF = 1,
				// Token: 0x04011D9B RID: 73115
				CM_LINK,
				// Token: 0x04011D9C RID: 73116
				CM_GM = 4,
				// Token: 0x04011D9D RID: 73117
				CM_VOICE = 8,
				// Token: 0x04011D9E RID: 73118
				CM_VOICE_FIRST = 16,
				// Token: 0x04011D9F RID: 73119
				CM_RED_PACKET = 32,
				// Token: 0x04011DA0 RID: 73120
				CM_ADD_FRIEND = 64
			}
		}

		// Token: 0x02004567 RID: 17767
		private class ChatRecordsConfig
		{
			// Token: 0x17002068 RID: 8296
			// (get) Token: 0x06018C98 RID: 101528 RVA: 0x007BE7D0 File Offset: 0x007BCBD0
			// (set) Token: 0x06018C99 RID: 101529 RVA: 0x007BE7D8 File Offset: 0x007BCBD8
			public List<ChatRecordManager.RoleChatRecords> ChatRecords
			{
				get
				{
					return this.chatRecords;
				}
				set
				{
					this.chatRecords = value;
				}
			}

			// Token: 0x06018C9A RID: 101530 RVA: 0x007BE7E4 File Offset: 0x007BCBE4
			public ChatRecordManager.RoleChatRecords GetChatRecords(ulong RoleId)
			{
				return this.ChatRecords.Find((ChatRecordManager.RoleChatRecords x) => x.RoleId == (long)RoleId);
			}

			// Token: 0x06018C9B RID: 101531 RVA: 0x007BE818 File Offset: 0x007BCC18
			public void AddPrivateChatData(ChatData chatData, RoleInfo roleInfo)
			{
				if (chatData == null)
				{
					return;
				}
				if (roleInfo == null)
				{
					Logger.LogErrorFormat("role info error!", new object[0]);
					return;
				}
				ulong num = (roleInfo.roleId != chatData.objid) ? chatData.objid : chatData.targetID;
				if (num == 0UL)
				{
					Logger.LogErrorFormat("targetId == 0 is Error! roleInfo.roleId is {0}, chatData.objId is {1}, and chatData.targetId is {2}", new object[]
					{
						roleInfo.roleId,
						chatData.objid,
						chatData.targetID
					});
					return;
				}
				ChatRecordManager.RoleChatRecords roleChatRecords = this.ChatRecords.Find((ChatRecordManager.RoleChatRecords x) => x.RoleId == (long)roleInfo.roleId);
				if (roleChatRecords == null)
				{
					roleChatRecords = new ChatRecordManager.RoleChatRecords();
					roleChatRecords.RoleId = (long)roleInfo.roleId;
					this.ChatRecords.Add(roleChatRecords);
				}
				if (roleChatRecords != null)
				{
					roleChatRecords.AddChatRecords(num, chatData, roleInfo);
				}
			}

			// Token: 0x06018C9C RID: 101532 RVA: 0x007BE91A File Offset: 0x007BCD1A
			public static string GetSavePath(ulong RoleId)
			{
				if (RoleId > 0UL)
				{
					return string.Format("ChatRecords_{0}.json", RoleId);
				}
				return string.Empty;
			}

			// Token: 0x06018C9D RID: 101533 RVA: 0x007BE93C File Offset: 0x007BCD3C
			public void SaveData2Jason(ulong RoleId)
			{
				if (RoleId > 0UL && SwitchFunctionUtility.IsOpen(3))
				{
					ChatRecordManager.RoleChatRecords roleChatRecords = this.ChatRecords.Find((ChatRecordManager.RoleChatRecords x) => x.RoleId == (long)RoleId);
					if (roleChatRecords != null)
					{
						string savePath = ChatRecordManager.ChatRecordsConfig.GetSavePath(RoleId);
						if (!string.IsNullOrEmpty(savePath))
						{
							string text = JsonMapper.ToJson(roleChatRecords);
							if (!string.IsNullOrEmpty(text))
							{
								FileArchiveAccessor.SaveFileInPersistentFileArchive(savePath, text);
							}
						}
						this.ChatRecords.Remove(roleChatRecords);
					}
				}
			}

			// Token: 0x06018C9E RID: 101534 RVA: 0x007BE9CC File Offset: 0x007BCDCC
			public void ReadDataFromJson(ulong RoleId, ChatRecordManager.OnLoadPrivateChatDataOK onLoadPrivateChatDataOK)
			{
				if (SwitchFunctionUtility.IsOpen(3))
				{
					string savePath = ChatRecordManager.ChatRecordsConfig.GetSavePath(RoleId);
					if (string.IsNullOrEmpty(savePath))
					{
						Logger.LogErrorFormat("read data from json path is empty!", new object[0]);
						return;
					}
					string text = null;
					FileArchiveAccessor.LoadFileInPersistentFileArchive(savePath, out text);
					if (string.IsNullOrEmpty(text))
					{
						return;
					}
					ChatRecordManager.RoleChatRecords roleChatRecords = JsonMapper.ToObject<ChatRecordManager.RoleChatRecords>(text);
					if (roleChatRecords == null)
					{
						Logger.LogErrorFormat("json2object failed !", new object[0]);
						return;
					}
					if (roleChatRecords.RoleId != (long)RoleId)
					{
						Logger.LogErrorFormat("json data may be error,roleId can not matched!", new object[0]);
						return;
					}
					this.ChatRecords.RemoveAll((ChatRecordManager.RoleChatRecords x) => x.RoleId == (long)RoleId);
					this.ChatRecords.Add(roleChatRecords);
					if (onLoadPrivateChatDataOK != null)
					{
						onLoadPrivateChatDataOK(RoleId);
					}
				}
			}

			// Token: 0x04011DA1 RID: 73121
			private List<ChatRecordManager.RoleChatRecords> chatRecords = new List<ChatRecordManager.RoleChatRecords>();
		}
	}
}
