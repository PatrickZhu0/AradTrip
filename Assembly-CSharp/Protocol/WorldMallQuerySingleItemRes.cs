using System;

namespace Protocol
{
	// Token: 0x0200091B RID: 2331
	[Protocol]
	public class WorldMallQuerySingleItemRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006A60 RID: 27232 RVA: 0x001387A3 File Offset: 0x00136BA3
		public uint GetMsgID()
		{
			return 602824U;
		}

		// Token: 0x06006A61 RID: 27233 RVA: 0x001387AA File Offset: 0x00136BAA
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006A62 RID: 27234 RVA: 0x001387B2 File Offset: 0x00136BB2
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006A63 RID: 27235 RVA: 0x001387BB File Offset: 0x00136BBB
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			this.mallItemInfo.encode(buffer, ref pos_);
		}

		// Token: 0x06006A64 RID: 27236 RVA: 0x001387D8 File Offset: 0x00136BD8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			this.mallItemInfo.decode(buffer, ref pos_);
		}

		// Token: 0x06006A65 RID: 27237 RVA: 0x001387F5 File Offset: 0x00136BF5
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			this.mallItemInfo.encode(buffer, ref pos_);
		}

		// Token: 0x06006A66 RID: 27238 RVA: 0x00138812 File Offset: 0x00136C12
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			this.mallItemInfo.decode(buffer, ref pos_);
		}

		// Token: 0x06006A67 RID: 27239 RVA: 0x00138830 File Offset: 0x00136C30
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + this.mallItemInfo.getLen();
		}

		// Token: 0x0400303A RID: 12346
		public const uint MsgID = 602824U;

		// Token: 0x0400303B RID: 12347
		public uint Sequence;

		// Token: 0x0400303C RID: 12348
		public uint retCode;

		// Token: 0x0400303D RID: 12349
		public MallItemInfo mallItemInfo = new MallItemInfo();
	}
}
