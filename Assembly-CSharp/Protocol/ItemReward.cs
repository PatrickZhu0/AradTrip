using System;

namespace Protocol
{
	// Token: 0x020008CA RID: 2250
	public class ItemReward : IProtocolStream
	{
		// Token: 0x060067B1 RID: 26545 RVA: 0x00131CC4 File Offset: 0x001300C4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
			BaseDLL.encode_int8(buffer, ref pos_, this.qualityLv);
			BaseDLL.encode_int8(buffer, ref pos_, this.strength);
			BaseDLL.encode_uint32(buffer, ref pos_, this.auctionCoolTimeStamp);
			BaseDLL.encode_int8(buffer, ref pos_, this.equipType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.auctionTransTimes);
		}

		// Token: 0x060067B2 RID: 26546 RVA: 0x00131D34 File Offset: 0x00130134
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.qualityLv);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.strength);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.auctionCoolTimeStamp);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.equipType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.auctionTransTimes);
		}

		// Token: 0x060067B3 RID: 26547 RVA: 0x00131DA4 File Offset: 0x001301A4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
			BaseDLL.encode_int8(buffer, ref pos_, this.qualityLv);
			BaseDLL.encode_int8(buffer, ref pos_, this.strength);
			BaseDLL.encode_uint32(buffer, ref pos_, this.auctionCoolTimeStamp);
			BaseDLL.encode_int8(buffer, ref pos_, this.equipType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.auctionTransTimes);
		}

		// Token: 0x060067B4 RID: 26548 RVA: 0x00131E14 File Offset: 0x00130214
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.qualityLv);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.strength);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.auctionCoolTimeStamp);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.equipType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.auctionTransTimes);
		}

		// Token: 0x060067B5 RID: 26549 RVA: 0x00131E84 File Offset: 0x00130284
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num++;
			num++;
			num += 4;
			num++;
			return num + 4;
		}

		// Token: 0x04002EC1 RID: 11969
		public uint id;

		// Token: 0x04002EC2 RID: 11970
		public uint num;

		// Token: 0x04002EC3 RID: 11971
		public byte qualityLv;

		// Token: 0x04002EC4 RID: 11972
		public byte strength;

		// Token: 0x04002EC5 RID: 11973
		public uint auctionCoolTimeStamp;

		// Token: 0x04002EC6 RID: 11974
		public byte equipType;

		// Token: 0x04002EC7 RID: 11975
		public uint auctionTransTimes;
	}
}
