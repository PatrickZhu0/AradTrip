using System;

namespace Protocol
{
	// Token: 0x02000AB4 RID: 2740
	public class SceneRetinue : IProtocolStream
	{
		// Token: 0x060076FC RID: 30460 RVA: 0x00158301 File Offset: 0x00156701
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.level);
		}

		// Token: 0x060076FD RID: 30461 RVA: 0x0015831F File Offset: 0x0015671F
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.level);
		}

		// Token: 0x060076FE RID: 30462 RVA: 0x0015833D File Offset: 0x0015673D
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.level);
		}

		// Token: 0x060076FF RID: 30463 RVA: 0x0015835B File Offset: 0x0015675B
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.level);
		}

		// Token: 0x06007700 RID: 30464 RVA: 0x0015837C File Offset: 0x0015677C
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 1;
		}

		// Token: 0x040037B9 RID: 14265
		public uint id;

		// Token: 0x040037BA RID: 14266
		public byte level;
	}
}
