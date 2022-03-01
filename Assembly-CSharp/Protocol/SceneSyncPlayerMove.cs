using System;

namespace Protocol
{
	// Token: 0x02000B03 RID: 2819
	[Protocol]
	public class SceneSyncPlayerMove : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007933 RID: 31027 RVA: 0x0015D63E File Offset: 0x0015BA3E
		public uint GetMsgID()
		{
			return 500502U;
		}

		// Token: 0x06007934 RID: 31028 RVA: 0x0015D645 File Offset: 0x0015BA45
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007935 RID: 31029 RVA: 0x0015D64D File Offset: 0x0015BA4D
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007936 RID: 31030 RVA: 0x0015D656 File Offset: 0x0015BA56
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			this.pos.encode(buffer, ref pos_);
			this.dir.encode(buffer, ref pos_);
		}

		// Token: 0x06007937 RID: 31031 RVA: 0x0015D680 File Offset: 0x0015BA80
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			this.pos.decode(buffer, ref pos_);
			this.dir.decode(buffer, ref pos_);
		}

		// Token: 0x06007938 RID: 31032 RVA: 0x0015D6AA File Offset: 0x0015BAAA
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			this.pos.encode(buffer, ref pos_);
			this.dir.encode(buffer, ref pos_);
		}

		// Token: 0x06007939 RID: 31033 RVA: 0x0015D6D4 File Offset: 0x0015BAD4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			this.pos.decode(buffer, ref pos_);
			this.dir.decode(buffer, ref pos_);
		}

		// Token: 0x0600793A RID: 31034 RVA: 0x0015D700 File Offset: 0x0015BB00
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += this.pos.getLen();
			return num + this.dir.getLen();
		}

		// Token: 0x0400393D RID: 14653
		public const uint MsgID = 500502U;

		// Token: 0x0400393E RID: 14654
		public uint Sequence;

		// Token: 0x0400393F RID: 14655
		public ulong id;

		// Token: 0x04003940 RID: 14656
		public ScenePosition pos = new ScenePosition();

		// Token: 0x04003941 RID: 14657
		public SceneDir dir = new SceneDir();
	}
}
