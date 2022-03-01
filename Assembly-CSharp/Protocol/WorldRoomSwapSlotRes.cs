using System;

namespace Protocol
{
	// Token: 0x02000AED RID: 2797
	[Protocol]
	public class WorldRoomSwapSlotRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060078A0 RID: 30880 RVA: 0x0015C748 File Offset: 0x0015AB48
		public uint GetMsgID()
		{
			return 607832U;
		}

		// Token: 0x060078A1 RID: 30881 RVA: 0x0015C74F File Offset: 0x0015AB4F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060078A2 RID: 30882 RVA: 0x0015C757 File Offset: 0x0015AB57
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060078A3 RID: 30883 RVA: 0x0015C760 File Offset: 0x0015AB60
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
		}

		// Token: 0x060078A4 RID: 30884 RVA: 0x0015C77E File Offset: 0x0015AB7E
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerId);
		}

		// Token: 0x060078A5 RID: 30885 RVA: 0x0015C79C File Offset: 0x0015AB9C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
		}

		// Token: 0x060078A6 RID: 30886 RVA: 0x0015C7BA File Offset: 0x0015ABBA
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerId);
		}

		// Token: 0x060078A7 RID: 30887 RVA: 0x0015C7D8 File Offset: 0x0015ABD8
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 8;
		}

		// Token: 0x040038EF RID: 14575
		public const uint MsgID = 607832U;

		// Token: 0x040038F0 RID: 14576
		public uint Sequence;

		// Token: 0x040038F1 RID: 14577
		public uint result;

		// Token: 0x040038F2 RID: 14578
		public ulong playerId;
	}
}
