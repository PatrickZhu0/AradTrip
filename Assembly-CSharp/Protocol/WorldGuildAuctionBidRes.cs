using System;

namespace Protocol
{
	// Token: 0x02000897 RID: 2199
	[Protocol]
	public class WorldGuildAuctionBidRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060066AC RID: 26284 RVA: 0x00130190 File Offset: 0x0012E590
		public uint GetMsgID()
		{
			return 608516U;
		}

		// Token: 0x060066AD RID: 26285 RVA: 0x00130197 File Offset: 0x0012E597
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060066AE RID: 26286 RVA: 0x0013019F File Offset: 0x0012E59F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060066AF RID: 26287 RVA: 0x001301A8 File Offset: 0x0012E5A8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x060066B0 RID: 26288 RVA: 0x001301B8 File Offset: 0x0012E5B8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x060066B1 RID: 26289 RVA: 0x001301C8 File Offset: 0x0012E5C8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x060066B2 RID: 26290 RVA: 0x001301D8 File Offset: 0x0012E5D8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x060066B3 RID: 26291 RVA: 0x001301E8 File Offset: 0x0012E5E8
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002DED RID: 11757
		public const uint MsgID = 608516U;

		// Token: 0x04002DEE RID: 11758
		public uint Sequence;

		// Token: 0x04002DEF RID: 11759
		public uint retCode;
	}
}
