using System;

namespace Protocol
{
	// Token: 0x02000800 RID: 2048
	[Protocol]
	public class UnionGoldConsignmentCancelOrderRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006247 RID: 25159 RVA: 0x00125C64 File Offset: 0x00124064
		public uint GetMsgID()
		{
			return 1210108U;
		}

		// Token: 0x06006248 RID: 25160 RVA: 0x00125C6B File Offset: 0x0012406B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006249 RID: 25161 RVA: 0x00125C73 File Offset: 0x00124073
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600624A RID: 25162 RVA: 0x00125C7C File Offset: 0x0012407C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint64(buffer, ref pos_, this.orderId);
		}

		// Token: 0x0600624B RID: 25163 RVA: 0x00125C9A File Offset: 0x0012409A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.orderId);
		}

		// Token: 0x0600624C RID: 25164 RVA: 0x00125CB8 File Offset: 0x001240B8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint64(buffer, ref pos_, this.orderId);
		}

		// Token: 0x0600624D RID: 25165 RVA: 0x00125CD6 File Offset: 0x001240D6
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.orderId);
		}

		// Token: 0x0600624E RID: 25166 RVA: 0x00125CF4 File Offset: 0x001240F4
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 8;
		}

		// Token: 0x04002B65 RID: 11109
		public const uint MsgID = 1210108U;

		// Token: 0x04002B66 RID: 11110
		public uint Sequence;

		// Token: 0x04002B67 RID: 11111
		public uint retCode;

		// Token: 0x04002B68 RID: 11112
		public ulong orderId;
	}
}
