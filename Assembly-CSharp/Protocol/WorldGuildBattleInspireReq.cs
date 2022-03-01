using System;

namespace Protocol
{
	// Token: 0x02000855 RID: 2133
	[Protocol]
	public class WorldGuildBattleInspireReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600646F RID: 25711 RVA: 0x0012BB28 File Offset: 0x00129F28
		public uint GetMsgID()
		{
			return 601944U;
		}

		// Token: 0x06006470 RID: 25712 RVA: 0x0012BB2F File Offset: 0x00129F2F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006471 RID: 25713 RVA: 0x0012BB37 File Offset: 0x00129F37
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006472 RID: 25714 RVA: 0x0012BB40 File Offset: 0x00129F40
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006473 RID: 25715 RVA: 0x0012BB42 File Offset: 0x00129F42
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006474 RID: 25716 RVA: 0x0012BB44 File Offset: 0x00129F44
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006475 RID: 25717 RVA: 0x0012BB46 File Offset: 0x00129F46
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006476 RID: 25718 RVA: 0x0012BB48 File Offset: 0x00129F48
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002D00 RID: 11520
		public const uint MsgID = 601944U;

		// Token: 0x04002D01 RID: 11521
		public uint Sequence;
	}
}
