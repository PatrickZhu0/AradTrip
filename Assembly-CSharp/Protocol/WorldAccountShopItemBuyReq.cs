using System;

namespace Protocol
{
	// Token: 0x02000B53 RID: 2899
	[Protocol]
	public class WorldAccountShopItemBuyReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007BA9 RID: 31657 RVA: 0x00161F6A File Offset: 0x0016036A
		public uint GetMsgID()
		{
			return 608803U;
		}

		// Token: 0x06007BAA RID: 31658 RVA: 0x00161F71 File Offset: 0x00160371
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007BAB RID: 31659 RVA: 0x00161F79 File Offset: 0x00160379
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007BAC RID: 31660 RVA: 0x00161F82 File Offset: 0x00160382
		public void encode(byte[] buffer, ref int pos_)
		{
			this.queryIndex.encode(buffer, ref pos_);
			BaseDLL.encode_uint32(buffer, ref pos_, this.buyShopItemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.buyShopItemNum);
		}

		// Token: 0x06007BAD RID: 31661 RVA: 0x00161FAD File Offset: 0x001603AD
		public void decode(byte[] buffer, ref int pos_)
		{
			this.queryIndex.decode(buffer, ref pos_);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buyShopItemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buyShopItemNum);
		}

		// Token: 0x06007BAE RID: 31662 RVA: 0x00161FD8 File Offset: 0x001603D8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.queryIndex.encode(buffer, ref pos_);
			BaseDLL.encode_uint32(buffer, ref pos_, this.buyShopItemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.buyShopItemNum);
		}

		// Token: 0x06007BAF RID: 31663 RVA: 0x00162003 File Offset: 0x00160403
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.queryIndex.decode(buffer, ref pos_);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buyShopItemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buyShopItemNum);
		}

		// Token: 0x06007BB0 RID: 31664 RVA: 0x00162030 File Offset: 0x00160430
		public int getLen()
		{
			int num = 0;
			num += this.queryIndex.getLen();
			num += 4;
			return num + 4;
		}

		// Token: 0x04003A98 RID: 15000
		public const uint MsgID = 608803U;

		// Token: 0x04003A99 RID: 15001
		public uint Sequence;

		// Token: 0x04003A9A RID: 15002
		public AccountShopQueryIndex queryIndex = new AccountShopQueryIndex();

		// Token: 0x04003A9B RID: 15003
		public uint buyShopItemId;

		// Token: 0x04003A9C RID: 15004
		public uint buyShopItemNum;
	}
}
