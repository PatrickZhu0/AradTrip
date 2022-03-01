using System;

namespace Protocol
{
	// Token: 0x02000AF5 RID: 2805
	[Protocol]
	public class WorldRoomBattleReadyRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060078E8 RID: 30952 RVA: 0x0015CB24 File Offset: 0x0015AF24
		public uint GetMsgID()
		{
			return 607840U;
		}

		// Token: 0x060078E9 RID: 30953 RVA: 0x0015CB2B File Offset: 0x0015AF2B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060078EA RID: 30954 RVA: 0x0015CB33 File Offset: 0x0015AF33
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060078EB RID: 30955 RVA: 0x0015CB3C File Offset: 0x0015AF3C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060078EC RID: 30956 RVA: 0x0015CB4C File Offset: 0x0015AF4C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060078ED RID: 30957 RVA: 0x0015CB5C File Offset: 0x0015AF5C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060078EE RID: 30958 RVA: 0x0015CB6C File Offset: 0x0015AF6C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060078EF RID: 30959 RVA: 0x0015CB7C File Offset: 0x0015AF7C
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003908 RID: 14600
		public const uint MsgID = 607840U;

		// Token: 0x04003909 RID: 14601
		public uint Sequence;

		// Token: 0x0400390A RID: 14602
		public uint result;
	}
}
