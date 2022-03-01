using System;

namespace Protocol
{
	// Token: 0x02000892 RID: 2194
	[Protocol]
	public class WorldGuildDungeonBossOddBlood : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006682 RID: 26242 RVA: 0x0012FA9C File Offset: 0x0012DE9C
		public uint GetMsgID()
		{
			return 608521U;
		}

		// Token: 0x06006683 RID: 26243 RVA: 0x0012FAA3 File Offset: 0x0012DEA3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006684 RID: 26244 RVA: 0x0012FAAB File Offset: 0x0012DEAB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006685 RID: 26245 RVA: 0x0012FAB4 File Offset: 0x0012DEB4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.bossOddBlood);
			BaseDLL.encode_uint64(buffer, ref pos_, this.bossTotalBlood);
		}

		// Token: 0x06006686 RID: 26246 RVA: 0x0012FAD2 File Offset: 0x0012DED2
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.bossOddBlood);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.bossTotalBlood);
		}

		// Token: 0x06006687 RID: 26247 RVA: 0x0012FAF0 File Offset: 0x0012DEF0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.bossOddBlood);
			BaseDLL.encode_uint64(buffer, ref pos_, this.bossTotalBlood);
		}

		// Token: 0x06006688 RID: 26248 RVA: 0x0012FB0E File Offset: 0x0012DF0E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.bossOddBlood);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.bossTotalBlood);
		}

		// Token: 0x06006689 RID: 26249 RVA: 0x0012FB2C File Offset: 0x0012DF2C
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 8;
		}

		// Token: 0x04002DD6 RID: 11734
		public const uint MsgID = 608521U;

		// Token: 0x04002DD7 RID: 11735
		public uint Sequence;

		// Token: 0x04002DD8 RID: 11736
		public ulong bossOddBlood;

		// Token: 0x04002DD9 RID: 11737
		public ulong bossTotalBlood;
	}
}
