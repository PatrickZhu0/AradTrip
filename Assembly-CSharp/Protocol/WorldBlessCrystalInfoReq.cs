using System;

namespace Protocol
{
	// Token: 0x02000698 RID: 1688
	[Protocol]
	public class WorldBlessCrystalInfoReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600576B RID: 22379 RVA: 0x0010AE14 File Offset: 0x00109214
		public uint GetMsgID()
		{
			return 608603U;
		}

		// Token: 0x0600576C RID: 22380 RVA: 0x0010AE1B File Offset: 0x0010921B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600576D RID: 22381 RVA: 0x0010AE23 File Offset: 0x00109223
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600576E RID: 22382 RVA: 0x0010AE2C File Offset: 0x0010922C
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600576F RID: 22383 RVA: 0x0010AE2E File Offset: 0x0010922E
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005770 RID: 22384 RVA: 0x0010AE30 File Offset: 0x00109230
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005771 RID: 22385 RVA: 0x0010AE32 File Offset: 0x00109232
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005772 RID: 22386 RVA: 0x0010AE34 File Offset: 0x00109234
		public int getLen()
		{
			return 0;
		}

		// Token: 0x040022C3 RID: 8899
		public const uint MsgID = 608603U;

		// Token: 0x040022C4 RID: 8900
		public uint Sequence;
	}
}
