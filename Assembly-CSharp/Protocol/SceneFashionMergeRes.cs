using System;

namespace Protocol
{
	// Token: 0x02000925 RID: 2341
	[Protocol]
	public class SceneFashionMergeRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006ABA RID: 27322 RVA: 0x001390C4 File Offset: 0x001374C4
		public uint GetMsgID()
		{
			return 500953U;
		}

		// Token: 0x06006ABB RID: 27323 RVA: 0x001390CB File Offset: 0x001374CB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006ABC RID: 27324 RVA: 0x001390D3 File Offset: 0x001374D3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006ABD RID: 27325 RVA: 0x001390DC File Offset: 0x001374DC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int32(buffer, ref pos_, this.result);
			BaseDLL.encode_int8(buffer, ref pos_, this.resultType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemA);
			BaseDLL.encode_int32(buffer, ref pos_, this.numA);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemB);
			BaseDLL.encode_int32(buffer, ref pos_, this.numB);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemC);
		}

		// Token: 0x06006ABE RID: 27326 RVA: 0x0013914C File Offset: 0x0013754C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.resultType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemA);
			BaseDLL.decode_int32(buffer, ref pos_, ref this.numA);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemB);
			BaseDLL.decode_int32(buffer, ref pos_, ref this.numB);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemC);
		}

		// Token: 0x06006ABF RID: 27327 RVA: 0x001391BC File Offset: 0x001375BC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int32(buffer, ref pos_, this.result);
			BaseDLL.encode_int8(buffer, ref pos_, this.resultType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemA);
			BaseDLL.encode_int32(buffer, ref pos_, this.numA);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemB);
			BaseDLL.encode_int32(buffer, ref pos_, this.numB);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemC);
		}

		// Token: 0x06006AC0 RID: 27328 RVA: 0x0013922C File Offset: 0x0013762C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.resultType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemA);
			BaseDLL.decode_int32(buffer, ref pos_, ref this.numA);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemB);
			BaseDLL.decode_int32(buffer, ref pos_, ref this.numB);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemC);
		}

		// Token: 0x06006AC1 RID: 27329 RVA: 0x0013929C File Offset: 0x0013769C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num++;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003065 RID: 12389
		public const uint MsgID = 500953U;

		// Token: 0x04003066 RID: 12390
		public uint Sequence;

		// Token: 0x04003067 RID: 12391
		public int result;

		// Token: 0x04003068 RID: 12392
		public byte resultType;

		// Token: 0x04003069 RID: 12393
		public uint itemA;

		// Token: 0x0400306A RID: 12394
		public int numA;

		// Token: 0x0400306B RID: 12395
		public uint itemB;

		// Token: 0x0400306C RID: 12396
		public int numB;

		// Token: 0x0400306D RID: 12397
		public uint itemC;
	}
}
