using System;

namespace Protocol
{
	// Token: 0x0200079C RID: 1948
	[Protocol]
	public class WorldDigWatchReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005F50 RID: 24400 RVA: 0x0011D8A0 File Offset: 0x0011BCA0
		public uint GetMsgID()
		{
			return 608209U;
		}

		// Token: 0x06005F51 RID: 24401 RVA: 0x0011D8A7 File Offset: 0x0011BCA7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005F52 RID: 24402 RVA: 0x0011D8AF File Offset: 0x0011BCAF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005F53 RID: 24403 RVA: 0x0011D8B8 File Offset: 0x0011BCB8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.mapId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.index);
		}

		// Token: 0x06005F54 RID: 24404 RVA: 0x0011D8D6 File Offset: 0x0011BCD6
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mapId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.index);
		}

		// Token: 0x06005F55 RID: 24405 RVA: 0x0011D8F4 File Offset: 0x0011BCF4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.mapId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.index);
		}

		// Token: 0x06005F56 RID: 24406 RVA: 0x0011D912 File Offset: 0x0011BD12
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mapId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.index);
		}

		// Token: 0x06005F57 RID: 24407 RVA: 0x0011D930 File Offset: 0x0011BD30
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002754 RID: 10068
		public const uint MsgID = 608209U;

		// Token: 0x04002755 RID: 10069
		public uint Sequence;

		// Token: 0x04002756 RID: 10070
		public uint mapId;

		// Token: 0x04002757 RID: 10071
		public uint index;
	}
}
