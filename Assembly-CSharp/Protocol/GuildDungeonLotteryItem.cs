using System;

namespace Protocol
{
	// Token: 0x0200088B RID: 2187
	public class GuildDungeonLotteryItem : IProtocolStream
	{
		// Token: 0x06006646 RID: 26182 RVA: 0x0012F498 File Offset: 0x0012D898
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.isHighVal);
		}

		// Token: 0x06006647 RID: 26183 RVA: 0x0012F4C4 File Offset: 0x0012D8C4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isHighVal);
		}

		// Token: 0x06006648 RID: 26184 RVA: 0x0012F4F0 File Offset: 0x0012D8F0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.isHighVal);
		}

		// Token: 0x06006649 RID: 26185 RVA: 0x0012F51C File Offset: 0x0012D91C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isHighVal);
		}

		// Token: 0x0600664A RID: 26186 RVA: 0x0012F548 File Offset: 0x0012D948
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002DC1 RID: 11713
		public uint itemId;

		// Token: 0x04002DC2 RID: 11714
		public uint itemNum;

		// Token: 0x04002DC3 RID: 11715
		public uint isHighVal;
	}
}
