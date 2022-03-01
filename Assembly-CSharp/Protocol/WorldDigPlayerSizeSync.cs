using System;

namespace Protocol
{
	// Token: 0x02000796 RID: 1942
	[Protocol]
	public class WorldDigPlayerSizeSync : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005F1A RID: 24346 RVA: 0x0011D3DD File Offset: 0x0011B7DD
		public uint GetMsgID()
		{
			return 608203U;
		}

		// Token: 0x06005F1B RID: 24347 RVA: 0x0011D3E4 File Offset: 0x0011B7E4
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005F1C RID: 24348 RVA: 0x0011D3EC File Offset: 0x0011B7EC
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005F1D RID: 24349 RVA: 0x0011D3F5 File Offset: 0x0011B7F5
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.mapId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.playerSize);
		}

		// Token: 0x06005F1E RID: 24350 RVA: 0x0011D413 File Offset: 0x0011B813
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mapId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.playerSize);
		}

		// Token: 0x06005F1F RID: 24351 RVA: 0x0011D431 File Offset: 0x0011B831
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.mapId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.playerSize);
		}

		// Token: 0x06005F20 RID: 24352 RVA: 0x0011D44F File Offset: 0x0011B84F
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mapId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.playerSize);
		}

		// Token: 0x06005F21 RID: 24353 RVA: 0x0011D470 File Offset: 0x0011B870
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x0400273F RID: 10047
		public const uint MsgID = 608203U;

		// Token: 0x04002740 RID: 10048
		public uint Sequence;

		// Token: 0x04002741 RID: 10049
		public uint mapId;

		// Token: 0x04002742 RID: 10050
		public uint playerSize;
	}
}
