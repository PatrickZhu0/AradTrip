using System;

namespace Protocol
{
	// Token: 0x020006CF RID: 1743
	[Protocol]
	public class SceneAuctionBuyBoothReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060058F6 RID: 22774 RVA: 0x0010E8CC File Offset: 0x0010CCCC
		public uint GetMsgID()
		{
			return 503903U;
		}

		// Token: 0x060058F7 RID: 22775 RVA: 0x0010E8D3 File Offset: 0x0010CCD3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060058F8 RID: 22776 RVA: 0x0010E8DB File Offset: 0x0010CCDB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060058F9 RID: 22777 RVA: 0x0010E8E4 File Offset: 0x0010CCE4
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060058FA RID: 22778 RVA: 0x0010E8E6 File Offset: 0x0010CCE6
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060058FB RID: 22779 RVA: 0x0010E8E8 File Offset: 0x0010CCE8
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060058FC RID: 22780 RVA: 0x0010E8EA File Offset: 0x0010CCEA
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060058FD RID: 22781 RVA: 0x0010E8EC File Offset: 0x0010CCEC
		public int getLen()
		{
			return 0;
		}

		// Token: 0x040023B5 RID: 9141
		public const uint MsgID = 503903U;

		// Token: 0x040023B6 RID: 9142
		public uint Sequence;
	}
}
