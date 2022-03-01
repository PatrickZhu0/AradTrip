using System;

namespace Protocol
{
	// Token: 0x02000A11 RID: 2577
	[Protocol]
	public class WorldMonopolyCardExchangeRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600725E RID: 29278 RVA: 0x0014B5F8 File Offset: 0x001499F8
		public uint GetMsgID()
		{
			return 610208U;
		}

		// Token: 0x0600725F RID: 29279 RVA: 0x0014B5FF File Offset: 0x001499FF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007260 RID: 29280 RVA: 0x0014B607 File Offset: 0x00149A07
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007261 RID: 29281 RVA: 0x0014B610 File Offset: 0x00149A10
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.errorCode);
		}

		// Token: 0x06007262 RID: 29282 RVA: 0x0014B620 File Offset: 0x00149A20
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.errorCode);
		}

		// Token: 0x06007263 RID: 29283 RVA: 0x0014B630 File Offset: 0x00149A30
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.errorCode);
		}

		// Token: 0x06007264 RID: 29284 RVA: 0x0014B640 File Offset: 0x00149A40
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.errorCode);
		}

		// Token: 0x06007265 RID: 29285 RVA: 0x0014B650 File Offset: 0x00149A50
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003490 RID: 13456
		public const uint MsgID = 610208U;

		// Token: 0x04003491 RID: 13457
		public uint Sequence;

		// Token: 0x04003492 RID: 13458
		public uint errorCode;
	}
}
