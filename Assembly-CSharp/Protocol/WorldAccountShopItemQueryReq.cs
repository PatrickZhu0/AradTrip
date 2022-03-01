using System;

namespace Protocol
{
	// Token: 0x02000B51 RID: 2897
	[Protocol]
	public class WorldAccountShopItemQueryReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007B97 RID: 31639 RVA: 0x00161C6E File Offset: 0x0016006E
		public uint GetMsgID()
		{
			return 608801U;
		}

		// Token: 0x06007B98 RID: 31640 RVA: 0x00161C75 File Offset: 0x00160075
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007B99 RID: 31641 RVA: 0x00161C7D File Offset: 0x0016007D
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007B9A RID: 31642 RVA: 0x00161C86 File Offset: 0x00160086
		public void encode(byte[] buffer, ref int pos_)
		{
			this.queryIndex.encode(buffer, ref pos_);
		}

		// Token: 0x06007B9B RID: 31643 RVA: 0x00161C95 File Offset: 0x00160095
		public void decode(byte[] buffer, ref int pos_)
		{
			this.queryIndex.decode(buffer, ref pos_);
		}

		// Token: 0x06007B9C RID: 31644 RVA: 0x00161CA4 File Offset: 0x001600A4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.queryIndex.encode(buffer, ref pos_);
		}

		// Token: 0x06007B9D RID: 31645 RVA: 0x00161CB3 File Offset: 0x001600B3
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.queryIndex.decode(buffer, ref pos_);
		}

		// Token: 0x06007B9E RID: 31646 RVA: 0x00161CC4 File Offset: 0x001600C4
		public int getLen()
		{
			int num = 0;
			return num + this.queryIndex.getLen();
		}

		// Token: 0x04003A8F RID: 14991
		public const uint MsgID = 608801U;

		// Token: 0x04003A90 RID: 14992
		public uint Sequence;

		// Token: 0x04003A91 RID: 14993
		public AccountShopQueryIndex queryIndex = new AccountShopQueryIndex();
	}
}
