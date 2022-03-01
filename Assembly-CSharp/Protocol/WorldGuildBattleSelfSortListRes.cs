using System;

namespace Protocol
{
	// Token: 0x02000861 RID: 2145
	[Protocol]
	public class WorldGuildBattleSelfSortListRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060064DB RID: 25819 RVA: 0x0012C49C File Offset: 0x0012A89C
		public uint GetMsgID()
		{
			return 601956U;
		}

		// Token: 0x060064DC RID: 25820 RVA: 0x0012C4A3 File Offset: 0x0012A8A3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060064DD RID: 25821 RVA: 0x0012C4AB File Offset: 0x0012A8AB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060064DE RID: 25822 RVA: 0x0012C4B4 File Offset: 0x0012A8B4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.memberRanking);
			BaseDLL.encode_uint32(buffer, ref pos_, this.guildRanking);
		}

		// Token: 0x060064DF RID: 25823 RVA: 0x0012C4E0 File Offset: 0x0012A8E0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.memberRanking);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.guildRanking);
		}

		// Token: 0x060064E0 RID: 25824 RVA: 0x0012C50C File Offset: 0x0012A90C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.memberRanking);
			BaseDLL.encode_uint32(buffer, ref pos_, this.guildRanking);
		}

		// Token: 0x060064E1 RID: 25825 RVA: 0x0012C538 File Offset: 0x0012A938
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.memberRanking);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.guildRanking);
		}

		// Token: 0x060064E2 RID: 25826 RVA: 0x0012C564 File Offset: 0x0012A964
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002D2A RID: 11562
		public const uint MsgID = 601956U;

		// Token: 0x04002D2B RID: 11563
		public uint Sequence;

		// Token: 0x04002D2C RID: 11564
		public uint result;

		// Token: 0x04002D2D RID: 11565
		public uint memberRanking;

		// Token: 0x04002D2E RID: 11566
		public uint guildRanking;
	}
}
