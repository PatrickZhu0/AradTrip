using System;

namespace Protocol
{
	// Token: 0x02000A04 RID: 2564
	public class FriendMatchStatusInfo : IProtocolStream
	{
		// Token: 0x060071EC RID: 29164 RVA: 0x0014ABE9 File Offset: 0x00148FE9
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
		}

		// Token: 0x060071ED RID: 29165 RVA: 0x0014AC07 File Offset: 0x00149007
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
		}

		// Token: 0x060071EE RID: 29166 RVA: 0x0014AC25 File Offset: 0x00149025
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
		}

		// Token: 0x060071EF RID: 29167 RVA: 0x0014AC43 File Offset: 0x00149043
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
		}

		// Token: 0x060071F0 RID: 29168 RVA: 0x0014AC64 File Offset: 0x00149064
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 1;
		}

		// Token: 0x0400345F RID: 13407
		public ulong roleId;

		// Token: 0x04003460 RID: 13408
		public byte status;
	}
}
