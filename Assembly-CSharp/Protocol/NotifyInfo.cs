using System;

namespace Protocol
{
	// Token: 0x02000682 RID: 1666
	public class NotifyInfo : IProtocolStream
	{
		// Token: 0x060056BD RID: 22205 RVA: 0x00109684 File Offset: 0x00107A84
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.param);
		}

		// Token: 0x060056BE RID: 22206 RVA: 0x001096A2 File Offset: 0x00107AA2
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.param);
		}

		// Token: 0x060056BF RID: 22207 RVA: 0x001096C0 File Offset: 0x00107AC0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.param);
		}

		// Token: 0x060056C0 RID: 22208 RVA: 0x001096DE File Offset: 0x00107ADE
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.param);
		}

		// Token: 0x060056C1 RID: 22209 RVA: 0x001096FC File Offset: 0x00107AFC
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 8;
		}

		// Token: 0x04002275 RID: 8821
		public uint type;

		// Token: 0x04002276 RID: 8822
		public ulong param;
	}
}
