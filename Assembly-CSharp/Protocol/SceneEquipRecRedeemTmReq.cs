using System;

namespace Protocol
{
	// Token: 0x02000941 RID: 2369
	[Protocol]
	public class SceneEquipRecRedeemTmReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006BAD RID: 27565 RVA: 0x0013AA5C File Offset: 0x00138E5C
		public uint GetMsgID()
		{
			return 501014U;
		}

		// Token: 0x06006BAE RID: 27566 RVA: 0x0013AA63 File Offset: 0x00138E63
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006BAF RID: 27567 RVA: 0x0013AA6B File Offset: 0x00138E6B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006BB0 RID: 27568 RVA: 0x0013AA74 File Offset: 0x00138E74
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006BB1 RID: 27569 RVA: 0x0013AA76 File Offset: 0x00138E76
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006BB2 RID: 27570 RVA: 0x0013AA78 File Offset: 0x00138E78
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006BB3 RID: 27571 RVA: 0x0013AA7A File Offset: 0x00138E7A
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006BB4 RID: 27572 RVA: 0x0013AA7C File Offset: 0x00138E7C
		public int getLen()
		{
			return 0;
		}

		// Token: 0x040030C9 RID: 12489
		public const uint MsgID = 501014U;

		// Token: 0x040030CA RID: 12490
		public uint Sequence;
	}
}
