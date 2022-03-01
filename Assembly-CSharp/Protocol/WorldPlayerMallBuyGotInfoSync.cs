using System;

namespace Protocol
{
	// Token: 0x0200091C RID: 2332
	[Protocol]
	public class WorldPlayerMallBuyGotInfoSync : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006A69 RID: 27241 RVA: 0x00138865 File Offset: 0x00136C65
		public uint GetMsgID()
		{
			return 602825U;
		}

		// Token: 0x06006A6A RID: 27242 RVA: 0x0013886C File Offset: 0x00136C6C
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006A6B RID: 27243 RVA: 0x00138874 File Offset: 0x00136C74
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006A6C RID: 27244 RVA: 0x0013887D File Offset: 0x00136C7D
		public void encode(byte[] buffer, ref int pos_)
		{
			this.mallBuyGotInfo.encode(buffer, ref pos_);
		}

		// Token: 0x06006A6D RID: 27245 RVA: 0x0013888C File Offset: 0x00136C8C
		public void decode(byte[] buffer, ref int pos_)
		{
			this.mallBuyGotInfo.decode(buffer, ref pos_);
		}

		// Token: 0x06006A6E RID: 27246 RVA: 0x0013889B File Offset: 0x00136C9B
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.mallBuyGotInfo.encode(buffer, ref pos_);
		}

		// Token: 0x06006A6F RID: 27247 RVA: 0x001388AA File Offset: 0x00136CAA
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.mallBuyGotInfo.decode(buffer, ref pos_);
		}

		// Token: 0x06006A70 RID: 27248 RVA: 0x001388BC File Offset: 0x00136CBC
		public int getLen()
		{
			int num = 0;
			return num + this.mallBuyGotInfo.getLen();
		}

		// Token: 0x0400303E RID: 12350
		public const uint MsgID = 602825U;

		// Token: 0x0400303F RID: 12351
		public uint Sequence;

		// Token: 0x04003040 RID: 12352
		public MallBuyGotInfo mallBuyGotInfo = new MallBuyGotInfo();
	}
}
