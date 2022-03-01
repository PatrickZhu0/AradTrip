using System;

namespace Protocol
{
	// Token: 0x02000B94 RID: 2964
	[Protocol]
	public class WorldTeamProcessRequesterRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007D8F RID: 32143 RVA: 0x00165508 File Offset: 0x00163908
		public uint GetMsgID()
		{
			return 601641U;
		}

		// Token: 0x06007D90 RID: 32144 RVA: 0x0016550F File Offset: 0x0016390F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007D91 RID: 32145 RVA: 0x00165517 File Offset: 0x00163917
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007D92 RID: 32146 RVA: 0x00165520 File Offset: 0x00163920
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.targetId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007D93 RID: 32147 RVA: 0x0016553E File Offset: 0x0016393E
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.targetId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007D94 RID: 32148 RVA: 0x0016555C File Offset: 0x0016395C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.targetId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007D95 RID: 32149 RVA: 0x0016557A File Offset: 0x0016397A
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.targetId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007D96 RID: 32150 RVA: 0x00165598 File Offset: 0x00163998
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 4;
		}

		// Token: 0x04003B88 RID: 15240
		public const uint MsgID = 601641U;

		// Token: 0x04003B89 RID: 15241
		public uint Sequence;

		// Token: 0x04003B8A RID: 15242
		public ulong targetId;

		// Token: 0x04003B8B RID: 15243
		public uint result;
	}
}
