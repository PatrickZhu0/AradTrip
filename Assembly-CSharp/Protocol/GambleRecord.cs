using System;

namespace Protocol
{
	// Token: 0x02000774 RID: 1908
	public class GambleRecord : IProtocolStream
	{
		// Token: 0x06005E27 RID: 24103 RVA: 0x0011A5D8 File Offset: 0x001189D8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint64(buffer, ref pos_, this.option);
			BaseDLL.encode_uint64(buffer, ref pos_, this.result);
			BaseDLL.encode_uint64(buffer, ref pos_, this.reward);
			BaseDLL.encode_uint32(buffer, ref pos_, this.time);
			BaseDLL.encode_uint64(buffer, ref pos_, this.num);
		}

		// Token: 0x06005E28 RID: 24104 RVA: 0x0011A63C File Offset: 0x00118A3C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.option);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.reward);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.time);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06005E29 RID: 24105 RVA: 0x0011A6A0 File Offset: 0x00118AA0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint64(buffer, ref pos_, this.option);
			BaseDLL.encode_uint64(buffer, ref pos_, this.result);
			BaseDLL.encode_uint64(buffer, ref pos_, this.reward);
			BaseDLL.encode_uint32(buffer, ref pos_, this.time);
			BaseDLL.encode_uint64(buffer, ref pos_, this.num);
		}

		// Token: 0x06005E2A RID: 24106 RVA: 0x0011A704 File Offset: 0x00118B04
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.option);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.reward);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.time);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06005E2B RID: 24107 RVA: 0x0011A768 File Offset: 0x00118B68
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 8;
			num += 8;
			num += 8;
			num += 4;
			return num + 8;
		}

		// Token: 0x0400269A RID: 9882
		public uint id;

		// Token: 0x0400269B RID: 9883
		public ulong option;

		// Token: 0x0400269C RID: 9884
		public ulong result;

		// Token: 0x0400269D RID: 9885
		public ulong reward;

		// Token: 0x0400269E RID: 9886
		public uint time;

		// Token: 0x0400269F RID: 9887
		public ulong num;
	}
}
