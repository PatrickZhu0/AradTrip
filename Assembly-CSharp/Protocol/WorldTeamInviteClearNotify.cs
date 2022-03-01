using System;

namespace Protocol
{
	// Token: 0x02000BA2 RID: 2978
	[Protocol]
	public class WorldTeamInviteClearNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007E0D RID: 32269 RVA: 0x00165E28 File Offset: 0x00164228
		public uint GetMsgID()
		{
			return 601656U;
		}

		// Token: 0x06007E0E RID: 32270 RVA: 0x00165E2F File Offset: 0x0016422F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007E0F RID: 32271 RVA: 0x00165E37 File Offset: 0x00164237
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007E10 RID: 32272 RVA: 0x00165E40 File Offset: 0x00164240
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int32(buffer, ref pos_, this.teamId);
		}

		// Token: 0x06007E11 RID: 32273 RVA: 0x00165E50 File Offset: 0x00164250
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int32(buffer, ref pos_, ref this.teamId);
		}

		// Token: 0x06007E12 RID: 32274 RVA: 0x00165E60 File Offset: 0x00164260
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int32(buffer, ref pos_, this.teamId);
		}

		// Token: 0x06007E13 RID: 32275 RVA: 0x00165E70 File Offset: 0x00164270
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int32(buffer, ref pos_, ref this.teamId);
		}

		// Token: 0x06007E14 RID: 32276 RVA: 0x00165E80 File Offset: 0x00164280
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003BB8 RID: 15288
		public const uint MsgID = 601656U;

		// Token: 0x04003BB9 RID: 15289
		public uint Sequence;

		// Token: 0x04003BBA RID: 15290
		public int teamId;
	}
}
