using System;

namespace Protocol
{
	// Token: 0x0200079B RID: 1947
	[Protocol]
	public class WorldDigMapCloseRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005F47 RID: 24391 RVA: 0x0011D82C File Offset: 0x0011BC2C
		public uint GetMsgID()
		{
			return 608208U;
		}

		// Token: 0x06005F48 RID: 24392 RVA: 0x0011D833 File Offset: 0x0011BC33
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005F49 RID: 24393 RVA: 0x0011D83B File Offset: 0x0011BC3B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005F4A RID: 24394 RVA: 0x0011D844 File Offset: 0x0011BC44
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06005F4B RID: 24395 RVA: 0x0011D854 File Offset: 0x0011BC54
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06005F4C RID: 24396 RVA: 0x0011D864 File Offset: 0x0011BC64
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06005F4D RID: 24397 RVA: 0x0011D874 File Offset: 0x0011BC74
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06005F4E RID: 24398 RVA: 0x0011D884 File Offset: 0x0011BC84
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002751 RID: 10065
		public const uint MsgID = 608208U;

		// Token: 0x04002752 RID: 10066
		public uint Sequence;

		// Token: 0x04002753 RID: 10067
		public uint result;
	}
}
