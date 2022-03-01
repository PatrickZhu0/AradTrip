using System;

namespace Protocol
{
	// Token: 0x020006C8 RID: 1736
	[Protocol]
	public class WorldAuctionQueryItemRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x060058B7 RID: 22711 RVA: 0x0010E3DC File Offset: 0x0010C7DC
		public uint GetMsgID()
		{
			return 603917U;
		}

		// Token: 0x060058B8 RID: 22712 RVA: 0x0010E3E3 File Offset: 0x0010C7E3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060058B9 RID: 22713 RVA: 0x0010E3EB File Offset: 0x0010C7EB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060058BA RID: 22714 RVA: 0x0010E3F4 File Offset: 0x0010C7F4
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060058BB RID: 22715 RVA: 0x0010E3F6 File Offset: 0x0010C7F6
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060058BC RID: 22716 RVA: 0x0010E3F8 File Offset: 0x0010C7F8
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060058BD RID: 22717 RVA: 0x0010E3FA File Offset: 0x0010C7FA
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060058BE RID: 22718 RVA: 0x0010E3FC File Offset: 0x0010C7FC
		public int getLen()
		{
			return 0;
		}

		// Token: 0x0400239E RID: 9118
		public const uint MsgID = 603917U;

		// Token: 0x0400239F RID: 9119
		public uint Sequence;
	}
}
