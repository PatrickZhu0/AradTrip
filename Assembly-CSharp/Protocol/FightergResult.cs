using System;

namespace Protocol
{
	// Token: 0x02000A95 RID: 2709
	public class FightergResult : IProtocolStream
	{
		// Token: 0x0600762D RID: 30253 RVA: 0x00155940 File Offset: 0x00153D40
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.flag);
			BaseDLL.encode_int8(buffer, ref pos_, this.seat);
			BaseDLL.encode_uint32(buffer, ref pos_, this.accid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.roldid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.remainHp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.remainMp);
		}

		// Token: 0x0600762E RID: 30254 RVA: 0x001559A4 File Offset: 0x00153DA4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.flag);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.seat);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roldid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.remainHp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.remainMp);
		}

		// Token: 0x0600762F RID: 30255 RVA: 0x00155A08 File Offset: 0x00153E08
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.flag);
			BaseDLL.encode_int8(buffer, ref pos_, this.seat);
			BaseDLL.encode_uint32(buffer, ref pos_, this.accid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.roldid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.remainHp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.remainMp);
		}

		// Token: 0x06007630 RID: 30256 RVA: 0x00155A6C File Offset: 0x00153E6C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.flag);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.seat);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roldid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.remainHp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.remainMp);
		}

		// Token: 0x06007631 RID: 30257 RVA: 0x00155AD0 File Offset: 0x00153ED0
		public int getLen()
		{
			int num = 0;
			num++;
			num++;
			num += 4;
			num += 8;
			num += 4;
			return num + 4;
		}

		// Token: 0x0400372C RID: 14124
		public byte flag;

		// Token: 0x0400372D RID: 14125
		public byte seat;

		// Token: 0x0400372E RID: 14126
		public uint accid;

		// Token: 0x0400372F RID: 14127
		public ulong roldid;

		// Token: 0x04003730 RID: 14128
		public uint remainHp;

		// Token: 0x04003731 RID: 14129
		public uint remainMp;
	}
}
