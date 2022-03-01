using System;

namespace Protocol
{
	// Token: 0x0200063E RID: 1598
	public class Relation : StreamObject
	{
		// Token: 0x04001FDB RID: 8155
		public ulong uid;

		// Token: 0x04001FDC RID: 8156
		[SProperty(1)]
		public string name;

		// Token: 0x04001FDD RID: 8157
		[SProperty(2)]
		public uint seasonLv;

		// Token: 0x04001FDE RID: 8158
		[SProperty(3)]
		public ushort level;

		// Token: 0x04001FDF RID: 8159
		[SProperty(4)]
		public byte occu;

		// Token: 0x04001FE0 RID: 8160
		[SProperty(6)]
		public byte dayGiftNum;

		// Token: 0x04001FE1 RID: 8161
		[SProperty(7)]
		public byte type;

		// Token: 0x04001FE2 RID: 8162
		[SProperty(8)]
		public uint createTime;

		// Token: 0x04001FE3 RID: 8163
		[SProperty(9)]
		public byte vipLv;

		// Token: 0x04001FE4 RID: 8164
		[SProperty(10)]
		public byte status;

		// Token: 0x04001FE5 RID: 8165
		[SProperty(11)]
		public byte dailyGiftTimes;

		// Token: 0x04001FE6 RID: 8166
		[SProperty(12)]
		public uint offlineTime;

		// Token: 0x04001FE7 RID: 8167
		[SProperty(13)]
		public ushort intimacy;

		// Token: 0x04001FE8 RID: 8168
		[SProperty(14)]
		public byte dailyMasterTaskState;

		// Token: 0x04001FE9 RID: 8169
		[SProperty(15)]
		public string remark;

		// Token: 0x04001FEA RID: 8170
		[SProperty(16)]
		public byte isRegress;

		// Token: 0x04001FEB RID: 8171
		[SProperty(17)]
		public ushort mark;

		// Token: 0x04001FEC RID: 8172
		[SProperty(18)]
		public uint headFrame;

		// Token: 0x04001FED RID: 8173
		[SProperty(19)]
		public ulong guildId;

		// Token: 0x04001FEE RID: 8174
		[SProperty(20)]
		public uint returnYearTitle;

		// Token: 0x04001FEF RID: 8175
		public byte isOnline;
	}
}
