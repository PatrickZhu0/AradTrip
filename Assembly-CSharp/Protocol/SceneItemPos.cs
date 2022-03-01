using System;

namespace Protocol
{
	// Token: 0x02000B12 RID: 2834
	public class SceneItemPos : IProtocolStream
	{
		// Token: 0x060079BA RID: 31162 RVA: 0x0015E044 File Offset: 0x0015C444
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.x);
			BaseDLL.encode_uint32(buffer, ref pos_, this.y);
		}

		// Token: 0x060079BB RID: 31163 RVA: 0x0015E062 File Offset: 0x0015C462
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.x);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.y);
		}

		// Token: 0x060079BC RID: 31164 RVA: 0x0015E080 File Offset: 0x0015C480
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.x);
			BaseDLL.encode_uint32(buffer, ref pos_, this.y);
		}

		// Token: 0x060079BD RID: 31165 RVA: 0x0015E09E File Offset: 0x0015C49E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.x);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.y);
		}

		// Token: 0x060079BE RID: 31166 RVA: 0x0015E0BC File Offset: 0x0015C4BC
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003968 RID: 14696
		public uint x;

		// Token: 0x04003969 RID: 14697
		public uint y;
	}
}
