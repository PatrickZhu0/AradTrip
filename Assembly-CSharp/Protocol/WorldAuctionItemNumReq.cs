using System;

namespace Protocol
{
	// Token: 0x020006CB RID: 1739
	[Protocol]
	public class WorldAuctionItemNumReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060058D2 RID: 22738 RVA: 0x0010E5BB File Offset: 0x0010C9BB
		public uint GetMsgID()
		{
			return 603920U;
		}

		// Token: 0x060058D3 RID: 22739 RVA: 0x0010E5C2 File Offset: 0x0010C9C2
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060058D4 RID: 22740 RVA: 0x0010E5CA File Offset: 0x0010C9CA
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060058D5 RID: 22741 RVA: 0x0010E5D3 File Offset: 0x0010C9D3
		public void encode(byte[] buffer, ref int pos_)
		{
			this.cond.encode(buffer, ref pos_);
		}

		// Token: 0x060058D6 RID: 22742 RVA: 0x0010E5E2 File Offset: 0x0010C9E2
		public void decode(byte[] buffer, ref int pos_)
		{
			this.cond.decode(buffer, ref pos_);
		}

		// Token: 0x060058D7 RID: 22743 RVA: 0x0010E5F1 File Offset: 0x0010C9F1
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.cond.encode(buffer, ref pos_);
		}

		// Token: 0x060058D8 RID: 22744 RVA: 0x0010E600 File Offset: 0x0010CA00
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.cond.decode(buffer, ref pos_);
		}

		// Token: 0x060058D9 RID: 22745 RVA: 0x0010E610 File Offset: 0x0010CA10
		public int getLen()
		{
			int num = 0;
			return num + this.cond.getLen();
		}

		// Token: 0x040023A9 RID: 9129
		public const uint MsgID = 603920U;

		// Token: 0x040023AA RID: 9130
		public uint Sequence;

		// Token: 0x040023AB RID: 9131
		public AuctionQueryCondition cond = new AuctionQueryCondition();
	}
}
