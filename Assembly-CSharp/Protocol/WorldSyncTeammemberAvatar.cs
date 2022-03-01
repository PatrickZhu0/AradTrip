using System;

namespace Protocol
{
	// Token: 0x02000B8F RID: 2959
	[Protocol]
	public class WorldSyncTeammemberAvatar : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007D62 RID: 32098 RVA: 0x0016517B File Offset: 0x0016357B
		public uint GetMsgID()
		{
			return 601636U;
		}

		// Token: 0x06007D63 RID: 32099 RVA: 0x00165182 File Offset: 0x00163582
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007D64 RID: 32100 RVA: 0x0016518A File Offset: 0x0016358A
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007D65 RID: 32101 RVA: 0x00165193 File Offset: 0x00163593
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.memberId);
			this.avatar.encode(buffer, ref pos_);
		}

		// Token: 0x06007D66 RID: 32102 RVA: 0x001651B0 File Offset: 0x001635B0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.memberId);
			this.avatar.decode(buffer, ref pos_);
		}

		// Token: 0x06007D67 RID: 32103 RVA: 0x001651CD File Offset: 0x001635CD
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.memberId);
			this.avatar.encode(buffer, ref pos_);
		}

		// Token: 0x06007D68 RID: 32104 RVA: 0x001651EA File Offset: 0x001635EA
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.memberId);
			this.avatar.decode(buffer, ref pos_);
		}

		// Token: 0x06007D69 RID: 32105 RVA: 0x00165208 File Offset: 0x00163608
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + this.avatar.getLen();
		}

		// Token: 0x04003B79 RID: 15225
		public const uint MsgID = 601636U;

		// Token: 0x04003B7A RID: 15226
		public uint Sequence;

		// Token: 0x04003B7B RID: 15227
		public ulong memberId;

		// Token: 0x04003B7C RID: 15228
		public PlayerAvatar avatar = new PlayerAvatar();
	}
}
