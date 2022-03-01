using System;

namespace Protocol
{
	// Token: 0x02000AF7 RID: 2807
	[Protocol]
	public class WorldRoomSendInviteLinkRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060078FA RID: 30970 RVA: 0x0015CC48 File Offset: 0x0015B048
		public uint GetMsgID()
		{
			return 607842U;
		}

		// Token: 0x060078FB RID: 30971 RVA: 0x0015CC4F File Offset: 0x0015B04F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060078FC RID: 30972 RVA: 0x0015CC57 File Offset: 0x0015B057
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060078FD RID: 30973 RVA: 0x0015CC60 File Offset: 0x0015B060
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060078FE RID: 30974 RVA: 0x0015CC70 File Offset: 0x0015B070
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060078FF RID: 30975 RVA: 0x0015CC80 File Offset: 0x0015B080
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007900 RID: 30976 RVA: 0x0015CC90 File Offset: 0x0015B090
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007901 RID: 30977 RVA: 0x0015CCA0 File Offset: 0x0015B0A0
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400390F RID: 14607
		public const uint MsgID = 607842U;

		// Token: 0x04003910 RID: 14608
		public uint Sequence;

		// Token: 0x04003911 RID: 14609
		public uint result;
	}
}
