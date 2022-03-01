using System;

namespace Protocol
{
	// Token: 0x02000898 RID: 2200
	[Protocol]
	public class WorldGuildAuctionFixReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060066B5 RID: 26293 RVA: 0x00130204 File Offset: 0x0012E604
		public uint GetMsgID()
		{
			return 608517U;
		}

		// Token: 0x060066B6 RID: 26294 RVA: 0x0013020B File Offset: 0x0012E60B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060066B7 RID: 26295 RVA: 0x00130213 File Offset: 0x0012E613
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060066B8 RID: 26296 RVA: 0x0013021C File Offset: 0x0012E61C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
		}

		// Token: 0x060066B9 RID: 26297 RVA: 0x0013022C File Offset: 0x0012E62C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
		}

		// Token: 0x060066BA RID: 26298 RVA: 0x0013023C File Offset: 0x0012E63C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
		}

		// Token: 0x060066BB RID: 26299 RVA: 0x0013024C File Offset: 0x0012E64C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
		}

		// Token: 0x060066BC RID: 26300 RVA: 0x0013025C File Offset: 0x0012E65C
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x04002DF0 RID: 11760
		public const uint MsgID = 608517U;

		// Token: 0x04002DF1 RID: 11761
		public uint Sequence;

		// Token: 0x04002DF2 RID: 11762
		public ulong guid;
	}
}
