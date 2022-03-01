using System;

namespace Protocol
{
	// Token: 0x02000BC9 RID: 3017
	[Protocol]
	public class TeamCopyVoteNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007EBE RID: 32446 RVA: 0x00167B80 File Offset: 0x00165F80
		public uint GetMsgID()
		{
			return 1100017U;
		}

		// Token: 0x06007EBF RID: 32447 RVA: 0x00167B87 File Offset: 0x00165F87
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007EC0 RID: 32448 RVA: 0x00167B8F File Offset: 0x00165F8F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007EC1 RID: 32449 RVA: 0x00167B98 File Offset: 0x00165F98
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.vote);
		}

		// Token: 0x06007EC2 RID: 32450 RVA: 0x00167BB6 File Offset: 0x00165FB6
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.vote);
		}

		// Token: 0x06007EC3 RID: 32451 RVA: 0x00167BD4 File Offset: 0x00165FD4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.vote);
		}

		// Token: 0x06007EC4 RID: 32452 RVA: 0x00167BF2 File Offset: 0x00165FF2
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.vote);
		}

		// Token: 0x06007EC5 RID: 32453 RVA: 0x00167C10 File Offset: 0x00166010
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 4;
		}

		// Token: 0x04003C82 RID: 15490
		public const uint MsgID = 1100017U;

		// Token: 0x04003C83 RID: 15491
		public uint Sequence;

		// Token: 0x04003C84 RID: 15492
		public ulong roleId;

		// Token: 0x04003C85 RID: 15493
		public uint vote;
	}
}
