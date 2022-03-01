using System;

namespace Protocol
{
	// Token: 0x02000B54 RID: 2900
	[Protocol]
	public class WorldAccountShopItemBuyRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007BB2 RID: 31666 RVA: 0x00162069 File Offset: 0x00160469
		public uint GetMsgID()
		{
			return 608804U;
		}

		// Token: 0x06007BB3 RID: 31667 RVA: 0x00162070 File Offset: 0x00160470
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007BB4 RID: 31668 RVA: 0x00162078 File Offset: 0x00160478
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007BB5 RID: 31669 RVA: 0x00162084 File Offset: 0x00160484
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.resCode);
			this.queryIndex.encode(buffer, ref pos_);
			BaseDLL.encode_uint32(buffer, ref pos_, this.buyShopItemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.buyShopItemNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.accountRestBuyNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.roleRestBuyNum);
		}

		// Token: 0x06007BB6 RID: 31670 RVA: 0x001620E4 File Offset: 0x001604E4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.resCode);
			this.queryIndex.decode(buffer, ref pos_);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buyShopItemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buyShopItemNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accountRestBuyNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.roleRestBuyNum);
		}

		// Token: 0x06007BB7 RID: 31671 RVA: 0x00162144 File Offset: 0x00160544
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.resCode);
			this.queryIndex.encode(buffer, ref pos_);
			BaseDLL.encode_uint32(buffer, ref pos_, this.buyShopItemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.buyShopItemNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.accountRestBuyNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.roleRestBuyNum);
		}

		// Token: 0x06007BB8 RID: 31672 RVA: 0x001621A4 File Offset: 0x001605A4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.resCode);
			this.queryIndex.decode(buffer, ref pos_);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buyShopItemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buyShopItemNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accountRestBuyNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.roleRestBuyNum);
		}

		// Token: 0x06007BB9 RID: 31673 RVA: 0x00162204 File Offset: 0x00160604
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += this.queryIndex.getLen();
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003A9D RID: 15005
		public const uint MsgID = 608804U;

		// Token: 0x04003A9E RID: 15006
		public uint Sequence;

		// Token: 0x04003A9F RID: 15007
		public uint resCode;

		// Token: 0x04003AA0 RID: 15008
		public AccountShopQueryIndex queryIndex = new AccountShopQueryIndex();

		// Token: 0x04003AA1 RID: 15009
		public uint buyShopItemId;

		// Token: 0x04003AA2 RID: 15010
		public uint buyShopItemNum;

		// Token: 0x04003AA3 RID: 15011
		public uint accountRestBuyNum;

		// Token: 0x04003AA4 RID: 15012
		public uint roleRestBuyNum;
	}
}
