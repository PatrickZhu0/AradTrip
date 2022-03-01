using System;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200164B RID: 5707
	public class GuildRedPackSubTypeItem : MonoBehaviour
	{
		// Token: 0x0600E092 RID: 57490 RVA: 0x00397521 File Offset: 0x00395921
		private void Awake()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnUpdateGuildRedPacketSpecInfo, new ClientEventSystem.UIEventHandler(this._OnUpdateGuildRedPacketSpecInfo));
		}

		// Token: 0x0600E093 RID: 57491 RVA: 0x0039753E File Offset: 0x0039593E
		private void Start()
		{
			this.UpdateInfo();
		}

		// Token: 0x0600E094 RID: 57492 RVA: 0x00397546 File Offset: 0x00395946
		private void OnDestroy()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnUpdateGuildRedPacketSpecInfo, new ClientEventSystem.UIEventHandler(this._OnUpdateGuildRedPacketSpecInfo));
		}

		// Token: 0x0600E095 RID: 57493 RVA: 0x00397563 File Offset: 0x00395963
		private void OnDisable()
		{
		}

		// Token: 0x0600E096 RID: 57494 RVA: 0x00397565 File Offset: 0x00395965
		private void _OnUpdateGuildRedPacketSpecInfo(UIEvent uiEvent)
		{
			this.UpdateInfo();
		}

		// Token: 0x0600E097 RID: 57495 RVA: 0x0039756D File Offset: 0x0039596D
		private void Update()
		{
		}

		// Token: 0x0600E098 RID: 57496 RVA: 0x0039756F File Offset: 0x0039596F
		public void SetUp(object data)
		{
		}

		// Token: 0x0600E099 RID: 57497 RVA: 0x00397574 File Offset: 0x00395974
		private void UpdateInfo()
		{
			GuildRedPacketSpecInfo guildRedPacketSpecInfo = DataManager<RedPackDataManager>.GetInstance().GetGuildRedPacketSpecInfo(this.sendRedPackType);
			this.btnSelect.SafeSetOnClickListener(delegate
			{
				if (guildRedPacketSpecInfo != null && guildRedPacketSpecInfo.joinNum == 0U)
				{
					return;
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnSelectGuildRedPackType, this.sendRedPackType, null, null, null);
			});
			if (guildRedPacketSpecInfo != null)
			{
				this.name.SafeSetText(SendRedPacketFrame.GetRedPackTypeName(this.sendRedPackType) + TR.Value("guild_red_packet_player_num", guildRedPacketSpecInfo.joinNum));
				DateTime dateTimeByTimeStamp = TimeUtility.GetDateTimeByTimeStamp((int)guildRedPacketSpecInfo.lastTime);
				this.time.SafeSetText(TR.Value("guild_red_packet_last_join_time", dateTimeByTimeStamp.Year, dateTimeByTimeStamp.Month, dateTimeByTimeStamp.Day));
				if (this.sendRedPackType == SendRedPackType.GuildWar)
				{
					this.receiverInfo.SafeSetText(TR.Value("guild_red_packet_guild_war_receiver", dateTimeByTimeStamp.Month, dateTimeByTimeStamp.Day));
				}
				else if (this.sendRedPackType == SendRedPackType.CrossGuildWar)
				{
					this.receiverInfo.SafeSetText(TR.Value("guild_red_packet_cross_guild_war_receiver", dateTimeByTimeStamp.Month, dateTimeByTimeStamp.Day));
				}
				else if (this.sendRedPackType == SendRedPackType.GuildDungeon)
				{
					this.receiverInfo.SafeSetText(TR.Value("guild_red_packet_guild_dungeon_receiver", dateTimeByTimeStamp.Month, dateTimeByTimeStamp.Day));
				}
				else if (this.sendRedPackType == SendRedPackType.GuildMember)
				{
					this.receiverInfo.SafeSetText(TR.Value("guild_red_packet_all_members_receiver"));
				}
				UIGray uigray = base.gameObject.SafeAddComponent(false);
				if (uigray != null)
				{
					uigray.enabled = (guildRedPacketSpecInfo.joinNum == 0U);
				}
			}
			if (this.sendRedPackType == SendRedPackType.GuildMember && DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
			{
				this.time.SafeSetText(string.Empty);
			}
		}

		// Token: 0x04008598 RID: 34200
		[SerializeField]
		private SendRedPackType sendRedPackType = SendRedPackType.GuildMember;

		// Token: 0x04008599 RID: 34201
		[SerializeField]
		private Text name;

		// Token: 0x0400859A RID: 34202
		[SerializeField]
		private Text time;

		// Token: 0x0400859B RID: 34203
		[SerializeField]
		private Text receiverInfo;

		// Token: 0x0400859C RID: 34204
		[SerializeField]
		private Button btnSelect;
	}
}
