using System;

namespace Protocol
{
	// Token: 0x020006D0 RID: 1744
	[Protocol]
	public class SceneAuctionBuyBoothRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060058FF RID: 22783 RVA: 0x0010E904 File Offset: 0x0010CD04
		public uint GetMsgID()
		{
			return 503904U;
		}

		// Token: 0x06005900 RID: 22784 RVA: 0x0010E90B File Offset: 0x0010CD0B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005901 RID: 22785 RVA: 0x0010E913 File Offset: 0x0010CD13
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005902 RID: 22786 RVA: 0x0010E91C File Offset: 0x0010CD1C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.boothNum);
		}

		// Token: 0x06005903 RID: 22787 RVA: 0x0010E93A File Offset: 0x0010CD3A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.boothNum);
		}

		// Token: 0x06005904 RID: 22788 RVA: 0x0010E958 File Offset: 0x0010CD58
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.boothNum);
		}

		// Token: 0x06005905 RID: 22789 RVA: 0x0010E976 File Offset: 0x0010CD76
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.boothNum);
		}

		// Token: 0x06005906 RID: 22790 RVA: 0x0010E994 File Offset: 0x0010CD94
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x040023B7 RID: 9143
		public const uint MsgID = 503904U;

		// Token: 0x040023B8 RID: 9144
		public uint Sequence;

		// Token: 0x040023B9 RID: 9145
		public uint result;

		// Token: 0x040023BA RID: 9146
		public uint boothNum;
	}
}
