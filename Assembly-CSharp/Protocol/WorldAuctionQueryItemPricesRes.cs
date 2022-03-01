using System;

namespace Protocol
{
	// Token: 0x020006D2 RID: 1746
	[Protocol]
	public class WorldAuctionQueryItemPricesRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005911 RID: 22801 RVA: 0x0010EB54 File Offset: 0x0010CF54
		public uint GetMsgID()
		{
			return 603923U;
		}

		// Token: 0x06005912 RID: 22802 RVA: 0x0010EB5B File Offset: 0x0010CF5B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005913 RID: 22803 RVA: 0x0010EB63 File Offset: 0x0010CF63
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005914 RID: 22804 RVA: 0x0010EB6C File Offset: 0x0010CF6C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemTypeId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.strengthen);
			BaseDLL.encode_uint32(buffer, ref pos_, this.averagePrice);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.actionItems.Length);
			for (int i = 0; i < this.actionItems.Length; i++)
			{
				this.actionItems[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.visAverPrice);
			BaseDLL.encode_uint32(buffer, ref pos_, this.minPrice);
			BaseDLL.encode_uint32(buffer, ref pos_, this.maxPrice);
			BaseDLL.encode_uint32(buffer, ref pos_, this.recommendPrice);
		}

		// Token: 0x06005915 RID: 22805 RVA: 0x0010EC24 File Offset: 0x0010D024
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemTypeId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.strengthen);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.averagePrice);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.actionItems = new AuctionBaseInfo[(int)num];
			for (int i = 0; i < this.actionItems.Length; i++)
			{
				this.actionItems[i] = new AuctionBaseInfo();
				this.actionItems[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.visAverPrice);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.minPrice);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.maxPrice);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.recommendPrice);
		}

		// Token: 0x06005916 RID: 22806 RVA: 0x0010ECF0 File Offset: 0x0010D0F0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemTypeId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.strengthen);
			BaseDLL.encode_uint32(buffer, ref pos_, this.averagePrice);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.actionItems.Length);
			for (int i = 0; i < this.actionItems.Length; i++)
			{
				this.actionItems[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.visAverPrice);
			BaseDLL.encode_uint32(buffer, ref pos_, this.minPrice);
			BaseDLL.encode_uint32(buffer, ref pos_, this.maxPrice);
			BaseDLL.encode_uint32(buffer, ref pos_, this.recommendPrice);
		}

		// Token: 0x06005917 RID: 22807 RVA: 0x0010EDA8 File Offset: 0x0010D1A8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemTypeId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.strengthen);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.averagePrice);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.actionItems = new AuctionBaseInfo[(int)num];
			for (int i = 0; i < this.actionItems.Length; i++)
			{
				this.actionItems[i] = new AuctionBaseInfo();
				this.actionItems[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.visAverPrice);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.minPrice);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.maxPrice);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.recommendPrice);
		}

		// Token: 0x06005918 RID: 22808 RVA: 0x0010EE74 File Offset: 0x0010D274
		public int getLen()
		{
			int num = 0;
			num++;
			num += 4;
			num += 4;
			num += 4;
			num += 2;
			for (int i = 0; i < this.actionItems.Length; i++)
			{
				num += this.actionItems[i].getLen();
			}
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x040023C2 RID: 9154
		public const uint MsgID = 603923U;

		// Token: 0x040023C3 RID: 9155
		public uint Sequence;

		// Token: 0x040023C4 RID: 9156
		public byte type;

		// Token: 0x040023C5 RID: 9157
		public uint itemTypeId;

		// Token: 0x040023C6 RID: 9158
		public uint strengthen;

		// Token: 0x040023C7 RID: 9159
		public uint averagePrice;

		// Token: 0x040023C8 RID: 9160
		public AuctionBaseInfo[] actionItems = new AuctionBaseInfo[0];

		// Token: 0x040023C9 RID: 9161
		public uint visAverPrice;

		// Token: 0x040023CA RID: 9162
		public uint minPrice;

		// Token: 0x040023CB RID: 9163
		public uint maxPrice;

		// Token: 0x040023CC RID: 9164
		public uint recommendPrice;
	}
}
