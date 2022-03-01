using System;

namespace Protocol
{
	// Token: 0x020006DD RID: 1757
	[Protocol]
	public class WorldAuctionQueryItemPriceListReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005971 RID: 22897 RVA: 0x0010FD5E File Offset: 0x0010E15E
		public uint GetMsgID()
		{
			return 603931U;
		}

		// Token: 0x06005972 RID: 22898 RVA: 0x0010FD65 File Offset: 0x0010E165
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005973 RID: 22899 RVA: 0x0010FD6D File Offset: 0x0010E16D
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005974 RID: 22900 RVA: 0x0010FD78 File Offset: 0x0010E178
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_int8(buffer, ref pos_, this.auctionState);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemTypeId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.strengthen);
			BaseDLL.encode_int8(buffer, ref pos_, this.enhanceType);
		}

		// Token: 0x06005975 RID: 22901 RVA: 0x0010FDCC File Offset: 0x0010E1CC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.auctionState);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemTypeId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.strengthen);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.enhanceType);
		}

		// Token: 0x06005976 RID: 22902 RVA: 0x0010FE20 File Offset: 0x0010E220
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_int8(buffer, ref pos_, this.auctionState);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemTypeId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.strengthen);
			BaseDLL.encode_int8(buffer, ref pos_, this.enhanceType);
		}

		// Token: 0x06005977 RID: 22903 RVA: 0x0010FE74 File Offset: 0x0010E274
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.auctionState);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemTypeId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.strengthen);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.enhanceType);
		}

		// Token: 0x06005978 RID: 22904 RVA: 0x0010FEC8 File Offset: 0x0010E2C8
		public int getLen()
		{
			int num = 0;
			num++;
			num++;
			num += 4;
			num += 4;
			return num + 1;
		}

		// Token: 0x04002400 RID: 9216
		public const uint MsgID = 603931U;

		// Token: 0x04002401 RID: 9217
		public uint Sequence;

		// Token: 0x04002402 RID: 9218
		public byte type;

		// Token: 0x04002403 RID: 9219
		public byte auctionState;

		// Token: 0x04002404 RID: 9220
		public uint itemTypeId;

		// Token: 0x04002405 RID: 9221
		public uint strengthen;

		// Token: 0x04002406 RID: 9222
		public byte enhanceType;
	}
}
