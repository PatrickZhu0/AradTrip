using System;

namespace Protocol
{
	// Token: 0x0200079A RID: 1946
	[Protocol]
	public class WorldDigMapCloseReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005F3E RID: 24382 RVA: 0x0011D7B5 File Offset: 0x0011BBB5
		public uint GetMsgID()
		{
			return 608207U;
		}

		// Token: 0x06005F3F RID: 24383 RVA: 0x0011D7BC File Offset: 0x0011BBBC
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005F40 RID: 24384 RVA: 0x0011D7C4 File Offset: 0x0011BBC4
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005F41 RID: 24385 RVA: 0x0011D7CD File Offset: 0x0011BBCD
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.mapId);
		}

		// Token: 0x06005F42 RID: 24386 RVA: 0x0011D7DD File Offset: 0x0011BBDD
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mapId);
		}

		// Token: 0x06005F43 RID: 24387 RVA: 0x0011D7ED File Offset: 0x0011BBED
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.mapId);
		}

		// Token: 0x06005F44 RID: 24388 RVA: 0x0011D7FD File Offset: 0x0011BBFD
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mapId);
		}

		// Token: 0x06005F45 RID: 24389 RVA: 0x0011D810 File Offset: 0x0011BC10
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400274E RID: 10062
		public const uint MsgID = 608207U;

		// Token: 0x0400274F RID: 10063
		public uint Sequence;

		// Token: 0x04002750 RID: 10064
		public uint mapId;
	}
}
