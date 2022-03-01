using System;

namespace Protocol
{
	// Token: 0x02000AD0 RID: 2768
	[Protocol]
	public class WorldSyncRoomInfo : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600779B RID: 30619 RVA: 0x0015A15F File Offset: 0x0015855F
		public uint GetMsgID()
		{
			return 607801U;
		}

		// Token: 0x0600779C RID: 30620 RVA: 0x0015A166 File Offset: 0x00158566
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600779D RID: 30621 RVA: 0x0015A16E File Offset: 0x0015856E
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600779E RID: 30622 RVA: 0x0015A177 File Offset: 0x00158577
		public void encode(byte[] buffer, ref int pos_)
		{
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x0600779F RID: 30623 RVA: 0x0015A186 File Offset: 0x00158586
		public void decode(byte[] buffer, ref int pos_)
		{
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x060077A0 RID: 30624 RVA: 0x0015A195 File Offset: 0x00158595
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x060077A1 RID: 30625 RVA: 0x0015A1A4 File Offset: 0x001585A4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x060077A2 RID: 30626 RVA: 0x0015A1B4 File Offset: 0x001585B4
		public int getLen()
		{
			int num = 0;
			return num + this.info.getLen();
		}

		// Token: 0x04003853 RID: 14419
		public const uint MsgID = 607801U;

		// Token: 0x04003854 RID: 14420
		public uint Sequence;

		// Token: 0x04003855 RID: 14421
		public RoomInfo info = new RoomInfo();
	}
}
