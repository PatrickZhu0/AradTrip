using System;

namespace Protocol
{
	// Token: 0x02000BF7 RID: 3063
	[Protocol]
	public class TeamCopyRecruitReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600804A RID: 32842 RVA: 0x0016B70B File Offset: 0x00169B0B
		public uint GetMsgID()
		{
			return 1100060U;
		}

		// Token: 0x0600804B RID: 32843 RVA: 0x0016B712 File Offset: 0x00169B12
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600804C RID: 32844 RVA: 0x0016B71A File Offset: 0x00169B1A
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600804D RID: 32845 RVA: 0x0016B723 File Offset: 0x00169B23
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamModel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamId);
		}

		// Token: 0x0600804E RID: 32846 RVA: 0x0016B741 File Offset: 0x00169B41
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamModel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamId);
		}

		// Token: 0x0600804F RID: 32847 RVA: 0x0016B75F File Offset: 0x00169B5F
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamModel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamId);
		}

		// Token: 0x06008050 RID: 32848 RVA: 0x0016B77D File Offset: 0x00169B7D
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamModel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamId);
		}

		// Token: 0x06008051 RID: 32849 RVA: 0x0016B79C File Offset: 0x00169B9C
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003D42 RID: 15682
		public const uint MsgID = 1100060U;

		// Token: 0x04003D43 RID: 15683
		public uint Sequence;

		// Token: 0x04003D44 RID: 15684
		public uint teamModel;

		// Token: 0x04003D45 RID: 15685
		public uint teamId;
	}
}
