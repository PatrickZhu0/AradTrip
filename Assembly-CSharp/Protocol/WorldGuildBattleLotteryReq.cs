using System;

namespace Protocol
{
	// Token: 0x0200086C RID: 2156
	[Protocol]
	public class WorldGuildBattleLotteryReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600653E RID: 25918 RVA: 0x0012D3F0 File Offset: 0x0012B7F0
		public uint GetMsgID()
		{
			return 601967U;
		}

		// Token: 0x0600653F RID: 25919 RVA: 0x0012D3F7 File Offset: 0x0012B7F7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006540 RID: 25920 RVA: 0x0012D3FF File Offset: 0x0012B7FF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006541 RID: 25921 RVA: 0x0012D408 File Offset: 0x0012B808
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006542 RID: 25922 RVA: 0x0012D40A File Offset: 0x0012B80A
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006543 RID: 25923 RVA: 0x0012D40C File Offset: 0x0012B80C
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006544 RID: 25924 RVA: 0x0012D40E File Offset: 0x0012B80E
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006545 RID: 25925 RVA: 0x0012D410 File Offset: 0x0012B810
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002D60 RID: 11616
		public const uint MsgID = 601967U;

		// Token: 0x04002D61 RID: 11617
		public uint Sequence;
	}
}
