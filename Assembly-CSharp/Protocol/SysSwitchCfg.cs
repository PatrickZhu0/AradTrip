using System;

namespace Protocol
{
	// Token: 0x020009D9 RID: 2521
	public class SysSwitchCfg : IProtocolStream
	{
		// Token: 0x060070C9 RID: 28873 RVA: 0x00145DE4 File Offset: 0x001441E4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.sysType);
			BaseDLL.encode_int8(buffer, ref pos_, this.switchValue);
		}

		// Token: 0x060070CA RID: 28874 RVA: 0x00145E02 File Offset: 0x00144202
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.sysType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.switchValue);
		}

		// Token: 0x060070CB RID: 28875 RVA: 0x00145E20 File Offset: 0x00144220
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.sysType);
			BaseDLL.encode_int8(buffer, ref pos_, this.switchValue);
		}

		// Token: 0x060070CC RID: 28876 RVA: 0x00145E3E File Offset: 0x0014423E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.sysType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.switchValue);
		}

		// Token: 0x060070CD RID: 28877 RVA: 0x00145E5C File Offset: 0x0014425C
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 1;
		}

		// Token: 0x0400335D RID: 13149
		public uint sysType;

		// Token: 0x0400335E RID: 13150
		public byte switchValue;
	}
}
