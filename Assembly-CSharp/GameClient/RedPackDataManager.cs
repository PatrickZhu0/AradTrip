using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020012D0 RID: 4816
	internal class RedPackDataManager : DataManager<RedPackDataManager>
	{
		// Token: 0x0600BAB3 RID: 47795 RVA: 0x002B2BC6 File Offset: 0x002B0FC6
		public override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.RedPackDataManager;
		}

		// Token: 0x0600BAB4 RID: 47796 RVA: 0x002B2BCC File Offset: 0x002B0FCC
		public override void Initialize()
		{
			this.Clear();
			this._BindNetMsg();
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(334, string.Empty, string.Empty);
			this.NewYearRedPackActivityID = tableItem.Value;
			SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(336, string.Empty, string.Empty);
			this.NewYearRedPackRankListActivityID = tableItem2.Value;
			this.redPacketRecords = new Dictionary<ulong, RedPacketRecord>();
			this.guildRedPacketSpecInfos = new Dictionary<SendRedPackType, GuildRedPacketSpecInfo>();
		}

		// Token: 0x0600BAB5 RID: 47797 RVA: 0x002B2C47 File Offset: 0x002B1047
		public override void Clear()
		{
			this._UnBindNetMsg();
			this.NewYearRedPackActivityID = 0;
			this.NewYearRedPackRankListActivityID = 0;
			this.m_dictRedPackets.Clear();
			this.m_dictPacketType.Clear();
			this.redPacketRecords = null;
			this.guildRedPacketSpecInfos = null;
		}

		// Token: 0x0600BAB6 RID: 47798 RVA: 0x002B2C84 File Offset: 0x002B1084
		public RedPacketBaseEntry GetRedPacketBaseInfo(ulong a_uID)
		{
			RedPacketBaseEntry result = null;
			this.m_dictRedPackets.TryGetValue(a_uID, out result);
			return result;
		}

		// Token: 0x0600BAB7 RID: 47799 RVA: 0x002B2CA4 File Offset: 0x002B10A4
		public string GetGuildRedPacketTitleName(RedPacketBaseEntry redPacketBaseEntry)
		{
			if (redPacketBaseEntry == null)
			{
				return string.Empty;
			}
			RedPacketTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<RedPacketTable>((int)redPacketBaseEntry.reason, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return string.Empty;
			}
			if (tableItem.ThirdType == RedPacketTable.eThirdType.GUILD_ALL)
			{
				return TR.Value("guild_red_packet_all_members");
			}
			if (tableItem.ThirdType == RedPacketTable.eThirdType.GUILD_BATTLE)
			{
				DateTime dateTimeByTimeStamp = TimeUtility.GetDateTimeByTimeStamp((int)redPacketBaseEntry.guildTimeStamp);
				return TR.Value("guild_red_packet_take_part_in_guild_battle", dateTimeByTimeStamp.Month, dateTimeByTimeStamp.Day);
			}
			if (tableItem.ThirdType == RedPacketTable.eThirdType.GUILD_CROSS_BATTLE)
			{
				DateTime dateTimeByTimeStamp2 = TimeUtility.GetDateTimeByTimeStamp((int)redPacketBaseEntry.guildTimeStamp);
				return TR.Value("guild_red_packet_take_part_in_cross_guild_battle", dateTimeByTimeStamp2.Month, dateTimeByTimeStamp2.Day);
			}
			if (tableItem.ThirdType == RedPacketTable.eThirdType.GUILD_DUNGEON)
			{
				DateTime dateTimeByTimeStamp3 = TimeUtility.GetDateTimeByTimeStamp((int)redPacketBaseEntry.guildTimeStamp);
				return TR.Value("guild_red_packet_take_part_in_guild_dungeon", dateTimeByTimeStamp3.Month, dateTimeByTimeStamp3.Day);
			}
			return string.Empty;
		}

		// Token: 0x0600BAB8 RID: 47800 RVA: 0x002B2DB4 File Offset: 0x002B11B4
		public string GetRedPacketStateText(int state)
		{
			if (state == 3)
			{
				return TR.Value("guild_red_packet_received");
			}
			if (state == 4)
			{
				return TR.Value("guild_red_packet_empty");
			}
			return string.Empty;
		}

		// Token: 0x0600BAB9 RID: 47801 RVA: 0x002B2DEC File Offset: 0x002B11EC
		public List<RedPacketBaseEntry> GetRedPacketsByType(RedPacketType a_eType)
		{
			List<RedPacketBaseEntry> list = new List<RedPacketBaseEntry>();
			List<ulong> list2 = null;
			this.m_dictPacketType.TryGetValue(a_eType, out list2);
			if (list2 != null)
			{
				for (int i = 0; i < list2.Count; i++)
				{
					list.Add(this.m_dictRedPackets[list2[i]]);
				}
			}
			return list;
		}

		// Token: 0x0600BABA RID: 47802 RVA: 0x002B2E48 File Offset: 0x002B1248
		public RedPacketBaseEntry GetFirstRedPacketToOpen()
		{
			foreach (KeyValuePair<ulong, RedPacketBaseEntry> keyValuePair in this.m_dictRedPackets)
			{
				RedPacketBaseEntry value = keyValuePair.Value;
				if (value.opened == 0 && value.status == 2 && value.opened == 0)
				{
					return value;
				}
			}
			return null;
		}

		// Token: 0x0600BABB RID: 47803 RVA: 0x002B2EA7 File Offset: 0x002B12A7
		public Dictionary<ulong, RedPacketRecord> GetRedPacketRecords()
		{
			return this.redPacketRecords;
		}

		// Token: 0x0600BABC RID: 47804 RVA: 0x002B2EAF File Offset: 0x002B12AF
		public Dictionary<SendRedPackType, GuildRedPacketSpecInfo> GetGuildRedPacketSpecInfos()
		{
			return this.guildRedPacketSpecInfos;
		}

		// Token: 0x0600BABD RID: 47805 RVA: 0x002B2EB7 File Offset: 0x002B12B7
		public GuildRedPacketSpecInfo GetGuildRedPacketSpecInfo(SendRedPackType sendRedPackType)
		{
			return this.guildRedPacketSpecInfos.SafeGetValue(sendRedPackType);
		}

		// Token: 0x0600BABE RID: 47806 RVA: 0x002B2EC5 File Offset: 0x002B12C5
		public RedPacketRecord GetRedPacketRecord(ulong guid)
		{
			if (this.redPacketRecords == null)
			{
				return null;
			}
			if (this.redPacketRecords.ContainsKey(guid))
			{
				return this.redPacketRecords[guid];
			}
			return null;
		}

		// Token: 0x0600BABF RID: 47807 RVA: 0x002B2EF4 File Offset: 0x002B12F4
		public int GetWaitOpenCount()
		{
			int num = 0;
			foreach (KeyValuePair<ulong, RedPacketBaseEntry> keyValuePair in this.m_dictRedPackets)
			{
				RedPacketBaseEntry value = keyValuePair.Value;
				if (value.status == 2 && value.opened == 0)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x0600BAC0 RID: 47808 RVA: 0x002B2F4C File Offset: 0x002B134C
		public string GetGetMoneyIcon(int a_nTableID)
		{
			RedPacketTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<RedPacketTable>(a_nTableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("红包表找不到ID为{0}的数据", new object[]
				{
					a_nTableID
				});
				return string.Empty;
			}
			ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(tableItem.GetMoneyID);
			if (commonItemTableDataByID != null)
			{
				return commonItemTableDataByID.Icon;
			}
			return string.Empty;
		}

		// Token: 0x0600BAC1 RID: 47809 RVA: 0x002B2FB8 File Offset: 0x002B13B8
		public string GetCostMoneyIcon(int a_nTableID)
		{
			RedPacketTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<RedPacketTable>(a_nTableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("红包表找不到ID为{0}的数据", new object[]
				{
					a_nTableID
				});
				return string.Empty;
			}
			ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(tableItem.CostMoneyID);
			if (commonItemTableDataByID != null)
			{
				return commonItemTableDataByID.Icon;
			}
			return string.Empty;
		}

		// Token: 0x0600BAC2 RID: 47810 RVA: 0x002B3024 File Offset: 0x002B1424
		public void SendWorldGetGuildRedPacketInfoReq()
		{
			WorldGetGuildRedPacketInfoReq cmd = new WorldGetGuildRedPacketInfoReq();
			NetManager.Instance().SendCommand<WorldGetGuildRedPacketInfoReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600BAC3 RID: 47811 RVA: 0x002B3044 File Offset: 0x002B1444
		public void SendRedPacket(ushort a_uID, int a_nCount, string des)
		{
			WorldSendCustomRedPacketReq worldSendCustomRedPacketReq = new WorldSendCustomRedPacketReq();
			worldSendCustomRedPacketReq.reason = a_uID;
			worldSendCustomRedPacketReq.num = (byte)a_nCount;
			worldSendCustomRedPacketReq.name = des;
			uint nTimes = (uint)(DataManager<CountDataManager>.GetInstance().GetCount("guild_pay_rp") + 1);
			NetManager.Instance().SendCommand<WorldSendCustomRedPacketReq>(ServerType.GATE_SERVER, worldSendCustomRedPacketReq);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldSendCustomRedPacketRes>(delegate(WorldSendCustomRedPacketRes msgRet)
			{
				if (msgRet.result != 0U)
				{
					SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
				}
				else
				{
					SystemNotifyManager.SysNotifyFloatingEffect("红包发送成功", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					RedPacketTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<RedPacketTable>((int)a_uID, string.Empty, string.Empty);
					if (tableItem != null && tableItem.ThirdType != RedPacketTable.eThirdType.INVALID)
					{
						DataManager<CountDataManager>.GetInstance().SetCount("guild_pay_rp", nTimes);
						if ((ulong)nTimes >= (ulong)((long)DataManager<GuildDataManager>.GetInstance().GetDailySendRedPacketMaxCount()))
						{
							SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("guild_red_packet_daily_left_count_zero"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
						}
					}
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RedPacketSendSuccess, a_uID, null, null, null);
				}
			}, true, 15f, null);
		}

		// Token: 0x0600BAC4 RID: 47812 RVA: 0x002B30C4 File Offset: 0x002B14C4
		public void OpenRedPacket(ulong a_uID)
		{
			RedPacketBaseEntry redPacketBaseInfo = this.GetRedPacketBaseInfo(a_uID);
			if (redPacketBaseInfo == null)
			{
				return;
			}
			if (redPacketBaseInfo.type == 2)
			{
				ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(this.NewYearRedPackRankListActivityID);
				if (activeData == null)
				{
					return;
				}
				if (DataManager<PlayerBaseData>.GetInstance().Level < activeData.mainInfo.level)
				{
					SystemNotifyManager.SysNotifyFloatingEffect(string.Format("等级不足{0}级,无法领取红包", activeData.mainInfo.level), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
			}
			WorldOpenRedPacketReq worldOpenRedPacketReq = new WorldOpenRedPacketReq();
			worldOpenRedPacketReq.id = a_uID;
			NetManager.Instance().SendCommand<WorldOpenRedPacketReq>(ServerType.GATE_SERVER, worldOpenRedPacketReq);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldOpenRedPacketRes>(delegate(WorldOpenRedPacketRes msgRet)
			{
				if (msgRet.result != 0U)
				{
					SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
				}
				else
				{
					RedPacketBaseEntry redPacketBaseInfo2 = this.GetRedPacketBaseInfo(msgRet.detail.baseEntry.id);
					if (redPacketBaseInfo2 == null)
					{
						SystemNotifyManager.SysNotifyTextAnimation("红包已抢完", CommonTipsDesc.eShowMode.SI_UNIQUE);
						return;
					}
					if (redPacketBaseInfo2.opened == 1)
					{
						ShowOpenedRedPacketFrame.showRedPacketMode = ShowRedPacketMode.Show;
					}
					redPacketBaseInfo2.status = msgRet.detail.baseEntry.status;
					redPacketBaseInfo2.opened = msgRet.detail.baseEntry.opened;
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<OpenRedPacketFrame>(FrameLayer.Middle, msgRet.detail, string.Empty);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RedPacketOpenSuccess, msgRet.detail, null, null, null);
					DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.GuildRedPacket);
				}
			}, true, 15f, null);
		}

		// Token: 0x0600BAC5 RID: 47813 RVA: 0x002B3178 File Offset: 0x002B1578
		public void CheckRedPacket(ulong a_uID)
		{
			WorldOpenRedPacketReq worldOpenRedPacketReq = new WorldOpenRedPacketReq();
			worldOpenRedPacketReq.id = a_uID;
			NetManager.Instance().SendCommand<WorldOpenRedPacketReq>(ServerType.GATE_SERVER, worldOpenRedPacketReq);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldOpenRedPacketRes>(delegate(WorldOpenRedPacketRes msgRet)
			{
				if (msgRet.result != 0U)
				{
					SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
				}
				else
				{
					RedPacketBaseEntry redPacketBaseInfo = this.GetRedPacketBaseInfo(msgRet.detail.baseEntry.id);
					redPacketBaseInfo.status = msgRet.detail.baseEntry.status;
					redPacketBaseInfo.opened = msgRet.detail.baseEntry.opened;
					ShowOpenedRedPacketFrame.showRedPacketMode = ShowRedPacketMode.Show;
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<ShowOpenedRedPacketFrame>(FrameLayer.Middle, msgRet.detail, string.Empty);
				}
			}, true, 15f, null);
		}

		// Token: 0x0600BAC6 RID: 47814 RVA: 0x002B31C0 File Offset: 0x002B15C0
		private void _BindNetMsg()
		{
			NetProcess.AddMsgHandler(607301U, new Action<MsgDATA>(this._OnNetInitRedPack));
			NetProcess.AddMsgHandler(607302U, new Action<MsgDATA>(this._OnNetGetRedPacket));
			NetProcess.AddMsgHandler(607303U, new Action<MsgDATA>(this._OnNetAddRedPacket));
			NetProcess.AddMsgHandler(607304U, new Action<MsgDATA>(this._OnNetRemoveRedPacket));
			NetProcess.AddMsgHandler(607305U, new Action<MsgDATA>(this._OnNetSyncRedPacketState));
			NetProcess.AddMsgHandler(607312U, new Action<MsgDATA>(this._OnWorldSyncRedPacketRecord));
			NetProcess.AddMsgHandler(607314U, new Action<MsgDATA>(this._OnWorldGetGuildRedPacketInfoRes));
		}

		// Token: 0x0600BAC7 RID: 47815 RVA: 0x002B3268 File Offset: 0x002B1668
		private void _UnBindNetMsg()
		{
			NetProcess.RemoveMsgHandler(607301U, new Action<MsgDATA>(this._OnNetInitRedPack));
			NetProcess.RemoveMsgHandler(607302U, new Action<MsgDATA>(this._OnNetGetRedPacket));
			NetProcess.RemoveMsgHandler(607303U, new Action<MsgDATA>(this._OnNetAddRedPacket));
			NetProcess.RemoveMsgHandler(607304U, new Action<MsgDATA>(this._OnNetRemoveRedPacket));
			NetProcess.RemoveMsgHandler(607305U, new Action<MsgDATA>(this._OnNetSyncRedPacketState));
			NetProcess.RemoveMsgHandler(607312U, new Action<MsgDATA>(this._OnWorldSyncRedPacketRecord));
			NetProcess.RemoveMsgHandler(607314U, new Action<MsgDATA>(this._OnWorldGetGuildRedPacketInfoRes));
		}

		// Token: 0x0600BAC8 RID: 47816 RVA: 0x002B3310 File Offset: 0x002B1710
		private void _OnNetInitRedPack(MsgDATA a_data)
		{
			if (a_data == null)
			{
				this.m_dictRedPackets.Clear();
				this.m_dictPacketType.Clear();
				return;
			}
			WorldSyncRedPacket worldSyncRedPacket = new WorldSyncRedPacket();
			worldSyncRedPacket.decode(a_data.bytes);
			this.m_dictRedPackets.Clear();
			this.m_dictPacketType.Clear();
			for (int i = 0; i < worldSyncRedPacket.entrys.Length; i++)
			{
				RedPacketBaseEntry redPacketBaseEntry = worldSyncRedPacket.entrys[i];
				this.m_dictRedPackets.Add(redPacketBaseEntry.id, redPacketBaseEntry);
				RedPacketType type = (RedPacketType)redPacketBaseEntry.type;
				if (!this.m_dictPacketType.ContainsKey(type))
				{
					this.m_dictPacketType.Add(type, new List<ulong>());
				}
				this.m_dictPacketType[type].Add(redPacketBaseEntry.id);
			}
		}

		// Token: 0x0600BAC9 RID: 47817 RVA: 0x002B33D8 File Offset: 0x002B17D8
		private void _OnNetGetRedPacket(MsgDATA a_data)
		{
			WorldNotifyGotNewRedPacket worldNotifyGotNewRedPacket = new WorldNotifyGotNewRedPacket();
			worldNotifyGotNewRedPacket.decode(a_data.bytes);
			if (!this.m_dictRedPackets.ContainsKey(worldNotifyGotNewRedPacket.entry.id))
			{
				this.m_dictRedPackets.Add(worldNotifyGotNewRedPacket.entry.id, worldNotifyGotNewRedPacket.entry);
				RedPacketType type = (RedPacketType)worldNotifyGotNewRedPacket.entry.type;
				if (!this.m_dictPacketType.ContainsKey(type))
				{
					this.m_dictPacketType.Add(type, new List<ulong>());
				}
				this.m_dictPacketType[type].Add(worldNotifyGotNewRedPacket.entry.id);
			}
			List<ulong> list = new List<ulong>();
			list.Add(worldNotifyGotNewRedPacket.entry.id);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RedPacketGet, list, null, null, null);
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.GuildRedPacket);
		}

		// Token: 0x0600BACA RID: 47818 RVA: 0x002B34B0 File Offset: 0x002B18B0
		private void _OnNetAddRedPacket(MsgDATA a_data)
		{
			WorldNotifyNewRedPacket worldNotifyNewRedPacket = new WorldNotifyNewRedPacket();
			worldNotifyNewRedPacket.decode(a_data.bytes);
			List<ulong> list = new List<ulong>();
			for (int i = 0; i < worldNotifyNewRedPacket.entry.Length; i++)
			{
				RedPacketBaseEntry redPacketBaseEntry = worldNotifyNewRedPacket.entry[i];
				if (!this.m_dictRedPackets.ContainsKey(redPacketBaseEntry.id))
				{
					this.m_dictRedPackets.Add(redPacketBaseEntry.id, redPacketBaseEntry);
					RedPacketType type = (RedPacketType)redPacketBaseEntry.type;
					if (!this.m_dictPacketType.ContainsKey(type))
					{
						this.m_dictPacketType.Add(type, new List<ulong>());
					}
					this.m_dictPacketType[type].Add(redPacketBaseEntry.id);
					list.Add(redPacketBaseEntry.id);
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RedPacketGet, list, null, null, null);
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.GuildRedPacket);
		}

		// Token: 0x0600BACB RID: 47819 RVA: 0x002B3590 File Offset: 0x002B1990
		private void _OnNetRemoveRedPacket(MsgDATA a_data)
		{
			WorldNotifyDelRedPacket worldNotifyDelRedPacket = new WorldNotifyDelRedPacket();
			worldNotifyDelRedPacket.decode(a_data.bytes);
			for (int i = 0; i < worldNotifyDelRedPacket.redPacketList.Length; i++)
			{
				ulong num = worldNotifyDelRedPacket.redPacketList[i];
				if (this.m_dictRedPackets.ContainsKey(num))
				{
					RedPacketBaseEntry redPacketBaseEntry = this.m_dictRedPackets[num];
					this.m_dictRedPackets.Remove(num);
					this.m_dictPacketType[(RedPacketType)redPacketBaseEntry.type].Remove(num);
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RedPacketDelete, worldNotifyDelRedPacket.redPacketList, null, null, null);
		}

		// Token: 0x0600BACC RID: 47820 RVA: 0x002B362C File Offset: 0x002B1A2C
		private void _OnNetSyncRedPacketState(MsgDATA a_data)
		{
			WorldNotifySyncRedPacketStatus worldNotifySyncRedPacketStatus = new WorldNotifySyncRedPacketStatus();
			worldNotifySyncRedPacketStatus.decode(a_data.bytes);
			if (this.m_dictRedPackets.ContainsKey(worldNotifySyncRedPacketStatus.id))
			{
				this.m_dictRedPackets[worldNotifySyncRedPacketStatus.id].status = worldNotifySyncRedPacketStatus.status;
			}
		}

		// Token: 0x0600BACD RID: 47821 RVA: 0x002B3680 File Offset: 0x002B1A80
		private void CopyRedPacketData(ref RedPacketRecord redPacketRecord1, ref RedPacketRecord redPacketRecord2)
		{
			if (redPacketRecord1 == null || redPacketRecord2 == null)
			{
				return;
			}
			redPacketRecord1.guid = redPacketRecord2.guid;
			redPacketRecord1.isBest = redPacketRecord2.isBest;
			redPacketRecord1.moneyId = redPacketRecord2.moneyId;
			redPacketRecord1.moneyNum = redPacketRecord2.moneyNum;
			redPacketRecord1.redPackOwnerName = redPacketRecord2.redPackOwnerName;
			redPacketRecord1.time = redPacketRecord2.time;
		}

		// Token: 0x0600BACE RID: 47822 RVA: 0x002B36F0 File Offset: 0x002B1AF0
		private SendRedPackType GetSendRedPackType(RedPacketTable.eThirdType thirdType)
		{
			switch (thirdType)
			{
			case RedPacketTable.eThirdType.GUILD_ALL:
				return SendRedPackType.GuildMember;
			case RedPacketTable.eThirdType.GUILD_BATTLE:
				return SendRedPackType.GuildWar;
			case RedPacketTable.eThirdType.GUILD_CROSS_BATTLE:
				return SendRedPackType.CrossGuildWar;
			case RedPacketTable.eThirdType.GUILD_DUNGEON:
				return SendRedPackType.GuildDungeon;
			default:
				return SendRedPackType.Invalid;
			}
		}

		// Token: 0x0600BACF RID: 47823 RVA: 0x002B3718 File Offset: 0x002B1B18
		private void _OnWorldGetGuildRedPacketInfoRes(MsgDATA a_data)
		{
			if (this.guildRedPacketSpecInfos == null)
			{
				return;
			}
			WorldGetGuildRedPacketInfoRes worldGetGuildRedPacketInfoRes = new WorldGetGuildRedPacketInfoRes();
			worldGetGuildRedPacketInfoRes.decode(a_data.bytes);
			if (worldGetGuildRedPacketInfoRes.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldGetGuildRedPacketInfoRes.code, string.Empty);
				return;
			}
			this.guildRedPacketSpecInfos.Clear();
			if (worldGetGuildRedPacketInfoRes.infos != null)
			{
				for (int i = 0; i < worldGetGuildRedPacketInfoRes.infos.Length; i++)
				{
					GuildRedPacketSpecInfo guildRedPacketSpecInfo = worldGetGuildRedPacketInfoRes.infos[i];
					if (guildRedPacketSpecInfo != null)
					{
						SendRedPackType sendRedPackType = this.GetSendRedPackType((RedPacketTable.eThirdType)guildRedPacketSpecInfo.type);
						if (sendRedPackType != SendRedPackType.Invalid)
						{
							this.guildRedPacketSpecInfos.SafeAdd(sendRedPackType, guildRedPacketSpecInfo);
						}
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnUpdateGuildRedPacketSpecInfo, null, null, null, null);
		}

		// Token: 0x0600BAD0 RID: 47824 RVA: 0x002B37DC File Offset: 0x002B1BDC
		private void _OnWorldSyncRedPacketRecord(MsgDATA a_data)
		{
			if (this.redPacketRecords == null)
			{
				return;
			}
			WorldSyncRedPacketRecord worldSyncRedPacketRecord = new WorldSyncRedPacketRecord();
			worldSyncRedPacketRecord.decode(a_data.bytes);
			if (worldSyncRedPacketRecord.dels != null)
			{
				for (int i = 0; i < worldSyncRedPacketRecord.dels.Length; i++)
				{
					this.redPacketRecords.SafeRemove(worldSyncRedPacketRecord.dels[i]);
				}
			}
			if (worldSyncRedPacketRecord.updates != null)
			{
				for (int j = 0; j < worldSyncRedPacketRecord.updates.Length; j++)
				{
					RedPacketRecord redPacketRecord = worldSyncRedPacketRecord.updates[j];
					if (redPacketRecord != null)
					{
						RedPacketRecord redPacketRecord2 = this.redPacketRecords.SafeGetValue(redPacketRecord.guid);
						if (redPacketRecord2 != null)
						{
							this.CopyRedPacketData(ref redPacketRecord2, ref redPacketRecord);
						}
					}
				}
			}
			if (worldSyncRedPacketRecord.adds != null)
			{
				for (int k = 0; k < worldSyncRedPacketRecord.adds.Length; k++)
				{
					RedPacketRecord redPacketRecord3 = worldSyncRedPacketRecord.adds[k];
					if (redPacketRecord3 != null)
					{
						RedPacketRecord redPacketRecord4 = new RedPacketRecord();
						if (redPacketRecord4 != null)
						{
							this.CopyRedPacketData(ref redPacketRecord4, ref redPacketRecord3);
							this.redPacketRecords.SafeAdd(redPacketRecord4.guid, redPacketRecord4);
						}
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnUpdateGuildRedPacketRecord, null, null, null, null);
		}

		// Token: 0x0600BAD1 RID: 47825 RVA: 0x002B3922 File Offset: 0x002B1D22
		private void _OnInitRedPack(MsgDATA a_data)
		{
			if (a_data != null)
			{
				this._OnNetInitRedPack(a_data);
			}
			else
			{
				this.m_dictRedPackets.Clear();
				this.m_dictPacketType.Clear();
			}
		}

		// Token: 0x0600BAD2 RID: 47826 RVA: 0x002B394C File Offset: 0x002B1D4C
		public bool CheckNewYearActivityOpen()
		{
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(this.NewYearRedPackRankListActivityID);
			return activeData != null && activeData.mainInfo.state == 1 && DataManager<PlayerBaseData>.GetInstance().Level >= activeData.mainInfo.level;
		}

		// Token: 0x0600BAD3 RID: 47827 RVA: 0x002B39A4 File Offset: 0x002B1DA4
		public bool HasRedPacketToOpen(RedPacketType type)
		{
			foreach (KeyValuePair<ulong, RedPacketBaseEntry> keyValuePair in this.m_dictRedPackets)
			{
				RedPacketBaseEntry value = keyValuePair.Value;
				if (value.status == 2 && value.opened == 0 && value.type == (byte)type)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x040068DC RID: 26844
		public int NewYearRedPackActivityID;

		// Token: 0x040068DD RID: 26845
		public int NewYearRedPackRankListActivityID;

		// Token: 0x040068DE RID: 26846
		private Dictionary<ulong, RedPacketBaseEntry> m_dictRedPackets = new Dictionary<ulong, RedPacketBaseEntry>();

		// Token: 0x040068DF RID: 26847
		private Dictionary<RedPacketType, List<ulong>> m_dictPacketType = new Dictionary<RedPacketType, List<ulong>>();

		// Token: 0x040068E0 RID: 26848
		private Dictionary<ulong, RedPacketRecord> redPacketRecords = new Dictionary<ulong, RedPacketRecord>();

		// Token: 0x040068E1 RID: 26849
		private Dictionary<SendRedPackType, GuildRedPacketSpecInfo> guildRedPacketSpecInfos = new Dictionary<SendRedPackType, GuildRedPacketSpecInfo>();
	}
}
