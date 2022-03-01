using System;

namespace Protocol
{
	// Token: 0x020007F5 RID: 2037
	public class OrderGradeInfo : IProtocolStream
	{
		// Token: 0x060061ED RID: 25069 RVA: 0x00124868 File Offset: 0x00122C68
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.unitPrice);
			BaseDLL.encode_uint64(buffer, ref pos_, this.tradeNum);
		}

		// Token: 0x060061EE RID: 25070 RVA: 0x00124886 File Offset: 0x00122C86
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.unitPrice);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.tradeNum);
		}

		// Token: 0x060061EF RID: 25071 RVA: 0x001248A4 File Offset: 0x00122CA4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.unitPrice);
			BaseDLL.encode_uint64(buffer, ref pos_, this.tradeNum);
		}

		// Token: 0x060061F0 RID: 25072 RVA: 0x001248C2 File Offset: 0x00122CC2
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.unitPrice);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.tradeNum);
		}

		// Token: 0x060061F1 RID: 25073 RVA: 0x001248E0 File Offset: 0x00122CE0
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 8;
		}

		// Token: 0x04002B29 RID: 11049
		public uint unitPrice;

		// Token: 0x04002B2A RID: 11050
		public ulong tradeNum;
	}
}
