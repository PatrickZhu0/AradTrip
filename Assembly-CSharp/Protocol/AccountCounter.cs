using System;

namespace Protocol
{
	// Token: 0x02000AC2 RID: 2754
	public class AccountCounter : IProtocolStream
	{
		// Token: 0x0600776E RID: 30574 RVA: 0x00158FF0 File Offset: 0x001573F0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.num);
		}

		// Token: 0x0600776F RID: 30575 RVA: 0x0015900E File Offset: 0x0015740E
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06007770 RID: 30576 RVA: 0x0015902C File Offset: 0x0015742C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.num);
		}

		// Token: 0x06007771 RID: 30577 RVA: 0x0015904A File Offset: 0x0015744A
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06007772 RID: 30578 RVA: 0x00159068 File Offset: 0x00157468
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 8;
		}

		// Token: 0x040037F7 RID: 14327
		public uint type;

		// Token: 0x040037F8 RID: 14328
		public ulong num;
	}
}
