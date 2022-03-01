using System;

namespace Protocol
{
	// Token: 0x02000970 RID: 2416
	public class BlackMarketAuctionInfo : IProtocolStream
	{
		// Token: 0x06006D4B RID: 27979 RVA: 0x0013D89C File Offset: 0x0013BC9C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.back_buy_item_id);
			BaseDLL.encode_int8(buffer, ref pos_, this.back_buy_type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.price);
			BaseDLL.encode_uint32(buffer, ref pos_, this.begin_time);
			BaseDLL.encode_uint32(buffer, ref pos_, this.end_time);
			BaseDLL.encode_uint32(buffer, ref pos_, this.recommend_price);
			BaseDLL.encode_uint32(buffer, ref pos_, this.price_lower_limit);
			BaseDLL.encode_uint32(buffer, ref pos_, this.price_upper_limit);
			BaseDLL.encode_int8(buffer, ref pos_, this.state);
			BaseDLL.encode_uint64(buffer, ref pos_, this.auctioner_guid);
			byte[] str = StringHelper.StringToUTF8Bytes(this.auctioner_name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.auction_price);
		}

		// Token: 0x06006D4C RID: 27980 RVA: 0x0013D970 File Offset: 0x0013BD70
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.back_buy_item_id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.back_buy_type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.price);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.begin_time);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.end_time);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.recommend_price);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.price_lower_limit);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.price_upper_limit);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.state);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.auctioner_guid);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.auctioner_name = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.auction_price);
		}

		// Token: 0x06006D4D RID: 27981 RVA: 0x0013DA68 File Offset: 0x0013BE68
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.back_buy_item_id);
			BaseDLL.encode_int8(buffer, ref pos_, this.back_buy_type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.price);
			BaseDLL.encode_uint32(buffer, ref pos_, this.begin_time);
			BaseDLL.encode_uint32(buffer, ref pos_, this.end_time);
			BaseDLL.encode_uint32(buffer, ref pos_, this.recommend_price);
			BaseDLL.encode_uint32(buffer, ref pos_, this.price_lower_limit);
			BaseDLL.encode_uint32(buffer, ref pos_, this.price_upper_limit);
			BaseDLL.encode_int8(buffer, ref pos_, this.state);
			BaseDLL.encode_uint64(buffer, ref pos_, this.auctioner_guid);
			byte[] str = StringHelper.StringToUTF8Bytes(this.auctioner_name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.auction_price);
		}

		// Token: 0x06006D4E RID: 27982 RVA: 0x0013DB3C File Offset: 0x0013BF3C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.back_buy_item_id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.back_buy_type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.price);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.begin_time);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.end_time);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.recommend_price);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.price_lower_limit);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.price_upper_limit);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.state);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.auctioner_guid);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.auctioner_name = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.auction_price);
		}

		// Token: 0x06006D4F RID: 27983 RVA: 0x0013DC34 File Offset: 0x0013C034
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			num++;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num++;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.auctioner_name);
			num += 2 + array.Length;
			return num + 4;
		}

		// Token: 0x04003178 RID: 12664
		public ulong guid;

		// Token: 0x04003179 RID: 12665
		public uint back_buy_item_id;

		// Token: 0x0400317A RID: 12666
		public byte back_buy_type;

		// Token: 0x0400317B RID: 12667
		public uint price;

		// Token: 0x0400317C RID: 12668
		public uint begin_time;

		// Token: 0x0400317D RID: 12669
		public uint end_time;

		// Token: 0x0400317E RID: 12670
		public uint recommend_price;

		// Token: 0x0400317F RID: 12671
		public uint price_lower_limit;

		// Token: 0x04003180 RID: 12672
		public uint price_upper_limit;

		// Token: 0x04003181 RID: 12673
		public byte state;

		// Token: 0x04003182 RID: 12674
		public ulong auctioner_guid;

		// Token: 0x04003183 RID: 12675
		public string auctioner_name;

		// Token: 0x04003184 RID: 12676
		public uint auction_price;
	}
}
