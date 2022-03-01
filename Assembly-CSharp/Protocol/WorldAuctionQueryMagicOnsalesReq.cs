using System;

namespace Protocol
{
	// Token: 0x020006DF RID: 1759
	[Protocol]
	public class WorldAuctionQueryMagicOnsalesReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005983 RID: 22915 RVA: 0x00110195 File Offset: 0x0010E595
		public uint GetMsgID()
		{
			return 603933U;
		}

		// Token: 0x06005984 RID: 22916 RVA: 0x0011019C File Offset: 0x0010E59C
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005985 RID: 22917 RVA: 0x001101A4 File Offset: 0x0010E5A4
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005986 RID: 22918 RVA: 0x001101AD File Offset: 0x0010E5AD
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemTypeId);
		}

		// Token: 0x06005987 RID: 22919 RVA: 0x001101BD File Offset: 0x0010E5BD
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemTypeId);
		}

		// Token: 0x06005988 RID: 22920 RVA: 0x001101CD File Offset: 0x0010E5CD
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemTypeId);
		}

		// Token: 0x06005989 RID: 22921 RVA: 0x001101DD File Offset: 0x0010E5DD
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemTypeId);
		}

		// Token: 0x0600598A RID: 22922 RVA: 0x001101F0 File Offset: 0x0010E5F0
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400240E RID: 9230
		public const uint MsgID = 603933U;

		// Token: 0x0400240F RID: 9231
		public uint Sequence;

		// Token: 0x04002410 RID: 9232
		public uint itemTypeId;
	}
}
