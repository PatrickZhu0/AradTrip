using System;

namespace Protocol
{
	// Token: 0x020006CA RID: 1738
	[Protocol]
	public class WorldAuctionRecommendPriceRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060058C9 RID: 22729 RVA: 0x0010E4C4 File Offset: 0x0010C8C4
		public uint GetMsgID()
		{
			return 603919U;
		}

		// Token: 0x060058CA RID: 22730 RVA: 0x0010E4CB File Offset: 0x0010C8CB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060058CB RID: 22731 RVA: 0x0010E4D3 File Offset: 0x0010C8D3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060058CC RID: 22732 RVA: 0x0010E4DC File Offset: 0x0010C8DC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemTypeId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.price);
		}

		// Token: 0x060058CD RID: 22733 RVA: 0x0010E508 File Offset: 0x0010C908
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemTypeId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.price);
		}

		// Token: 0x060058CE RID: 22734 RVA: 0x0010E534 File Offset: 0x0010C934
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemTypeId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.price);
		}

		// Token: 0x060058CF RID: 22735 RVA: 0x0010E560 File Offset: 0x0010C960
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemTypeId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.price);
		}

		// Token: 0x060058D0 RID: 22736 RVA: 0x0010E58C File Offset: 0x0010C98C
		public int getLen()
		{
			int num = 0;
			num++;
			num += 4;
			return num + 4;
		}

		// Token: 0x040023A4 RID: 9124
		public const uint MsgID = 603919U;

		// Token: 0x040023A5 RID: 9125
		public uint Sequence;

		// Token: 0x040023A6 RID: 9126
		public byte type;

		// Token: 0x040023A7 RID: 9127
		public uint itemTypeId;

		// Token: 0x040023A8 RID: 9128
		public uint price;
	}
}
