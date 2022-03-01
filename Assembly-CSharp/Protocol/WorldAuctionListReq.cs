using System;

namespace Protocol
{
	// Token: 0x020006BE RID: 1726
	[Protocol]
	public class WorldAuctionListReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005860 RID: 22624 RVA: 0x0010D36F File Offset: 0x0010B76F
		public uint GetMsgID()
		{
			return 603901U;
		}

		// Token: 0x06005861 RID: 22625 RVA: 0x0010D376 File Offset: 0x0010B776
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005862 RID: 22626 RVA: 0x0010D37E File Offset: 0x0010B77E
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005863 RID: 22627 RVA: 0x0010D387 File Offset: 0x0010B787
		public void encode(byte[] buffer, ref int pos_)
		{
			this.cond.encode(buffer, ref pos_);
		}

		// Token: 0x06005864 RID: 22628 RVA: 0x0010D396 File Offset: 0x0010B796
		public void decode(byte[] buffer, ref int pos_)
		{
			this.cond.decode(buffer, ref pos_);
		}

		// Token: 0x06005865 RID: 22629 RVA: 0x0010D3A5 File Offset: 0x0010B7A5
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.cond.encode(buffer, ref pos_);
		}

		// Token: 0x06005866 RID: 22630 RVA: 0x0010D3B4 File Offset: 0x0010B7B4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.cond.decode(buffer, ref pos_);
		}

		// Token: 0x06005867 RID: 22631 RVA: 0x0010D3C4 File Offset: 0x0010B7C4
		public int getLen()
		{
			int num = 0;
			return num + this.cond.getLen();
		}

		// Token: 0x0400235B RID: 9051
		public const uint MsgID = 603901U;

		// Token: 0x0400235C RID: 9052
		public uint Sequence;

		// Token: 0x0400235D RID: 9053
		public AuctionQueryCondition cond = new AuctionQueryCondition();
	}
}
