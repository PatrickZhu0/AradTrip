using System;

namespace Protocol
{
	// Token: 0x02000946 RID: 2374
	[Protocol]
	public class WorldEquipRecoOpenJarsRecordReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006BDA RID: 27610 RVA: 0x0013AC64 File Offset: 0x00139064
		public uint GetMsgID()
		{
			return 600904U;
		}

		// Token: 0x06006BDB RID: 27611 RVA: 0x0013AC6B File Offset: 0x0013906B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006BDC RID: 27612 RVA: 0x0013AC73 File Offset: 0x00139073
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006BDD RID: 27613 RVA: 0x0013AC7C File Offset: 0x0013907C
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006BDE RID: 27614 RVA: 0x0013AC7E File Offset: 0x0013907E
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006BDF RID: 27615 RVA: 0x0013AC80 File Offset: 0x00139080
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006BE0 RID: 27616 RVA: 0x0013AC82 File Offset: 0x00139082
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006BE1 RID: 27617 RVA: 0x0013AC84 File Offset: 0x00139084
		public int getLen()
		{
			return 0;
		}

		// Token: 0x040030D7 RID: 12503
		public const uint MsgID = 600904U;

		// Token: 0x040030D8 RID: 12504
		public uint Sequence;
	}
}
