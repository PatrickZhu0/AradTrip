using System;

namespace Protocol
{
	// Token: 0x02000880 RID: 2176
	public class GuildDungeonBossBlood : IProtocolStream
	{
		// Token: 0x060065F2 RID: 26098 RVA: 0x0012E5C0 File Offset: 0x0012C9C0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.oddBlood);
			BaseDLL.encode_uint64(buffer, ref pos_, this.verifyBlood);
		}

		// Token: 0x060065F3 RID: 26099 RVA: 0x0012E5EC File Offset: 0x0012C9EC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.oddBlood);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.verifyBlood);
		}

		// Token: 0x060065F4 RID: 26100 RVA: 0x0012E618 File Offset: 0x0012CA18
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.oddBlood);
			BaseDLL.encode_uint64(buffer, ref pos_, this.verifyBlood);
		}

		// Token: 0x060065F5 RID: 26101 RVA: 0x0012E644 File Offset: 0x0012CA44
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.oddBlood);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.verifyBlood);
		}

		// Token: 0x060065F6 RID: 26102 RVA: 0x0012E670 File Offset: 0x0012CA70
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 8;
			return num + 8;
		}

		// Token: 0x04002D9E RID: 11678
		public uint dungeonId;

		// Token: 0x04002D9F RID: 11679
		public ulong oddBlood;

		// Token: 0x04002DA0 RID: 11680
		public ulong verifyBlood;
	}
}
