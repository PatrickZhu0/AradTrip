using System;

namespace Protocol
{
	// Token: 0x02000890 RID: 2192
	[Protocol]
	public class WorldGuildDungeonBossDeadNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006670 RID: 26224 RVA: 0x0012F9B1 File Offset: 0x0012DDB1
		public uint GetMsgID()
		{
			return 608512U;
		}

		// Token: 0x06006671 RID: 26225 RVA: 0x0012F9B8 File Offset: 0x0012DDB8
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006672 RID: 26226 RVA: 0x0012F9C0 File Offset: 0x0012DDC0
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006673 RID: 26227 RVA: 0x0012F9C9 File Offset: 0x0012DDC9
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonId);
		}

		// Token: 0x06006674 RID: 26228 RVA: 0x0012F9D9 File Offset: 0x0012DDD9
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonId);
		}

		// Token: 0x06006675 RID: 26229 RVA: 0x0012F9E9 File Offset: 0x0012DDE9
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonId);
		}

		// Token: 0x06006676 RID: 26230 RVA: 0x0012F9F9 File Offset: 0x0012DDF9
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonId);
		}

		// Token: 0x06006677 RID: 26231 RVA: 0x0012FA0C File Offset: 0x0012DE0C
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002DD0 RID: 11728
		public const uint MsgID = 608512U;

		// Token: 0x04002DD1 RID: 11729
		public uint Sequence;

		// Token: 0x04002DD2 RID: 11730
		public uint dungeonId;
	}
}
