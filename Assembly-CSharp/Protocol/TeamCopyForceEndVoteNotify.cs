using System;

namespace Protocol
{
	// Token: 0x02000C03 RID: 3075
	[Protocol]
	public class TeamCopyForceEndVoteNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x060080B6 RID: 32950 RVA: 0x0016BF90 File Offset: 0x0016A390
		public uint GetMsgID()
		{
			return 1100072U;
		}

		// Token: 0x060080B7 RID: 32951 RVA: 0x0016BF97 File Offset: 0x0016A397
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060080B8 RID: 32952 RVA: 0x0016BF9F File Offset: 0x0016A39F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060080B9 RID: 32953 RVA: 0x0016BFA8 File Offset: 0x0016A3A8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.voteDurationTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.voteEndTime);
		}

		// Token: 0x060080BA RID: 32954 RVA: 0x0016BFC6 File Offset: 0x0016A3C6
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.voteDurationTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.voteEndTime);
		}

		// Token: 0x060080BB RID: 32955 RVA: 0x0016BFE4 File Offset: 0x0016A3E4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.voteDurationTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.voteEndTime);
		}

		// Token: 0x060080BC RID: 32956 RVA: 0x0016C002 File Offset: 0x0016A402
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.voteDurationTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.voteEndTime);
		}

		// Token: 0x060080BD RID: 32957 RVA: 0x0016C020 File Offset: 0x0016A420
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003D6F RID: 15727
		public const uint MsgID = 1100072U;

		// Token: 0x04003D70 RID: 15728
		public uint Sequence;

		// Token: 0x04003D71 RID: 15729
		public uint voteDurationTime;

		// Token: 0x04003D72 RID: 15730
		public uint voteEndTime;
	}
}
