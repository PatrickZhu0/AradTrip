using System;

namespace Protocol
{
	// Token: 0x02000790 RID: 1936
	public class DigItemInfo : IProtocolStream
	{
		// Token: 0x06005EF0 RID: 24304 RVA: 0x0011CB58 File Offset: 0x0011AF58
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemNum);
		}

		// Token: 0x06005EF1 RID: 24305 RVA: 0x0011CB76 File Offset: 0x0011AF76
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemNum);
		}

		// Token: 0x06005EF2 RID: 24306 RVA: 0x0011CB94 File Offset: 0x0011AF94
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemNum);
		}

		// Token: 0x06005EF3 RID: 24307 RVA: 0x0011CBB2 File Offset: 0x0011AFB2
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemNum);
		}

		// Token: 0x06005EF4 RID: 24308 RVA: 0x0011CBD0 File Offset: 0x0011AFD0
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002729 RID: 10025
		public uint itemId;

		// Token: 0x0400272A RID: 10026
		public uint itemNum;
	}
}
