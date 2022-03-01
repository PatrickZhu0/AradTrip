using System;

namespace Protocol
{
	// Token: 0x020009FC RID: 2556
	public class PkOccuRecord : IProtocolStream
	{
		// Token: 0x060071A7 RID: 29095 RVA: 0x0014A27F File Offset: 0x0014867F
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			BaseDLL.encode_uint32(buffer, ref pos_, this.winNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.loseNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalNum);
		}

		// Token: 0x060071A8 RID: 29096 RVA: 0x0014A2B9 File Offset: 0x001486B9
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.winNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.loseNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalNum);
		}

		// Token: 0x060071A9 RID: 29097 RVA: 0x0014A2F3 File Offset: 0x001486F3
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			BaseDLL.encode_uint32(buffer, ref pos_, this.winNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.loseNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalNum);
		}

		// Token: 0x060071AA RID: 29098 RVA: 0x0014A32D File Offset: 0x0014872D
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.winNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.loseNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalNum);
		}

		// Token: 0x060071AB RID: 29099 RVA: 0x0014A368 File Offset: 0x00148768
		public int getLen()
		{
			int num = 0;
			num++;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003436 RID: 13366
		public byte occu;

		// Token: 0x04003437 RID: 13367
		public uint winNum;

		// Token: 0x04003438 RID: 13368
		public uint loseNum;

		// Token: 0x04003439 RID: 13369
		public uint totalNum;
	}
}
