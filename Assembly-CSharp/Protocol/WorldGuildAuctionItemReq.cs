using System;

namespace Protocol
{
	// Token: 0x02000893 RID: 2195
	[Protocol]
	public class WorldGuildAuctionItemReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600668B RID: 26251 RVA: 0x0012FB4C File Offset: 0x0012DF4C
		public uint GetMsgID()
		{
			return 608513U;
		}

		// Token: 0x0600668C RID: 26252 RVA: 0x0012FB53 File Offset: 0x0012DF53
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600668D RID: 26253 RVA: 0x0012FB5B File Offset: 0x0012DF5B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600668E RID: 26254 RVA: 0x0012FB64 File Offset: 0x0012DF64
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.type);
		}

		// Token: 0x0600668F RID: 26255 RVA: 0x0012FB74 File Offset: 0x0012DF74
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.type);
		}

		// Token: 0x06006690 RID: 26256 RVA: 0x0012FB84 File Offset: 0x0012DF84
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.type);
		}

		// Token: 0x06006691 RID: 26257 RVA: 0x0012FB94 File Offset: 0x0012DF94
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.type);
		}

		// Token: 0x06006692 RID: 26258 RVA: 0x0012FBA4 File Offset: 0x0012DFA4
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002DDA RID: 11738
		public const uint MsgID = 608513U;

		// Token: 0x04002DDB RID: 11739
		public uint Sequence;

		// Token: 0x04002DDC RID: 11740
		public uint type;
	}
}
