using System;

namespace Protocol
{
	// Token: 0x02000BB7 RID: 2999
	[Protocol]
	public class TeamCopyCreateTeamReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007E28 RID: 32296 RVA: 0x00165FC0 File Offset: 0x001643C0
		public uint GetMsgID()
		{
			return 1100003U;
		}

		// Token: 0x06007E29 RID: 32297 RVA: 0x00165FC7 File Offset: 0x001643C7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007E2A RID: 32298 RVA: 0x00165FCF File Offset: 0x001643CF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007E2B RID: 32299 RVA: 0x00165FD8 File Offset: 0x001643D8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamGrade);
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamModel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.equipScore);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param);
		}

		// Token: 0x06007E2C RID: 32300 RVA: 0x0016602C File Offset: 0x0016442C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamGrade);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamModel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.equipScore);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param);
		}

		// Token: 0x06007E2D RID: 32301 RVA: 0x00166080 File Offset: 0x00164480
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamGrade);
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamModel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.equipScore);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param);
		}

		// Token: 0x06007E2E RID: 32302 RVA: 0x001660D4 File Offset: 0x001644D4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamGrade);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamModel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.equipScore);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param);
		}

		// Token: 0x06007E2F RID: 32303 RVA: 0x00166128 File Offset: 0x00164528
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003C24 RID: 15396
		public const uint MsgID = 1100003U;

		// Token: 0x04003C25 RID: 15397
		public uint Sequence;

		// Token: 0x04003C26 RID: 15398
		public uint teamType;

		// Token: 0x04003C27 RID: 15399
		public uint teamGrade;

		// Token: 0x04003C28 RID: 15400
		public uint teamModel;

		// Token: 0x04003C29 RID: 15401
		public uint equipScore;

		// Token: 0x04003C2A RID: 15402
		public uint param;
	}
}
