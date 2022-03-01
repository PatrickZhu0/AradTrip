using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200164E RID: 5710
	public class GuildRedPacketItem : MonoBehaviour
	{
		// Token: 0x0600E0B2 RID: 57522 RVA: 0x00397E65 File Offset: 0x00396265
		private void Start()
		{
		}

		// Token: 0x0600E0B3 RID: 57523 RVA: 0x00397E67 File Offset: 0x00396267
		private void OnDestroy()
		{
		}

		// Token: 0x0600E0B4 RID: 57524 RVA: 0x00397E69 File Offset: 0x00396269
		private void Update()
		{
		}

		// Token: 0x0600E0B5 RID: 57525 RVA: 0x00397E6C File Offset: 0x0039626C
		public void SetUp(ulong guid)
		{
			RedPacketBaseEntry redPacketBaseInfo = DataManager<RedPackDataManager>.GetInstance().GetRedPacketBaseInfo(guid);
			if (redPacketBaseInfo == null)
			{
				return;
			}
			this.name.SafeSetText(DataManager<RedPackDataManager>.GetInstance().GetGuildRedPacketTitleName(redPacketBaseInfo));
			this.leftCount.SafeSetText(TR.Value("guild_red_packet_left_count", redPacketBaseInfo.remainNum, redPacketBaseInfo.totalNum));
			this.owner.SafeSetText(TR.Value("guild_red_packet_owner", redPacketBaseInfo.ownerName));
			this.state.SafeSetText(DataManager<RedPackDataManager>.GetInstance().GetRedPacketStateText((int)redPacketBaseInfo.status));
			this.moneyNum.SafeSetText(redPacketBaseInfo.totalMoney.ToString());
			this.moneyIcon.SafeSetImage(DataManager<RedPackDataManager>.GetInstance().GetCostMoneyIcon((int)redPacketBaseInfo.reason), false);
			RedPacketStatus status = (RedPacketStatus)redPacketBaseInfo.status;
			this.btnGet.SafeSetOnClickListener(delegate
			{
				ulong guid2 = guid;
				DataManager<RedPackDataManager>.GetInstance().OpenRedPacket(guid2);
			});
			this.btnDetail.SafeSetOnClickListener(delegate
			{
				ulong guid2 = guid;
				DataManager<RedPackDataManager>.GetInstance().CheckRedPacket(guid2);
			});
			this.btnNotReach.SafeSetOnClickListener(delegate
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("guild_red_packet_not_reach"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			});
			this.btnNotReach.CustomActive(false);
			this.btnGet.CustomActive(false);
			this.btnDetail.CustomActive(false);
			if (status == RedPacketStatus.UNSATISFY)
			{
				this.btnNotReach.CustomActive(true);
			}
			else if (status == RedPacketStatus.WAIT_RECEIVE)
			{
				this.btnGet.CustomActive(true);
			}
			else if (status == RedPacketStatus.RECEIVED || status == RedPacketStatus.EMPTY)
			{
				this.btnDetail.CustomActive(true);
			}
			if (status == RedPacketStatus.RECEIVED || status == RedPacketStatus.EMPTY)
			{
				this.state.CustomActive(true);
				this.leftCount.CustomActive(false);
			}
			else
			{
				this.state.CustomActive(false);
				this.leftCount.CustomActive(true);
			}
		}

		// Token: 0x040085A6 RID: 34214
		[SerializeField]
		private Image icon;

		// Token: 0x040085A7 RID: 34215
		[SerializeField]
		private Text name;

		// Token: 0x040085A8 RID: 34216
		[SerializeField]
		private Text owner;

		// Token: 0x040085A9 RID: 34217
		[SerializeField]
		private Text leftCount;

		// Token: 0x040085AA RID: 34218
		[SerializeField]
		private Text state;

		// Token: 0x040085AB RID: 34219
		[SerializeField]
		private Text btnGetText;

		// Token: 0x040085AC RID: 34220
		[SerializeField]
		private Button btnGet;

		// Token: 0x040085AD RID: 34221
		[SerializeField]
		private Button btnDetail;

		// Token: 0x040085AE RID: 34222
		[SerializeField]
		private Button btnNotReach;

		// Token: 0x040085AF RID: 34223
		[SerializeField]
		private Image moneyIcon;

		// Token: 0x040085B0 RID: 34224
		[SerializeField]
		private Text moneyNum;
	}
}
