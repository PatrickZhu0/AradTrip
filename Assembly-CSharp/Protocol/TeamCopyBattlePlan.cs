using System;

namespace Protocol
{
	// Token: 0x02000BC4 RID: 3012
	public class TeamCopyBattlePlan : IProtocolStream
	{
		// Token: 0x06007E94 RID: 32404 RVA: 0x00167668 File Offset: 0x00165A68
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.difficulty);
			BaseDLL.encode_uint32(buffer, ref pos_, this.squadId);
		}

		// Token: 0x06007E95 RID: 32405 RVA: 0x00167686 File Offset: 0x00165A86
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.difficulty);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.squadId);
		}

		// Token: 0x06007E96 RID: 32406 RVA: 0x001676A4 File Offset: 0x00165AA4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.difficulty);
			BaseDLL.encode_uint32(buffer, ref pos_, this.squadId);
		}

		// Token: 0x06007E97 RID: 32407 RVA: 0x001676C2 File Offset: 0x00165AC2
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.difficulty);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.squadId);
		}

		// Token: 0x06007E98 RID: 32408 RVA: 0x001676E0 File Offset: 0x00165AE0
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003C71 RID: 15473
		public uint difficulty;

		// Token: 0x04003C72 RID: 15474
		public uint squadId;
	}
}
