using System;

namespace Protocol
{
	// Token: 0x02000A88 RID: 2696
	[Protocol]
	public class WorldGetGuildRedPacketInfoReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060075D6 RID: 30166 RVA: 0x00154D85 File Offset: 0x00153185
		public uint GetMsgID()
		{
			return 607313U;
		}

		// Token: 0x060075D7 RID: 30167 RVA: 0x00154D8C File Offset: 0x0015318C
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060075D8 RID: 30168 RVA: 0x00154D94 File Offset: 0x00153194
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060075D9 RID: 30169 RVA: 0x00154D9D File Offset: 0x0015319D
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060075DA RID: 30170 RVA: 0x00154D9F File Offset: 0x0015319F
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060075DB RID: 30171 RVA: 0x00154DA1 File Offset: 0x001531A1
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060075DC RID: 30172 RVA: 0x00154DA3 File Offset: 0x001531A3
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060075DD RID: 30173 RVA: 0x00154DA8 File Offset: 0x001531A8
		public int getLen()
		{
			return 0;
		}

		// Token: 0x040036DD RID: 14045
		public const uint MsgID = 607313U;

		// Token: 0x040036DE RID: 14046
		public uint Sequence;
	}
}
