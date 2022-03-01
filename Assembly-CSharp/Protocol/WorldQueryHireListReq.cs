using System;

namespace Protocol
{
	// Token: 0x02000C41 RID: 3137
	[Protocol]
	public class WorldQueryHireListReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060082A2 RID: 33442 RVA: 0x0016FF68 File Offset: 0x0016E368
		public uint GetMsgID()
		{
			return 601790U;
		}

		// Token: 0x060082A3 RID: 33443 RVA: 0x0016FF6F File Offset: 0x0016E36F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060082A4 RID: 33444 RVA: 0x0016FF77 File Offset: 0x0016E377
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060082A5 RID: 33445 RVA: 0x0016FF80 File Offset: 0x0016E380
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060082A6 RID: 33446 RVA: 0x0016FF82 File Offset: 0x0016E382
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060082A7 RID: 33447 RVA: 0x0016FF84 File Offset: 0x0016E384
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060082A8 RID: 33448 RVA: 0x0016FF86 File Offset: 0x0016E386
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060082A9 RID: 33449 RVA: 0x0016FF88 File Offset: 0x0016E388
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003E61 RID: 15969
		public const uint MsgID = 601790U;

		// Token: 0x04003E62 RID: 15970
		public uint Sequence;
	}
}
