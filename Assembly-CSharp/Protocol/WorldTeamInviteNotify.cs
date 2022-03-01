using System;

namespace Protocol
{
	// Token: 0x02000B98 RID: 2968
	[Protocol]
	public class WorldTeamInviteNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007DB3 RID: 32179 RVA: 0x0016575B File Offset: 0x00163B5B
		public uint GetMsgID()
		{
			return 601645U;
		}

		// Token: 0x06007DB4 RID: 32180 RVA: 0x00165762 File Offset: 0x00163B62
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007DB5 RID: 32181 RVA: 0x0016576A File Offset: 0x00163B6A
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007DB6 RID: 32182 RVA: 0x00165773 File Offset: 0x00163B73
		public void encode(byte[] buffer, ref int pos_)
		{
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x06007DB7 RID: 32183 RVA: 0x00165782 File Offset: 0x00163B82
		public void decode(byte[] buffer, ref int pos_)
		{
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x06007DB8 RID: 32184 RVA: 0x00165791 File Offset: 0x00163B91
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x06007DB9 RID: 32185 RVA: 0x001657A0 File Offset: 0x00163BA0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x06007DBA RID: 32186 RVA: 0x001657B0 File Offset: 0x00163BB0
		public int getLen()
		{
			int num = 0;
			return num + this.info.getLen();
		}

		// Token: 0x04003B96 RID: 15254
		public const uint MsgID = 601645U;

		// Token: 0x04003B97 RID: 15255
		public uint Sequence;

		// Token: 0x04003B98 RID: 15256
		public TeamBaseInfo info = new TeamBaseInfo();
	}
}
