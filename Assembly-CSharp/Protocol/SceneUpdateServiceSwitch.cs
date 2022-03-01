using System;

namespace Protocol
{
	// Token: 0x02000B3F RID: 2879
	[Protocol]
	public class SceneUpdateServiceSwitch : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007AFE RID: 31486 RVA: 0x001608C7 File Offset: 0x0015ECC7
		public uint GetMsgID()
		{
			return 501215U;
		}

		// Token: 0x06007AFF RID: 31487 RVA: 0x001608CE File Offset: 0x0015ECCE
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007B00 RID: 31488 RVA: 0x001608D6 File Offset: 0x0015ECD6
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007B01 RID: 31489 RVA: 0x001608DF File Offset: 0x0015ECDF
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, this.type);
			BaseDLL.encode_int8(buffer, ref pos_, this.open);
		}

		// Token: 0x06007B02 RID: 31490 RVA: 0x001608FD File Offset: 0x0015ECFD
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.open);
		}

		// Token: 0x06007B03 RID: 31491 RVA: 0x0016091B File Offset: 0x0015ED1B
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, this.type);
			BaseDLL.encode_int8(buffer, ref pos_, this.open);
		}

		// Token: 0x06007B04 RID: 31492 RVA: 0x00160939 File Offset: 0x0015ED39
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.open);
		}

		// Token: 0x06007B05 RID: 31493 RVA: 0x00160958 File Offset: 0x0015ED58
		public int getLen()
		{
			int num = 0;
			num += 2;
			return num + 1;
		}

		// Token: 0x04003A47 RID: 14919
		public const uint MsgID = 501215U;

		// Token: 0x04003A48 RID: 14920
		public uint Sequence;

		// Token: 0x04003A49 RID: 14921
		public ushort type;

		// Token: 0x04003A4A RID: 14922
		public byte open;
	}
}
