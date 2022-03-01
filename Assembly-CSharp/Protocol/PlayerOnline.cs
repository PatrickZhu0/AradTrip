using System;

namespace Protocol
{
	// Token: 0x02000C95 RID: 3221
	public class PlayerOnline : IProtocolStream
	{
		// Token: 0x060084F7 RID: 34039 RVA: 0x00175270 File Offset: 0x00173670
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
			BaseDLL.encode_int8(buffer, ref pos_, this.online);
		}

		// Token: 0x060084F8 RID: 34040 RVA: 0x0017528E File Offset: 0x0017368E
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.online);
		}

		// Token: 0x060084F9 RID: 34041 RVA: 0x001752AC File Offset: 0x001736AC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
			BaseDLL.encode_int8(buffer, ref pos_, this.online);
		}

		// Token: 0x060084FA RID: 34042 RVA: 0x001752CA File Offset: 0x001736CA
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.online);
		}

		// Token: 0x060084FB RID: 34043 RVA: 0x001752E8 File Offset: 0x001736E8
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 1;
		}

		// Token: 0x04003FBD RID: 16317
		public ulong uid;

		// Token: 0x04003FBE RID: 16318
		public byte online;
	}
}
