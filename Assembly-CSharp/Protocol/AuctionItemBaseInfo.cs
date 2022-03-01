using System;

namespace Protocol
{
	// Token: 0x020006BD RID: 1725
	public class AuctionItemBaseInfo : IProtocolStream
	{
		// Token: 0x0600585A RID: 22618 RVA: 0x0010D28F File Offset: 0x0010B68F
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemTypeId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
			BaseDLL.encode_int8(buffer, ref pos_, this.isTreas);
		}

		// Token: 0x0600585B RID: 22619 RVA: 0x0010D2BB File Offset: 0x0010B6BB
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemTypeId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isTreas);
		}

		// Token: 0x0600585C RID: 22620 RVA: 0x0010D2E7 File Offset: 0x0010B6E7
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemTypeId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
			BaseDLL.encode_int8(buffer, ref pos_, this.isTreas);
		}

		// Token: 0x0600585D RID: 22621 RVA: 0x0010D313 File Offset: 0x0010B713
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemTypeId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isTreas);
		}

		// Token: 0x0600585E RID: 22622 RVA: 0x0010D340 File Offset: 0x0010B740
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + 1;
		}

		// Token: 0x04002358 RID: 9048
		public uint itemTypeId;

		// Token: 0x04002359 RID: 9049
		public uint num;

		// Token: 0x0400235A RID: 9050
		public byte isTreas;
	}
}
