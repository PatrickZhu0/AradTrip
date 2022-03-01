using System;

namespace Protocol
{
	// Token: 0x02000883 RID: 2179
	[Protocol]
	public class WorldGuildDungeonDamageRankReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006607 RID: 26119 RVA: 0x0012EBD2 File Offset: 0x0012CFD2
		public uint GetMsgID()
		{
			return 608503U;
		}

		// Token: 0x06006608 RID: 26120 RVA: 0x0012EBD9 File Offset: 0x0012CFD9
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006609 RID: 26121 RVA: 0x0012EBE1 File Offset: 0x0012CFE1
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600660A RID: 26122 RVA: 0x0012EBEA File Offset: 0x0012CFEA
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600660B RID: 26123 RVA: 0x0012EBEC File Offset: 0x0012CFEC
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600660C RID: 26124 RVA: 0x0012EBEE File Offset: 0x0012CFEE
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600660D RID: 26125 RVA: 0x0012EBF0 File Offset: 0x0012CFF0
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600660E RID: 26126 RVA: 0x0012EBF4 File Offset: 0x0012CFF4
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002DAB RID: 11691
		public const uint MsgID = 608503U;

		// Token: 0x04002DAC RID: 11692
		public uint Sequence;
	}
}
