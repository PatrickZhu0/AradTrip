using System;

namespace Protocol
{
	// Token: 0x020007FD RID: 2045
	public class GoldConsignmentOrder : IProtocolStream
	{
		// Token: 0x0600622F RID: 25135 RVA: 0x001256CC File Offset: 0x00123ACC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.orderId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.unitPrice);
			BaseDLL.encode_uint32(buffer, ref pos_, this.tradeNum);
			BaseDLL.encode_uint64(buffer, ref pos_, this.sumbitTime);
			BaseDLL.encode_uint64(buffer, ref pos_, this.expireTime);
		}

		// Token: 0x06006230 RID: 25136 RVA: 0x00125720 File Offset: 0x00123B20
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.orderId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.unitPrice);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.tradeNum);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.sumbitTime);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.expireTime);
		}

		// Token: 0x06006231 RID: 25137 RVA: 0x00125774 File Offset: 0x00123B74
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.orderId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.unitPrice);
			BaseDLL.encode_uint32(buffer, ref pos_, this.tradeNum);
			BaseDLL.encode_uint64(buffer, ref pos_, this.sumbitTime);
			BaseDLL.encode_uint64(buffer, ref pos_, this.expireTime);
		}

		// Token: 0x06006232 RID: 25138 RVA: 0x001257C8 File Offset: 0x00123BC8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.orderId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.unitPrice);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.tradeNum);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.sumbitTime);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.expireTime);
		}

		// Token: 0x06006233 RID: 25139 RVA: 0x0012581C File Offset: 0x00123C1C
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			num += 4;
			num += 8;
			return num + 8;
		}

		// Token: 0x04002B56 RID: 11094
		public ulong orderId;

		// Token: 0x04002B57 RID: 11095
		public uint unitPrice;

		// Token: 0x04002B58 RID: 11096
		public uint tradeNum;

		// Token: 0x04002B59 RID: 11097
		public ulong sumbitTime;

		// Token: 0x04002B5A RID: 11098
		public ulong expireTime;
	}
}
