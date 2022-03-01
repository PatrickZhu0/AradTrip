using System;

namespace Protocol
{
	// Token: 0x020007FF RID: 2047
	[Protocol]
	public class UnionGoldConsignmentCancelOrderReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600623E RID: 25150 RVA: 0x00125BB2 File Offset: 0x00123FB2
		public uint GetMsgID()
		{
			return 1210107U;
		}

		// Token: 0x0600623F RID: 25151 RVA: 0x00125BB9 File Offset: 0x00123FB9
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006240 RID: 25152 RVA: 0x00125BC1 File Offset: 0x00123FC1
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006241 RID: 25153 RVA: 0x00125BCA File Offset: 0x00123FCA
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.orderType);
			BaseDLL.encode_uint64(buffer, ref pos_, this.orderId);
		}

		// Token: 0x06006242 RID: 25154 RVA: 0x00125BE8 File Offset: 0x00123FE8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.orderType);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.orderId);
		}

		// Token: 0x06006243 RID: 25155 RVA: 0x00125C06 File Offset: 0x00124006
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.orderType);
			BaseDLL.encode_uint64(buffer, ref pos_, this.orderId);
		}

		// Token: 0x06006244 RID: 25156 RVA: 0x00125C24 File Offset: 0x00124024
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.orderType);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.orderId);
		}

		// Token: 0x06006245 RID: 25157 RVA: 0x00125C44 File Offset: 0x00124044
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 8;
		}

		// Token: 0x04002B61 RID: 11105
		public const uint MsgID = 1210107U;

		// Token: 0x04002B62 RID: 11106
		public uint Sequence;

		// Token: 0x04002B63 RID: 11107
		public uint orderType;

		// Token: 0x04002B64 RID: 11108
		public ulong orderId;
	}
}
