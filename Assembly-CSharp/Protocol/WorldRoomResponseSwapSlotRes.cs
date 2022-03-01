using System;

namespace Protocol
{
	// Token: 0x02000AEF RID: 2799
	[Protocol]
	public class WorldRoomResponseSwapSlotRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060078B2 RID: 30898 RVA: 0x0015C8E4 File Offset: 0x0015ACE4
		public uint GetMsgID()
		{
			return 607834U;
		}

		// Token: 0x060078B3 RID: 30899 RVA: 0x0015C8EB File Offset: 0x0015ACEB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060078B4 RID: 30900 RVA: 0x0015C8F3 File Offset: 0x0015ACF3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060078B5 RID: 30901 RVA: 0x0015C8FC File Offset: 0x0015ACFC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060078B6 RID: 30902 RVA: 0x0015C90C File Offset: 0x0015AD0C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060078B7 RID: 30903 RVA: 0x0015C91C File Offset: 0x0015AD1C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060078B8 RID: 30904 RVA: 0x0015C92C File Offset: 0x0015AD2C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060078B9 RID: 30905 RVA: 0x0015C93C File Offset: 0x0015AD3C
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040038F8 RID: 14584
		public const uint MsgID = 607834U;

		// Token: 0x040038F9 RID: 14585
		public uint Sequence;

		// Token: 0x040038FA RID: 14586
		public uint result;
	}
}
