using System;

namespace Protocol
{
	// Token: 0x02000BB8 RID: 3000
	[Protocol]
	public class TeamCopyCreateTeamRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007E31 RID: 32305 RVA: 0x00166154 File Offset: 0x00164554
		public uint GetMsgID()
		{
			return 1100004U;
		}

		// Token: 0x06007E32 RID: 32306 RVA: 0x0016615B File Offset: 0x0016455B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007E33 RID: 32307 RVA: 0x00166163 File Offset: 0x00164563
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007E34 RID: 32308 RVA: 0x0016616C File Offset: 0x0016456C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06007E35 RID: 32309 RVA: 0x0016618A File Offset: 0x0016458A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06007E36 RID: 32310 RVA: 0x001661A8 File Offset: 0x001645A8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06007E37 RID: 32311 RVA: 0x001661C6 File Offset: 0x001645C6
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06007E38 RID: 32312 RVA: 0x001661E4 File Offset: 0x001645E4
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003C2B RID: 15403
		public const uint MsgID = 1100004U;

		// Token: 0x04003C2C RID: 15404
		public uint Sequence;

		// Token: 0x04003C2D RID: 15405
		public uint teamId;

		// Token: 0x04003C2E RID: 15406
		public uint retCode;
	}
}
