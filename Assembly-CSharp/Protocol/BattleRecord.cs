using System;

namespace Protocol
{
	// Token: 0x02000740 RID: 1856
	public class BattleRecord : IProtocolStream
	{
		// Token: 0x06005C86 RID: 23686 RVA: 0x00117198 File Offset: 0x00115598
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.courtId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.champion);
			BaseDLL.encode_uint32(buffer, ref pos_, this.odds);
			BaseDLL.encode_uint32(buffer, ref pos_, this.maxProfit);
		}

		// Token: 0x06005C87 RID: 23687 RVA: 0x001171D2 File Offset: 0x001155D2
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.courtId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.champion);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.odds);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.maxProfit);
		}

		// Token: 0x06005C88 RID: 23688 RVA: 0x0011720C File Offset: 0x0011560C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.courtId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.champion);
			BaseDLL.encode_uint32(buffer, ref pos_, this.odds);
			BaseDLL.encode_uint32(buffer, ref pos_, this.maxProfit);
		}

		// Token: 0x06005C89 RID: 23689 RVA: 0x00117246 File Offset: 0x00115646
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.courtId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.champion);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.odds);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.maxProfit);
		}

		// Token: 0x06005C8A RID: 23690 RVA: 0x00117280 File Offset: 0x00115680
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x040025C6 RID: 9670
		public uint courtId;

		// Token: 0x040025C7 RID: 9671
		public uint champion;

		// Token: 0x040025C8 RID: 9672
		public uint odds;

		// Token: 0x040025C9 RID: 9673
		public uint maxProfit;
	}
}
