using System;

namespace Protocol
{
	// Token: 0x02000B95 RID: 2965
	[Protocol]
	public class WorldTeamRaceVoteNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007D98 RID: 32152 RVA: 0x001655B8 File Offset: 0x001639B8
		public uint GetMsgID()
		{
			return 601642U;
		}

		// Token: 0x06007D99 RID: 32153 RVA: 0x001655BF File Offset: 0x001639BF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007D9A RID: 32154 RVA: 0x001655C7 File Offset: 0x001639C7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007D9B RID: 32155 RVA: 0x001655D0 File Offset: 0x001639D0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonId);
		}

		// Token: 0x06007D9C RID: 32156 RVA: 0x001655E0 File Offset: 0x001639E0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonId);
		}

		// Token: 0x06007D9D RID: 32157 RVA: 0x001655F0 File Offset: 0x001639F0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonId);
		}

		// Token: 0x06007D9E RID: 32158 RVA: 0x00165600 File Offset: 0x00163A00
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonId);
		}

		// Token: 0x06007D9F RID: 32159 RVA: 0x00165610 File Offset: 0x00163A10
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003B8C RID: 15244
		public const uint MsgID = 601642U;

		// Token: 0x04003B8D RID: 15245
		public uint Sequence;

		// Token: 0x04003B8E RID: 15246
		public uint dungeonId;
	}
}
