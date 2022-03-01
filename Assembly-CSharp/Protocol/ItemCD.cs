using System;

namespace Protocol
{
	// Token: 0x020008CC RID: 2252
	public class ItemCD : IProtocolStream
	{
		// Token: 0x060067BD RID: 26557 RVA: 0x00131F50 File Offset: 0x00130350
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.groupid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.endtime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.maxtime);
		}

		// Token: 0x060067BE RID: 26558 RVA: 0x00131F7C File Offset: 0x0013037C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.groupid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.endtime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.maxtime);
		}

		// Token: 0x060067BF RID: 26559 RVA: 0x00131FA8 File Offset: 0x001303A8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.groupid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.endtime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.maxtime);
		}

		// Token: 0x060067C0 RID: 26560 RVA: 0x00131FD4 File Offset: 0x001303D4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.groupid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.endtime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.maxtime);
		}

		// Token: 0x060067C1 RID: 26561 RVA: 0x00132000 File Offset: 0x00130400
		public int getLen()
		{
			int num = 0;
			num++;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002ECA RID: 11978
		public byte groupid;

		// Token: 0x04002ECB RID: 11979
		public uint endtime;

		// Token: 0x04002ECC RID: 11980
		public uint maxtime;
	}
}
