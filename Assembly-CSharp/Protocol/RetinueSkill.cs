using System;

namespace Protocol
{
	// Token: 0x02000AB2 RID: 2738
	public class RetinueSkill : IProtocolStream
	{
		// Token: 0x060076F0 RID: 30448 RVA: 0x00157FE0 File Offset: 0x001563E0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.bufferId);
		}

		// Token: 0x060076F1 RID: 30449 RVA: 0x00157FFE File Offset: 0x001563FE
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.bufferId);
		}

		// Token: 0x060076F2 RID: 30450 RVA: 0x0015801C File Offset: 0x0015641C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.bufferId);
		}

		// Token: 0x060076F3 RID: 30451 RVA: 0x0015803A File Offset: 0x0015643A
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.bufferId);
		}

		// Token: 0x060076F4 RID: 30452 RVA: 0x00158058 File Offset: 0x00156458
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x040037B2 RID: 14258
		public uint id;

		// Token: 0x040037B3 RID: 14259
		public uint bufferId;
	}
}
