using System;

namespace Protocol
{
	// Token: 0x02000BC1 RID: 3009
	[Protocol]
	public class TeamCopyTeamApplyRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007E79 RID: 32377 RVA: 0x001674D0 File Offset: 0x001658D0
		public uint GetMsgID()
		{
			return 1100010U;
		}

		// Token: 0x06007E7A RID: 32378 RVA: 0x001674D7 File Offset: 0x001658D7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007E7B RID: 32379 RVA: 0x001674DF File Offset: 0x001658DF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007E7C RID: 32380 RVA: 0x001674E8 File Offset: 0x001658E8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.expireTime);
		}

		// Token: 0x06007E7D RID: 32381 RVA: 0x00167514 File Offset: 0x00165914
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.expireTime);
		}

		// Token: 0x06007E7E RID: 32382 RVA: 0x00167540 File Offset: 0x00165940
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.expireTime);
		}

		// Token: 0x06007E7F RID: 32383 RVA: 0x0016756C File Offset: 0x0016596C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.expireTime);
		}

		// Token: 0x06007E80 RID: 32384 RVA: 0x00167598 File Offset: 0x00165998
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + 8;
		}

		// Token: 0x04003C67 RID: 15463
		public const uint MsgID = 1100010U;

		// Token: 0x04003C68 RID: 15464
		public uint Sequence;

		// Token: 0x04003C69 RID: 15465
		public uint retCode;

		// Token: 0x04003C6A RID: 15466
		public uint teamId;

		// Token: 0x04003C6B RID: 15467
		public ulong expireTime;
	}
}
