using System;

namespace Protocol
{
	// Token: 0x020006A0 RID: 1696
	[Protocol]
	public class WorldQueryExpeditionMapReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060057B3 RID: 22451 RVA: 0x0010B27A File Offset: 0x0010967A
		public uint GetMsgID()
		{
			return 608611U;
		}

		// Token: 0x060057B4 RID: 22452 RVA: 0x0010B281 File Offset: 0x00109681
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060057B5 RID: 22453 RVA: 0x0010B289 File Offset: 0x00109689
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060057B6 RID: 22454 RVA: 0x0010B292 File Offset: 0x00109692
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.mapId);
		}

		// Token: 0x060057B7 RID: 22455 RVA: 0x0010B2A2 File Offset: 0x001096A2
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.mapId);
		}

		// Token: 0x060057B8 RID: 22456 RVA: 0x0010B2B2 File Offset: 0x001096B2
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.mapId);
		}

		// Token: 0x060057B9 RID: 22457 RVA: 0x0010B2C2 File Offset: 0x001096C2
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.mapId);
		}

		// Token: 0x060057BA RID: 22458 RVA: 0x0010B2D4 File Offset: 0x001096D4
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x040022DE RID: 8926
		public const uint MsgID = 608611U;

		// Token: 0x040022DF RID: 8927
		public uint Sequence;

		// Token: 0x040022E0 RID: 8928
		public byte mapId;
	}
}
