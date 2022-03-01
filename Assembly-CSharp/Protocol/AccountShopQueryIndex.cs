using System;

namespace Protocol
{
	// Token: 0x02000B4F RID: 2895
	public class AccountShopQueryIndex : IProtocolStream
	{
		// Token: 0x06007B8B RID: 31627 RVA: 0x001613CD File Offset: 0x0015F7CD
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.shopId);
			BaseDLL.encode_int8(buffer, ref pos_, this.tabType);
			BaseDLL.encode_int8(buffer, ref pos_, this.jobType);
		}

		// Token: 0x06007B8C RID: 31628 RVA: 0x001613F9 File Offset: 0x0015F7F9
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.shopId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.tabType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.jobType);
		}

		// Token: 0x06007B8D RID: 31629 RVA: 0x00161425 File Offset: 0x0015F825
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.shopId);
			BaseDLL.encode_int8(buffer, ref pos_, this.tabType);
			BaseDLL.encode_int8(buffer, ref pos_, this.jobType);
		}

		// Token: 0x06007B8E RID: 31630 RVA: 0x00161451 File Offset: 0x0015F851
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.shopId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.tabType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.jobType);
		}

		// Token: 0x06007B8F RID: 31631 RVA: 0x00161480 File Offset: 0x0015F880
		public int getLen()
		{
			int num = 0;
			num += 4;
			num++;
			return num + 1;
		}

		// Token: 0x04003A79 RID: 14969
		public uint shopId;

		// Token: 0x04003A7A RID: 14970
		public byte tabType;

		// Token: 0x04003A7B RID: 14971
		public byte jobType;
	}
}
