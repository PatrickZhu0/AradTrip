using System;

namespace Protocol
{
	// Token: 0x02000BC3 RID: 3011
	[Protocol]
	public class TeamCopyTeamQuitRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007E8B RID: 32395 RVA: 0x001675F4 File Offset: 0x001659F4
		public uint GetMsgID()
		{
			return 1100012U;
		}

		// Token: 0x06007E8C RID: 32396 RVA: 0x001675FB File Offset: 0x001659FB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007E8D RID: 32397 RVA: 0x00167603 File Offset: 0x00165A03
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007E8E RID: 32398 RVA: 0x0016760C File Offset: 0x00165A0C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06007E8F RID: 32399 RVA: 0x0016761C File Offset: 0x00165A1C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06007E90 RID: 32400 RVA: 0x0016762C File Offset: 0x00165A2C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06007E91 RID: 32401 RVA: 0x0016763C File Offset: 0x00165A3C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06007E92 RID: 32402 RVA: 0x0016764C File Offset: 0x00165A4C
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003C6E RID: 15470
		public const uint MsgID = 1100012U;

		// Token: 0x04003C6F RID: 15471
		public uint Sequence;

		// Token: 0x04003C70 RID: 15472
		public uint retCode;
	}
}
