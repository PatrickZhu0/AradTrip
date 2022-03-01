using System;

namespace Protocol
{
	// Token: 0x02000AD2 RID: 2770
	[Protocol]
	public class WorldSyncRoomSlotInfo : IProtocolStream, IGetMsgID
	{
		// Token: 0x060077AD RID: 30637 RVA: 0x0015A26D File Offset: 0x0015866D
		public uint GetMsgID()
		{
			return 607803U;
		}

		// Token: 0x060077AE RID: 30638 RVA: 0x0015A274 File Offset: 0x00158674
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060077AF RID: 30639 RVA: 0x0015A27C File Offset: 0x0015867C
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060077B0 RID: 30640 RVA: 0x0015A285 File Offset: 0x00158685
		public void encode(byte[] buffer, ref int pos_)
		{
			this.slotInfo.encode(buffer, ref pos_);
		}

		// Token: 0x060077B1 RID: 30641 RVA: 0x0015A294 File Offset: 0x00158694
		public void decode(byte[] buffer, ref int pos_)
		{
			this.slotInfo.decode(buffer, ref pos_);
		}

		// Token: 0x060077B2 RID: 30642 RVA: 0x0015A2A3 File Offset: 0x001586A3
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.slotInfo.encode(buffer, ref pos_);
		}

		// Token: 0x060077B3 RID: 30643 RVA: 0x0015A2B2 File Offset: 0x001586B2
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.slotInfo.decode(buffer, ref pos_);
		}

		// Token: 0x060077B4 RID: 30644 RVA: 0x0015A2C4 File Offset: 0x001586C4
		public int getLen()
		{
			int num = 0;
			return num + this.slotInfo.getLen();
		}

		// Token: 0x04003859 RID: 14425
		public const uint MsgID = 607803U;

		// Token: 0x0400385A RID: 14426
		public uint Sequence;

		// Token: 0x0400385B RID: 14427
		public RoomSlotInfo slotInfo = new RoomSlotInfo();
	}
}
