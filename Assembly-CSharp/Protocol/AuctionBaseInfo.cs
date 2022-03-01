using System;

namespace Protocol
{
	// Token: 0x020006BF RID: 1727
	public class AuctionBaseInfo : IProtocolStream
	{
		// Token: 0x06005869 RID: 22633 RVA: 0x0010D3EC File Offset: 0x0010B7EC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.price);
			BaseDLL.encode_int8(buffer, ref pos_, this.pricetype);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemTypeId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.strengthed);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemScore);
			BaseDLL.encode_uint32(buffer, ref pos_, this.publicEndTime);
			BaseDLL.encode_int8(buffer, ref pos_, this.isTreas);
			BaseDLL.encode_uint64(buffer, ref pos_, this.owner);
			BaseDLL.encode_int8(buffer, ref pos_, this.attent);
			BaseDLL.encode_uint32(buffer, ref pos_, this.attentNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.duetime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.onSaleTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.beadbuffid);
			BaseDLL.encode_int8(buffer, ref pos_, this.isAgainOnsale);
			BaseDLL.encode_int8(buffer, ref pos_, this.equipType);
			BaseDLL.encode_int8(buffer, ref pos_, this.enhanceType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemDueTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.enhanceNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemTransNum);
		}

		// Token: 0x0600586A RID: 22634 RVA: 0x0010D520 File Offset: 0x0010B920
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.price);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.pricetype);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemTypeId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.strengthed);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemScore);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.publicEndTime);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isTreas);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.owner);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.attent);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.attentNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.duetime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.onSaleTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.beadbuffid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isAgainOnsale);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.equipType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.enhanceType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemDueTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.enhanceNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemTransNum);
		}

		// Token: 0x0600586B RID: 22635 RVA: 0x0010D654 File Offset: 0x0010BA54
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.price);
			BaseDLL.encode_int8(buffer, ref pos_, this.pricetype);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemTypeId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.strengthed);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemScore);
			BaseDLL.encode_uint32(buffer, ref pos_, this.publicEndTime);
			BaseDLL.encode_int8(buffer, ref pos_, this.isTreas);
			BaseDLL.encode_uint64(buffer, ref pos_, this.owner);
			BaseDLL.encode_int8(buffer, ref pos_, this.attent);
			BaseDLL.encode_uint32(buffer, ref pos_, this.attentNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.duetime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.onSaleTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.beadbuffid);
			BaseDLL.encode_int8(buffer, ref pos_, this.isAgainOnsale);
			BaseDLL.encode_int8(buffer, ref pos_, this.equipType);
			BaseDLL.encode_int8(buffer, ref pos_, this.enhanceType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemDueTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.enhanceNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemTransNum);
		}

		// Token: 0x0600586C RID: 22636 RVA: 0x0010D788 File Offset: 0x0010BB88
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.price);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.pricetype);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemTypeId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.strengthed);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemScore);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.publicEndTime);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isTreas);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.owner);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.attent);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.attentNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.duetime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.onSaleTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.beadbuffid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isAgainOnsale);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.equipType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.enhanceType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemDueTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.enhanceNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemTransNum);
		}

		// Token: 0x0600586D RID: 22637 RVA: 0x0010D8BC File Offset: 0x0010BCBC
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
			num++;
			num += 8;
			num++;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num++;
			num++;
			num++;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x0400235E RID: 9054
		public ulong guid;

		// Token: 0x0400235F RID: 9055
		public uint price;

		// Token: 0x04002360 RID: 9056
		public byte pricetype;

		// Token: 0x04002361 RID: 9057
		public uint num;

		// Token: 0x04002362 RID: 9058
		public uint itemTypeId;

		// Token: 0x04002363 RID: 9059
		public uint strengthed;

		// Token: 0x04002364 RID: 9060
		public uint itemScore;

		// Token: 0x04002365 RID: 9061
		public uint publicEndTime;

		// Token: 0x04002366 RID: 9062
		public byte isTreas;

		// Token: 0x04002367 RID: 9063
		public ulong owner;

		// Token: 0x04002368 RID: 9064
		public byte attent;

		// Token: 0x04002369 RID: 9065
		public uint attentNum;

		// Token: 0x0400236A RID: 9066
		public uint duetime;

		// Token: 0x0400236B RID: 9067
		public uint onSaleTime;

		// Token: 0x0400236C RID: 9068
		public uint beadbuffid;

		// Token: 0x0400236D RID: 9069
		public byte isAgainOnsale;

		// Token: 0x0400236E RID: 9070
		public byte equipType;

		// Token: 0x0400236F RID: 9071
		public byte enhanceType;

		// Token: 0x04002370 RID: 9072
		public uint itemDueTime;

		// Token: 0x04002371 RID: 9073
		public uint enhanceNum;

		// Token: 0x04002372 RID: 9074
		public uint itemTransNum;
	}
}
