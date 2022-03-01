using System;

namespace Protocol
{
	// Token: 0x02000AAF RID: 2735
	public class ReplayRaceResult : IProtocolStream
	{
		// Token: 0x060076E4 RID: 30436 RVA: 0x00157C19 File Offset: 0x00156019
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.pos);
			BaseDLL.encode_int8(buffer, ref pos_, this.result);
		}

		// Token: 0x060076E5 RID: 30437 RVA: 0x00157C37 File Offset: 0x00156037
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.pos);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060076E6 RID: 30438 RVA: 0x00157C55 File Offset: 0x00156055
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.pos);
			BaseDLL.encode_int8(buffer, ref pos_, this.result);
		}

		// Token: 0x060076E7 RID: 30439 RVA: 0x00157C73 File Offset: 0x00156073
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.pos);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060076E8 RID: 30440 RVA: 0x00157C94 File Offset: 0x00156094
		public int getLen()
		{
			int num = 0;
			num++;
			return num + 1;
		}

		// Token: 0x040037AA RID: 14250
		public byte pos;

		// Token: 0x040037AB RID: 14251
		public byte result;
	}
}
