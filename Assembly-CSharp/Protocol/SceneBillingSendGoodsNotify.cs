using System;

namespace Protocol
{
	// Token: 0x02000C35 RID: 3125
	[Protocol]
	public class SceneBillingSendGoodsNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008245 RID: 33349 RVA: 0x0016F3E4 File Offset: 0x0016D7E4
		public uint GetMsgID()
		{
			return 504003U;
		}

		// Token: 0x06008246 RID: 33350 RVA: 0x0016F3EB File Offset: 0x0016D7EB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008247 RID: 33351 RVA: 0x0016F3F3 File Offset: 0x0016D7F3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008248 RID: 33352 RVA: 0x0016F3FC File Offset: 0x0016D7FC
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06008249 RID: 33353 RVA: 0x0016F3FE File Offset: 0x0016D7FE
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600824A RID: 33354 RVA: 0x0016F400 File Offset: 0x0016D800
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600824B RID: 33355 RVA: 0x0016F402 File Offset: 0x0016D802
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600824C RID: 33356 RVA: 0x0016F404 File Offset: 0x0016D804
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003E3A RID: 15930
		public const uint MsgID = 504003U;

		// Token: 0x04003E3B RID: 15931
		public uint Sequence;
	}
}
