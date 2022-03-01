using System;

namespace Protocol
{
	// Token: 0x02000827 RID: 2087
	public class GuildStorageDelItemInfo : IProtocolStream
	{
		// Token: 0x060062D7 RID: 25303 RVA: 0x001296F4 File Offset: 0x00127AF4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
			BaseDLL.encode_uint16(buffer, ref pos_, this.num);
		}

		// Token: 0x060062D8 RID: 25304 RVA: 0x00129712 File Offset: 0x00127B12
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.num);
		}

		// Token: 0x060062D9 RID: 25305 RVA: 0x00129730 File Offset: 0x00127B30
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
			BaseDLL.encode_uint16(buffer, ref pos_, this.num);
		}

		// Token: 0x060062DA RID: 25306 RVA: 0x0012974E File Offset: 0x00127B4E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.num);
		}

		// Token: 0x060062DB RID: 25307 RVA: 0x0012976C File Offset: 0x00127B6C
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 2;
		}

		// Token: 0x04002C6D RID: 11373
		public ulong uid;

		// Token: 0x04002C6E RID: 11374
		public ushort num;
	}
}
