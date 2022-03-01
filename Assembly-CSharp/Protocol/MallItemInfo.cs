using System;

namespace Protocol
{
	// Token: 0x020008CF RID: 2255
	public class MallItemInfo : IProtocolStream
	{
		// Token: 0x060067CF RID: 26575 RVA: 0x001321B4 File Offset: 0x001305B4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_int8(buffer, ref pos_, this.subtype);
			BaseDLL.encode_int8(buffer, ref pos_, this.jobtype);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemnum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.price);
			BaseDLL.encode_uint32(buffer, ref pos_, this.discountprice);
			BaseDLL.encode_int8(buffer, ref pos_, this.moneytype);
			BaseDLL.encode_int8(buffer, ref pos_, this.limit);
			BaseDLL.encode_uint16(buffer, ref pos_, this.limitnum);
			BaseDLL.encode_int8(buffer, ref pos_, this.gift);
			BaseDLL.encode_uint16(buffer, ref pos_, this.vipscore);
			byte[] str = StringHelper.StringToUTF8Bytes(this.icon);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.starttime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.endtime);
			BaseDLL.encode_uint16(buffer, ref pos_, this.limittotalnum);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.giftItems.Length);
			for (int i = 0; i < this.giftItems.Length; i++)
			{
				this.giftItems[i].encode(buffer, ref pos_);
			}
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.giftName);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.tagType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.sortIdx);
			BaseDLL.encode_uint32(buffer, ref pos_, this.hotSortIdx);
			BaseDLL.encode_uint16(buffer, ref pos_, this.goodsSubType);
			BaseDLL.encode_int8(buffer, ref pos_, this.isRecommend);
			BaseDLL.encode_int8(buffer, ref pos_, this.isPersonalTailor);
			BaseDLL.encode_uint32(buffer, ref pos_, this.discountRate);
			BaseDLL.encode_int8(buffer, ref pos_, this.loginPushId);
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.fashionImagePath);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
			byte[] str4 = StringHelper.StringToUTF8Bytes(this.giftDesc);
			BaseDLL.encode_string(buffer, ref pos_, str4, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.buyGotInfos.Length);
			for (int j = 0; j < this.buyGotInfos.Length; j++)
			{
				this.buyGotInfos[j].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.extParams.Length);
			for (int k = 0; k < this.extParams.Length; k++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.extParams[k]);
			}
			BaseDLL.encode_int8(buffer, ref pos_, this.accountRefreshType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.accountLimitBuyNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.accountRestBuyNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.discountCouponId);
			BaseDLL.encode_int8(buffer, ref pos_, this.multiple);
			BaseDLL.encode_uint32(buffer, ref pos_, this.multipleEndTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.deductionCouponId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.creditPointDeduction);
		}

		// Token: 0x060067D0 RID: 26576 RVA: 0x001324AC File Offset: 0x001308AC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.subtype);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.jobtype);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemnum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.price);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.discountprice);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.moneytype);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.limit);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.limitnum);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.gift);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.vipscore);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.icon = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.starttime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.endtime);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.limittotalnum);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.giftItems = new ItemReward[(int)num2];
			for (int j = 0; j < this.giftItems.Length; j++)
			{
				this.giftItems[j] = new ItemReward();
				this.giftItems[j].decode(buffer, ref pos_);
			}
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			byte[] array2 = new byte[(int)num3];
			for (int k = 0; k < (int)num3; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[k]);
			}
			this.giftName = StringHelper.BytesToString(array2);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.tagType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.sortIdx);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.hotSortIdx);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.goodsSubType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isRecommend);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isPersonalTailor);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.discountRate);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.loginPushId);
			ushort num4 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num4);
			byte[] array3 = new byte[(int)num4];
			for (int l = 0; l < (int)num4; l++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[l]);
			}
			this.fashionImagePath = StringHelper.BytesToString(array3);
			ushort num5 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num5);
			byte[] array4 = new byte[(int)num5];
			for (int m = 0; m < (int)num5; m++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array4[m]);
			}
			this.giftDesc = StringHelper.BytesToString(array4);
			ushort num6 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num6);
			this.buyGotInfos = new MallBuyGotInfo[(int)num6];
			for (int n = 0; n < this.buyGotInfos.Length; n++)
			{
				this.buyGotInfos[n] = new MallBuyGotInfo();
				this.buyGotInfos[n].decode(buffer, ref pos_);
			}
			ushort num7 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num7);
			this.extParams = new uint[(int)num7];
			for (int num8 = 0; num8 < this.extParams.Length; num8++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.extParams[num8]);
			}
			BaseDLL.decode_int8(buffer, ref pos_, ref this.accountRefreshType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accountLimitBuyNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accountRestBuyNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.discountCouponId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.multiple);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.multipleEndTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.deductionCouponId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.creditPointDeduction);
		}

		// Token: 0x060067D1 RID: 26577 RVA: 0x00132890 File Offset: 0x00130C90
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_int8(buffer, ref pos_, this.subtype);
			BaseDLL.encode_int8(buffer, ref pos_, this.jobtype);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemnum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.price);
			BaseDLL.encode_uint32(buffer, ref pos_, this.discountprice);
			BaseDLL.encode_int8(buffer, ref pos_, this.moneytype);
			BaseDLL.encode_int8(buffer, ref pos_, this.limit);
			BaseDLL.encode_uint16(buffer, ref pos_, this.limitnum);
			BaseDLL.encode_int8(buffer, ref pos_, this.gift);
			BaseDLL.encode_uint16(buffer, ref pos_, this.vipscore);
			byte[] str = StringHelper.StringToUTF8Bytes(this.icon);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.starttime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.endtime);
			BaseDLL.encode_uint16(buffer, ref pos_, this.limittotalnum);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.giftItems.Length);
			for (int i = 0; i < this.giftItems.Length; i++)
			{
				this.giftItems[i].encode(buffer, ref pos_);
			}
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.giftName);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.tagType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.sortIdx);
			BaseDLL.encode_uint32(buffer, ref pos_, this.hotSortIdx);
			BaseDLL.encode_uint16(buffer, ref pos_, this.goodsSubType);
			BaseDLL.encode_int8(buffer, ref pos_, this.isRecommend);
			BaseDLL.encode_int8(buffer, ref pos_, this.isPersonalTailor);
			BaseDLL.encode_uint32(buffer, ref pos_, this.discountRate);
			BaseDLL.encode_int8(buffer, ref pos_, this.loginPushId);
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.fashionImagePath);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
			byte[] str4 = StringHelper.StringToUTF8Bytes(this.giftDesc);
			BaseDLL.encode_string(buffer, ref pos_, str4, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.buyGotInfos.Length);
			for (int j = 0; j < this.buyGotInfos.Length; j++)
			{
				this.buyGotInfos[j].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.extParams.Length);
			for (int k = 0; k < this.extParams.Length; k++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.extParams[k]);
			}
			BaseDLL.encode_int8(buffer, ref pos_, this.accountRefreshType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.accountLimitBuyNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.accountRestBuyNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.discountCouponId);
			BaseDLL.encode_int8(buffer, ref pos_, this.multiple);
			BaseDLL.encode_uint32(buffer, ref pos_, this.multipleEndTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.deductionCouponId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.creditPointDeduction);
		}

		// Token: 0x060067D2 RID: 26578 RVA: 0x00132B94 File Offset: 0x00130F94
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.subtype);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.jobtype);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemnum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.price);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.discountprice);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.moneytype);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.limit);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.limitnum);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.gift);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.vipscore);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.icon = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.starttime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.endtime);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.limittotalnum);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.giftItems = new ItemReward[(int)num2];
			for (int j = 0; j < this.giftItems.Length; j++)
			{
				this.giftItems[j] = new ItemReward();
				this.giftItems[j].decode(buffer, ref pos_);
			}
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			byte[] array2 = new byte[(int)num3];
			for (int k = 0; k < (int)num3; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[k]);
			}
			this.giftName = StringHelper.BytesToString(array2);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.tagType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.sortIdx);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.hotSortIdx);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.goodsSubType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isRecommend);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isPersonalTailor);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.discountRate);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.loginPushId);
			ushort num4 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num4);
			byte[] array3 = new byte[(int)num4];
			for (int l = 0; l < (int)num4; l++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[l]);
			}
			this.fashionImagePath = StringHelper.BytesToString(array3);
			ushort num5 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num5);
			byte[] array4 = new byte[(int)num5];
			for (int m = 0; m < (int)num5; m++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array4[m]);
			}
			this.giftDesc = StringHelper.BytesToString(array4);
			ushort num6 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num6);
			this.buyGotInfos = new MallBuyGotInfo[(int)num6];
			for (int n = 0; n < this.buyGotInfos.Length; n++)
			{
				this.buyGotInfos[n] = new MallBuyGotInfo();
				this.buyGotInfos[n].decode(buffer, ref pos_);
			}
			ushort num7 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num7);
			this.extParams = new uint[(int)num7];
			for (int num8 = 0; num8 < this.extParams.Length; num8++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.extParams[num8]);
			}
			BaseDLL.decode_int8(buffer, ref pos_, ref this.accountRefreshType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accountLimitBuyNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accountRestBuyNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.discountCouponId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.multiple);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.multipleEndTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.deductionCouponId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.creditPointDeduction);
		}

		// Token: 0x060067D3 RID: 26579 RVA: 0x00132F78 File Offset: 0x00131378
		public int getLen()
		{
			int num = 0;
			num += 4;
			num++;
			num++;
			num++;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num++;
			num++;
			num += 2;
			num++;
			num += 2;
			byte[] array = StringHelper.StringToUTF8Bytes(this.icon);
			num += 2 + array.Length;
			num += 4;
			num += 4;
			num += 2;
			num += 2;
			for (int i = 0; i < this.giftItems.Length; i++)
			{
				num += this.giftItems[i].getLen();
			}
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.giftName);
			num += 2 + array2.Length;
			num++;
			num += 4;
			num += 4;
			num += 2;
			num++;
			num++;
			num += 4;
			num++;
			byte[] array3 = StringHelper.StringToUTF8Bytes(this.fashionImagePath);
			num += 2 + array3.Length;
			byte[] array4 = StringHelper.StringToUTF8Bytes(this.giftDesc);
			num += 2 + array4.Length;
			num += 2;
			for (int j = 0; j < this.buyGotInfos.Length; j++)
			{
				num += this.buyGotInfos[j].getLen();
			}
			num += 2 + 4 * this.extParams.Length;
			num++;
			num += 4;
			num += 4;
			num += 4;
			num++;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002ED2 RID: 11986
		public uint id;

		// Token: 0x04002ED3 RID: 11987
		public byte type;

		// Token: 0x04002ED4 RID: 11988
		public byte subtype;

		// Token: 0x04002ED5 RID: 11989
		public byte jobtype;

		// Token: 0x04002ED6 RID: 11990
		public uint itemid;

		// Token: 0x04002ED7 RID: 11991
		public uint itemnum;

		// Token: 0x04002ED8 RID: 11992
		public uint price;

		// Token: 0x04002ED9 RID: 11993
		public uint discountprice;

		// Token: 0x04002EDA RID: 11994
		public byte moneytype;

		// Token: 0x04002EDB RID: 11995
		public byte limit;

		// Token: 0x04002EDC RID: 11996
		public ushort limitnum;

		// Token: 0x04002EDD RID: 11997
		public byte gift;

		// Token: 0x04002EDE RID: 11998
		public ushort vipscore;

		// Token: 0x04002EDF RID: 11999
		public string icon;

		// Token: 0x04002EE0 RID: 12000
		public uint starttime;

		// Token: 0x04002EE1 RID: 12001
		public uint endtime;

		// Token: 0x04002EE2 RID: 12002
		public ushort limittotalnum;

		// Token: 0x04002EE3 RID: 12003
		public ItemReward[] giftItems = new ItemReward[0];

		// Token: 0x04002EE4 RID: 12004
		public string giftName;

		// Token: 0x04002EE5 RID: 12005
		public byte tagType;

		// Token: 0x04002EE6 RID: 12006
		public uint sortIdx;

		// Token: 0x04002EE7 RID: 12007
		public uint hotSortIdx;

		// Token: 0x04002EE8 RID: 12008
		public ushort goodsSubType;

		// Token: 0x04002EE9 RID: 12009
		public byte isRecommend;

		// Token: 0x04002EEA RID: 12010
		public byte isPersonalTailor;

		// Token: 0x04002EEB RID: 12011
		public uint discountRate;

		// Token: 0x04002EEC RID: 12012
		public byte loginPushId;

		// Token: 0x04002EED RID: 12013
		public string fashionImagePath;

		// Token: 0x04002EEE RID: 12014
		public string giftDesc;

		// Token: 0x04002EEF RID: 12015
		public MallBuyGotInfo[] buyGotInfos = new MallBuyGotInfo[0];

		// Token: 0x04002EF0 RID: 12016
		public uint[] extParams = new uint[0];

		// Token: 0x04002EF1 RID: 12017
		public byte accountRefreshType;

		// Token: 0x04002EF2 RID: 12018
		public uint accountLimitBuyNum;

		// Token: 0x04002EF3 RID: 12019
		public uint accountRestBuyNum;

		// Token: 0x04002EF4 RID: 12020
		public uint discountCouponId;

		// Token: 0x04002EF5 RID: 12021
		public byte multiple;

		// Token: 0x04002EF6 RID: 12022
		public uint multipleEndTime;

		// Token: 0x04002EF7 RID: 12023
		public uint deductionCouponId;

		// Token: 0x04002EF8 RID: 12024
		public uint creditPointDeduction;
	}
}
