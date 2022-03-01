using System;

namespace Protocol
{
	// Token: 0x02000792 RID: 1938
	public class DigMapInfo : IProtocolStream
	{
		// Token: 0x06005EFC RID: 24316 RVA: 0x0011CDD3 File Offset: 0x0011B1D3
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.mapId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.goldDigSize);
			BaseDLL.encode_uint32(buffer, ref pos_, this.silverDigSize);
		}

		// Token: 0x06005EFD RID: 24317 RVA: 0x0011CDFF File Offset: 0x0011B1FF
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mapId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.goldDigSize);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.silverDigSize);
		}

		// Token: 0x06005EFE RID: 24318 RVA: 0x0011CE2B File Offset: 0x0011B22B
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.mapId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.goldDigSize);
			BaseDLL.encode_uint32(buffer, ref pos_, this.silverDigSize);
		}

		// Token: 0x06005EFF RID: 24319 RVA: 0x0011CE57 File Offset: 0x0011B257
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mapId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.goldDigSize);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.silverDigSize);
		}

		// Token: 0x06005F00 RID: 24320 RVA: 0x0011CE84 File Offset: 0x0011B284
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x0400272D RID: 10029
		public uint mapId;

		// Token: 0x0400272E RID: 10030
		public uint goldDigSize;

		// Token: 0x0400272F RID: 10031
		public uint silverDigSize;
	}
}
