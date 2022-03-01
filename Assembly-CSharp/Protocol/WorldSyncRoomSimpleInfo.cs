using System;

namespace Protocol
{
	// Token: 0x02000AD1 RID: 2769
	[Protocol]
	public class WorldSyncRoomSimpleInfo : IProtocolStream, IGetMsgID
	{
		// Token: 0x060077A4 RID: 30628 RVA: 0x0015A1E5 File Offset: 0x001585E5
		public uint GetMsgID()
		{
			return 607802U;
		}

		// Token: 0x060077A5 RID: 30629 RVA: 0x0015A1EC File Offset: 0x001585EC
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060077A6 RID: 30630 RVA: 0x0015A1F4 File Offset: 0x001585F4
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060077A7 RID: 30631 RVA: 0x0015A1FD File Offset: 0x001585FD
		public void encode(byte[] buffer, ref int pos_)
		{
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x060077A8 RID: 30632 RVA: 0x0015A20C File Offset: 0x0015860C
		public void decode(byte[] buffer, ref int pos_)
		{
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x060077A9 RID: 30633 RVA: 0x0015A21B File Offset: 0x0015861B
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x060077AA RID: 30634 RVA: 0x0015A22A File Offset: 0x0015862A
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x060077AB RID: 30635 RVA: 0x0015A23C File Offset: 0x0015863C
		public int getLen()
		{
			int num = 0;
			return num + this.info.getLen();
		}

		// Token: 0x04003856 RID: 14422
		public const uint MsgID = 607802U;

		// Token: 0x04003857 RID: 14423
		public uint Sequence;

		// Token: 0x04003858 RID: 14424
		public RoomSimpleInfo info = new RoomSimpleInfo();
	}
}
