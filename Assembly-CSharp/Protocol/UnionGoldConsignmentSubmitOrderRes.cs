using System;

namespace Protocol
{
	// Token: 0x020007F8 RID: 2040
	[Protocol]
	public class UnionGoldConsignmentSubmitOrderRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006205 RID: 25093 RVA: 0x00124FE0 File Offset: 0x001233E0
		public uint GetMsgID()
		{
			return 510102U;
		}

		// Token: 0x06006206 RID: 25094 RVA: 0x00124FE7 File Offset: 0x001233E7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006207 RID: 25095 RVA: 0x00124FEF File Offset: 0x001233EF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006208 RID: 25096 RVA: 0x00124FF8 File Offset: 0x001233F8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.orderType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dealNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.hangListNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.unitPrice);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param1);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param2);
		}

		// Token: 0x06006209 RID: 25097 RVA: 0x00125068 File Offset: 0x00123468
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.orderType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dealNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.hangListNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.unitPrice);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param1);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param2);
		}

		// Token: 0x0600620A RID: 25098 RVA: 0x001250D8 File Offset: 0x001234D8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.orderType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dealNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.hangListNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.unitPrice);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param1);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param2);
		}

		// Token: 0x0600620B RID: 25099 RVA: 0x00125148 File Offset: 0x00123548
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.orderType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dealNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.hangListNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.unitPrice);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param1);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param2);
		}

		// Token: 0x0600620C RID: 25100 RVA: 0x001251B8 File Offset: 0x001235B8
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002B40 RID: 11072
		public const uint MsgID = 510102U;

		// Token: 0x04002B41 RID: 11073
		public uint Sequence;

		// Token: 0x04002B42 RID: 11074
		public uint retCode;

		// Token: 0x04002B43 RID: 11075
		public uint orderType;

		// Token: 0x04002B44 RID: 11076
		public uint dealNum;

		// Token: 0x04002B45 RID: 11077
		public uint hangListNum;

		// Token: 0x04002B46 RID: 11078
		public uint unitPrice;

		// Token: 0x04002B47 RID: 11079
		public uint param1;

		// Token: 0x04002B48 RID: 11080
		public uint param2;
	}
}
