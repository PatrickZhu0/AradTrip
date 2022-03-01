using System;

namespace Protocol
{
	// Token: 0x02000730 RID: 1840
	public class ShooterInfo : IProtocolStream
	{
		// Token: 0x06005C02 RID: 23554 RVA: 0x0011601C File Offset: 0x0011441C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dataid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.status);
			BaseDLL.encode_uint32(buffer, ref pos_, this.odds);
			BaseDLL.encode_uint32(buffer, ref pos_, this.winRate);
			BaseDLL.encode_uint32(buffer, ref pos_, this.champion);
		}

		// Token: 0x06005C03 RID: 23555 RVA: 0x00116080 File Offset: 0x00114480
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dataid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.status);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.odds);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.winRate);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.champion);
		}

		// Token: 0x06005C04 RID: 23556 RVA: 0x001160E4 File Offset: 0x001144E4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dataid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.status);
			BaseDLL.encode_uint32(buffer, ref pos_, this.odds);
			BaseDLL.encode_uint32(buffer, ref pos_, this.winRate);
			BaseDLL.encode_uint32(buffer, ref pos_, this.champion);
		}

		// Token: 0x06005C05 RID: 23557 RVA: 0x00116148 File Offset: 0x00114548
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dataid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.status);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.odds);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.winRate);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.champion);
		}

		// Token: 0x06005C06 RID: 23558 RVA: 0x001161AC File Offset: 0x001145AC
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x0400258C RID: 9612
		public uint id;

		// Token: 0x0400258D RID: 9613
		public uint dataid;

		// Token: 0x0400258E RID: 9614
		public uint status;

		// Token: 0x0400258F RID: 9615
		public uint odds;

		// Token: 0x04002590 RID: 9616
		public uint winRate;

		// Token: 0x04002591 RID: 9617
		public uint champion;
	}
}
