using System;
using Protocol;

namespace GameClient
{
	// Token: 0x020019E3 RID: 6627
	public class RelationData
	{
		// Token: 0x060103D2 RID: 66514 RVA: 0x0048B69F File Offset: 0x00489A9F
		public bool IsFriend()
		{
			return this.type == 1;
		}

		// Token: 0x060103D3 RID: 66515 RVA: 0x0048B6AA File Offset: 0x00489AAA
		public bool IsMater()
		{
			return this.type == 4;
		}

		// Token: 0x060103D4 RID: 66516 RVA: 0x0048B6B5 File Offset: 0x00489AB5
		public bool IsDisciple()
		{
			return this.type == 5;
		}

		// Token: 0x0400A46A RID: 42090
		public byte type;

		// Token: 0x0400A46B RID: 42091
		public ulong uid;

		// Token: 0x0400A46C RID: 42092
		public string name;

		// Token: 0x0400A46D RID: 42093
		public uint seasonLv;

		// Token: 0x0400A46E RID: 42094
		public ushort level;

		// Token: 0x0400A46F RID: 42095
		public byte occu;

		// Token: 0x0400A470 RID: 42096
		public byte dayGiftNum;

		// Token: 0x0400A471 RID: 42097
		public byte isOnline;

		// Token: 0x0400A472 RID: 42098
		public uint createTime;

		// Token: 0x0400A473 RID: 42099
		public byte vipLv;

		// Token: 0x0400A474 RID: 42100
		public byte status;

		// Token: 0x0400A475 RID: 42101
		public string announcement;

		// Token: 0x0400A476 RID: 42102
		public byte tapDayGiftTimes;

		// Token: 0x0400A477 RID: 42103
		public uint offlineTime;

		// Token: 0x0400A478 RID: 42104
		public uint intimacy;

		// Token: 0x0400A479 RID: 42105
		public string remark;

		// Token: 0x0400A47A RID: 42106
		public byte isRegress;

		// Token: 0x0400A47B RID: 42107
		public uint mark;

		// Token: 0x0400A47C RID: 42108
		public PlayerAvatar avatar = new PlayerAvatar();

		// Token: 0x0400A47D RID: 42109
		public byte activeTimeType;

		// Token: 0x0400A47E RID: 42110
		public byte masterType;

		// Token: 0x0400A47F RID: 42111
		public byte regionId;

		// Token: 0x0400A480 RID: 42112
		public string declaration;

		// Token: 0x0400A481 RID: 42113
		public byte dailyTaskState;

		// Token: 0x0400A482 RID: 42114
		public TAPType tapType;

		// Token: 0x0400A483 RID: 42115
		public PlayerLabelInfo playerLabelInfo = new PlayerLabelInfo();

		// Token: 0x0400A484 RID: 42116
		public uint headFrame;

		// Token: 0x0400A485 RID: 42117
		public uint zoneId;

		// Token: 0x0400A486 RID: 42118
		public uint returnYearTitle;
	}
}
