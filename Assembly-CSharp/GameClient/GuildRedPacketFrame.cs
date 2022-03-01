using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200164C RID: 5708
	public class GuildRedPacketFrame : ClientFrame
	{
		// Token: 0x0600E09B RID: 57499 RVA: 0x003977C8 File Offset: 0x00395BC8
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildRedPacket";
		}

		// Token: 0x0600E09C RID: 57500 RVA: 0x003977CF File Offset: 0x00395BCF
		protected override void _OnOpenFrame()
		{
			this.BindUIEvent();
			this.guildRedPackDatas = new List<GuildRedPacketFrame.GuildRedPackData>();
			this.UpdateRedPackList();
			this.UpdateSendRedPacketLimitInfo();
		}

		// Token: 0x0600E09D RID: 57501 RVA: 0x003977EE File Offset: 0x00395BEE
		protected override void _OnCloseFrame()
		{
			this.guildRedPackDatas = null;
			this.UnBindUIEvent();
		}

		// Token: 0x0600E09E RID: 57502 RVA: 0x00397800 File Offset: 0x00395C00
		protected override void _bindExUI()
		{
			this.Close = this.mBind.GetCom<Button>("Close");
			this.Close.SafeSetOnClickListener(delegate
			{
				this.frameMgr.CloseFrame<GuildRedPacketFrame>(this, false);
			});
			this.redPackList = this.mBind.GetCom<ComUIListScript>("redPackList");
			this.redPackRecord = this.mBind.GetCom<Button>("redPackRecord");
			this.redPackRecord.SafeSetOnClickListener(delegate
			{
				this.frameMgr.OpenFrame<GuildMyRedPacketRecordFrame>(FrameLayer.Middle, null, string.Empty);
			});
			this.btSend = this.mBind.GetCom<Button>("btSend");
			this.btSend.SafeSetOnClickListener(delegate
			{
				SendRedPacketFrame.sendRedPackType = SendRedPackType.GuildMember;
				this.frameMgr.OpenFrame<SendRedPacketFrame>(FrameLayer.Middle, null, string.Empty);
			});
			this.vipLimit = this.mBind.GetCom<Text>("vipLimit");
			this.leftTime = this.mBind.GetCom<Text>("leftTime");
		}

		// Token: 0x0600E09F RID: 57503 RVA: 0x003978D6 File Offset: 0x00395CD6
		protected override void _unbindExUI()
		{
			this.Close = null;
			this.redPackList = null;
			this.redPackRecord = null;
			this.btSend = null;
			this.vipLimit = null;
			this.leftTime = null;
		}

		// Token: 0x0600E0A0 RID: 57504 RVA: 0x00397904 File Offset: 0x00395D04
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RedPacketGet, new ClientEventSystem.UIEventHandler(this.OnUpdateRedPack));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RedPacketDelete, new ClientEventSystem.UIEventHandler(this.OnUpdateRedPack));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RedPacketOpenSuccess, new ClientEventSystem.UIEventHandler(this.OnUpdateRedPack));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RedPacketSendSuccess, new ClientEventSystem.UIEventHandler(this.OnSendRedPackSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this.OnSendRedPackSuccess));
		}

		// Token: 0x0600E0A1 RID: 57505 RVA: 0x00397998 File Offset: 0x00395D98
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RedPacketGet, new ClientEventSystem.UIEventHandler(this.OnUpdateRedPack));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RedPacketDelete, new ClientEventSystem.UIEventHandler(this.OnUpdateRedPack));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RedPacketOpenSuccess, new ClientEventSystem.UIEventHandler(this.OnUpdateRedPack));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RedPacketSendSuccess, new ClientEventSystem.UIEventHandler(this.OnSendRedPackSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this.OnSendRedPackSuccess));
		}

		// Token: 0x0600E0A2 RID: 57506 RVA: 0x00397A2C File Offset: 0x00395E2C
		private void OnUpdateRedPack(UIEvent _uiEvent)
		{
			this.UpdateRedPackList();
		}

		// Token: 0x0600E0A3 RID: 57507 RVA: 0x00397A34 File Offset: 0x00395E34
		private void OnSendRedPackSuccess(UIEvent _uiEvent)
		{
			this.UpdateSendRedPacketLimitInfo();
		}

		// Token: 0x0600E0A4 RID: 57508 RVA: 0x00397A3C File Offset: 0x00395E3C
		private void GetRedPackStates(RedPacketBaseEntry redPacketBaseEntry, ref bool bCanGet, ref bool bNotReach, ref bool bGot, ref bool bEmpty)
		{
			if (redPacketBaseEntry == null)
			{
				return;
			}
			RedPacketStatus status = (RedPacketStatus)redPacketBaseEntry.status;
			if (status == RedPacketStatus.UNSATISFY)
			{
				bNotReach = true;
			}
			if (status == RedPacketStatus.WAIT_RECEIVE)
			{
				bCanGet = true;
			}
			if (status == RedPacketStatus.RECEIVED)
			{
				bGot = true;
			}
			if (status == RedPacketStatus.EMPTY)
			{
				bEmpty = true;
			}
		}

		// Token: 0x0600E0A5 RID: 57509 RVA: 0x00397A84 File Offset: 0x00395E84
		private void CalcGuildRedPackDatas()
		{
			this.guildRedPackDatas = new List<GuildRedPacketFrame.GuildRedPackData>();
			if (this.guildRedPackDatas == null)
			{
				return;
			}
			List<RedPacketBaseEntry> redPacketsByType = DataManager<RedPackDataManager>.GetInstance().GetRedPacketsByType(RedPacketType.GUILD);
			if (redPacketsByType == null)
			{
				return;
			}
			for (int i = 0; i < redPacketsByType.Count; i++)
			{
				if (redPacketsByType[i] == null)
				{
					return;
				}
				GuildRedPacketFrame.GuildRedPackData guildRedPackData = new GuildRedPacketFrame.GuildRedPackData();
				if (guildRedPackData == null)
				{
					return;
				}
				guildRedPackData.redPacketBaseEntry = redPacketsByType[i];
				this.guildRedPackDatas.Add(guildRedPackData);
			}
			this.guildRedPackDatas.Sort(delegate(GuildRedPacketFrame.GuildRedPackData a, GuildRedPacketFrame.GuildRedPackData b)
			{
				if (a.redPacketBaseEntry == null || b.redPacketBaseEntry == null)
				{
					return 0;
				}
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				bool flag4 = false;
				bool flag5 = false;
				bool flag6 = false;
				bool flag7 = false;
				bool flag8 = false;
				this.GetRedPackStates(a.redPacketBaseEntry, ref flag, ref flag3, ref flag5, ref flag7);
				this.GetRedPackStates(b.redPacketBaseEntry, ref flag2, ref flag4, ref flag6, ref flag8);
				if (flag != flag2)
				{
					return flag2.CompareTo(flag);
				}
				if (flag3 != flag4)
				{
					return flag4.CompareTo(flag3);
				}
				if (flag5 != flag6)
				{
					return flag6.CompareTo(flag5);
				}
				if (flag7 != flag8)
				{
					return flag8.CompareTo(flag7);
				}
				return b.redPacketBaseEntry.id.CompareTo(a.redPacketBaseEntry.id);
			});
		}

		// Token: 0x0600E0A6 RID: 57510 RVA: 0x00397B1C File Offset: 0x00395F1C
		private void UpdateRedPackListItem(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.guildRedPackDatas == null)
			{
				return;
			}
			if (item.m_index >= this.guildRedPackDatas.Count)
			{
				return;
			}
			GuildRedPacketItem guildRedPacketItem = item.gameObjectBindScript as GuildRedPacketItem;
			if (guildRedPacketItem != null && this.guildRedPackDatas[item.m_index].redPacketBaseEntry != null)
			{
				guildRedPacketItem.SetUp(this.guildRedPackDatas[item.m_index].redPacketBaseEntry.id);
			}
		}

		// Token: 0x0600E0A7 RID: 57511 RVA: 0x00397BB0 File Offset: 0x00395FB0
		private void UpdateRedPackList()
		{
			if (this.redPackList == null)
			{
				return;
			}
			this.CalcGuildRedPackDatas();
			if (this.guildRedPackDatas == null)
			{
				return;
			}
			this.redPackList.Initialize();
			this.redPackList.onBindItem = delegate(GameObject item)
			{
				if (item != null)
				{
					return item.GetComponent<GuildRedPacketItem>();
				}
				return null;
			};
			this.redPackList.onItemVisiable = delegate(ComUIListElementScript item)
			{
				this.UpdateRedPackListItem(item);
			};
			this.redPackList.OnItemUpdate = delegate(ComUIListElementScript item)
			{
				this.UpdateRedPackListItem(item);
			};
			this.redPackList.UpdateElementAmount(this.guildRedPackDatas.Count);
		}

		// Token: 0x0600E0A8 RID: 57512 RVA: 0x00397C58 File Offset: 0x00396058
		private void UpdateSendRedPacketLimitInfo()
		{
			this.vipLimit.CustomActive(false);
			this.leftTime.CustomActive(false);
			int systemValueFromTable = Utility.GetSystemValueFromTable(SystemValueTable.eType2.SVT_GUILD_RED_PACKET_VIP_LV_LIMIT);
			int dailySendRedPacketMaxCount = DataManager<GuildDataManager>.GetInstance().GetDailySendRedPacketMaxCount();
			int dailySendRedPacketLeftCount = DataManager<GuildDataManager>.GetInstance().GetDailySendRedPacketLeftCount();
			bool flag;
			if (DataManager<PlayerBaseData>.GetInstance().VipLevel < systemValueFromTable)
			{
				flag = false;
				this.vipLimit.CustomActive(true);
				this.vipLimit.SafeSetText(TR.Value("guild_red_packet_need_vip_lv", systemValueFromTable));
			}
			else
			{
				flag = (dailySendRedPacketLeftCount > 0);
				this.leftTime.CustomActive(true);
				this.leftTime.SafeSetText(TR.Value("guild_red_packet_daily_left_count", dailySendRedPacketLeftCount, dailySendRedPacketMaxCount));
			}
			this.btSend.SafeSetGray(!flag, true);
		}

		// Token: 0x0400859D RID: 34205
		private List<GuildRedPacketFrame.GuildRedPackData> guildRedPackDatas;

		// Token: 0x0400859E RID: 34206
		private new Button Close;

		// Token: 0x0400859F RID: 34207
		private ComUIListScript redPackList;

		// Token: 0x040085A0 RID: 34208
		private Button redPackRecord;

		// Token: 0x040085A1 RID: 34209
		private Button btSend;

		// Token: 0x040085A2 RID: 34210
		private Text vipLimit;

		// Token: 0x040085A3 RID: 34211
		private Text leftTime;

		// Token: 0x0200164D RID: 5709
		public class GuildRedPackData
		{
			// Token: 0x040085A5 RID: 34213
			public RedPacketBaseEntry redPacketBaseEntry = new RedPacketBaseEntry();
		}
	}
}
