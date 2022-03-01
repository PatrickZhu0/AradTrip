using System;

namespace Protocol
{
	// Token: 0x02000BB9 RID: 3001
	[Protocol]
	public class TeamCopyTeamDataReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007E3A RID: 32314 RVA: 0x00166204 File Offset: 0x00164604
		public uint GetMsgID()
		{
			return 1100005U;
		}

		// Token: 0x06007E3B RID: 32315 RVA: 0x0016620B File Offset: 0x0016460B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007E3C RID: 32316 RVA: 0x00166213 File Offset: 0x00164613
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007E3D RID: 32317 RVA: 0x0016621C File Offset: 0x0016461C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamType);
		}

		// Token: 0x06007E3E RID: 32318 RVA: 0x0016623A File Offset: 0x0016463A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamType);
		}

		// Token: 0x06007E3F RID: 32319 RVA: 0x00166258 File Offset: 0x00164658
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamType);
		}

		// Token: 0x06007E40 RID: 32320 RVA: 0x00166276 File Offset: 0x00164676
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamType);
		}

		// Token: 0x06007E41 RID: 32321 RVA: 0x00166294 File Offset: 0x00164694
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003C2F RID: 15407
		public const uint MsgID = 1100005U;

		// Token: 0x04003C30 RID: 15408
		public uint Sequence;

		// Token: 0x04003C31 RID: 15409
		public uint teamId;

		// Token: 0x04003C32 RID: 15410
		public uint teamType;
	}
}
