using System;

namespace Protocol
{
	// Token: 0x02000BE9 RID: 3049
	[Protocol]
	public class TeamCopyAppointmentReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007FCF RID: 32719 RVA: 0x0016A434 File Offset: 0x00168834
		public uint GetMsgID()
		{
			return 1100047U;
		}

		// Token: 0x06007FD0 RID: 32720 RVA: 0x0016A43B File Offset: 0x0016883B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007FD1 RID: 32721 RVA: 0x0016A443 File Offset: 0x00168843
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007FD2 RID: 32722 RVA: 0x0016A44C File Offset: 0x0016884C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.post);
		}

		// Token: 0x06007FD3 RID: 32723 RVA: 0x0016A46A File Offset: 0x0016886A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.post);
		}

		// Token: 0x06007FD4 RID: 32724 RVA: 0x0016A488 File Offset: 0x00168888
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.post);
		}

		// Token: 0x06007FD5 RID: 32725 RVA: 0x0016A4A6 File Offset: 0x001688A6
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.post);
		}

		// Token: 0x06007FD6 RID: 32726 RVA: 0x0016A4C4 File Offset: 0x001688C4
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 4;
		}

		// Token: 0x04003D01 RID: 15617
		public const uint MsgID = 1100047U;

		// Token: 0x04003D02 RID: 15618
		public uint Sequence;

		// Token: 0x04003D03 RID: 15619
		public ulong playerId;

		// Token: 0x04003D04 RID: 15620
		public uint post;
	}
}
