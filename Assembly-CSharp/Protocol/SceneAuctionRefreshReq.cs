using System;

namespace Protocol
{
	// Token: 0x020006CD RID: 1741
	[Protocol]
	public class SceneAuctionRefreshReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060058E4 RID: 22756 RVA: 0x0010E81D File Offset: 0x0010CC1D
		public uint GetMsgID()
		{
			return 503901U;
		}

		// Token: 0x060058E5 RID: 22757 RVA: 0x0010E824 File Offset: 0x0010CC24
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060058E6 RID: 22758 RVA: 0x0010E82C File Offset: 0x0010CC2C
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060058E7 RID: 22759 RVA: 0x0010E835 File Offset: 0x0010CC35
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060058E8 RID: 22760 RVA: 0x0010E837 File Offset: 0x0010CC37
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060058E9 RID: 22761 RVA: 0x0010E839 File Offset: 0x0010CC39
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060058EA RID: 22762 RVA: 0x0010E83B File Offset: 0x0010CC3B
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060058EB RID: 22763 RVA: 0x0010E840 File Offset: 0x0010CC40
		public int getLen()
		{
			return 0;
		}

		// Token: 0x040023B0 RID: 9136
		public const uint MsgID = 503901U;

		// Token: 0x040023B1 RID: 9137
		public uint Sequence;
	}
}
