using System;

namespace Protocol
{
	// Token: 0x02000B08 RID: 2824
	[Protocol]
	public class SceneReturnToTown : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007960 RID: 31072 RVA: 0x0015D818 File Offset: 0x0015BC18
		public uint GetMsgID()
		{
			return 500517U;
		}

		// Token: 0x06007961 RID: 31073 RVA: 0x0015D81F File Offset: 0x0015BC1F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007962 RID: 31074 RVA: 0x0015D827 File Offset: 0x0015BC27
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007963 RID: 31075 RVA: 0x0015D830 File Offset: 0x0015BC30
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007964 RID: 31076 RVA: 0x0015D832 File Offset: 0x0015BC32
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007965 RID: 31077 RVA: 0x0015D834 File Offset: 0x0015BC34
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007966 RID: 31078 RVA: 0x0015D836 File Offset: 0x0015BC36
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007967 RID: 31079 RVA: 0x0015D838 File Offset: 0x0015BC38
		public int getLen()
		{
			return 0;
		}

		// Token: 0x0400394A RID: 14666
		public const uint MsgID = 500517U;

		// Token: 0x0400394B RID: 14667
		public uint Sequence;
	}
}
