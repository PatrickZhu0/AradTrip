using System;

namespace Protocol
{
	// Token: 0x02000874 RID: 2164
	[Protocol]
	public class WorldGuildDelStorageRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006586 RID: 25990 RVA: 0x0012DF49 File Offset: 0x0012C349
		public uint GetMsgID()
		{
			return 601975U;
		}

		// Token: 0x06006587 RID: 25991 RVA: 0x0012DF50 File Offset: 0x0012C350
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006588 RID: 25992 RVA: 0x0012DF58 File Offset: 0x0012C358
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006589 RID: 25993 RVA: 0x0012DF61 File Offset: 0x0012C361
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x0600658A RID: 25994 RVA: 0x0012DF71 File Offset: 0x0012C371
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x0600658B RID: 25995 RVA: 0x0012DF81 File Offset: 0x0012C381
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x0600658C RID: 25996 RVA: 0x0012DF91 File Offset: 0x0012C391
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x0600658D RID: 25997 RVA: 0x0012DFA4 File Offset: 0x0012C3A4
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002D7B RID: 11643
		public const uint MsgID = 601975U;

		// Token: 0x04002D7C RID: 11644
		public uint Sequence;

		// Token: 0x04002D7D RID: 11645
		public uint result;
	}
}
