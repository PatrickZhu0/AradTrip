using System;

namespace Protocol
{
	// Token: 0x02000BFD RID: 3069
	[Protocol]
	public class TeamCopyPlayerExpireNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008080 RID: 32896 RVA: 0x0016BB40 File Offset: 0x00169F40
		public uint GetMsgID()
		{
			return 1100066U;
		}

		// Token: 0x06008081 RID: 32897 RVA: 0x0016BB47 File Offset: 0x00169F47
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008082 RID: 32898 RVA: 0x0016BB4F File Offset: 0x00169F4F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008083 RID: 32899 RVA: 0x0016BB58 File Offset: 0x00169F58
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.expireTime);
		}

		// Token: 0x06008084 RID: 32900 RVA: 0x0016BB76 File Offset: 0x00169F76
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.expireTime);
		}

		// Token: 0x06008085 RID: 32901 RVA: 0x0016BB94 File Offset: 0x00169F94
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.expireTime);
		}

		// Token: 0x06008086 RID: 32902 RVA: 0x0016BBB2 File Offset: 0x00169FB2
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.expireTime);
		}

		// Token: 0x06008087 RID: 32903 RVA: 0x0016BBD0 File Offset: 0x00169FD0
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 8;
		}

		// Token: 0x04003D57 RID: 15703
		public const uint MsgID = 1100066U;

		// Token: 0x04003D58 RID: 15704
		public uint Sequence;

		// Token: 0x04003D59 RID: 15705
		public ulong playerId;

		// Token: 0x04003D5A RID: 15706
		public ulong expireTime;
	}
}
