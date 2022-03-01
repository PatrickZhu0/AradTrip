using System;

namespace Protocol
{
	// Token: 0x02000AE3 RID: 2787
	[Protocol]
	public class WorldKickOutRoomRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007846 RID: 30790 RVA: 0x0015C108 File Offset: 0x0015A508
		public uint GetMsgID()
		{
			return 607820U;
		}

		// Token: 0x06007847 RID: 30791 RVA: 0x0015C10F File Offset: 0x0015A50F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007848 RID: 30792 RVA: 0x0015C117 File Offset: 0x0015A517
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007849 RID: 30793 RVA: 0x0015C120 File Offset: 0x0015A520
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x0600784A RID: 30794 RVA: 0x0015C130 File Offset: 0x0015A530
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x0600784B RID: 30795 RVA: 0x0015C140 File Offset: 0x0015A540
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x0600784C RID: 30796 RVA: 0x0015C150 File Offset: 0x0015A550
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x0600784D RID: 30797 RVA: 0x0015C160 File Offset: 0x0015A560
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040038CA RID: 14538
		public const uint MsgID = 607820U;

		// Token: 0x040038CB RID: 14539
		public uint Sequence;

		// Token: 0x040038CC RID: 14540
		public uint result;
	}
}
