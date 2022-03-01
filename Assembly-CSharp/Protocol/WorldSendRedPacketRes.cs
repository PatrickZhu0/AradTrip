using System;

namespace Protocol
{
	// Token: 0x02000A82 RID: 2690
	[Protocol]
	public class WorldSendRedPacketRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060075A0 RID: 30112 RVA: 0x00154558 File Offset: 0x00152958
		public uint GetMsgID()
		{
			return 607307U;
		}

		// Token: 0x060075A1 RID: 30113 RVA: 0x0015455F File Offset: 0x0015295F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060075A2 RID: 30114 RVA: 0x00154567 File Offset: 0x00152967
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060075A3 RID: 30115 RVA: 0x00154570 File Offset: 0x00152970
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060075A4 RID: 30116 RVA: 0x00154580 File Offset: 0x00152980
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060075A5 RID: 30117 RVA: 0x00154590 File Offset: 0x00152990
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060075A6 RID: 30118 RVA: 0x001545A0 File Offset: 0x001529A0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060075A7 RID: 30119 RVA: 0x001545B0 File Offset: 0x001529B0
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040036C5 RID: 14021
		public const uint MsgID = 607307U;

		// Token: 0x040036C6 RID: 14022
		public uint Sequence;

		// Token: 0x040036C7 RID: 14023
		public uint result;
	}
}
