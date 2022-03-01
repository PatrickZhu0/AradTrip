using System;

namespace Protocol
{
	// Token: 0x020006C9 RID: 1737
	[Protocol]
	public class WorldAuctionRecommendPriceReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060058C0 RID: 22720 RVA: 0x0010E414 File Offset: 0x0010C814
		public uint GetMsgID()
		{
			return 603918U;
		}

		// Token: 0x060058C1 RID: 22721 RVA: 0x0010E41B File Offset: 0x0010C81B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060058C2 RID: 22722 RVA: 0x0010E423 File Offset: 0x0010C823
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060058C3 RID: 22723 RVA: 0x0010E42C File Offset: 0x0010C82C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemTypeId);
		}

		// Token: 0x060058C4 RID: 22724 RVA: 0x0010E44A File Offset: 0x0010C84A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemTypeId);
		}

		// Token: 0x060058C5 RID: 22725 RVA: 0x0010E468 File Offset: 0x0010C868
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemTypeId);
		}

		// Token: 0x060058C6 RID: 22726 RVA: 0x0010E486 File Offset: 0x0010C886
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemTypeId);
		}

		// Token: 0x060058C7 RID: 22727 RVA: 0x0010E4A4 File Offset: 0x0010C8A4
		public int getLen()
		{
			int num = 0;
			num++;
			return num + 4;
		}

		// Token: 0x040023A0 RID: 9120
		public const uint MsgID = 603918U;

		// Token: 0x040023A1 RID: 9121
		public uint Sequence;

		// Token: 0x040023A2 RID: 9122
		public byte type;

		// Token: 0x040023A3 RID: 9123
		public uint itemTypeId;
	}
}
