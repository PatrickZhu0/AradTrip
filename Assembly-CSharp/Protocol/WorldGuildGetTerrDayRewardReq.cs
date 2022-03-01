using System;

namespace Protocol
{
	// Token: 0x0200087D RID: 2173
	[Protocol]
	public class WorldGuildGetTerrDayRewardReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060065D7 RID: 26071 RVA: 0x0012E4DC File Offset: 0x0012C8DC
		public uint GetMsgID()
		{
			return 601994U;
		}

		// Token: 0x060065D8 RID: 26072 RVA: 0x0012E4E3 File Offset: 0x0012C8E3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060065D9 RID: 26073 RVA: 0x0012E4EB File Offset: 0x0012C8EB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060065DA RID: 26074 RVA: 0x0012E4F4 File Offset: 0x0012C8F4
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060065DB RID: 26075 RVA: 0x0012E4F6 File Offset: 0x0012C8F6
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060065DC RID: 26076 RVA: 0x0012E4F8 File Offset: 0x0012C8F8
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060065DD RID: 26077 RVA: 0x0012E4FA File Offset: 0x0012C8FA
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060065DE RID: 26078 RVA: 0x0012E4FC File Offset: 0x0012C8FC
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002D97 RID: 11671
		public const uint MsgID = 601994U;

		// Token: 0x04002D98 RID: 11672
		public uint Sequence;
	}
}
