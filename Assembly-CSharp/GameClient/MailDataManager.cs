using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020012A9 RID: 4777
	public class MailDataManager : DataManager<MailDataManager>
	{
		// Token: 0x17001AFE RID: 6910
		// (get) Token: 0x0600B7CA RID: 47050 RVA: 0x002A0540 File Offset: 0x0029E940
		// (set) Token: 0x0600B7CB RID: 47051 RVA: 0x002A0547 File Offset: 0x0029E947
		public static int AnnouncementMailOneKeyDeleteNum
		{
			get
			{
				return MailDataManager.announcementMailOneKeyDeleteNum;
			}
			set
			{
				MailDataManager.announcementMailOneKeyDeleteNum = value;
			}
		}

		// Token: 0x17001AFF RID: 6911
		// (get) Token: 0x0600B7CC RID: 47052 RVA: 0x002A054F File Offset: 0x0029E94F
		// (set) Token: 0x0600B7CD RID: 47053 RVA: 0x002A0556 File Offset: 0x0029E956
		public static int RewardMailOneKeyDeleteNum
		{
			get
			{
				return MailDataManager.rewardMailOneKeyDeleteNum;
			}
			set
			{
				MailDataManager.rewardMailOneKeyDeleteNum = value;
			}
		}

		// Token: 0x17001B00 RID: 6912
		// (get) Token: 0x0600B7CE RID: 47054 RVA: 0x002A055E File Offset: 0x0029E95E
		// (set) Token: 0x0600B7CF RID: 47055 RVA: 0x002A0565 File Offset: 0x0029E965
		public static int AnnouncmentMailOneKeyReceiveNum
		{
			get
			{
				return MailDataManager.announcementMailOneKeyReceiveNum;
			}
			set
			{
				MailDataManager.announcementMailOneKeyReceiveNum = value;
			}
		}

		// Token: 0x17001B01 RID: 6913
		// (get) Token: 0x0600B7D0 RID: 47056 RVA: 0x002A056D File Offset: 0x0029E96D
		// (set) Token: 0x0600B7D1 RID: 47057 RVA: 0x002A0574 File Offset: 0x0029E974
		public static int RewardMailOneKeyReceiveNum
		{
			get
			{
				return MailDataManager.rewardMailOneKeyReceiveNum;
			}
			set
			{
				MailDataManager.rewardMailOneKeyReceiveNum = value;
			}
		}

		// Token: 0x17001B02 RID: 6914
		// (get) Token: 0x0600B7D2 RID: 47058 RVA: 0x002A057C File Offset: 0x0029E97C
		// (set) Token: 0x0600B7D3 RID: 47059 RVA: 0x002A0583 File Offset: 0x0029E983
		public static int GuildMailOneKeyReceiveNum
		{
			get
			{
				return MailDataManager.guildMailOneKeyReceiveNum;
			}
			set
			{
				MailDataManager.guildMailOneKeyReceiveNum = value;
			}
		}

		// Token: 0x17001B03 RID: 6915
		// (get) Token: 0x0600B7D4 RID: 47060 RVA: 0x002A058B File Offset: 0x0029E98B
		// (set) Token: 0x0600B7D5 RID: 47061 RVA: 0x002A0592 File Offset: 0x0029E992
		public static int GuildMailOneKeyDeleteNum
		{
			get
			{
				return MailDataManager.guildMailOneKeyDeleteNum;
			}
			set
			{
				MailDataManager.guildMailOneKeyDeleteNum = value;
			}
		}

		// Token: 0x17001B04 RID: 6916
		// (get) Token: 0x0600B7D6 RID: 47062 RVA: 0x002A059A File Offset: 0x0029E99A
		// (set) Token: 0x0600B7D7 RID: 47063 RVA: 0x002A05A1 File Offset: 0x0029E9A1
		public static MailTabType CurrentSelectMailTabType
		{
			get
			{
				return MailDataManager.mCurrentSelectMailTabType;
			}
			set
			{
				MailDataManager.mCurrentSelectMailTabType = value;
			}
		}

		// Token: 0x17001B05 RID: 6917
		// (get) Token: 0x0600B7D8 RID: 47064 RVA: 0x002A05A9 File Offset: 0x0029E9A9
		// (set) Token: 0x0600B7D9 RID: 47065 RVA: 0x002A05B0 File Offset: 0x0029E9B0
		public static int MailItemNum
		{
			get
			{
				return MailDataManager.mMailItemNum;
			}
			set
			{
				MailDataManager.mMailItemNum = value;
			}
		}

		// Token: 0x17001B06 RID: 6918
		// (get) Token: 0x0600B7DA RID: 47066 RVA: 0x002A05B8 File Offset: 0x0029E9B8
		// (set) Token: 0x0600B7DB RID: 47067 RVA: 0x002A05BF File Offset: 0x0029E9BF
		public static int UnReadMailNum
		{
			get
			{
				return MailDataManager.mUnReadMailNum;
			}
			set
			{
				MailDataManager.mUnReadMailNum = value;
			}
		}

		// Token: 0x17001B07 RID: 6919
		// (get) Token: 0x0600B7DC RID: 47068 RVA: 0x002A05C7 File Offset: 0x0029E9C7
		// (set) Token: 0x0600B7DD RID: 47069 RVA: 0x002A05CE File Offset: 0x0029E9CE
		public static int OneKeyReceiveNum
		{
			get
			{
				return MailDataManager.mOneKeyReceiveNum;
			}
			set
			{
				MailDataManager.mOneKeyReceiveNum = value;
			}
		}

		// Token: 0x17001B08 RID: 6920
		// (get) Token: 0x0600B7DE RID: 47070 RVA: 0x002A05D6 File Offset: 0x0029E9D6
		// (set) Token: 0x0600B7DF RID: 47071 RVA: 0x002A05DD File Offset: 0x0029E9DD
		public static int OneKeyDeleteNum
		{
			get
			{
				return MailDataManager.mOneKeyDeleteNum;
			}
			set
			{
				MailDataManager.mOneKeyDeleteNum = value;
			}
		}

		// Token: 0x17001B09 RID: 6921
		// (get) Token: 0x0600B7E0 RID: 47072 RVA: 0x002A05E5 File Offset: 0x0029E9E5
		// (set) Token: 0x0600B7E1 RID: 47073 RVA: 0x002A05EC File Offset: 0x0029E9EC
		public static int AnnouncementUnReadMailNum
		{
			get
			{
				return MailDataManager.mAnnouncementUnReadMailNum;
			}
			set
			{
				MailDataManager.mAnnouncementUnReadMailNum = value;
			}
		}

		// Token: 0x17001B0A RID: 6922
		// (get) Token: 0x0600B7E2 RID: 47074 RVA: 0x002A05F4 File Offset: 0x0029E9F4
		// (set) Token: 0x0600B7E3 RID: 47075 RVA: 0x002A05FB File Offset: 0x0029E9FB
		public static int RewardUnReadMailNum
		{
			get
			{
				return MailDataManager.mRewardUnReadMailNum;
			}
			set
			{
				MailDataManager.mRewardUnReadMailNum = value;
			}
		}

		// Token: 0x17001B0B RID: 6923
		// (get) Token: 0x0600B7E4 RID: 47076 RVA: 0x002A0603 File Offset: 0x0029EA03
		// (set) Token: 0x0600B7E5 RID: 47077 RVA: 0x002A060A File Offset: 0x0029EA0A
		public static int GuildUnReadMailNum
		{
			get
			{
				return MailDataManager.mGuildUnReadMailNum;
			}
			set
			{
				MailDataManager.mGuildUnReadMailNum = value;
			}
		}

		// Token: 0x17001B0C RID: 6924
		// (get) Token: 0x0600B7E6 RID: 47078 RVA: 0x002A0612 File Offset: 0x0029EA12
		// (set) Token: 0x0600B7E7 RID: 47079 RVA: 0x002A0619 File Offset: 0x0029EA19
		public static int DefaultMailMainTabIndex
		{
			get
			{
				return MailDataManager.mDefaultMailMainTabIndex;
			}
			set
			{
				MailDataManager.mDefaultMailMainTabIndex = value;
			}
		}

		// Token: 0x0600B7E8 RID: 47080 RVA: 0x002A0624 File Offset: 0x0029EA24
		public MailTitleInfo FindMailTitleInfo(List<MailTitleInfo> mailInfoList, ulong id)
		{
			MailTitleInfo result = null;
			for (int i = 0; i < mailInfoList.Count; i++)
			{
				ulong id2 = mailInfoList[i].id;
				if (id2 == id)
				{
					return mailInfoList[i];
				}
			}
			return result;
		}

		// Token: 0x0600B7E9 RID: 47081 RVA: 0x002A066C File Offset: 0x0029EA6C
		public MailDataModel FindMailDataModel(Dictionary<ulong, MailDataModel> mailDataModel, ulong id)
		{
			MailDataModel result;
			if (mailDataModel.TryGetValue(id, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x0600B7EA RID: 47082 RVA: 0x002A068C File Offset: 0x0029EA8C
		public List<MailTitleInfo> GetCurrentShowMailTitleInfoList()
		{
			List<MailTitleInfo> result = new List<MailTitleInfo>();
			switch (MailDataManager.CurrentSelectMailTabType)
			{
			case MailTabType.MTT_ANNOUNCEMENT:
				result = DataManager<MailDataManager>.GetInstance().mAnnouncementMailTitleInfoList;
				break;
			case MailTabType.MTT_REWARD:
				result = DataManager<MailDataManager>.GetInstance().mRewardMailTitleInfoList;
				break;
			case MailTabType.MTT_GUILD:
				result = DataManager<MailDataManager>.GetInstance().mGuildMailTitleInfoList;
				break;
			}
			return result;
		}

		// Token: 0x0600B7EB RID: 47083 RVA: 0x002A06FB File Offset: 0x0029EAFB
		public sealed override EEnterGameOrder GetOrder()
		{
			return base.GetOrder();
		}

		// Token: 0x0600B7EC RID: 47084 RVA: 0x002A0704 File Offset: 0x0029EB04
		public sealed override void Clear()
		{
			this.mAllMailTilteInfo.Clear();
			this.mAnnouncementMailTitleInfoList.Clear();
			this.mRewardMailTitleInfoList.Clear();
			this.mGuildMailTitleInfoList.Clear();
			this.mAnnouncementMailDataModelDict.Clear();
			this.mRewardMailDataModelDict.Clear();
			this.mGuildMailDataModelDict.Clear();
			MailDataManager.announcementMailOneKeyDeleteNum = 0;
			MailDataManager.rewardMailOneKeyDeleteNum = 0;
			MailDataManager.announcementMailOneKeyReceiveNum = 0;
			MailDataManager.rewardMailOneKeyReceiveNum = 0;
			MailDataManager.guildMailOneKeyReceiveNum = 0;
			MailDataManager.guildMailOneKeyDeleteNum = 0;
			MailDataManager.mMailItemNum = 0;
			MailDataManager.mUnReadMailNum = 0;
			MailDataManager.mOneKeyReceiveNum = 0;
			MailDataManager.mOneKeyDeleteNum = 0;
			MailDataManager.mAnnouncementUnReadMailNum = 0;
			MailDataManager.mRewardUnReadMailNum = 0;
			MailDataManager.mGuildUnReadMailNum = 0;
			this.UnRegisterNetHandler();
		}

		// Token: 0x0600B7ED RID: 47085 RVA: 0x002A07B2 File Offset: 0x0029EBB2
		public sealed override void Initialize()
		{
			this.InitLocalData();
			this.RegisterNetHandler();
		}

		// Token: 0x0600B7EE RID: 47086 RVA: 0x002A07C0 File Offset: 0x0029EBC0
		private void InitLocalData()
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(11, string.Empty, string.Empty);
			MailDataManager.mMailItemNum = tableItem.Value;
		}

		// Token: 0x0600B7EF RID: 47087 RVA: 0x002A07F0 File Offset: 0x0029EBF0
		public bool CheckRedPoint(MailTabType mailTabType)
		{
			int num = 0;
			switch (mailTabType)
			{
			case MailTabType.MTT_ANNOUNCEMENT:
				num = MailDataManager.AnnouncementUnReadMailNum;
				break;
			case MailTabType.MTT_REWARD:
				num = MailDataManager.RewardUnReadMailNum;
				break;
			case MailTabType.MTT_GUILD:
				num = MailDataManager.GuildUnReadMailNum;
				break;
			}
			return num > 0;
		}

		// Token: 0x0600B7F0 RID: 47088 RVA: 0x002A084C File Offset: 0x0029EC4C
		public void UpdateMailUnReadNumAndOneKeyReceiveNum()
		{
			MailDataManager.mUnReadMailNum = 0;
			MailDataManager.mOneKeyReceiveNum = 0;
			MailDataManager.mOneKeyDeleteNum = 0;
			MailDataManager.mAnnouncementUnReadMailNum = 0;
			MailDataManager.mRewardUnReadMailNum = 0;
			MailDataManager.mGuildUnReadMailNum = 0;
			for (int i = 0; i < this.mAllMailTilteInfo.Count; i++)
			{
				if (this.mAllMailTilteInfo[i].status == 0)
				{
					MailDataManager.mUnReadMailNum++;
				}
				if (this.mAllMailTilteInfo[i].hasItem == 1)
				{
					MailDataManager.mOneKeyReceiveNum++;
				}
				else
				{
					MailDataManager.mOneKeyDeleteNum++;
				}
			}
			for (int j = 0; j < this.mAnnouncementMailTitleInfoList.Count; j++)
			{
				if (this.mAnnouncementMailTitleInfoList[j].status == 0)
				{
					MailDataManager.mAnnouncementUnReadMailNum++;
				}
			}
			for (int k = 0; k < this.mRewardMailTitleInfoList.Count; k++)
			{
				if (this.mRewardMailTitleInfoList[k].status == 0)
				{
					MailDataManager.mRewardUnReadMailNum++;
				}
			}
			for (int l = 0; l < this.mGuildMailTitleInfoList.Count; l++)
			{
				if (this.mGuildMailTitleInfoList[l].status == 0)
				{
					MailDataManager.mGuildUnReadMailNum++;
				}
			}
		}

		// Token: 0x0600B7F1 RID: 47089 RVA: 0x002A09AC File Offset: 0x0029EDAC
		public void UpdateOpenMailTabType()
		{
			if (this.mRewardMailTitleInfoList.Count > 0)
			{
				MailDataManager.mDefaultMailMainTabIndex = 1;
			}
			else if (this.mGuildMailTitleInfoList.Count > 0 && this.mRewardMailTitleInfoList.Count <= 0)
			{
				MailDataManager.mDefaultMailMainTabIndex = 2;
			}
			else
			{
				MailDataManager.mDefaultMailMainTabIndex = 0;
			}
		}

		// Token: 0x0600B7F2 RID: 47090 RVA: 0x002A0A08 File Offset: 0x0029EE08
		private void RegisterNetHandler()
		{
			NetProcess.AddMsgHandler(601503U, new Action<MsgDATA>(this.OnWorldMailListRet));
			NetProcess.AddMsgHandler(601505U, new Action<MsgDATA>(this.OnWorldReadMailRet));
			NetProcess.AddMsgHandler(601507U, new Action<MsgDATA>(this.OnWorldSyncMailStatusRes));
			NetProcess.AddMsgHandler(601511U, new Action<MsgDATA>(this.OnWorldNotifyDeleteMailRes));
			NetProcess.AddMsgHandler(601509U, new Action<MsgDATA>(this.OnWorldNotifyNewMailRes));
		}

		// Token: 0x0600B7F3 RID: 47091 RVA: 0x002A0A84 File Offset: 0x0029EE84
		private void UnRegisterNetHandler()
		{
			NetProcess.RemoveMsgHandler(601503U, new Action<MsgDATA>(this.OnWorldMailListRet));
			NetProcess.RemoveMsgHandler(601505U, new Action<MsgDATA>(this.OnWorldReadMailRet));
			NetProcess.RemoveMsgHandler(601507U, new Action<MsgDATA>(this.OnWorldSyncMailStatusRes));
			NetProcess.RemoveMsgHandler(601511U, new Action<MsgDATA>(this.OnWorldNotifyDeleteMailRes));
			NetProcess.RemoveMsgHandler(601509U, new Action<MsgDATA>(this.OnWorldNotifyNewMailRes));
		}

		// Token: 0x0600B7F4 RID: 47092 RVA: 0x002A0B00 File Offset: 0x0029EF00
		private void OnWorldMailListRet(MsgDATA msg)
		{
			WorldMailListRet worldMailListRet = new WorldMailListRet();
			worldMailListRet.decode(msg.bytes);
			this.mAnnouncementMailTitleInfoList.Clear();
			this.mRewardMailTitleInfoList.Clear();
			this.mGuildMailTitleInfoList.Clear();
			this.mAllMailTilteInfo.Clear();
			for (int i = 0; i < worldMailListRet.mails.Length; i++)
			{
				if (worldMailListRet.mails[i].type == 2)
				{
					this.mAnnouncementMailTitleInfoList.Add(worldMailListRet.mails[i]);
				}
				else if (worldMailListRet.mails[i].type == 3)
				{
					this.mGuildMailTitleInfoList.Add(worldMailListRet.mails[i]);
				}
				else
				{
					this.mRewardMailTitleInfoList.Add(worldMailListRet.mails[i]);
				}
				this.mAllMailTilteInfo.Add(worldMailListRet.mails[i]);
			}
			this.SortAnnouncementMailList();
			this.UpdateAnnouncementOneKeyNum();
			this.SortRewardMailList();
			this.UpdateRewardOneKeyNum();
			this.SortGuildMailList();
			this.UpdateGuildMailOneKeyNum();
			this.UpdateMailUnReadNumAndOneKeyReceiveNum();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.NewMailNotify, null, null, null, null);
		}

		// Token: 0x0600B7F5 RID: 47093 RVA: 0x002A0C20 File Offset: 0x0029F020
		private void OnWorldReadMailRet(MsgDATA msg)
		{
			WorldReadMailRet worldReadMailRet = new WorldReadMailRet();
			worldReadMailRet.decode(msg.bytes);
			MailDataModel mailDataModel = new MailDataModel();
			mailDataModel.content = worldReadMailRet.content;
			mailDataModel.items = new List<ItemReward>(worldReadMailRet.items);
			mailDataModel.detailItems = worldReadMailRet.detailItems;
			switch (MailDataManager.CurrentSelectMailTabType)
			{
			case MailTabType.MTT_ANNOUNCEMENT:
				mailDataModel.info = this.FindMailTitleInfo(this.mAnnouncementMailTitleInfoList, worldReadMailRet.id);
				if (this.FindMailDataModel(this.mAnnouncementMailDataModelDict, worldReadMailRet.id) == null)
				{
					this.mAnnouncementMailDataModelDict.Add(worldReadMailRet.id, mailDataModel);
				}
				break;
			case MailTabType.MTT_REWARD:
				mailDataModel.info = this.FindMailTitleInfo(this.mRewardMailTitleInfoList, worldReadMailRet.id);
				if (this.FindMailDataModel(this.mRewardMailDataModelDict, worldReadMailRet.id) == null)
				{
					this.mRewardMailDataModelDict.Add(worldReadMailRet.id, mailDataModel);
				}
				break;
			case MailTabType.MTT_GUILD:
				mailDataModel.info = this.FindMailTitleInfo(this.mGuildMailTitleInfoList, worldReadMailRet.id);
				if (this.FindMailDataModel(this.mGuildMailDataModelDict, worldReadMailRet.id) == null)
				{
					this.mGuildMailDataModelDict.Add(worldReadMailRet.id, mailDataModel);
				}
				break;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReadMailResSuccess, mailDataModel, null, null, null);
		}

		// Token: 0x0600B7F6 RID: 47094 RVA: 0x002A0D84 File Offset: 0x0029F184
		private void OnWorldSyncMailStatusRes(MsgDATA msg)
		{
			WorldSyncMailStatus worldSyncMailStatus = new WorldSyncMailStatus();
			worldSyncMailStatus.decode(msg.bytes);
			switch (MailDataManager.CurrentSelectMailTabType)
			{
			case MailTabType.MTT_ANNOUNCEMENT:
				this.UpdateMailStatue(this.mAnnouncementMailTitleInfoList, this.mAnnouncementMailDataModelDict, worldSyncMailStatus);
				break;
			case MailTabType.MTT_REWARD:
				this.UpdateMailStatue(this.mRewardMailTitleInfoList, this.mRewardMailDataModelDict, worldSyncMailStatus);
				break;
			case MailTabType.MTT_GUILD:
				this.UpdateMailStatue(this.mGuildMailTitleInfoList, this.mGuildMailDataModelDict, worldSyncMailStatus);
				break;
			}
			this.UpdateMailUnReadNumAndOneKeyReceiveNum();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.UpdateMailStatus, null, null, null, null);
		}

		// Token: 0x0600B7F7 RID: 47095 RVA: 0x002A0E2C File Offset: 0x0029F22C
		private void OnWorldNotifyDeleteMailRes(MsgDATA msg)
		{
			WorldNotifyDeleteMail worldNotifyDeleteMail = new WorldNotifyDeleteMail();
			worldNotifyDeleteMail.decode(msg.bytes);
			switch (MailDataManager.CurrentSelectMailTabType)
			{
			case MailTabType.MTT_ANNOUNCEMENT:
				for (int i = 0; i < worldNotifyDeleteMail.ids.Length; i++)
				{
					this.DeleteMailTitleInfo(this.mAnnouncementMailTitleInfoList, worldNotifyDeleteMail.ids[i]);
					this.DeleteMailDataModle(this.mAnnouncementMailDataModelDict, worldNotifyDeleteMail.ids[i]);
					this.DeleteMailTitleInfo(this.mAllMailTilteInfo, worldNotifyDeleteMail.ids[i]);
				}
				this.SortAnnouncementMailList();
				this.UpdateAnnouncementOneKeyNum();
				break;
			case MailTabType.MTT_REWARD:
				for (int j = 0; j < worldNotifyDeleteMail.ids.Length; j++)
				{
					this.DeleteMailTitleInfo(this.mRewardMailTitleInfoList, worldNotifyDeleteMail.ids[j]);
					this.DeleteMailDataModle(this.mRewardMailDataModelDict, worldNotifyDeleteMail.ids[j]);
					this.DeleteMailTitleInfo(this.mAllMailTilteInfo, worldNotifyDeleteMail.ids[j]);
				}
				this.SortRewardMailList();
				this.UpdateRewardOneKeyNum();
				break;
			case MailTabType.MTT_GUILD:
				for (int k = 0; k < worldNotifyDeleteMail.ids.Length; k++)
				{
					this.DeleteMailTitleInfo(this.mGuildMailTitleInfoList, worldNotifyDeleteMail.ids[k]);
					this.DeleteMailDataModle(this.mGuildMailDataModelDict, worldNotifyDeleteMail.ids[k]);
					this.DeleteMailTitleInfo(this.mAllMailTilteInfo, worldNotifyDeleteMail.ids[k]);
				}
				this.SortGuildMailList();
				this.UpdateGuildMailOneKeyNum();
				break;
			}
			this.UpdateMailUnReadNumAndOneKeyReceiveNum();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMailDeleteSuccess, null, null, null, null);
			SystemNotifyManager.SystemNotify(1026, string.Empty);
		}

		// Token: 0x0600B7F8 RID: 47096 RVA: 0x002A0FD8 File Offset: 0x0029F3D8
		private void OnWorldNotifyNewMailRes(MsgDATA msg)
		{
			WorldNotifyNewMail worldNotifyNewMail = new WorldNotifyNewMail();
			worldNotifyNewMail.decode(msg.bytes);
			if (worldNotifyNewMail.info.type == 2)
			{
				this.mAnnouncementMailTitleInfoList.Insert(0, worldNotifyNewMail.info);
				this.UpdateAnnouncementOneKeyNum();
			}
			else if (worldNotifyNewMail.info.type == 3)
			{
				this.mGuildMailTitleInfoList.Insert(0, worldNotifyNewMail.info);
				this.UpdateGuildMailOneKeyNum();
			}
			else
			{
				this.mRewardMailTitleInfoList.Insert(0, worldNotifyNewMail.info);
				this.UpdateRewardOneKeyNum();
			}
			this.mAllMailTilteInfo.Insert(0, worldNotifyNewMail.info);
			this.UpdateMailUnReadNumAndOneKeyReceiveNum();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.NewMailNotify, null, null, null, null);
		}

		// Token: 0x0600B7F9 RID: 47097 RVA: 0x002A1098 File Offset: 0x0029F498
		public static void OnSendMailListReq()
		{
			if (Singleton<ClientSystemManager>.GetInstance().CurrentSystem.GetType() != typeof(ClientSystemTown))
			{
				return;
			}
			WorldMailListReq cmd = new WorldMailListReq();
			MonoSingleton<NetManager>.instance.SendCommand<WorldMailListReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600B7FA RID: 47098 RVA: 0x002A10D8 File Offset: 0x0029F4D8
		public void OnSendReadMailReq(ulong id)
		{
			WorldReadMailReq worldReadMailReq = new WorldReadMailReq();
			worldReadMailReq.id = id;
			MonoSingleton<NetManager>.instance.SendCommand<WorldReadMailReq>(ServerType.GATE_SERVER, worldReadMailReq);
		}

		// Token: 0x0600B7FB RID: 47099 RVA: 0x002A1100 File Offset: 0x0029F500
		public void OnSendReceiveMailReq(bool bReceivaAll, ulong curSelMailID)
		{
			WorldGetMailItems worldGetMailItems = new WorldGetMailItems();
			if (bReceivaAll)
			{
				worldGetMailItems.type = 1;
				worldGetMailItems.id = 0UL;
				switch (MailDataManager.CurrentSelectMailTabType)
				{
				case MailTabType.MTT_ANNOUNCEMENT:
					worldGetMailItems.mailType = 2U;
					break;
				case MailTabType.MTT_REWARD:
					worldGetMailItems.mailType = 0U;
					break;
				case MailTabType.MTT_GUILD:
					worldGetMailItems.mailType = 3U;
					break;
				}
			}
			else
			{
				worldGetMailItems.type = 0;
				worldGetMailItems.id = curSelMailID;
			}
			MonoSingleton<NetManager>.instance.SendCommand<WorldGetMailItems>(ServerType.GATE_SERVER, worldGetMailItems);
		}

		// Token: 0x0600B7FC RID: 47100 RVA: 0x002A1194 File Offset: 0x0029F594
		public void OnSendDeleteMailReq(bool bDeleteAll, ulong curSelMailID)
		{
			WorldDeleteMail worldDeleteMail = new WorldDeleteMail();
			List<ulong> list = null;
			if (bDeleteAll)
			{
				switch (MailDataManager.CurrentSelectMailTabType)
				{
				case MailTabType.MTT_ANNOUNCEMENT:
					list = this.GetDeleteMailList(this.mAnnouncementMailTitleInfoList);
					break;
				case MailTabType.MTT_REWARD:
					list = this.GetDeleteMailList(this.mRewardMailTitleInfoList);
					break;
				case MailTabType.MTT_GUILD:
					list = this.GetDeleteMailList(this.mGuildMailTitleInfoList);
					break;
				}
				worldDeleteMail.ids = new ulong[list.Count];
				for (int i = 0; i < list.Count; i++)
				{
					worldDeleteMail.ids[i] = list[i];
				}
			}
			else
			{
				worldDeleteMail.ids = new ulong[1];
				worldDeleteMail.ids[0] = curSelMailID;
			}
			MonoSingleton<NetManager>.instance.SendCommand<WorldDeleteMail>(ServerType.GATE_SERVER, worldDeleteMail);
		}

		// Token: 0x0600B7FD RID: 47101 RVA: 0x002A1270 File Offset: 0x0029F670
		private List<ulong> GetDeleteMailList(List<MailTitleInfo> mailList)
		{
			List<ulong> list = new List<ulong>();
			for (int i = 0; i < mailList.Count; i++)
			{
				if (mailList[i].hasItem == 0)
				{
					list.Add(mailList[i].id);
				}
			}
			return list;
		}

		// Token: 0x0600B7FE RID: 47102 RVA: 0x002A12C0 File Offset: 0x0029F6C0
		private void DeleteMailTitleInfo(List<MailTitleInfo> mailTitleInfo, ulong id)
		{
			for (int i = 0; i < mailTitleInfo.Count; i++)
			{
				if (mailTitleInfo[i].id == id)
				{
					mailTitleInfo.RemoveAt(i);
					break;
				}
			}
		}

		// Token: 0x0600B7FF RID: 47103 RVA: 0x002A1302 File Offset: 0x0029F702
		private void DeleteMailDataModle(Dictionary<ulong, MailDataModel> mailDataModle, ulong id)
		{
			if (mailDataModle.ContainsKey(id))
			{
				mailDataModle.Remove(id);
			}
		}

		// Token: 0x0600B800 RID: 47104 RVA: 0x002A1318 File Offset: 0x0029F718
		private void UpdateAnnouncementOneKeyNum()
		{
			MailDataManager.announcementMailOneKeyDeleteNum = 0;
			MailDataManager.announcementMailOneKeyReceiveNum = 0;
			for (int i = 0; i < this.mAnnouncementMailTitleInfoList.Count; i++)
			{
				if (this.mAnnouncementMailTitleInfoList[i].hasItem == 0)
				{
					MailDataManager.announcementMailOneKeyDeleteNum++;
				}
				else
				{
					MailDataManager.announcementMailOneKeyReceiveNum++;
				}
			}
		}

		// Token: 0x0600B801 RID: 47105 RVA: 0x002A1380 File Offset: 0x0029F780
		private void UpdateRewardOneKeyNum()
		{
			MailDataManager.rewardMailOneKeyDeleteNum = 0;
			MailDataManager.rewardMailOneKeyReceiveNum = 0;
			for (int i = 0; i < this.mRewardMailTitleInfoList.Count; i++)
			{
				if (this.mRewardMailTitleInfoList[i].hasItem == 0)
				{
					MailDataManager.rewardMailOneKeyDeleteNum++;
				}
				else
				{
					MailDataManager.rewardMailOneKeyReceiveNum++;
				}
			}
		}

		// Token: 0x0600B802 RID: 47106 RVA: 0x002A13E8 File Offset: 0x0029F7E8
		private void UpdateGuildMailOneKeyNum()
		{
			MailDataManager.guildMailOneKeyDeleteNum = 0;
			MailDataManager.guildMailOneKeyReceiveNum = 0;
			for (int i = 0; i < this.mGuildMailTitleInfoList.Count; i++)
			{
				if (this.mGuildMailTitleInfoList[i].hasItem == 0)
				{
					MailDataManager.guildMailOneKeyDeleteNum++;
				}
				else
				{
					MailDataManager.guildMailOneKeyReceiveNum++;
				}
			}
		}

		// Token: 0x0600B803 RID: 47107 RVA: 0x002A1450 File Offset: 0x0029F850
		private void UpdateMailStatue(List<MailTitleInfo> mailInfoList, Dictionary<ulong, MailDataModel> mailDataDict, WorldSyncMailStatus res)
		{
			for (int i = 0; i < mailInfoList.Count; i++)
			{
				if (mailInfoList[i].id == res.id)
				{
					if (mailInfoList[i].status != res.status)
					{
						mailInfoList[i].status = res.status;
						MailDataModel mailDataModel = this.FindMailDataModel(mailDataDict, res.id);
						if (mailDataModel != null)
						{
							mailDataModel.info.status = res.status;
						}
					}
				}
			}
		}

		// Token: 0x0600B804 RID: 47108 RVA: 0x002A14E0 File Offset: 0x0029F8E0
		private void SortAnnouncementMailList()
		{
			List<MailTitleInfo> list = new List<MailTitleInfo>();
			List<MailTitleInfo> list2 = new List<MailTitleInfo>();
			for (int i = 0; i < this.mAnnouncementMailTitleInfoList.Count; i++)
			{
				if (this.mAnnouncementMailTitleInfoList[i].status == 0)
				{
					list.Add(this.mAnnouncementMailTitleInfoList[i]);
				}
				else
				{
					list2.Add(this.mAnnouncementMailTitleInfoList[i]);
				}
			}
			this.mAnnouncementMailTitleInfoList = list;
			for (int j = 0; j < list2.Count; j++)
			{
				this.mAnnouncementMailTitleInfoList.Add(list2[j]);
			}
		}

		// Token: 0x0600B805 RID: 47109 RVA: 0x002A1584 File Offset: 0x0029F984
		private void SortRewardMailList()
		{
			List<MailTitleInfo> list = new List<MailTitleInfo>();
			List<MailTitleInfo> list2 = new List<MailTitleInfo>();
			for (int i = 0; i < this.mRewardMailTitleInfoList.Count; i++)
			{
				if (this.mRewardMailTitleInfoList[i].status == 0)
				{
					list.Add(this.mRewardMailTitleInfoList[i]);
				}
				else
				{
					list2.Add(this.mRewardMailTitleInfoList[i]);
				}
			}
			this.mRewardMailTitleInfoList = list;
			for (int j = 0; j < list2.Count; j++)
			{
				this.mRewardMailTitleInfoList.Add(list2[j]);
			}
		}

		// Token: 0x0600B806 RID: 47110 RVA: 0x002A1628 File Offset: 0x0029FA28
		private void SortGuildMailList()
		{
			List<MailTitleInfo> list = new List<MailTitleInfo>();
			List<MailTitleInfo> list2 = new List<MailTitleInfo>();
			for (int i = 0; i < this.mGuildMailTitleInfoList.Count; i++)
			{
				if (this.mGuildMailTitleInfoList[i].status == 0)
				{
					list.Add(this.mGuildMailTitleInfoList[i]);
				}
				else
				{
					list2.Add(this.mGuildMailTitleInfoList[i]);
				}
			}
			this.mGuildMailTitleInfoList = list;
			for (int j = 0; j < list2.Count; j++)
			{
				this.mGuildMailTitleInfoList.Add(list2[j]);
			}
		}

		// Token: 0x0600B807 RID: 47111 RVA: 0x002A16CC File Offset: 0x0029FACC
		public void SortMailList()
		{
			this.SortAnnouncementMailList();
			this.SortRewardMailList();
			this.SortGuildMailList();
		}

		// Token: 0x040067AB RID: 26539
		private List<MailTitleInfo> mAllMailTilteInfo = new List<MailTitleInfo>();

		// Token: 0x040067AC RID: 26540
		public List<MailTitleInfo> mAnnouncementMailTitleInfoList = new List<MailTitleInfo>();

		// Token: 0x040067AD RID: 26541
		public List<MailTitleInfo> mRewardMailTitleInfoList = new List<MailTitleInfo>();

		// Token: 0x040067AE RID: 26542
		public List<MailTitleInfo> mGuildMailTitleInfoList = new List<MailTitleInfo>();

		// Token: 0x040067AF RID: 26543
		public Dictionary<ulong, MailDataModel> mAnnouncementMailDataModelDict = new Dictionary<ulong, MailDataModel>();

		// Token: 0x040067B0 RID: 26544
		public Dictionary<ulong, MailDataModel> mRewardMailDataModelDict = new Dictionary<ulong, MailDataModel>();

		// Token: 0x040067B1 RID: 26545
		public Dictionary<ulong, MailDataModel> mGuildMailDataModelDict = new Dictionary<ulong, MailDataModel>();

		// Token: 0x040067B2 RID: 26546
		private static int announcementMailOneKeyDeleteNum;

		// Token: 0x040067B3 RID: 26547
		private static int rewardMailOneKeyDeleteNum;

		// Token: 0x040067B4 RID: 26548
		private static int announcementMailOneKeyReceiveNum;

		// Token: 0x040067B5 RID: 26549
		private static int rewardMailOneKeyReceiveNum;

		// Token: 0x040067B6 RID: 26550
		private static int guildMailOneKeyReceiveNum;

		// Token: 0x040067B7 RID: 26551
		private static int guildMailOneKeyDeleteNum;

		// Token: 0x040067B8 RID: 26552
		private static MailTabType mCurrentSelectMailTabType;

		// Token: 0x040067B9 RID: 26553
		private static int mMailItemNum;

		// Token: 0x040067BA RID: 26554
		private static int mUnReadMailNum;

		// Token: 0x040067BB RID: 26555
		private static int mOneKeyReceiveNum;

		// Token: 0x040067BC RID: 26556
		private static int mOneKeyDeleteNum;

		// Token: 0x040067BD RID: 26557
		private static int mAnnouncementUnReadMailNum;

		// Token: 0x040067BE RID: 26558
		private static int mRewardUnReadMailNum;

		// Token: 0x040067BF RID: 26559
		private static int mGuildUnReadMailNum;

		// Token: 0x040067C0 RID: 26560
		private static int mDefaultMailMainTabIndex;
	}
}
