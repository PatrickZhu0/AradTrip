using System;

namespace Protocol
{
	// Token: 0x020007FA RID: 2042
	public class GoldConsignmentTradeRecord : IProtocolStream
	{
		// Token: 0x06006217 RID: 25111 RVA: 0x00125224 File Offset: 0x00123624
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.orderType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.unitPrice);
			BaseDLL.encode_uint32(buffer, ref pos_, this.tradeNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param);
			BaseDLL.encode_uint64(buffer, ref pos_, this.tradeTime);
		}

		// Token: 0x06006218 RID: 25112 RVA: 0x00125278 File Offset: 0x00123678
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.orderType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.unitPrice);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.tradeNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.tradeTime);
		}

		// Token: 0x06006219 RID: 25113 RVA: 0x001252CC File Offset: 0x001236CC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.orderType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.unitPrice);
			BaseDLL.encode_uint32(buffer, ref pos_, this.tradeNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param);
			BaseDLL.encode_uint64(buffer, ref pos_, this.tradeTime);
		}

		// Token: 0x0600621A RID: 25114 RVA: 0x00125320 File Offset: 0x00123720
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.orderType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.unitPrice);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.tradeNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.tradeTime);
		}

		// Token: 0x0600621B RID: 25115 RVA: 0x00125374 File Offset: 0x00123774
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			return num + 8;
		}

		// Token: 0x04002B4B RID: 11083
		public uint orderType;

		// Token: 0x04002B4C RID: 11084
		public uint unitPrice;

		// Token: 0x04002B4D RID: 11085
		public uint tradeNum;

		// Token: 0x04002B4E RID: 11086
		public uint param;

		// Token: 0x04002B4F RID: 11087
		public ulong tradeTime;
	}
}
