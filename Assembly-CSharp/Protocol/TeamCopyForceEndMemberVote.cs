using System;

namespace Protocol
{
	// Token: 0x02000C05 RID: 3077
	[Protocol]
	public class TeamCopyForceEndMemberVote : IProtocolStream, IGetMsgID
	{
		// Token: 0x060080C8 RID: 32968 RVA: 0x0016C0B4 File Offset: 0x0016A4B4
		public uint GetMsgID()
		{
			return 1100074U;
		}

		// Token: 0x060080C9 RID: 32969 RVA: 0x0016C0BB File Offset: 0x0016A4BB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060080CA RID: 32970 RVA: 0x0016C0C3 File Offset: 0x0016A4C3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060080CB RID: 32971 RVA: 0x0016C0CC File Offset: 0x0016A4CC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.vote);
		}

		// Token: 0x060080CC RID: 32972 RVA: 0x0016C0EA File Offset: 0x0016A4EA
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.vote);
		}

		// Token: 0x060080CD RID: 32973 RVA: 0x0016C108 File Offset: 0x0016A508
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.vote);
		}

		// Token: 0x060080CE RID: 32974 RVA: 0x0016C126 File Offset: 0x0016A526
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.vote);
		}

		// Token: 0x060080CF RID: 32975 RVA: 0x0016C144 File Offset: 0x0016A544
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 4;
		}

		// Token: 0x04003D76 RID: 15734
		public const uint MsgID = 1100074U;

		// Token: 0x04003D77 RID: 15735
		public uint Sequence;

		// Token: 0x04003D78 RID: 15736
		public ulong roleId;

		// Token: 0x04003D79 RID: 15737
		public uint vote;
	}
}
