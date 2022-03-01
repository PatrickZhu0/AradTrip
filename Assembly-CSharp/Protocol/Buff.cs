using System;

namespace Protocol
{
	// Token: 0x02000B5B RID: 2907
	public class Buff : IProtocolStream
	{
		// Token: 0x06007BD9 RID: 31705 RVA: 0x0016288C File Offset: 0x00160C8C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.overlay);
			BaseDLL.encode_uint32(buffer, ref pos_, this.duration);
		}

		// Token: 0x06007BDA RID: 31706 RVA: 0x001628C6 File Offset: 0x00160CC6
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.overlay);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.duration);
		}

		// Token: 0x06007BDB RID: 31707 RVA: 0x00162900 File Offset: 0x00160D00
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.overlay);
			BaseDLL.encode_uint32(buffer, ref pos_, this.duration);
		}

		// Token: 0x06007BDC RID: 31708 RVA: 0x0016293A File Offset: 0x00160D3A
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.overlay);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.duration);
		}

		// Token: 0x06007BDD RID: 31709 RVA: 0x00162974 File Offset: 0x00160D74
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003AB2 RID: 15026
		public ulong uid;

		// Token: 0x04003AB3 RID: 15027
		public uint id;

		// Token: 0x04003AB4 RID: 15028
		public uint overlay;

		// Token: 0x04003AB5 RID: 15029
		public uint duration;
	}
}
