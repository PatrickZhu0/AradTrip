using System;

namespace Protocol
{
	// Token: 0x02000709 RID: 1801
	public class DetailItem : IProtocolStream
	{
		// Token: 0x06005ACA RID: 23242 RVA: 0x00113C88 File Offset: 0x00112088
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemTypeId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
		}

		// Token: 0x06005ACB RID: 23243 RVA: 0x00113CB4 File Offset: 0x001120B4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemTypeId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06005ACC RID: 23244 RVA: 0x00113CE0 File Offset: 0x001120E0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemTypeId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
		}

		// Token: 0x06005ACD RID: 23245 RVA: 0x00113D0C File Offset: 0x0011210C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemTypeId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06005ACE RID: 23246 RVA: 0x00113D38 File Offset: 0x00112138
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			return num + 4;
		}

		// Token: 0x040024EF RID: 9455
		public ulong guid;

		// Token: 0x040024F0 RID: 9456
		public uint itemTypeId;

		// Token: 0x040024F1 RID: 9457
		public uint num;
	}
}
