using System;

namespace Protocol
{
	// Token: 0x02000AF3 RID: 2803
	[Protocol]
	public class WorldRoomBattleCancelRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060078D6 RID: 30934 RVA: 0x0015CA3C File Offset: 0x0015AE3C
		public uint GetMsgID()
		{
			return 607838U;
		}

		// Token: 0x060078D7 RID: 30935 RVA: 0x0015CA43 File Offset: 0x0015AE43
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060078D8 RID: 30936 RVA: 0x0015CA4B File Offset: 0x0015AE4B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060078D9 RID: 30937 RVA: 0x0015CA54 File Offset: 0x0015AE54
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060078DA RID: 30938 RVA: 0x0015CA64 File Offset: 0x0015AE64
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060078DB RID: 30939 RVA: 0x0015CA74 File Offset: 0x0015AE74
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060078DC RID: 30940 RVA: 0x0015CA84 File Offset: 0x0015AE84
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060078DD RID: 30941 RVA: 0x0015CA94 File Offset: 0x0015AE94
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003902 RID: 14594
		public const uint MsgID = 607838U;

		// Token: 0x04003903 RID: 14595
		public uint Sequence;

		// Token: 0x04003904 RID: 14596
		public uint result;
	}
}
