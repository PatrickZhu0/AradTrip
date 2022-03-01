using System;

namespace Protocol
{
	// Token: 0x020007F7 RID: 2039
	[Protocol]
	public class UnionGoldConsignmentSubmitOrderReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060061FC RID: 25084 RVA: 0x00124E4A File Offset: 0x0012324A
		public uint GetMsgID()
		{
			return 510101U;
		}

		// Token: 0x060061FD RID: 25085 RVA: 0x00124E51 File Offset: 0x00123251
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060061FE RID: 25086 RVA: 0x00124E59 File Offset: 0x00123259
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060061FF RID: 25087 RVA: 0x00124E64 File Offset: 0x00123264
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.tradeType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.orderType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.unitPrice);
			BaseDLL.encode_uint32(buffer, ref pos_, this.tradeNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param);
		}

		// Token: 0x06006200 RID: 25088 RVA: 0x00124EB8 File Offset: 0x001232B8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.tradeType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.orderType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.unitPrice);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.tradeNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param);
		}

		// Token: 0x06006201 RID: 25089 RVA: 0x00124F0C File Offset: 0x0012330C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.tradeType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.orderType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.unitPrice);
			BaseDLL.encode_uint32(buffer, ref pos_, this.tradeNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param);
		}

		// Token: 0x06006202 RID: 25090 RVA: 0x00124F60 File Offset: 0x00123360
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.tradeType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.orderType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.unitPrice);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.tradeNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param);
		}

		// Token: 0x06006203 RID: 25091 RVA: 0x00124FB4 File Offset: 0x001233B4
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002B39 RID: 11065
		public const uint MsgID = 510101U;

		// Token: 0x04002B3A RID: 11066
		public uint Sequence;

		// Token: 0x04002B3B RID: 11067
		public uint tradeType;

		// Token: 0x04002B3C RID: 11068
		public uint orderType;

		// Token: 0x04002B3D RID: 11069
		public uint unitPrice;

		// Token: 0x04002B3E RID: 11070
		public uint tradeNum;

		// Token: 0x04002B3F RID: 11071
		public uint param;
	}
}
