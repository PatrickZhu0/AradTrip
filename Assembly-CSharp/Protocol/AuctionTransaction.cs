using System;

namespace Protocol
{
	// Token: 0x020006D6 RID: 1750
	public class AuctionTransaction : IProtocolStream
	{
		// Token: 0x06005935 RID: 22837 RVA: 0x0010F160 File Offset: 0x0010D560
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.item_id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.item_num);
			BaseDLL.encode_uint32(buffer, ref pos_, this.item_score);
			BaseDLL.encode_uint32(buffer, ref pos_, this.unit_price);
			BaseDLL.encode_uint32(buffer, ref pos_, this.verify_end_time);
			BaseDLL.encode_int8(buffer, ref pos_, this.enhance_type);
			BaseDLL.encode_int8(buffer, ref pos_, this.strength);
			BaseDLL.encode_int8(buffer, ref pos_, this.qualitylv);
			BaseDLL.encode_uint32(buffer, ref pos_, this.trans_time);
			BaseDLL.encode_uint32(buffer, ref pos_, this.beadbuffId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.mountBeadId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.mountBeadBuffId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.mountMagicCardId);
			BaseDLL.encode_int8(buffer, ref pos_, this.mountMagicCardLv);
			BaseDLL.encode_int8(buffer, ref pos_, this.equipType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.enhanceNum);
		}

		// Token: 0x06005936 RID: 22838 RVA: 0x0010F25C File Offset: 0x0010D65C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.item_id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.item_num);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.item_score);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.unit_price);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.verify_end_time);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.enhance_type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.strength);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.qualitylv);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.trans_time);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.beadbuffId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mountBeadId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mountBeadBuffId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mountMagicCardId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.mountMagicCardLv);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.equipType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.enhanceNum);
		}

		// Token: 0x06005937 RID: 22839 RVA: 0x0010F358 File Offset: 0x0010D758
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.item_id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.item_num);
			BaseDLL.encode_uint32(buffer, ref pos_, this.item_score);
			BaseDLL.encode_uint32(buffer, ref pos_, this.unit_price);
			BaseDLL.encode_uint32(buffer, ref pos_, this.verify_end_time);
			BaseDLL.encode_int8(buffer, ref pos_, this.enhance_type);
			BaseDLL.encode_int8(buffer, ref pos_, this.strength);
			BaseDLL.encode_int8(buffer, ref pos_, this.qualitylv);
			BaseDLL.encode_uint32(buffer, ref pos_, this.trans_time);
			BaseDLL.encode_uint32(buffer, ref pos_, this.beadbuffId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.mountBeadId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.mountBeadBuffId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.mountMagicCardId);
			BaseDLL.encode_int8(buffer, ref pos_, this.mountMagicCardLv);
			BaseDLL.encode_int8(buffer, ref pos_, this.equipType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.enhanceNum);
		}

		// Token: 0x06005938 RID: 22840 RVA: 0x0010F454 File Offset: 0x0010D854
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.item_id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.item_num);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.item_score);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.unit_price);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.verify_end_time);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.enhance_type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.strength);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.qualitylv);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.trans_time);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.beadbuffId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mountBeadId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mountBeadBuffId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mountMagicCardId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.mountMagicCardLv);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.equipType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.enhanceNum);
		}

		// Token: 0x06005939 RID: 22841 RVA: 0x0010F550 File Offset: 0x0010D950
		public int getLen()
		{
			int num = 0;
			num++;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num++;
			num++;
			num++;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num++;
			num++;
			return num + 4;
		}

		// Token: 0x040023DA RID: 9178
		public byte type;

		// Token: 0x040023DB RID: 9179
		public uint item_id;

		// Token: 0x040023DC RID: 9180
		public uint item_num;

		// Token: 0x040023DD RID: 9181
		public uint item_score;

		// Token: 0x040023DE RID: 9182
		public uint unit_price;

		// Token: 0x040023DF RID: 9183
		public uint verify_end_time;

		// Token: 0x040023E0 RID: 9184
		public byte enhance_type;

		// Token: 0x040023E1 RID: 9185
		public byte strength;

		// Token: 0x040023E2 RID: 9186
		public byte qualitylv;

		// Token: 0x040023E3 RID: 9187
		public uint trans_time;

		// Token: 0x040023E4 RID: 9188
		public uint beadbuffId;

		// Token: 0x040023E5 RID: 9189
		public uint mountBeadId;

		// Token: 0x040023E6 RID: 9190
		public uint mountBeadBuffId;

		// Token: 0x040023E7 RID: 9191
		public uint mountMagicCardId;

		// Token: 0x040023E8 RID: 9192
		public byte mountMagicCardLv;

		// Token: 0x040023E9 RID: 9193
		public byte equipType;

		// Token: 0x040023EA RID: 9194
		public uint enhanceNum;
	}
}
