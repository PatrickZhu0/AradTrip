using System;

namespace Protocol
{
	// Token: 0x02000798 RID: 1944
	[Protocol]
	public class WorldDigMapOpenReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005F2C RID: 24364 RVA: 0x0011D516 File Offset: 0x0011B916
		public uint GetMsgID()
		{
			return 608205U;
		}

		// Token: 0x06005F2D RID: 24365 RVA: 0x0011D51D File Offset: 0x0011B91D
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005F2E RID: 24366 RVA: 0x0011D525 File Offset: 0x0011B925
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005F2F RID: 24367 RVA: 0x0011D52E File Offset: 0x0011B92E
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.mapId);
		}

		// Token: 0x06005F30 RID: 24368 RVA: 0x0011D53E File Offset: 0x0011B93E
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mapId);
		}

		// Token: 0x06005F31 RID: 24369 RVA: 0x0011D54E File Offset: 0x0011B94E
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.mapId);
		}

		// Token: 0x06005F32 RID: 24370 RVA: 0x0011D55E File Offset: 0x0011B95E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mapId);
		}

		// Token: 0x06005F33 RID: 24371 RVA: 0x0011D570 File Offset: 0x0011B970
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002746 RID: 10054
		public const uint MsgID = 608205U;

		// Token: 0x04002747 RID: 10055
		public uint Sequence;

		// Token: 0x04002748 RID: 10056
		public uint mapId;
	}
}
