using System;

namespace Protocol
{
	// Token: 0x020009F5 RID: 2549
	public class RaceBuffInfo : IProtocolStream
	{
		// Token: 0x0600717A RID: 29050 RVA: 0x00148140 File Offset: 0x00146540
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.overlayNums);
			BaseDLL.encode_uint64(buffer, ref pos_, this.startTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.duration);
		}

		// Token: 0x0600717B RID: 29051 RVA: 0x0014817A File Offset: 0x0014657A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.overlayNums);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.startTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.duration);
		}

		// Token: 0x0600717C RID: 29052 RVA: 0x001481B4 File Offset: 0x001465B4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.overlayNums);
			BaseDLL.encode_uint64(buffer, ref pos_, this.startTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.duration);
		}

		// Token: 0x0600717D RID: 29053 RVA: 0x001481EE File Offset: 0x001465EE
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.overlayNums);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.startTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.duration);
		}

		// Token: 0x0600717E RID: 29054 RVA: 0x00148228 File Offset: 0x00146628
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 8;
			return num + 4;
		}

		// Token: 0x040033F7 RID: 13303
		public uint id;

		// Token: 0x040033F8 RID: 13304
		public uint overlayNums;

		// Token: 0x040033F9 RID: 13305
		public ulong startTime;

		// Token: 0x040033FA RID: 13306
		public uint duration;
	}
}
