using System;

namespace Protocol
{
	// Token: 0x020007C8 RID: 1992
	public class DungeonChest : IProtocolStream
	{
		// Token: 0x06006079 RID: 24697 RVA: 0x00122294 File Offset: 0x00120694
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.goldReward);
			BaseDLL.encode_int8(buffer, ref pos_, this.isRareControl);
			BaseDLL.encode_int8(buffer, ref pos_, this.strenth);
			BaseDLL.encode_int8(buffer, ref pos_, this.equipType);
		}

		// Token: 0x0600607A RID: 24698 RVA: 0x00122304 File Offset: 0x00120704
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.goldReward);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isRareControl);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.strenth);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.equipType);
		}

		// Token: 0x0600607B RID: 24699 RVA: 0x00122374 File Offset: 0x00120774
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.goldReward);
			BaseDLL.encode_int8(buffer, ref pos_, this.isRareControl);
			BaseDLL.encode_int8(buffer, ref pos_, this.strenth);
			BaseDLL.encode_int8(buffer, ref pos_, this.equipType);
		}

		// Token: 0x0600607C RID: 24700 RVA: 0x001223E4 File Offset: 0x001207E4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.goldReward);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isRareControl);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.strenth);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.equipType);
		}

		// Token: 0x0600607D RID: 24701 RVA: 0x00122454 File Offset: 0x00120854
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num++;
			num += 4;
			num++;
			num++;
			return num + 1;
		}

		// Token: 0x04002837 RID: 10295
		public uint itemId;

		// Token: 0x04002838 RID: 10296
		public uint num;

		// Token: 0x04002839 RID: 10297
		public byte type;

		// Token: 0x0400283A RID: 10298
		public uint goldReward;

		// Token: 0x0400283B RID: 10299
		public byte isRareControl;

		// Token: 0x0400283C RID: 10300
		public byte strenth;

		// Token: 0x0400283D RID: 10301
		public byte equipType;
	}
}
