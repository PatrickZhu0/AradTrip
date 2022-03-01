using System;

namespace Protocol
{
	// Token: 0x02000BEA RID: 3050
	[Protocol]
	public class TeamCopyAppointmentRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007FD8 RID: 32728 RVA: 0x0016A4E4 File Offset: 0x001688E4
		public uint GetMsgID()
		{
			return 1100048U;
		}

		// Token: 0x06007FD9 RID: 32729 RVA: 0x0016A4EB File Offset: 0x001688EB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007FDA RID: 32730 RVA: 0x0016A4F3 File Offset: 0x001688F3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007FDB RID: 32731 RVA: 0x0016A4FC File Offset: 0x001688FC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06007FDC RID: 32732 RVA: 0x0016A50C File Offset: 0x0016890C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06007FDD RID: 32733 RVA: 0x0016A51C File Offset: 0x0016891C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06007FDE RID: 32734 RVA: 0x0016A52C File Offset: 0x0016892C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06007FDF RID: 32735 RVA: 0x0016A53C File Offset: 0x0016893C
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003D05 RID: 15621
		public const uint MsgID = 1100048U;

		// Token: 0x04003D06 RID: 15622
		public uint Sequence;

		// Token: 0x04003D07 RID: 15623
		public uint retCode;
	}
}
