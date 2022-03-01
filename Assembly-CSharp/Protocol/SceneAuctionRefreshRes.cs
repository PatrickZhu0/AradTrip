using System;

namespace Protocol
{
	// Token: 0x020006CE RID: 1742
	[Protocol]
	public class SceneAuctionRefreshRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060058ED RID: 22765 RVA: 0x0010E858 File Offset: 0x0010CC58
		public uint GetMsgID()
		{
			return 503902U;
		}

		// Token: 0x060058EE RID: 22766 RVA: 0x0010E85F File Offset: 0x0010CC5F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060058EF RID: 22767 RVA: 0x0010E867 File Offset: 0x0010CC67
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060058F0 RID: 22768 RVA: 0x0010E870 File Offset: 0x0010CC70
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060058F1 RID: 22769 RVA: 0x0010E880 File Offset: 0x0010CC80
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060058F2 RID: 22770 RVA: 0x0010E890 File Offset: 0x0010CC90
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060058F3 RID: 22771 RVA: 0x0010E8A0 File Offset: 0x0010CCA0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060058F4 RID: 22772 RVA: 0x0010E8B0 File Offset: 0x0010CCB0
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040023B2 RID: 9138
		public const uint MsgID = 503902U;

		// Token: 0x040023B3 RID: 9139
		public uint Sequence;

		// Token: 0x040023B4 RID: 9140
		public uint result;
	}
}
