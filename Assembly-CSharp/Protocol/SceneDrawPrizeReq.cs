using System;

namespace Protocol
{
	// Token: 0x02000938 RID: 2360
	[Protocol]
	public class SceneDrawPrizeReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006B5F RID: 27487 RVA: 0x0013A26C File Offset: 0x0013866C
		public uint GetMsgID()
		{
			return 501006U;
		}

		// Token: 0x06006B60 RID: 27488 RVA: 0x0013A273 File Offset: 0x00138673
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006B61 RID: 27489 RVA: 0x0013A27B File Offset: 0x0013867B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006B62 RID: 27490 RVA: 0x0013A284 File Offset: 0x00138684
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
		}

		// Token: 0x06006B63 RID: 27491 RVA: 0x0013A294 File Offset: 0x00138694
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06006B64 RID: 27492 RVA: 0x0013A2A4 File Offset: 0x001386A4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
		}

		// Token: 0x06006B65 RID: 27493 RVA: 0x0013A2B4 File Offset: 0x001386B4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06006B66 RID: 27494 RVA: 0x0013A2C4 File Offset: 0x001386C4
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040030A9 RID: 12457
		public const uint MsgID = 501006U;

		// Token: 0x040030AA RID: 12458
		public uint Sequence;

		// Token: 0x040030AB RID: 12459
		public uint id;
	}
}
