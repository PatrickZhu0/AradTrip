using System;

namespace Protocol
{
	// Token: 0x02000A97 RID: 2711
	public class PkPlayerRaceEndInfo : IProtocolStream
	{
		// Token: 0x0600763C RID: 30268 RVA: 0x00155D2C File Offset: 0x0015412C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_int8(buffer, ref pos_, this.pos);
			BaseDLL.encode_int8(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.remainHp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.remainMp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.damagePercent);
		}

		// Token: 0x0600763D RID: 30269 RVA: 0x00155D90 File Offset: 0x00154190
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.pos);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.remainHp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.remainMp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.damagePercent);
		}

		// Token: 0x0600763E RID: 30270 RVA: 0x00155DF4 File Offset: 0x001541F4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_int8(buffer, ref pos_, this.pos);
			BaseDLL.encode_int8(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.remainHp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.remainMp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.damagePercent);
		}

		// Token: 0x0600763F RID: 30271 RVA: 0x00155E58 File Offset: 0x00154258
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.pos);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.remainHp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.remainMp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.damagePercent);
		}

		// Token: 0x06007640 RID: 30272 RVA: 0x00155EBC File Offset: 0x001542BC
		public int getLen()
		{
			int num = 0;
			num += 8;
			num++;
			num++;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003737 RID: 14135
		public ulong roleId;

		// Token: 0x04003738 RID: 14136
		public byte pos;

		// Token: 0x04003739 RID: 14137
		public byte result;

		// Token: 0x0400373A RID: 14138
		public uint remainHp;

		// Token: 0x0400373B RID: 14139
		public uint remainMp;

		// Token: 0x0400373C RID: 14140
		public uint damagePercent;
	}
}
